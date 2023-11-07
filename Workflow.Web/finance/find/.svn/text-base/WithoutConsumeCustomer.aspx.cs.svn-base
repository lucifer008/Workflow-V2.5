using System;
using System.Collections;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support.Report.Finance;
/// <summary>
/// 功能概要: 无消费客户查询
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2010年1月21日11:25:06
/// 修正描述: 完善查询功能，增加打印功能
/// </summary>
public partial class finance_find_WithoutConsumeCustomer :System.Web.UI.Page
{
    #region//ClassMember
    //private string queryString;
    private long customerType = 0;
    private long customerLevel = 0;
    private long memberCardLevel = 0;
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
        InitData();
        if (!IsPostBack)
        {}
        findFinanceAction.Model.Operator1 = customerLevel.ToString();
        findFinanceAction.Model.Operator2 = customerType.ToString();
        findFinanceAction.Model.Operator3 = memberCardLevel.ToString();
    }
    private void InitData() 
    {
        findFinanceAction.GetAllMasterDate();
    }
    #endregion

    #region//Search
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            Hashtable customer = new Hashtable();
            if ("-1"!=Request.Form["CustomerLevel"])
            {
                customer.Add("CustomerLevel", long.Parse(Request.Form["CustomerLevel"]));
            }

            if ("-1"!= Request.Form["CustomerType"])
            {
                customer.Add("CustomerType", long.Parse(Request.Form["CustomerType"]));
            }

            if ("-1"!=Request.Form["MemberCardLevel"])
            {
                customer.Add("MemberCardLevel", long.Parse(Request.Form["MemberCardLevel"]));
            }

            if (""!=txtBeginDateTime.Value.Trim())
            {
                customer.Add("BeginTime", txtBeginDateTime.Value.Trim());
            }

            if (""!=txtTo.Value.Trim())
            {
                customer.Add("EndTime", txtTo.Value.Trim());
            }
            customer.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
            customer.Add("CurrentPageIndex",0);
            customer.Add("PageCount", Constants.ROW_COUNT_FOR_PAGER);
            findFinanceAction.GetWithoutConsumeCustomer(customer);
            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.RecordCount = (int)model.EmployeeId;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

            ViewState.Add("CustomerLevel", Request.Form["CustomerLevel"]);
            ViewState.Add("CustomerType", Request.Form["CustomerType"]);
            ViewState.Add("MemberCardLevel", Request.Form["MemberCardLevel"]);
            ViewState.Add("BeginTime", txtBeginDateTime.Value.Trim());
            ViewState.Add("EndTime", txtTo.Value.Trim());
            ViewState.Add("queryCondition", Request.Form["queryCondition"]);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//Print
    protected void Print(object sender, EventArgs e)
    {
        try 
        {
            btnPrint.Enabled = false;
            model.IsPrint = true;
            QueryNextPageData(1);
            ReportWithoutConsumeCustomer rSearchAcc = new ReportWithoutConsumeCustomer();
            rSearchAcc.QueryString = ViewState["queryCondition"].ToString();
            string reportFileName = "WithoutConsumeCustomer" + DateTime.Now.Ticks.ToString() + ".pdf";
            rSearchAcc.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
            rSearchAcc.CreateReport(model, "无消费客户查询", "无消费客户查询", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '无消费客户查询', 1024, 1024 , false, false, null);</script>");
            btnPrint.Enabled = true;
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
            Hashtable condition = new Hashtable();
            if ("-1" != ViewState["CustomerLevel"].ToString())
            {
                condition.Add("CustomerLevel", ViewState["CustomerLevel"]);
            }
            if ("-1" != ViewState["CustomerType"].ToString())
            {
                condition.Add("CustomerType", ViewState["CustomerType"]);
            }
            if ("-1" != ViewState["MemberCardLevel"].ToString())
            {
                condition.Add("MemberCardLevel", ViewState["MemberCardLevel"]);
            }
            if ("" != ViewState["BeginTime"].ToString())
            {
                condition.Add("BeginTime", ViewState["BeginTime"]);
            }
            if ("" != ViewState["EndTime"].ToString())
            {
                condition.Add("EndTime", ViewState["EndTime"]);
            }
            condition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
            condition.Add("CurrentPageIndex", currentPageIndex - 1);
            condition.Add("PageCount", Constants.ROW_COUNT_FOR_PAGER);
            findFinanceAction.GetWithoutConsumeCustomer(condition);
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
