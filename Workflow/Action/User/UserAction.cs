using System;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Service.OrderManage;
using Workflow.Action.Permission.Model;
using Workflow.Service.SystemPermission.UserMangae;
using Workflow.Service.SystemPermission.EmployeeManage;
namespace Workflow.Action
{
	public class UserAction
    {
        #region 注入Service

        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService 
        {
            set { masterDataService = value; }
        }

        private IUserService userService;
        public IUserService UserService
        {
            set { userService = value; }
        }

        private IUserPermissionCheckService userPermissionCheckService;
        public IUserPermissionCheckService UserPermissionCheckService
        {
            set { userPermissionCheckService = value; }
        }

        private IEmployeeService employeeService;
        public IEmployeeService EmployeeService 
        {
            set { employeeService = value; }
            get { return employeeService; }
        }
        #endregion

        #region Model
        private UserModel model = new UserModel();
        public UserModel Model
        {
            get { return model; }
        }
        #endregion

       /// <summary>
       /// 添加一个用户
       /// </summary>
       /// <param name="userList"></param>
       public void AddUserInfo(string[] userList)
        {
           
           userService.AddUserInfo(model.User, userList, model.UserConcessionRanageList);
        }

        /// <summary>
        /// 获取所有雇员
        /// </summary>
		public void GetAllEmployee()
		{
			model.EmployeeList = employeeService.GetAllEmployee();
		}

		/// <summary>
		/// 获取所有用户
		/// </summary>
		public void GetAllUser() 
		{
            if (null == Model.User)
            {
                model.User = new User();
                model.User.CurrentPageIndex = 0;
                model.User.RowCount =Constants.ROW_COUNT_FOR_PAGER;
            }
			model.UserList=masterDataService.GetAllUser(model.User);
          List<User> userList = (List<User>)masterDataService.GetAllUser(model.User);
		}

        /// <summary>
        /// 根据用户Id获取用户所有角色
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年3月3日16:30:20
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public string[] GetUserRoleStringByUserId(long userId)
        {
            string[] usList = new string[2];
            int count = 0;
            foreach (UserRole ur in userService.GetAllRole())
            {
                if (userId == ur.UsersId)
                {
                    if (0 == count)
                    {
                        usList[0] += ur.RoleId;
                        usList[1] += ur.PermissionName;
                    }
                    else
                    {
                        usList[0] += "/" + ur.RoleId;
                        usList[1] += "/" + ur.PermissionName;
                    }
                    count++;
                }
            }
            return usList;
        }

        /// <summary>
        /// 按照条件 获取所有用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年3月3日16:30:20
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public void SearchUserInfo() 
        {
            model.UserList = userService.SearchUserInfo(model.User);
        }


        /// <summary>
        /// 查询 满足条件的用户记录数
        /// </summary>
        /// <returns></returns>
        public long GetAllUserRowCount() 
        {
            return userService.GetAllUserRowCount(model.User);
        } 

		/// <summary>
		/// 获取所有角色
		/// </summary>
		public void GetAllRole()
		{
			model.RoleList = masterDataService.GetRoleList();
		}

        /// <summary>
        /// 功能概要：根据用户名和密码获取授权用户信息
        /// 作    者：张晓林
        /// 创建时间：2009年12月11日15:01:31
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public void GetAccreditUserInfo()
        {
            this.model.User = userPermissionCheckService.GetAccreditUserInfo(model.User);
        }

        public void CheckCurrentUserPermissionByUserId()
        {
            model.UserList = userPermissionCheckService.CheckCurrentUserPermissionByUserId();
        }

        /// <summary>
        /// 获取所有雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月8日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void SelectAllEmployee() 
        {
            model.EmployeeList = masterDataService.SelectAllEmployee();
        }

        #region //修改用户信息
        /// <summary>
        /// 更新用户
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月12日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void UpdateUserInfo(string []roleList)
        {
            model.User.IsNullUserConcessionRanage = model.IsNullUserConcessionRanage;
            userService.UpdateUserInfo(model.User, roleList,model.UserConcessionRanageList);
        }
        #endregion

        #region //删除用户信息
        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月12日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void DeleteUserInfo()
        {
            userService.DeleteUserInfo(model.User);
        }
        #endregion

        #region //修改用户密码
        /// <summary>
        /// 修改用户密码
        /// </summary>
        public void UpdatePasswordByUserId()
        {
            User user = new User();
            user.Id = model.User.Id;
            user.Password = model.User.Password;
            userService.UpdatePasswordByUserId(user);
        }
        #endregion

        #region //根据用户Id查询用户的优惠范围
        /// <summary>
        /// 根据用户Id查询用户的优惠范围
        /// </summary>
        /// <param name="userId"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月4日16:45:25
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void SearchUserConcessionRange(long userId) 
        {
           model.UserConcessionRanageList=userService.SearchUserConcessionRange(userId); 
        }
        #endregion

        #region // 检查用户是否有优惠范围
        public long CheckUserIsNotConcessionRange(long userId) 
        {
            return userService.CheckUserIsNotConcessionRange(userId);
        }
        #endregion

        /// <summary>
        /// 添加用户授权记录
        /// </summary>
        /// <remarks>
        ///  作    者：张晓林
        ///  创建时间:2009年12月11日16:14:33
        ///  修正履历:
        ///  修正时间:
        /// </remarks>
        public void InsertAccreditRecord() 
        {
            masterDataService.InsertAccreditRecord(model.AccreditRecord);
        }
    }
}
