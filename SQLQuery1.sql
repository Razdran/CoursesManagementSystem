create table Users(
    Id  uniqueidentifier ,
    Username nvarchar(100) Primary Key,
    [Password] nvarchar(100),
    UserRole int,
    IsDeleted bit
    );

drop table Users;

create table Students(
	Id  uniqueidentifier PRIMARY KEY,
	UserId uniqueidentifier,
	FirstName nvarchar(100),
	LastName nvarchar(100),
	[Group] uniqueidentifier,
	[Year] int,
	[Email] nvarchar(100),
	IsDeleted bit
);

drop table students;

create table Professors(
	Id  uniqueidentifier PRIMARY KEY,
	UserId uniqueidentifier,
	FirstName nvarchar(100),
	LastName nvarchar(100),
	[Object] uniqueidentifier,
	[Email] nvarchar(100),
	IsDeleted bit
);

create table Groups(
	Id uniqueidentifier PRIMARY KEY,
	[Name] nvarchar(30),
	IsDeleted bit 
);

insert into Groups(Id,[Name],IsDeleted) values ('feacf0cb-3c0f-476d-a04c-34da5421e0df','B1',0)
insert into Groups(Id,[Name],IsDeleted) values ('76792adf-0f81-4c74-9ee2-dafdbe2251a2','B2',0)
Select * from Groups;

create table [Objects](
	Id uniqueidentifier PRIMARY KEY,
	[Name] nvarchar(100),
	IsDeleted bit
);
insert into [Objects](Id,[Name],IsDeleted) values ('e4b56040-d812-4d8d-a683-da011e4077c2','Computer Networks',0)

