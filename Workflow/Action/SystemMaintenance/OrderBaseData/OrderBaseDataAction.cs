using System;
using System.Collections.Generic;
using Workflow.Service.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

namespace Workflow.Action.SystemMaintenance.OrderBaseData
{
    /// <summary>
    /// ��   ��:  OrderBaseDataAction
    /// ���ܸ�Ҫ: ������������ά��Action
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:02:07
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public class OrderBaseDataAction
    {
        #region//ClassMember
        private IOrderBaseDataService orderBaseDataService;
        public IOrderBaseDataService OrderBaseDataService 
        {
            set { orderBaseDataService = value; }
        }

        private OrderBaseDataModel model = new OrderBaseDataModel();
        public OrderBaseDataModel Model
        {
            set { model = value; }
            get { return model; }
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
        public void AddCustomerLevel() 
        {
            orderBaseDataService.AddCustomerLevel(model.CustomerLevel);
        }

        /// <summary>
        /// ��   ��:  UpdateCustomerLevel
        /// ���ܸ�Ҫ: ���¿ͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateCustomerLevel()
        {
            orderBaseDataService.UpdateCustomerLevel(model.CustomerLevel);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteCustomerLevel
        /// ���ܸ�Ҫ: �߼�ɾ���ͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteCustomerLevel()
        {
            orderBaseDataService.LogicDeleteCustomerLevel(model.CustomerLevel.Id);
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
        public void AddCustomerType()
        {
            orderBaseDataService.AddCustomerType(model.CustomerType);
        }

        /// <summary>
        /// ��   ��:  UpdateCustomerType
        /// ���ܸ�Ҫ: ���¿ͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateCustomerTypel()
        {
            orderBaseDataService.UpdateCustomerType(model.CustomerType);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteCustomerType
        /// ���ܸ�Ҫ: �߼�ɾ���ͻ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��9:47:16
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteCustomerType()
        {
            orderBaseDataService.LogicDeleteCustomerType(model.CustomerType.Id);
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
        public void AddMasterTrade()
        {
            orderBaseDataService.AddMasterTrade(model.MasterTrade);
        }

        /// <summary>
        /// ��   ��:  UpdateMasterTrade
        /// ���ܸ�Ҫ: ���¿ͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateMasterTrade()
        {
            orderBaseDataService.UpdateMasterTrade(model.MasterTrade);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteMasterTrade
        /// ���ܸ�Ҫ: �߼�ɾ���ͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteMasterTrade()
        {
            orderBaseDataService.LogicDeleteMasterTrade(model.MasterTrade.Id);
        }

        /// <summary>
        /// ��   ��:  AddSeondaryTrade
        /// ���ܸ�Ҫ: ��ӿͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddSecondaryTrade()
        {
            orderBaseDataService.AddSecondaryTrade(model.SecondaryTrade);
        }

        /// <summary>
        /// ��   ��:  UpdateSecondaryTrade
        /// ���ܸ�Ҫ: ���¿ͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateSecondaryTrade()
        {
            orderBaseDataService.UpdateSecondaryTrade(model.SecondaryTrade);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteSecondaryTrade
        /// ���ܸ�Ҫ: �߼�ɾ���ͻ�����ҵ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��9:56:25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteSecondaryTrade()
        {
            orderBaseDataService.LogicDeleteSecondaryTrade(model.SecondaryTrade.Id);
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
        public void AddMemberCardLevel() 
        {
            orderBaseDataService.AddMemberCardLevel(model.MemberCardLevel);
        }

        /// <summary>
        /// ��   ��:  UpdateMemberCardLevel
        /// ���ܸ�Ҫ: ���»�Ա������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:42:04
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateMemberCardLevel()
        {
            orderBaseDataService.UpdateMemberCardLevel(model.MemberCardLevel);
        }

        /// <summary>
        /// ��   ��:  UpdateMemberCardLevel
        /// ���ܸ�Ҫ: ���»�Ա������
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:42:04
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteMemberCardLevel()
        {
            orderBaseDataService.LogicDeleteMemberCardLevel(model.MemberCardLevel.Id);
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
        public void AddPrintDemand()
        {
            orderBaseDataService.AddPrintDemand(model.PrintDemand);
        }

        /// <summary>
        /// ��   ��:  UpdatePrintDemand
        /// ���ܸ�Ҫ: ����ӡ��Ҫ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��13:46:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdatePrintDemand()
        {
            orderBaseDataService.UpdatePrintDemand(model.PrintDemand);
        }

        /// <summary>
        /// ��   ��:  LogicDeletePrintDemand
        /// ���ܸ�Ҫ: �߼�ɾ��ӡ��Ҫ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��13:46:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeletePrintDemand()
        {
            orderBaseDataService.LogicDeletePrintDemand(model.PrintDemand.Id);
        }

         /// <summary>
        /// ��   ��:  AddPrintDemandDetail
        /// ���ܸ�Ҫ: ���ӡ��Ҫ����ϸ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void AddPrintDemandDetail() 
        {
            orderBaseDataService.AddPrintDemandDetail(model.PrintDemandDetail);
        }

        /// <summary>
        /// ��   ��:  UpdatePrintDemandDetail
        /// ���ܸ�Ҫ: ����ӡ��Ҫ����ϸ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdatePrintDemandDetail()
        {
            orderBaseDataService.UpdatePrintDemandDetail(model.PrintDemandDetail);
        }

        /// <summary>
        /// ��   ��:  LogicDeletePrintDemandDetail
        /// ���ܸ�Ҫ: �߼�ɾ��ӡ��Ҫ����ϸ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeletePrintDemandDetail()
        {
            orderBaseDataService.LogicDeletePrintDemandDetail(model.PrintDemandDetail.Id);
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
        public void AddReportLessMode()
        {
            orderBaseDataService.AddReportLessMode(model.ReportLessMode);
        }

        /// <summary>
        /// ��   ��:  UpdateReportLessMode
        /// ���ܸ�Ҫ: �޸Ĺ�ʧ��ʽ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��11:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateReportLessMode()
        {
            orderBaseDataService.UpdateReportLessMode(model.ReportLessMode);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteReportLessMode
        /// ���ܸ�Ҫ: �߼�ɾ����ʧ��ʽ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��11:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteReportLessMode()
        {
            orderBaseDataService.LogicDeleteReportLessMode(model.ReportLessMode.Id);
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
        public void AddTrashReason()
        {
            orderBaseDataService.AddTrashReason(model.TrashReason);
        }

        /// <summary>
        /// ��   ��:  UpdateTrashReason
        /// ���ܸ�Ҫ: �޸ķ���ԭ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateTrashReason()
        {
            orderBaseDataService.UpdateTrashReason(model.TrashReason);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteTrashReason
        /// ���ܸ�Ҫ: �߼�ɾ������ԭ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:22:45
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteTrashReason()
        {
            orderBaseDataService.LogicDeleteTrashReason(model.TrashReason.Id);
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
        public void AddProcessContentAchievementRate() 
        {
            orderBaseDataService.AddProcessContentAchievementRate(model.ProcessContentAchievementRate);
        }

        /// <summary>
        /// ��   ��:  UpdateProcessContentAchievementRate
        /// ���ܸ�Ҫ: �޸ļӹ�����ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void UpdateProcessContentAchievementRate()
        {
            orderBaseDataService.UpdateProcessContentAchievementRate(model.ProcessContentAchievementRate);
        }

        /// <summary>
        /// ��   ��:  LogicDeleteProcessContentAchievementRate
        /// ���ܸ�Ҫ: �߼�ɾ���ӹ�����ҵ������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void LogicDeleteProcessContentAchievementRate()
        {
            orderBaseDataService.LogicDeleteProcessContentAchievementRate(model.ProcessContentAchievementRate.Id);
        }
        #endregion
    }
}
