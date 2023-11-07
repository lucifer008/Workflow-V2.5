using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Action.Login.Model;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Support;

namespace Workflow.Action
{
    /// <summary>
    /// ��    ��: LoginAction
    /// ���ܸ�Ҫ: ��½��Action
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2008-11-3
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public class LoginAction:BaseAction
    {
        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        private LoginModel model = new LoginModel();
        public  LoginModel LoginModel
        {
            get { return model; }
        }


        public void GetCurrentBranchShop()
        { 
            model.BranchShopList = masterDataService.GetAllBranchShopInfo(Constants.COMPANY_ID);
        }

        public int CheckUserNameAndPassword()
        {
            //masterDataService.CheckUserNameAndPassword(model.LoginUser)

            return masterDataService.CheckUserNameAndPassword(model.LoginUser);

            //if (!masterDataService.CheckUserNameAndPassword(model.LoginUser))
            //{
            //    return false;
            //}
            //return true;
        }
        public void LogoutUser()
        {
            masterDataService.LogoutUser(model.LoginUser);
        }

        public int LogoutLoginUser()
        {
            return masterDataService.LogoutLoginUser(model.LoginUser);
        }
        public void GetEmployeeNameByUserId()
        {
            model.LoginUser.EmployeeName = masterDataService.GetEmployeeNameByUserId(model.LoginUser);
        }
        public void ExitLogoutUser() 
        {
            masterDataService.ExitLogoutUser(model.LoginUser); 
        }
    }
}
