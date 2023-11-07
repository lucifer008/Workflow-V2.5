using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table BUSINESS_TYPE_PRICE_SET ��Ӧ��Dao ʵ��
	/// </summary>
    public class BusinessTypePriceSetDaoImpl : Workflow.Da.Base.DaoBaseImpl<BusinessTypePriceSet>, IBusinessTypePriceSetDao
    {
        public IList<BusinessTypePriceSet> GetBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessTypePriceSet.CompanyId = user.CompanyId;
            businessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForList<BusinessTypePriceSet>("BusinessTypePriceSet.SelectCustomQueryBusinessTypePriceSetList", businessTypePriceSet);
        }

        public long GetBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessTypePriceSet.CompanyId = user.CompanyId;
            businessTypePriceSet.BranchShopId = user.BranchShopId;
            return (long)base.sqlMap.QueryForObject("BusinessTypePriceSet.SelectCustomQueryBusinessTypePriceSetListCount", businessTypePriceSet);
        }


        #region //������û�����û�Ա������ҵ�۸�,��������ָ�����������.
        /// <summary>
        /// ������û�����û�Ա������ҵ�۸�,��������ָ�����������. 
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public IList<BusinessTypePriceSet> GetAllBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessTypePriceSet.CompanyId = user.CompanyId;
            businessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForList<BusinessTypePriceSet>("BusinessTypePriceSet.SelectAllCustomQueryBusinessTypePriceSetList", businessTypePriceSet);
        }

        #endregion

        #region //��ȡBusinessTypePriceSet��Ӧ�Ļ�Ա�����������ҵ����

        /// <summary>
        /// ��ȡBusinessTypePriceSet��Ӧ�Ļ�Ա�����������ҵ����
        /// </summary>
        /// <param name="bizPriceSet"></param>
        public string GetTargetName(BusinessTypePriceSet bizPriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            bizPriceSet.CompanyId = user.CompanyId;
            bizPriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForObject<string>("BusinessTypePriceSet.GetTargetName", bizPriceSet);
        }
        #endregion

        #region //�������û�Ա������ҵ�۸�,������ָ�����������.
        /// <summary>
        /// �������û�Ա������ҵ�۸�,������ָ�����������. 
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public IList<BusinessTypePriceSet> GetOnlyBusinessTypePriceSetListCustomQuery(BusinessTypePriceSet businessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessTypePriceSet.CompanyId = user.CompanyId;
            businessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForList<BusinessTypePriceSet>("BusinessTypePriceSet.SelectOnlyCustomQueryBusinessTypePriceSetList", businessTypePriceSet);
        }
        #endregion

		#region //�������û�Ա������ҵ�۸�,������ָ�����������.(����ҳ)
		/// <summary>
		/// �������û�Ա������ҵ�۸�,������ָ�����������. (����ҳ)
		/// </summary>
		/// <param name="businessTypePriceSet"></param>
		/// <returns></returns>
		public IList<BusinessTypePriceSet> GetOnlyBusinessTypePriceSetList(BusinessTypePriceSet businessTypePriceSet)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			businessTypePriceSet.CompanyId = user.CompanyId;
			businessTypePriceSet.BranchShopId = user.BranchShopId;
			return base.sqlMap.QueryForList<BusinessTypePriceSet>("BusinessTypePriceSet.SelectOnlyBusinessTypePriceSetList", businessTypePriceSet);
		}
		#endregion


        #region //������û�����û�Ա������ҵ�۸�,��������ָ�����������.ȡ����
        /// <summary>
        /// ������û�����û�Ա������ҵ�۸�,��������ָ�����������.ȡ����
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public long GetAllBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessTypePriceSet.CompanyId = user.CompanyId;
            businessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForObject<long>("BusinessTypePriceSet.SelectAllCustomQueryBusinessTypePriceSetListCount", businessTypePriceSet);
        }
        #endregion

        #region //�������û�Ա������ҵ�۸�,������ָ�����������.ȡ����
        /// <summary>
        /// �������û�Ա������ҵ�۸�,������ָ�����������.ȡ����
        /// </summary>
        /// <param name="businessTypePriceSet"></param>
        /// <returns></returns>
        public long GetOnlyBusinessTypePriceSetListCustomQueryCount(BusinessTypePriceSet businessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessTypePriceSet.CompanyId = user.CompanyId;
            businessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForObject<long>("BusinessTypePriceSet.SelectOnlyCustomQueryBusinessTypePriceSetListCount", businessTypePriceSet);
        }
        #endregion


        public BusinessTypePriceSet GetPrice(BusinessTypePriceSet businessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            businessTypePriceSet.CompanyId = user.CompanyId;
            businessTypePriceSet.BranchShopId = user.BranchShopId;

            BusinessTypePriceSet btps =(BusinessTypePriceSet)base.sqlMap.QueryForObject("BusinessTypePriceSet.SelectTheLowerestPrice", businessTypePriceSet);
            //if (null == price || 0==decimal.Parse(price.ToString()))
            if(null==btps)
            {
                btps = new BusinessTypePriceSet();
                btps.StandardPrice = -1;
                btps.Id = -1;
                return btps;

                //return -1.0M;//��ʾû���ҵ��۸�
            }
            else
            {
                return btps;
                //return decimal.Parse(price.ToString());
            }
        }
        #region//ɾ����Ա�۸�
        /// <summary>
        /// ��������: DeleteMembercardPrice
        /// ���ܸ�Ҫ: ɾ����Ա�۸�
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��30��10:10:40
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public void DeleteMembercardPrice(BusinessTypePriceSet businessTypePriceSet) 
        {
            businessTypePriceSet.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessTypePriceSet.BranchShopId= Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.Delete("BusinessTypePriceSet.DeleteMembercardPrice", businessTypePriceSet);
        }
        #endregion

        #region//�༭��Ա�۸�
        /// <summary>
        /// ��������: UpdateMembercardPrice
        /// ���ܸ�Ҫ: �༭��Ա�۸�
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��30��15:39:54
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public void UpdateMembercardPrice(BusinessTypePriceSet businessTypePriceSet) 
        {
            businessTypePriceSet.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            businessTypePriceSet.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.Delete("BusinessTypePriceSet.UpdateMembercardPrice", businessTypePriceSet);
        }
        #endregion

		#region �޸Ļ�Ա���۸�

		/// <summary>
		/// �޸Ļ�Ա���۸�
		/// </summary>
		/// <param name="val"></param>
		public void UpdateBusinessTypePrice(BusinessTypePriceSet val)
		{
			sqlMap.Update("BusinessTypePriceSet.UpdateBusinessTypePrice", val);
		}

		#endregion
	}
}
