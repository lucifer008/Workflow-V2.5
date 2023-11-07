using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table TRASH_REASON 对应的Dao 实现
	/// </summary>
    public class TrashReasonDaoImpl : Workflow.Da.Base.DaoBaseImpl<TrashReason>, ITrashReasonDao
    {
        #region//废张原因
        /// <summary>
        /// 名   称:  SearchTrashReason
        /// 功能概要: 获取废张原因列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<TrashReason> SearchTrashReason(TrashReason trashReason) 
        {
            trashReason.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            trashReason.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<TrashReason>("TrashReason.SearchTrashReason", trashReason);
        }

        /// <summary>
        /// 名   称:  SearchTrashReasonRowCount
        /// 功能概要: 获取废张原因列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchTrashReasonRowCount(TrashReason trashReason) 
        {
            return sqlMap.QueryForObject<long>("TrashReason.SearchTrashReasonRowCount", trashReason);
        }

        /// <summary>
        /// 名   称:  CheckTrashReasonIsUse
        /// 功能概要: 检查废张原因是否正在使用
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月2日10:29:05
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long CheckTrashReasonIsUse(long trashReasonId) 
        {
            TrashReason trashReason = new TrashReason();
            trashReason.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            trashReason.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            trashReason.Id = trashReasonId;
            return sqlMap.QueryForObject<long>("TrashReason.CheckTrashReasonIsUse", trashReason);
        }
        #endregion
    }
}
