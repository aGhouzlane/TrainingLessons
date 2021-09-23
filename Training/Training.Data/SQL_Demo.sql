/* insert statements */
/* brackets surrounding a value keeps it from using keywords */
Insert into dbo.Trainees ([Name], FavoriteFood) values('Eric Miller', 'Tacos');
Insert into dbo.Trainees (Name, FavoriteFood) values('Justin Winans', 'Pizza');
Insert into dbo.Trainees (Name, FavoriteFood) values('Miles Mixon', 'Chicken Tenders');

/* select everything */
select * from dbo.Trainees;
/* select specific things */
select FavoriteFood from dbo.Trainees;
select Id, Name, FavoriteFood from dbo.Trainees;

/* both do the same thing */
select * from dbo.Trainees where Id >= 2 and Id <= 4;
select * from dbo.Trainees where Id between 2 and 4;

delete from dbo.Trainees where Id = 4;

/* auto increment does not recycle id's it just keeps incrementing */
Insert into dbo.Trainees (Name, FavoriteFood) values('Miles Mixon', 'Chicken Tenders');

/* cannot set an identity column field by default. must turn setting on */
Set IDENTITY_INSERT dbo.Trainees ON;
Insert into dbo.Trainees (Id, Name, FavoriteFood) values(4, 'Yash Patel', 'Tikka Masala');

Update dbo.Trainees set FavoriteFood = NULL;

Insert into dbo.Foods (Name, Calories) values ('Pickles', 100);
Insert into dbo.Foods (Name, Calories) values ('Tacos', 200);
Insert into dbo.Foods (Name, Calories) values ('Pizza', 300);
Insert into dbo.Foods (Name, Calories) values ('Tikki Masala', 400);
Insert into dbo.Foods (Name, Calories) values ('Chicken Tenders', 500);

select * from dbo.Foods;

Update dbo.Trainees set FavoriteFood = 1 where Id = 1;
Update dbo.Trainees set FavoriteFood = 4 where Id = 4;
Update dbo.Trainees set FavoriteFood = 3 where Id = 3;
Update dbo.Trainees set FavoriteFood = 5 where Id = 5;
Update dbo.Trainees set FavoriteFood = 2 where Id = 2;

/* As keyword used for ailiasing */
/* Returns results in the order you specify */
select T.Id, T.Name, F.Name as Favorite_Food from dbo.Trainees as T Join dbo.Foods as F on F.Id = T.FavoriteFood;

/* ----------- Day 3 SQL ---------- */
Insert into dbo.Foods (Name, Calories) values ('Spaghetti', 300);
Rollback Transaction; /* Doesnt work because transaction has already happened by default */

Begin Tran T1; /* Can name transactions or just leave without a name */
Update dbo.Trainees set FavoriteFood = 5 where Id = 1;
Update dbo.Trainees set FavoriteFood = 2 where Id = 4;
Update dbo.Trainees set FavoriteFood = 4 where Id = 3;
Update dbo.Trainees set FavoriteFood = 3 where Id = 5;
Update dbo.Trainees set FavoriteFood = 1 where Id = 2;

select * from dbo.Trainees;

rollback tran T1;

select * from dbo.Trainees;

/* how you save a transaction */
Begin tran T2;
Insert into dbo.Foods (Name, Calories) values ('Rice', 100);
Insert into dbo.Foods (Name, Calories) values ('Burger', 400);

select * from dbo.Foods;

commit tran T2;

select * from dbo.Foods;

rollback tran T2;

/* Another way to change the setting for just the query instead of in general */
SET IMPLICIT_TRANSACTIONS ON;
Begin Tran; /* Can name transactions or just leave without a name */
Update dbo.Trainees set FavoriteFood = 5 where Id = 1;
Update dbo.Trainees set FavoriteFood = 2 where Id = 4;
Update dbo.Trainees set FavoriteFood = 4 where Id = 3;
Update dbo.Trainees set FavoriteFood = 3 where Id = 5;
Update dbo.Trainees set FavoriteFood = 1 where Id = 2;

select * from dbo.Trainees;

rollback tran;
SET IMPLICIT_TRANSACTIONS OFF;

/* two different ways to run the same stored procedure */
dbo.UpdateFavFood 5, 7;
select Id, Name, FavoriteFood from dbo.Trainees;

exec dbo.UpdateFavFood @Food = 9, @Id = 4;
select Id, Name, FavoriteFood from dbo.Trainees;

dbo.GetTrainees;

/* must declare a variable to be returned from a stored procedure with a return value */
declare @NewId int;
/* have to pass in the variable to be used by the output */
exec dbo.AddTrainee @Name = 'Tyler Hilton', @Food = 9, @Id = @NewId Output;

select @NewId as 'New ID';

/* Control flow statements do exist */
exec dbo.ControlFlow 1;

Insert into dbo.Trainees ([Name]) values('Ryan Taylor');
Insert into dbo.Trainees (Name) values('Ahmed Ghouzlane');

/*Three different ways to get the same results */
select * from dbo.Trainees as T join dbo.Foods as F on T.FavoriteFood = F.Id;
select * from dbo.Trainees as T inner join dbo.Foods as F on T.FavoriteFood = F.Id;
select * from dbo.Trainees as T, dbo.Foods as F where T.FavoriteFood = F.Id;

/* cross join, avoid this */
select * from dbo.Trainees as T, dbo.Foods;

/* Not a cross join, but does display everything from both tables */
select * from dbo.Trainees as T full outer join dbo.Foods as F on T.FavoriteFood = F.Id;

/* Left join returns everything from the left table and anything that matches on the right, vice-vers for a right join */
select * from dbo.Trainees as T left join dbo.Foods as F on T.FavoriteFood = F.Id;
select * from dbo.Trainees as T right join dbo.Foods as F on T.FavoriteFood = F.Id;

select * from dbo.Trainees as T left join dbo.Foods as F on T.FavoriteFood = F.Id Where T.FavoriteFood IS NULL;

insert into dbo.Vehicles (Make, Model, [Year], [Owner]) values ('Ford', 'Mustang', '2020', 6);
insert into dbo.Vehicles (Make, Model, [Year], [Owner]) values ('Toyota', 'Corolla', '2004', 5);
insert into dbo.Vehicles (Make, Model, [Year], [Owner]) values ('Nissan', 'GTR', '2018', 1);

/* join multiple tables together */
select 
	T.Id as 'Trainee Id', 
	T.[Name] as 'Trainee Name', 
	FavoriteFood as 'Food Id', 
	F.[Name] as 'Favorite Food', 
	Make, 
	Model, 
	[Year]
from dbo.Trainees as T
join dbo.Foods as F on T.FavoriteFood = F.Id 
Join dbo.Vehicles as V on T.Id = V.[Owner];

/* Very basic nested query */
select qInner.[Name] from (select * from dbo.Foods) as qInner;

select * from (
	select 
		T.Id as 'Trainee Id', 
		T.[Name] as 'Trainee Name', 
		FavoriteFood as 'Food Id', 
		F.[Name] as 'Favorite Food', 
		Make, 
		Model, 
		[Year]
	from dbo.Trainees as T
	join dbo.Foods as F on T.FavoriteFood = F.Id 
	Join dbo.Vehicles as V on T.Id = V.[Owner]
	) as qInner
where [Trainee Id] > 4;

/* example of a self join. Used to compare values within the same table */
select * from dbo.Trainees as T1, dbo.Trainees as T2 where T1.FavoriteFood = T2.FavoriteFood and T1.Id != T2.Id;

/* Union keyword is used to combine the results of two queries */
select * from dbo.Trainees where Id < 3 
union 
select * from dbo.Trainees where Id > 5;

/* only returns overlapping rows */
/* in this case returns nothing */
select * from dbo.Trainees where Id < 3 
intersect 
select * from dbo.Trainees where Id > 5;

/* in this case returns 2 rows */
select * from dbo.Trainees where Id <= 5 
intersect 
select * from dbo.Trainees where Id >= 4;

/* except = minus returns everything in the first query that is not a part of the second */
select * from dbo.Trainees
except
select * from dbo.Trainees where Id > 4;

/* Queries follow ACID transactions, Atomicity, Consisitency, Isolation, and Durability */
select * from dbo.Trainees;
update dbo.Trainees set FavoriteFood = 7 where Id = 7;

/* Count(*) does not skip null values */
/* Count(column name) does skip null values */
select COUNT(*) as 'Number of Trainees' from dbo.Trainees;
select * from dbo.Trainees;

/* Aggregate functions return scalars and will ignore null values */
select AVG(FavoriteFood) from dbo.Trainees;
select MAX(FavoriteFood) from dbo.Trainees;
select MIN(FavoriteFood) from dbo.Trainees;
select SUM(FavoriteFood) from dbo.Trainees;

/* can use aggregate functions on the results of queries */
select SUM([Food Id]) from (
	select 
		T.Id as 'Trainee Id', 
		T.[Name] as 'Trainee Name', 
		FavoriteFood as 'Food Id', 
		F.[Name] as 'Favorite Food', 
		Make, 
		Model, 
		[Year]
	from dbo.Trainees as T
	join dbo.Foods as F on T.FavoriteFood = F.Id 
	Join dbo.Vehicles as V on T.Id = V.[Owner]
	) as qInner
where [Trainee Id] > 4;

/* can use concat to combine multiple columns inot a single string */
select 
	T.Id as 'Trainee Id', 
	T.[Name] as 'Trainee Name', 
	FavoriteFood as 'Food Id', 
	F.[Name] as 'Favorite Food', 
	CONCAT([Year], ' ', Make, ' ', Model) as 'Vehicle'
from dbo.Trainees as T
join dbo.Foods as F on T.FavoriteFood = F.Id 
Join dbo.Vehicles as V on T.Id = V.[Owner];

/* must include everything in the columns selected in group by statement */
/* can only use group by with aggregate functions to control how datat is aggregated */
select 
	F.[Name] as 'Favorite Food',
	Count(T.Id)
from dbo.Trainees as T
join dbo.Foods as F on T.FavoriteFood = F.Id
Group By F.[Name];

/* Order By is used to control the order that data is returned */
select 
	F.[Name] as 'Favorite Food',
	Count(T.Id)
from dbo.Trainees as T
join dbo.Foods as F on T.FavoriteFood = F.Id
Group By F.[Name]
Order By F.[Name] ASC;

select 
	T.Id as 'Trainee Id', 
	T.[Name] as 'Trainee Name', 
	FavoriteFood as 'Food Id', 
	F.[Name] as 'Favorite Food'
from dbo.Trainees as T
join dbo.Foods as F on T.FavoriteFood = F.Id
Order By [Food Id] ASC;

/* Having only works with aggregate functions and serves the purpose of a where clause */
select 
	F.[Name] as 'Favorite Food',
	Count(T.Id) as 'Count'
from dbo.Trainees as T
join dbo.Foods as F on T.FavoriteFood = F.Id
Group By F.[Name]
Having COUNT(T.[Id]) > 1
Order By F.[Name] ASC;

/* two different queries above only gets entries with a count above 1, this gets the count for only employees 
with an Id greater than 4 */
select 
	F.[Name] as 'Favorite Food',
	Count(T.Id)
from dbo.Trainees as T
join dbo.Foods as F on T.FavoriteFood = F.Id
where T.Id > 4
Group By F.[Name]
Order By F.[Name] ASC;

/* LEN function returns the length of a string */
select T.[Name], LEN(T.[Name]) as 'Number of Characters' from dbo.Trainees as T;

/* Removes leading and trailing white space */
select TRIM('               string        string        ');

/* Numeric and Decimal mean the same thing 
Defined as Decimal(precision, scale) precision is the number of digits, scale is the number of digits after the 
decimal place */

-- decimal and numeric will add trailing zeroes and hold up to whataver amount of total digits
-- they will not add leading 0's
CREATE TABLE dbo.MyTable  
(  
	Id int Primary Key Not Null,
	MyDecimalColumn DECIMAL(5,2),
	MyNumericColumn NUMERIC(10,5)
);  
  
GO  
INSERT INTO dbo.MyTable VALUES (1, 123, 12345.12);  
INSERT INTO dbo.MyTable VALUES (2, 12, 145.12);  
INSERT INTO dbo.MyTable VALUES (3, 123.4, 125.13332);  
GO  
SELECT MyDecimalColumn, MyNumericColumn  
FROM dbo.MyTable;

Select POWER(3, 5);

/* Round rounds up or down to however many decimal places are specified, does not remove trailing zeroes 
Round does not change the data type.
Ceiling and floor change the data type to an integer
Ceiling gets the neirest int above the value, floor gets the nearest int below a value*/
Select ROUND(125.13532, 2);

Select CEILING(125.13532) as 'Ceiling';
select FLOOR(125.13532) as 'Floor';

-- same as GETDATE but for UTC
select GETUTCDATE();

/* In lets you specify multiple values for a where clause */
select * from dbo.Trainees where Id = 1 Or Id = 5 Or Id = 6;
select * from dbo.Trainees where Id In (1, 5, 6);
select * from dbo.Trainees where Id In
(select 
	T.Id
from dbo.Trainees as T
Join dbo.Vehicles as V on T.Id = V.[Owner]
);

/* Checks if the query evaluates to true or false and then returns data based on that */
select T2.Id, T2.Name from dbo.Trainees as T2 where exists
(select 
	T.Id
from dbo.Trainees as T
Join dbo.Vehicles as V on T.Id = V.[Owner] and T.Id = T2.Id);

/* Changeed in VS */