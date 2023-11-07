using System;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Workflow.Da;
using Workflow.Support;
using Workflow.Da.Domain;
namespace Workflow.Service.SystemPermission.UserMangae.Impl
{
    /// <summary>
    /// 功能概要: 用户 IUserService 接口实现类
    /// 作    者: 张晓林
    /// 创建时间: 2009-2-05
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public class UserServiceImpl : IUserService
    {
        #region //注入Dao
        /// <summary>
        /// 用户Dao
        /// </summary>
        private IUserDao userDao;
        public IUserDao UserDao
        {
            set { userDao = value; }
        }

        /// <summary>
        ///用户角色Dao
        /// </summary>
        private IUserRoleDao userRoleDao;
        public IUserRoleDao UserRoleDao
        {
            set { userRoleDao = value; }
        }

        private IUserConcessionRangeDao userConcessionRangeDao;
        public IUserConcessionRangeDao UserConcessionRangeDao 
        {
            set { userConcessionRangeDao = value; }
        }
        #endregion

        #region //添加一个用户

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="userConcessionRange"></param>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年8月3日13:39:34
        /// 修正履历:
        /// 修正时间:
        ///</remarks>
        [Transaction]
        public void AddUserInfo(User user, string[] arrUserList, IList<UserConcessionRange> userConcessionRangeList) 
        {
            AddUser(user);
            //添加用户角色
            AddUserRole(user, arrUserList);
            //添加用户优惠范围
            if (null != userConcessionRangeList)
            {
                for (int i = 0; i < userConcessionRangeList.Count; i++)
                {
                    userConcessionRangeList[i].UsersId = user.Id;
                    AddUserConcessionRance(userConcessionRangeList[i]);
                }
            }
        }
        /// <summary>
        /// 添加一个用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void AddUser(User user)
        {
            userDao.Insert(user);
        }
        #endregion

        #region //添加用户角色
        /// <summary>
        /// 添加用户角色
        /// </summary>
        /// <param name="user"></param>
        /// <param name="strRoleID"></param>
        public void AddUserRole(User user, string[] strRoleID)
        {
            UserRole userRole;
            foreach (string str in strRoleID)
            {
                userRole = new UserRole();
                userRole.UsersId = user.Id;
                userRole.RoleId = Convert.ToInt32(str);
                //检查添加的角色用户是否已经拥有该角色
                UserRole checkUserRoleIsExist = userRoleDao.SelectUserRoleByUserIdAndRoleId(userRole);
                if (null == checkUserRoleIsExist)
                {
                    userRoleDao.Insert(userRole);
                }
            }
        }
        #endregion

        #region //添加用户权限范围
        /// <summary>
        /// 添加用户优惠范围
        /// </summary>
        /// <param name="userConcessionRange"></param>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月4日13:12:58
        /// 修正履历:
        /// 修正时间:
        ///</remarks>
        public void AddUserConcessionRance(UserConcessionRange userConcessionRange)
        {
            userConcessionRange.InsertDateTime = DateTime.Now;
            userConcessionRange.UpdateDateTime = DateTime.Now;
            userConcessionRange.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            userConcessionRange.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            userConcessionRange.InsertUser = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
            userConcessionRange.Version = 1;
            userConcessionRange.Deleted = "0";
            userConcessionRange.Memo = "";
            userConcessionRangeDao.Insert(userConcessionRange);
        }
        #endregion

        #region //根据用户Id删除用户权限范围

        /// <summary>
        /// 根据用户Id删除用户权限范围
        /// </summary>
        /// <param name="userConcessionRange"></param>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月4日14:13:53
        /// 修正履历:
        /// 修正时间:
        ///</remarks>
        public void DeleteUserConcessionRanceByUserId(long userId) 
        {
            userDao.DeleteUserConcessionRanceByUserId(userId);
        }
        #endregion

        #region // 按照条件获取所有用户
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
        public IList<User> SearchUserInfo(User user) 
        {
            return userDao.SearchUserInfo(user);
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年3月3日16:30:20
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public IList<UserRole> GetAllRole() 
        {
            return userDao.GetAllRole();
        }
        #endregion

        #region //获取所有用户记录数
        /// <summary>
        /// 获取所有用户记录数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public long GetAllUserRowCount(User user)
        {
            return userDao.GetAllUserRowCount(user);
        }
        #endregion

        #region //更新用户信息
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月12日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        /// 
        [Transaction]
        public void UpdateUserInfo(User user, string[] userList, IList<UserConcessionRange> userConcessionRanageList)
        {
            string userName = user.UserName;
            string permissionName = user.PermissionName;
            user.UserName = user.Id.ToString();
            user.PermissionName = user.RoleId.ToString();
            //删除旧的用户角色
            userDao.DeleteUserRoleInfo(user);
            //添加新的用户角色
            AddUserRole(user, userList);
            user.UserName = userName;
            user.PermissionName = permissionName;

            //删除旧的用户优惠范围
            userDao.DeleteUserConcessionRanceByUserId(user.Id);
            //添加用户优惠范围
            if (null != userConcessionRanageList)
            {
                for (int i = 0; i < userConcessionRanageList.Count; i++)
                {
                    userConcessionRanageList[i].UsersId = user.Id;
                    AddUserConcessionRance(userConcessionRanageList[i]);
                }
            }

            userDao.UpdateUserInfo(user);
            if(!user.IsNullUserConcessionRanage)
            {
                userConcessionRangeDao.DeleteConcessionRanageByUserId(user.Id);
            }
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
        public void DeleteUserInfo(User user)
        {
            userDao.DeleteUserInfo(user);
        }
        #endregion

        #region //判断用户是否使用
        /// <summary>
        /// 判断用户是否使用
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月13日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public long SearchDeleteUserIsUse(User user)
        {
            return userDao.SearchDeleteUserIsUse(user);
        }
        #endregion

        #region //修改个人密码
        /// <summary>
        /// 修改个人密码
        /// </summary>
        /// <param name="newpassword"></param>
        /// <param name="user"></param>

        public void UpdatePasswordByUserId(User user)
        {
            int k = userDao.UpdateUserPassWord(user);
        }
        #endregion 

        #region //判断用户名称是否已经存在
        /// <summary>
        /// 检查用户名是否已经存在
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年2月20日10:37:01
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public long CheckUserNameIsExist(User user) 
        {
            return userDao.CheckUserNameIsExist(user);
        }
        #endregion

        #region //根据用户Id查询该用户是否有优惠范围
        /// <summary>
        /// 根据用户Id查询该用户是否有优惠范围
        /// </summary>
        /// <param name="userConcessionRange"></param>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月4日16:08:16
        /// 修正履历:
        /// 修正时间:
        ///</remarks>
        public long CheckUserIsNotConcessionRange(long userId) 
        {
            return userDao.CheckUserIsNotConcessionRange(userId); 
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
        public IList<UserConcessionRange> SearchUserConcessionRange(long userId) 
        {
            return userDao.SearchUserConcessionRange(userId);
        }
        #endregion

		#region 获取不相同雇员的所有用户

		/// <summary>
		/// 获取不相同雇员的所有用户
		/// </summary>
		/// <returns>用户列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-5-6
		/// </remarks>
		public IList<User> GetDifferEmployeeAllUser()
		{
			return userDao.GetDifferEmployeeAllUser();
		}

		#endregion

		#region 获取指定用户通过用户id

		/// <summary>
		/// 获取指定用户通过用户id
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>user</returns>
		public User GetUserById(long id)
		{
			return userDao.SelectByPk(id);
		}

		#endregion
	}
}
