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
	/// Table DAILY_BUSIONESS_REPORT_ITEM (日营业报表明细) 对应的Dao 实现
	/// </summary>
    public class DailyBusionessReportItemDaoImpl : Workflow.Da.Base.DaoBaseImpl<DailyBusionessReportItem>, IDailyBusionessReportItemDao
    {
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
        public void DeleteDailyBusinessReportItem(string date) 
        {
            DailyBusionessReportItem dailyBusionessReportItem = new DailyBusionessReportItem();
            dailyBusionessReportItem.Date = date;
            dailyBusionessReportItem.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            dailyBusionessReportItem.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            sqlMap.Delete("DailyBusionessReportItem.DeleteDailyBusinessReportItem",dailyBusionessReportItem);
            sqlMap.Delete("DailyBusionessReportItem.DeleteDailyBusinessReport",dailyBusionessReportItem);
        }

        /// <summary>
        /// 获取日营业报表数据
        /// </summary>
        /// <param name="dailyBusionessReportItem"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月20日15:43:36
        /// </remarks>
        public IList<DailyBusionessReportItem> SearchDailyBusinessInfo(DailyBusionessReportItem dailyBusionessReportItem) 
        {
            dailyBusionessReportItem.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            dailyBusionessReportItem.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<DailyBusionessReportItem>("DailyBusionessReportItem.SearchDailyBusinessInfo", dailyBusionessReportItem);
        }
        /// <summary>
        /// 功  能: 统计业务类型使用情况
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13 
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public IList<DailyBusionessReportItem> GetStatisticalBusinessTypeUsed(string date) 
        {
            DailyBusionessReportItem dailyBusionessReportItem = new DailyBusionessReportItem();
            dailyBusionessReportItem.Date = date;
            dailyBusionessReportItem.Id = Convert.ToInt32(Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE);
            dailyBusionessReportItem.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            dailyBusionessReportItem.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<DailyBusionessReportItem>("DailyBusionessReportItem.GetStatisticalBusinessTypeUsed", dailyBusionessReportItem);
        }

        /// <summary>
        /// 功  能: 获取日期下的所有订单明细Id集合
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13 
        /// </summary>
        /// <returns></returns>
        public IList<long> GetOrderItemIdList(string date) 
        {
            DailyBusionessReportItem dailyBusionessReportItem = new DailyBusionessReportItem();
            dailyBusionessReportItem.Date = date;
            dailyBusionessReportItem.Id = Convert.ToInt32(Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE);
            dailyBusionessReportItem.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            dailyBusionessReportItem.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<long>("DailyBusionessReportItem.GetOrderItemIdList", dailyBusionessReportItem);
        }

        /// <summary>
        /// 功  能: 根据价格因素Id与价格因素值获取价格因素值文本
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13 
        /// </summary>
        /// <returns></returns>
        public string GetPriceFactorValueText(long priceFactorValueId,PriceFactor pf) 
        {
            PriceFactor priceFactor = new PriceFactor();
            priceFactor.TargetTable = pf.TargetTable;
            priceFactor.TargetTextColumn = pf.TargetTextColumn;
            priceFactor.TargetValueColumn = pf.TargetValueColumn;
            priceFactor.Id = priceFactorValueId;
            priceFactor.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            priceFactor.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<string>("DailyBusionessReportItem.GetPriceFactorValueText", priceFactor);
        }
        /// <summary>
        /// 获取业务花费金额
        /// </summary>
        /// <param name="businessTypeName">业务</param>
        /// <param name="date">统计日期</param>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年5月4日14:02:41
        /// </remarks>
        public decimal GetPossessiveAmount(string businessTypeName, string date) 
        {
            DailyBusionessReportItem dailyBusionessReportItem = new DailyBusionessReportItem();
            dailyBusionessReportItem.Date = date;
            dailyBusionessReportItem.Name = businessTypeName;
            dailyBusionessReportItem.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            dailyBusionessReportItem.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<decimal>("DailyBusionessReportItem.GetPossessiveAmount", dailyBusionessReportItem);
        }
    }
}