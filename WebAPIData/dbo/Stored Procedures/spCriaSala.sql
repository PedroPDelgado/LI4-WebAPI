CREATE PROCEDURE [dbo].[spCriaSala]
	@SalaId int,
	@UserId nvarchar(128),
	@Nome nvarchar(50),
	@Password nvarchar(100),
	@Xcoord float,
	@Ycoord float
AS
	DECLARE @HashedPwd varbinary(MAX)
	DECLARE @existeNome nvarchar(50)

	SET @existeNome = null

	SELECT @existeNome = Nome
	FROM dbo.Sala
	WHERE Nome = @Nome

	IF @existeNome IS NULL
	BEGIN
	SET @HashedPwd = HASHBYTES('SHA2_512',@Password) 
	
	INSERT INTO dbo.Sala(AuthOwnerID,Nome,Password,Xcoord,Ycoord)
	VALUES(@UserId,@Nome,@HashedPwd,@Xcoord,@Ycoord)

	SELECT @SalaId = ID
	FROM dbo.Sala
	WHERE Nome = @Nome
	END

	ELSE
	BEGIN
	SET @SalaId = 0
	END

	SELECT @SalaId

RETURN 0
