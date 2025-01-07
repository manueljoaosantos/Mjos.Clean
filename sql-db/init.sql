DECLARE @dbName NVARCHAR(128) = 'PremierLeagueDb';

IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = @dbName)
BEGIN
    EXEC('CREATE DATABASE [' + @dbName + '];');
    PRINT 'Database ' + @dbName + ' created.';
END
ELSE
BEGIN
    PRINT 'Database ' + @dbName + ' already exists.';
END