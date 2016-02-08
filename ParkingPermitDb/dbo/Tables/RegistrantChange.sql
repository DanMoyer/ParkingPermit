CREATE TABLE [dbo].[RegistrantChange](
	Action				NVARCHAR(10),
	[Table]				NVARCHAR(10),
	[DeletedId]			INT  NULL,
	[DeletedFirstName]	NVARCHAR(30) NULL,
	[DeletedLastName]	NVARCHAR(30)  NULL,
	[InsertedId]		INT  NULL,
	[InsertedFirstName] NVARCHAR(30)  NULL,
	[InsertedLastName]	NVARCHAR(30)  NULL,
	[Date]				DATETIME NOT NULL,
) ON [PRIMARY]

