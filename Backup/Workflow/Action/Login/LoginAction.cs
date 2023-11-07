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

        /// <summary>
        /// ��鵱ǰ�û����������Ƿ���ȷ������������Է��أ�
        /// ���ڵ�½�ɹ���󶨵�ǰ�û���Ϣ��ThreadLocalUtils.CurrentSession.CurrentUser��
        /// </summary>
        /// <returns>
        /// 1:�û������������ 
        /// 2:�û��Ѿ���½ 
        /// 3:��½�ɹ�
        /// </returns>
        /// <remarks>
        /// ��  ��: ����û���������
        /// ��  ��: 
        /// ��  ��: 
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

        #region ��鵱ǰ�û��Ƿ���߹���Ա
        /// <summary>
        ///��鵱ǰ�û��Ƿ���߹���Ա 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��  ��: ������
        /// ��  ��: 2010��5��8��17:05:04
        /// </remarks>
        public bool CheckIsBestUser(User user) 
        {
            return masterDataService.CheckIsBestUser(user);
        }
        #endregion
    }
}
