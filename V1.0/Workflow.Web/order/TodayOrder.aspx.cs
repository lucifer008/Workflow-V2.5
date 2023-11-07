using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using Workflow.Web;
using Workflow.Util;
using Workflow.Enums;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
/// <summary>
/// 名    称: TodayOrder
/// 功能概要: 本日工单
/// 作    者: 付强
/// 创建时间: 2007-8-7
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class TodayOrder :PageBase
{

    #region 类成员
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData(0);
        }
        model = newOrderAction.Model;
    }
    #endregion

    #region 数据绑定
    private void BindData(int currentPageIndex)
    {
        newOrderAction.Model.NewOrder.CurrentPageIndex = currentPageIndex;

        if (null != Session["BeginDateTime"] && null != Session["EndDateTime"])
        {
            newOrderAction.Model.NewOrder.InsertDateTimeString = Session["BeginDateTime"].ToString();
            newOrderAction.Model.NewOrder.BalanceDateTimeString = Session["EndDateTime"].ToString();
        }
        else 
        {
            newOrderAction.Model.NewOrder.InsertDateTimeString = DateTime.Now.Date.ToString();
            newOrderAction.Model.NewOrder.BalanceDateTimeString = DateTime.Now.AddDays(+1).Date.ToString();
        }
        //代表全部
        newOrderAction.Model.NewOrder.OrderAll = "1";
        if (null != Session["ORDER_FILTER_BLANKOUT"])
        {
            newOrderAction.Model.NewOrder.OrderBlankOut = Session["ORDER_FILTER_BLANKOUT"].ToString();
            newOrderAction.Model.NewOrder.OrderAll = null;
        }
        if (null != Session["ORDER_FILTER_FINISHED"])
        {
            newOrderAction.Model.NewOrder.OrderFinished = Session["ORDER_FILTER_FINISHED"].ToString();
            newOrderAction.Model.NewOrder.OrderAll = null;
        }
        if (null != Session["ORDER_FILTER_NODISPATCH"])
        {
            newOrderAction.Model.NewOrder.OrderNoDispatch = Session["ORDER_FILTER_NODISPATCH"].ToString();
            newOrderAction.Model.NewOrder.OrderAll = null;
        }
        if (null != Session["ORDER_FILTER_SUCCESSED"])//当天已完成
        {
            newOrderAction.Model.NewOrder.OrderSuccessed = Session["ORDER_FILTER_SUCCESSED"].ToString();
            newOrderAction.Model.NewOrder.OrderAll = null;
            newOrderAction.Model.NewOrder.LinkManName =null;
        }
        if (null != Session["ORDER_FILTER_WORKING"])
        {
            newOrderAction.Model.NewOrder.OrderWorking = Session["ORDER_FILTER_WORKING"].ToString();
            newOrderAction.Model.NewOrder.OrderAll = null;
        }

        if (null != Session["ORDER_FILTER_NOPREPAY"])
        {
            newOrderAction.Model.NewOrder.OrderNoPrepay = Session["ORDER_FILTER_NOPREPAY"].ToString();
            newOrderAction.Model.NewOrder.OrderAll = null;
        }
        if (null != Session["ORDER_FILTER_NOCLOSED"])//当天已登记
        {
            newOrderAction.Model.NewOrder.OrderNoClosed = Session["ORDER_FILTER_NOCLOSED"].ToString();
            newOrderAction.Model.NewOrder.OrderAll = null;
            newOrderAction.Model.NewOrder.LinkManName = null;
        }
        else
        {
            newOrderAction.Model.NewOrder.LinkManName = "Yes";
        }

        int rowCounter = newOrderAction.GetDailyOrderCount();
        newOrderAction.Model.NewOrder.CurrentPageIndex = currentPageIndex;
        newOrderAction.Model.NewOrder.Status2 = currentPageIndex;
        newOrderAction.GetDailyOrderPager();
        this.AspNetPager1.RecordCount = rowCounter;
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

    }
    #endregion

    #region  分页控件事件
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        BindData(e.NewPageIndex - 1);
    }
    #endregion
}
