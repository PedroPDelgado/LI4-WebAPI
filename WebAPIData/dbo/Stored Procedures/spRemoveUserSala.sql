CREATE PROCEDURE [dbo].[spRemoveUserSala]
	@SalaId int,
	@UserId nvarchar(128),
	@IdARemover nvarchar(128)
AS
	DECLARE @Owner nvarchar(128) = null
	
	--verificar que se trata do Owner da Sala
	SELECT @Owner = AuthOwnerID
	FROM Sala
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId

	IF @Owner is not null AND NOT(@IdARemover = @Owner)
	BEGIN
		DELETE FROM Participantes
		WHERE SalaID = @SalaId
		AND UserID = @IdARemover
	END



RETURN 0
