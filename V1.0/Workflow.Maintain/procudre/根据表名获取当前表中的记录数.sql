/*
	名	  称 : pro_GetRowCountByTableName
	功能概要 : 根据表名称获取当前记录数
	作    者 ：张晓林
	创建时间 : 2009年6月9日10:52:08
	修正履历 :
	修正时间 :
*/

IF OBJECT_ID ( 'pro_GetRowCountByTableName', 'P' ) IS NOT NULL 
    DROP PROCEDURE pro_GetRowCountByTableName;
GO

create proc [dbo].[pro_GetRowCountByTableName]
@tableName varchar(200)
as
declare @sql varchar(200)
set @sql='select isnull(max(id),0) from '+@tableName
--set @sql='select name,+(select isnull(max(id),0) from '+@tableName+') from sysobjects where xtype=''U'''
execute (@sql)

--exec pro_GetRowCountByTableName 'orders'