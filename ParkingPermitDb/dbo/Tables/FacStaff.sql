CREATE TABLE [dbo].[FacStaff] (
    [Id]        INT          IDENTITY (1, 1) NOT NULL,
    [FirstName] VARCHAR (90) NULL,
    [LastName]  VARCHAR (90) NULL,
    CONSTRAINT [PK_FacStaff] PRIMARY KEY CLUSTERED ([Id] ASC)
);

