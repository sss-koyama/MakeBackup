DECLARE @wNum int, @dNum int,
		@wDir varchar(2);
DECLARE @sql nvarchar(max) ='BACKUP DATABASE [TARGETDB] TO  DISK = N''BACKUPPATH\'

SET @wNum = DATEPART(DAY,GETDATE());


SET @wDir = CONVERT(varchar(2), @wNum);

PRINT @wDir;
SET @sql = @sql + @wDir + '\TARGETDB.bak'' WITH NOFORMAT, NOINIT,  NAME = N''TARGETDB-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD,  STATS = 10'
EXEC (@sql);

