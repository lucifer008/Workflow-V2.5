using System;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Action.Finance.Find.Model;

/// <summary>
/// ��    ��: DailyStatisticalAction
/// ���ܸ�Ҫ: ��Ӫҵ����Action
/// ��    ��: ������
/// ����ʱ��: 2010��4��16��11:42:38
/// ��������: 
/// ����ʱ��: 
/// </summary>
namespace Workflow.Action.Finance.Find
{
    public class DailyStatisticalAction
    {
        #region//��Ա����
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

        #region//��Ӫҵ����ͳ��
        /// <summary>
        /// ��  ��: ��Ӫҵ����ͳ��
        /// </summary>
        /// <remarks>
        /// ��  ��: ������
        /// ��  ��: 2010��4��16��14:23:13
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
        /// ��  ��: ������ͳ��ҵ������ʹ�����
        /// ��  ��: ������
        /// ��  ��: 2010��4��16��14:23:13
        /// </summary>
        private void StatisticalBusinessTypeUsed() 
        {
            findFinanceService.StatisticalBusinessTypeUsed(model.DailyBusionessReportItem.Date, model.DailyBusionessReportItem.FileName);
        }

        /// <summary>
        /// ��ȡҵ�񻨷ѽ��
        /// </summary>
        /// <param name="businessTypeName">ҵ��</param>
        /// <param name="date">ͳ������</param>
        /// <remarks>
        /// ��  ��: ������
        /// ��  ��: 2010��5��4��14:02:41
        /// </remarks>
        public string GetSameBusinessTypeInverse(string businessTypeName,string date) 
        {
            //decimal businessPossessiveAmount = 0;//��ҵ��������ֽ����ռ�Ľ��
            //decimal allBusinessAmountTotal = 0;//��������ҵ����ܺ�
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
