using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using Spring.Transaction.Interceptor;
using System.Collections;
/// <summary>
/// 名    称: UserDaoImpl
/// 功能概要: 用户接口IUserDao实现类
/// 作    者: 付强
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table USERS 对应的Dao 实现
	/// </summary>
    public class UserDaoImpl : Workflow.Da.Base.DaoBaseImpl<User>, IUserDao
    {
        /// <summary>
        /// 检查用户名称和密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User CheckUserNameAndPassword(User user)
        {
            return sqlMap.QueryForObject<User>("User.SelectUserByUserNameAndPassword", user);
        }

        /// <summary>
        /// 修改用户的状态
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUserLoginStatus(User user)
        {
            sqlMap.Update("User.UpdateUserLoginStatus", user);
        }

        /// <summary>
        /// 检查用户是否登陆
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool CheckUserIsLogin(User user)
        {
            bool isLogin = false;
            User u =sqlMap.QueryForObject<User>("User.CheckUserIsLogin",user);
            if (null == u) isLogin=true;
            return isLogin;
        }

        /// <summary>
        /// 功能概要：根据用户名和密码获取授权用户信息
        /// 作    者：张晓林
        /// 创建时间：2009年12月11日15:01:31
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        public User GetAccreditUserInfo(User user)
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return (User)sqlMap.QueryForObject("User.GetAccreditUserInfo", user);
        }
        
        /// <summary>
        /// 获取当前用户权限根据用户Id
        /// </summary>
        /// <returns></returns>
        public IList<User> CheckCurrentUserPermissionByUserId()
        {
            User user = new User();
            user.Id = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            user.IsUsed = Constants.TRUE;
            return sqlMap.QueryForList<User>("User.CheckCurrentUserPermissionByUserId", user);
        }

        /// <summary>
        /// 根据用户Id获取雇员名称
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GetEmployeeNameByUserId(User user)
        {
            return sqlMap.QueryForObject<string>("User.GetEmployeeNameByUserId", user);
        }

        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUserPassWord(User user)
        {
            return sqlMap.QueryForObject<int>("User.UpdateUserPassWord", user);
        }

	     /// <summary>
        /// 按照条件 获取所有用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月12日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public IList<User> GetAllUsers(User user) 
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<User>("User.GetAllUsers", user);
        }

        /// <summary>
        /// 按照条件 获取所有用户(不包含角色信息)
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
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<User>("User.SearchUserInfo", user);
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
            Role role = new Role();
            role.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            role.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<UserRole>("User.SearchUserRole", role);
        }

        /// <summary>
        /// 获取所有用户记录数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月12日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public long GetAllUserRowCount(User user) 
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("User.SearchUserInfoRowCount",user);
        }
        /// <summary>
        /// 删除用户的信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人: 张晓林
        /// 创建时间: 2009年1月12日
        /// 修正履历:
        /// 修正人:
        /// </remarks>        
        public void DeleteUserInfo(User user) 
        {
            string permissionName = user.PermissionName;
            user.PermissionName = null;
            sqlMap.Update("User.DeleteUserInfo", user);
            user.PermissionName = permissionName;
            sqlMap.Delete("User.DeleteUserRoleByUserId", user);
        }

        /// <summary>
        /// 更新用户的信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创 建 人: 张晓林
        /// 创建时间: 2009年1月12日
        /// 修正履历:
        /// </remarks>
        public void UpdateUserInfo(User user) 
        {
            sqlMap.Update("User.UpdateUserInfoByUserId", user);
        }

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
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("User.SearchDeleteUserIsUse", user);
        }
        /// <summary>
        /// 根据用户Id和角色Id 删除用户的角色信息
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// 创建人:张晓林
        /// 创建时间:2009年1月14日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        public void DeleteUserRoleInfo(User user) 
        {
            sqlMap.Delete("User.DeleteUserRoleByUserId", user);
        }


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
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("User.CheckUserNameIsExist", user);
        }

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
            UserConcessionRange userConcessionRange = new UserConcessionRange();
            userConcessionRange.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            userConcessionRange.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            userConcessionRange.UsersId = userId;
            sqlMap.Delete("User.DeleteUserConcessionRanceByUserId", userConcessionRange);
        }

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
            UserConcessionRange userConcessionRange = new UserConcessionRange();
            userConcessionRange.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            userConcessionRange.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            userConcessionRange.UsersId = userId;
            return sqlMap.QueryForObject<long>("User.CheckUserIsNotConcessionRange", userConcessionRange);
        }

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
            UserConcessionRange userConcessionRange = new UserConcessionRange();
            userConcessionRange.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            userConcessionRange.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            userConcessionRange.UsersId = userId;
            return sqlMap.QueryForList<UserConcessionRange>("User.SearchUserConcessionRange", userConcessionRange);
        }

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
			Hashtable map = new Hashtable();
			map.Add("companyid", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
			map.Add("branchshopid", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
			return sqlMap.QueryForList<User>("User.GetDifferEmployeeAllUser", map);
		}

		#endregion

        public void ExitLogoutUser(User user)
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.Update("User.UpdateUserLoginStatus", user);
		}

		#region 根据用户id获取雇员名称

		public string GetEmployeeNameByUserId(long userId)
		{
			return sqlMap.QueryForObject<string>("User.GetNameByUserId", userId);
		}

		#endregion

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
            bool isExist=false;
            int count = sqlMap.QueryForObject<int>("User.CheckCurrentIsBestUser", user);
            if (0 < count) isExist = true;
            return isExist;
        }

		/// <summary>
		/// 通过雇员名称获取用户信息
		/// 作者：白晓宇
		/// 时间：2010-05-18
		/// </summary>
		/// <param name="employeeName">雇员名称</param>
		/// <returns></returns>
		public IList<User> SelectUserListByEmployeeName(string employeeName)
		{
			User domain = ThreadLocalUtils.CurrentUserContext.CurrentUser;

			Hashtable para = new Hashtable();
			para.Add("Name", employeeName);
			para.Add("Companyid", domain.CompanyId);
			para.Add("BranchshopId", domain.BranchShopId);

			return sqlMap.QueryForList<User>("User.SelectUserListByEmployeeName", para);
		}
	}
}
