﻿CREATE TABLE [dbo].[Musica_Artistas]
(
	[MusicaURI] NVARCHAR(200) NOT NULL, 
    [Artista] NCHAR(200) NOT NULL,
	CONSTRAINT [FK_MusicaURI] FOREIGN KEY ([MusicaURI]) REFERENCES [Musica]([URI]),
	 PRIMARY KEY ([MusicaURI],[Artista])
)
