using System;
using System.Text;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;
/// <summary>
/// 名    称: FinanceFindSearchArrear
/// 功能概要: 应收款查询
/// 作    者: 崔萧
/// 创建时间: 2008-12-12
/// 修正履历: 张晓林
/// 修正时间: 2008-12-15
///             完善查询，分页,打印
///          2009-01-16
///             调整页面
/// </summary>
public partial class FinanceFindSearchArrear : Workflow.Web.PageBase
{
    #region Class Member
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
        get { return findFinanceAction; }
    }
    protected FindFinanceModel model;
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
       try
        {
            model = findFinanceAction.Model;
            findFinanceAction.GetOperatorList();
            findFinanceAction.Model.Order = new Order();
            if(!IsPostBack)
            {
               QueryNextPageData(1);   
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region Search
    protected void Search(object sender, EventArgs e)
    {      
        try
        {
            QueryNextPageData(1);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region Print
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new StringBuilder();
        findFinanceAction.Model.Order = new Order();
        if ("" != CustomerName.Text)
        {
            findFinanceAction.Model.Order.CustomerName = "%" + CustomerName.Text + "%";
          sb.Append(" 客户名称:" + Request.Form["CustomerName"]);          
        }
        if ("" != Operation1.Value)
        {
            findFinanceAction.Model.Order.Operator1 = Operation1.Value;
        }
        else
        {
          findFinanceAction.Model.Order.Operator1 = ">=";
        }
        if ("0"!=SumAmount.Text.Trim())
        {
            findFinanceAction.Model.Order.Sumamount = Convert.ToDecimal(SumAmount.Text);
            sb.Append(" 金额:" + findFinanceAction.Model.Order.Operator1 + SumAmount.Text);
        }
        //else
        //{
        //    findFinanceAction.Model.Order.Sumamount = Convert.ToDecimal("0.1");

        //}
        if (""!=Operation2.Value)
        {
            findFinanceAction.Model.Order.Operator2 = Operation2.Value;
        }
        else
        {
          findFinanceAction.Model.Order.Operator2 = ">=";
        }
        if (""!=Days.Text.Trim())
        {
          findFinanceAction.Model.Order.Days = Convert.ToInt64(Days.Text);
          sb.Append(" 帐龄:" + findFinanceAction.Model.Order.Operator2 + Days.Text);
        }
        if ("" != BeginDateTime.Value)
        {
            findFinanceAction.Model.Order.BalanceDateTimeString = BeginDateTime.Value;
            sb.Append(" 开始时间:" + BeginDateTime.Value);
       }

       if ("" != EndDateTime.Value)
        {
            findFinanceAction.Model.Order.InsertDateTimeString = EndDateTime.Value;
            sb.Append(" 结束时间:" + EndDateTime.Value);
        }
        findFinanceAction.Model.Order.Status = Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE;
        findFinanceAction.GetaAllCustomerArrearage();
        this.AspNetPager1.CurrentPageIndex = 1;
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        this.AspNetPager1.RecordCount = (int)findFinanceAction.GetSelectCustomerArrearageCount();
        try
        {
            ReportSearchArrear report = new ReportSearchArrear();
            report.QueryString = sb.ToString();
            string reportFileName = "FinanceFindSearchArrear" + DateTime.Now.Ticks.ToString() + ".pdf";
            report.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
            report.CreateReport(findFinanceAction.Model, "应收款合计", "应收款合计", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '应收款合计', 1024, 1024 , false, false, null);</script>");
            QueryNextPageData(AspNetPager1.CurrentPageIndex);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
        finally
        {
            sb = null;
        }
    }
    #endregion

    #region 分页处理程序

    protected void QueryNextPageData(int currentPageIndex)
    {
        findFinanceAction.Model.Order = new Order();

        if (""!=CustomerName.Text.Trim())
        {
            findFinanceAction.Model.Order.CustomerName = "%" + CustomerName.Text + "%";
        }

        if (""!=Operation1.Value)
        {
            findFinanceAction.Model.Order.Operator1 = Operation1.Value;
        }
        else
        {
            findFinanceAction.Model.Order.Operator1 = ">=";
        }

        if ("0"!=SumAmount.Text.Trim())
        {
            findFinanceAction.Model.Order.Sumamount = Convert.ToDecimal(SumAmount.Text);
        }
        //else
        //{
        //    findFinanceAction.Model.Order.Sumamount = Convert.ToDecimal("0.1");
        //}

        if (""!=Operation2.Value)
        {
            findFinanceAction.Model.Order.Operator2 = Operation2.Value;
        }
        else
        {
            findFinanceAction.Model.Order.Operator2 = ">=";
        }
        if (""!=Days.Text.Trim())
        {
            findFinanceAction.Model.Order.Days = Convert.ToInt64(Days.Text);
        }
        if ("" != BeginDateTime.Value)
        {
            findFinanceAction.Model.Order.BalanceDateTimeString = BeginDateTime.Value;
        }
        if (""!=EndDateTime.Value)
        {
            findFinanceAction.Model.Order.InsertDateTimeString = EndDateTime.Value;
        }

        
        findFinanceAction.Model.Order.EveryPageCount = Constants.ROW_COUNT_FOR_PAGER;
        findFinanceAction.Model.Order.Status = Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE;
        findFinanceAction.Model.Order.CurrentPageIndex = currentPageIndex - 1;
        findFinanceAction.GetCustomerArrearage();

        this.AspNetPager1.CurrentPageIndex = 1;
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        this.AspNetPager1.RecordCount = (int)findFinanceAction.GetSelectCustomerArrearageCount();
    
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
