CREATE PROCEDURE [dbo].[spMusicaInfo]
	@URI nvarchar(100)
AS
BEGIN
	select URI, Nome, Artista, Genero, Duracao_ms
	from dbo.Musica
	where URI = @URI
END

