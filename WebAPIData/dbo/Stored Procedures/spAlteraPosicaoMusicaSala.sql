CREATE PROCEDURE [dbo].[spAlteraPosicaoMusicaSala]
	@UserId nvarchar(128),
	@SalaId int,
	@MusicaURI nvarchar(200),
	@PosicaoAtual int,
	@PosicaoFinal int

AS
	/*UPDATE dbo.Sala_Musica
	SET Posicao = Posicao + 1
	WHERE Posicao >= @PosicaoAtual*/

RETURN 0
