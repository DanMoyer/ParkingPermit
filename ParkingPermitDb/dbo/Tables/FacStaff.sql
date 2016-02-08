CREATE TABLE [dbo].[FacStaff] (
    [Id]        INT NOT NULL PRIMARY KEY,
    [FirstName] NVARCHAR (30) NULL,
    [LastName]  NVARCHAR (30) NULL,
    CONSTRAINT [PK_FacStaff] PRIMARY KEY CLUSTERED ([Id] ASC)
);

