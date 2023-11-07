using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// ��    ��: IPermissionDao
/// ���ܸ�Ҫ: �����ӿ�IPermissionDaoʵ����
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table PERMISSION ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IPermissionDao : IDaoBase<Permission>
    {
        /// <summary>
        /// ͨ��Ȩ����id��ȡΨһ��һ��Ȩ�����id
        /// </summary>
        /// <param name="permissionGroupId">permissionGroupId</param>
        /// <returns></returns>
        long GetPermissionIdByPermissionGroupId(long permissionGroupId);
	/// <summary>
        /// ��Ӳ�������
        /// </summary>
        /// <param name="permission"></param>
        void AddPermissionInfo(Permission permission);

        /// <summary>
        /// ��ȡ���������б� 
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        IList<Permission> SearchPermissionInfo(Permission permission);

        /// <summary>
        /// ��ȡ���������б����
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
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

        IList<Permission> GetBranchShopPermission();
    }
  	
}
