CREATE PROCEDURE [dbo].[spEntraSala]
	@UserId nvarchar(128),
	@SalaId int
AS
BEGIN
	INSERT INTO dbo.Participantes(UserID, SalaID)
	VALUES (@UserId,@SalaId)
END
RETURN 0
