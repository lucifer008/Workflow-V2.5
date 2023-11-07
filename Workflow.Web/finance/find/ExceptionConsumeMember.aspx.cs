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
/// 功能概要: 异常消费会员查询
/// 作    者: 
/// 创建时间: 
/// 修正履历：张晓林
/// 修正时间: 2010年2月3日9:35:56
/// 修正履历: 完成查询，打印功能
/// </summary>
public partial class finance_find_Default5 : Workflow.Web.PageBase
{
    #region//ClassMember
    private string queryString="";
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
        //get { return findFinanceAction; }
    }
    protected FindFinanceModel model;
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;
    }
    #endregion

    #region//Search
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            Order order = new Order();
            if (!StringUtils.IsEmpty(Request.Form["MemberCardNo"]))
            {
                order.MemberCardNo = Request.Form["MemberCardNo"];
            }
            if (""!=txtBeginDateTime.Value.Trim())
            {
                order.BalanceDateTimeString = txtBeginDateTime.Value.Trim();
            }
            if (""!=txtTo.Value.Trim())
            {
                order.InsertDateTimeString = txtTo.Value.Trim();
            }
            if (!StringUtils.IsEmpty(Request.Form["SumAmount"]))
            {
                order.No = Request.Form["sltSumAmount"];
                order.SumAmount = decimal.Parse(Request.Form["SumAmount"]);
            }
            order.CurrentPageIndex = 0;
            order.Status4 = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            model.Order = order;
            findFinanceAction.GetExceptionConsumeMemberCount();

            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(model.EmployeeId);
            AspNetPager1.CurrentPageIndex = 1;

            ViewState.Add("MemberCardNo", order.MemberCardNo);
            ViewState.Add("BeginDateTime", order.BalanceDateTimeString);
            ViewState.Add("EndDateTime", order.InsertDateTimeString);
            ViewState.Add("sltSumAmount", order.No);
            ViewState.Add("SumAmount", order.SumAmount);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            Order order = new Order();
            if (null != ViewState["MemberCardNo"] && "" != ViewState["MemberCardNo"].ToString())
            {
                order.MemberCardNo = ViewState["MemberCardNo"].ToString();
                queryString = "卡号:"+order.MemberCardNo;
            }
            if (null != ViewState["BeginDateTime"] && "" != ViewState["BeginDateTime"].ToString())
            {
                order.BalanceDateTimeString = ViewState["BeginDateTime"].ToString();
                queryString += " 时间段>=" + order.BalanceDateTimeString;
            }
            if (null != ViewState["EndDateTime"] && "" != ViewState["EndDateTime"].ToString())
            {
                order.InsertDateTimeString = ViewState["EndDateTime"].ToString();
                queryString += " 时间段<=" + order.InsertDateTimeString;
            }
            if (null != ViewState["sltSumAmount"] && "" != ViewState["sltSumAmount"].ToString())
            {
                order.No = ViewState["sltSumAmount"].ToString();
                queryString += " 消费总额" + ViewState["sltSumAmount"].ToString() + ViewState["SumAmount"].ToString();
            }
            if (null != ViewState["SumAmount"] && "" != ViewState["SumAmount"].ToString())
            {
                order.SumAmount = decimal.Parse(ViewState["SumAmount"].ToString());
            }

            order.CurrentPageIndex = currentPageIndex - 1;
            order.Status4 = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            model.Order = order;
            findFinanceAction.GetExceptionConsumeMemberCount();

            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(model.EmployeeId);
            AspNetPager1.CurrentPageIndex = currentPageIndex;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion

    #region//Print
    protected void Print(object sender, EventArgs e)
    {
        try
        {
            model.IsPrint = true;
            QueryNextPageData(1);
            ReportExceptionConsumeMember rSearchAcc = new ReportExceptionConsumeMember();
            rSearchAcc.QueryString = queryString;
            string reportFileName = "ExceptionConsumeMember" + DateTime.Now.Ticks.ToString() + ".pdf";
            rSearchAcc.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
            rSearchAcc.CreateReport(model, "异常消费会员查询", "异常消费会员查询", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '异常消费会员查询', 1024, 1024 , false, false, null);</script>");
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
