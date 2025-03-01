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
