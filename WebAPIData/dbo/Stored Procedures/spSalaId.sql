CREATE PROCEDURE [dbo].[spSalaId]--devolve o id da sala de acordo com o seu nome
	@SalaId int,
	@Nome nvarchar(50)
AS
	SET @SalaId = 0

	SELECT @SalaId = ID
	FROM Sala
	WHERE Nome = @Nome

	SELECT @SalaId

RETURN 0
