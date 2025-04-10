-- Create Master Key in 'master' if doesnt exist
USE master;
GO
IF NOT EXISTS (
    SELECT * FROM sys.symmetric_keys WHERE symmetric_key_id = 101
)
BEGIN
    CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'QuangDuyDangDuy@2112708522127088';
    PRINT N'Master Key created.';
END
ELSE
    PRINT N'Master Key exists.';

-- Create certificate TDECert if doesnt exist
IF NOT EXISTS (
    SELECT * FROM sys.certificates WHERE name = 'TDECert'
)
BEGIN
    CREATE CERTIFICATE TDECert
    WITH SUBJECT = 'Certificate for TDE - QLBongDa';
    PRINT N'Certificate TDECert created.';
END
ELSE
    PRINT N'Certificate TDECert exists.';

-- Create Database Encryption Key and turn on TDE for QLBongDa
USE QLBongDa;
GO
CREATE DATABASE ENCRYPTION KEY
WITH ALGORITHM = AES_256
ENCRYPTION BY SERVER CERTIFICATE TDECert;
GO

ALTER DATABASE QLBongDa SET ENCRYPTION ON;
GO
PRINT N'Database QLBongDa encrypted by TDE.';

-- Check encrypting status
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