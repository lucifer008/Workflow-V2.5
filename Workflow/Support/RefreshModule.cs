using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Workflow.Support
{
    /// <summary>
    /// ��    ��: RefreshModule
    /// ���ܸ�Ҫ: ȫ��ģ�� ����ҳ��ˢ���ظ��ύ
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2010-1-21
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public class RefreshModule:IHttpModule
    {

        #region IHttpModule ��Ա

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
