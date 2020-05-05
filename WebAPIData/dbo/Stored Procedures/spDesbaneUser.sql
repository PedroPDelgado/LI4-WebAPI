CREATE PROCEDURE [dbo].[spDesbaneUser]
	@SalaId int,
	@UserId nvarchar(128),
	@IdADesbanir nvarchar(128)
AS
	DECLARE @Owner nvarchar(128) = null
	
	--verificar que se trata do Owner da Sala
	SELECT @Owner = AuthOwnerID
	FROM Sala
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId

	IF @Owner is not null AND NOT(@IdADesbanir = @Owner)
	BEGIN

		-- remover da blacklist o user que se quer desbanir
		DELETE 
		FROM BlackList
		WHERE SalaId = @SalaId
		AND UserId = @IdADesbanir 
	END

RETURN 0
