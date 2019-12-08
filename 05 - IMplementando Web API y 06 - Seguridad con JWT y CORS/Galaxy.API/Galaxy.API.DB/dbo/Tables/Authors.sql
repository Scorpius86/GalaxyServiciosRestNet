CREATE TABLE [dbo].[Authors] (
    [Id]          UNIQUEIDENTIFIER   NOT NULL,
    [DateOfBirth] DATETIMEOFFSET (7) NOT NULL,
    [FirstName]   NVARCHAR (50)      NOT NULL,
    [Genre]       NVARCHAR (50)      NOT NULL,
    [LastName]    NVARCHAR (50)      NOT NULL,
    [DateOfDeath] DATETIMEOFFSET (7) NULL,
    CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED ([Id] ASC)
);



