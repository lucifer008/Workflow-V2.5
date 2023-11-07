using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table APPLICATION_PROPERTIES ��Ӧ��Dao ʵ��
	/// </summary>
    public class ApplicationPropertyDaoImpl : Workflow.Da.Base.DaoBaseImpl<ApplicationProperty>, IApplicationPropertyDao
    {

		#region IApplicationPropertyDao ��Ա

        /// <summary>
        /// ���ݲ���Id��ȡ����ֵ
        /// </summary>
        /// <param name="key">����Id</param>
        /// <returns></returns>
        /// <remarks>
        /// ����: 
        /// ����: 
        /// ��������: ������ �ӹ�˾��ֵ��ѯ����
        /// ����ʱ��: 2010��4��26��15:47:49
        /// </remarks>
		public string GetValue(string key)
		{
            ApplicationProperty applicationProperty = new ApplicationProperty();
            applicationProperty.PropertyId = key;
            applicationProperty.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            applicationProperty.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject("ApplicationProperty.GetValue", applicationProperty) as string;
		}

		#endregion

        #region//Ӧ�ò���ά��
        /// <summary>
        /// ��   ��:  SearchApplictionPeroptery
        /// ���ܸ�Ҫ: ��ȡӦ�ò�����Ϣ�б�
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��10:49:29
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<ApplicationProperty> SearchApplictionPeroptery(ApplicationProperty applicationProperty) 
        {
            applicationProperty.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            applicationProperty.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<ApplicationProperty>("ApplicationProperty.SearchApplictionPeroptery",applicationProperty);
        }

        /// <summary>
        /// ��   ��:  SearchApplictionPeropteryRowCount
        /// ���ܸ�Ҫ: ��ȡӦ�ò�����Ϣ�б��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��10:49:29
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public long SearchApplictionPeropteryRowCount(ApplicationProperty applicationProperty) 
        {
            return sqlMap.QueryForObject<long>("ApplicationProperty.SearchApplictionPeropteryRowCount", applicationProperty); ;
        }

        /// <summary>
        /// ��    �ƣ�DeletePropertyData
        /// ���ܸ�Ҫ��ɾ��Ӧ�ó������
        /// ��    ��: ������
        /// ����ʱ��: 2009��6��8��13:52:10
        /// ��������:
        /// ����ʱ�䣺
        /// </summary>
        public void DeletePropertyData(string proteryId) 
        {
            ApplicationProperty applicationProperty = new ApplicationProperty();
            applicationProperty.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            applicationProperty.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            applicationProperty.PropertyId = proteryId;
            sqlMap.Delete("ApplicationProperty.DeletePropertyData", applicationProperty);
        }
        #endregion

        /// <summary>
        /// ��    ��; GetItem
        /// ���ܸ�Ҫ: ��ȡ������Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2010��7��1��
        /// </summary>
        /// <param name="proteryId"></param>
        public ApplicationProperty GetItem(string proteryId)
        {

            ApplicationProperty applicationProperty = new ApplicationProperty();
            User currentUser = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser;

            applicationProperty.BranchShopId = currentUser.BranchShopId;
            applicationProperty.CompanyId = currentUser.CompanyId;
            applicationProperty.PropertyId = proteryId;

            return sqlMap.QueryForObject<ApplicationProperty>("ApplicationProperty.SelectItem", applicationProperty);
        }
	}
}
