using System;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;

/// <summary>
///  功能概要: 补领发票记录
///  作    者: 张晓林
///  创建时间: 2009年12月29日
///  修正履历:
///  修正时间:
/// </summary>
public partial class finance_find_SearchDrawTicketRecord : System.Web.UI.Page
{
    #region//ClassMember
    private string queryString = "";
    protected FindFinanceModel model;
    public FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
        if(!IsPostBack)
        {
            ViewState.Add("DefaultBeginDateTime", DateTime.Now.ToShortDateString());
            ViewState.Add("DefaultEndDateTime", DateTime.Now.AddDays(+1).ToShortDateString());
            QueryNextPageData(1);
        }
    }
    #endregion

    #region//Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        QueryNextPageData(1);
    }
    #endregion

    #region//Print
    protected void btnDispatchPrint_Click(object sender, EventArgs e)
    {
        model.IsPrint = true;
        QueryNextPageData(1);

        ReportSearchDrawTicketRecord rSearchAcc = new ReportSearchDrawTicketRecord();
        rSearchAcc.QueryString = queryString;
        string reportFileName = "SearchSearchDrawTicketRecord" + DateTime.Now.Ticks.ToString() + ".pdf";
        rSearchAcc.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rSearchAcc.CreateReport(model, "补领发票记录", "补领发票记录", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '补领发票记录', 1024, 1024 , false, false, null);</script>");
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            OtherGatheringAndRefundmentRecord oGathering = new OtherGatheringAndRefundmentRecord();
            if ("" != txtOrderNo.Value.Trim())
            {
                oGathering.OrderNo = txtOrderNo.Value.Trim();
                queryString += " 订单号:" + oGathering.OrderNo;
                ViewState["DefaultBeginDateTime"] = null;
                ViewState["DefaultEndDateTime"] = null;
            }
            if ("" != txtCustomerName.Value.Trim())
            {
                oGathering.CustomerName = txtCustomerName.Value.Trim();
                queryString += " 客户名称：" + oGathering.CustomerName;
                ViewState["DefaultBeginDateTime"] = null;
                ViewState["DefaultEndDateTime"] = null;
            }

            if ("" != txtMemberCardNo.Value.Trim())
            {
                oGathering.MemberCardNo = txtMemberCardNo.Value.Trim();
                ViewState["DefaultBeginDateTime"] = null;
                ViewState["DefaultEndDateTime"] = null;
            }

            if (null != ViewState["DefaultBeginDateTime"] && "" != ViewState["DefaultBeginDateTime"].ToString())
            {
                oGathering.InsertDateTimeString = ViewState["DefaultBeginDateTime"].ToString();
                queryString += " 补领日期>=" + oGathering.InsertDateTimeString;
            }
            if (null != ViewState["DefaultEndDateTime"] && "" != ViewState["DefaultEndDateTime"].ToString())
            {
                oGathering.EndDateTimeString = ViewState["DefaultEndDateTime"].ToString();
                queryString += " 补领日期<=" + oGathering.EndDateTimeString;
            }

            if ("" != txtBeginDateTime.Value.Trim())
            {
                oGathering.InsertDateTimeString = txtBeginDateTime.Value.Trim();
                queryString += " 补领日期>=" + oGathering.InsertDateTimeString;
                ViewState["DefaultBeginDateTime"] = null;
                ViewState["DefaultEndDateTime"] = null;
            }
            if ("" != txtEndDateTime.Value.Trim())
            {
                oGathering.EndDateTimeString = txtEndDateTime.Value.Trim();
                queryString += " 补领日期<=" + oGathering.EndDateTimeString;
                ViewState["DefaultBeginDateTime"] = null;
                ViewState["DefaultEndDateTime"] = null;
            }
           
            oGathering.CurrentPageIndex = Convert.ToInt32(currentPageIndex - 1);
            oGathering.RowCount = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
            findFinanceAction.Model.OtherGathingAndRefundMentRecord = oGathering;
            findFinanceAction.SearchDrawTicketRecord();

            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(model.Operator1);
            AspNetPager1.CurrentPageIndex = currentPageIndex;
        }
        catch (Exception ex) 
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
