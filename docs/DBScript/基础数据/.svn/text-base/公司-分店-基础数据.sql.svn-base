--select * from customer_type
--select * from company
--select * from employee
--select * from position
--select * from BRANCH_SHOP
--update BRANCH_SHOP set company_id=1

--初始化公司信息 
delete from company
insert COMPANY
select 1,'西安兰克','',getdate(),1,getdate(),1,1,0
update id_generator set current_value=2 where flag_no='company'

--初始化分店信息 
delete from BRANCH_SHOP
insert BRANCH_SHOP
select 1,1,'高新店','',getdate(),1,getdate(),1,1,0
union
select 2,1,'建大店','',getdate(),1,getdate(),1,1,0
union
select 3,1,'经开店','',getdate(),1,getdate(),1,1,0

update id_generator set current_value=4 where flag_no='BRANCH_SHOP'

--岗位信息 与程序的常量中职位定义一致
delete from position
insert POSITION
select 1,'前台接待','',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'前期','',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'后加工','',getdate(),1,getdate(),1,1,0,1,1
union
select 4,'收银','',getdate(),1,getdate(),1,1,0,1,1
union 
insert POSITION
select 5,'店长','',getdate(),1,getdate(),1,1,0,1,1
union
select 6,'经理','',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=7 where flag_no='POSITION'

--雇员
delete from employee
insert employee
select 1,'001','尤玉佳',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'002','王窈窕',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'003','胡伟',getdate(),1,getdate(),1,1,0,1,1
union
select 4,'004','刘晓波',getdate(),1,getdate(),1,1,0,1,1
union
select 5,'005','张三',getdate(),1,getdate(),1,1,0,1,1
union
select 6,'006','李四',getdate(),1,getdate(),1,1,0,1,1
union
select 7,'008','王五',getdate(),1,getdate(),1,1,0,1,1
union
select 8,'008','陈九',getdate(),1,getdate(),1,1,0,1,1

update id_generator set current_value=9 where flag_no='employee'


--角色
delete from [role]
insert [role]
select 1,'管理员',getdate(),1,getdate(),1,1,0,1,1
union 
select 2,'前台操作员',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'收银操作员',getdate(),1,getdate(),1,1,0,1,1
union
select 4,'店长',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=5 where flag_no='role'

--select * from EMPLOYEE_POSITION
--雇员岗位
delete from EMPLOYEE_POSITION
insert EMPLOYEE_POSITION
select 1,1,1
union
select 2,2,2
union 
select 3,3,3
union
select 4,4,4 
union
select 5,5,2
union
select 6,6,2
union
select 7,7,3
union
select 8,8,3

update id_generator set current_value=9 where flag_no='EMPLOYEE_POSITION'

select * from users
--用户
delete from USER_ROLE
delete from users
insert users
select 1,1,'admin','e10adc3949ba59abbe56e057f20f883e',getdate(),1,getdate(),1,'N',1,0,1,1 --password:123456
update id_generator set current_value=2 where flag_no='users'

--用户角色
insert USER_ROLE
select 1,1,1
update id_generator set current_value=2 where flag_no='user_role'

--select * from USER_CONCESSION_RANGE
--用户优惠范围
insert USER_CONCESSION_RANGE
select 1,1,1,0,10,getdate(),1,getdate(),1,1,'0',1,1,''
union
select 2,1,2,0,100,getdate(),1,getdate(),1,1,'0',1,1,''
union
select 3,1,3,0,100,getdate(),1,getdate(),1,1,'0',1,1,''
update id_generator set current_value=4 where flag_no='USER_CONCESSION_RANGE'



--挂失方式

delete from REPORT_LESS_MODE
insert REPORT_LESS_MODE
select 1,'01','来店挂失',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'02','电话挂失',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=3 where flag_no='REPORT_LESS_MODE'


--废张原因
delete from TRASH_REASON
insert TRASH_REASON
select 1,'机器故障','',getdate(),1,getdate(),1,1,0,1,1
union 
select 2,'人为疏忽','',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'新员工','',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=4 where flag_no='TRASH_REASON'


--客户类型
DELETE FROM customer_type
insert customer_type
select 1,'001','图文',1,getdate(),1,getdate(),1,1,0,1,1
union 
select 2,'002','印艺',2,getdate(),1,getdate(),1,1,0,1,1
union
select 3,'003','商务',3,getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=4 where flag_no='customer_type'

--select * from customer_type
--客户级别
DELETE FROM customer_level
insert customer_level
select 1,'01','普通客户',1,getdate(),1,getdate(),1,0,1,1,1
union
select 2,'02','普卡客户',2,getdate(),1,getdate(),1,0,1,1,1
union
select 3,'03','金卡客户',3,getdate(),1,getdate(),1,0,1,1,1
update id_generator set current_value=4 where flag_no='customer_level'


--select * from MASTER_TRADE
--行业
DELETE FROM MASTER_TRADE
insert MASTER_TRADE
select 0,'00','默认',getdate(),1,getdate(),1,1,0,1,1
union 
select 1,'01','图文',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'02','印艺',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'03','商务',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=4 where flag_no='MASTER_TRADE'

--子行业
DELETE FROM SECONDARY_TRADE
insert SECONDARY_TRADE
select 0,0,'00','默认',getdate(),1,getdate(),1,1,0,1,1
union
select 1,1,'01','图文',getdate(),1,getdate(),1,1,0,1,1
union
select 2,2,'02','印艺',getdate(),1,getdate(),1,1,0,1,1
union
select 3,3,'03','商务',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=4 where flag_no='SECONDARY_TRADE'

