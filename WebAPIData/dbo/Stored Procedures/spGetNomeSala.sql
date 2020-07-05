CREATE PROCEDURE [dbo].[spGetNomeSala]
	@SalaId int
AS
	DECLARE @Nome nvarchar(50) = null

	SELECT @Nome = Nome
	FROM Sala
	WHERE ID = @SalaId

	SELECT @Nome

RETURN 0