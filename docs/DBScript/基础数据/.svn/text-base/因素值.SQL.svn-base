--select * from [FACTOR_VALUE] 
DELETE [FACTOR_VALUE] 
INSERT [FACTOR_VALUE]
select 1,5,'01','要',1,getdate(),1,getdate(),1,1,'0',1,1
union
select 2,5,'02','不要',2,getdate(),1,getdate(),1,1,'0',1,1
union
select 3,5,'03','无关',3,getdate(),1,getdate(),1,1,'0',1,1
union
select 4,6,'01','是',1,getdate(),1,getdate(),1,1,'0',1,1
union
select 5,6,'02','不是',2,getdate(),1,getdate(),1,1,'0',1,1
--union
--select 6,7,'01','1-50',1,getdate(),1,getdate(),1,1,'0',1,1
--union
--select 7,7,'02','51-10000',2,getdate(),1,getdate(),1,1,'0',1,1
--union
--select 8,7,'03','1-20',3,getdate(),1,getdate(),1,1,'0',1,1
--union
--select 9,7,'04','21-10000',4,getdate(),1,getdate(),1,1,'0',1,1
--union
--select 10,7,'05','1-10000',5,getdate(),1,getdate(),1,1,'0',1,1

Update ID_Generator set current_value=6 where Flag_No='FACTOR_VALUE'

insert AMOUNT_SEGMENT
select 1,'01','1-50',getdate(),1,getdate(),1,1,'0',1,1
union
select 2,'02','51-10000',getdate(),1,getdate(),1,1,'0',1,1
union
select 3,'03','1-20',getdate(),1,getdate(),1,1,'0',1,1
union
select 4,'04','21-10000',getdate(),1,getdate(),1,1,'0',1,1
union
select 5,'05','1-10000',getdate(),1,getdate(),1,1,'0',1,1
union
select 6,'06','1-10',getdate(),1,getdate(),1,1,'0',1,1
union
select 7,'07','11-10000',getdate(),1,getdate(),1,1,'0',1,1

Update ID_Generator set current_value=8 where Flag_No='AMOUNT_SEGMENT'
