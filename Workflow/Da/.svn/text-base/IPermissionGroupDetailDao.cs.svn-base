using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table PERMISSION_GROUP_DETAIL 对应的Dao 接口
	/// </summary>
    public interface IPermissionGroupDetailDao : IDaoBase<PermissionGroupDetail>
    {
    	/// <summary>
        /// 通过Permission.Id和PermissionGroupDetail.Id查询PermissionGroupDetail
        /// </summary>
        /// <param name="perGroupDetail">PermissionGroupDetail</param>
        /// <returns>PermissionGroupDetail</returns>
        PermissionGroupDetail GetPermissionGroupDetailByDoubleId(PermissionGroupDetail perGroupDetail);

        /// <summary>
        /// 通过PermissionGroup.Id删除PermissionGroupDetail中的信息
        /// </summary>
        /// <param name="id">PermissionGroup.Id</param>
        void DeleteByPermissionGroupId(long id);

        /// Add:Cry Date:2009.1.16
        /// <summary>
        /// 获取当前存在关系的权限组
        /// </summary>
        /// <returns>list</returns>
        IList<long> GetExistRelationPermissionGroup();
    }
}
