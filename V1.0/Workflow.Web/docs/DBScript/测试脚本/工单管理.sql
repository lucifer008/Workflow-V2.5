
--�ͻ���Ϣ
select * from CUSTOMER order by id
--��ϵ��
select * from LINK_MAN order by id


--��Ա����Ϣ
select * from MEMBER_CARD where insert_date_time between convert(nvarchar(10),getdate(),120) and convert(nvarchar(10),dateadd(day,1,getdate()),120) order by insert_date_time
--��Ա��������¼
select * from MEMBER_OPERATE_LOG  order by insert_date_time
--����������¼
select * from LOGOFF_MEMBER_CARD order by insert_date_time


--������
select * from ORDERS order by insert_date_time desc
--������ϸ��
select * from ORDER_ITEM order by insert_date_time desc
--������ֵ��
select * from ORDER_ITEM_FACTOR_VALUE order by ID desc
--������Ա��
select * from ORDER_ITEM_EMPLOYEE order by ID desc
--����ӡ��Ҫ��
select * from ORDER_ITEM_PRINT_REQUIRE_DETAIL order by ID desc
--ӡ��Ҫ�����
select * from PRINT_DEMAND order by ID desc
--ӡ��Ҫ����ϸ
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
