using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using Workflow.Support.Ajax;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Support;
using Workflow.Service.SystemPermission.UserMangae;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: CheckUserIsNotUseAjax
    /// 功能概要: 通过用户Id检查改用户是否正在使用
    /// 作    者: 张晓林
    /// 创建时间: 2009-01-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class CheckUserIsNotUseAjax:AjaxProcess
    {
        private IUserService userService;
        public IUserService UserService 
        {
            set { userService = value; }
        }
        public string DoProcess(NameValueCollection parameters)
        {
            long isHave =0;
            try
            {
                if (null == parameters["UserId"] || "" == parameters["UserId"]) return null;
                string userId = parameters["UserId"];
                User user = new User();
                user.Id = Convert.ToInt32(userId);
                isHave = userService.SearchDeleteUserIsUse(user);
                return Convert.ToString(isHave);
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }
    }
}
