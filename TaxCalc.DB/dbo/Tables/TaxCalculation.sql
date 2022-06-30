CREATE TABLE [dbo].[TaxCalculation] (
    [Id]         INT         IDENTITY (1, 1) NOT NULL,
    [DateTime]   DATETIME    CONSTRAINT [DF__TaxCalcul__DateT__286302EC] DEFAULT (getdate()) NOT NULL,
    [PostalCode] VARCHAR (4) NOT NULL,
    [Income]     INT         NOT NULL,
    CONSTRAINT [PK__TaxCalcu__3214EC0795A2F714] PRIMARY KEY CLUSTERED ([Id] ASC)
);

