CREATE TABLE [dbo].[Musica]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [URI] NVARCHAR(200) NOT NULL, 
    [Nome] NVARCHAR(100) NOT NULL, 
    [Artista] NVARCHAR(100) NULL, 
    [Genero] NVARCHAR(100) NULL, 
    [Duracao_ms] INT NOT NULL
)
