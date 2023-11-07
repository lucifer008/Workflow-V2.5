delete from PERMISSION_GROUP_DETAIL
delete from ROLE_PERMISSION_GROUP
delete from PERMISSION_GROUP
delete from PERMISSION



--权限许可
--select * from PERMISSION
insert PERMISSION
select 1,'增加','Y',''
union 
select 2,'删除','Y',''
union
select 3,'修改','Y',''
union
select 4,'查询','Y',''
union
select 5,'操作','Y',''
union
select 6,'浏览','Y',''
Update ID_GENERATOR set current_value=7 where Flag_No='PERMISSION'

--权限许可组
--select * from PERMISSION_GROUP
insert PERMISSION_GROUP
select 1,'手动输入会员卡号授权','',1
union
select 2,'修改价格授权','',2
union
select 3,'抹零授权','',3
union
select 4,'优惠授权','',4
union
select 5,'挂账授权','',5
union
select 6,'注销用户','',6
union
select 7,'本日工单','',7
union
select 8,'工单查询','',8
union 
select 9,'上门取活','',9 --
union
select 10,'发卡','',10
union
select 11,'挂失/恢复','',11
union
select 12,'注销','',12
union
select 13,'补卡','',13
union
select 14,'收银','',14
union
select 15,'应收款处理','',15
union
select 16,'预收款处理','',16
union
select 17,'业务类型设置','',17
union
select 18,'门市价格设置','',18
union
select 19,'会员卡价格设置','',19
union
select 20,'雇员添加','',20
union
select 21,'用户添加','',21
union 
select 22,'应收款查询','',22
union 
select 23,'应收款按时间段合计','',23
union 
select 24,'日报','',24
union 
select 25,'月报','',25
union
select 26,'预收款查询','',26
union
select 27,'发票领取','',27
union
select 28,'绩效调整','',28
union
select 29,'绩效查询','',29
union
select 30,'工单绩效分配情况','',30
union
select 31,'员工绩效统计','',31
union
select 32,'岗位一览','',32
union
select 33,'岗位添加','',33
union
select 34,'角色一览','',34
union
select 35,'角色添加','',35
union
select 36,'客户一览','',36
union
select 37,'雇员一览','',37
union
select 38,'用户一览','',38
union
select 39,'收银当班查询','',39
union
--insert PERMISSION_GROUP
select 40,'权限组一览','',40
union
select 41,'权限组添加','',41
union
select 42,'操作一览','',42
union
select 43,'操作添加','',43
union
select 44,'交班','',44
union 
select 45,'交班查询','',45
union 
select 46,'会员一览','',46
union 
select 47,'会员充值','',47
union
select 48,'会员详情查询','',48
union
select 49,'会员消费统计','',49
union
select 50,'会员充值记录','',50
union
select 51,'会员管理记录','',51
union
select 52,'会员换卡记录','',52
union
select 53,'会员消费统计','',53

union
select 54,'营销活动一览','',54
union
select 55,'营销活动添加','',55
union
select 56,'优惠方案一览','',56
union
select 57,'优惠方案添加','',57

Update ID_GENERATOR set current_value=44 where Flag_No='PERMISSION_GROUP'

select * from role
--角色权限许可组
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

--权限许可组明细
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