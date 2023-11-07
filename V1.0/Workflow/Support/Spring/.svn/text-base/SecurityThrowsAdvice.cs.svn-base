using System;
using System.Collections.Generic;
using System.Text;
using Spring.Aop;
using Workflow.Support.Security;
using System.Reflection;
using Workflow.Support.Exception;
using Workflow.Support.Log;

namespace Workflow.Support.Spring
{
    /// <summary>
    /// 名    称: SecurityThrowsAdvice
    /// 功能概要: 异常拦截通知
    /// 作    者: 付强
    /// 创建时间: 2008-12-4
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class SecurityThrowsAdvice:IThrowsAdvice
    {
        /// <summary>
        /// 访问被拒绝
        /// </summary>
        /// <param name="method"></param>
        /// <param name="args"></param>
        /// <param name="target"></param>
        /// <param name="ex"></param>
        public void AfterThrowing(MethodInfo method, object[] args, object target, PermissionDeniedException ex)
        {
            StringBuilder errMsg = new StringBuilder();
            errMsg.Append(ThreadLocalUtils.CurrentUserContext.CurrentUser.UserName);
            errMsg.Append("(");
            errMsg.Append(ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeName);
            errMsg.Append(")");
            errMsg.Append(" 在 ");
            errMsg.Append(DateTime.Now.ToString());
            errMsg.Append(" 访问 ");
            errMsg.Append(method.Name);
            errMsg.Append(" 时被拒绝！");
            LogHelper.WriteError(new System.Exception(errMsg.ToString()), Constants.LOGGER_NAME);
        }
        /// <summary>
        /// 其他异常
        /// </summary>
        /// <param name="ex"></param>
        public void AfterThrowing(System.Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }

    }
}
