create table Users(
    Id  uniqueidentifier ,
    Username nvarchar(100) Primary Key,
    [Password] nvarchar(100),
    UserRole int,
    IsDeleted bit
    );

drop table Users;
select * from Users;
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

select * from Professors;
select * from [Objects];

create table Groups(
	Id uniqueidentifier PRIMARY KEY,
	[Name] nvarchar(30),
	IsDeleted bit 
);

insert into Groups(Id,[Name],IsDeleted) values ('feacf0cb-3c0f-476d-a04c-34da5421e0df','B1',0);
insert into Groups(Id,[Name],IsDeleted) values ('76792adf-0f81-4c74-9ee2-dafdbe2251a2','B2',0);
insert into Groups(Id,[Name],IsDeleted) values ('d14bcbce-591d-48f6-996b-cc57aae573b4','B3',0);
insert into Groups(Id,[Name],IsDeleted) values ('fe014ec1-8c55-413e-b3f1-d62df430a76f','B4',0);
insert into Groups(Id,[Name],IsDeleted) values ('e8b1e446-f674-43a8-bdc5-b92d7a363dd3','B5',0);
insert into Groups(Id,[Name],IsDeleted) values ('7202d464-90f4-4c22-a5f2-61bf508f3682','B6',0);
insert into Groups(Id,[Name],IsDeleted) values ('0d7e6973-cd0b-463e-8a6c-52410c14f10e','B7',0);
insert into Groups(Id,[Name],IsDeleted) values ('0958befa-e07e-4037-abf8-6146ca1a2868','A1',0);
insert into Groups(Id,[Name],IsDeleted) values ('12ce18e4-bf9b-4e27-bb9a-1edc854a3d98','A2',0);
insert into Groups(Id,[Name],IsDeleted) values ('fd342149-b6c2-481e-99ca-747b5fb56acc','A3',0);
insert into Groups(Id,[Name],IsDeleted) values ('d4f09fb2-92f1-45ed-b389-242e0d2b936b','A4',0);
insert into Groups(Id,[Name],IsDeleted) values ('9858b93a-6682-48a5-acb9-46a0c7e933a0','A5',0);
insert into Groups(Id,[Name],IsDeleted) values ('c8411d33-c8ea-4fce-be5f-ec6dac421736','A6',0);
insert into Groups(Id,[Name],IsDeleted) values ('939f2688-78f1-4e66-a169-d2f7b34b43fb','A7',0);
insert into Groups(Id,[Name],IsDeleted) values ('82111798-2f0d-4403-947b-60e7f57f49b7','E1',0);
insert into Groups(Id,[Name],IsDeleted) values ('dee7efe8-52d9-4724-ac9d-75aba0e720ff','E2',0);



Select * from Groups;

create table [Objects](
	Id uniqueidentifier PRIMARY KEY,
	[Name] nvarchar(100),
	[Year] int,
	IsDeleted bit
);

drop table [Objects];
insert into [Objects](Id,[Name],[Year],IsDeleted) values ('e4b56040-d812-4d8d-a683-da011e4077c2','Computer Networks',1,0);
insert into [Objects](Id,[Name],[Year],IsDeleted) values ('5edbac92-7ba3-41db-83b8-6f9629de96b8','Algebraic Foundations of Computer Science',0,0);
insert into [Objects](Id,[Name],[Year],IsDeleted) values ('e19d64b2-5016-4e62-8cbf-cd96ea90e637','Databases',1,0);
insert into [Objects](Id,[Name],[Year],IsDeleted) values ('640dafe0-7363-432a-a338-15dbcb9a9e06','Data Structures',0,0);
insert into [Objects](Id,[Name],[Year],IsDeleted) values ('aa92f091-a1f7-4867-ac71-233c7d28144b','Logics for Computer Science',0,0);
insert into [Objects](Id,[Name],[Year],IsDeleted) values ('3f2d9995-a636-43e6-a6fb-249597f40a7b','Information Security',2,0);


create table Schedules(
	Id uniqueidentifier PRIMARY KEY,
	[Group] nvarchar(100),
	[Year] int,
	[Object] nvarchar(100),
	[Professor] nvarchar(100),
	[Day] int,
	[StartTime] int,
	[EndTime] int,
	IsDeleted bit
);

insert into Schedules(Id,[Group],[Year],[Object],[Professor],[Day],[StartTime],[EndTime],IsDeleted) values
('706dd455-5b5e-4317-bb18-313223bdc8c6','B1',0,'Data Structures','Gatu Cristian',1,8,10,0);
insert into Schedules(Id,[Group],[Year],[Object],[Professor],[Day],[StartTime],[EndTime],IsDeleted) values
('acfc99c8-a163-4740-9715-07e7533aa4a5','B2',0,'Data Structures','Gatu Cristian',0,8,10,0);
drop table Schedules;

create table Subscriptions(
	Id uniqueidentifier PRIMARY KEY,
	[User] uniqueidentifier,
	[Professor] uniqueidentifier,
	IsDeleted bit
);

create table Anouncements(
	Id uniqueidentifier PRIMARY KEY,
	[Professor] nvarchar(100),
	[AnouncementText] nvarchar(400),
	[CreationDate] datetime, 
	IsDeleted bit
);

drop table Anouncements;