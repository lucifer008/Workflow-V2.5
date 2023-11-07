using System;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
public partial class FinanceFindSearchTurnOver : Workflow.Web.PageBase
{
    private string balanceDateTime = "";
    private string insertDateTime = "";
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
        }
        model.BalanceDateTimeString = balanceDateTime;
        model.InsertDateTimeString = insertDateTime;
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
		if (!string.IsNullOrEmpty(order.BalanceDateTimeString) && !string.IsNullOrEmpty(order.InsertDateTimeString))
		{
			findFinanceAction.Model.Order = order;
			findFinanceAction.SelectBranShopTurnover();
		}
    }
}
