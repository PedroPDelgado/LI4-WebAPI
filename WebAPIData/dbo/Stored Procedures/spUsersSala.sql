CREATE PROCEDURE [dbo].[spUsersSala]
	@SalaId int
AS
	SELECT UserId
	FROM dbo.Participantes
	WHERE SalaID = @SalaId
RETURN 0
