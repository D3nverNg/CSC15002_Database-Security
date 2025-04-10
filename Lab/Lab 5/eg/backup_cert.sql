-- Backup certificate to use in other DB (Detach/Restore)
-- Create folder backup key for other server
USE master;
GO
BACKUP CERTIFICATE TDECert
TO FILE = 'D:\BackupKey\SVA_TDECert_QLBongDa.cer'
WITH PRIVATE KEY (
    FILE = 'D:\BackupKey\SVA_TDECert_QLBongDa.pvk',
    ENCRYPTION BY PASSWORD = '22127085_22127088'
);
GO
PRINT N'Certificate TDECert backup successfully.';