
--取得欠款笔数/欠款金额(收银交班)
select 
isnull(sum(REAL_PAID_AMOUNT-PAID_AMOUNT),0) as DEBT_AMOUNT_SUM,
count(*) as DEBT_COUNT from orders 
where REAL_PAID_AMOUNT-PAID_AMOUNT>0

--取得记帐笔数/记帐金额(收银交班)
select isnull(sum(PAID_AMOUNT),0) as KEEP_BUSINESS_RECORD_AMOUNT_SUM,
count(*) as KEEP_BUSINESS_RECORD_COUNT from orders
where PAY_TYPE=2
and PAID_AMOUNT>0

--取得结款笔数/结款金额(收银交班)
select isnull(sum(AMOUNT),0) as PAY_FOR_AMOUNT_SUM,
count(*) as PAY_FOR_COUNT
from GATHERING
where DELETED='0'

--取得发票笔数/发票金额(收银交班)
select  isnull(sum(REAL_PAID_AMOUNT),0) as TICKET_AMOUNT_SUM from orders
where NEED_TICKET='Y'


