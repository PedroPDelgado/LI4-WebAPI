CREATE TABLE [dbo].[Salas]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [AuthOwnerID] NVARCHAR(128) NOT NULL, 
    [Estado] NVARCHAR(50) NOT NULL, 
    [Limite] INT NULL, 
    [PlaylistID] INT NULL, 
    CONSTRAINT [FK_Salas_PlaylistID] FOREIGN KEY ([PlaylistID]) REFERENCES [Playlists]([Id]) 
)
