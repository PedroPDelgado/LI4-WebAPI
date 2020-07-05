CREATE PROCEDURE [dbo].[spGetIdSalaUser]
	@IdUser nvarchar(128)
AS
	DECLARE @Sala int = 0

	SELECT @Sala = SalaID
	FROM Participantes
	WHERE UserID = @IdUser

	SELECT @Sala

RETURN 0
