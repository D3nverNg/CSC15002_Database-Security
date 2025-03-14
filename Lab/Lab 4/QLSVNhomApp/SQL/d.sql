-- d.sql
USE QLSVNhom;
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

CREATE PROCEDURE SP_UPDATE_STUDENT_INFO
    @MASV NVARCHAR(20),
    @HOTEN NVARCHAR(100),
    @NGAYSINH DATETIME,
    @DIACHI NVARCHAR(200),
    @OLD_MALOP NVARCHAR(20),
    @NEW_MALOP NVARCHAR(20),
    @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;
    IF NOT EXISTS(SELECT 1 FROM SINHVIEN WHERE MASV = @MASV AND MALOP = @OLD_MALOP)
    BEGIN
        SET @ErrorMessage = 'Sinh viên không tồn tại trong lớp hiện tại.';
        RETURN;
    END

    IF @NEW_MALOP <> @OLD_MALOP
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM LOP WHERE MALOP = @NEW_MALOP)
        BEGIN
            SET @ErrorMessage = 'Mã lớp mới không tồn tại.';
            RETURN;
        END
    END

    UPDATE SINHVIEN
    SET HOTEN = @HOTEN,
        NGAYSINH = @NGAYSINH,
        DIACHI = @DIACHI,
        MALOP = @NEW_MALOP
    WHERE MASV = @MASV AND MALOP = @OLD_MALOP;

    SET @ErrorMessage = '';
END
GO

-- Xóa procedure nếu tồn tại trước khi tạo mới
IF OBJECT_ID('SP_FIND_STUDENT_IN_CLASS', 'P') IS NOT NULL
    DROP PROCEDURE SP_FIND_STUDENT_IN_CLASS;
GO

CREATE PROCEDURE SP_FIND_STUDENT_IN_CLASS
    @MASV NVARCHAR(20),
    @MALOP NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MASV, HOTEN, NGAYSINH, DIACHI, MALOP
    FROM SINHVIEN
    WHERE MASV = @MASV AND MALOP = @MALOP;
END
GO

-- Xóa procedure nếu tồn tại trước khi tạo mới
IF OBJECT_ID('SP_GET_STUDENTS_BY_CLASS', 'P') IS NOT NULL
    DROP PROCEDURE SP_GET_STUDENTS_BY_CLASS;
GO

CREATE PROCEDURE SP_GET_STUDENTS_BY_CLASS
    @MALOP NVARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MASV, HOTEN, NGAYSINH, DIACHI, MALOP
    FROM SINHVIEN
    WHERE MALOP = @MALOP;
END
GO

-- Xóa procedure nếu tồn tại trước khi tạo mới
IF OBJECT_ID('SP_SEARCH_CLASSES', 'P') IS NOT NULL
    DROP PROCEDURE SP_SEARCH_CLASSES;
GO

CREATE PROCEDURE SP_SEARCH_CLASSES
    @MALOP NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MALOP, TENLOP, MANV FROM LOP 
    WHERE MALOP = @MALOP;
END
GO

-- Xóa procedure nếu tồn tại trước khi tạo mới
IF OBJECT_ID('SP_GET_CLASSES', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE SP_GET_CLASSES;
END;
GO

CREATE PROCEDURE SP_GET_CLASSES
AS
BEGIN
    SELECT MALOP, TENLOP, MANV
    FROM LOP;
END
GO

-- Xóa procedure nếu tồn tại trước khi tạo mới
IF OBJECT_ID('SP_INS_DIEM', 'P') IS NOT NULL
    DROP PROCEDURE SP_INS_DIEM;
GO

-- Stored procedure SP_INS_DIEM: Cập nhật điểm thi cho sinh viên, 
-- mã hóa điểm sử dụng asymetric key và khóa bí mật là Public Key của nhân viên.
CREATE PROCEDURE SP_INS_DIEM
    @MASV VARCHAR(20),
    @MAHP VARCHAR(20),
    @DIEMTHI DECIMAL(4,2),
    @PUBKEY VARCHAR(20),
    @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
    BEGIN TRY
        IF EXISTS (SELECT 1 FROM BANGDIEM WHERE MASV = @MASV AND MAHP = @MAHP)
        BEGIN
            -- Nếu đã có điểm, cập nhật điểm mới
            UPDATE BANGDIEM
            SET DIEMTHI = ENCRYPTBYASYMKEY(AsymKey_ID(@PUBKEY), CAST(@DIEMTHI AS VARBINARY))
            WHERE MASV = @MASV AND MAHP = @MAHP;
            SET @ErrorMessage = '';
        END
        ELSE
        BEGIN
            -- Nếu chưa có điểm, chèn mới
            INSERT INTO BANGDIEM (MASV, MAHP, DIEMTHI)
            VALUES (@MASV, @MAHP, ENCRYPTBYASYMKEY(AsymKey_ID(@PUBKEY), CAST(@DIEMTHI AS VARBINARY)));
            
            SET @ErrorMessage = '';
        END
    END TRY
    BEGIN CATCH
        SET @ErrorMessage = ERROR_MESSAGE();
    END CATCH
END;
GO

-- Xóa procedure nếu tồn tại trước khi tạo mới
IF OBJECT_ID('SP_LOGIN_NHANVIEN', 'P') IS NOT NULL
    DROP PROCEDURE SP_LOGIN_NHANVIEN;
GO

CREATE PROCEDURE SP_LOGIN_NHANVIEN
    @MANV VARCHAR(20),
    @MK VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra xem nhân viên có tồn tại không
    DECLARE @HashedPassword VARBINARY(100)

    SELECT @HashedPassword = MATKHAU
    FROM NHANVIEN
    WHERE MANV = @MANV

    ---- Kiểm tra mật khẩu
    IF @HashedPassword = HASHBYTES('SHA1', @MK)
    BEGIN
        SELECT MANV, HOTEN, EMAIL
        FROM NHANVIEN
        WHERE MANV = @MANV
    END
    ELSE
    BEGIN
        -- Nếu mật khẩu không khớp, trả về không có bản ghi nào
        SELECT NULL AS MANV, NULL AS HOTEN, NULL AS EMAIL
    END
END
GO