using System;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service
{
    /// <summary>
    /// 名    称: Workflow.Service.Impl.IApplicationProperty
    /// 功能概要: 提供系统配置信息
    /// 作    者: 祝新宾
    /// 创建时间: 2007-9-21
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public interface IApplicationProperty
    {
        /// <summary>
        /// 根据指定的key获取相应的信息
        /// </summary>
		/// <remarks>
		/// 作    者: 祝新宾
		/// 创建时间: 2007-9-21
		/// 修正履历:
		/// 修正时间:
		/// </remarks>
        string GetProperty(string key);

		int GetConcessionPriceBaseRange();

        /// <summary>
        /// 获取预付款限制方式
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        string GetPrePayLimit();
    }
}
