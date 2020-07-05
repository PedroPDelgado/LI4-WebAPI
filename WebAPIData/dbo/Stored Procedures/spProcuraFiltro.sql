CREATE PROCEDURE [dbo].[spProcuraFiltro]
	@Nome nvarchar(200)
AS
	SELECT Filtro
	FROM Filtros
	WHERE Filtro LIKE '%' + @Nome + '%'

RETURN 0
