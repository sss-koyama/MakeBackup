DECLARE @wNum int, @dNum int,
		@wDir varchar(2);
DECLARE @sql nvarchar(max) ='BACKUP DATABASE [TARGETDB] TO  DISK = N''BACKUPPATH\'

SET @wNum = DATEPART(WEEKDAY,GETDATE());


SET @wDir =
CASE 

	WHEN @wNum = 1 THEN 'Su'

	WHEN @wNum = 2 THEN 'Mo'

	WHEN @wNum = 3 THEN 'Tu'

	WHEN @wNum = 4 THEN 'We'

	WHEN @wNum = 5 THEN 'Th'

	WHEN @wNum = 6 THEN 'Fr'

	WHEN @wNum = 7 THEN 'Sa'

END

PRINT @wDir;
SET @sql = @sql + @wDir + '\TARGETDB.bak'' WITH NOFORMAT, NOINIT,  NAME = N''TARGETDB-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD,  STATS = 10'
EXEC (@sql);


SET @dNum = DATEPART(DAY,GETDATE());

SET @sql ='BACKUP DATABASE [TARGETDB] TO  DISK = N''BACKUPPATH\'

IF @dNum = 1
	BEGIN
		SET @wDir = 1
		PRINT @wDir;
		SET @sql = @sql + @wDir + '\TARGETDB.bak'' WITH NOFORMAT, NOINIT,  NAME = N''TARGETDB-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD,  STATS = 10'
		EXEC (@sql);
	END

ELSE IF @dNum = 6
	BEGIN
		SET @wDir = 6
		PRINT @wDir;
		SET @sql = @sql + @wDir + '\TARGETDB.bak'' WITH NOFORMAT, NOINIT,  NAME = N''TARGETDB-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD,  STATS = 10'
		EXEC (@sql);
	END

ELSE IF @dNum = 11
	BEGIN
		SET @wDir = 11
		PRINT @wDir;
		SET @sql = @sql + @wDir + '\TARGETDB.bak'' WITH NOFORMAT, NOINIT,  NAME = N''TARGETDB-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD,  STATS = 10'
		EXEC (@sql);
	END

ELSE IF @dNum = 16
	BEGIN
		SET @wDir = 16
		PRINT @wDir;
		SET @sql = @sql + @wDir + '\TARGETDB.bak'' WITH NOFORMAT, NOINIT,  NAME = N''TARGETDB-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD,  STATS = 10'
		EXEC (@sql);
	END

ELSE IF @dNum = 21
	BEGIN
		SET @wDir = 21
		PRINT @wDir;
		SET @sql = @sql + @wDir + '\TARGETDB.bak'' WITH NOFORMAT, NOINIT,  NAME = N''TARGETDB-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD,  STATS = 10'
		EXEC (@sql);
	END

ELSE IF @dNum = 26
	BEGIN
		
		SET @wDir = 26
		PRINT @wDir;
		SET @sql = @sql + @wDir + '\TARGETDB.bak'' WITH NOFORMAT, NOINIT,  NAME = N''TARGETDB-完全 データベース バックアップ'', SKIP, NOREWIND, NOUNLOAD,  STATS = 10'
		EXEC (@sql);
	END