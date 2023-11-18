--SQL Server
create table stockValues
(
id int IDENTITY(1,1) PRIMARY KEY,
companyId int,
date date,
openCost float,
highCost float,
lowCost float,
closeCost float,
adjCloseCost float,
volume int
)

create table company
(
id int IDENTITY(1,1) PRIMARY KEY,
company varchar(4) 
)

insert into company values ('AAPL')
insert into company values ('GOOG')
insert into company values ('MSFT')
insert into company values ('SPY')