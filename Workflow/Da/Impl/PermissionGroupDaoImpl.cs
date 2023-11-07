using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table PERMISSION_GROUP ��Ӧ��Dao ʵ��
	/// </summary>
    public class PermissionGroupDaoImpl : Workflow.Da.Base.DaoBaseImpl<PermissionGroup>, IPermissionGroupDao
    {
        public IList<PermissionGroup> GetBranchShopPermissionGroup()
        {
            PermissionGroup permissionGroup = new PermissionGroup();
            permissionGroup.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            permissionGroup.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PermissionGroup>("PermissionGroup.SelectBranchShop", permissionGroup);
        }

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
        public IList<PermissionGroup> GetPermissionGroup(PermissionGroup permissionGroup) 
        {
            permissionGroup.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            permissionGroup.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PermissionGroup>("PermissionGroup.GetPermissionGroup", permissionGroup);
        }

        /// <summary>
        /// ��ȡȨ�����б��¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public long GetPermissionGroupRowCount(PermissionGroup permissionGroup) 
        {
            return sqlMap.QueryForObject<long>("PermissionGroup.GetPermissionGroupRowCount", permissionGroup);
        }

        /// <summary>
        /// ���Ȩ�����Ƿ�����ʹ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public long CheckPermissionGroupIsUsed(long permissionGroupId) 
        {
            PermissionGroup permissionGroup = new PermissionGroup();
            permissionGroup.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            permissionGroup.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            permissionGroup.Id = permissionGroupId;
            long count=sqlMap.QueryForObject<long>("PermissionGroup.CheckPermissionGroupIsUsed", permissionGroup);
            return count += sqlMap.QueryForObject<long>("PermissionGroup.CheckPermissionGroupIsUsed1", permissionGroup);
        }

        /// <summary>
        /// �޸�Ȩ����
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��15��10:21:32
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void UpdatePermissionGroup(PermissionGroup permissionGroup) 
        {
            permissionGroup.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            permissionGroup.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            permissionGroup.UpdateDateTime = DateTime.Now;
            permissionGroup.UpdateUser = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
            permissionGroup.Version = ThreadLocalUtils.CurrentUserContext.CurrentUser.Version;
            sqlMap.Update("PermissionGroup.UpdatePermissionGroup", permissionGroup);
        }
        #endregion
        
    }
}
