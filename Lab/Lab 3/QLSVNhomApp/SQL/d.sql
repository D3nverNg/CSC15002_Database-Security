-- d.sql
USE QLSVNhom;
GO

-- Stored procedure SP_INS_DIEM: C?p nh?t ?i?m thi cho sinh viên, 
-- mã hóa ?i?m s? d?ng hàm dbo.EncryptRSA512 và khóa bí m?t là Public Key c?a nhân viên.
CREATE PROCEDURE SP_INS_DIEM
    @MASV VARCHAR(20),
    @MAHP VARCHAR(20),
    @DIEM FLOAT,
    @PUBKEY VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE BANGDIEM
    SET DIEMTHI = dbo.EncryptRSA512(CAST(@DIEM AS VARCHAR(10)), @PUBKEY)
    WHERE MASV = @MASV AND MAHP = @MAHP;
END
GO

-- Quản lý lớp học
CREATE PROCEDURE SP_GET_CLASSES_BY_EMPLOYEE
    @MANV VARCHAR(20)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MALOP, TENLOP, MANV FROM LOP WHERE MANV = @MANV;
END
GO


CREATE PROCEDURE SP_SEARCH_CLASSES_BY_EMPLOYEE
    @MANV VARCHAR(20),
    @TENLOP NVARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT MALOP, TENLOP, MANV FROM LOP 
    WHERE MANV = @MANV OR TENLOP = @TENLOP;
END
GO

-- CLASS DETAIL FORM
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


-- UPDATE STUDENT FORM
-- Procedure kiểm tra sinh viên có tồn tại trong lớp hay không
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

-- Procedure cập nhật thông tin sinh viên
-- Nếu @NEW_MALOP khác @OLD_MALOP, procedure sẽ thực hiện chuyển lớp (với kiểm tra tồn tại lớp mới)
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
    -- Kiểm tra xem sinh viên có tồn tại trong lớp cũ không
    IF NOT EXISTS(SELECT 1 FROM SINHVIEN WHERE MASV = @MASV AND MALOP = @OLD_MALOP)
    BEGIN
        SET @ErrorMessage = 'Sinh viên không tồn tại trong lớp hiện tại.';
        RETURN;
    END

    -- Nếu mã lớp mới khác mã lớp cũ, kiểm tra xem lớp mới có tồn tại không
    IF @NEW_MALOP <> @OLD_MALOP
    BEGIN
        IF NOT EXISTS(SELECT 1 FROM LOP WHERE MALOP = @NEW_MALOP)
        BEGIN
            SET @ErrorMessage = 'Mã lớp mới không tồn tại.';
            RETURN;
        END
    END

    -- Cập nhật thông tin sinh viên (bao gồm cả thay đổi mã lớp nếu có)
    UPDATE SINHVIEN
    SET HOTEN = @HOTEN,
        NGAYSINH = @NGAYSINH,
        DIACHI = @DIACHI,
        MALOP = @NEW_MALOP
    WHERE MASV = @MASV AND MALOP = @OLD_MALOP;

    SET @ErrorMessage = '';
END
GO


-- ADD STUDENT FORM
-- Tạo stored procedure để tạo mã sinh viên mới
CREATE PROCEDURE SP_GENERATE_NEW_STUDENT_ID
AS
BEGIN
    DECLARE @NewID INT;
    DECLARE @MaxID NVARCHAR(20);
    SELECT @MaxID = MAX(MASV) FROM SINHVIEN;
    IF @MaxID IS NULL
        SET @NewID = 1;
    ELSE
        SET @NewID = CAST(SUBSTRING(@MaxID, 2, LEN(@MaxID)) AS INT) + 1;
    SELECT 'S' + RIGHT('000' + CAST(@NewID AS NVARCHAR(10)), 3) AS NewMASV;
END
GO

-- Tạo stored procedure để thêm sinh viên mới
CREATE PROCEDURE SP_INSERT_STUDENT
    @HOTEN NVARCHAR(100),
    @NGAYSINH DATETIME,
    @DIACHI NVARCHAR(200),
    @TENDN NVARCHAR(100),
    @MATKHAU NVARCHAR(50),
    @MASV NVARCHAR(20) OUTPUT,
    @ErrorMessage NVARCHAR(200) OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- Kiểm tra tên đăng nhập duy nhất
    IF EXISTS (SELECT 1 FROM SINHVIEN WHERE TENDN = @TENDN)
    BEGIN
        SET @ErrorMessage = 'Tên đăng nhập đã tồn tại.';
        RETURN;
    END

    -- Sinh mã sinh viên mới
    DECLARE @NewID INT;
    DECLARE @MaxID NVARCHAR(20);
    SELECT @MaxID = MAX(MASV) FROM SINHVIEN;
    IF @MaxID IS NULL
        SET @NewID = 1;
    ELSE
        SET @NewID = CAST(SUBSTRING(@MaxID, 2, LEN(@MaxID)) AS INT) + 1;
    SET @MASV = 'S' + RIGHT('000' + CAST(@NewID AS NVARCHAR(10)), 3);

    -- Kiểm tra thông tin bắt buộc (nếu cần thêm các kiểm tra khác tại đây)

    INSERT INTO SINHVIEN (MASV, HOTEN, NGAYSINH, DIACHI, TENDN, MATKHAU)
    VALUES (@MASV, @HOTEN, @NGAYSINH, @DIACHI, @TENDN, @MATKHAU);

    SET @ErrorMessage = '';
END
GO


--DELETE STUDENT FORM
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

    DELETE FROM SINHVIEN
    WHERE MASV = @MASV AND MALOP = @MALOP;

    SET @ErrorMessage = '';
END
GO