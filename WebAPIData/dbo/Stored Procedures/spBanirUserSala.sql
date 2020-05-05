CREATE PROCEDURE [dbo].[spBanirUserSala]
	@SalaId int,
	@UserId nvarchar(128),
	@IdABanir nvarchar(128)
AS
	DECLARE @Owner nvarchar(128) = null
	
	--verificar que se trata do Owner da Sala
	SELECT @Owner = AuthOwnerID
	FROM Sala
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId

	IF @Owner is not null AND NOT(@IdABanir = @Owner)
	BEGIN
		--retirar dos participantes
		DELETE FROM Participantes
		WHERE UserID = @IdABanir
		AND SalaID = @SalaId

		--colocar na blacklist
		INSERT INTO BlackList(SalaId, UserId)
		VALUES(@SalaId, @IdABanir)
	END
RETURN 0
