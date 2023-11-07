using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support.Exception;
using Spring.Transaction.Interceptor;
using Spring.Transaction;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ID_GENERATOR 对应的Dao 实现
	/// </summary>
    public class IdGeneratorDaoImpl : Workflow.Da.Base.DaoBaseImpl<IdGenerator>, IIdGeneratorDao
    {

        #region IIdGeneratorDao 成员

        //[Transaction(TransactionPropagation.RequiresNew)]
        public IdGenerator NextId(long branchShopId, string flagno, int size)
        {
            IdGenerator generator = new IdGenerator();
            generator.FlagNo = flagno;
            generator.Size = size;
            generator.BranchShopId = branchShopId;
            try
            {
                IdGenerator resultGenerator = (IdGenerator)sqlMap.QueryForObject("IdGenerator.SelectCurrentIdGenerator", generator);
                sqlMap.Update("IdGenerator.UpdateCurrentValuePlusSize", generator);
                return resultGenerator;
            }
            catch (Exception err)
            {
                WorkflowException exception = new WorkflowException("产生ID的时候发生错误。", err);
                throw exception;
            }
        }

        #endregion

        /// <summary>
        /// 名   称:  SearchIdGenerator
        /// 功能概要: 获取Id数据列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日10:42:26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<IdGenerator> SearchIdGenerator(IdGenerator idGenerator) 
        {
            idGenerator.Memo = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId.ToString();
            idGenerator.FlagNo = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString();
            return sqlMap.QueryForList<IdGenerator>("IdGenerator.SearchIdGenerator", idGenerator);
        }

        /// <summary>
        /// 名   称:  SearchIdGeneratorRowCount
        /// 功能概要: 获取Id数据列表个数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日10:42:26
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchIdGeneratorRowCount(IdGenerator idGenerator) 
        {
            return sqlMap.QueryForObject<long>("IdGenerator.SearchIdGeneratorRowCount", idGenerator);
        }

         /// <summary>
        /// 名   称:  GetAllUserTableName
        /// 功能概要: 获取所有的用户表列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:23:36
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<IdGenerator> GetAllUserTableName()
        {
            return sqlMap.QueryForList<IdGenerator>("IdGenerator.GetAllUserTableName", null);
        }

        /// <summary>
        /// 名   称:  GetRecordRowCountByTableName
        /// 功能概要: 根据表名称获取当前表中的记录数 
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日17:28:30
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long GetRecordRowCountByTableName(string tableName) 
        {
            IdGenerator idGenerator = new IdGenerator();
            //注释原因：有一部分表可能没有Company_Id,deleted,branch_shop_Id字段
            //idGenerator.Id = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //idGenerator.FlagNo = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString();
            idGenerator.Memo = tableName;
            return sqlMap.QueryForObject<long>("IdGenerator.GetRecordRowCountByTableName", idGenerator);
        }

        /// <summary>
        /// 名   称:  DeleteIdGenerator
        /// 功能概要: 删除所有用户Id
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:23:36
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void DeleteIdGenerator() 
        {
            sqlMap.Delete("IdGenerator.DeleteIdGenerator", null);
        }

        /// <summary>
        /// 名   称:  InsertIdGenerator
        /// 功能概要: 插入一个InsertIdGenerator
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月6日13:23:36
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void InsertIdGenerator(IdGenerator idGenerator) 
        {
            sqlMap.Insert("IdGeneratorBase.Insert", idGenerator);
        }
    }
}
