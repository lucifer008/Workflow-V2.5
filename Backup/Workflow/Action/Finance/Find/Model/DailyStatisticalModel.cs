using System;
using System.Collections.Generic;

using Workflow.Da.Domain;
/// <summary>
/// ��    ��: DailyStatisticalModel
/// ���ܸ�Ҫ: ��Ӫҵ����Model
/// ��    ��: ������
/// ����ʱ��: 2010��4��16��11:42:38
/// ��������: 
/// ����ʱ��: 
/// </summary>
namespace Workflow.Action.Finance.Find.Model
{
    public class DailyStatisticalModel
    {
        #region ��Ա����
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
