CREATE PROCEDURE [dbo].[spAlteraCoordenadasSala]
	@SalaId int,
	@Xcoord float,
	@Ycoord float,
	@UserId nvarchar(128)

AS
	UPDATE Sala
	SET Xcoord = @Xcoord, Ycoord = @Ycoord
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId

RETURN 0
