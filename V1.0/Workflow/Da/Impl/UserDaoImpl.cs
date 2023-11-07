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
            return (User)sqlMap.QueryForObject("User.SelectUserByUserNameAndPassword", user);
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
            User u = (User)sqlMap.QueryForObject("User.CheckUserIsLogin",user);
            if (u == null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 根据用户名和密码检查 用户权限
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User CheckUserPermissionByUserNameAndPassword(User user)
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return (User)sqlMap.QueryForObject("User.CheckUserPermissionbyUserNameAndPassword", user);
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
            return (string)sqlMap.QueryForObject("User.GetEmployeeNameByUserId", user);
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
        /// 创建人:张晓林
        /// 创建时间:2009年1月12日
        /// 修正履历:
        /// 修正人:
        /// </remarks>
        /// 
        [Transaction]
        public void DeleteUserInfo(User user) 
        {
            //判断用户是否只有一个角色
            string permissionName = user.PermissionName;
            user.PermissionName = null;
            //IList<UserRole> userRoleList=sqlMap.QueryForList<UserRole>("UserRole.SelectUserRoleByUserId", user);
            //if(userRoleList.Count==1)
            //{
            //    sqlMap.Update("User.DeleteUserInfo", user);
            //}
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
        /// 创建人:张晓林
        /// 创建时间:2009年1月12日
        /// 修正履历:
        /// 修正人:
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
	}
}
