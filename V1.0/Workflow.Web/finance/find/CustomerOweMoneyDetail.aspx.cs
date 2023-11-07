using System;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
/// <summary>
/// 名    称: CustomerOweMoneyDetail 
/// 功能概要: 客户欠款明细
/// 作    者: 张晓林
/// 创建时间: 2009年10月22日13:31:35
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class finance_find_CustomerOweMoneyDetail : System.Web.UI.Page
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
        model=financeAction.Model;
        if(!IsPostBack)
        {
            if (null != Request.QueryString["CustomerId"] && "" != Request.QueryString["CustomerId"])
            {
                QueryCustomerOweMoneyDetail();
            }
        }
    }
    private void QueryCustomerOweMoneyDetail() 
    {
        Order order = new Order();
        order.CustomerId = long.Parse(Request.QueryString["CustomerId"]);
        customerName = Request.QueryString["CustomerName"];
        order.Status = Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE;
        order.Status1 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_ZERO_VALUE);
        order.Status2 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_CONCESSION_VALUE);
        order.Status3 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_RENDERUP_VALUE);
        order.LastTelNo = Constants.PAY_KIND_CLOSED_VALUE;//结算款
        order.LinkManName = Constants.PAY_KIND_USE_PREPAY_VALUE;//预付款冲减
        order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//应收款处理金额
        order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
        order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(结算:冲减的预存款)
        order.CashName = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(应收款处理:冲减的预存款)
        order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
        order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
        financeAction.Model.Orders = order;
        financeAction.SelectNotHaveBeenPaidOrder();
    }
    #endregion
}
