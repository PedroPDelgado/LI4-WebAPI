CREATE TABLE [dbo].[BlackList]
(
	[SalaId] INT NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL,
	CONSTRAINT [Sala_Fk] FOREIGN KEY ([SalaId]) REFERENCES [Sala]([ID]),
    PRIMARY KEY ([SalaId],[UserId])
)
