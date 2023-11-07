using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.SystemMaintenance.OrderBaseData
{
    /// <summary>
    /// ��    ��: ISearchOrderBaseDataService
    /// ���ܸ�Ҫ: ��ȡ�����������ݽӿ�
    /// ��    ��: ������
    /// ����ʱ��: 2009��4��29��17:22:33
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public interface ISearchOrderBaseDataService
    {
        #region//�ͻ�����
        /// <summary>
        /// ��   ��:  SearchCustomerLevel
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<CustomerLevel> SearchCustomerLevel(CustomerLevel customerLevel); 

        /// <summary>
        /// ��   ��:  SearchCustomerLevelRowCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchCustomerLevelRowCount(CustomerLevel customerLevel);

        /// <summary>
        /// ��   ��:  CheckCustomerLevelIsUse
        /// ���ܸ�Ҫ: ���ͻ������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��11:35:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckCustomerLevelIsUse(long customerLevelId);
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
        IList<CustomerType> SearchCustomerType(CustomerType customerType);

        /// <summary>
        /// ��   ��:  SearchCustomerTypeRowCount
        /// ���ܸ�Ҫ: ��ȡ�ͻ������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��10:04:46
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchCustomerTypeRowCount(CustomerType customerType);

        /// <summary>
        /// ��   ��:  CheckCustomerTypeIsUse
        /// ���ܸ�Ҫ: ���ͻ������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��19��11:35:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckCustomerTypeIsUse(long customerTypeId);
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
       IList<MasterTrade> SearchMasterTrade(MasterTrade masterTrade);

       /// <summary>
       /// ��   ��:  SearchMasterTradeRowCount
       /// ���ܸ�Ҫ: ��ȡ������ҵ�б����
       /// ��    ��: ������
       /// ����ʱ��: 2009��5��20��10:20:39
       /// ��������:
       /// ����ʱ��:
       /// </summary>
       long SearchMasterTradeRowCount(MasterTrade masterTrade);

       /// <summary>
       /// ��   ��:  SearchMasterTrade
       /// ���ܸ�Ҫ: ��ȡ�ͻ�����ҵ�б�
       /// ��    ��: ������
       /// ����ʱ��: 2009��5��20��10:20:39
       /// ��������:
       /// ����ʱ��:
       /// </summary>
       IList<SecondaryTrade> SearchSecondaryTrade(SecondaryTrade secondaryTrade);

       /// <summary>
       /// ��   ��:  SearchMasterTradeRowCount
       /// ���ܸ�Ҫ: ��ȡ�ͻ�����ҵ�б����
       /// ��    ��: ������
       /// ����ʱ��: 2009��5��20��10:20:39
       /// ��������:
       /// ����ʱ��:
       /// </summary>
       long SearchSecondaryTradeRowCount(SecondaryTrade secondaryTrade);

       /// <summary>
       /// ��   ��:  CheckMasterTradeIsUse
       /// ���ܸ�Ҫ: ���ͻ��ͻ�����ҵ�Ƿ�����ʹ��
       /// ��    ��: ������
       /// ����ʱ��: 2009��5��20��11:48:22
       /// ��������:
       /// ����ʱ��:
       /// </summary>
       long CheckMasterTradeIsUse(long masterTradeId);

         /// <summary>
        /// ��   ��:  GetAllMasterTrade
        /// ���ܸ�Ҫ: ��ȡ��������ҵ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��22��9:51:12
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<MasterTrade> GetAllMasterTrade(); 
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
        IList<MemberCardLevel> SearchMemberCardLevel(MemberCardLevel memberCardLevel);

        /// <summary>
        /// ��   ��:  SearchMemberCardLevelRowCount
        /// ���ܸ�Ҫ: ��ȡ��Ա�������б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:52:43
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchMemberCardLevelRowCount(MemberCardLevel memberCardLevel);

        /// <summary>
        /// ��   ��:  CheckMemberCardLevelIsUse
        /// ���ܸ�Ҫ: ����Ա�������Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��10:58:02
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckMemberCardLevelIsUse(long memberCardLevelId);
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
        IList<PrintDemand> SearchPrintDemand(PrintDemand printDemand);

        /// <summary>
        /// ��   ��:  SearchPrintDemandRowCount
        /// ���ܸ�Ҫ: ��ȡӡ��Ҫ���б���Ŀ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchPrintDemandRowCount(PrintDemand printDemand);

         /// <summary>
        /// ��   ��:  SearchPrintDemandDetail
        /// ���ܸ�Ҫ: ��ȡӡ��Ҫ����ϸ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<PrintDemandDetail> SearchPrintDemandDetail(PrintDemandDetail printDemandDetail);

        /// <summary>
        /// ��   ��:  SearchPrintDemandDetailRowCount
        /// ���ܸ�Ҫ: ��ȡӡ��Ҫ����ϸ�б���Ŀ
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��11:49:00
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchPrintDemandDetailRowCount(PrintDemandDetail printDemandDetail);

         /// <summary>
        /// ��   ��:  GetAllPrintDemand
        /// ���ܸ�Ҫ: ��ȡ����ӡ��Ҫ���б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��17:47:10
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        IList<PrintDemand> GetAllPrintDemand();

        /// <summary>
        /// ��   ��:  CheckPrintDemandIsUse
        /// ���ܸ�Ҫ: ���ӡ��Ҫ���Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��26��17:49:14
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckPrintDemandIsUse(long printDemandId);
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
        IList<ReportLessMode> SearchReportLessMode(ReportLessMode reportLessMode);

        /// <summary>
        /// ��   ��:  SearchReportLessModeRowCount
        /// ���ܸ�Ҫ: ��ȡ��ʧ��ʽ�б����
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchReportLessModeRowCount(ReportLessMode reportLessMode);

         /// <summary>
        /// ��   ��:  CheckReportLessModeIsUse
        /// ���ܸ�Ҫ: ����ʧ��ʽ�Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��27��10:36:51
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckReportLessModeIsUse(long reportLessModeId); 
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
        IList<TrashReason> SearchTrashReason(TrashReason trashReason);

        /// <summary>
        /// ��   ��:  SearchTrashReasonRowCount
        /// ���ܸ�Ҫ: ��ȡ����ԭ���б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long SearchTrashReasonRowCount(TrashReason trashReason);

        /// <summary>
        /// ��   ��:  CheckTrashReasonIsUse
        /// ���ܸ�Ҫ: ������ԭ���Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��10:29:05
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        long CheckTrashReasonIsUse(long trashReasonId); 
        #endregion

        #region//�ӹ�����ҵ������
        /// <summary>
        /// ��    ��: GetAllProcessContent
        /// ���ܸ�Ҫ: ��ȡ���мӹ�����
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ����ʱ��:
        /// </summary>
        IList<ProcessContent> GetAllProcessContent(); 

        /// <summary>
        /// ��    ��: SearchProcessContentAchievementValue
        /// ���ܸ�Ҫ: ��ȡ�ӹ�����ҵ�������б� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ����ʱ��:
        /// </summary>
        IList<ProcessContentAchievementRate> SearchProcessContentAchievementValue(ProcessContentAchievementRate processContentAchievementRate);

        /// <summary>
        /// ��    ��: SearchProcessContentAchievementValueRowCount
        /// ���ܸ�Ҫ: ��ȡ�ӹ�����ҵ�������б��¼�� 
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��2��
        /// ����ʱ��:
        /// </summary>
        long SearchProcessContentAchievementValueRowCount(ProcessContentAchievementRate processContentAchievementRate);
        #endregion
    }
}
