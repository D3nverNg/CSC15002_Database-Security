--c.sql
USE QLSVNhom
GO

---- Tạo Database Master Key (nếu chưa có)
--IF NOT EXISTS (SELECT * FROM sys.symmetric_keys WHERE name = '##MS_DatabaseMasterKey##')
--BEGIN
--    CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'StrongPassword123!';
--    PRINT 'Database Master Key đã được tạo.';
--END
--ELSE
--BEGIN
--    PRINT 'Database Master Key đã tồn tại.';
--END
--GO

---- i. Stored dùng để thêm nhân viên
IF EXISTS (SELECT 1 FROM sys.procedures WHERE name = 'SP_INS_PUBLIC_NHANVIEN')
BEGIN
    DROP PROCEDURE SP_INS_PUBLIC_NHANVIEN;
END
GO

CREATE PROCEDURE SP_INS_PUBLIC_NHANVIEN
    @MANV VARCHAR(20),
    @HOTEN NVARCHAR(100),
    @EMAIL VARCHAR(100),
    @LUONGCB INT,
    @TENDN NVARCHAR(100),
    @MK VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra nếu nhân viên đã tồn tại
    IF EXISTS (SELECT 1 FROM NHANVIEN WHERE MANV = @MANV)
    BEGIN
        RAISERROR('Nhân viên đã tồn tại.', 16, 1);
        RETURN;
    END

	-- Khai báo biến
	DECLARE @HASHED_PASSWORD VARBINARY(100);
    DECLARE @ENCRYPTED_SALARY VARBINARY(100);
	DECLARE @SQL NVARCHAR(MAX);

    -- Mã hóa mật khẩu sử dụng SHA1
    SET @HASHED_PASSWORD = HASHBYTES('SHA1', @MK);

    -- Kiểm tra nếu Asymmetric Key đã tồn tại
    IF NOT EXISTS (SELECT 1 FROM sys.asymmetric_keys WHERE name = @MANV)
    BEGIN
        -- Tạo Asymmetric Key riêng cho nhân viên
        SET @SQL = 'CREATE ASYMMETRIC KEY ' + @MANV +
                   ' WITH ALGORITHM = RSA_2048 ENCRYPTION BY PASSWORD = ''' + @MK + ''''
        EXEC sp_executesql @SQL;
    END

    ---- Mở Asymmetric Key để mã hóa lương
    --SET @SQL = 'OPEN ASYMMETRIC KEY ' + @MANV + 
    --           ' DECRYPTION BY PASSWORD = ''' + @MK + ''''
    --EXEC sp_executesql @SQL;

    -- Mã hóa lương bằng key của nhân viên
    DECLARE @ENCRYPTED_LUONG VARBINARY(500);
    SET @ENCRYPTED_LUONG = ENCRYPTBYASYMKEY(AsymKey_ID(@MANV), CONVERT(VARCHAR, @LUONGCB));

    ---- Đóng Asymmetric Key sau khi sử dụng
    --SET @SQL = 'CLOSE ASYMMETRIC KEY ' + @MANV + ';';
    --EXEC sp_executesql @SQL;

    -- Thêm dữ liệu vào bảng NHANVIEN
    INSERT INTO NHANVIEN (MANV, HOTEN, EMAIL, LUONG, TENDN, MATKHAU, PUBKEY)
    VALUES (@MANV, @HOTEN, @EMAIL, @ENCRYPTED_LUONG, @TENDN, @HASHED_PASSWORD, @MANV);
END
GO

EXEC SP_INS_PUBLIC_NHANVIEN 'NV10', N'NGUYEN VAN BD', 'nvbd@yahoo.com', 300000, N'NVBD', '123456'


---- ii. Stored dùng để truy vấn dữ liệu nhân viên (NHANVIEN)
IF EXISTS (SELECT 1 FROM sys.procedures WHERE name = 'SP_SEL_PUBLIC_NHANVIEN')
BEGIN
    DROP PROCEDURE SP_SEL_PUBLIC_NHANVIEN;
END
GO

CREATE PROCEDURE SP_SEL_PUBLIC_NHANVIEN
    @TENDN NVARCHAR(100),
    @MK VARCHAR(100)  -- 🔹 Mật khẩu riêng của nhân viên để mở key
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @HASHED_PASSWORD VARBINARY(100);
	DECLARE @MANV VARCHAR(20);

    -- Kiểm tra thông tin đăng nhập
    SET @HASHED_PASSWORD = HASHBYTES('SHA1', @MK);
    SELECT @MANV = MANV FROM NHANVIEN WHERE TENDN = @TENDN AND MATKHAU = @HASHED_PASSWORD;
    IF @MANV IS NULL
    BEGIN
        RAISERROR('Tên đăng nhập hoặc mật khẩu không đúng.', 16, 1);
        RETURN;
    END

    -- Kiểm tra nếu Asymmetric Key tồn tại
    IF NOT EXISTS (SELECT 1 FROM sys.asymmetric_keys WHERE name = @MANV)
    BEGIN
        RAISERROR('Khóa RSA không tồn tại.', 16, 1);
        RETURN;
    END

    ---- Mở Asymmetric Key của nhân viên
    --DECLARE @SQL NVARCHAR(MAX);
    --SET @SQL = 'OPEN ASYMMETRIC KEY ' + @MANV + 
    --           ' DECRYPTION BY PASSWORD = ''' + @MK + ''';';
    --EXEC sp_executesql @SQL;

    -- Giải mã lương
    SELECT 
        MANV,
        HOTEN,
        EMAIL,
        CONVERT(INT, DECRYPTBYASYMKEY(AsymKey_ID(@MANV), LUONG)) AS LUONGCB -- 🔹 Chuyển trực tiếp sang INT
    FROM NHANVIEN
    WHERE TENDN = @TENDN AND MATKHAU = @HASHED_PASSWORD;

    ---- Đóng Asymmetric Key sau khi sử dụng
    --SET @SQL = 'CLOSE ASYMMETRIC KEY ' + @MANV + ';';
    --EXEC sp_executesql @SQL;
END
GO

EXEC SP_INS_PUBLIC_NHANVIEN 'NV1', 'NGUYEN VAN A', 'NVA@company.com', 1500000, 'NVA', 'abcd12';
EXEC SP_SEL_PUBLIC_NHANVIEN 'NVBD', '123456';