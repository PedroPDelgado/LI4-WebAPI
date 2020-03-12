CREATE TABLE [dbo].[Salas]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [AuthOwnerID] NVARCHAR(128) NOT NULL, 
    [Estado] NVARCHAR(50) NOT NULL, 
    [PlaylistID] INT NULL, 
    CONSTRAINT [FK_Salas_PlaylistID] FOREIGN KEY ([PlaylistID]) REFERENCES [Playlists]([ID]) 
)
