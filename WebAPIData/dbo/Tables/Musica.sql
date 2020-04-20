CREATE TABLE [dbo].[Musica]
(
    [URI] NVARCHAR(200) NOT NULL PRIMARY KEY, 
    [Nome] NVARCHAR(100) NOT NULL,
    [Duracao_ms] INT NOT NULL, 
    [Album] NVARCHAR(100) NOT NULL, 
    [Url_imagem] NVARCHAR(500) NOT NULL
)
