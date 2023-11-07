using System;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Util;

public partial class ExceptionPriceOrderView : Workflow.Web.PageBase
{
    private string balanceDateTime = "";
    private string insertDateTime = "";
    private string operator1 = "";
    private string operator2 = "";
    private string operator3 = "";
    private decimal amount1 = 0;
    private decimal amount2 = 0;
    private decimal amount3 = 0;
    private string customerName = "";
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
        get { return findFinanceAction; }
    }
    protected FindFinanceModel model;
    protected void Page_Load(object sender, EventArgs e)
    {
        model=findFinanceAction.Model;
        FindFinanceAction.GetOperatorList();
        if (!IsPostBack)
        {
            FindFinanceAction.Model.BalanceDateTimeString = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            FindFinanceAction.Model.InsertDateTimeString = DateTime.Now.ToString("yyyy-MM-dd");
            balanceDateTime = FindFinanceAction.Model.BalanceDateTimeString;
            insertDateTime = FindFinanceAction.Model.InsertDateTimeString;
        }
        else
        {
            balanceDateTime = Request.Form["BeginDateTime"];
            insertDateTime = Request.Form["EndDateTime"];
            operator1 = Request.Form["SltZero"];
            operator2 = Request.Form["SltConcession"];
            operator3 = Request.Form["sltGiveAway"];
            amount1 = decimal.Parse(Request.Form["Zero"]);
            amount2 = decimal.Parse(Request.Form["Concession"]);
            amount3 = decimal.Parse(Request.Form["GiveAway"]);
            customerName = Request.Form["CustomerName"];
        }
        FindFinanceAction.Model.BalanceDateTimeString = balanceDateTime;
        FindFinanceAction.Model.InsertDateTimeString = insertDateTime;
        FindFinanceAction.Model.Operator1 = operator1;
        FindFinanceAction.Model.Operator2 = operator2;
        FindFinanceAction.Model.Operator3 = operator3;
        FindFinanceAction.Model.Amount1 = amount1;
        FindFinanceAction.Model.Amount2 = amount2;
        FindFinanceAction.Model.Amount3 = amount3;
        FindFinanceAction.Model.CustomerName = customerName;
    }
    protected void Search(object sender, EventArgs e)
    {
        Order order = new Order();
        if (!StringUtils.IsEmpty(Request.Form["CustomerName"]))
        {
            order.CustomerName = Request.Form["CustomerName"];
        }
        if (!StringUtils.IsEmpty(Request.Form["Zero"]))
        {
            order.No=Request.Form["sltZero"];
            order.Zero = decimal.Parse(Request.Form["Zero"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["Concession"]))
        {
            order.LinkManName = Request.Form["sltConcession"];
            order.Concession = decimal.Parse(Request.Form["Concession"]);
        }

        if (!StringUtils.IsEmpty(Request.Form["GiveAway"]))
        {
            order.LastTelNo = Request.Form["sltGiveAway"];
            order.GiveAway = decimal.Parse(Request.Form["GiveAway"]);
        }

        if (!StringUtils.IsEmpty(Request.Form["BeginDateTime"]))
        {
            order.BalanceDateTimeString = Request.Form["BeginDateTime"];
        }

        if (!StringUtils.IsEmpty(Request.Form["EndDateTime"]))
        {
            order.InsertDateTimeString = Request.Form["EndDateTime"];
        }
        order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
        findFinanceAction.Model.Order = order;
        findFinanceAction.GetExceptionPriceOrdersCount();
    }
}


