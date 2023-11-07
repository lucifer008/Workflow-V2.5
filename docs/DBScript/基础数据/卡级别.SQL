delete from member_card
delete from link_man
delete from customer
insert Customer
select 1,1,2,0,'散客','XTMR','','','',0,'',0,1,getdate(),1,getdate(),1,1,'N',1,1,0
union
select 2,1,3,0,'学生','XTMR','','','',0,'',0,1,getdate(),1,getdate(),1,1,'N',1,1,0
Update ID_Generator set current_value=3 where Flag_No='Customer'

DELETE [MEMBER_CARD_LEVEL]
INSERT [MEMBER_CARD_LEVEL] ([ID],[NO],[NAME],[INSERT_DATE_TIME],[INSERT_USER],[UPDATE_DATE_TIME],[UPDATE_USER],[VERSION],[DELETED],[COMPANY_ID],[BRANCH_SHOP_ID]) VALUES ( 0,'0','默认',getdate(),1,getdate(),1,1,'0',1,1)
INSERT [MEMBER_CARD_LEVEL] ([ID],[NO],[NAME],[INSERT_DATE_TIME],[INSERT_USER],[UPDATE_DATE_TIME],[UPDATE_USER],[VERSION],[DELETED],[COMPANY_ID],[BRANCH_SHOP_ID]) VALUES ( 1,'1','普卡',getdate(),1,getdate(),1,1,'0',1,1)
INSERT [MEMBER_CARD_LEVEL] ([ID],[NO],[NAME],[INSERT_DATE_TIME],[INSERT_USER],[UPDATE_DATE_TIME],[UPDATE_USER],[VERSION],[DELETED],[COMPANY_ID],[BRANCH_SHOP_ID]) VALUES ( 2,'2','金卡',getdate(),1,getdate(),1,1,'0',1,1)

Update ID_Generator set current_value=3 where Flag_No='MEMBER_CARD_LEVEL'


insert member_card
select 1,1,0,'M000001','散客卡',0,'','','','',0,1,'','',getdate(),dateadd(year,3,getdate()),'N',0,0,getdate(),1,getdate(),1,1,0,1,1
union
select 2,2,0,'M000002','学生卡',0,'','','','',0,1,'','',getdate(),dateadd(year,3,getdate()),'N',0,0,getdate(),1,getdate(),1,1,0,1,1

Update ID_Generator set current_value=3 where Flag_No='member_card'
--
--
--select * from [MEMBER_CARD_LEVEL]
--select * from customer_Level
--select * from customer_Type
--select * from secondary_trade
--select * from member_card
--select * from [MEMBER_CARD_LEVEL]

--update customer_level set deleted=0 ,version=1


