using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table BUSINESS_TYPE_PRICE_SET 对应的Dao 实现
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


        #region //不论有没有设置会员或者行业价格,都按条件指定条件查出来.
        /// <summary>
        /// 不论有没有设置会员或者行业价格,都按条件指定条件查出来. 
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

        #region //获取BusinessTypePriceSet对应的会员卡级别或者行业名称

        /// <summary>
        /// 获取BusinessTypePriceSet对应的会员卡级别或者行业名称
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

        #region //经过设置会员或者行业价格,按条件指定条件查出来.
        /// <summary>
        /// 经过设置会员或者行业价格,按条件指定条件查出来. 
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

        #region //不论有没有设置会员或者行业价格,都按条件指定条件查出来.取行数
        /// <summary>
        /// 不论有没有设置会员或者行业价格,都按条件指定条件查出来.取行数
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

        #region //经过设置会员或者行业价格,按条件指定条件查出来.取行数
        /// <summary>
        /// 经过设置会员或者行业价格,按条件指定条件查出来.取行数
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

                //return -1.0M;//表示没有找到价格
            }
            else
            {
                return btps;
                //return decimal.Parse(price.ToString());
            }
            
        }
    }
}
