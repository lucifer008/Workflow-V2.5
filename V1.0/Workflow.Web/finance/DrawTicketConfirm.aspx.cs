using System;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;

/// <summary>
/// 名    称: DrawTicketConfirm
/// 功能概要: 发票领取金额确认界面
/// 作    者: 张晓林
/// 创建时间: 2009年3月24日11:23:47
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class finance_DrawTicketConfirm : System.Web.UI.Page
{
    #region //Class Member
    private FinanceAction financeAction;
    public FinanceAction FinanceAction
    {
        set { financeAction = value; }
    }

    protected FinanceModel model;
    protected decimal drawTicketAmount;
    protected bool isDraw = false;
    //protected decimal paidTicketAmount;//已付发票金额
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = financeAction.Model;
        QueryData();
    }

    private void QueryData()
    {
        try
        {
            Order order = new Order();
            if (!string.IsNullOrEmpty(Request.QueryString["OrderId"]))
            {
                order.Name = Request.QueryString["OrderId"];
            }
            financeAction.Model.Orders = order;
            financeAction.SearchTicketAmountInfoByOrderNo(1);
            if (null!=financeAction.Model.OrderList)
            {
                drawTicketAmount = financeAction.Model.OrderList[0].NotPayTicketAmount;
                //paidTicketAmount = financeAction.Model.OrderList[0].PaidTicketAmount;//已付发票金额
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion

    #region//Save
    protected void Save(object sender, EventArgs e)
    {
        try
        {
            financeAction.Model.Orders = new Order();
            financeAction.Model.Orders.Id = Convert.ToInt32(Request.QueryString["OrderId"]);
            financeAction.Model.Orders.NotPayTicketAmount = Convert.ToDecimal(Request.Form["drawtTicketAmount"]);
            if (drawTicketAmount == Convert.ToDecimal(Request.Form["drawtTicketAmount"]))//一次全部领完，修改发票的状态 
            {
                financeAction.Model.Orders.PaidTicket = Constants.TAKE_TICKET_STATUS_NOT_OWE;
            }
            financeAction.DrawTicket();
            //Response.Write("<script>opener.location.reload();</script>");//父窗体重新加载 opener.location.reload();
            //Response.Write("<script>window.close();</script>");
            isDraw = true;
            //Response.Write("<script>window.navigate('DrawTicket.aspx');</script>");
            //Response.Write("<script>opener.location.reload();</script>");//父窗体重新加载 opener.location.reload();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion
}
