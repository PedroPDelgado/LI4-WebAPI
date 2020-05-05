CREATE PROCEDURE [dbo].[spVerificaParticipante]
	@SalaId int,
	@UserId nvarchar(180)
AS
	DECLARE @Existe nvarchar(180) = null
	DECLARE @Return int = 0

	SELECT @Existe = UserID
	FROM Participantes
	WHERE SalaID = @SalaId
	AND UserID = @UserId

	IF @Existe is not null
	BEGIN
		SET @Return = 1
	END
	
	SELECT @Return

RETURN 0
