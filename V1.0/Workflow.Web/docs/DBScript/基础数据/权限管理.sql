delete from PERMISSION_GROUP_DETAIL
delete from ROLE_PERMISSION_GROUP
delete from PERMISSION_GROUP
delete from PERMISSION



--Ȩ�����
--select * from PERMISSION
insert PERMISSION
select 1,'����','Y',''
union 
select 2,'ɾ��','Y',''
union
select 3,'�޸�','Y',''
union
select 4,'��ѯ','Y',''
union
select 5,'����','Y',''
union
select 6,'���','Y',''
Update ID_GENERATOR set current_value=7 where Flag_No='PERMISSION'

--Ȩ�������
--select * from PERMISSION_GROUP
insert PERMISSION_GROUP
select 1,'�ֶ������Ա������Ȩ','',1
union
select 2,'�޸ļ۸���Ȩ','',2
union
select 3,'Ĩ����Ȩ','',3
union
select 4,'�Ż���Ȩ','',4
union
select 5,'������Ȩ','',5
union
select 6,'ע���û�','',6
union
select 7,'���չ���','',7
union
select 8,'������ѯ','',8
union 
select 9,'����ȡ��','',9 --
union
select 10,'����','',10
union
select 11,'��ʧ/�ָ�','',11
union
select 12,'ע��','',12
union
select 13,'����','',13
union
select 14,'����','',14
union
select 15,'Ӧ�տ��','',15
union
select 16,'Ԥ�տ��','',16
union
select 17,'ҵ����������','',17
union
select 18,'���м۸�����','',18
union
select 19,'��Ա���۸�����','',19
union
select 20,'��Ա���','',20
union
select 21,'�û����','',21
union 
select 22,'Ӧ�տ��ѯ','',22
union 
select 23,'Ӧ�տʱ��κϼ�','',23
union 
select 24,'�ձ�','',24
union 
select 25,'�±�','',25
union
select 26,'Ԥ�տ��ѯ','',26
union
select 27,'��Ʊ��ȡ','',27
union
select 28,'��Ч����','',28
union
select 29,'��Ч��ѯ','',29
union
select 30,'������Ч�������','',30
union
select 31,'Ա����Чͳ��','',31
union
select 32,'��λһ��','',32
union
select 33,'��λ���','',33
union
select 34,'��ɫһ��','',34
union
select 35,'��ɫ���','',35
union
select 36,'�ͻ�һ��','',36
union
select 37,'��Աһ��','',37
union
select 38,'�û�һ��','',38
union
select 39,'���������ѯ','',39
union
--insert PERMISSION_GROUP
select 40,'Ȩ����һ��','',40
union
select 41,'Ȩ�������','',41
union
select 42,'����һ��','',42
union
select 43,'�������','',43
union
select 44,'����','',44
union 
select 45,'�����ѯ','',45
union 
select 46,'��Աһ��','',46
union 
select 47,'��Ա��ֵ','',47
union
select 48,'��Ա�����ѯ','',48
union
select 49,'��Ա����ͳ��','',49
union
select 50,'��Ա��ֵ��¼','',50
union
select 51,'��Ա�����¼','',51
union
select 52,'��Ա������¼','',52
union
select 53,'��Ա����ͳ��','',53

union
select 54,'Ӫ���һ��','',54
union
select 55,'Ӫ������','',55
union
select 56,'�Żݷ���һ��','',56
union
select 57,'�Żݷ������','',57

Update ID_GENERATOR set current_value=44 where Flag_No='PERMISSION_GROUP'

select * from role
--��ɫȨ�������
select * from ROLE_PERMISSION_GROUP

insert ROLE_PERMISSION_GROUP
select 1,1,1
union
select 2,1,2
union 
select 3,1,3
union 
select 4,1,4
union
select 5,1,5
union
select 6,1,6
union
select 7,1,7
union
select 8,1,8
union
select 10,1,10
union
select 11,1,11
union
select 12,1,12
union
select 13,1,13
union
select 14,1,14
union
select 15,1,15
union
select 16,1,16
union
select 17,1,17
union
select 18,1,18
union
select 19,1,19
union
select 20,1,20
union
select 21,1,21
union
select 22,1,22
union
select 23,1,23
union
select 24,1,24
union
select 25,1,25
union 
select 26,2,7
union
select 27,2,8
union
select 28,2,10
union
select 29,2,11
union
select 30,2,12
union
select 31,2,13
union
select 32,3,14
union
select 33,3,15
union
select 34,3,16
union
select 35,2,22
union
select 36,2,23
union
select 37,2,24
union
select 38,2,25
union 
select 39,1,25
union
select 40,1,26
union
select 41,2,26
union
select 42,3,27
union
select 43,1,27
union
select 44,1,28
union
select 45,1,29
union
select 46,1,30
union
select 47,1,31
union
select 48,2,28
union
select 49,2,29
union
select 50,2,30
union
select 51,2,31
union
select 52,4,1
union
select 53,4,3
union
select 54,4,4
union
select 55,4,5
union
select 56,4,6
union
select 57,4,7
union
select 58,4,8
union
select 59,4,10
union
select 60,4,11
union
select 61,4,12
union
select 62,4,13
union
select 63,4,14
union
select 64,4,15
union
select 65,4,16
union
select 66,4,20
union
select 67,4,21
union
select 68,4,22
union
select 69,4,23
union
select 70,4,24
union
select 71,4,25
union
select 72,4,26
union
select 73,4,27
union
select 74,4,28
union
select 75,4,29
union
select 76,4,30
union
select 77,4,31
union
select 316,1,32
union
select 317,1,33
union
select 318,4,32
union
select 319,4,33
union
select 82,1,34
union
select 83,1,35
union
select 84,1,36
union
select 85,4,34
union
select 86,4,35
union
select 87,4,36
union
select 88,1,37
union
select 89,1,38
union
select 90,4,37
union
select 91,4,38
union
select 131,1,40
union
select 132,1,41
union
select 133,1,42
union
select 134,1,43
--union
insert ROLE_PERMISSION_GROUP
select 165,2,36
Update ID_GENERATOR set current_value=320 where Flag_No='ROLE_PERMISSION_GROUP'

--Ȩ���������ϸ
--select * from PERMISSION_GROUP_DETAIL
insert PERMISSION_GROUP_DETAIL
select 1,5,1
union
select 2,5,2
union
select 3,5,3
union
select 4,5,4
union
select 5,5,5
union
select 6,6,6
union
select 7,6,7
union
select 8,6,8
union
select 9,5,9
union
select 10,5,10
union
select 11,5,11
union
select 12,5,12
union
select 13,5,13
union
select 14,5,14
union
select 15,5,15
union
select 16,5,16
union
select 17,5,17
union
select 18,5,18
union
select 19,5,19
union
select 20,5,20
union
select 21,5,21
union
select 22,5,22
union
select 23,5,23
union
select 24,5,24
union
select 25,5,25
union
select 26,5,26
union
select 27,5,27
union
select 28,5,28
union
select 29,5,29
union
select 30,5,30
union
select 31,5,31
union
select 32,5,32
union
select 33,5,33
union
select 34,5,34
union
select 35,5,35
union
select 36,5,36
union
select 37,5,37
union
select 38,5,38
union
select 39,5,39
union
--insert PERMISSION_GROUP_DETAIL
select 40,5,40
union
select 41,5,40
union
select 42,5,42
union
select 43,5,43

Update ID_GENERATOR set current_value=44 where Flag_No='PERMISSION_GROUP_DETAIL'



--select * from users
--select * from role
--select * from user_role
--select * from employee
--select * from position
--select * from employee_position
--update user_role set role_id=4 where id=5