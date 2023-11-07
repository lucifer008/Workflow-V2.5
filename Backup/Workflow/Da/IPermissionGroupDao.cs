using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Da
{
	/// <summary>
	/// Table PERMISSION_GROUP ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IPermissionGroupDao : IDaoBase<PermissionGroup>
    {
        IList<PermissionGroup> GetBranchShopPermissionGroup();

        #region//Ȩ�������

        /// <summary>
        /// ��ȡȨ�����б�
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<PermissionGroup> GetPermissionGroup(PermissionGroup permissionGroup);

        /// <summary>
        /// ��ȡȨ�����б��¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        long GetPermissionGroupRowCount(PermissionGroup permissionGroup);

        /// <summary>
        /// ���Ȩ�����Ƿ�����ʹ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        long CheckPermissionGroupIsUsed(long permissionGroupId);

        /// <summary>
        /// �޸�Ȩ����
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void UpdatePermissionGroup(PermissionGroup permissionGroup); 
        #endregion
    }
}
