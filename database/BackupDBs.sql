BACKUP DATABASE [BlogManSysAuthDb] TO  DISK = N'C:\Daten\Hassan\Code\Blog Managment System\Blog managment system\database\AuthDB.bak' WITH NOFORMAT, NOINIT,  NAME = N'BlogManSysAuthDb-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO

BACKUP DATABASE [BlogManSysDB] TO  DISK = N'C:\Daten\Hassan\Code\Blog Managment System\Blog managment system\database\DB.bak' WITH NOFORMAT, INIT,  NAME = N'BlogManSysDB-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10
GO
