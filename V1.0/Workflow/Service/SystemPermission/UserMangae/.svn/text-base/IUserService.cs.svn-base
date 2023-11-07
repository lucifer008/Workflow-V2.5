using System;
using System.Collections.Generic;
using Workflow.Da.Domain;
namespace Workflow.Service.SystemPermission.UserMangae
{
    /// <summary>
    /// 功能概要: 用户 Service 接口
    /// 作    者: 张晓林
    /// 创建时间: 2009-2-05
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// 插入一个用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        void AddUser(User user);

        ///// <summary>
        ///// 加入一个用户角色
        ///// </summary>
        ///// <param name="userRole"></param>
        //void AddUserRole(UserRole userRole);

        /// <summary>
        /// 添加用户的角色
        /// </summary>
        /// <param name="user"></param>
        /// <param name="strRoleID"></param>
        void AddUserRole(User user, string[] strRoleID);

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
        void AddUserConcessionRance(UserConcessionRange userConcessionRange);

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
        void AddUserInfo(User user,string[] arrUserList,IList<UserConcessionRange> userConcessionRangeList);

        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月12日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void UpdateUserInfo(User user, string[] userList,IList<UserConcessionRange> userConcessionRange);

        /// <summary>
        /// 删除用户信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月12日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void DeleteUserInfo(User user);
        /// <summary>
        /// 获取所有用户记录数
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        long GetAllUserRowCount(User user);

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
        /// 修改当前用户密码
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        void UpdatePasswordByUserId(User user);

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

		#region 获取指定用户通过用户id

		/// <summary>
		/// 获取指定用户通过用户id
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>user</returns>
		User GetUserById(long id);

		#endregion

		
	}
}
