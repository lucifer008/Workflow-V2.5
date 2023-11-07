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

        /// <summary>
        /// 根据参数Id获取参数值
        /// </summary>
        /// <param name="key">参数Id</param>
        /// <returns></returns>
        /// <remarks>
        /// 作者: 
        /// 日期: 
        /// 修正履历: 张晓林 加公司与分店查询条件
        /// 修正时间: 2010年4月26日15:47:49
        /// </remarks>
		public string GetValue(string key)
		{
            ApplicationProperty applicationProperty = new ApplicationProperty();
            applicationProperty.PropertyId = key;
            applicationProperty.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            applicationProperty.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject("ApplicationProperty.GetValue", applicationProperty) as string;
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

        /// <summary>
        /// 名    称; GetItem
        /// 功能概要: 获取配置信息
        /// 作    者: 白晓宇
        /// 创建时间: 2010年7月1日
        /// </summary>
        /// <param name="proteryId"></param>
        public ApplicationProperty GetItem(string proteryId)
        {

            ApplicationProperty applicationProperty = new ApplicationProperty();
            User currentUser = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser;

            applicationProperty.BranchShopId = currentUser.BranchShopId;
            applicationProperty.CompanyId = currentUser.CompanyId;
            applicationProperty.PropertyId = proteryId;

            return sqlMap.QueryForObject<ApplicationProperty>("ApplicationProperty.SelectItem", applicationProperty);
        }
	}
}
