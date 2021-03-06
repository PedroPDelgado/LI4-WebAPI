﻿CREATE TABLE [dbo].[Sala]
(
	[ID] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [AuthOwnerID] NVARCHAR(128) NOT NULL, 
    [Estado] NVARCHAR(50) NOT NULL DEFAULT 'Open', 
    [Nome] NVARCHAR(50) NOT NULL UNIQUE, 
    [Password] VARBINARY(MAX) NOT NULL, 
    [Xcoord] FLOAT NULL, 
    [Ycoord] FLOAT NULL, 
    [LimiteMusicas] INT NULL, 
    [LimiteHoras] INT NULL, 
    [MusicaAtual] INT NOT NULL DEFAULT 0
)
