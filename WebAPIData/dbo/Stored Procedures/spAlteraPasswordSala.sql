CREATE PROCEDURE [dbo].[spAlteraPasswordSala]
	@SalaId int,
	@Password nvarchar(50),
	@UserId nvarchar(128)
AS
	DECLARE @Owner nvarchar(128) = null
	
	SELECT @Owner = AuthOwnerID
	FROM Sala
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId

	IF @Owner is not null
	BEGIN
		UPDATE Sala
		SET Password = HASHBYTES('SHA2_512',@Password)
		WHERE ID = @SalaId
	END
RETURN 0
