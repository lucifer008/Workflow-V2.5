using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table APPLICATION_PROPERTIES 对应的Dao 接口
	/// </summary>
    public interface IApplicationPropertyDao : IDaoBase<ApplicationProperty>
    {
		string GetValue(string key);

        #region//应用参数维护
        /// <summary>
        /// 名   称:  SearchApplictionPeroptery
        /// 功能概要: 获取应用参数信息列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日10:49:29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        IList<ApplicationProperty> SearchApplictionPeroptery(ApplicationProperty applicationProperty);

        /// <summary>
        /// 名   称:  SearchApplictionPeropteryRowCount
        /// 功能概要: 获取应用参数信息列表记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日10:49:29
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        long SearchApplictionPeropteryRowCount(ApplicationProperty applicationProperty);

        /// <summary>
        /// 名    称：DeletePropertyData
        /// 功能概要：删除应用程序参数
        /// 作    者: 张晓林
        /// 创建时间: 2009年6月8日13:52:10
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        void DeletePropertyData(string proteryId);
        #endregion
    }
}
