CREATE PROCEDURE [dbo].[spApagaSala]
	@UserId nvarchar(128),
	@SalaId int
AS
	DELETE FROM dbo.Sala
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId

RETURN 0
