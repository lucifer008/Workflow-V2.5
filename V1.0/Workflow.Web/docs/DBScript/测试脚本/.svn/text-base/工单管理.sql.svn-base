
--客户信息
select * from CUSTOMER order by id
--联系人
select * from LINK_MAN order by id


--会员卡信息
select * from MEMBER_CARD where insert_date_time between convert(nvarchar(10),getdate(),120) and convert(nvarchar(10),dateadd(day,1,getdate()),120) order by insert_date_time
--会员卡操作记录
select * from MEMBER_OPERATE_LOG  order by insert_date_time
--销卡操作记录
select * from LOGOFF_MEMBER_CARD order by insert_date_time


--工单表
select * from ORDERS order by insert_date_time desc
--工单明细表
select * from ORDER_ITEM order by insert_date_time desc
--工单数值表
select * from ORDER_ITEM_FACTOR_VALUE order by ID desc
--工单成员组
select * from ORDER_ITEM_EMPLOYEE order by ID desc
--工单印制要求
select * from ORDER_ITEM_PRINT_REQUIRE_DETAIL order by ID desc
--印制要求分类
select * from PRINT_DEMAND order by ID desc
--印制要求明细
select * from PRINT_DEMAND_DETAIL order by ID desc
SELECT
ID,
NO,
DELIVERY_TYPE,
DELIVERY_DATE_TIME,
MEMO,
INSERT_DATE_TIME
FROM ORDERS
Where DELETED = '0'
AND insert_date_time between convert(nvarchar(10),getdate(),120) and convert(nvarchar(10),dateadd(day,1,getdate()),120)
ORDER BY insert_date_time DESC

SELECT
ID,
NO,
PREPARE_MONEY_AMOUNT,
MEMO,
INSERT_DATE_TIME
FROM ORDERS
Where DELETED = '0'
AND insert_date_time between convert(nvarchar(10),getdate(),120) and convert(nvarchar(10),dateadd(day,1,getdate()),120)
ORDER BY insert_date_time DESC
