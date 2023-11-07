using System;
using System.Web;
using System.Collections.Generic;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Support.Encrypt;

namespace Workflow.Action.Ajax.SystemMaintenance
{
    public class CheckLoginAjax : AjaxProcess
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
                loginAction.LoginModel.LoginUser.IsSystemMaintenance = true;
                int loginStatus = loginAction.CheckUserNameAndPassword();

                switch (loginStatus)
                {
                    case 1:
                        LogHelper.WriteInfo("用户 " + parameters["userName"] + " 在 " + parameters["ip"] + " 登陆失败.用户名或密码错误! 操作时间 " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
                        break;
                    //case 2:
                    //    LogHelper.WriteInfo("用户 " + parameters["userName"] + " 在 " + parameters["ip"] + " 登陆失败.该用户已经登陆! 操作时间 " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
                    //    break;
                    case 3:
                        LogHelper.WriteInfo("用户 " + parameters["userName"] + " 在 " + parameters["ip"] + " 登陆成功. 操作时间 " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
                        break;
                }

                LoginInfo lginfo = new LoginInfo();
                lginfo.LoginSuccess = loginStatus;
                lginfo.LastVisitedUrl = ThreadLocalUtils.CurrentSession.LastVisitedUrl;
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(LoginInfo), "LoginSuccess,LastVisitedUrl");
                return JSONUtils.ToJSONString(lginfo, jsonDic);

            }
            LogHelper.WriteInfo("用户 " + parameters["userName"] + " 登陆失败.用户名或密码错误! 操作时间 " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
            return "1,''";
        }
    }
    internal class LoginInfo
    {
        private int loginSuccess;
        public int LoginSuccess
        {
            get { return loginSuccess; }
            set { loginSuccess = value; }
        }
        private string lastVisitedUrl;
        public string LastVisitedUrl
        {
            get { return lastVisitedUrl; }
            set { lastVisitedUrl = value; }
        }
    }
}
