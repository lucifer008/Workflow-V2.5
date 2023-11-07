using System;
using System.Collections.Generic;
using System.Text;

namespace Workflow.Support.Attributes
{
    /// <summary>
    /// 名    称: DeletePermissionAttribute
    /// 功能概要: 用作拦截器的属性切入点 (用户检查是否有删除权限)
    /// 作    者: 付强
    /// 创建时间: 2008-12-4
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    [Serializable]
    public class DeletePermissionAttribute:Attribute
    {
    }
}
