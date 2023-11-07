using System;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Action.Finance.Find.Model;

/// <summary>
/// 名    称: DailyStatisticalAction
/// 功能概要: 日营业报表Action
/// 作    者: 张晓林
/// 创建时间: 2010年4月16日11:42:38
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action.Finance.Find
{
    public class DailyStatisticalAction
    {
        #region//成员变量
        private IFindFinanceService findFinanceService;
        public IFindFinanceService FindFinanceService 
        {
            set { findFinanceService = value; }
        }
        private DailyStatisticalModel model = new DailyStatisticalModel();
        public DailyStatisticalModel Model 
        {
            set { model = value; }
            get { return model; }
        }
        #endregion

        #region//日营业报表统计
        /// <summary>
        /// 功  能: 日营业报表统计
        /// </summary>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13
        /// </remarks>
        public void SearchDailyBusinessInfo() 
        {
            if (model.DailyBusionessReportItem.Date == DateTime.Now.ToString("yyyy-MM-dd"))
            {
                findFinanceService.DeleteDailyBusinessReportItem(model.DailyBusionessReportItem.Date);
            }
            model.DailyBusionessReportItemList = findFinanceService.SearchDailyBusinessInfo(model.DailyBusionessReportItem);
            if (0 == model.DailyBusionessReportItemList.Count) 
            {
                StatisticalBusinessTypeUsed();
                model.DailyBusionessReportItemList = findFinanceService.SearchDailyBusinessInfo(model.DailyBusionessReportItem);
            }
        }

        /// <summary>
        /// 功  能: 按条件统计业务类型使用情况
        /// 作  者: 张晓林
        /// 日  期: 2010年4月16日14:23:13
        /// </summary>
        private void StatisticalBusinessTypeUsed() 
        {
            findFinanceService.StatisticalBusinessTypeUsed(model.DailyBusionessReportItem.Date, model.DailyBusionessReportItem.FileName);
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
        public string GetSameBusinessTypeInverse(string businessTypeName,string date) 
        {
            //decimal businessPossessiveAmount = 0;//该业务下所有纸型所占的金额
            //decimal allBusinessAmountTotal = 0;//当天所有业务的总和
            //businessPossessiveAmount = findFinanceService.GetPossessiveAmount(businessTypeName, date);
            //businessTypeName = null;
            //allBusinessAmountTotal = findFinanceService.GetPossessiveAmount(businessTypeName, date);
            //decimal inverseValue = decimal.Round(businessPossessiveAmount / allBusinessAmountTotal,2);
            //return Convert.ToString(inverseValue * 100) + "%";
            return findFinanceService.GetPossessiveAmount(businessTypeName, date);
        }
        #endregion
    }
}
