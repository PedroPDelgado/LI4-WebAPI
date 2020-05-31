CREATE PROCEDURE [dbo].[spAdicionaMusicaSala]
	@SalaId int,
	@MusicaURI nvarchar(200),
	@UserId nvarchar(128)
AS
	DECLARE @LimiteMusicas int
	DECLARE @LimiteHorario int
	DECLARE @NumMusicas int = 0
	DECLARE @TempoTotal bigint = 0
	DECLARE @Duracao int
	DECLARE @Posicao int

	SELECT @LimiteMusicas = LimiteMusicas
	FROM Sala
	WHERE ID = @SalaId

	SELECT @LimiteHorario = LimiteHoras
	FROM Sala
	WHERE ID = @SalaId

	SELECT @NumMusicas = COUNT(MusicaURI) 
	FROM Sala_Musica
	WHERE SalaID = @SalaId

	--verificar o numero de ms de musica da Sala
	SELECT @TempoTotal = SUM(Duracao_ms)
	FROM Sala
	JOIN Sala_Musica
	ON Sala.ID = Sala_Musica.SalaID
	JOIN Musica
	ON Sala_Musica.MusicaURI = Musica.URI
	WHERE Sala.ID = @SalaId

	SELECT @Duracao = (Duracao_ms)
	FROM Musica
	WHERE URI = @MusicaURI


	IF(@NumMusicas+1 <= @LimiteMusicas AND ((@LimiteHorario+@Duracao)/60000) <= (@LimiteHorario*60))
	BEGIN

		SELECT @Posicao = COUNT(Posicao)+1
		FROM Sala_Musica
		WHERE SalaID = @SalaId

		INSERT INTO Sala_Musica(SalaID, MusicaURI, Posicao, UserId)
		VALUES(@SalaId, @MusicaURI, @Posicao, @UserId)
	END


RETURN 0
