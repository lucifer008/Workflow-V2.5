using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using Spring.Transaction.Interceptor;
using System.Collections;
/// <summary>
/// ��    ��: UserDaoImpl
/// ���ܸ�Ҫ: �û��ӿ�IUserDaoʵ����
/// ��    ��: ��ǿ
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table USERS ��Ӧ��Dao ʵ��
	/// </summary>
    public class UserDaoImpl : Workflow.Da.Base.DaoBaseImpl<User>, IUserDao
    {
        /// <summary>
        /// ����û����ƺ�����
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User CheckUserNameAndPassword(User user)
        {
            return (User)sqlMap.QueryForObject("User.SelectUserByUserNameAndPassword", user);
        }

        /// <summary>
        /// �޸��û���״̬
        /// </summary>
        /// <param name="user"></param>
        public void UpdateUserLoginStatus(User user)
        {
            sqlMap.Update("User.UpdateUserLoginStatus", user);
        }

        /// <summary>
        /// ����û��Ƿ��½
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
        /// �����û����������� �û�Ȩ��
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
        /// ��ȡ��ǰ�û�Ȩ�޸����û�Id
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
        /// �����û�Id��ȡ��Ա����
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GetEmployeeNameByUserId(User user)
        {
            return (string)sqlMap.QueryForObject("User.GetEmployeeNameByUserId", user);
        }

        /// <summary>
        /// �޸��û�����
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUserPassWord(User user)
        {
            return sqlMap.QueryForObject<int>("User.UpdateUserPassWord", user);
        }

	     /// <summary>
        /// �������� ��ȡ�����û�
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��12��
        /// ��������:
        /// ������:
        /// </remarks>
        public IList<User> GetAllUsers(User user) 
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<User>("User.GetAllUsers", user);
        }

        /// <summary>
        /// �������� ��ȡ�����û�(��������ɫ��Ϣ)
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��3��3��16:30:20
        /// ��������:
        /// ������:
        /// </remarks>
        public IList<User> SearchUserInfo(User user) 
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<User>("User.SearchUserInfo", user);
        }

        /// <summary>
        /// ��ȡ���н�ɫ
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��3��3��16:30:20
        /// ��������:
        /// ������:
        /// </remarks>
        public IList<UserRole> GetAllRole() 
        {
            Role role = new Role();
            role.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            role.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<UserRole>("User.SearchUserRole", role);
        }

        /// <summary>
        /// ��ȡ�����û���¼��
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��12��
        /// ��������:
        /// ������:
        /// </remarks>
        public long GetAllUserRowCount(User user) 
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("User.SearchUserInfoRowCount",user);
        }
        /// <summary>
        /// ɾ���û�����Ϣ
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��12��
        /// ��������:
        /// ������:
        /// </remarks>
        /// 
        [Transaction]
        public void DeleteUserInfo(User user) 
        {
            //�ж��û��Ƿ�ֻ��һ����ɫ
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
        /// �����û�����Ϣ
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��12��
        /// ��������:
        /// ������:
        /// </remarks>
        public void UpdateUserInfo(User user) 
        {
            sqlMap.Update("User.UpdateUserInfoByUserId", user);
        }

        /// <summary>
        /// �ж��û��Ƿ�ʹ��
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��13��
        /// ��������:
        /// ������:
        /// </remarks>
        public long SearchDeleteUserIsUse(User user) 
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("User.SearchDeleteUserIsUse", user);
        }
        /// <summary>
        /// �����û�Id�ͽ�ɫId ɾ���û��Ľ�ɫ��Ϣ
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��1��14��
        /// ��������:
        /// ������:
        /// </remarks>
        public void DeleteUserRoleInfo(User user) 
        {
            sqlMap.Delete("User.DeleteUserRoleByUserId", user);
        }


        /// <summary>
        /// ����û����Ƿ��Ѿ�����
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// ������:������
        /// ����ʱ��:2009��2��20��10:37:01
        /// ��������:
        /// ������:
        /// </remarks>
        public long CheckUserNameIsExist(User user) 
        {
            user.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            user.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("User.CheckUserNameIsExist", user);
        }

        /// <summary>
        /// �����û�Idɾ���û�Ȩ�޷�Χ
        /// </summary>
        /// <param name="userConcessionRange"></param>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��3��4��14:13:53
        /// ��������:
        /// ����ʱ��:
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
        /// �����û�Id��ѯ���û��Ƿ����Żݷ�Χ
        /// </summary>
        /// <param name="userConcessionRange"></param>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��3��4��16:08:16
        /// ��������:
        /// ����ʱ��:
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
        /// �����û�Id��ѯ�û����Żݷ�Χ
        /// </summary>
        /// <param name="userId"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��4��16:45:25
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<UserConcessionRange> SearchUserConcessionRange(long userId) 
        {
            UserConcessionRange userConcessionRange = new UserConcessionRange();
            userConcessionRange.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            userConcessionRange.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            userConcessionRange.UsersId = userId;
            return sqlMap.QueryForList<UserConcessionRange>("User.SearchUserConcessionRange", userConcessionRange);
        }

		#region ��ȡ����ͬ��Ա�������û�

		/// <summary>
		/// ��ȡ����ͬ��Ա�������û�
		/// </summary>
		/// <returns>�û��б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-5-6
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
