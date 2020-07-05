CREATE PROCEDURE [dbo].[spBansSala]
	@SalaId int
AS
	SELECT UserId 
	FROM BlackList
	WHERE SalaId = @SalaId
RETURN 0
