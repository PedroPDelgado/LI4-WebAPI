CREATE TABLE [dbo].[Playlist_Musica]
(
	[PlaylistID] INT NOT NULL , 
    [MusicaURI] NVARCHAR(200) NOT NULL, 
    [Posicao] INT NOT NULL IDENTITY(1,1), 
    CONSTRAINT [FK_Playlist] FOREIGN KEY ([PlaylistID]) REFERENCES [Playlists]([ID]),
    CONSTRAINT [FK_Musica] FOREIGN KEY ([MusicaURI]) REFERENCES [Musica]([URI]),
    PRIMARY KEY ([PlaylistID],[MusicaURI]) 
)
