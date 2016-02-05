CREATE TABLE [dbo].[Registrant]
(
	[Id] SMALLINT NOT NULL PRIMARY KEY,        --UF Id
	[FirstName] VARCHAR (30) NOT NULL,
	[LastName]  VARCHAR (30) NOT NULL,
	[IsStudent] BIT NOT NULL,
	[IsFacStaff] BIT NOT NULL,
	CONSTRAINT [PK_Registrant] PRIMARY KEY CLUSTERED ([Id] ASC)
)
