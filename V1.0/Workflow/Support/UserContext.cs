using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Web;
using System.Web.SessionState;

namespace Workflow.Support
{
    public class UserContext
    {
        /// <summary>
        /// ��ǰִ�л����е��û�
        /// </summary>
        private User currentUser;
        public  User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

    }

}
