using System;
using Workflow.Da.Domain;
using Workflow.Util;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
public partial class FinanceFindSearchPayment : Workflow.Web.PageBase
{
    private string balanceDateTime = "";
    private string insertDateTime = "";
    private string customerName = "";
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        if (!IsPostBack)
        {
            model.BalanceDateTimeString = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            model.InsertDateTimeString = DateTime.Now.ToString("yyyy-MM-dd");
            balanceDateTime = model.BalanceDateTimeString;
            insertDateTime = model.InsertDateTimeString;
        }
        else
        {
            balanceDateTime = Request.Form["BeginDateTime"];
            insertDateTime = Request.Form["EndDateTime"];
            customerName = Request.Form["CustomerName"];
        }
        model.BalanceDateTimeString = balanceDateTime;
        model.InsertDateTimeString = insertDateTime;
        model.CustomerName = customerName;
    }
    protected void Search(object sender, EventArgs e)
    {
        Order order = new Order();
        if (!StringUtils.IsEmpty(Request.Form["BeginDateTime"]))
        {
            order.BalanceDateTimeString = Request.Form["BeginDateTime"];
        }
        if (!StringUtils.IsEmpty(Request.Form["EndDateTime"]))
        {
            order.InsertDateTimeString = Request.Form["EndDateTime"];
        }
        if (!StringUtils.IsEmpty(Request.Form["CustomerName"]))
        {
            order.CustomerName = Request.Form["CustomerName"];
        }
        model.Order = order;
        findFinanceAction.GetCustomerPayment();
    }
}
