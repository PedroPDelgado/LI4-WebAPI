CREATE PROCEDURE [dbo].[spMusicaInfo]
	@URI nvarchar(100)
AS
BEGIN
	select URI, Nome, Duracao_ms, Album, Url_imagem
	from dbo.Musica
	where URI = @URI
END

