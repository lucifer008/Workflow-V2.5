using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: IPermissionDao
/// 功能概要: 操作接口IPermissionDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table PERMISSION 对应的Dao 接口
	/// </summary>
    public interface IPermissionDao : IDaoBase<Permission>
    {
        /// <summary>
        /// 通过权限组id获取唯一的一个权限许可id
        /// </summary>
        /// <param name="permissionGroupId">permissionGroupId</param>
        /// <returns></returns>
        long GetPermissionIdByPermissionGroupId(long permissionGroupId);
	/// <summary>
        /// 添加操作名称
        /// </summary>
        /// <param name="permission"></param>
        void AddPermissionInfo(Permission permission);

        /// <summary>
        /// 获取操作名称列表 
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        IList<Permission> SearchPermissionInfo(Permission permission);

        /// <summary>
        /// 获取操作名称列表个数
        /// </summary>
        /// <param name="permission"></param>
        /// <returns></returns>
        long SearchPermissionInfoRowCount(Permission permission);
 
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
        void DeletePermissionInfo(long permissionId); 

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
        void UpdatePermissionInfo(Permission permission);

        IList<Permission> GetBranchShopPermission();
    }
  	
}
