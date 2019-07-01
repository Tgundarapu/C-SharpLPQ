
/*
master.[dbo].[CreateDBSnapshot_AnyDB] @RestoreSnapshot = 0, @DatabaseName='FreedomDEMO_AutomationTests'
master.[dbo].[CreateDBSnapshot_AnyDB] @RestoreSnapshot = 1, @DatabaseName='FreedomDEMO_AutomationTests'
*/


USE [master]
GO
/****** Object:  StoredProcedure [dbo].[CreateDBSnapshot]    Script Date: 5/25/2016 5:10:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CreateDBSnapshot_AnyDB]
	@RestoreSnapshot BIT = 0,
	@DatabaseName NVARCHAR(50) = 0
AS
BEGIN
	--AC: Added for automation until unit test replication from Central DB is working 
	DECLARE @SnapshotPath NVARCHAR(255) = 'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\' + @DatabaseName + '.mdf'

	--DECLARE @DatabaseName NVARCHAR(255)
	DECLARE @SnapshotName NVARCHAR(255)
	DECLARE @LogicalName NVARCHAR(255)
	DECLARE @Sql NVARCHAR(2000)

	SET @SnapshotName = @DatabaseName + 'SS'

	SET @Sql = 'select @LogicalName = [name] from ' + @DatabaseName + '.sys.database_files WHERE is_sparse = 0 and type_desc = ''ROWS'''
	EXEC SP_ExecuteSQL @Sql,N'@LogicalName VARCHAR(255) OUTPUT',@LogicalName = @LogicalName OUTPUT

	IF @RestoreSnapshot = 0
	BEGIN
		-- Drop database snapshot if it already exists
		IF  EXISTS (
				SELECT name 
						FROM sys.databases 
						WHERE name = @SnapshotName
		)
		BEGIN
				SET @Sql = 'DROP DATABASE ' + @SnapshotName
				EXEC(@SQL)
		END

		-- Create the database snapshot
		SET @Sql = N'CREATE DATABASE ' + @SnapshotName + ' ON
		( NAME = ''' + @LogicalName +''', FILENAME = 
		''' + @SnapshotPath + @SnapshotName + '.ss'' )
		AS SNAPSHOT OF ' + @DatabaseName
		EXEC(@SQL)
	END
	ELSE
	BEGIN
		BEGIN TRY
				SET @Sql = 'ALTER DATABASE ' + @DatabaseName + ' SET SINGLE_USER WITH ROLLBACK IMMEDIATE'
				EXEC(@Sql)
				SET @Sql = 'RESTORE DATABASE ' + @DatabaseName + ' FROM DATABASE_SNAPSHOT = ''' + @SnapshotName + ''''
				EXEC(@Sql)
				SET @Sql = 'ALTER DATABASE ' + @DatabaseName + ' SET MULTI_USER'
				EXEC(@Sql)
				SET @Sql = 'DROP DATABASE ' + @SnapshotName
				EXEC(@SQL)
		END TRY
		BEGIN CATCH
				SELECT
        ERROR_NUMBER() AS ErrorNumber
        ,ERROR_SEVERITY() AS ErrorSeverity
        ,ERROR_STATE() AS ErrorState
        ,ERROR_PROCEDURE() AS ErrorProcedure
        ,ERROR_LINE() AS ErrorLine
        ,ERROR_MESSAGE() AS ErrorMessage;
		END CATCH
	END
END
