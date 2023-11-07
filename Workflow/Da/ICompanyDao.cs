using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table COMPANY ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface ICompanyDao : IDaoBase<Company>
    {
        #region//��˾��Ϣά��
        /// <summary>
        /// ��    �ƣ�SearchCompany
        /// ���ܸ�Ҫ����ȡ��˾��Ϣ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        IList<Company> SearchCompany(Company company);

        /// <summary>
        /// ��    �ƣ�SearchCompany
        /// ���ܸ�Ҫ����ȡ��˾��Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        long SearchCompanyRowCount(Company company);


        /// <summary>
        /// ��    �ƣ�CheckCompanyIsUsed
        /// ���ܸ�Ҫ����鹫˾�Ƿ�����ʹ��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��9��13:24:38
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        long CheckCompanyIsUsed(long companyId);
        #endregion
    }
}
