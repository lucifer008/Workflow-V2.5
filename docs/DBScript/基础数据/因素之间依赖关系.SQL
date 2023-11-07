--SELECT * FROM BUSINESS_TYPE
--select * from price_factor
--select * from [FACTOR_RELATION]
DELETE [FACTOR_RELATION] 
insert [FACTOR_RELATION] 
select 1,1,1,2,'打印：加工内容制约机器',getdate(),1,getdate(),1,1,0,1,1 --PriceFactorId为加工内容Id PriceFactorId2为机器Id
union 
select 2,1,2,3,'打印：机器制约纸质',getdate(),1,getdate(),1,1,0,1,1
union
select 3,1,2,4,'打印：机器制约纸型',getdate(),1,getdate(),1,1,0,1,1
union
select 4,2,1,2,'复印: 加工内容制约机器',getdate(),1,getdate(),1,1,0,1,1 
union
select 5,2,2,3,'复印：机器制约纸质',getdate(),1,getdate(),1,1,0,1,1
union
select 6,2,2,4,'复印：机器制约纸型',getdate(),1,getdate(),1,1,0,1,1
union
select 7,3,1,2,'扫描: 加工内容制约机器',getdate(),1,getdate(),1,1,0,1,1
union
select 8,3,2,3,'扫描: 机器制约纸质',getdate(),1,getdate(),1,1,0,1,1
union
select 9,3,2,4,'扫描: 机器制约纸型',getdate(),1,getdate(),1,1,0,1,1
union
select 10,4,1,2,'喷绘: 加工内容制约机器',getdate(),1,getdate(),1,1,0,1,1
union
select 11,4,2,3,'喷绘: 机器制约纸质',getdate(),1,getdate(),1,1,0,1,1
union
select 12,4,2,4,'喷绘: 机器制约纸型',getdate(),1,getdate(),1,1,0,1,1
union
select 13,5,1,4,'装订: 加工内容制约纸型',getdate(),1,getdate(),1,1,0,1,1
union
select 14,6,1,2,'工程图: 加工内容制约机器',getdate(),1,getdate(),1,1,0,1,1
union
select 15,6,2,3,'工程图: 机器制约纸质',getdate(),1,getdate(),1,1,0,1,1
union
select 16,6,2,4,'工程图: 机器制约纸型',getdate(),1,getdate(),1,1,0,1,1
union
select 17,7,1,4,'其它: 加工内容制约纸型',getdate(),1,getdate(),1,1,0,1,1
Update ID_Generator set current_value=18 where Flag_No='FACTOR_RELATION'


