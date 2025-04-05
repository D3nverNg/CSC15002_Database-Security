USE QLBongDa
GO

-- Kiểm tra các stored procedure không mã hóa
SELECT name 
FROM sys.objects 
WHERE type = 'P' AND OBJECTPROPERTY(object_id, 'IsEncrypted') = 0;

-- Xử lí
DECLARE @ProcName NVARCHAR(128)
DECLARE @DropSp NVARCHAR(MAX)
DECLARE @Encrypt NVARCHAR(MAX)
DECLARE @SQL NVARCHAR(MAX)

DECLARE ProcCursor CURSOR FOR
SELECT name FROM sys.objects 
WHERE type = 'P' AND OBJECTPROPERTY(object_id, 'IsEncrypted') = 0;

OPEN ProcCursor
FETCH NEXT FROM ProcCursor INTO @ProcName

WHILE @@FETCH_STATUS = 0
BEGIN
	-- Lấy danh sách các SP
    PRINT 'Stored Procedure: ' + @ProcName

	-- Lấy script các SP
	SET @SQL = (SELECT OBJECT_DEFINITION(OBJECT_ID(@ProcName)))
	--print @SQL

	-- Kiểm tra có thể drop không
	IF @SQL IS NOT NULL
	BEGIN
		PRINT 'Stored procedure exists'
	END
	ELSE
	BEGIN
		PRINT 'Stored procedure non-exists'
	END

	-- Drop procedure
	SET @DropSp = 'DROP PROCEDURE ' + QUOTENAME(@ProcName)
	EXEC sp_executesql @DropSp
	--print @DropSp

	--Tạo lại với encryption
	SET @Encrypt = REPLACE(@SQL, 'AS', 'WITH ENCRYPTION AS')
	EXEC sp_executesql @Encrypt
	--print @Encrypt

	FETCH NEXT FROM ProcCursor INTO @ProcName
END

CLOSE ProcCursor
DEALLOCATE ProcCursor

