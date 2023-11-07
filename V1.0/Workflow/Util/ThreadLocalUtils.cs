using System;
using System.Collections.Generic;
using System.Text;
using Spring.Threading;
using System.Web;
using System.Collections;
using Workflow.Da.Domain;
namespace Workflow.Support
{
    public sealed class ThreadLocalUtils
    {
        private static string sessionName = typeof(ThreadLocalUtils).FullName;

        /// <summary>
        /// 当前执行上下文中的用户信息
        /// </summary>
        public static UserContext CurrentUserContext
        {
            get { return (UserContext)LogicalThreadContext.GetData(typeof(UserContext).FullName); }
            set { LogicalThreadContext.SetData(typeof(UserContext).FullName, value); }
            //get { return currentUser; }
            //set { currentUser = value; }

        }


        public static ThreadLocalUtils CurrentSession
        {
            get
            {
                object session = null;

                if (HttpContext.Current.Session != null)
                {
                    session = HttpContext.Current.Session[sessionName];
                }

                if (session == null)
                {
                    session = new ThreadLocalUtils();
                    HttpContext.Current.Session[sessionName] = session;
                }

                return (ThreadLocalUtils)session;
            }
            set
            {
                if (value == null)
                {
                    if (HttpContext.Current.Session != null)
                    {
                        HttpContext.Current.Session.Remove(sessionName);
                    }
                }
                else
                {
                    HttpContext.Current.Session[sessionName] = value;
                }
            }
        }

        private User currentUser;
        /// <summary>
        /// 当前环境的用户信息
        /// </summary>
        public User CurrentUser
        {
            get { return currentUser; }
            set { currentUser = value; }
        }

        private string lastVisitedUrl;
        public string LastVisitedUrl
        {
            get { return lastVisitedUrl; }
            set { lastVisitedUrl = value; }
        }

    }



}
