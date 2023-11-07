using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Util
{
    /// <summary>
    /// 名    称: Workflow.Util.StringUtils
    /// 功能概要:
    /// 作    者: 祝新宾
    /// 创建时间: 2007-9-16
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public class StringUtils
    {
        /// <summary>
        /// 名    称: Workflow.Util.StringUtils.IsEmpty
        /// 功能概要: 检查指定的字符串是否为空。
        /// 作    者: 祝新宾
        /// 创建时间: 2007-9-16
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public static bool IsEmpty(String value)
        {
            return (value == null || value == "" || value.ToLower()=="undefined");
        }
    }
}
