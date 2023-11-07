using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// ��    ��: IUserDao
/// ���ܸ�Ҫ: �û��ӿ�
/// ��    ��: ��ǿ
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table USERS ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IUserDao : IDaoBase<User>
    {
        /// <summary>
        /// ����û���������
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User CheckUserNameAndPassword(User user);

        /// <summary>
        /// �����û������������û�Ȩ��
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        User CheckUserPermissionByUserNameAndPassword(User user);

        /// <summary>
        /// �����û�ID����û�Ȩ��
        /// </summary>
        /// <returns></returns>
        IList<User> CheckCurrentUserPermissionByUserId();
        
        /// <summary>
        /// �����û�Id��ȡ�û���
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        string GetEmployeeNameByUserId(User user);

        /// <summary>
        /// �޸��û���½״̬
        /// </summary>
        /// <param name="user"></param>
        void UpdateUserLoginStatus(User user);

        /// <summary>
        /// �����û�����
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int UpdateUserPassWord(User user);

        /// <summary>
        /// ����û��Ƿ��½
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        bool CheckUserIsLogin(User user);

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
        IList<User> GetAllUsers(User user);

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
        IList<User> SearchUserInfo(User user);

         /// <summary>
        /// ��ȡ�����û���¼��
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        long GetAllUserRowCount(User user);

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
        IList<UserRole> GetAllRole();

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
        void DeleteUserInfo(User user);

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
        void UpdateUserInfo(User user);

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
        long SearchDeleteUserIsUse(User user);

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
        void DeleteUserRoleInfo(User user);

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
        long CheckUserNameIsExist(User user);

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
        void DeleteUserConcessionRanceByUserId(long userId);

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
        long CheckUserIsNotConcessionRange(long userId);

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
        IList<UserConcessionRange> SearchUserConcessionRange(long userId);

		#region ��ȡ����ͬ��Ա�������û�

		/// <summary>
		/// ��ȡ����ͬ��Ա�������û�
		/// </summary>
		/// <returns>�û��б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-5-6
		/// </remarks>
		IList<User> GetDifferEmployeeAllUser();

		#endregion

        void ExitLogoutUser(User user);
	}
}
