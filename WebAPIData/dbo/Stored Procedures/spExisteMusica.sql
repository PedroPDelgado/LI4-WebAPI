CREATE PROCEDURE [dbo].[spExisteMusica]
	@URI nvarchar(200)
AS
	DECLARE @existe nvarchar(200) = null
	SELECT @existe = URI
	FROM Musica 
	WHERE URI = @URI

	SELECT @existe

RETURN 0
