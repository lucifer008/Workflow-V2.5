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
    /// 名    称: LoginAction
    /// 功能概要: 登陆的Action
    /// 作    者: 付强
    /// 创建时间: 2008-11-3
    /// 修正履历: 
    /// 修正时间: 
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

        /// <summary>
        /// 检查当前用户名与密码是否正确，并将结果做以返回，
        /// 且在登陆成功后绑定当前用户信息到ThreadLocalUtils.CurrentSession.CurrentUser上
        /// </summary>
        /// <returns>
        /// 1:用户名或密码错误 
        /// 2:用户已经登陆 
        /// 3:登陆成功
        /// </returns>
        /// <remarks>
        /// 功  能: 检查用户名与密码
        /// 作  者: 
        /// 日  期: 
        /// </remarks>
        public int CheckUserNameAndPassword()
        {
            return masterDataService.CheckUserNameAndPassword(model.LoginUser);
        }

        //public void LogoutUser()
        //{
        //    masterDataService.LogoutUser(model.LoginUser);
        //}

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

        #region 检查当前用户是否最高管理员
        /// <summary>
        ///检查当前用户是否最高管理员 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年5月8日17:05:04
        /// </remarks>
        public bool CheckIsBestUser(User user) 
        {
            return masterDataService.CheckIsBestUser(user);
        }
        #endregion
    }
}
