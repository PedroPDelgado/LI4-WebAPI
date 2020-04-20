CREATE PROCEDURE [dbo].[spAlteraPosicaoMusicaSala]
	@UserId nvarchar(128),
	@SalaId int,
	@MusicaURI nvarchar(200),
	@PosicaoAtual int,
	@PosicaoFinal int

AS
	DECLARE @Owner nvarchar(128) = null
	SELECT @Owner = AuthOwnerID
	FROM Sala
	WHERE ID = @SalaId

	DECLARE @Existe nvarchar(128) = null
	SELECT @Existe = @MusicaURI 
	FROM Sala_Musica
	WHERE SalaID = @SalaId
	AND MusicaURI = @MusicaURI
	AND Posicao = @PosicaoAtual
	AND(@UserId = @Owner)


	IF @Existe is not null
BEGIN

		IF @PosicaoAtual > @PosicaoFinal
	BEGIN

		UPDATE Sala_Musica
		SET Posicao = 0
		WHERE SalaID = @SalaId
		AND MusicaURI = @MusicaURI
		AND Posicao = @PosicaoAtual

		UPDATE Sala_Musica
		SET Posicao = Posicao + 1
		WHERE SalaID = @SalaId
		AND Posicao >= @PosicaoFinal
		AND Posicao < @PosicaoAtual

		UPDATE Sala_Musica
		SET Posicao = @PosicaoFinal
		WHERE Posicao = 0
	END

		IF @PosicaoAtual < @PosicaoFinal
	BEGIN
		UPDATE Sala_Musica
		SET Posicao = 0
		WHERE SalaID = @SalaId
		AND MusicaURI = @MusicaURI
		AND Posicao = @PosicaoAtual

		UPDATE Sala_Musica
		SET Posicao = Posicao - 1
		WHERE SalaID = @SalaId
		AND Posicao <= @PosicaoFinal
		AND Posicao > @PosicaoAtual

		UPDATE Sala_Musica
		SET Posicao = @PosicaoFinal
		WHERE Posicao = 0
	END
END
RETURN 0
