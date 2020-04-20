CREATE PROCEDURE [dbo].[spAdicionaArtistaMusica]
	@MusicaURI nvarchar(200),
	@Artista nvarchar(100)
AS
	INSERT INTO Musica_Artistas(MusicaURI, Artista)
	VALUES(@MusicaURI, @Artista)
RETURN 0
