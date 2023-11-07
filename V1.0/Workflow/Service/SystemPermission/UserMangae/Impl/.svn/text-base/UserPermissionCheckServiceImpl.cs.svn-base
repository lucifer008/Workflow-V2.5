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

        public User CheckUserPermissionByUserNameAndPassword(User user)
        {
            return userDao.CheckUserPermissionByUserNameAndPassword(user);
        }
        public IList<User> CheckCurrentUserPermissionByUserId()
        {
            return userDao.CheckCurrentUserPermissionByUserId();
        }

    }
}
