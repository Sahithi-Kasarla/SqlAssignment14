Create database CricDb
use CricDb
create table Team(Id int primary key,TeamName nvarchar(50) not
null unique)

create table Player
(Id int primary key,
PlayerName varchar(50) not null,
PlayerRole nvarchar(50) not null,
TeamName int foreign key references Team(Id)
)
insert into Team Values(1,'CSK')
insert into Team Values(2,'RCB')
insert into Team Values(3,'SRH')

insert into Player values(1,'MSD','WicketKeeper/Bat',1)
insert into Player values(2,'Virat','Batsman',1)
insert into Player values(3,'Siraj','Bowler',1)
insert into Player values(4,'Yuvaraj','All-Rounder',1)

select *from Player

