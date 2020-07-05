CREATE PROCEDURE [dbo].[spIsOwner]
	@SalaId int,
	@UserId nvarchar(128)
AS
	DECLARE @Owner nvarchar(128)

	SELECT @Owner = AuthOwnerID
	FROM Sala
	WHERE ID = @SalaId

	IF @Owner = @UserId
	BEGIN
		SELECT 1
	END
	ELSE
	BEGIN
		SELECT 0
	END

RETURN 0
