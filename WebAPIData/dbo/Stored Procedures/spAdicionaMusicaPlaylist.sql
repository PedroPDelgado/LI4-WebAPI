CREATE PROCEDURE [dbo].[spAdicionaMusicaPlaylist]
	@PlaylistId int,
	@MusicaURI nvarchar(200)
AS
	INSERT INTO dbo.Playlist_Musica(PlaylistID, MusicaURI)
	VALUES(@PlaylistId, @MusicaURI)

RETURN 0
