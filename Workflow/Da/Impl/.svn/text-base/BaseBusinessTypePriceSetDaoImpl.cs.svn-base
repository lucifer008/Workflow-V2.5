using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using System.Collections;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table BASE_BUSINESS_TYPE_PRICE_SET 对应的Dao 实现
	/// </summary>
    public class BaseBusinessTypePriceSetDaoImpl : Workflow.Da.Base.DaoBaseImpl<BaseBusinessTypePriceSet>, IBaseBusinessTypePriceSetDao
    {
        public IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery(BaseBusinessTypePriceSet  baseBusinessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            baseBusinessTypePriceSet.CompanyId = user.CompanyId;
            baseBusinessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForList<BaseBusinessTypePriceSet>("BaseBusinessTypePriceSet.SelectCustomQueryBaseBusinessTypePriceSetList", baseBusinessTypePriceSet);
        }


        /// <summary>
        /// 增加分页功能的GetBaseBusinessTypePriceSetListCustomQuery
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        /// <remarks>
        /// 2008-11-08
        /// </remarks>
        public IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetListCustomQuery_Page(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            baseBusinessTypePriceSet.CompanyId = user.CompanyId;
            baseBusinessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForList<BaseBusinessTypePriceSet>("BaseBusinessTypePriceSet.SelectCustomQueryBaseBusinessTypePriceSetList_Page", baseBusinessTypePriceSet);
        }

        /// <summary>
        /// 方法名称: SearchBaseBuinessTypeSetInfo
        /// 功能概要: 获得门市价格设置一览(分页)
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月5日13:40:53
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        public IList<BaseBusinessTypePriceSet> SearchBaseBuinessTypeSetInfo(BaseBusinessTypePriceSet baseBusinessTypePriceSet) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            baseBusinessTypePriceSet.CompanyId = user.CompanyId;
            baseBusinessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForList<BaseBusinessTypePriceSet>("BaseBusinessTypePriceSet.SearchBaseBuinessTypeSetInfo", baseBusinessTypePriceSet);
        }

        /// <summary>
        /// 方法名称: SearchBaseBuinessTypeSetInfoRowCount
        /// 功能概要: 获得门市价格设置记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月5日13:40:53
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="baseBusinessTypePriceSet"></param>
        /// <returns></returns>
        public long SearchBaseBuinessTypeSetInfoRowCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            baseBusinessTypePriceSet.CompanyId = user.CompanyId;
            baseBusinessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForObject<long>("BaseBusinessTypePriceSet.SearchBaseBuinessTypeSetInfoRowCount", baseBusinessTypePriceSet);
        }

        public int GetBaseBusinessTypePriceSetListCustomQueryCount(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            baseBusinessTypePriceSet.CompanyId = user.CompanyId;
            baseBusinessTypePriceSet.BranchShopId = user.BranchShopId;
            return base.sqlMap.QueryForObject<int>("BaseBusinessTypePriceSet.SelectCustomQueryBaseBusinessTypePriceSetListCount", baseBusinessTypePriceSet);
        }


        public BaseBusinessTypePriceSet GetTheLowerestPrice(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            baseBusinessTypePriceSet.CompanyId = user.CompanyId;
            baseBusinessTypePriceSet.BranchShopId = user.BranchShopId;

            BaseBusinessTypePriceSet bbtps =(BaseBusinessTypePriceSet)base.sqlMap.QueryForObject("BaseBusinessTypePriceSet.SelectTheLowerestPrice", baseBusinessTypePriceSet);
            if(null==bbtps)
            {
                bbtps = new BaseBusinessTypePriceSet();
                bbtps.Id = -1;
                bbtps.StandardPrice = -1;
                return bbtps;
                //return -1.0M;//表示没有找到价格
            }
            else
            {
                return bbtps;
                //return decimal.Parse(price.ToString());
            }
        }

        #region 修改门市价格设置的分页

        /// <summary>
        /// 方法名称: GetBaseBusinessTypePriceSetDao
        /// 功能概要: 修改门市价格设置的分页
        /// 作    者: 陈汝胤
        /// 创建时间: 2008-1-9
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSetDao(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            baseBusinessTypePriceSet.CompanyId = user.CompanyId;
            baseBusinessTypePriceSet.BranchShopId = user.BranchShopId;
            return sqlMap.QueryForList<BaseBusinessTypePriceSet>("BaseBusinessTypePriceSet.GetBaseBusinessTypePriceSetDao", baseBusinessTypePriceSet);
        }

        #endregion

		#region 修改门市价格设置

		/// <summary>
		/// 方法名称: GetBaseBusinessTypePriceSets
		/// 功能概要: 修改门市价格设置
		/// 作    者: 陈汝胤
		/// 创建时间: 2008-1-9
		/// 修正履历: 
		/// 修正时间: 
		/// </summary>
		public IList<BaseBusinessTypePriceSet> GetBaseBusinessTypePriceSets(BaseBusinessTypePriceSet baseBusinessTypePriceSet)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			baseBusinessTypePriceSet.CompanyId = user.CompanyId;
			baseBusinessTypePriceSet.BranchShopId = user.BranchShopId;
			return sqlMap.QueryForList<BaseBusinessTypePriceSet>("BaseBusinessTypePriceSet.GetBaseBusinessTypePriceSets", baseBusinessTypePriceSet);
		}

		#endregion

        #region //获取会员卡消费的业务类型明细
        /// <summary>
        /// 获取会员卡消费的业务类型明细
        /// </summary>
        /// <param name="memberCardId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者:张晓林 
        /// 创建时间: 2009年4月16日10:44:31
        /// 修正履历:
        /// 修正时间:
        /// 描    述:
        /// </remarks>
        public IList<Order> GetMemberCardBaseBusItem(MemberCard memberCard) 
        {
            Hashtable condtion=new Hashtable();
            condtion.Add("CompanyId",ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condtion.Add("BranchShopId",ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condtion.Add("MemberCardId",memberCard.Id);
            condtion.Add("OrdersId",memberCard.OperateType);
            return sqlMap.QueryForList<Order>("BusinessTypePriceSet.GetMemberCardBaseBusItem", condtion);
        }
        #endregion 

        /// <summary>
        /// 删除基于门市价格下的其他价格
        /// </summary>
        /// <param name="memberCardId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林 
        /// 创建时间: 2010年1月15日11:34:48
        /// 修正履历:
        /// 修正时间:
        /// 描    述:
        /// </remarks>
        public void DeleteBusinessTypePriceSet(long bbId)
        {
            sqlMap.Delete("BusinessTypePriceSet.DeleteBusinessTypePriceSet", bbId);
		}

		#region 更新门市价格

		/// <summary>
		/// 更新门市价格
		/// </summary>
		/// <param name="val"></param>
		public void UpdateBusinessTypePrice(BaseBusinessTypePriceSet val)
		{
			sqlMap.Update("BaseBusinessTypePriceSet.UpdateBusinessTypePrice", val);
		}

		#endregion

		#region 获取指定价格因素的最大价格
		/// <summary>
		/// 作    者: 白晓宇
		/// 创建时间: 2010年04月16日
		/// 修正履历:
		/// 修正时间:
		/// 描    述:
		/// </summary>
		public BaseBusinessTypePriceSet SelectTheMostBaseBusinessTypePrice(BaseBusinessTypePriceSet domain)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

			domain.CompanyId = user.CompanyId;
			domain.BranchShopId = user.BranchShopId;

			return sqlMap.QueryForObject<BaseBusinessTypePriceSet>("BaseBusinessTypePriceSet.SelectTheLowerestPrice", domain);
		}
		#endregion
		
	}
}
