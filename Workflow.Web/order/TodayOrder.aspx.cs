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
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Report;
using iTextSharp.text;
/// <summary>
/// 名    称: TodayOrder
/// 功能概要: 本日订单
/// 作    者: 付强
/// 创建时间: 2007-8-7
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class TodayOrder :PageBase
{

    #region //类成员
    protected string[] strList = null;
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    private SearchOrderAction sAction;
    public SearchOrderAction SearchOrderAction
    {
        set { sAction = value; }
    }

    #endregion

    #region //页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        strList = newOrderAction.GetDeliverMaturityTime.Split(',');
        //Session["Tag"]控制选项卡定位
        //Session["CurrentPageIndex"]控制分页定位
        model = newOrderAction.Model;

        #region //控制 自动刷新
        if (!IsPostBack)
        {
            if (null == Session["CurrentPageIndex"])//没有进行分页
            {
                if (null == Session["Tag"])//没有操作选项卡
                {
                    BindData("All", 0,false);//全部
                    actionTag.Value ="All";
                }
                else
                {
                    BindData(Session["Tag"].ToString(), 0,false);
                    actionTag.Value = Session["Tag"].ToString();
                }
            }
            else
            {
                BindData(Session["Tag"].ToString(), int.Parse(Session["CurrentPageIndex"].ToString()),false);
                actionTag.Value = Session["Tag"].ToString();
            }
        }
        #endregion

        #region //控制 选项卡变换
        else 
        {
            Session.Add("Tag", actionTag.Value.Trim());
            if ("false" == Request.Form["paginationTag"]) BindData(Session["Tag"].ToString(), 0, false);
        }
        #endregion

        PrintReport(); 
    }
    #endregion

    #region //分页数据绑定
    protected void AspNetPagerAll_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        BindData(Session["Tag"].ToString(), e.NewPageIndex - 1,true);
        Session.Add("CurrentPageIndex", e.NewPageIndex - 1);
    }

    private void BindData(string tag,int currentPageIndex,bool isNotPage) 
    {
        Order order = new Order();     
        switch(tag)
        {
            case "All":
                order.OrderFinished = Constants.ORDER_STATUS_SUCCESSED_VALUE.ToString();
                order.OrderNoClosed = Constants.ORDER_STATUS_BLANKOUT_VALUE.ToString();
                break;
            case "NoDispatch":
                order.StatusList.Add(Constants.ORDER_STATUS_NODISPATCHED_VALUE.ToString());
                break;
            case "Recepting":
                order.StatusList.Add(Constants.ORDER_STATUS_RECEPTING_VALUE.ToString());
                break;
            case "Facturing":
                order.StatusList.Add(Constants.ORDER_STATUS_FACTURING_VALUE.ToString());
                break;
            case "WaitForOrder":
                order.StatusList.Add(Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE.ToString());
                break;
            case "Sucessed":
                order.StatusList.Add(Constants.ORDER_STATUS_SUCCESSED_VALUE.ToString());
                break;
        }
        if (!isNotPage && "All"!=tag) currentPageIndex = 0;
        order.CurrentPageIndex = currentPageIndex; 
        order.Status2 = currentPageIndex;
        newOrderAction.Model.NewOrder = order;
        model.DailyOrder = newOrderAction.GetDailyOrderPager();
        model.MemberCardBrushNumber = newOrderAction.GetDailyOrderCount();
        AspNetPagerAll.RecordCount = model.MemberCardBrushNumber;
        AspNetPagerAll.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPagerAll.CurrentPageIndex = currentPageIndex + 1;
    }
    #endregion

    #region//打印报表
    /// <summary>
    /// 输出报表
    /// </summary>
    private void PrintReport()
    {
        string orderNo = Request.Form["orderNo"];
        if ("" == orderNo) orderNo = null;
        if (null == orderNo) orderNo = Request.QueryString["orderNo"];
        try
        {
            //订单详细信息
            if (null != orderNo)
            {
                newOrderAction.GetOrderInfo(orderNo);
                newOrderAction.GetOrderItemByOrderNo(orderNo);
                newOrderAction.GetOrderItemListByOrderNo(orderNo);
                newOrderAction.GetOrderItemPrintRequeireDetail(orderNo);
                newOrderAction.GetOrderItemFactorValueByOrderNo(orderNo);
                newOrderAction.GetFactorValue(true);
                newOrderAction.InitMasterData();
                newOrderAction.GetAllUser();
                newOrderAction.Model.CustomerName = Request.QueryString["CustomerName"];

                //订单员工信息
                Workflow.Da.Domain.OrderItemEmployee orderItemEmployee = new Workflow.Da.Domain.OrderItemEmployee();
                orderItemEmployee.No = orderNo;
                orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                orderItemEmployee.PositionId2 = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                orderItemEmployee.PositionId = Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                orderItemEmployee.Id = Constants.POSITION_RECEPTION_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                newOrderAction.Model.OrderItemEmployee.Add(orderItemEmployee);
                newOrderAction.SelectOldEmployee();
                newOrderAction.GetOrderPaymentConcessionByOrderId(newOrderAction.SelectOrderIdByOrderNo(orderNo));
                //送货人
                sAction.SearchDelivery(orderNo);
                ReportOrder ro = new ReportOrder();
                ro.IsDisplayBarCode = true;
                string reportName = "Order" + DateTime.Now.Ticks.ToString() + ".pdf";
                ro.FileName = Server.MapPath("~") + @"\reports\" + reportName;
                ro.CreateReport(newOrderAction.Model, "", "", PageSize.A4, 0, 0, 30, 30);//"业务委托订单", "业务委托订单", PageSize.A4, 0, 0, 30, 30);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);</script>");
                //处理页面重复提交
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);window.parent.location.href=window.parent.location.href;</script>");
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }

    #endregion
}
