
--select * from [BUSINESS_TYPE] 
DELETE [PROCESS_CONTENT]
DELETE [BUSINESS_TYPE]
INSERT [BUSINESS_TYPE] 
select 1,'打印','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 2,'复印','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 3,'扫描','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 4,'喷绘','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 5,'装订','N',getdate(),1,getdate(),1,1,0,1,1
union
select 6,'工程图','Y',getdate(),1,getdate(),1,1,0,1,1
union
select 7,'其它','N',getdate(),1,getdate(),1,1,0,1,1

Update ID_Generator set current_value=8 where Flag_No='BUSINESS_TYPE'



--select * from [PROCESS_CONTENT] 
 
insert [PROCESS_CONTENT] 
select 1,1,'001','黑白打印',1,getdate(),1,getdate(),1,1,0,1,1
union
select 2,1,'002','彩色打印',2,getdate(),1,getdate(),1,1,0,1,1
union
select 3,2,'003','黑白复印',1,getdate(),1,getdate(),1,1,0,1,1
union
select 4,2,'004','彩色复印',2,getdate(),1,getdate(),1,1,0,1,1
union
select 5,3,'005','黑白扫描',1,getdate(),1,getdate(),1,1,0,1,1
union
select 6,3,'006','彩色扫描',1,getdate(),1,getdate(),1,1,0,1,1
union
select 7,4,'007','效果图',1,getdate(),1,getdate(),1,1,0,1,1
union
select 8,4,'008','彩色线条',1,getdate(),1,getdate(),1,1,0,1,1
union
select 9,5,'009','胶装精装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 10,5,'010','内铁环精装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 11,5,'011','外铁环精装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 12,5,'012','精装蝴蝶装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 13,5,'013','软装蝴蝶装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 14,5,'014','激皮光胶装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 15,5,'015','背皮胶胶装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 16,5,'016','激光覆膜胶装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 17,5,'017','皮纹纸胶装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 18,5,'018','铁环装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 19,5,'019','胶圈装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 20,5,'020','夹条装',1,getdate(),1,getdate(),1,1,0,1,1
union
select 21,5,'021','骑马订',1,getdate(),1,getdate(),1,1,0,1,1
union
select 22,6,'022','黑白线条打印复印',1,getdate(),1,getdate(),1,1,0,1,1
union
select 23,6,'023','黑白色块打印/复印',1,getdate(),1,getdate(),1,1,0,1,1
union
select 24,6,'024','晒图',1,getdate(),1,getdate(),1,1,0,1,1
union
select 25,7,'025','刻光盘',1,getdate(),1,getdate(),1,1,0,1,1
union
select 26,7,'026','折图',1,getdate(),1,getdate(),1,1,0,1,1
union
select 27,7,'027','拼版',1,getdate(),1,getdate(),1,1,0,1,1
union
select 28,7,'028','单面名片',1,getdate(),1,getdate(),1,1,0,1,1
union
select 29,7,'029','双面名片',1,getdate(),1,getdate(),1,1,0,1,1
union
select 30,7,'030','裱白卡',1,getdate(),1,getdate(),1,1,0,1,1
union
select 31,7,'031','裱板',1,getdate(),1,getdate(),1,1,0,1,1
union
select 32,7,'032','其它',1,getdate(),1,getdate(),1,1,0,1,1
union
select 33,5,'033','胶装',1,getdate(),1,getdate(),1,1,0,1,1

Update ID_Generator set current_value=34 where Flag_No='PROCESS_CONTENT'
