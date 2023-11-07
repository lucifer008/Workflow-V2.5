using System;
using System.Collections.Generic;

using Workflow.Da.Domain;
/// <summary>
/// 名    称: DailyStatisticalModel
/// 功能概要: 日营业报表Model
/// 作    者: 张晓林
/// 创建时间: 2010年4月16日11:42:38
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action.Finance.Find.Model
{
    public class DailyStatisticalModel
    {
        #region 成员变量
        private DailyBusionessReportItem dailyBusionessReportItem=new DailyBusionessReportItem();
        public DailyBusionessReportItem DailyBusionessReportItem 
        {
            set { dailyBusionessReportItem = value; }
            get { return dailyBusionessReportItem; }
        }

        private IList<DailyBusionessReportItem> dailyBusionessReportItemList;
        public IList<DailyBusionessReportItem> DailyBusionessReportItemList
        {
            get { return dailyBusionessReportItemList; }
            set { dailyBusionessReportItemList = value; }
        }
        #endregion
    }
}
