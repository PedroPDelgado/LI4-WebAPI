CREATE PROCEDURE [dbo].[spMusicaInfo]
	@Id int
AS
BEGIN
	select ID, URI, Nome, Artista, Genero, Duracao_ms
	from dbo.Musica
	where ID = @Id;
END

