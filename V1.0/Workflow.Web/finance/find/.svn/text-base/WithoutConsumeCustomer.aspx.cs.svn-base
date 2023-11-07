using System;
using System.Collections;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;

public partial class finance_find_WithoutConsumeCustomer : Workflow.Web.PageBase
{
    private string balanceDateTime = "";
    private string insertDateTime = "";

    private long customerType = 0;
    private long customerLevel = 0;
    private long memberCardLevel = 0;
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        findFinanceAction.GetAllMasterDate();
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
            customerLevel=long.Parse(Request.Form["CustomerLevel"]);
            customerType = long.Parse(Request.Form["CustomerType"]);
            memberCardLevel = long.Parse(Request.Form["MemberCardLevel"]);
        }
        findFinanceAction.Model.BalanceDateTimeString = balanceDateTime;
        findFinanceAction.Model.InsertDateTimeString = insertDateTime;
        findFinanceAction.Model.Operator1 = customerLevel.ToString();
        findFinanceAction.Model.Operator2 = customerType.ToString();
        findFinanceAction.Model.Operator3 = memberCardLevel.ToString();
    }
    protected void Search(object sender, EventArgs e)
    {
        Hashtable customer = new Hashtable();
        if (!StringUtils.IsEmpty(Request.Form["CustomerLevel"]) && Request.Form["CustomerLevel"]!="0")
        {
            customer.Add("CustomerLevel", long.Parse(Request.Form["CustomerLevel"]));
        }

        if (!StringUtils.IsEmpty(Request.Form["CustomerType"]) && Request.Form["CustomerType"] != "0")
        {
            customer.Add("CustomerType", long.Parse(Request.Form["CustomerType"]));
        }

        if (!StringUtils.IsEmpty(Request.Form["MemberCardLevel"]) && Request.Form["MemberCardLevel"] != "0")
        {
            customer.Add("MemberCardLevel", long.Parse(Request.Form["MemberCardLevel"]));
        }

        if (!StringUtils.IsEmpty(Request.Form["BeginDateTime"]))
        {
            customer.Add("BeginTime", Request.Form["BeginDateTime"]);
        }

        if (!StringUtils.IsEmpty(Request.Form["EndDateTime"]))
        {
            customer.Add("EndTime", Request.Form["EndDateTime"]);
        }
        findFinanceAction.GetWithoutConsumeCustomer(customer);

    }
}
