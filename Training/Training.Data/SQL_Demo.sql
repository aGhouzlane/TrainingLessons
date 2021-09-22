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

/* ANother way to change the setting for just the query instead of in general */
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
