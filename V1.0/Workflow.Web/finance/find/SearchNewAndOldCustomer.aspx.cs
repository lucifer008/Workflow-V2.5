using System;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
public partial class SearchNewAndOldCustomer : Workflow.Web.PageBase
{
    private string balanceDateTime = "";
    private string insertDateTime = "";
    private string operator1 = "";
    private string operator2 = "";
    private decimal amount1 = 0;
    private decimal amount2 = 0;
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
            model.BalanceDateTimeString = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
            model.InsertDateTimeString = DateTime.Now.ToString("yyyy-MM-dd");
            balanceDateTime = model.BalanceDateTimeString;
            insertDateTime = model.InsertDateTimeString;
        }
        else
        {
            balanceDateTime = Request.Form["BeginDateTime"];
            insertDateTime = Request.Form["EndDateTime"];
            operator1 = Request.Form["sltSumAmount"];
            operator2 = Request.Form["sltPaperCount"];
            amount1 = decimal.Parse(Request.Form["SumAmount"]);
            amount2 = decimal.Parse(Request.Form["PaperCount"]);
        }
        model.BalanceDateTimeString = balanceDateTime;
        model.InsertDateTimeString = insertDateTime;
        model.Operator1 = operator1;
        model.Operator2 = operator2;
        model.Amount1 = amount1;
        model.Amount2 = amount2;

    }
    protected void Search(object sender, EventArgs e)
    {
        Order order = new Order();
        if (!StringUtils.IsEmpty(Request.Form["SumAmount"]))
        {
            order.No = Request.Form["sltSumAmount"];
            order.SumAmount = decimal.Parse(Request.Form["SumAmount"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["PaperCount"]))
        {
            order.Name = Request.Form["sltPaperCount"];
            order.PaperCount = decimal.Parse(Request.Form["PaperCount"]);
        }
        order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
        model.Order = order;
        findFinanceAction.GetNewAndOldCustomerConsumeCount();
    }
}
