--select * from customer_type
--select * from company
--select * from employee
--select * from position
--select * from BRANCH_SHOP
--update BRANCH_SHOP set company_id=1

--��ʼ����˾��Ϣ 
delete from company
insert COMPANY
select 1,'��������','',getdate(),1,getdate(),1,1,0
update id_generator set current_value=2 where flag_no='company'

--��ʼ���ֵ���Ϣ 
delete from BRANCH_SHOP
insert BRANCH_SHOP
select 1,1,'���µ�','',getdate(),1,getdate(),1,1,0
union
select 2,1,'�����','',getdate(),1,getdate(),1,1,0
union
select 3,1,'������','',getdate(),1,getdate(),1,1,0

update id_generator set current_value=4 where flag_no='BRANCH_SHOP'

--��λ��Ϣ �����ĳ�����ְλ����һ��
delete from position
insert POSITION
select 1,'ǰ̨�Ӵ�','',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'ǰ��','',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'��ӹ�','',getdate(),1,getdate(),1,1,0,1,1
union
select 4,'����','',getdate(),1,getdate(),1,1,0,1,1
union 
insert POSITION
select 5,'�곤','',getdate(),1,getdate(),1,1,0,1,1
union
select 6,'����','',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=7 where flag_no='POSITION'

--��Ա
delete from employee
insert employee
select 1,'001','�����',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'002','����',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'003','��ΰ',getdate(),1,getdate(),1,1,0,1,1
union
select 4,'004','������',getdate(),1,getdate(),1,1,0,1,1
union
select 5,'005','����',getdate(),1,getdate(),1,1,0,1,1
union
select 6,'006','����',getdate(),1,getdate(),1,1,0,1,1
union
select 7,'008','����',getdate(),1,getdate(),1,1,0,1,1
union
select 8,'008','�¾�',getdate(),1,getdate(),1,1,0,1,1

update id_generator set current_value=9 where flag_no='employee'


--��ɫ
delete from [role]
insert [role]
select 1,'����Ա',getdate(),1,getdate(),1,1,0,1,1
union 
select 2,'ǰ̨����Ա',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'��������Ա',getdate(),1,getdate(),1,1,0,1,1
union
select 4,'�곤',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=5 where flag_no='role'

--select * from EMPLOYEE_POSITION
--��Ա��λ
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
--�û�
delete from USER_ROLE
delete from users
insert users
select 1,1,'admin','e10adc3949ba59abbe56e057f20f883e',getdate(),1,getdate(),1,'N',1,0,1,1 --password:123456
update id_generator set current_value=2 where flag_no='users'

--�û���ɫ
insert USER_ROLE
select 1,1,1
update id_generator set current_value=2 where flag_no='user_role'

--select * from USER_CONCESSION_RANGE
--�û��Żݷ�Χ
insert USER_CONCESSION_RANGE
select 1,1,1,0,10,getdate(),1,getdate(),1,1,'0',1,1,''
union
select 2,1,2,0,100,getdate(),1,getdate(),1,1,'0',1,1,''
union
select 3,1,3,0,100,getdate(),1,getdate(),1,1,'0',1,1,''
update id_generator set current_value=4 where flag_no='USER_CONCESSION_RANGE'



--��ʧ��ʽ

delete from REPORT_LESS_MODE
insert REPORT_LESS_MODE
select 1,'01','�����ʧ',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'02','�绰��ʧ',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=3 where flag_no='REPORT_LESS_MODE'


--����ԭ��
delete from TRASH_REASON
insert TRASH_REASON
select 1,'��������','',getdate(),1,getdate(),1,1,0,1,1
union 
select 2,'��Ϊ���','',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'��Ա��','',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=4 where flag_no='TRASH_REASON'


--�ͻ�����
DELETE FROM customer_type
insert customer_type
select 1,'001','ͼ��',1,getdate(),1,getdate(),1,1,0,1,1
union 
select 2,'002','ӡ��',2,getdate(),1,getdate(),1,1,0,1,1
union
select 3,'003','����',3,getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=4 where flag_no='customer_type'

--select * from customer_type
--�ͻ�����
DELETE FROM customer_level
insert customer_level
select 1,'01','��ͨ�ͻ�',1,getdate(),1,getdate(),1,0,1,1,1
union
select 2,'02','�տ��ͻ�',2,getdate(),1,getdate(),1,0,1,1,1
union
select 3,'03','�𿨿ͻ�',3,getdate(),1,getdate(),1,0,1,1,1
update id_generator set current_value=4 where flag_no='customer_level'


--select * from MASTER_TRADE
--��ҵ
DELETE FROM MASTER_TRADE
insert MASTER_TRADE
select 0,'00','Ĭ��',getdate(),1,getdate(),1,1,0,1,1
union 
select 1,'01','ͼ��',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'02','ӡ��',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'03','����',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=4 where flag_no='MASTER_TRADE'

--����ҵ
DELETE FROM SECONDARY_TRADE
insert SECONDARY_TRADE
select 0,0,'00','Ĭ��',getdate(),1,getdate(),1,1,0,1,1
union
select 1,1,'01','ͼ��',getdate(),1,getdate(),1,1,0,1,1
union
select 2,2,'02','ӡ��',getdate(),1,getdate(),1,1,0,1,1
union
select 3,3,'03','����',getdate(),1,getdate(),1,1,0,1,1
update id_generator set current_value=4 where flag_no='SECONDARY_TRADE'

