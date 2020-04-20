CREATE PROCEDURE [dbo].[spAdicionaMusica]
	
	@MusicaURI nvarchar(200),
	@Nome nvarchar(100),
	@Duracao int,
	@Album nvarchar(100),
	@Url_imagem nvarchar(500)
	
AS
	INSERT INTO dbo.[Musica](URI, Nome, Duracao_ms, Album, Url_imagem)
	VALUES(@MusicaURI, @Nome, @Duracao, @Album, @Url_imagem)
	
RETURN 0
