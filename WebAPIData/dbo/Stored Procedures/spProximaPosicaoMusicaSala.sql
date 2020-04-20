CREATE PROCEDURE [dbo].[spProximaPosicaoMusicaSala]
	@SalaId int
AS
	SELECT COUNT(Posicao)+1
	FROM Sala_Musica
	WHERE SalaID = @SalaId

RETURN 0
