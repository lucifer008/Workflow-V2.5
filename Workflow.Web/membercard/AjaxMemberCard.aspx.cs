using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Common.Logging;
using Workflow.Support.Ajax;
using System.Collections.Specialized;

public partial class AjaxMemberCard : Workflow.Web.PageBase
{
    private static readonly string JSON_ERROR_STRING = "{success:false}";
    private static readonly string AJAX_PROCESS_FIX_PREFIX = "ajaxProcess";
    private static readonly ILog LOG = LogManager.GetLogger(typeof(AjaxMemberCard));

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("pragma", "no-cache");
        Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
        Response.AppendHeader("expires", "0");
        try
        {
            string processResult = DoProcess(Request.QueryString);
            Response.Write(processResult);
        }
        catch (Exception err)
        {
            Response.Write(JSON_ERROR_STRING);
        }
	
        Response.End();
    }

    private string DoProcess(NameValueCollection queryString)
    {
        string ajaxProcessNo = queryString["a"];
        AjaxProcess process = (AjaxProcess)ApplicationContext.GetObject(AJAX_PROCESS_FIX_PREFIX + ajaxProcessNo);

        return process.DoProcess(queryString);
    }
}
