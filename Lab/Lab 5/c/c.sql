-- Master Key trong 'master' nếu chưa có
USE master;
GO
IF NOT EXISTS (
    SELECT * FROM sys.symmetric_keys WHERE symmetric_key_id = 101
)
BEGIN
    CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'PhamQuangDuyNguyenHoDangDuy@2112708522127088';
    PRINT N'Master Key đã được tạo.';
END
ELSE
    PRINT N'Master Key đã tồn tại.';

-- Tạo certificate TDECert nếu chưa có
IF NOT EXISTS (
    SELECT * FROM sys.certificates WHERE name = 'TDECert'
)
BEGIN
    CREATE CERTIFICATE TDECert
    WITH SUBJECT = 'Certificate for TDE - QLBongDa';
    PRINT N'Certificate TDECert đã được tạo.';
END
ELSE
    PRINT N'Certificate TDECert đã tồn tại.';

-- Tạo Database Encryption Key và bật TDE cho QLBongDa
USE QLBongDa;
GO
CREATE DATABASE ENCRYPTION KEY
WITH ALGORITHM = AES_256
ENCRYPTION BY SERVER CERTIFICATE TDECert;
GO

ALTER DATABASE QLBongDa SET ENCRYPTION ON;
GO
PRINT N'Database QLBongDa đã được mã hóa bằng TDE.';

-- Kiểm tra trạng thái mã hóa
SELECT 
    db.name AS DatabaseName,
    db.is_encrypted AS IsEncrypted,
    dek.encryption_state AS EncryptionState,
    dek.percent_complete AS PercentComplete,
    dek.key_algorithm AS Algorithm,
    dek.key_length AS KeyLength
FROM sys.databases db
LEFT JOIN sys.dm_database_encryption_keys dek
    ON db.database_id = dek.database_id
WHERE db.name = 'QLBongDa';

-- Backup certificate để dùng ở server khác (Detach/Restore)
-- Tạo folder backup key cho server khác nếu muốn attach vào server khác 
BACKUP CERTIFICATE TDECert
TO FILE = 'D:\SQL_SERVER_02\MSSQL16.MSSQLSERVER02\MSSQL\BackupKey\TDECert_QLBongDa.cer'
WITH PRIVATE KEY (
    FILE = 'D:\SQL_SERVER_02\MSSQL16.MSSQLSERVER02\MSSQL\BackupKey\TDECert_QLBongDa.pvk',
    ENCRYPTION BY PASSWORD = 'ExportCert@2025'
);
GO
PRINT N'Certificate TDECert đã được backup thành công.';
