create table Users (
Id int primary key identity (1,1),
Login nvarchar(50),
Password nvarchar(50)
)

create table Posts (
Id int primary key identity (1,1),
Header nvarchar (100),
Description nvarchar(max)
)

INSERT INTO Users(Login	, Password)
VALUES ('Admin','Admin');


INSERT INTO Users(Login	, Password)
VALUES ('Moderator','Moderator');

INSERT INTO Users(Login	, Password)
VALUES ('User','User');

select * from Users