CREATE PROCEDURE [dbo].[spRemoverMusicaPlaylistURI]
	@PlaylistId int,
	@MusicaURI nvarchar(100)
AS
	DELETE FROM dbo.Playlist_Musica

	WHERE PlaylistID = @PlaylistId
	AND MusicaURI = @MusicaURI
RETURN 0
