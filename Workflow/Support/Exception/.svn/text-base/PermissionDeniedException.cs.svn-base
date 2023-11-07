using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Support.Exception
{
    public class PermissionDeniedException:System.Exception
    {
        public PermissionDeniedException()
            : base()
        { }
        public PermissionDeniedException(User user)
            : base(user.EmployeeName+" 试图访问没有权限的操作。")
        { }
        public PermissionDeniedException(string message)
            : base(message)
        { }
    }
}
