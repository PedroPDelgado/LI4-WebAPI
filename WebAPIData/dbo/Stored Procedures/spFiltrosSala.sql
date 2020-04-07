CREATE PROCEDURE [dbo].[spFiltrosSala]
	@SalaId int
AS
	SELECT Filtro
	FROM dbo.Sala_Filtros
	WHERE SalaId = @SalaId
RETURN 0
