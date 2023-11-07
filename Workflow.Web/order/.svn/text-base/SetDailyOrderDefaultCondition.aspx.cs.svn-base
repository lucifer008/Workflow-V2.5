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
using Workflow.Action;
using Workflow.Support;
/// <summary>
/// 名    称: order_SetDailyOrderDefaultCondition
/// 功能概要: 本日订单过滤条件
/// 作    者: 付强
/// 创建时间: 2009-1-7
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class order_SetDailyOrderDefaultCondition : PageBase
{
    #region 类成员
    protected bool closeFlag = false;
    //private NewOrderAction newOrderAction;
    //public NewOrderAction NewOrderAction
    //{
    //    set { newOrderAction = value; }
    //}
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {}
        //displayOrderInnerDayCount.Value = newOrderAction.GetDisplayOrderInnerDayCount().ToString();
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
        //else if ("" != Request.Form["txtBeginDateTime"] && "" == Request.Form["txtEndDateTime"])
        //{
        //    Session["BeginDateTime"] = Request.Form["txtBeginDateTime"];
        //    Session["EndDateTime"] = null;
        //}
        //else if ("" == Request.Form["txtBeginDateTime"] && "" != Request.Form["txtEndDateTime"])
        //{
        //    Session["BeginDateTime"] = null;
        //    Session["EndDateTime"] = Request.Form["txtEndDateTime"];
        //}
        else 
        {
            Session["BeginDateTime"] = null;
            Session["EndDateTime"] = null;
            //Session["Date"] = "Now";
            //int filterDayCount = Convert.ToInt32(displayOrderInnerDayCount.Value);
            //if (0 == filterDayCount - 1) filterDayCount = 0;
            //else filterDayCount = filterDayCount - 1;
            //if (filterDayCount >= 0)
            //{
            //    Session["BeginDateTime"] = DateTime.Now.Date.AddDays(-filterDayCount).Date.ToShortDateString();
            //    Session["EndDateTime"] = DateTime.Now.Date.AddDays(+1).Date.ToShortDateString();
            //}

        }

        //全部
        if (null != Request.Form["All"] && Request.Form["All"].ToLower() == "on")
        {
            Session["ORDER_FILTER_ALL"] = "1";
        }
        else 
        {
            Session["ORDER_FILTER_ALL"] = null;
        }

        //未预付订单
        if (null != Request.Form["NoPrepay"] && "on" == Request.Form["NoPrepay"].ToLower())
        {
            Session["ORDER_FILTER_NOPREPAY"] = Constants.ORDER_STATUS_NOPREPAY_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_NOPREPAY"] = null;
        }

        //未分配订单
        if (null != Request.Form["NoDispatch"] && "on" == Request.Form["NoDispatch"].ToLower())
        {
            Session["ORDER_FILTER_NODISPATCH"] = Constants.ORDER_STATUS_NODISPATCHED_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_NODISPATCH"] = null;
        }

        //制作中订单
        if (null != Request.Form["Working"] && "on" == Request.Form["Working"].ToLower())
        {
            Session["ORDER_FILTER_WORKING"] = Constants.ORDER_STATUS_FACTURING_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_WORKING"] = null;
        }
        //接待中
        if (null != Request.Form["cbReception"] && "on" == Request.Form["cbReception"].ToLower())
        {
            Session["ORDER_FILTER_RECEPTION"] = Constants.ORDER_STATUS_RECEPTING_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else 
        {
            Session["ORDER_FILTER_RECEPTION"] = null;
        }
        //已修正
        if (null != Request.Form["cbAdmendmented"] && "on" == Request.Form["cbAdmendmented"].ToLower())
        {
            Session["ORDER_FILTER_ADMENDMENTED"] = Constants.ORDER_STATUS_CONFIRM_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else 
        {
            Session["ORDER_FILTER_ADMENDMENTED"] = null;
        }
        
        //制作完工订单
        if (null != Request.Form["Finish"] && "on" == Request.Form["Finish"].ToLower())
        {
            Session["ORDER_FILTER_FINISHED"] = Constants.ORDER_STATUS_FINISHED_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_FINISHED"] = null;
        }

        //已登记订单
        if (null != Request.Form["NoClosed"] && "on" == Request.Form["NoClosed"].ToLower())
        {
            Session["ORDER_FILTER_NOCLOSED"] = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_NOCLOSED"] = null;
        }

        //已完成订单
        if (null != Request.Form["Closed"] && "on" == Request.Form["Closed"].ToLower())
        {
            Session["ORDER_FILTER_SUCCESSED"] = Constants.ORDER_STATUS_SUCCESSED_VALUE.ToString();
            Session["ORDER_FILTER_ALL"] = null;
        }
        else
        {
            Session["ORDER_FILTER_SUCCESSED"] = null;
        }

        //已作废订单
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

