CREATE PROCEDURE [dbo].[spNovaMusica]
	@URI nvarchar(200),
	@Nome nvarchar(100),
	@Artista nvarchar(100),
	@Genero nvarchar(100),
	@Duracao_ms int
AS
BEGIN
	INSERT INTO dbo.Musica(URI,Nome,Artista,Genero,Duracao_ms)
	VALUES (@URI,@Nome,@Artista,@Genero,@Duracao_ms)
END
RETURN 0