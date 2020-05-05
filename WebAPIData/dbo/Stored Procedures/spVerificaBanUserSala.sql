CREATE PROCEDURE [dbo].[spVerificaBanUserSala]
	@SalaId int,
	@UserId nvarchar(128)
AS
	DECLARE @Existe nvarchar(180) = null
	DECLARE @Return int = 0

	SELECT @Existe = UserID
	FROM BlackList
	WHERE SalaID = @SalaId
	AND UserID = @UserId

	IF @Existe is not null
	BEGIN
		SET @Return = 1
	END
	
	SELECT @Return
RETURN 0
