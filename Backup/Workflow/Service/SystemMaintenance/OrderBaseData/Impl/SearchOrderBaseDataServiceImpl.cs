using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.SystemMaintenance.OrderBaseData.Impl
{
    /// <summary>
    /// ��    ��: SearchOrderBaseDataServiceImpl
    /// ���ܸ�Ҫ: ��ȡ�����������ݽӿ�ʵ��
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:22:33
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public class SearchOrderBaseDataServiceImpl:ISearchOrderBaseDataService
    {
        #region//ע��Dao
        private ICustomerLevelDao customerLevelDao;
        public ICustomerLevelDao CustomerLevelDao 
        {
            set { customerLevelDao = value; }
        }

        private ICustomerTypeDao customerTypeDao;
        public ICustomerTypeDao CustomerTypeDao 
        {
            set { customerTypeDao = value; }
        }

        private IMasterTradeDao masterTradeDao;
        public IMasterTradeDao MasterTradeDao
        {
            set { masterTradeDao = value; }
        }
        private ISecondaryTradeDao secondaryTradeDao;
        public ISecondaryTradeDao SecondaryTradeDao
        {
            set { secondaryTradeDao = value; }
        }

        private IMemberCardLevelDao memberCardLevelDao;
        public IMemberCardLevelDao MemberCardLevelDao
        {
            set { memberCardLevelDao = value; }
        }

        private IPrintDemandDao printDemandDao;
        public IPrintDemandDao PrintDemandDao 
        {
            set { printDemandDao = value; }
        }

        private IPrintDemandDetailDao printDemandDetailDao;
        public IPrintDemandDetailDao PrintDemandDetailDao
        {
            set { printDemandDetailDao = value; }
        }

        private IReportLessModeDao reportLessModeDao;
        public IReportLessModeDao ReportLessModeDao 
        {
            set { reportLessModeDao = value; }
        }

        private ITrashReasonDao trashReasonDao;
        public ITrashReasonDao TrashReasonDao
        {
            set { trashReasonDao = value; }
        }

        private IProcessContentDao processContentDao;
        public IProcessContentDao ProcessContentDao 
        {
            set { processContentDao = value; }
        }

        private IProcessContentAchievementRateDao processContentAchievementRateDao;
        public IProcessContentAchievementRateDao ProcessContentAchievementRateDao 
        {
            set { processContentAchievementRateDao = value; }
        }
        #endregion

        #region//�ͻ�����
        /// <summary>
        /// ��   ��:  SearchCustomerLevel
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<CustomerLevel> SearchCustomerLevel(CustomerLevel customerLevel) 
        {
            return customerLevelDao.SearchCustomerLevel(customerLevel);
        }

        /// <summary>
        /// ��   ��:  SearchCustomerLevelRowCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchCustomerLevelRowCount(CustomerLevel customerLevel) 
        {
            return customerLevelDao.SearchCustomerLevelRowCount(customerLevel);
        }

        /// <summary>
        /// ��   ��:  CheckCustomerLevelIsUse
        /// ���ܸ�Ҫ: ���ͻ������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��11:35:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckCustomerLevelIsUse(long customerLevelId) 
        {
            return customerLevelDao.CheckCustomerLevelIsUse(customerLevelId);
        }
        #endregion

        #region//�ͻ�����

        /// <summary>
        /// ��   ��:  SearchCustomerType
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<CustomerType> SearchCustomerType(CustomerType customerType) 
        {
            return customerTypeDao.SearchCustomerType(customerType);
        }

        /// <summary>
        /// ��   ��:  SearchCustomerTypeRowCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchCustomerTypeRowCount(CustomerType customerType) 
        {
            return customerTypeDao.SearchCustomerTypeRowCount(customerType);
        }

        /// <summary>
        /// ��   ��:  CheckCustomerTypeIsUse
        /// ���ܸ�Ҫ: ���ͻ������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��11:35:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckCustomerTypeIsUse(long customerTypeId) 
        {
            return customerTypeDao.CheckCustomerTypeIsUse(customerTypeId);
        }
        #endregion

        #region//�ͻ���ҵ������ҵ
        /// <summary>
        /// ��   ��:  SearchMasterTrade
        /// ���ܸ�Ҫ: ��ȡ������ҵ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��10:20:39
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<MasterTrade> SearchMasterTrade(MasterTrade masterTrade) 
        {
            return masterTradeDao.SearchMasterTrade(masterTrade);
        }

        /// <summary>
        /// ��   ��:  SearchMasterTradeRowCount
        /// ���ܸ�Ҫ: ��ȡ������ҵ�б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��10:20:39
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchMasterTradeRowCount(MasterTrade masterTrade) 
        {
            return masterTradeDao.SearchMasterTradeRowCount(masterTrade);
        }

        /// <summary>
        /// ��   ��:  SearchMasterTrade
        /// ���ܸ�Ҫ: ��ȡ�ͻ�����ҵ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��10:20:39
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<SecondaryTrade> SearchSecondaryTrade(SecondaryTrade secondaryTrade) 
        {
            return secondaryTradeDao.SearchSecondaryTrade(secondaryTrade);
        }

        /// <summary>
        /// ��   ��:  SearchMasterTradeRowCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ�����ҵ�б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��10:20:39
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchSecondaryTradeRowCount(SecondaryTrade secondaryTrade) 
        {
            return secondaryTradeDao.SearchSecondaryTradeRowCount(secondaryTrade);
        }

        /// <summary>
        /// ��   ��:  CheckMasterTradeIsUse
        /// ���ܸ�Ҫ: ���ͻ��ͻ�����ҵ�Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��11:48:22
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckMasterTradeIsUse(long masterTradeId) 
        {
            return masterTradeDao.CheckMasterTradeIsUse(masterTradeId);
        }

        /// <summary>
        /// ��   ��:  GetAllMasterTrade
        /// ���ܸ�Ҫ: ��ȡ��������ҵ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��22��9:51:12
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<MasterTrade> GetAllMasterTrade() 
        {
            return masterTradeDao.SelectAll();
        }
        #endregion

        #region//��Ա������
        /// <summary>
        /// ��   ��:  SearchMemberCardLevel
        /// ���ܸ�Ҫ: ��ȡ��Ա�������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:52:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<MemberCardLevel> SearchMemberCardLevel(MemberCardLevel memberCardLevel) 
        {
            return memberCardLevelDao.SearchMemberCardLevel(memberCardLevel);
        }

        /// <summary>
        /// ��   ��:  SearchMemberCardLevelRowCount
        /// ���ܸ�Ҫ: ��ȡ��Ա�������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:52:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchMemberCardLevelRowCount(MemberCardLevel memberCardLevel) 
        {
            return memberCardLevelDao.SearchMemberCardLevelRowCount(memberCardLevel);
        }

        /// <summary>
        /// ��   ��:  CheckMemberCardLevelIsUse
        /// ���ܸ�Ҫ: ����Ա�������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:58:02
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckMemberCardLevelIsUse(long memberCardLevelId) 
        {
            return memberCardLevelDao.CheckMemberCardLevelIsUse(memberCardLevelId);
        }
        #endregion

        #region//ӡ��Ҫ����ϸ
        /// <summary>
        /// ��   ��:  SearchPrintDemand
        /// ���ܸ�Ҫ: ��ȡӡ��Ҫ���б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<PrintDemand> SearchPrintDemand(PrintDemand printDemand) 
        {
            return printDemandDao.SearchPrintDemand(printDemand); ;
        }

        /// <summary>
        /// ��   ��:  SearchPrintDemandRowCount
        /// ���ܸ�Ҫ: ��ȡӡ��Ҫ���б���Ŀ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchPrintDemandRowCount(PrintDemand printDemand) 
        {
            return printDemandDao.SearchPrintDemandRowCount(printDemand);
        }

        /// <summary>
        /// ��   ��:  SearchPrintDemandDetail
        /// ���ܸ�Ҫ: ��ȡӡ��Ҫ����ϸ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<PrintDemandDetail> SearchPrintDemandDetail(PrintDemandDetail printDemandDetail) 
        {
            return printDemandDetailDao.SearchPrintDemandDetail(printDemandDetail);
        }

        /// <summary>
        /// ��   ��:  SearchPrintDemandDetailRowCount
        /// ���ܸ�Ҫ: ��ȡӡ��Ҫ����ϸ�б���Ŀ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchPrintDemandDetailRowCount(PrintDemandDetail printDemandDetail) 
        {
            return printDemandDetailDao.SearchPrintDemandDetailRowCount(printDemandDetail);
        }

        /// <summary>
        /// ��   ��:  GetAllPrintDemand
        /// ���ܸ�Ҫ: ��ȡ����ӡ��Ҫ���б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��17:47:10
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<PrintDemand> GetAllPrintDemand() 
        {
           return printDemandDao.GetAllPrintDemand();
        }

        /// <summary>
        /// ��   ��:  CheckPrintDemandIsUse
        /// ���ܸ�Ҫ: ���ӡ��Ҫ���Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��17:49:14
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckPrintDemandIsUse(long printDemandId) 
        {
            return printDemandDao.CheckPrintDemandIsUse(printDemandId);
        }
        #endregion

        #region//��ʧ��ʽ
        /// <summary>
        /// ��   ��:  SearchReportLessMode
        /// ���ܸ�Ҫ: ��ȡ��ʧ��ʽ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<ReportLessMode> SearchReportLessMode(ReportLessMode reportLessMode) 
        {
            return reportLessModeDao.SearchReportLessMode(reportLessMode);
        }

        /// <summary>
        /// ��   ��:  SearchReportLessModeRowCount
        /// ���ܸ�Ҫ: ��ȡ��ʧ��ʽ�б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchReportLessModeRowCount(ReportLessMode reportLessMode) 
        {
            return reportLessModeDao.SearchReportLessModeRowCount(reportLessMode);
        }


        /// <summary>
        /// ��   ��:  CheckReportLessModeIsUse
        /// ���ܸ�Ҫ: ����ʧ��ʽ�Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��10:36:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckReportLessModeIsUse(long reportLessModeId) 
        {
            return reportLessModeDao.CheckReportLessModeIsUse(reportLessModeId);
        }
        #endregion

        #region//����ԭ��
        /// <summary>
        /// ��   ��:  SearchTrashReason
        /// ���ܸ�Ҫ: ��ȡ����ԭ���б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<TrashReason> SearchTrashReason(TrashReason trashReason) 
        {
            return trashReasonDao.SearchTrashReason(trashReason);
        }

        /// <summary>
        /// ��   ��:  SearchTrashReasonRowCount
        /// ���ܸ�Ҫ: ��ȡ����ԭ���б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchTrashReasonRowCount(TrashReason trashReason) 
        {
            return trashReasonDao.SearchTrashReasonRowCount(trashReason);
        }

        /// <summary>
        /// ��   ��:  CheckTrashReasonIsUse
        /// ���ܸ�Ҫ: ������ԭ���Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long CheckTrashReasonIsUse(long trashReasonId) 
        {
            return trashReasonDao.CheckTrashReasonIsUse(trashReasonId);
        }

        #endregion

        #region//�ӹ�����ҵ������
        /// <summary>
        /// ��    ��: GetAllProcessContent
        /// ���ܸ�Ҫ: ��ȡ���мӹ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ����ʱ��:
        /// </summary>
        public IList<ProcessContent> GetAllProcessContent()
        {
            return processContentDao.GetAllProcessContent();
        }

        /// <summary>
        /// ��    ��: SearchProcessContentAchievementValue
        /// ���ܸ�Ҫ: ��ȡ�ӹ�����ҵ�������б� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ����ʱ��:
        /// </summary>
        public IList<ProcessContentAchievementRate> SearchProcessContentAchievementValue(ProcessContentAchievementRate processContentAchievementRate) 
        {
            return processContentAchievementRateDao.SearchProcessContentAchievementValue(processContentAchievementRate);
        }

        /// <summary>
        /// ��    ��: SearchProcessContentAchievementValueRowCount
        /// ���ܸ�Ҫ: ��ȡ�ӹ�����ҵ�������б��¼�� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ����ʱ��:
        /// </summary>
        public long SearchProcessContentAchievementValueRowCount(ProcessContentAchievementRate processContentAchievementRate) 
        {
            return processContentAchievementRateDao.SearchProcessContentAchievementValueRowCount(processContentAchievementRate);
        }
        #endregion
    }
}
