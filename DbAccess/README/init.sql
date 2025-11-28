CREATE TABLE [Person] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [IdNumber] varchar(30) NOT NULL,
    [Firstname] varchar(MAX) NOT NULL,
    [Lastname] varchar(MAX) NOT NULL,
    CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Person_Id] UNIQUE ([Id]),
    CONSTRAINT [UQ_Person_IdNumber] UNIQUE ([IdNumber])
    ) ON [PRIMARY];
GO

CREATE TABLE [Author] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Firstname] varchar(MAX) NOT NULL,
    [Lastname] varchar(MAX) NOT NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Author_Id] UNIQUE ([Id])
    ) ON [PRIMARY];
GO

CREATE TABLE [Publisher] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] varchar(MAX) NOT NULL,
    [Location] varchar(MAX) NOT NULL,
    CONSTRAINT [PK_Publisher] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Publisher_Id] UNIQUE ([Id])
    ) ON [PRIMARY];
GO

CREATE TABLE [Book] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [InternId] nvarchar(10) NOT NULL,
    [ISBN] int NOT NULL,
    [Title] varchar(MAX) NOT NULL,
    [Subject] varchar(50) NOT NULL CONSTRAINT CK_Book_Subject CHECK (
    [Subject] IN (
     'Roman','Kurzgeschichte','Klassiker','Lyrik','Fantasy','ScienceFiction','Horror','Mystery','Thriller',
     'Krimi','Abenteuer','HistorischerRoman','Liebesroman','YoungAdult','Kinderbuch','Sachbuch','Ratgeber',
     'Lexikon','Lehrbuch','Handbuch','Reisefuehrer','Geschichte','Politik','Gesellschaft','Kultur','Philosophie',
     'Psychologie','Paedagogik','Soziologie','Anthropologie','Archäologie','Naturwissenschaft','Mathematik',
     'Physik','Chemie','Biologie','Astronomie','Geowissenschaften','Informatik','Technik','Medizin',
     'Gesundheit','Umwelt','Wirtschaft','Finanzen','Recht','Management','Marketing','Personalwesen',
     'Unternehmertum','Religion','Theologie','Spiritualitaet','Esoterik','Kunst','Architektur','Fotografie',
     'Musik','Film','Theater','Mode','Design','Kochbuch','Gartenbau','Sport','Lifestyle','TrueCrime','Humor',
     'Tagebuch','Biografie','Autobiografie','Memoir'
                 )
    ),
    [PublisherId] int NOT NULL,
    [AuthorId] int NOT NULL,
    [PublishDate] date NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Book_Id] UNIQUE ([Id]),
    CONSTRAINT [UQ_Book_InternId] UNIQUE ([InternId])
    ) ON [PRIMARY];
GO

CREATE TABLE [Borrow] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PersonId] int NOT NULL,
    [BookId] int NOT NULL,
    [BorrowDate] datetime NOT NULL,
    [ReturnDate] datetime NULL,
    [LatestReturnDate] datetime NOT NULL,
    CONSTRAINT [PK_Borrow] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Borrow_Id] UNIQUE ([Id])
    ) ON [PRIMARY];
GO

ALTER TABLE [Book] WITH CHECK
    ADD CONSTRAINT [FK_Book_Publisher]
    FOREIGN KEY ([PublisherId]) REFERENCES [Publisher]([Id]);
GO

ALTER TABLE [Book] CHECK CONSTRAINT [FK_Book_Publisher];
GO

ALTER TABLE [Book] WITH CHECK
    ADD CONSTRAINT [FK_Book_Author]
    FOREIGN KEY ([AuthorId]) REFERENCES [Author]([Id]);
GO

ALTER TABLE [Book] CHECK CONSTRAINT [FK_Book_Author];
GO

ALTER TABLE [Borrow] WITH CHECK
    ADD CONSTRAINT [FK_Borrow_Person]
    FOREIGN KEY ([PersonId]) REFERENCES [Person]([Id]);
GO

ALTER TABLE [Borrow] CHECK CONSTRAINT [FK_Borrow_Person];
GO

ALTER TABLE [Borrow] WITH CHECK
    ADD CONSTRAINT [FK_Borrow_Book]
    FOREIGN KEY ([BookId]) REFERENCES [Book]([Id]);
GO

ALTER TABLE [Borrow] CHECK CONSTRAINT [FK_Borrow_Book];
GO
