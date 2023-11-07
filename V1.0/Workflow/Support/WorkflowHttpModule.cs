using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using Workflow.Da.Domain;
using System.Configuration;
using System.Web.SessionState;
using Workflow.Util;
using Workflow.Support.Log;

namespace Workflow.Support
{
    /// <summary>
    /// 名    称: WorkflowHttpModule
    /// 功能概要: 全局模块
    /// 作    者: 付强
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class WorkflowHttpModule : IHttpModule,IRequiresSessionState
    {
        #region IHttpModule 成员
        public void Init(HttpApplication context)
        {
            context.BeginRequest += new EventHandler(OnBeginRequest);
            context.EndRequest += new EventHandler(OnEndRequest);
            context.PostAcquireRequestState += new EventHandler(OnAcquireRequestState);
			context.Error += new EventHandler(OnError);
        }

        public void Dispose()
        {
            
        }

        #endregion


        public void OnAcquireRequestState(Object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            if (app.Context.Session != null)
            {
                if (ThreadLocalUtils.CurrentSession != null && ThreadLocalUtils.CurrentSession.CurrentUser != null)
                {
                    UserContext userContext = new UserContext();
                    userContext.CurrentUser = ThreadLocalUtils.CurrentSession.CurrentUser;
                    ThreadLocalUtils.CurrentUserContext = userContext;
                    for (int i = 0; i < ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList.Count; i++)
                    {
                        if (Constants.CONCESSION_TYPE_CONCESSION_VALUE == ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList[i].ConcessionType)
                        {
                            ThreadLocalUtils.CurrentUserContext.CurrentUser.ConcessionMin = ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList[i].Min;
                            ThreadLocalUtils.CurrentUserContext.CurrentUser.ConcessionMax = ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList[i].Max;
                        }
                        else if (Constants.CONCESSION_TYPE_RENDERUP_VALUE == ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList[i].ConcessionType)
                        {
                            ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMin = ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList[i].Min;
                            ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMax = ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList[i].Max;
                        }
                        else if (Constants.CONCESSION_TYPE_ZERO_VALUE == ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList[i].ConcessionType)
                        {
                            ThreadLocalUtils.CurrentUserContext.CurrentUser.ZeroMin = ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList[i].Min;
                            ThreadLocalUtils.CurrentUserContext.CurrentUser.ZeroMax = ThreadLocalUtils.CurrentSession.CurrentUser.UserConcessionRangeList[i].Max;
                        }
                    }
                }
            }
            HttpRequest req = ((HttpApplication)sender).Request;
            if (req.Url.ToString().ToLower().EndsWith(".aspx") )
            {
                string[] strName = req.Url.ToString().ToLower().Split('/');
                if (req.UrlReferrer == null )
                {
                    if (!strName[strName.Length - 1].Equals("selectcustomer.aspx") &&
                        !strName[strName.Length - 1].Equals("newcustomer.aspx") &&
                        !strName[strName.Length - 1].Equals("printrequest.aspx") &&
                        !strName[strName.Length - 1].Equals("todayorder.aspx") &&
                        !strName[strName.Length - 1].Equals("setdailyorderdefaultcondition.aspx") &&
                        !strName[strName.Length - 1].Equals("accredit.aspx") &&
                        !strName[strName.Length - 1].Equals("loginout.aspx") &&
                        !strName[strName.Length - 1].Equals("newgetingorder.aspx") &&
                        !strName[strName.Length - 1].Equals("top.aspx") &&
                        !strName[strName.Length - 1].Equals("login.aspx") &&
                        !strName[strName.Length - 1].Equals("updatepassword.aspx") &&
                        !strName[strName.Length - 1].Equals("addbusinesstype.aspx") &&
                        !strName[strName.Length - 1].Equals("clearcache.aspx") &&
                        !strName[strName.Length - 1].Equals("workflowerrorexception.aspx") &&
                        !strName[strName.Length - 1].Equals("notfounderror.aspx") &&
                        !strName[strName.Length - 1].Equals("logoutuser.aspx") &&
                        !strName[strName.Length - 1].Equals("accessdenied.aspx"))
                    {
                        if (ThreadLocalUtils.CurrentUserContext == null || ThreadLocalUtils.CurrentUserContext.CurrentUser == null)
                        {

                            ((HttpApplication)sender).Response.Redirect("~/Login.aspx", true);
                        }
                        else
                        {
                            ((HttpApplication)sender).Response.Redirect("~/error/AccessDenied.aspx", true);
                        }
                    }
                }
                else
                {

                    if (!strName[strName.Length - 1].Equals("login.aspx") &&
                        !strName[strName.Length - 1].Equals("accredit.aspx") && 
                        (ThreadLocalUtils.CurrentUserContext == null || ThreadLocalUtils.CurrentUserContext.CurrentUser == null))
                    {
                        ((HttpApplication)sender).Response.Redirect("~/Login.aspx", true);
                    }
                }
            }
        }

        public void OnBeginRequest(Object sender, EventArgs e)
        {
            //userContext.CurrentUser = user;
            ////userContext.CurrentUser = GetUser();
            //ThreadLocalUtils.CurrentUserContext = userContext;
        }

		public void OnEndRequest(Object sender, EventArgs e)
		{
		}


		public void OnError(Object sender, EventArgs e)
		{
            //HttpApplication context = sender as HttpApplication;
            //LogHelper.WriteError(context.Server.GetLastError(), Constants.LOGGER_NAME);
            //Workflow.Support.Exception.PermissionDeniedException pde = context.Server.GetLastError().InnerException as Workflow.Support.Exception.PermissionDeniedException;
            //if(pde!=null)
            //{
            //    context.Server.ClearError();
            //    context.Response.Redirect("~/error/AccessDenied.aspx", true);
            //}
            //else
            //{
            //    context.Server.ClearError();
            //    context.Response.Redirect("~/error/WorkflowErrorException.aspx", true);
            //}
		}

        /// <summary>
        /// 根据上下文环境构造一个User对象
        /// </summary>
        /// <returns></returns>
        private User GetUser()
        {
            User user=new User() ;
            user.Id = 1;
            user.CompanyId = Constants.COMPANY_ID;
            user.BranchShopId = 1;
            user.InsertDateTime = DateTime.Now;
            user.UpdateDateTime = DateTime.Now;
            return user;
        }
    }
}
