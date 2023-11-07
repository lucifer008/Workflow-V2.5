#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table DAILY_BUSIONESS_REPORT_ITEM (日营业报表明细)对应的Dao 接口
	/// </summary>
	public interface IDailyBusionessReportItemDao : IDaoBase<DailyBusionessReportItem>
	{
        /// <summary>
        /// 获取日营业报表数据
        /// </summary>
        /// <param name="dailyBusionessReportItem"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月20日15:43:36
        /// </remarks>
        IList<DailyBusionessReportItem> SearchDailyBusinessInfo(DailyBusionessReportItem dailyBusionessReportItem);

        /// <summary>
        /// 功  能: 统计业务类型使用情况
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        IList<DailyBusionessReportItem> GetStatisticalBusinessTypeUsed(string date);

        /// <summary>
        /// 功  能: 获取日期下的所有订单明细Id集合
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13 
        /// </summary>
        /// <returns></returns>
        IList<long> GetOrderItemIdList(string date);

        /// <summary>
        /// 功  能: 根据价格因素Id与价格因素值获取价格因素值文本
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13 
        /// </summary>
        /// <returns></returns>
        string GetPriceFactorValueText(long priceFactorValueId, PriceFactor pf);

        /// <summary>
        /// 删除营业报表
        /// </summary>
        /// <param name="columnFormat"></param>
        /// <param name="tempDailyBusionessReportItem"></param>
        /// <param name="date">统计日期</param>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月21日10:37:57
        /// </remarks>
        void DeleteDailyBusinessReportItem(string date);

        /// <summary>
        /// 获取业务花费金额
        /// </summary>
        /// <param name="businessTypeName">业务</param>
        /// <param name="date">统计日期</param>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年5月4日14:02:41
        /// </remarks>
        decimal GetPossessiveAmount(string businessTypeName, string date);
	}
}