CREATE PROCEDURE [dbo].[spUsersSala]
	@SalaId int
AS
	SELECT UserID
	FROM dbo.Participantes
	WHERE SalaID = @SalaId
RETURN 0
