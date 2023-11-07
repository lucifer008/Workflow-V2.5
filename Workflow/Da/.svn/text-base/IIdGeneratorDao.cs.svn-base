using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table ID_GENERATOR 对应的Dao 接口
	/// </summary>
    public interface IIdGeneratorDao : IDaoBase<IdGenerator>
    {
        IdGenerator NextId(long branchShopId, string flagno, int size);

        /// <summary>
        /// 名   称:  SearchIdGenerator
        /// 功能概要: 获取Id数据列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日10:42:26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<IdGenerator> SearchIdGenerator(IdGenerator idGenerator);

        /// <summary>
        /// 名   称:  SearchIdGeneratorRowCount
        /// 功能概要: 获取Id数据列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日10:42:26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchIdGeneratorRowCount(IdGenerator idGenerator); 

        /// <summary>
        /// 名   称:  GetAllUserTableName
        /// 功能概要: 获取所有的用户表列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:23:36
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<IdGenerator> GetAllUserTableName(); 

        /// <summary>
        /// 名   称:  GetRecordRowCountByTableName
        /// 功能概要: 根据表名称获取当前表中的记录数 
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日17:28:30
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long GetRecordRowCountByTableName(string tableName); 

        /// <summary>
        /// 名   称:  DeleteIdGenerator
        /// 功能概要: 删除所有用户Id
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:23:36
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void DeleteIdGenerator();

        /// <summary>
        /// 名   称:  InsertIdGenerator
        /// 功能概要: 插入一个InsertIdGenerator
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:23:36
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        void InsertIdGenerator(IdGenerator idGenerator);
    }
}
