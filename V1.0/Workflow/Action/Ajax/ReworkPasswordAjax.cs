using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using Workflow.Util;
using Workflow.Support;
using Workflow.Support.Encrypt;

namespace Workflow.Action.Ajax
{
    class ReworkPasswordAjax : AjaxProcess
    {
        public LoginAction loginAction;
        public LoginAction LoginAction
        {
            set { loginAction = value; }
        }
        public string DoProcess(System.Collections.Specialized.NameValueCollection parameters)
        {
            loginAction.LoginModel.LoginUser = new Workflow.Da.Domain.User();
            loginAction.LoginModel.LoginUser.UserName = ThreadLocalUtils.CurrentUserContext.CurrentUser.UserName;
            loginAction.LoginModel.LoginUser.Password = EncryptUtils.HexMD5(parameters["password"]);
            loginAction.LoginModel.LoginUser.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            loginAction.LoginModel.LoginUser.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            int isUser = loginAction.CheckUserNameAndPassword();
            if (isUser == 3)
            {
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(Boolean), "Login");

                return JSONUtils.ToJSONString(isUser, jsonDic);
            }
            return isUser.ToString();
        }

    }
}
