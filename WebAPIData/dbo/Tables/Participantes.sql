CREATE TABLE [dbo].[Participantes]
(
	[UserID] NVARCHAR(128) NOT NULL, 
    [SalaID] INT NOT NULL,
    CONSTRAINT [FK_Sala] FOREIGN KEY ([SalaID]) REFERENCES [Sala]([ID]),
    PRIMARY KEY ([UserID],[SalaID])
)
