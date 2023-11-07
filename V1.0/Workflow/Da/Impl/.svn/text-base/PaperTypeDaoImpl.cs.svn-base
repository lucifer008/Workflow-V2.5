using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名   称: PaperTypeDaoImpl
    /// 功能概要:纸质操作接口实现
    /// 作    者:
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class PaperTypeDaoImpl : Workflow.Da.Base.DaoBaseImpl<PaperType>, IPaperTypeDao
    {
        #region //纸质
        /// <summary>
        /// 名    称: SearchPaperType
        /// 功能概要: 获取纸质列表
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日9:53:28
        /// 修正时间:
        /// </summary>
        public IList<PaperType> SearchPaperType(PaperType paperType) 
        {
            paperType.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            paperType.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<PaperType>("PaperType.SearchPaperType", paperType);
        }

        /// <summary>
        /// 名    称: SearchPaperTypeRowCount
        /// 功能概要: 获取纸质记录数
        /// 作    者：张晓林
        /// 创建时间: 2009年5月6日9:53:28
        /// 修正时间:
        /// </summary>
        public long SearchPaperTypeRowCount(PaperType paperType) 
        {
            return sqlMap.QueryForObject<long>("PaperType.SearchPaperTypeRowCount", paperType);
        }

        #endregion	
    }
}
