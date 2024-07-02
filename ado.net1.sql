create database AdoNetTask
use AdoNetTask

create table Academies(
	Id int identity(1,1) primary key,
	Name nvarchar(30)
)
create table Groups(
	Id int identity(1,1) primary key,
	Name nvarchar(30),
	AcademyId int foreign key references Academies(Id)
)
create table Students(
	Id int identity(1,1) primary key,
	Name nvarchar(30),
	Surname nvarchar(30),
	Age int,
	[Grant] decimal,
	GroupId int foreign key references Groups(Id)
)

insert into Academies
values
('1 Academy'),
('2 Academy')

insert into Groups 
values 
('group 1', 1),
('group 2', 2)

insert into Students
values
('John', '1', 20, 150, 1),
('dwayn', '2', 21, 200, 2),
('bob', '3', 22, 180, 1)
