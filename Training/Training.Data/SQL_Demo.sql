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