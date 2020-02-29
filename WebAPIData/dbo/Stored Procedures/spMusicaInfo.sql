CREATE PROCEDURE [dbo].[spMusicaInfo]
	@Id int
AS
BEGIN
	select ID, URI
	from dbo.Musica
	where ID = @Id;
END

