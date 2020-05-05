CREATE PROCEDURE [dbo].[spAlteraNomeSala]
	@SalaId int,
	@Nome nvarchar(50),
	@UserId nvarchar(128)
AS
	DECLARE @Owner nvarchar(128) = null

	--verificar que se trata do Owner da Sala	
	SELECT @Owner = AuthOwnerID
	FROM Sala
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId

	IF @Owner is not null
	BEGIN
		UPDATE Sala
		SET Nome = @Nome
		WHERE ID = @SalaId
	END
RETURN 0
