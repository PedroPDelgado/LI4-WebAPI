CREATE PROCEDURE [dbo].[spRemoveFiltrosSala]
	@SalaId int,
	@UserId nvarchar(128)
AS
	DECLARE @Sala int
	SET @Sala = null

	SELECT @Sala = ID
	FROM Sala
	WHERE AuthOwnerID = @UserId
	AND ID = @SalaId

	IF @Sala = @SalaId
	BEGIN
		DELETE FROM Sala_Filtros
		WHERE SalaId = @SalaId
	END

	
RETURN 0
