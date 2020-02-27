CREATE TABLE [dbo].[Playlist_Musica]
(
	[PlaylistID] INT NOT NULL , 
    [MusicaURI] NVARCHAR(200) NOT NULL, 
    PRIMARY KEY ([PlaylistID],[MusicaURI]) 
)
