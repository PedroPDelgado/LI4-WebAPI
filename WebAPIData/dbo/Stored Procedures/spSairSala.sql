CREATE PROCEDURE [dbo].[spSairSala]
	@SalaId int,
	@UserId nvarchar(128)
AS
	DELETE FROM dbo.[Participantes]
	WHERE SalaID = @SalaId
	AND UserID = @UserId

RETURN 0
