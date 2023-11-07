using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Service.Impl
{
    public class UserPermissionCheckServiceImpl:IUserPermissionCheckService
    {
        private IUserDao userDao;
        public IUserDao UserDao
        {
            set { userDao = value; }
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
            return userDao.GetAccreditUserInfo(user);
        }
        public IList<User> CheckCurrentUserPermissionByUserId()
        {
            return userDao.CheckCurrentUserPermissionByUserId();
        }

    }
}
