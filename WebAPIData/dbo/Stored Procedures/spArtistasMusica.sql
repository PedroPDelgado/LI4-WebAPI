CREATE PROCEDURE [dbo].[spArtistasMusica]
	@URI nvarchar(200) 
AS
	SELECT Artista
	FROM Musica_Artistas
	WHERE MusicaURI = @URI
RETURN 0
