-- d.sql
USE QLSVNhom;
GO
IF OBJECT_ID('SP_GET_SCORES_BY_CLASS', 'P') IS NOT NULL
    DROP PROCEDURE SP_GET_SCORES_BY_CLASS;
GO

CREATE PROCEDURE SP_GET_SCORES_BY_CLASS
    @MALOP VARCHAR(20),  -- Mã lớp cần lấy điểm
    @PUBKEY VARCHAR(20),  -- Khóa công khai của nhân viên để giải mã
	@MK NVARCHAR(20),
    @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    -- Kiểm tra nếu lớp tồn tại
    IF NOT EXISTS (SELECT 1 FROM LOP WHERE MALOP = @MALOP)
    BEGIN
        SET @ErrorMessage = 'Mã lớp không tồn tại!';
        RETURN;
    END

    -- Kiểm tra nếu khóa bất đối xứng tồn tại
    IF NOT EXISTS (SELECT 1 FROM sys.asymmetric_keys WHERE name = @PUBKEY)
    BEGIN
        SET @ErrorMessage = 'Khóa giải mã không hợp lệ!';
        RETURN;
    END

    -- Lấy danh sách điểm của sinh viên trong lớp và giải mã
    SELECT 
        S.MASV, 
        S.HOTEN, 
        B.MAHP, 
        H.TENHP,
        CAST(
       DecryptByAsymKey(AsymKey_ID(@PUBKEY), B.DIEMTHI, @MK) 
       AS DECIMAL(18,2)) AS DIEM
    FROM BANGDIEM B
    JOIN SINHVIEN S ON B.MASV = S.MASV
    JOIN HOCPHAN H ON B.MAHP = H.MAHP
    WHERE S.MALOP = @MALOP;
END
GO

-- Xóa stored procedure nếu đã tồn tại
IF OBJECT_ID('SP_INSERT_STUDENT', 'P') IS NOT NULL
    DROP PROCEDURE SP_INSERT_STUDENT;
GO

CREATE PROCEDURE SP_INSERT_STUDENT
    @MASV VARCHAR(20),
    @HOTEN NVARCHAR(100),
    @NGAYSINH DATETIME,
    @DIACHI NVARCHAR(200),
    @MALOP VARCHAR(20),
    @TENDN NVARCHAR(100),
    @MATKHAU NVARCHAR(100),  -- Mật khẩu gốc, sẽ được mã hóa
    @ErrorMessage NVARCHAR(200) OUTPUT -- Trả về lỗi nếu có
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;

        -- 1️ Kiểm tra nếu tên đăng nhập đã tồn tại
        IF EXISTS (SELECT 1 FROM SINHVIEN WHERE TENDN = @TENDN)
        BEGIN
            SET @ErrorMessage = 'Tên đăng nhập đã tồn tại!';
            RETURN;
        END

        -- 2️ Kiểm tra nếu lớp học tồn tại
        IF NOT EXISTS (SELECT 1 FROM LOP WHERE MALOP = @MALOP)
        BEGIN
            SET @ErrorMessage = 'Mã lớp không hợp lệ!';
            RETURN;
        END

        -- 4️ Mã hóa mật khẩu bằng SHA2_256
        DECLARE @EncryptedPassword VARBINARY(MAX);
        SET @EncryptedPassword = HASHBYTES('SHA2_256', @MATKHAU);

        -- 5️ Chèn dữ liệu vào bảng SINHVIEN
        INSERT INTO SINHVIEN (MASV, HOTEN, NGAYSINH, DIACHI, MALOP, TENDN, MATKHAU)
        VALUES (@MASV, @HOTEN, @NGAYSINH, @DIACHI, @MALOP, @TENDN, @EncryptedPassword);

        SET @ErrorMessage = '';
    END TRY
    BEGIN CATCH
        -- Xử lý lỗi
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH
END;
GO

-- Xóa procedure nếu tồn tại trước khi tạo mới
IF OBJECT_ID('SP_DELETE_STUDENT', 'P') IS NOT NULL
    DROP PROCEDURE SP_DELETE_STUDENT;
GO

CREATE PROCEDURE SP_DELETE_STUDENT
    @MASV NVARCHAR(20),
    @MALOP NVARCHAR(20),
    @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS(SELECT 1 FROM SINHVIEN WHERE MASV = @MASV AND MALOP = @MALOP)
    BEGIN
        SET @ErrorMessage = 'Sinh viên không tồn tại trong lớp.';
        RETURN;
    END

  DELETE FROM BANGDIEM WHERE MASV = @MASV;
    DELETE FROM SINHVIEN
    WHERE MASV = @MASV AND MALOP = @MALOP;

    SET @ErrorMessage = '';
END
GO

-- Xóa procedure nếu tồn tại trước khi tạo mới
IF OBJECT_ID('SP_GENERATE_NEW_STUDENT_ID', 'P') IS NOT NULL
    DROP PROCEDURE SP_GENERATE_NEW_STUDENT_ID;
GO

CREATE PROCEDURE SP_GENERATE_NEW_STUDENT_ID
AS
BEGIN
    DECLARE @NewID INT;
    DECLARE @MaxID NVARCHAR(20);
    SELECT @MaxID = MAX(MASV) FROM SINHVIEN;
    IF @MaxID IS NULL
        SET @NewID = 1;
    ELSE
        SET @NewID = CAST(SUBSTRING(@MaxID, PATINDEX('%[0-9]%', @MaxID), LEN(@MaxID)) AS INT) + 1;
    SELECT 'SV' + RIGHT('000' + CAST(@NewID AS NVARCHAR(10)), 3) AS NewMASV;
END
GO

-- Xóa procedure nếu tồn tại trước khi tạo mới
IF OBJECT_ID('SP_UPDATE_STUDENT_INFO', 'P') IS NOT NULL
    DROP PROCEDURE SP_UPDATE_STUDENT_INFO;
GO