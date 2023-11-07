using System;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
public partial class ExceptionConsumeCustomer : Workflow.Web.PageBase
{
    private string balanceDateTime = "";
    private string insertDateTime = "";
    private string operator1 = "";
    private decimal amount1 = 0;
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;

    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        findFinanceAction.GetOperatorList();
        if (!IsPostBack)
        {
            findFinanceAction.Model.BalanceDateTimeString = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            findFinanceAction.Model.InsertDateTimeString = DateTime.Now.ToString("yyyy-MM-dd");
            balanceDateTime = findFinanceAction.Model.BalanceDateTimeString;
            insertDateTime = findFinanceAction.Model.InsertDateTimeString;
        }
        else
        {
            balanceDateTime = Request.Form["BeginDateTime"];
            insertDateTime = Request.Form["EndDateTime"];
            operator1 = Request.Form["sltSumAmount"];
            amount1 = decimal.Parse(Request.Form["SumAmount"]);
        }
        findFinanceAction.Model.BalanceDateTimeString = balanceDateTime;
        findFinanceAction.Model.InsertDateTimeString = insertDateTime;
        findFinanceAction.Model.Operator1 = operator1;
        findFinanceAction.Model.Amount1 = amount1;
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
        if (!StringUtils.IsEmpty(Request.Form["SumAmount"]))
        {
            order.No = Request.Form["sltSumAmount"];
            order.SumAmount = decimal.Parse(Request.Form["SumAmount"]);
        }
        order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
        findFinanceAction.Model.Order = order;
        findFinanceAction.GetExceptionConsumeCustomer();
    }
}
