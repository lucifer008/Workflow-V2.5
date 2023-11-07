using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Support.Exception;

namespace Workflow.Support.Permission.Impl
{
    public class AccreditImpl:IAccredit
    {
        public void TheMethod()
        {
            throw new System.Exception("The method or operation is not implemented.");
        }

        public bool ModifyPrice(User user)
        {
            //check this user can modify price or not  in DB
            if (user.Id == 1)
            {
                return true;
            }
            else
            {
                throw new PermissionDeniedException(user);
            }
        }

    }
}
