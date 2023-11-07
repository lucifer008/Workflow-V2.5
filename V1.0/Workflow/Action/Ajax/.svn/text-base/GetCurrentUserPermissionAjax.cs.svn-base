using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using Workflow.Action.Permission.Model;
using Workflow.Da.Domain;
using Workflow.Util;

namespace Workflow.Action.Ajax
{
    class GetCurrentUserPermissionAjax:AjaxProcess
    {
        protected UserAction userAction;
        public UserAction UserAction
        {
            set { userAction = value; }
        }
        public string DoProcess(System.Collections.Specialized.NameValueCollection parameters)
        {
            userAction.CheckCurrentUserPermissionByUserId();

            //if (null != userAction.Model.UserList && userAction.Model.UserList.Count>0)
            //{
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(UserModel), "UserList");
                jsonDic.Add(typeof(User), "Id,PermissionName");
                return JSONUtils.ToJSONString(userAction.Model, jsonDic);

            //}
            //return "";
        }


    }
}
