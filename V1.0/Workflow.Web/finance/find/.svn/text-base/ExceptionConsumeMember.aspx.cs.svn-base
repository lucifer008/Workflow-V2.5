using System;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Da.Domain;
using Workflow.Util;
using Workflow.Support;
public partial class finance_find_Default5 : Workflow.Web.PageBase
{
    private string balanceDateTime = "";
    private string insertDateTime = "";
    private string operator1 = "";
    private decimal amount1 = 0;
    private string memberCardNo = "";
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
        get { return findFinanceAction; }
    }
    protected FindFinanceModel model;

    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
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
            operator1 = Request.Form["sltSumAmount"];
            amount1 = decimal.Parse(Request.Form["SumAmount"]);
            memberCardNo = Request.Form["MemberCardNo"];
        }
        FindFinanceAction.Model.BalanceDateTimeString = balanceDateTime;
        FindFinanceAction.Model.InsertDateTimeString = insertDateTime;
        FindFinanceAction.Model.Operator1 = operator1;
        FindFinanceAction.Model.Amount1 = amount1;
        FindFinanceAction.Model.MemberCardNo = memberCardNo;
    }

    protected void Search(object sender, EventArgs e)
    {
        Order order = new Order();
        if (!StringUtils.IsEmpty(Request.Form["MemberCardNo"]))
        {
            order.MemberCardNo = Request.Form["MemberCardNo"];
        }
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
        model.Order = order;
        findFinanceAction.GetExceptionConsumeMemberCount();
    }
}
