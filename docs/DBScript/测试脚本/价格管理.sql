--业务类型
select * from BUSINESS_TYPE

--价格因素
select * from PRICE_FACTOR

--业务类型包含的价格因素
select * from BUSINESS_TYPE_PRICE_FACTOR


--因素之间的依赖关系
select * from FACTOR_RELATION

--因素值
select * from FACTOR_VALUE

--因素之间的依赖关系的值
select * from FACTOR_RELATION_VALUES

--业务类型下价格因素一览
select 
t1.ID,
t1.BUSINESS_TYPE_ID,
t2.name as BUSINESS_TYPE_NAME,
t1.BUSINESS_TYPE_ID,
t3.name as PRICE_FACTOR_NAME
from BUSINESS_TYPE_PRICE_FACTOR t1
left join BUSINESS_TYPE t2 
on t1.BUSINESS_TYPE_ID=t2.id
left join PRICE_FACTOR t3
on t1.PRICE_FACTOR_ID=t3.id

select * from BUSINESS_TYPE where id>99

delete from BUSINESS_TYPE_PRICE_FACTOR where id>99
delete from BUSINESS_TYPE where id>99
