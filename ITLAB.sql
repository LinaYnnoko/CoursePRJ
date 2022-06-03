use master

create database ITLabDB

use ITLabDB

create table Users(
ID int primary key IDENTITY(1,1) not null,
Email nvarchar(max) not null,
FullName nvarchar(max) not null,
Address nvarchar(max),
HashPassword nvarchar(max) not null,
IsAdministrator bit not null,
);

CREATE table Messages 
(	
	ID int primary key IDENTITY(1,1),
	UserID1 int,
	UserID2 int,
	Text nvarchar(max),
	SendTime DateTime
);


create table Computers(
	ID int primary key IDENTITY(1,1),
	TypeComputer nvarchar(max),
	SizeRAM nvarchar(max),
	TypeRAM nvarchar(max),
	SizeHardDisk int,
	TypeHardDisk nvarchar(max),
	TimeOfOrder DateTime,
	UserID int
);

create table GPUs(
ID int primary key IDENTITY(1,1),
Frequency nvarchar(max),
Series nvarchar(max),
Model nvarchar(max),
Memory int,
ComputerId int
);

create table CPUs(
ID int primary key IDENTITY(1,1),
Frequency nvarchar(max),
Series nvarchar(max),
Model nvarchar(max),
CacheSize int,
NumberOfCores int,
ComputerId int
);

alter table Messages add constraint fk_msg11 foreign key (UserID1) references Users(ID);
alter table Messages add constraint fk_msg12 foreign key (UserID2) references Users(ID);
alter table Computers add constraint fk_com1 foreign key (UserID) references Users(ID);
alter table GPUs add constraint fk_gpu1 foreign key (ComputerId) references Computers(ID);
alter table CPUs add constraint fk_cpu1 foreign key (ComputerId) references Computers(ID);
