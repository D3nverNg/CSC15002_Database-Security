--c.sql
USE QLSVNhom
GO

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
    @MK NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra nếu nhân viên đã tồn tại
    IF EXISTS (SELECT 1 FROM NHANVIEN WHERE MANV = @MANV)
    BEGIN
        RAISERROR('@MANV is exist', 16, 1);
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
        SET @SQL = 'CREATE ASYMMETRIC KEY ' + @MANV+
' WITH ALGORITHM = RSA_2048 ENCRYPTION BY PASSWORD = '''+@MK+''''
        EXEC sp_executesql @SQL;
    END

    -- Mã hóa lương bằng key của nhân viên
    DECLARE @ENCRYPTED_LUONG VARBINARY(500);
    SET @ENCRYPTED_LUONG = ENCRYPTBYASYMKEY(AsymKey_ID(@MANV), CONVERT(VARCHAR, @LUONGCB));

    -- Thêm dữ liệu vào bảng NHANVIEN
    INSERT INTO NHANVIEN (MANV, HOTEN, EMAIL, LUONG, TENDN, MATKHAU, PUBKEY)
    VALUES (@MANV, @HOTEN, @EMAIL, @ENCRYPTED_LUONG, @TENDN, @HASHED_PASSWORD, @MANV);
END
GO

---- ii. Stored dùng để truy vấn dữ liệu nhân viên (NHANVIEN)
IF EXISTS (SELECT 1 FROM sys.procedures WHERE name = 'SP_SEL_PUBLIC_NHANVIEN')
BEGIN
    DROP PROCEDURE SP_SEL_PUBLIC_NHANVIEN;
END
GO

CREATE PROCEDURE SP_SEL_PUBLIC_NHANVIEN
    @TENDN NVARCHAR(100),
    @MK NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
	DECLARE @HASHED_PASSWORD VARBINARY(100);
	DECLARE @MANV VARCHAR(20);

    SET @HASHED_PASSWORD = HASHBYTES('SHA1', @MK);
    SELECT @MANV = MANV FROM NHANVIEN WHERE TENDN = @TENDN AND MATKHAU = @HASHED_PASSWORD;
    IF @MANV IS NULL
    BEGIN
        RAISERROR('Incorrect TENDN or MK', 16, 1);
        RETURN;
    END

    -- Kiểm tra nếu Asymmetric Key tồn tại
    IF NOT EXISTS (SELECT 1 FROM sys.asymmetric_keys WHERE name = @MANV)
    BEGIN
        RAISERROR('RSA key doesnt exist', 16, 1);
        RETURN;
    END

    -- Giải mã lương
    SELECT 
        MANV,
        HOTEN,
        EMAIL,
        CONVERT(INT,CONVERT(VARCHAR,DECRYPTBYASYMKEY(ASYMKEY_ID(@MANV), LUONG, @MK))) AS LUONGCB
    FROM NHANVIEN
    WHERE TENDN = @TENDN AND MATKHAU = @HASHED_PASSWORD;
END
GO

--EXEC SP_INS_PUBLIC_NHANVIEN 'NV12', N'NGUYỄN THỊ YẾN THƠ', 'ntytho@yahoo.com', 99999989, N'ntytho', N'2111';
--EXEC SP_SEL_PUBLIC_NHANVIEN N'nva', N'123456';

