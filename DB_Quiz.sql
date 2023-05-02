CREATE DATABASE [Quiz]
GO

USE [Quiz]
GO

CREATE TABLE [Category](
    [Id] INT NOT NULL IDENTITY(1,1),
    [Matter] NVARCHAR(200) NOT NULL,

    CONSTRAINT [PK_Category] PRIMARY KEY ([Id])
)

CREATE TABLE [Question](
    [Id] INT NOT NULL IDENTITY(1,1),
    [CategoryId] INT NOT NULL,
    [Body] TEXT NOT NULL,

    CONSTRAINT [PK_Question] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Question_Category] FOREIGN KEY ([CategoryId])
        REFERENCES [Category]([Id])
)

CREATE TABLE [Answer](
    [QuestionId] INT NOT NULL,
    [AnswerOrder] INT NOT NULL,
    [Body] TEXT NOT NULL,
    [RightAnswer] BIT NOT NULL,

    CONSTRAINT [PK_Answer] PRIMARY KEY ([QuestionId], [AnswerOrder]),
    CONSTRAINT [FK_Answer_Question] FOREIGN KEY ([QuestionId])
        REFERENCES [Question]([Id])
)

