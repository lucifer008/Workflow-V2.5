using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table PERMISSION_GROUP_DETAIL 对应的Dao 实现
	/// </summary>
    public class PermissionGroupDetailDaoImpl : Workflow.Da.Base.DaoBaseImpl<PermissionGroupDetail>, IPermissionGroupDetailDao
    {
        /// <summary>
        /// 通过Permission.Id和PermissionGroupDetail.Id查询PermissionGroupDetail
        /// </summary>
        /// <param name="perGroupDetail">PermissionGroupDetail</param>
        /// <returns>PermissionGroupDetail</returns>
        public PermissionGroupDetail GetPermissionGroupDetailByDoubleId(PermissionGroupDetail perGroupDetail)
        {
            return sqlMap.QueryForObject<PermissionGroupDetail>("PermissionGroupDetail.GetPermissionGroupDetailByDoubleId", perGroupDetail);
        }

        /// <summary>
        /// 通过PermissionGroup.Id删除PermissionGroupDetail中的信息
        /// </summary>
        /// <param name="id">PermissionGroup.Id</param>
        public void DeleteByPermissionGroupId(long id)
        {
            sqlMap.Delete("PermissionGroupDetail.DeleteByPermissionGroupId", id);
        }

        #region 获取当前存在关系的权限组

        /// Add:Cry Date:2009.1.16
        /// <summary>
        /// 获取当前存在关系的权限组
        /// </summary>
        /// <returns>list</returns>
        public IList<long> GetExistRelationPermissionGroup()
        {
            return sqlMap.QueryForList<long>("PermissionGroupDetail.GetExistRelationPermissionGroup",null);
        }

        #endregion
    }
}
