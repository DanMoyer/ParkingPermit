﻿CREATE TABLE [dbo].[VehicleType]
(
	[Id] TINYINT NOT NULL PRIMARY KEY,
	[VehicleType] VARCHAR(20) NOT NULL,
	CONSTRAINT [PK_VehicleType] PRIMARY KEY CLUSTERED ([Id] ASC)
)