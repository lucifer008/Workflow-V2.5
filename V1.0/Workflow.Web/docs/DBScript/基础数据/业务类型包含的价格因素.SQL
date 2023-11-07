--select * from business_type
--select * from price_factor
--select * from [BUSINESS_TYPE_PRICE_FACTOR] 
delete [BUSINESS_TYPE_PRICE_FACTOR] 
INSERT [BUSINESS_TYPE_PRICE_FACTOR] 
--打印的价格因素
select 1,1,1,1
union
select 2,2,1,2
union
select 3,3,1,3
union
select 4,4,1,4
union
select 5,5,1,5
--复印的价格因素
union
select 6,1,2,1
union
select 7,2,2,2
union
select 8,3,2,3
union
select 9,4,2,4
--扫描的价格因素
union
select 10,1,3,1
union
select 11,2,3,2
union
select 12,3,3,3
union
select 13,4,3,4
union
select 14,5,3,5
--喷绘的价格因素
union
select 15,1,4,1
union
select 16,2,4,2
union
select 17,3,4,3
union
select 18,4,4,4
union
select 19,5,4,5
--装订的价格因素
union
select 20,1,5,1
union
select 21,4,5,2
union
select 22,5,5,3
--union
--select 23,7,5,4
--工程图的价格因素
union
select 24,1,6,1
union
select 25,2,6,2
union
select 26,3,6,3
union
select 27,4,6,4
--其他的价格因素
union
select 28,1,7,1
union
select 29,4,7,2


Update ID_Generator set current_value=30 where Flag_No='BUSINESS_TYPE_PRICE_FACTOR'


--select * from business_type_price_factor where business_type_id=1



select * from FACTOR_VALUE