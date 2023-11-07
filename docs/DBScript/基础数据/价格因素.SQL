--select * from price_factor
DELETE [PRICE_FACTOR] 
INSERT [PRICE_FACTOR] 
select 1,'加工内容','加工内容','PROCESS_CONTENT','ID','NAME','Y','Y',1,getdate(),1,getdate(),1,1,'0',1,1
union
select 2,'机器型号','机器','MACHINE_TYPE','ID','NAME','Y','Y',2,getdate(),1,getdate(),1,1,'0',1,1
union
select 3,'纸质','纸质','PAPER_TYPE','ID','NAME','Y','Y',3,getdate(),1,getdate(),1,1,'0',1,1
union
select 4,'纸型','规格','PAPER_SPECIFICATION','ID','NAME','Y','Y',4,getdate(),1,getdate(),1,1,'0',1,1
union
select 5,'发票','发票','FACTOR_VALUE','VALUE','TEXT','Y','Y',5,getdate(),1,getdate(),1,1,'0',1,1
union
select 6,'会员','会员','FACTOR_VALUE','VALUE','TEXT','Y','Y',6,getdate(),1,getdate(),1,1,'0',1,1
union
select 7,'数量区间','数量','AMOUNT_SEGMENT','ID','NAME','Y','N',7,getdate(),1,getdate(),1,1,'0',1,1
Update ID_Generator set current_value=8 where Flag_No='PRICE_FACTOR'


