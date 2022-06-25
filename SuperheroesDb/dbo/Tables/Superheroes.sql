CREATE TABLE [dbo].[Superheroes] (
    [Id]              INT            IDENTITY (1, 1) NOT NULL,
    [HeroName]        NVARCHAR (MAX) NOT NULL,
    [FirstName]       NVARCHAR (MAX) NOT NULL,
    [LastName]        NVARCHAR (MAX) NOT NULL,
    [Location]        NVARCHAR (MAX) NOT NULL,
    [Rank]            INT            NOT NULL,
    [NumberOfFriends] INT            NOT NULL,
    [ImgFileName]     NVARCHAR (MAX) DEFAULT (N'') NOT NULL,
    CONSTRAINT [PK_Superheroes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

