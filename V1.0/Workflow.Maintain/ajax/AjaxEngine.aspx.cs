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

/// <summary>
/// 名    称: AjaxEngine
/// 功能概要: 
/// 作    者: 祝新宾
/// 创建时间: 2007-9-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class AjaxEngine : Workflow.Web.PageBase
{
    private static readonly string JSON_ERROR_STRING = "{success:false}";
    private static readonly string AJAX_PROCESS_FIX_PREFIX = "ajaxProcess";
    private static readonly ILog LOG = LogManager.GetLogger(typeof(AjaxEngine));

    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("pragma", "no-cache");
        Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
        Response.AppendHeader("expires", "0");
        try
        {
            string processResult = DoProcess(Request.QueryString);
            //LOG.Debug(processResult);
            Response.Write(processResult);
        }
        catch (Exception err)
        {
            LOG.Error("", err);
            Response.Write(JSON_ERROR_STRING);
        }

        Response.End();
    }


    /// <summary>
    /// 方法名称: DoProcess
    /// 功能概要: 根据参数，获取相应的AjaxProcess，返回其处理的结果
    /// 作    者: 祝新宾
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    /// <param name="queryString"></param>
    /// <returns></returns>
    private string DoProcess(NameValueCollection queryString)
    {
        string ajaxProcessNo = queryString["a"];
        AjaxProcess process = (AjaxProcess)ApplicationContext.GetObject(AJAX_PROCESS_FIX_PREFIX + ajaxProcessNo);

        return process.DoProcess(queryString);
    }

}
