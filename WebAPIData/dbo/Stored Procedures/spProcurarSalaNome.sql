CREATE PROCEDURE [dbo].[spProcurarSalaNome]
	@Nome nvarchar(200)
AS
	SELECT Nome
	FROM Sala
	WHERE Nome LIKE '%' + @Nome + '%'

RETURN 0
