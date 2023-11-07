using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table BUSINESS_TYPE ��Ӧ��Dao ʵ��
	/// </summary>
    public class BusinessTypeDaoImpl : Workflow.Da.Base.DaoBaseImpl<BusinessType>, IBusinessTypeDao
    {

        #region IBusinessTypeDao ��Ա

        //public IList<PriceFactor> GetPriceFactorListByBusinessTypeId(long id)
        //{
        //    return sqlMap.QueryForList<PriceFactor>("BusinessTypeBase.SelectPriceFactor", id);
        //}

        public IList<BusinessType> SelectCustomerQueryBusinessTypeList(BusinessType businessType)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessType.CompanyId = user.CompanyId;
            businessType.BranchShopId = user.BranchShopId;
            return sqlMap.QueryForList<BusinessType>("BusinessType.SelectCustomQueryBusinessTypeList", businessType);
        }


        public IList<BusinessType> SelectCustomerQueryBusinessTypeList_Set(BusinessType businessType)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessType.CompanyId = user.CompanyId;
            businessType.BranchShopId = user.BranchShopId;
            return sqlMap.QueryForList<BusinessType>("BusinessType.SelectCustomQueryBusinessTypeList_Set", businessType);
        }

        /// <summary>
        /// ָ����ŵ�ҵ�������Ƿ���ɾ��.������ܷ���BusinessType��������,����������
        /// </summary>
        /// <param name="businessId">Ҫ�����ҵ������ID</param>
        /// <returns></returns>
        /// <remarks>
        /// ����:2008-11-06
        /// �쾲��
        ///</remarks>
        public IList<BusinessType> DeleteCheck(long businessId)
        {
            return sqlMap.QueryForList<BusinessType>("BusinessType.DeleteCheck", businessId);        
        }



        #endregion

        /// <summary>
        /// ��    �ƣ�GetBusinessTypeList
        /// ���ܸ�Ҫ����ȡҵ�������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��28��17:26:13
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        public IList<BusinessType> GetBusinessTypeList(BusinessType businessType) 
        {
            businessType.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessType.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<BusinessType>("BusinessType.GetBusinessTypeList", businessType);
        }


        /// <summary>
        /// ��    �ƣ�GetBusinessTypeListRowCount
        /// ���ܸ�Ҫ����ȡҵ�����ͼ�¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��29��11:26:27
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="businessType"></param>
        /// <returns></returns>
        public long GetBusinessTypeListRowCount(BusinessType businessType) 
        {
            return sqlMap.QueryForObject<long>("BusinessType.GetBusinessTypeListRowCount", businessType);
        }

        /// <summary>
        /// ��    �ƣ�GetAllBusinessTypeList
        /// ���ܸ�Ҫ: ��ȡҵ�������б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��4��30��9:45:47
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<BusinessType> GetAllBusinessTypeList() 
        {
            BusinessType businessType = new BusinessType();
            businessType.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessType.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<BusinessType>("BusinessType.GetAllBusinessTypeList", businessType);
        }

         /// <summary>
        /// ��    �ƣ�CheckBusinessTyIsUse
        /// ���ܸ�Ҫ: ���ҵ�������Ƿ�����ʹ��
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��4��30��15:35:42
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckBusinessTyIsUse(long businessTypeId) 
        {
            BusinessType businessType = new BusinessType();
            businessType.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessType.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            businessType.Id = businessTypeId;
            return sqlMap.QueryForObject<long>("BusinessType.CheckBusinessTyIsUse", businessType);
        }
    }
}
