using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// ��     ��:PaperSpecificationDaoImpl
    /// ���ܸ�Ҫ:IPaperSpecification�ӿ�ʵ��
    /// ��    ��:
    /// ����ʱ��:
    /// ��������:
    /// ����ʱ��:
    /// </summary>
    public class PaperSpecificationDaoImpl : Workflow.Da.Base.DaoBaseImpl<PaperSpecification>, IPaperSpecificationDao
    {
        #region //��ȡֽ������
        /// <summary>
        /// ��    ��: SearchPaperSecification
        /// ���ܸ�Ҫ: ��ȡֽ���б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��5��15:15:30
        /// ����ʱ��:
        /// </summary>
        public IList<PaperSpecification> SearchPaperSecification(PaperSpecification paperSpecification)
        {
            paperSpecification.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            paperSpecification.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PaperSpecification>("PaperSpecification.SearchPaperSecification", paperSpecification);
        }

        /// <summary>
        /// ��    ��: SearchPaperSecificationRowCount
        /// ���ܸ�Ҫ: ��ȡֽ�ͼ�¼�� 
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��5��5��15:15:30
        /// ����ʱ��:
        /// </summary>
        public long SearchPaperSecificationRowCount(PaperSpecification paperSpecification) 
        {
            return sqlMap.QueryForObject<long>("PaperSpecification.SearchPaperSecificationRowCount", paperSpecification);
        }
        #endregion
    }
}
