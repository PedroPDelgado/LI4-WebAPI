CREATE PROCEDURE [dbo].[spAdicionaMusicaSala]
	@SalaId int,
	@MusicaURI nvarchar(200),
	@Nome nvarchar(100),
	@Duracao int,
	@UserId nvarchar(128)
AS
	DECLARE @existeURI nvarchar(200)
	SET @existeURI = null

	SELECT @existeURI = URI
	FROM dbo.Musica
	WHERE URI = @MusicaURI

	IF @existeURI IS NULL
	BEGIN
		INSERT INTO dbo.[Musica](URI, Nome, Duracao_ms)
		VALUES(@MusicaURI, @Nome, @Duracao)
	END
	
	INSERT INTO dbo.[Sala_Musica](SalaID, MusicaURI, UserId)
	VALUES(@SalaId, @MusicaURI, @UserId)

RETURN 0
