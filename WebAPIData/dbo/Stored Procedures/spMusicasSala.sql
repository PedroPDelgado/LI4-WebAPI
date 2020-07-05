CREATE PROCEDURE [dbo].[spMusicasSala]
	@SalaId int
AS
	DECLARE @table table(URI nvarchar(200), Nome nvarchar(100), Duracao_ms int, Album nvarchar(100), Url_imagem nvarchar(500))
	DECLARE @uri nvarchar(200)
	DECLARE uris CURSOR
	FOR SELECT MusicaURI
	FROM dbo.[Sala_Musica]
	WHERE SalaID = @SalaId
	ORDER BY Posicao ASC

	OPEN uris

	FETCH NEXT FROM uris INTO @uri
	
	WHILE @@FETCH_STATUS = 0  
BEGIN  
      INSERT INTO @table
	  SELECT * FROM dbo.Musica
	  WHERE URI = @uri

      FETCH NEXT FROM uris INTO @uri 
END
	SELECT * FROM @table;

RETURN 0
