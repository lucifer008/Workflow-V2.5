using System;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
/// <summary>
/// 名    称: CustomerPaidMoneyDetail 
/// 功能概要: 订单付款明细
/// 作    者: 张晓林
/// 创建时间: 2009年12月1日15:50:14
/// 修正履历:
/// 修正时间:
/// </summary>

public partial class finance_find_OrderPaidMoneyDetail : System.Web.UI.Page
{
    #region//ClassMember
    protected FinanceModel model;
    protected string customerName = "";
    public FinanceAction financeAction;
    public FinanceAction FinanceAction
    {
        set { financeAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = financeAction.Model;
        if (!IsPostBack)
        {
            string customerId = Request.QueryString["CustomerId"];
            if (null != customerId && "" != customerId)
            {
                QueryCustomerOweMoneyDetail();
            }
        }
    }
    private void QueryCustomerOweMoneyDetail()
    {
        Order order = new Order();
        order.InsertDateTimeString = Request.QueryString["GatheringDateTime"];//收款日期
        order.CustomerId = long.Parse(Request.QueryString["CustomerId"]);
        customerName = Request.QueryString["CustomerName"];
        string membercardNo = Request.QueryString["MembercardNo"];
        if (null != membercardNo && "" != membercardNo) order.MemberCardNo = membercardNo;
        order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
        order.Status1 = int.Parse(Constants.CONCESSION_TYPE_ZERO_VALUE);
        order.Status2 = int.Parse(Constants.CONCESSION_TYPE_CONCESSION_VALUE);
        order.Status3 = int.Parse(Constants.CONCESSION_TYPE_RENDERUP_VALUE);
        order.Status4 = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
        order.LastTelNo = Constants.PAY_KIND_CLOSED_VALUE;//结算款
        order.LinkManName = Constants.PAY_KIND_USE_PREPAY_VALUE;//预付款冲减
        order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//应收款处理金额
        order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
        order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(结算:冲减的预存款)
        order.CashName = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(应收款处理:冲减的预存款)
        order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//订单冲减
        order.OrderNoDispatch = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//舍入多收
        order.PayType = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;
        order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
        order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
        order.PayType = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;
        financeAction.Model.Orders = order;
        financeAction.SelectCustomerPaidAmountDetail();
    }
    #endregion

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
    }
}
