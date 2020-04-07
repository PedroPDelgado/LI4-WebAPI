CREATE PROCEDURE [dbo].[spAdicionaFiltroSala]
	@SalaId int,
	@UserId nvarchar(128),
	@Filtro nvarchar(80)
AS
	DECLARE @Sala int
	SET @Sala = null

	SELECT @Sala = ID 
	FROM Sala
	WHERE ID = @SalaId
	AND AuthOwnerID = @UserId
	
	IF @Sala is not null
	BEGIN
		
		DECLARE @Existe nvarchar(80)
		SET @Existe = null

		SELECT @Existe = Filtro
		FROM Sala_Filtros
		WHERE SalaId = @Sala
		AND Filtro = @Filtro

		IF @Existe is null
		INSERT INTO Sala_Filtros(SalaId,Filtro)
		VALUES(@Sala,@Filtro)

	END

	

RETURN 0
