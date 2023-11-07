using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: IUserDao
/// 功能概要: 用户接口
/// 作    者: 付强
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table USERS 对应的Dao 接口
	/// </summary>
    public interface IUserDao : IDaoBase<User>
    {
        /// <summary>
        /// 检查用户名和密码是否存在
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User CheckUserNameAndPassword(User user);

        /// <summary>
        /// 功能概要：根据用户名和密码获取授权用户信息
        /// 作    者：张晓林
        /// 创建时间：2009年12月11日15:01:31
        /// 修正履历：
        /// 修正时间:
        /// </summary>
        User GetAccreditUserInfo(User user);

        /// <summary>
        /// 根据用户ID检查用户权限
        /// </summary>
        /// <returns></returns>
        IList<User> CheckCurrentUserPermissionByUserId();
        
        /// <summary>
        /// 根据用户Id获取用户名
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string GetEmployeeNameByUserId(User user);

		#region 根据用户id获取雇员名称

		/// <summary>
		/// 根据用户Id获取用户名
		/// </summary>
		/// <param name="userId">userId</param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-12-18
		/// </remarks>
		string GetEmployeeNameByUserId(long userId);

		#endregion

		/// <summary>
        /// 修改用户登陆状态
        /// </summary>
        /// <param name="user"></param>
        void UpdateUserLoginStatus(User user);

        /// <summary>
        /// 更新用户密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int UpdateUserPassWord(User user);

        /// <summary>
        /// 检查用户是否登陆
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool CheckUserIsLogin(User user);

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
        IList<User> GetAllUsers(User user);

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
        IList<User> SearchUserInfo(User user);

         /// <summary>
        /// 获取所有用户记录数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        long GetAllUserRowCount(User user);

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
        IList<UserRole> GetAllRole();

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
        void DeleteUserInfo(User user);

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
        void UpdateUserInfo(User user);

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
        long SearchDeleteUserIsUse(User user);

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
        void DeleteUserRoleInfo(User user);

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
        long CheckUserNameIsExist(User user);

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
        void DeleteUserConcessionRanceByUserId(long userId);

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
        long CheckUserIsNotConcessionRange(long userId);

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
        IList<UserConcessionRange> SearchUserConcessionRange(long userId);

		#region 获取不相同雇员的所有用户

		/// <summary>
		/// 获取不相同雇员的所有用户
		/// </summary>
		/// <returns>用户列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-5-6
		/// </remarks>
		IList<User> GetDifferEmployeeAllUser();

		#endregion

        void ExitLogoutUser(User user);

        /// <summary>
        ///检查当前用户是否最高管理员
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作  者: 张晓林
        /// 日  期: 2010年5月8日17:05:04
        /// </remarks>
        bool CheckIsBestUser(User user);

		/// <summary>
		/// 通过雇员名称获取用户信息
		/// 作者：白晓宇
		/// 时间：2010-05-18
		/// </summary>
		/// <param name="employeeName">雇员名称</param>
		/// <returns></returns>
		IList<User> SelectUserListByEmployeeName(string employeeName);
	}
}
