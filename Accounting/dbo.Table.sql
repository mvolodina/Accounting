CREATE TABLE [dbo].[Supplier]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] TEXT NULL, 
    [Phone] TEXT NULL, 
    [E-mail] TEXT NULL, 
    [Address] TEXT NULL, 
    [FK_ord] INT NULL, 
    CONSTRAINT [FK_ord] FOREIGN KEY ([FK_ord]) REFERENCES [Orders]([id])
)
