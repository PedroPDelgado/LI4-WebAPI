CREATE TABLE [dbo].[Playlist_Musica]
(
	[PlaylistID] INT NOT NULL , 
    [MusicaID] INT NOT NULL, 
    [Posicao] INT NOT NULL, 
    CONSTRAINT [FK_Playlist] FOREIGN KEY ([PlaylistID]) REFERENCES [Playlists]([ID]),
    CONSTRAINT [FK_Musica] FOREIGN KEY ([MusicaID]) REFERENCES [Musica]([ID]),
    PRIMARY KEY ([PlaylistID],[MusicaID]) 
)
