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


        /// <summary>
        /// 名    称; GetItem
        /// 功能概要: 获取配置信息
        /// 作    者: 白晓宇
        /// 创建时间: 2010年7月1日
        /// </summary>
        /// <param name="proteryId"></param>
        ApplicationProperty GetItem(string proteryId);
    }
}
