CREATE TABLE [dbo].[Books] (
    [Id]          UNIQUEIDENTIFIER NOT NULL,
    [AuthorId]    UNIQUEIDENTIFIER NOT NULL,
    [Description] NVARCHAR (500)   NULL,
    [Title]       NVARCHAR (100)   NOT NULL,
    CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Books_Authors_AuthorId] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Authors] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_Books_AuthorId]
    ON [dbo].[Books]([AuthorId] ASC);

