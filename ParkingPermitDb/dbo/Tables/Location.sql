﻿CREATE TABLE [dbo].[Location]
(
	[Id] TINYINT NOT NULL PRIMARY KEY,
	[Location] VARCHAR(20) NOT NULL,	
	CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([Id] ASC)
)