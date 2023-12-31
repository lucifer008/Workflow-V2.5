
--抄表
select * from RECORD_MACHINE_WATCH
select * from MACHINE_WATCH_RECORD_LOG
select * from UNCOMPLETE_ORDERS_USED_PAPER

/*
delete from MACHINE_WATCH_RECORD_LOG
delete from UNCOMPLETE_ORDERS_USED_PAPER
delete from RECORD_MACHINE_WATCH
*/

--抄表核对,补单人员一览,补单用纸量
select * from COMPENSATE_EMPLOYEE
select * from COMPENSATE_USED_PAPER
select isnull(SUM(USED_PAPER_COUNT),0) as amount from COMPENSATE_USED_PAPER WHERE 1=1
/*
delete from COMPENSATE_EMPLOYEE
delete from COMPENSATE_USED_PAPER
*/

--计数器换算纸张
select * from MACHINE_WATCH_CONVERSION_PAPER
--计数器抄表的最后刻度数
select * from MACHINE_WATCH_SCALE
/*
UPDATE MACHINE_WATCH_SCALE SET LASTEST_NUMBER=0
*/

			SELECT top 1
			T1.ID, T1.PAPER_SPECIFICATION_ID, T1.MACHINE_TYPE_ID, T1.NAME, 
			T1.COMPUTE_FORMULA, T1.COLOR_TYPE,T3.ID AS MACHINE_ID,T3.NAME AS MACHINE_NAME
			FROM MACHINE_WATCH_CONVERSION_PAPER T1 
			INNER JOIN MACHINE_TYPE T2
			ON T1.MACHINE_TYPE_ID=T2.ID
			INNER JOIN MACHINE T3
			ON T2.ID=T3.MACHINE_TYPE_ID
			ORDER BY T1.MACHINE_TYPE_ID,T3.ID


--抄表记录
select * from DAILY_RECORD_MACHINE
/*
delete from DAILY_RECORD_MACHINE
*/

			SELECT
			MACHINE_ID, PAPER_SPECIFICATION_ID, COLOR_TYPE, SUM(IN_WATCH_COUNT) AS IN_WATCH_COUNT
			FROM DAILY_RECORD_MACHINE
			WHERE MACHINE_ID=1002
			GROUP BY MACHINE_ID,PAPER_SPECIFICATION_ID,COLOR_TYPE


exec sp_executesql N'SELECT isnull((NEW_NUMBER-LAST_NUMBER),0) as MachineWatchValue     FROM MACHINE_WATCH_RECORD_LOG     WHERE RECORD_MACHINE_WATCH_ID =  @param0      AND MACHINE_ID =  @param1       AND MACHINE_WATCH_ID =  @param2', N'@param0 bigint,@param1 bigint,@param2 bigint', @param0 = 19304, @param1 = 1001, @param2 = 20035


SELECT isnull(max(NEW_NUMBER-LAST_NUMBER),0) as MachineWatchValue     FROM MACHINE_WATCH_RECORD_LOG where machine_id=1001

select *  FROM MACHINE_WATCH_RECORD_LOG 

select ISNULL(SUM(T1.TRASH_PAPERS),0) from REAL_ORDER_ITEM T1
INNER JOIN ORDERS T2
ON T1.ORDERS_ID=T2.ID
WHERE T2.STATUS=5
AND T1.INSERT_DATE_TIME>'2007-12-31'

--计算废张数

SELECT
MACHINE_ID,PAPER_SPECIFICATION_ID,COLOR_TYPE,
isnull(sum(PAPER_COUNT),0) as PAPER_COUNT,isnull(sum(TRASH_PAPERS),0) as TRASH_PAPERS
FROM ORDERS_FOR_RECORD_MACHINE_SUM
WHERE MACHINE_ID=MACHINE_ID
AND PAPER_SPECIFICATION_ID=PAPER_SPECIFICATION_ID
AND COLOR_TYPE=COLOR_TYPE
--AND BALANCE_DATE_TIME >'2007-12-30'
GROUP BY MACHINE_ID,PAPER_SPECIFICATION_ID,COLOR_TYPE


SELECT * FROM UNCOMPLETE_ORDERS_USED_PAPER WHERE RECORD_MACHINE_WATCH_ID=17549 OR RECORD_MACHINE_WATCH_ID=18200

SELECT SUM(USED_PAPER_COUNT) AS USED_PAPER_COUNT FROM UNCOMPLETE_ORDERS_USED_PAPER
WHERE RECORD_MACHINE_WATCH_ID=17549 
OR RECORD_MACHINE_WATCH_ID=18200

--求上次未完工用纸量和本次未完工用纸量
SELECT ISNULL(MAX(COL1),0) AS USED_PAPER_COUNT,ISNULL(MAX(COL2),0) AS LAST_TIME_USED_PAPER_COUNT FROM 
(
SELECT 	CASE WHEN RECORD_MACHINE_WATCH_ID=175491 THEN SUM(USED_PAPER_COUNT) END AS COL1,
	CASE WHEN RECORD_MACHINE_WATCH_ID=182001 THEN SUM(USED_PAPER_COUNT) END AS COL2
FROM UNCOMPLETE_ORDERS_USED_PAPER
WHERE 
(
RECORD_MACHINE_WATCH_ID=175491
and 1=1
and 2=2
)
OR 
(RECORD_MACHINE_WATCH_ID=182001
and 1=1
and 2=2
)
GROUP BY RECORD_MACHINE_WATCH_ID
) T1

select * from UNCOMPLETE_ORDERS_USED_PAPER