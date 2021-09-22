/* DDL statements (Data Definition Language) */
/* Can run this to create a table */
Create Table [Training].[dbo].[TestTable] (
	[Id] [int] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[FavoriteFood] [int] NULL,
	CONSTRAINT [PK_TestTable] Primary Key ([Id]),
	CONSTRAINT [FK_TestTable_TestFoods] FOREIGN KEY([FavoriteFood]) REFERENCES [dbo].[TestFoods] ([Id])
);

/* Set IDENTITY_INSERT dbo.TestTable ON; */
Insert into dbo.TestTable ([Id], [Name], FavoriteFood) values(1, 'Eric Miller', 3);
Insert into dbo.TestTable ([Id], Name, FavoriteFood) values(2, 'Justin Winans', 5);
Insert into dbo.TestTable ([Id], Name, FavoriteFood) values(3, 'Miles Mixon', 1);

/* removes all data in the table, but does not delete it */
Truncate Table dbo.TestTable;

/* can run this to get rid of a table and its data */
Drop Table [Training].[dbo].[TestTable];