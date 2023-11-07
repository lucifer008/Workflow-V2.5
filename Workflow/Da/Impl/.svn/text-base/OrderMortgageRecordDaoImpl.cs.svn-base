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
	/// Table ORDER_MORTGAGE_RECORD (订单冲减记录) 对应的Dao 实现
	/// </summary>
    public class OrderMortgageRecordDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrderMortgageRecord>, IOrderMortgageRecordDao
    {
        /// <summary>
        /// 获取要输出的冲减订单信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2009年12月9日11:36:30
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public OrderMortgageRecord SearchMortgageOrderPrint() 
        {
            OrderMortgageRecord om = new OrderMortgageRecord();
            om.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            om.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<OrderMortgageRecord>("OrderMortgageRecord.SearchMortgageOrderPrint", om);
        }
    }
}