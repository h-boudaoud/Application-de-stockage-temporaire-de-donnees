---- Sur SQL Server , Créer la base de données DataGridSample 
---- puis les deux table ci-dessous

--Create DATABASE  DataGridSample
--GO
--use DataGridSample
--Go

CREATE TABLE [dbo].[UserAdress] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Numero]     INT           NULL,
    [Voie]       VARCHAR (250) NOT NULL,
    [CodePostal] CHAR (6)      NOT NULL,
    [Ville]      VARCHAR (250) NOT NULL,
    CONSTRAINT [PK_dbo.UserAdress] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [dbo].[User] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Nom]        VARCHAR (250) NOT NULL,
    [Prenom]     VARCHAR (250) NOT NULL,
    [Age]        INT           NOT NULL,
    [Genre]      INT           NOT NULL,
    [Profession] VARCHAR (250) NULL,
    [Adress_Id]  INT           NULL,
    CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.User_dbo.UserAdress_Adress_Id] FOREIGN KEY ([Adress_Id]) REFERENCES [dbo].[UserAdress] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Adress_Id]
    ON [dbo].[User]([Adress_Id] ASC);

