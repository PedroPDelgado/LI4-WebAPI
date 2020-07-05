CREATE PROCEDURE [dbo].[spApagaSala]
	@UserId nvarchar(128),
	@SalaId int
AS

	DECLARE @Owner nvarchar(128) = null
	
	SELECT @Owner = AuthOwnerID
	FROM Sala
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId

	IF @Owner is not null
	BEGIN
		
		DELETE FROM dbo.Participantes
		WHERE SalaID = @SalaId

		DELETE FROM BlackList
		WHERE SalaId = @SalaId

		DELETE FROM Sala_Filtros
		WHERE SalaId = @SalaId

		DELETE FROM dbo.Sala
		WHERE ID = @SalaId
		AND AuthOwnerID = @UserId

	END

RETURN 0
