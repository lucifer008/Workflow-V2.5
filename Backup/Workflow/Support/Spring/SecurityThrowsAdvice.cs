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
    /// ��    ��: SecurityThrowsAdvice
    /// ���ܸ�Ҫ: �쳣����֪ͨ
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2008-12-4
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public class SecurityThrowsAdvice:IThrowsAdvice
    {
        /// <summary>
        /// ���ʱ��ܾ�
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
            errMsg.Append(" �� ");
            errMsg.Append(DateTime.Now.ToString());
            errMsg.Append(" ���� ");
            errMsg.Append(method.Name);
            errMsg.Append(" ʱ���ܾ���");
            LogHelper.WriteError(new System.Exception(errMsg.ToString()), Constants.LOGGER_NAME);
        }
        /// <summary>
        /// �����쳣
        /// </summary>
        /// <param name="ex"></param>
        public void AfterThrowing(System.Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }

    }
}
