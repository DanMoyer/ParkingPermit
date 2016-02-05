CREATE TABLE [dbo].[Admin_Security_ParkingRegistration] (
    [RowID]          INT           IDENTITY (1, 1) NOT NULL,
    [TagNumber]      NVARCHAR (90) NULL,
    [DateTagIssued]  SMALLDATETIME NULL,
    [IssuedBy]       VARCHAR (50)  NULL,
    [StudentID]      VARCHAR (90)  NULL,
    [ClassYear]      VARCHAR (50)  NULL,
    [FirstName]      VARCHAR (90)  NULL,
    [LastName]       VARCHAR (90)  NULL,
    [Phone]          VARCHAR (90)  NULL,
    [StudentType]    VARCHAR (50)  NULL,
    [CarMake]        VARCHAR (90)  NULL,
    [CarModel]       VARCHAR (50)  NULL,
    [Color]          VARCHAR (90)  NULL,
    [LicenseNumber]  VARCHAR (90)  NULL,
    [State]          VARCHAR (90)  NULL,
    [CarYear]        INT           NULL,
    [CreatedDate]    DATETIME      NULL,
    [ModifiedDate]   DATETIME      NULL,
    [ViolationCount] TINYINT       CONSTRAINT [DF_Admin_Security_ParkingRegistration_ViolationCount] DEFAULT ((0)) NULL,
    [VehicleType]    VARCHAR (50)  NULL,
    CONSTRAINT [PK_Admin_Security_ParkingRegistration] PRIMARY KEY CLUSTERED ([RowID] ASC)
);

