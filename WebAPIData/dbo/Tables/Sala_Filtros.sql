CREATE TABLE [dbo].[Sala_Filtros]
(
	[SalaId] INT NOT NULL, 
    [Filtro] NVARCHAR(80) NOT NULL,
	 CONSTRAINT [FK_SalaId] FOREIGN KEY ([SalaId]) REFERENCES [Sala]([ID]),
	 PRIMARY KEY ([SalaId],[Filtro]) 
)
