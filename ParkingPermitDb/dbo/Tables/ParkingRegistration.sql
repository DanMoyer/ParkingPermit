﻿CREATE TABLE [dbo].[ParkingRegistration]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[UFId]   SMALLINT FOREIGN KEY REFERENCES Registrant(Id) NOT NULL,
	[TagNumber]      NVARCHAR (20) NULL,
	[DateTagIssued]  SMALLDATETIME NULL,
	[IssuedBy]       VARCHAR (20)  NULL,
	[Phone]          VARCHAR (20)  NULL,
	[Make]			 VARCHAR (20)  NULL,
	[Model]			 VARCHAR (20)  NULL,
	[Year]			 SMALLINT      NULL,
	[Color]          VARCHAR (20)  NULL,
	[LicenseNumber]  VARCHAR (20)  NULL,
	[State]          VARCHAR (10)  NULL,
	[CreatedDate]    SMALLDATETIME      NULL,
	[ModifiedDate]   SMALLDATETIME      NULL,
	[IsStudent]		 BIT NOT NULL,
	[IsFacStaff]     BIT NOT NULL,
	[ViolationCount] TINYINT       CONSTRAINT [DF_ParkingRegistration_ViolationCount] DEFAULT ((0)) NULL,
	[Location]       TINYINT FOREIGN KEY REFERENCES Location(Id) NOT NULL,
	[ClassYear]      TINYINT FOREIGN KEY REFERENCES ClassYear(Id) NOT NULL,
	[StudentType]    TINYINT FOREIGN KEY REFERENCES StudentType(Id) NOT NULL,
	[VehicleType]    TINYINT FOREIGN KEY REFERENCES  VehicleType(Id) NOT NULL,
	CONSTRAINT [PK_ParkingRegistration] PRIMARY KEY CLUSTERED ([Id] ASC)
)
