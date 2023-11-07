using System;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Da.Support;
namespace Workflow.Service.SystemMaintenance.OrderBaseData.Impl
{
    /// <summary>
    /// ��    ��: OrderBaseDataServiceImpl
    /// ���ܸ�Ҫ: �������������ݽӿ�ʵ��
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:22:33
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public class OrderBaseDataServiceImpl:IOrderBaseDataService
    {
        #region//ע��Dao
        private IdGeneratorSupport idGeneratorSupport;
        public IdGeneratorSupport IdGeneratorSupport
        {
            set { idGeneratorSupport = value; }
        }

        private ICustomerLevelDao customerLevelDao;
        public ICustomerLevelDao CustomerLevelDao
        {
            set{customerLevelDao=value;}
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

        private IProcessContentAchievementRateDao processContentAchievementRateDao;
        public IProcessContentAchievementRateDao ProcessContentAchievementRateDao
        {
            set { processContentAchievementRateDao = value; }
        }
        #endregion

        #region//�ͻ�����
        /// <summary>
        /// ��   ��:  AddCustomerLevel
        /// ���ܸ�Ҫ: ��ӿͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddCustomerLevel(CustomerLevel customerLevel)
        {
            Type type = typeof(CustomerLevel);
            long id = idGeneratorSupport.NextId(type);
            customerLevel.No = "0" + id.ToString();
            customerLevel.SortNo = Convert.ToInt32(id);
            customerLevelDao.Insert(customerLevel);
        }

        /// <summary>
        /// ��   ��:  UpdateCustomerLevel
        /// ���ܸ�Ҫ: ���¿ͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateCustomerLevel(CustomerLevel customerLevel)
        {
            customerLevel.No = "0" + customerLevel.Id.ToString();
            customerLevel.SortNo = Convert.ToInt32(customerLevel.Id);
            customerLevelDao.Update(customerLevel);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteCustomerLevel
        /// ���ܸ�Ҫ: �߼�ɾ���ͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteCustomerLevel(long customerLevelId) 
        {
            customerLevelDao.LogicDelete(customerLevelId);
        }
        
        #endregion

        #region//�ͻ�����
        /// <summary>
        /// ��   ��:  AddCustomerType
        /// ���ܸ�Ҫ: ��ӿͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddCustomerType(CustomerType customerType) 
        {
            Type type = typeof(CustomerType);
            long id = idGeneratorSupport.NextId(type);
            customerType.No = "0" + id.ToString();
            customerType.SortNo = Convert.ToInt32(id);
            customerTypeDao.Insert(customerType);
        }

        /// <summary>
        /// ��   ��:  UpdateCustomerType
        /// ���ܸ�Ҫ: ���¿ͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateCustomerType(CustomerType customerType) 
        {
            customerType.No = "0" + customerType.Id.ToString();
            customerType.SortNo = Convert.ToInt32(customerType.Id);
            customerTypeDao.Update(customerType);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteCustomerType
        /// ���ܸ�Ҫ: �߼�ɾ���ͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteCustomerType(long customerTypeId) 
        {
            customerTypeDao.LogicDelete(customerTypeId);
        }

        #endregion

        #region//�ͻ���ҵ������ҵ
        /// <summary>
        /// ��   ��:  AddMasterTrade
        /// ���ܸ�Ҫ: ��ӿͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddMasterTrade(MasterTrade masterTrade) 
        {
            Type type = typeof(MasterTrade);
            long id = idGeneratorSupport.NextId(type);
            masterTrade.No = "0" + id.ToString();
            masterTradeDao.Insert(masterTrade);
        }

        /// <summary>
        /// ��   ��:  UpdateMasterTrade
        /// ���ܸ�Ҫ: ���¿ͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateMasterTrade(MasterTrade masterTrade) 
        {
            masterTrade.No ="0"+ masterTrade.Id.ToString();
            masterTradeDao.Update(masterTrade);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteMasterTrade
        /// ���ܸ�Ҫ: �߼�ɾ���ͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteMasterTrade(long masterTradeId) 
        {
            masterTradeDao.LogicDelete(masterTradeId);
        }


        /// <summary>
        /// ��   ��:  AddSeondaryTrade
        /// ���ܸ�Ҫ: ��ӿͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddSecondaryTrade(SecondaryTrade secondaryTrade) 
        {
            Type type = typeof(SecondaryTrade);
            long id = idGeneratorSupport.NextId(type);
            secondaryTrade.No = "0" + id.ToString();
            secondaryTradeDao.Insert(secondaryTrade);
        }

        /// <summary>
        /// ��   ��:  UpdateSecondaryTrade
        /// ���ܸ�Ҫ: ���¿ͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateSecondaryTrade(SecondaryTrade secondaryTrade) 
        {
            secondaryTrade.No ="0"+ secondaryTrade.Id.ToString();
            secondaryTradeDao.Update(secondaryTrade);
        }


        /// <summary>
        /// ��   ��:  LogicDeleteSecondaryTrade
        /// ���ܸ�Ҫ: �߼�ɾ���ͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteSecondaryTrade(long secondaryTradeId) 
        {
            secondaryTradeDao.LogicDelete(secondaryTradeId);
        }
        #endregion

        #region//��Ա������
        /// <summary>
        /// ��   ��:  AddMemberCardLevel
        /// ���ܸ�Ҫ: ��ӻ�Ա������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:42:04
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddMemberCardLevel(MemberCardLevel memberCardLevel) 
        {
            Type type = typeof(MemberCardLevel);
            long id = idGeneratorSupport.NextId(type);
            memberCardLevel.No = "0" + id.ToString();
            memberCardLevelDao.Insert(memberCardLevel);
        }

        /// <summary>
        /// ��   ��:  UpdateMemberCardLevel
        /// ���ܸ�Ҫ: ���»�Ա������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:42:04
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateMemberCardLevel(MemberCardLevel memberCardLevel) 
        {
            memberCardLevel.No = "0" + memberCardLevel.Id;
            memberCardLevelDao.Update(memberCardLevel);
        }

        /// <summary>
        /// ��   ��:  UpdateMemberCardLevel
        /// ���ܸ�Ҫ: ���»�Ա������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:42:04
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteMemberCardLevel(long memberCardLevelId) 
        {
            memberCardLevelDao.LogicDelete(memberCardLevelId);
        }
        #endregion

        #region//ӡ��Ҫ����ϸ
        /// <summary>
        /// ��   ��:  AddPrintDemand
        /// ���ܸ�Ҫ: ���ӡ��Ҫ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��13:46:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddPrintDemand(PrintDemand printDemand) 
        {
            Type type = typeof(PrintDemand);
            long id = idGeneratorSupport.NextId(type);
            printDemand.SortNo = Convert.ToInt32(id);
            printDemandDao.Insert(printDemand);
        }

        /// <summary>
        /// ��   ��:  UpdatePrintDemand
        /// ���ܸ�Ҫ: ����ӡ��Ҫ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��13:46:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdatePrintDemand(PrintDemand printDemand) 
        {
            printDemand.SortNo = Convert.ToInt32(printDemand.Id);
            printDemandDao.Update(printDemand);
        }

        /// <summary>
        /// ��   ��:  LogicDeletePrintDemand
        /// ���ܸ�Ҫ: �߼�ɾ��ӡ��Ҫ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��13:46:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeletePrintDemand(long printDemandId) 
        {
            printDemandDao.LogicDelete(printDemandId);
        }

        /// <summary>
        /// ��   ��:  AddPrintDemandDetail
        /// ���ܸ�Ҫ: ���ӡ��Ҫ����ϸ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddPrintDemandDetail(PrintDemandDetail printDemandDetail) 
        {
            Type type = typeof(PrintDemandDetail);
            long id = idGeneratorSupport.NextId(type);
            printDemandDetail.SortNo = Convert.ToInt32(id);
            printDemandDetailDao.Insert(printDemandDetail);
        }

        /// <summary>
        /// ��   ��:  UpdatePrintDemandDetail
        /// ���ܸ�Ҫ: ����ӡ��Ҫ����ϸ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdatePrintDemandDetail(PrintDemandDetail printDemandDetail) 
        {
            printDemandDetail.SortNo = Convert.ToInt32(printDemandDetail.Id);
            printDemandDetailDao.Update(printDemandDetail);
        }

        /// <summary>
        /// ��   ��:  LogicDeletePrintDemandDetail
        /// ���ܸ�Ҫ: �߼�ɾ��ӡ��Ҫ����ϸ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeletePrintDemandDetail(long printDemandDetailId) 
        {
            printDemandDetailDao.LogicDelete(printDemandDetailId);
        }
        #endregion

        #region//��ʧ��ʽ
        /// <summary>
        /// ��   ��:  AddReportLessMode
        /// ���ܸ�Ҫ: ��ӹ�ʧ��ʽ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��11:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddReportLessMode(ReportLessMode reportLessMode) 
        {
            Type type = typeof(ReportLessMode);
            long id = idGeneratorSupport.NextId(type);
            reportLessMode.No = "0"+Convert.ToString(id);
            reportLessModeDao.Insert(reportLessMode);
        }

        /// <summary>
        /// ��   ��:  UpdateReportLessMode
        /// ���ܸ�Ҫ: �޸Ĺ�ʧ��ʽ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��11:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateReportLessMode(ReportLessMode reportLessMode) 
        {
            reportLessMode.No = "0"+reportLessMode.Id.ToString();
            reportLessModeDao.Update(reportLessMode);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteReportLessMode
        /// ���ܸ�Ҫ: �߼�ɾ����ʧ��ʽ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��11:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteReportLessMode(long reportLessModeId) 
        {
            reportLessModeDao.LogicDelete(reportLessModeId);
        }
        #endregion

        #region//����ԭ��
        /// <summary>
        /// ��   ��:  AddTrashReason
        /// ���ܸ�Ҫ: ��ӷ���ԭ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddTrashReason(TrashReason trashReason)
        {
            trashReasonDao.Insert(trashReason);
        }

        /// <summary>
        /// ��   ��:  UpdateTrashReason
        /// ���ܸ�Ҫ: �޸ķ���ԭ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateTrashReason(TrashReason trashReason) 
        {
            trashReasonDao.Update(trashReason);
        }
        /// <summary>
        /// ��   ��:  LogicDeleteTrashReason
        /// ���ܸ�Ҫ: �߼�ɾ������ԭ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteTrashReason(long trashReasonId) 
        {
            trashReasonDao.LogicDelete(trashReasonId);
        }
        #endregion

        #region//�ӹ�����ҵ������
        /// <summary>
        /// ��   ��:  AddProcessContentAchievementRate
        /// ���ܸ�Ҫ: ��Ӽӹ�����ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddProcessContentAchievementRate(ProcessContentAchievementRate processContentAchievementRate) 
        {
            processContentAchievementRateDao.Insert(processContentAchievementRate);
        }

        /// <summary>
        /// ��   ��:  UpdateProcessContentAchievementRate
        /// ���ܸ�Ҫ: �޸ļӹ�����ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateProcessContentAchievementRate(ProcessContentAchievementRate processContentAchievementRate) 
        {
            processContentAchievementRateDao.Update(processContentAchievementRate);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteProcessContentAchievementRate
        /// ���ܸ�Ҫ: �߼�ɾ���ӹ�����ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteProcessContentAchievementRate(long processContentAchievementId) 
        {
            processContentAchievementRateDao.Delete(processContentAchievementId);
        }
        #endregion
    }
}
