using System;
using System.Collections.Generic;
using Workflow.Da.Domain;
/// <summary>
/// ���ܸ�Ҫ: ���� Service �ӿ�
/// ��    ��: ������
/// ����ʱ��: 2009-2-04
/// �� �� ��: 
/// ����ʱ��: 
/// ��������: 
/// </summary>
namespace Workflow.Service.SystemPermission.PermissionManage
{
    public interface IPermissionService
    {
        /// <summary>
        /// ����²���
        /// </summary>
        /// <param name="permission"></param>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��16��
        /// ��������:
        /// ������:
        /// </remarks>
        void AddPermissionInfo(Permission permission);

        /// <summary>
        /// ��ȡ���������б� 
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��16��
        /// ��������:
        /// ������:
        /// </remarks>
        IList<Permission> SearchPermissionInfo(Permission permission);

        /// <summary>
        /// ��ȡ���������б����
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��16��
        /// ��������:
        /// ������:
        /// </remarks>
        long SearchPermissionInfoRowCount(Permission permission);

        /// <summary>
        /// ���ݲ���Idɾ��������Ϣ
        /// </summary>
        /// <param name="permissionId"></param>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��16��
        /// ��������:
        /// ������:
        /// </remarks>
        void DeletePermissionInfo(long permissionId);

        /// <summary>
        /// ���ݲ���Id���²�����Ϣ
        /// </summary>
        /// <param name="permissionId"></param>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��16��
        /// ��������:
        /// ������:
        /// </remarks>
        void UpdatePermissionInfo(Permission permission);

        #region//Ȩ�������

        /// <summary>
        /// ���Ȩ����
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void AddPermissionGroup(PermissionGroup permissionGroup);

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
        /// ɾ��Ȩ�����б�
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��14:17:56
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void LogicDeletePermissionGroup(PermissionGroup permissionGroup);
        #endregion
    }
}
