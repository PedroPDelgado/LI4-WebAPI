CREATE TABLE [dbo].[Sala_Musica]
(
	[SalaID] INT NOT NULL , 
    [MusicaURI] NVARCHAR(200) NOT NULL, 
    [Posicao] INT NOT NULL IDENTITY(1,1), 
    [UserId] NVARCHAR(128) NULL, 
    CONSTRAINT [FK_Musica] FOREIGN KEY ([MusicaURI]) REFERENCES [Musica]([URI]),
    PRIMARY KEY ([SalaID],[MusicaURI],[Posicao]) 
)
