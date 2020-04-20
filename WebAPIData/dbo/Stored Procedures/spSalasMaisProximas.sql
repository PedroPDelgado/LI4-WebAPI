CREATE PROCEDURE [dbo].[spSalasMaisProximas]
	@Xcoord float,--latitude
	@Ycoord float,--longitude
	@NumSalas int
AS
	DECLARE @UserLoc geography = geography::Point(@Xcoord, @Ycoord, 4326)
	DECLARE @table TABLE(Nome nvarchar(50), Distancia_metros float)

	INSERT INTO @table
	SELECT Nome, geography::Point(Xcoord,Ycoord,4326).STDistance(@UserLoc)
	FROM Sala
	WHERE Xcoord is not null

	SELECT TOP (@NumSalas)
	Nome, Distancia_metros
	FROM @table
	ORDER BY Distancia_metros


RETURN 0
