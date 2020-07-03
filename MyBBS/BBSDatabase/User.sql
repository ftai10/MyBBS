CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [LoginId] NVARCHAR(16) NOT NULL, 
    [Password] VARBINARY(16) NOT NULL, 
    [CreateData] DATETIME NOT NULL, 
    [UpdateData] DATETIME NULL
)
