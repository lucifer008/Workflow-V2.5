#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
#endregion

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MARKING_SETTING (积分设置) 对应的Dao 实现
	/// </summary>
    public class MarkingSettingDaoImpl : Workflow.Da.Base.DaoBaseImpl<MarkingSetting>, IMarkingSettingDao
    {
        #region//会员积分设置
        /// <summary>
        /// 名   称:  SearchMarking
        /// 功能概要: 获取积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日11:32:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MarkingSetting> SearchMarkingSetting(MarkingSetting markingSetting) 
        {
            markingSetting.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            markingSetting.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<MarkingSetting>("MarkingSetting.SearchMarkingSetting", markingSetting);
        }

        /// <summary>
        /// 名   称:  SearchMarkingSettingRowCount
        /// 功能概要: 获取积分列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日11:32:18
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchMarkingSettingRowCount(MarkingSetting markingSetting) 
        {
            return sqlMap.QueryForObject<long>("MarkingSetting.SearchMarkingSettingRowCount", markingSetting);
        }

        /// <summary>
        /// 名    称：CheckMarkingSettingIsExist
        /// 功能概要：检加工内容积分是否存在
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月28日16:57:01
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public bool CheckMarkingSettingIsExist(MarkingSetting markingSetting) 
        {
            markingSetting.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            markingSetting.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            long count = sqlMap.QueryForObject<long>("MarkingSetting.CheckMarkingSettingIsExist", markingSetting);
            if (count > 0) return true;
            return false;
        }

        /// <summary>
        /// 名   称:  GetAllMarkingSettingList
        /// 功能概要: 获取所有积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MarkingSetting> GetAllMarkingSettingList() 
        {
            MarkingSetting markingSetting = new MarkingSetting();
            markingSetting.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            markingSetting.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<MarkingSetting>("MarkingSetting.GetAllMarkingSetting", markingSetting);
        }

        /// <summary>
        /// 名   称:  根据工单Id获取会员消费的工单明细
        /// 功能概要: 获取所有积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<Order> GetOrderItemList(Order order) 
        {
            order.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Order>("Order.GetOrderItemList", order);
        }
        #endregion
    }
}