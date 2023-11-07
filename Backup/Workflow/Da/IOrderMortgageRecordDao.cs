#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table ORDER_MORTGAGE_RECORD (订单冲减记录)对应的Dao 接口
	/// </summary>
	public interface IOrderMortgageRecordDao : IDaoBase<OrderMortgageRecord>
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
        OrderMortgageRecord SearchMortgageOrderPrint(); 
	}
}