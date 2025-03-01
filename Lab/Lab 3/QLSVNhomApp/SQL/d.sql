-- d.sql
USE QLSVNhom;
GO

-- Stored procedure SP_INS_DIEM: C?p nh?t ?i?m thi cho sinh vi�n, 
-- m� h�a ?i?m s? d?ng h�m dbo.EncryptRSA512 v� kh�a b� m?t l� Public Key c?a nh�n vi�n.
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
