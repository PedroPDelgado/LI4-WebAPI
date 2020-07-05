CREATE PROCEDURE [dbo].[spMusicaAtualSala]
	@SalaId int
AS
	SELECT MusicaAtual
	FROM Sala
	WHERE ID = @SalaId
RETURN 0
