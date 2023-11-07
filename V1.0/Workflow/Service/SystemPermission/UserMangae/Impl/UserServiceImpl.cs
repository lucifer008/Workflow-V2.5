using System;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Workflow.Da;
using Workflow.Support;
using Workflow.Da.Domain;
namespace Workflow.Service.SystemPermission.UserMangae.Impl
{
    /// <summary>
    /// ���ܸ�Ҫ: �û� IUserService �ӿ�ʵ����
    /// ��    ��: ������
    /// ����ʱ��: 2009-2-05
    /// �� �� ��: 
    /// ����ʱ��: 
    /// ��������: 
    /// </summary>
    public class UserServiceImpl : IUserService
    {
        #region //ע��Dao
        /// <summary>
        /// �û�Dao
        /// </summary>
        private IUserDao userDao;
        public IUserDao UserDao
        {
            set { userDao = value; }
        }

        /// <summary>
        ///�û���ɫDao
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

        #region //���һ���û�

        /// <summary>
        /// ����û�
        /// </summary>
        /// <param name="userConcessionRange"></param>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��8��3��13:39:34
        /// ��������:
        /// ����ʱ��:
        ///</remarks>
        [Transaction]
        public void AddUserInfo(User user, string[] arrUserList, IList<UserConcessionRange> userConcessionRangeList) 
        {
            AddUser(user);
            //����û���ɫ
            AddUserRole(user, arrUserList);
            //����û��Żݷ�Χ
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
        /// ���һ���û�
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public void AddUser(User user)
        {
            userDao.Insert(user);
        }
        #endregion

        #region //����û���ɫ
        /// <summary>
        /// ����û���ɫ
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
                //�����ӵĽ�ɫ�û��Ƿ��Ѿ�ӵ�иý�ɫ
                UserRole checkUserRoleIsExist = userRoleDao.SelectUserRoleByUserIdAndRoleId(userRole);
                if (null == checkUserRoleIsExist)
                {
                    userRoleDao.Insert(userRole);
                }
            }
        }
        #endregion

        #region //����û�Ȩ�޷�Χ
        /// <summary>
        /// ����û��Żݷ�Χ
        /// </summary>
        /// <param name="userConcessionRange"></param>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��3��4��13:12:58
        /// ��������:
        /// ����ʱ��:
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

        #region //�����û�Idɾ���û�Ȩ�޷�Χ

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
            userDao.DeleteUserConcessionRanceByUserId(userId);
        }
        #endregion

        #region // ����������ȡ�����û�
        /// <summary>
        /// �������� ��ȡ�����û�
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
            return userDao.SearchUserInfo(user);
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
            return userDao.GetAllRole();
        }
        #endregion

        #region //��ȡ�����û���¼��
        /// <summary>
        /// ��ȡ�����û���¼��
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public long GetAllUserRowCount(User user)
        {
            return userDao.GetAllUserRowCount(user);
        }
        #endregion

        #region //�����û���Ϣ
        /// <summary>
        /// �����û���Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��12��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        /// 
        [Transaction]
        public void UpdateUserInfo(User user, string[] userList, IList<UserConcessionRange> userConcessionRanageList)
        {
            string userName = user.UserName;
            string permissionName = user.PermissionName;
            user.UserName = user.Id.ToString();
            user.PermissionName = user.RoleId.ToString();
            //ɾ���ɵ��û���ɫ
            userDao.DeleteUserRoleInfo(user);
            //����µ��û���ɫ
            AddUserRole(user, userList);
            user.UserName = userName;
            user.PermissionName = permissionName;

            //ɾ���ɵ��û��Żݷ�Χ
            userDao.DeleteUserConcessionRanceByUserId(user.Id);
            //����û��Żݷ�Χ
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

        #region //ɾ���û���Ϣ
        /// <summary>
        /// ɾ���û���Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��12��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void DeleteUserInfo(User user)
        {
            userDao.DeleteUserInfo(user);
        }
        #endregion

        #region //�ж��û��Ƿ�ʹ��
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
            return userDao.SearchDeleteUserIsUse(user);
        }
        #endregion

        #region //�޸ĸ�������
        /// <summary>
        /// �޸ĸ�������
        /// </summary>
        /// <param name="newpassword"></param>
        /// <param name="user"></param>

        public void UpdatePasswordByUserId(User user)
        {
            int k = userDao.UpdateUserPassWord(user);
        }
        #endregion 

        #region //�ж��û������Ƿ��Ѿ�����
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
            return userDao.CheckUserNameIsExist(user);
        }
        #endregion

        #region //�����û�Id��ѯ���û��Ƿ����Żݷ�Χ
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
            return userDao.CheckUserIsNotConcessionRange(userId); 
        }
        #endregion

        #region //�����û�Id��ѯ�û����Żݷ�Χ
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
            return userDao.SearchUserConcessionRange(userId);
        }
        #endregion

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
			return userDao.GetDifferEmployeeAllUser();
		}

		#endregion

		#region ��ȡָ���û�ͨ���û�id

		/// <summary>
		/// ��ȡָ���û�ͨ���û�id
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
