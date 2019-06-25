create database test
go
use test
go
create table info
(
	id int
)
insert into info values(1)
insert into info values(2)
insert into info values(3)
insert into info values(4)
insert into info values(5)
insert into info values(6)
insert into info values(7)
insert into info values(8)
insert into info values(9)

select * from info 


use master
go
drop database test
