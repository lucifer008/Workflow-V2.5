using System;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
public partial class SearchRepayHistory :Workflow.Web.PageBase
{
    private string customerName = "";
    private string memberCardNo = "";
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;
    protected void Page_Load(object sender, EventArgs e)
    {
        model=findFinanceAction.Model;
        if (!IsPostBack)
        {
        }
        else
        {
            memberCardNo = Request.Form["MemberCardNo"];
            customerName = Request.Form["CustomerName"];
        }
        model.MemberCardNo = memberCardNo;
        model.CustomerName = customerName;
    }
    protected void Search(object sender, EventArgs e)
    {
        Order order = new Order();
        if (!StringUtils.IsEmpty(Request.Form["MemberCardNo"]))
        {
            order.MemberCardNo = Request.Form["MemberCardNo"];
        }
        else
        {
            order.MemberCardNo = "-1";
        }
        if (!StringUtils.IsEmpty(Request.Form["CustomerName"]))
        {
            order.CustomerName = Request.Form["CustomerName"];
            order.CustomerName = "-1";
        }
        model.Order = order;
        findFinanceAction.GetCustomerHistory();

    }
}
