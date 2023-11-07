using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// ��     ��:FactorRelationValueDaoImpl
    /// ���ܸ�Ҫ:����������ϵֵ�ӿ�ʵ��
    /// ��    ��:
    /// ����ʱ��:
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public class FactorRelationValueDaoImpl : Workflow.Da.Base.DaoBaseImpl<FactorRelationValue>, IFactorRelationValueDao
    {
        /// <summary>
        /// ��    ��: SearchFactorRelationValue
        /// ���ܸ�Ҫ: ��ȡ���������Ĺ�ϵֵ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��11:10:17
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public IList<FactorRelationValue> SearchFactorRelationValue(FactorRelationValue factorRelationValue) 
        {
            factorRelationValue.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelationValue.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<FactorRelationValue>("FactorRelationValue.SearchFactorRelationValue", factorRelationValue);
        }

        /// <summary>
        /// ��    ��: SearchFactorRelationValueRowCount
        /// ���ܸ�Ҫ: ��ȡ���������Ĺ�ϵֵ�б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��18��11:10:17
        /// ����������
        /// ����ʱ��:
        /// </summary>
        public long SearchFactorRelationValueRowCount(FactorRelationValue factorRelationValue) 
        {
            return sqlMap.QueryForObject<long>("FactorRelationValue.SearchFactorRelationValueRowCount", factorRelationValue);
        }

        /// <summary>
        /// ��    ��: CheckFactorIsRelation
        /// ���ܸ�Ҫ: ����Ƿ����������������ϵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��25��15:26:24
        /// ����������
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public long CheckFactorIsRelation(FactorRelationValue factorRelationValue) 
        {
            return sqlMap.QueryForObject<long>("FactorRelationValue.CheckFactorIsRelation", factorRelationValue);
        }

        ///// <summary>
        ///// ��    ��: GetBusinessTypeRelationPriceFactorCount
        ///// ���ܸ�Ҫ: ��ȡҵ�����ͼ۸�����
        ///// ��    ��: ������
        ///// ����ʱ��: 2009��6��26��9:44:49
        ///// ����������
        ///// ����ʱ��:
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns></returns>
        //public long GetBusinessTypeRelationPriceFactorCount(FactorRelationValue factorRelationValue) 
        //{
        //    return sqlMap.QueryForObject<long>("FactorRelationValue.GetBusinessTypeRelationPriceFactorCount", factorRelationValue);
        //}

        /// <summary>
        /// ��    ��: GetFactorRelationId
        /// ���ܸ�Ҫ: ��ȡ�۸�����������ϵId
        /// ��    ��: ������
        /// ����ʱ��: 2009��7��13��10:27:18
        /// ����������
        /// ����ʱ��: 
        /// </summary>
        /// <param name="factorRelation"></param>
        /// <returns></returns>
        public long GetFactorRelationId(FactorRelation factorRelation) 
        {
            factorRelation.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelation.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("FactorRelationValue.GetFactorRelationId", factorRelation);
        }

        /// <summary>
        /// ��    ��: CheckFactorRelationValueIsExist
        /// ���ܸ�Ҫ: ���FactorRelationValue�Ƿ����
        /// ��    ��: ������
        /// ����ʱ��: 2009��7��15��14:50:16
        /// ����������
        /// ����ʱ��: 
        /// </summary>
        /// <param name="factorRelation"></param>
        /// <returns></returns>
        public bool CheckFactorRelationValueIsExist(FactorRelationValue factorRelationValue) 
        {
            factorRelationValue.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            factorRelationValue.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            long count = sqlMap.QueryForObject<long>("FactorRelationValue.CheckFactorRelationValueIsExist", factorRelationValue);
            if (count > 0) 
            {
                return true;
            }
            return false;
        }
    }
}
