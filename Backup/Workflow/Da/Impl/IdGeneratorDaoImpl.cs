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
	/// Table ID_GENERATOR ��Ӧ��Dao ʵ��
	/// </summary>
    public class IdGeneratorDaoImpl : Workflow.Da.Base.DaoBaseImpl<IdGenerator>, IIdGeneratorDao
    {

        #region IIdGeneratorDao ��Ա

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
                WorkflowException exception = new WorkflowException("����ID��ʱ��������", err);
                throw exception;
            }
        }

        #endregion

        /// <summary>
        /// ��   ��:  SearchIdGenerator
        /// ���ܸ�Ҫ: ��ȡId�����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��10:42:26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<IdGenerator> SearchIdGenerator(IdGenerator idGenerator) 
        {
            idGenerator.Memo = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId.ToString();
            idGenerator.FlagNo = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString();
            return sqlMap.QueryForList<IdGenerator>("IdGenerator.SearchIdGenerator", idGenerator);
        }

        /// <summary>
        /// ��   ��:  SearchIdGeneratorRowCount
        /// ���ܸ�Ҫ: ��ȡId�����б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��10:42:26
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchIdGeneratorRowCount(IdGenerator idGenerator) 
        {
            return sqlMap.QueryForObject<long>("IdGenerator.SearchIdGeneratorRowCount", idGenerator);
        }

         /// <summary>
        /// ��   ��:  GetAllUserTableName
        /// ���ܸ�Ҫ: ��ȡ���е��û����б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��13:23:36
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<IdGenerator> GetAllUserTableName()
        {
            return sqlMap.QueryForList<IdGenerator>("IdGenerator.GetAllUserTableName", null);
        }

        /// <summary>
        /// ��   ��:  GetRecordRowCountByTableName
        /// ���ܸ�Ҫ: ���ݱ����ƻ�ȡ��ǰ���еļ�¼�� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��17:28:30
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long GetRecordRowCountByTableName(string tableName) 
        {
            IdGenerator idGenerator = new IdGenerator();
            //ע��ԭ����һ���ֱ����û��Company_Id,deleted,branch_shop_Id�ֶ�
            //idGenerator.Id = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //idGenerator.FlagNo = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId.ToString();
            idGenerator.Memo = tableName;
            return sqlMap.QueryForObject<long>("IdGenerator.GetRecordRowCountByTableName", idGenerator);
        }

        /// <summary>
        /// ��   ��:  DeleteIdGenerator
        /// ���ܸ�Ҫ: ɾ�������û�Id
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��13:23:36
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void DeleteIdGenerator() 
        {
            sqlMap.Delete("IdGenerator.DeleteIdGenerator", null);
        }

        /// <summary>
        /// ��   ��:  InsertIdGenerator
        /// ���ܸ�Ҫ: ����һ��InsertIdGenerator
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��6��13:23:36
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void InsertIdGenerator(IdGenerator idGenerator) 
        {
            sqlMap.Insert("IdGeneratorBase.Insert", idGenerator);
        }
    }
}
