using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table REPORT_LESS_MODE ��Ӧ��Dao ʵ��
	/// </summary>
    public class ReportLessModeDaoImpl : Workflow.Da.Base.DaoBaseImpl<ReportLessMode>, IReportLessModeDao
    {
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
            reportLessMode.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            reportLessMode.BranchShopId= Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<ReportLessMode>("ReportLessMode.SearchReportLessMode", reportLessMode);
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
            return sqlMap.QueryForObject<long>("ReportLessMode.SearchReportLessModeRowCount", reportLessMode);
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
            ReportLessMode reportLessMode = new ReportLessMode();
            reportLessMode.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            reportLessMode.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            reportLessMode.Id = reportLessModeId;
            return sqlMap.QueryForObject<long>("ReportLessMode.CheckReportLessModeIsUse", reportLessMode);
        }
        #endregion
    }
}
