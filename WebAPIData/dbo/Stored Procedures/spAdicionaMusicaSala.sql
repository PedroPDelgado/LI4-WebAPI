CREATE PROCEDURE [dbo].[spAdicionaMusicaSala]
	@SalaId int,
	@MusicaURI nvarchar(200),
	@Posicao int,
	@UserId nvarchar(128)
AS
	INSERT INTO Sala_Musica(SalaID, MusicaURI, Posicao, UserId)
	VALUES(@SalaId, @MusicaURI, @Posicao, @UserId)
RETURN 0
