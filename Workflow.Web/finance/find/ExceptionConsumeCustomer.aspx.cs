using System;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;
using iTextSharp.text;
/// <summary>
/// 功能概要:波动客户消费查询
/// 作    者：
/// 日    期:
/// 修 正 人:张晓林
/// 修正描述:完善查询，分页处理及打印输出功能
/// 修正日期:2010年2月23日14:14:41
/// </summary>
public partial class ExceptionConsumeCustomer : Workflow.Web.PageBase
{
    #region//ClassMember
    private string queryString;
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        if (!IsPostBack)
        {
            InitData();
        }
    }
    private void InitData() 
    {
        findFinanceAction.GetOperatorList();
        foreach (LabelValue lv in model.OperatorList)
        {
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem(lv.Label, lv.Value);
            ddpSumAmount.Items.Add(li);
        }
    }
    #endregion

    #region//Search
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            Order order = new Order();
            if ("" != txtBeginDateTime.Value.Trim())
            {
                order.BalanceDateTimeString = txtBeginDateTime.Value;
            }
            if ("" != txtTo.Value.Trim())
            {
                order.InsertDateTimeString = txtTo.Value.Trim();
            }
            if ("" != txtSumAmount.Value.Trim())
            {
                order.No = ddpSumAmount.SelectedValue;
                order.SumAmount = decimal.Parse(txtSumAmount.Value);
            }
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.CurrentPageIndex = 0;
            order.Status1 = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
            findFinanceAction.Model.Order = order;
            findFinanceAction.GetExceptionConsumeCustomer();

            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.RecordCount = (int)model.EmployeeId;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            ViewState.Add("BeginDate", order.BalanceDateTimeString);
            ViewState.Add("EndDate", order.InsertDateTimeString);
            ViewState.Add("SumAmount", order.SumAmount);
            ViewState.Add("Operate", order.No);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//Print
    protected void btnDispatchPrint_Click(object sender, EventArgs e)
    {
        model.IsPrint = true;
        QueryNextPageData(1);
        ReportExceptionConsumeCustomer rSearchAcc = new ReportExceptionConsumeCustomer();
        rSearchAcc.QueryString = queryString;
        string reportFileName = "ExceptionConsumeCustomer" + DateTime.Now.Ticks.ToString() + ".pdf";
        rSearchAcc.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rSearchAcc.CreateReport(model, "波动客户查询", "波动客户查询", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '波动客户查询', 1024, 1024 , false, false, null);</script>");
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            Order order = new Order();
            if (null != ViewState["BeginDate"] && "" != ViewState["BeginDate"].ToString())
            {
                order.BalanceDateTimeString = ViewState["BeginDate"].ToString();
                queryString = "开始时间>=" + order.BalanceDateTimeString;
            }
            if (null != ViewState["EndDate"] && "" != ViewState["EndDate"].ToString())
            {
                order.InsertDateTimeString = ViewState["EndDate"].ToString();
                queryString += " 结束时间<=" + order.InsertDateTimeString;
            }
            if (null != ViewState["SumAmount"] && "" != ViewState["SumAmount"].ToString())
            {
                order.SumAmount = Convert.ToDecimal(ViewState["SumAmount"].ToString());
                queryString += " 金额" + ViewState["Operate"].ToString() + ViewState["SumAmount"].ToString();
            }
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.CurrentPageIndex = currentPageIndex - 1;
            order.Status1 = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
            findFinanceAction.Model.Order = order;
            findFinanceAction.GetExceptionConsumeCustomer();

            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.RecordCount = (int)model.EmployeeId;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
