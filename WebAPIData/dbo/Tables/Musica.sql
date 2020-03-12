CREATE TABLE [dbo].[Musica]
(
    [URI] NVARCHAR(200) NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(100) NOT NULL, 
    [Artista] NVARCHAR(100) NULL, 
    [Genero] NVARCHAR(100) NULL, 
    [Duracao_ms] INT NOT NULL
)
