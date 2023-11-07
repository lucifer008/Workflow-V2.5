using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Web;
using Workflow.Support;
/// <summary>
/// 名    称: order_SetDailyOrderDefaultCondition
/// 功能概要: 本日工单过滤条件
/// 作    者: 付强
/// 创建时间: 2009-1-7
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class order_SetDailyOrderDefaultCondition : PageBase
{
    #region 类成员
    protected bool closeFlag = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {}
        if (null != Request.Form["txtAction"] && 2 == int.Parse(Request.Form["txtAction"]))
        { 
            SetFilterCondition();
        }
    }
    #endregion

    #region 自定义方法
    protected void SetFilterCondition()
    {
        if ("" != Request.Form["txtBeginDateTime"] && "" != Request.Form["txtEndDateTime"])
        {
            Session["BeginDateTime"] = Request.Form["txtBeginDateTime"];
            Session["EndDateTime"] = Request.Form["txtEndDateTime"];
        }
        else 
        {
            Session["BeginDateTime"] = null;
            Session["EndDateTime"] = null;
            //Session["Date"] = "Now";
        }
        if (null != Request.Form["All"] && Request.Form["All"].ToLower() == "on")
        {
            Session["ORDER_FILTER_ALL"] = "1";
        }

        if (null != Request.Form["NoPrepay"] && "on" == Request.Form["NoPrepay"].ToLower())
        {
            Session["ORDER_FILTER_NOPREPAY"] = Constants.ORDER_STATUS_NOPREPAY_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_NOPREPAY"] = null;
        }


        if (null != Request.Form["NoDispatch"] && "on" == Request.Form["NoDispatch"].ToLower())
        {
            Session["ORDER_FILTER_NODISPATCH"] = Constants.ORDER_STATUS_NODISPATCHED_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_NODISPATCH"] = null;
        }
        if (null != Request.Form["Working"] && "on" == Request.Form["Working"].ToLower())
        {
            Session["ORDER_FILTER_WORKING"] = Constants.ORDER_STATUS_FACTURING_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_WORKING"] = null;
        }
        if (null != Request.Form["Finish"] && "on" == Request.Form["Finish"].ToLower())
        {
            Session["ORDER_FILTER_FINISHED"] = Constants.ORDER_STATUS_FINISHED_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_FINISHED"] = null;
        }

        if (null != Request.Form["NoClosed"] && "on" == Request.Form["NoClosed"].ToLower())
        {
            Session["ORDER_FILTER_NOCLOSED"] = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_NOCLOSED"] = null;
        }

        if (null != Request.Form["Closed"] && "on" == Request.Form["Closed"].ToLower())
        {
            Session["ORDER_FILTER_SUCCESSED"] = Constants.ORDER_STATUS_SUCCESSED_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_SUCCESSED"] = null;
        }
        if (null != Request.Form["BlankOut"] && "on" == Request.Form["BlankOut"].ToLower())
        {
            Session["ORDER_FILTER_BLANKOUT"] = Constants.ORDER_STATUS_BLANKOUT_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_BLANKOUT"] = null;
        }
        
        closeFlag = true;
        Response.Write("<script>opener.rVal='true';</script>");
        Response.Write("<script>window.close()</script>");
    }
    #endregion
}

