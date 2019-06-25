create table User_Salary (UserName nvarchar(200), Month datetime, Salary int)

go

insert into User_Salary (UserName,Month,Salary ) values('AAA','2010-12-01',1000)
insert into User_Salary (UserName,Month,Salary ) values('AAA','2011-01-01',2000)
insert into User_Salary (UserName,Month,Salary ) values('AAA','2011-02-01',3000)
insert into User_Salary (UserName,Month,Salary ) values('BBB','2010-12-01',2000)
insert into User_Salary (UserName,Month,Salary ) values('BBB','2011-01-01',2500)
insert into User_Salary (UserName,Month,Salary ) values('BBB','2011-02-01',2500)

select * from User_Salary


select sum(salary),MONTH(User_Salary.month)  from User_Salary group by MONTH(User_Salary.month)

go

select UserName,Month,Salary,
	Cummulation=(
		select SUM(Salary) 
		from 
			User_Salary i
		 where i.UserName=o.UserName and i.Month<=o.Month)
from User_Salary o
order by 1,2

select 
	A.UserName,A.Month,MAX(A.Salary) as Salary,SUM (B.Salary) as Accumulation 
from 
	User_Salary A
inner join 
	User_Salary B
ON 
	A.UserName = B.UserName 
where 
	B.Month <= A.Month 
group by
	A.UserName,A.Month
order by	
	A.UserName,A.Month
go



drop table User_Salary
