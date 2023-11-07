using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Workflow.Support
{
    /// <summary>
    /// 名    称: RefreshModule
    /// 功能概要: 全局模块 处理页面刷新重复提交
    /// 作    者: 付强
    /// 创建时间: 2010-1-21
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class RefreshModule:IHttpModule
    {

        #region IHttpModule 成员

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(OnAcquireRequestState);
        }

        #endregion

        private void OnAcquireRequestState(object sender, EventArgs e)
        {
            HttpApplication app = (HttpApplication)sender;
            HttpContext ctx = app.Context;

            if (null==ctx.Session) return;
            if (ctx.Session["LastTicketServed"] == null)
                ctx.Session["LastTicketServed"] = 0;

            ctx.Items["IsRefresh"] = false;

            int lastTicket = Convert.ToInt32(ctx.Session["LastTicketServed"]);
            int thisTicket = Convert.ToInt32(ctx.Request["__Ticket"]);

            if (thisTicket > lastTicket ||
                (thisTicket == lastTicket && thisTicket == 0))
            {
                ctx.Session["LastTicketServed"] = thisTicket;
                ctx.Items["IsRefresh"] = false;
            }
            else
            {
                ctx.Items["IsRefresh"] = true;
            }

        }
    }
}
