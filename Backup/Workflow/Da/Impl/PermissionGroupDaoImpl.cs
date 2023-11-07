using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table PERMISSION_GROUP 对应的Dao 实现
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

        #region//权限组操作

        /// <summary>
        /// 获取权限组列表
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<PermissionGroup> GetPermissionGroup(PermissionGroup permissionGroup) 
        {
            permissionGroup.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            permissionGroup.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PermissionGroup>("PermissionGroup.GetPermissionGroup", permissionGroup);
        }

        /// <summary>
        /// 获取权限组列表记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long GetPermissionGroupRowCount(PermissionGroup permissionGroup) 
        {
            return sqlMap.QueryForObject<long>("PermissionGroup.GetPermissionGroupRowCount", permissionGroup);
        }

        /// <summary>
        /// 检查权限组是否正在使用
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
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
        /// 修改权限组
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月15日10:21:32
        /// 修正履历:
        /// 修正时间:
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
