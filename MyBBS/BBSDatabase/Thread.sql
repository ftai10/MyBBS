CREATE TABLE [dbo].[Thread]
(
	[ThreadId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [isOrigin] BIT NOT NULL, 
    [UserId] UNIQUEIDENTIFIER NOT NULL, 
    [CreateDate] DATETIME NOT NULL, 
    [UpdateDate] DATETIME NULL, 
    [OriginThreadId] INT NULL, 
    [Title] NVARCHAR(128) NOT NULL,
    [PostText] NVARCHAR(MAX) NOT NULL, 
    [IsDeleted] BIT NOT NULL
)
