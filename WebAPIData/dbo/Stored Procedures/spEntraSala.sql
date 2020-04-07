CREATE PROCEDURE [dbo].[spEntraSala]
	@SalaId int,
	@UserId nvarchar(128),
	@Nome nvarchar(50),
	@Password nvarchar(100)
AS
BEGIN
	DECLARE @Estado nvarchar(50)
	DECLARE @HashedPwd varbinary(MAX)
	DECLARE @HashedDBPwd varbinary(MAX)
	DECLARE @participaUser nvarchar(128)

	SELECT @Estado = Estado, @HashedDBPwd = Password, @SalaId = ID
	FROM dbo.Sala
	WHERE Nome = @Nome
	SELECT @HashedPwd = HASHBYTES('SHA2_512',@Password)

	SET @participaUser = null

	SELECT @participaUser = UserID
	FROM dbo.Participantes
	WHERE SalaID = @SalaId
	AND UserID = @UserId

	IF @participaUser IS NULL AND @Estado = 'Open' AND @HashedPwd = @HashedDBPwd
	BEGIN
		INSERT INTO dbo.Participantes(UserID, SalaID)
		VALUES (@UserId,@SalaId)
		SELECT @SalaId
	END
	ELSE
	BEGIN
		SET @SalaId = 0
	END
	

END
RETURN 0
