using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table APPLICATION_PROPERTIES 对应的Dao 实现
	/// </summary>
    public class ApplicationPropertyDaoImpl : Workflow.Da.Base.DaoBaseImpl<ApplicationProperty>, IApplicationPropertyDao
    {

		#region IApplicationPropertyDao 成员

		public string GetValue(string key)
		{
			return sqlMap.QueryForObject("ApplicationProperty.GetValue", key) as string;
		}

		#endregion

        #region//应用参数维护
        /// <summary>
        /// 名   称:  SearchApplictionPeroptery
        /// 功能概要: 获取应用参数信息列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日10:49:29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<ApplicationProperty> SearchApplictionPeroptery(ApplicationProperty applicationProperty) 
        {
            applicationProperty.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            applicationProperty.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<ApplicationProperty>("ApplicationProperty.SearchApplictionPeroptery",applicationProperty);
        }

        /// <summary>
        /// 名   称:  SearchApplictionPeropteryRowCount
        /// 功能概要: 获取应用参数信息列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日10:49:29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long SearchApplictionPeropteryRowCount(ApplicationProperty applicationProperty) 
        {
            return sqlMap.QueryForObject<long>("ApplicationProperty.SearchApplictionPeropteryRowCount", applicationProperty); ;
        }

        /// <summary>
        /// 名    称：DeletePropertyData
        /// 功能概要：删除应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void DeletePropertyData(string proteryId) 
        {
            ApplicationProperty applicationProperty = new ApplicationProperty();
            applicationProperty.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            applicationProperty.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            applicationProperty.PropertyId = proteryId;
            sqlMap.Delete("ApplicationProperty.DeletePropertyData", applicationProperty);
        }
        #endregion
	}
}
