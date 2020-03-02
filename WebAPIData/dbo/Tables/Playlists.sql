CREATE TABLE [dbo].[Playlists]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [TotalMusicas] INT NOT NULL DEFAULT 0, 
    [LimiteMusicas] NCHAR(10) NOT NULL DEFAULT 50
)
