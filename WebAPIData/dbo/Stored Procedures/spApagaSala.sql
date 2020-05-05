﻿CREATE PROCEDURE [dbo].[spApagaSala]
	@UserId nvarchar(128),
	@SalaId int
AS

	DECLARE @Owner nvarchar(128) = null
	
	SELECT @Owner = AuthOwnerID
	FROM Sala
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId

	IF @Owner is not null
	BEGIN
		DELETE FROM dbo.Sala
		WHERE ID = @SalaId
		AND AuthOwnerID = @UserId

		DELETE FROM dbo.Participantes
		WHERE SalaID = @SalaId
	END

RETURN 0
