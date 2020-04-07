CREATE PROCEDURE [dbo].[spRemoverMusicaSalaURI]
	@SalaId int,
	@MusicaURI nvarchar(200),
	@UserId nvarchar(128)
AS
	DECLARE @OwnerId nvarchar(128)

	SELECT @OwnerId = AuthOwnerID
	FROM [dbo].Sala
	WHERE ID = @SalaId

	DELETE FROM dbo.[Sala_Musica]
	WHERE SalaID = @SalaId
	AND MusicaURI = @MusicaURI
	AND (UserId = @UserId OR UserId = @OwnerId)

RETURN 0
