CREATE PROCEDURE [dbo].[spAlteraMusicaAtualSala]
	@SalaId int,
	@Posicao int
AS
	Update Sala
	SET MusicaAtual = @Posicao
	WHERE ID = @SalaId
RETURN 0
