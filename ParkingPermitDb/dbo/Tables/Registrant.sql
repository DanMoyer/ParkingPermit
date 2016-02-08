CREATE TABLE [dbo].[Registrant](
	[Id]		INT NOT NULL PRIMARY KEY,        --UF Id
	[FirstName] NVARCHAR (30) NOT NULL,
	[LastName]  NVARCHAR (30) NOT NULL,
	[IsStudent] BIT NOT NULL
)
