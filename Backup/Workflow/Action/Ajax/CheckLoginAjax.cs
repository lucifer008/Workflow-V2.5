using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using Workflow.Util;
using Workflow.Support;
using Workflow.Support.Encrypt;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using System.Web;
using System.Configuration;
namespace Workflow.Action.Ajax
{
    class CheckLoginAjax:AjaxProcess
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
                string strMac = parameters["clientMac"];
                int loginStatus = loginAction.CheckUserNameAndPassword();
                if (!CheckMACAdress(strMac, loginAction.LoginModel.LoginUser)) 
                {
                    loginStatus = -1;
                }
                switch (loginStatus)
                {
                    case -1:
                        LogHelper.WriteInfo("�û� " + parameters["userName"] + " �� " + parameters["ip"] + " ��½ʧ��.���û������ڴ˴���½! ����ʱ�� " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
                        break;
                    case 1:
                        LogHelper.WriteInfo("�û� " + parameters["userName"] + " �� "+ parameters["ip"] + " ��½ʧ��.�û������������! ����ʱ�� " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
                        break;
                    case 2:
                        LogHelper.WriteInfo("�û� " + parameters["userName"] + " �� " + parameters["ip"] + " ��½ʧ��.���û��Ѿ���½! ����ʱ�� " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
                        break;
                    case 3:
                        LogHelper.WriteInfo("�û� " + parameters["userName"] + " �� " + parameters["ip"] + " ��½�ɹ�. ����ʱ�� " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
                        break;
                }

                LoginInfo lginfo = new LoginInfo();
                lginfo.LoginSuccess = loginStatus;
                lginfo.LastVisitedUrl = ThreadLocalUtils.CurrentSession.LastVisitedUrl;
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(LoginInfo), "LoginSuccess,LastVisitedUrl");
                return JSONUtils.ToJSONString(lginfo, jsonDic);

            }
            LogHelper.WriteInfo("�û� " + parameters["userName"] + " ��½ʧ��.�û������������! ����ʱ�� " + DateTime.Now.ToString(), Constants.LOGGER_NAME);
            return "1,''";
        }

        /// <summary>
        /// ����Ƿ��ǷǷ��û�
        /// </summary>
        /// <param name="strMACAdress">MAC��ַ</param>
        /// <param name="currentUserName">�û���</param>
        /// <returns></returns>
        /// <remarks>
        /// ��  ��: ������
        /// ��  ��: 2010��5��8��17:05:04
        /// </remarks>
        private bool CheckMACAdress(string strMACAdress,User users) 
        {
            bool isLogin = false;
            if (loginAction.CheckIsBestUser(users)) return true;
            string clientMACAddress = strMACAdress;
            if ("" == strMACAdress) return false;
            string strServerMacAddress = ConfigurationManager.AppSettings["MAC"].ToString();
            if (null != clientMACAddress)
            {
                string[] serverMacAddress = strServerMacAddress.Split(',');
                foreach (string str in serverMacAddress)
                {
                    if (str.ToUpper() == clientMACAddress.ToUpper())
                    {
                        isLogin = true;
                        break;
                    }
                }
            }
            return isLogin;
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
