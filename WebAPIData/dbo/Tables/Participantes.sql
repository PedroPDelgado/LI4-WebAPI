CREATE TABLE [dbo].[Participantes]
(
	[UserID] NVARCHAR(128) NOT NULL, 
    [SalaID] INT NOT NULL,
    CONSTRAINT [FK_Sala] FOREIGN KEY ([SalaID]) REFERENCES [Salas]([ID]),
    PRIMARY KEY ([UserID],[SalaID])
)
