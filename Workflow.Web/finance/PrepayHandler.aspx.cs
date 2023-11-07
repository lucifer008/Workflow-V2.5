using System;
using System.Collections.Generic;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
/// <summary>
/// 收预收款
/// </summary>
/// <remarks>
/// 作    者: 付强
/// 创建时间: 2007-10-13
/// 修正履历: 张晓林
/// 修正时间:2009-1-17
///            去掉多余的命名空间,增加捕获异常处理
/// 修正履历:张晓林
/// 修正时间:2009年3月9日14:47:10
/// 修正描述:增加：按日期查询；合计预收款;
/// </remarks>
public partial class PrepayHandler : Workflow.Web.PageBase
{
    #region Class Member
    protected OrderModel oModel;
    protected FinanceModel fModel;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    private FinanceAction financeAction;
    public FinanceAction FinanceAction
    {
        set { financeAction = value; }
    }
    private static string orderNo = "";
    private static long orderId = 0;
    public static string limitValue = "";
    protected string lastShowOrderNo = "";
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                limitValue = financeAction.GetPrePayLimitType();
                GetAllNeedPrePayOrders(1);
            }
            oModel = newOrderAction.Model;
            fModel = financeAction.Model;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }

    private void GetAllNeedPrePayOrders(int currentPageIndex)
    {
        Order order = new Order();
        //newOrderAction.Model.NewOrder = new Order();
        if (null != ViewState["OrderNo"] && "" != ViewState["OrderNo"].ToString()) 
        {
            order.No = ViewState["OrderNo"].ToString();
        }

        if(null!=ViewState["BeginDateTime"] && ""!=ViewState["BeginDateTime"].ToString())
        {
            order.BalanceDateTimeString = ViewState["BeginDateTime"].ToString();
        }
        if(null!=ViewState["EndDateTime"] && ""!=ViewState["EndDateTime"].ToString())
        {
            order.InsertDateTimeString = ViewState["EndDateTime"].ToString();
        }
        if (null != ViewState["memberCardNo"] && !string.IsNullOrEmpty(ViewState["memberCardNo"].ToString()))
        {
            order.MemberCardNo = ViewState["memberCardNo"].ToString();
        }
        order.Memo = "只显示有预收的订单信息";
        
        order.CurrentPageIndex = currentPageIndex - 1;
        order.EveryPageCount = Constants.ROW_COUNT_FOR_PAGER;
        newOrderAction.Model.NewOrder = order;    
        newOrderAction.GetAllNeedPrePayOrders();

        this.AspNetPager1.CurrentPageIndex = currentPageIndex;
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        this.AspNetPager1.RecordCount = Convert.ToInt32(newOrderAction.Model.NeedPrePayOrdersCount);
        ViewState.Add("OrderNo",order.No);
        ViewState.Add("BeginDateTime", order.BalanceDateTimeString);
        ViewState.Add("EndDateTime", order.InsertDateTimeString);
        ViewState.Add("MemberCardNo", order.MemberCardNo);
    }
    #endregion

    #region Search
    protected void SearchOrder(object sender, EventArgs e)
    {
        try
        {
            Order order = new Order();
            if (!string.IsNullOrEmpty(Request.Form["txtOrderNo"]))
            {
                order.No = Request.Form["txtOrderNo"];
            }

            if(!string.IsNullOrEmpty(Request.Form["beginDateTime"]))
            {
                order.BalanceDateTimeString = Request.Form["beginDateTime"];
            }

            if (!string.IsNullOrEmpty(Request.Form["endDateTime"]))
            {
                order.InsertDateTimeString = Request.Form["endDateTime"];
            }

            if (!string.IsNullOrEmpty(Request.Form["memberCardNo"]))
            {
                order.MemberCardNo = Request.Form["memberCardNo"];
            }

            //order.Memo = "只显示有预收的订单信息";

            order.EveryPageCount = Constants.ROW_COUNT_FOR_PAGER;
            order.CurrentPageIndex = 0;
            newOrderAction.Model.NewOrder = order;
            newOrderAction.GetAllNeedPrePayOrders();
            this.AspNetPager1.CurrentPageIndex = 1;
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            this.AspNetPager1.RecordCount = Convert.ToInt32(newOrderAction.Model.NeedPrePayOrdersCount);

            ViewState.Add("OrderNo", order.No);
            ViewState.Add("BeginDateTime", order.BalanceDateTimeString);
            ViewState.Add("EndDateTime", order.InsertDateTimeString);
            ViewState.Add("MemberCardNo", order.MemberCardNo);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }

    #region 分页控件事件
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        GetAllNeedPrePayOrders(e.NewPageIndex);
    }
    #endregion
    #endregion

    #region Save
    protected void Save(object sender, EventArgs e)
    {
        try
        {
            orderNo = Request.Form["txtOrderNo"];
            orderId = newOrderAction.SelectOrderIdByOrderNo(orderNo);
            if (orderId == -1)
            {
                Response.Write("<script>alert('请输入正确的订单号!')</script>");
                GetAllNeedPrePayOrders(1);
                return;
            }

            Gathering gathering = new Gathering();
            gathering.Amount = decimal.Parse(Request.Form["PrepayMoney"]);
            gathering.GatheringDateTime = DateTime.Now;

            GatheringOrder gatheringOrder = new GatheringOrder();
            gatheringOrder.PayKind = Constants.PAY_KIND_PREPAY_VALUE;
            gatheringOrder.OrdersId = orderId;

            financeAction.Model.Gatherings = gathering;
            financeAction.Model.GatheringOrders = gatheringOrder;

            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.OrdersId = orderId;
            orderStatusAlter.Status = Constants.ORDER_STATUS_NODISPATCHED_VALUE;
            orderStatusAlter.Memo = "收预收款";
            financeAction.Model.OrderStatusAlter = orderStatusAlter;

            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            RelationEmployee relationEmp = new RelationEmployee();
            relationEmp.EmployeeId = user.EmployeeId;
            financeAction.Model.RelationEmployee = relationEmp;
            financeAction.PrepayHandler(orderNo, Workflow.Support.Constants.ORDER_STATUS_NODISPATCHED_VALUE);
            
            GetAllNeedPrePayOrders(1);
            //保存完之后,就不再页面上显示信息了.
            financeAction.Model.Orders = null;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }

    }
    #endregion
}
