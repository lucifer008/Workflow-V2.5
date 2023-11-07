using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support;
using Workflow.Support.Ajax;
using Workflow.Util;
using Workflow.Support.Encrypt;
using Workflow.Support.Log;

namespace Workflow.Action.Ajax
{
    class LogoutUserAjax:AjaxProcess
    {
        public LoginAction loginAction;
        public LoginAction LoginAction
        {
            set { loginAction = value; }
        }
        public string DoProcess(System.Collections.Specialized.NameValueCollection parameters)
        {
            if (!StringUtils.IsEmpty(parameters["userName"]) && !StringUtils.IsEmpty(parameters["branchShopId"]))
            {
                loginAction.LoginModel.LoginUser = new Workflow.Da.Domain.User();
                loginAction.LoginModel.LoginUser.UserName = parameters["userName"];
                loginAction.LoginModel.LoginUser.Password = EncryptUtils.HexMD5(parameters["password"]);
                loginAction.LoginModel.LoginUser.BranchShopId = int.Parse(parameters["branchShopId"]);
                loginAction.LoginModel.LoginUser.CompanyId = Constants.COMPANY_ID;
                int loginStatus = loginAction.LogoutLoginUser();

                switch (loginStatus)
                { 
                    case 1:
                        LogHelper.WriteInfo(ThreadLocalUtils.CurrentUserContext.CurrentUser.UserName + " 注销用户 " + parameters["userName"] + " 失败:用户名或密码错误! 操作时间:"+DateTime.Now.ToString(), Constants.LOGGER_NAME);
                        break;
                    case 2:
                        LogHelper.WriteInfo(ThreadLocalUtils.CurrentUserContext.CurrentUser.UserName + " 注销用户 " + parameters["userName"] + " 失败:该用户当前未登陆! 操作时间:" + DateTime.Now.ToString(), Constants.LOGGER_NAME);
                        break;
                    case 3:
                        LogHelper.WriteInfo(ThreadLocalUtils.CurrentUserContext.CurrentUser.UserName + " 注销用户 " + parameters["userName"] + " 成功! 操作时间:" + DateTime.Now.ToString(), Constants.LOGGER_NAME);
                        break;
                }

                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(int), "LoginStaus");
                return JSONUtils.ToJSONString(loginStatus, jsonDic);

            }
            return "1";
        }

    }
  
}
