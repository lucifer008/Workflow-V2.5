using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
/// <summary>
/// 名    称: PermissionDaoImpl
/// 功能概要: 操作接口IPermissionDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table PERMISSION 对应的Dao 实现
	/// </summary>
    public class PermissionDaoImpl : Workflow.Da.Base.DaoBaseImpl<Permission>, IPermissionDao
    {

        #region 通过权限组id获取唯一的一个权限许可id
        /// <summary>
        /// 通过权限组id获取唯一的一个权限许可id
        /// </summary>
        /// <param name="permissionGroupId">permissionGroupId</param>
        /// <returns></returns>
        public long GetPermissionIdByPermissionGroupId(long permissionGroupId)
        {
            Hashtable codition = new Hashtable();
            codition.Add("permissionGroupId", permissionGroupId);
            codition.Add("BranchShopId", Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            codition.Add("CompanyId", Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            return sqlMap.QueryForObject<long>("Permission.GetPermissionIdByPermissionGroupId", codition);
        }

        #endregion

        #region //添加新操作
        /// <summary>
        /// 添加新操作
        /// </summary>
        /// <param name="permission"></param>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月12日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public void AddPermissionInfo(Permission permission) 
        {
            this.Insert(permission);
        }
        #endregion

        #region //获取操作名称列表
        /// <summary>
        /// 获取操作名称列表 
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月12日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public IList<Permission> SearchPermissionInfo(Permission permission) 
        {
            permission.ComId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            permission.BranId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Permission>("Permission.SearchPermissionInfo", permission);
        }
        #endregion

        #region //获取操作名称列表个数
        /// <summary>
        /// 获取操作名称列表个数
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月12日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public long SearchPermissionInfoRowCount(Permission permission) 
        {
            permission.ComId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            permission.BranId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("Permission.SearchPermissionInfoRowCount", permission);
        }
        #endregion

        #region //根据操作Id删除操作信息
        /// <summary>
        /// 根据操作Id删除操作信息
        /// </summary>
        /// <param name="permissionId"></param>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月16日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public void DeletePermissionInfo(long permissionId) 
        {
            Permission permission = new Permission();
            permission.Id = permissionId;
            permission.ComId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            permission.BranId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.Delete("Permission.DeletePermissionInfo", permission);
        }
        #endregion

        #region //根据操作Id更新操作信息
        /// <summary>
        /// 根据操作Id更新操作信息
        /// </summary>
        /// <param name="permissionId"></param>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月16日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public void UpdatePermissionInfo(Permission permission) 
        {
            permission.ComId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            permission.BranId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.Update("Permission.UpdatePermissionInfo", permission);
        }
        #endregion


        public IList<Permission> GetBranchShopPermission()
        {
            Permission permission = new Permission();
            permission.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            permission.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;

            return sqlMap.QueryForList<Permission>("Permission.GetBranchShopPermission", permission);
        }

    }
}
