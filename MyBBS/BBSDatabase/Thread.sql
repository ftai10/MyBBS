CREATE TABLE [dbo].[Thread]
(
	[ThreadId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [isOrigin] BIT NOT NULL, 
    [UserId] INT NOT NULL, 
    [CreateData] DATETIME NOT NULL, 
    [UpdateData] DATETIME NOT NULL, 
    [OriginThreadId] INT NULL, 
    [Title] VARCHAR(128) NOT NULL,
    [PostText] VARCHAR(MAX) NOT NULL
)
