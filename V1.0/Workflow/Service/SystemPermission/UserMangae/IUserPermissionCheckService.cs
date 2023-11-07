using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Service
{
    public interface IUserPermissionCheckService
    {
        User CheckUserPermissionByUserNameAndPassword(User user);
        IList<User> CheckCurrentUserPermissionByUserId();
        
    }
}
