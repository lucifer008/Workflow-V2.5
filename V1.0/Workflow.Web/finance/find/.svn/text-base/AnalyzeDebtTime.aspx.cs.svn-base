using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflow.Action.Finance;
using Workflow.Da.Domain;
using Workflow.Util;

public partial class FinanceAnalyzeDebtTime : Workflow.Web.PageBase
{
    private string balanceDateTime = "";
    private string insertDateTime = "";
    private string customerName = "";
    private long employeeId = 0;
    public FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        findFinanceAction.GetCasherEmployeeList(4);
        
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
            customerName = Request.Form["txtKey"];
            employeeId = long.Parse(Request.Form["casherEmployee"]);
        }
        findFinanceAction.Model.BalanceDateTimeString = balanceDateTime;
        findFinanceAction.Model.InsertDateTimeString = insertDateTime;
        findFinanceAction.Model.CustomerName = customerName;
        findFinanceAction.Model.EmployeeId = employeeId;
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

        if (!StringUtils.IsEmpty(Request.Form["txtKey"]))
        {
            order.Memo = "%" + Request.Form["txtKey"]+"%";
        }
        else
        {
            order.Memo = "%%";
        }
        if (Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_KEY!=Request.Form["casherEmployee"])
        { 
            User user=new User();
            user.Id=long.Parse(Request.Form["casherEmployee"]);
            order.CashUser=user;
        }
        
        order.Status = Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE;
        findFinanceAction.Model.Order = order;
        findFinanceAction.GetAnalyzeDebt();
    }
}
