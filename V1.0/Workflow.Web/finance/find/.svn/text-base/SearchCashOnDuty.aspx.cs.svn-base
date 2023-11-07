using System;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Finance;
using Workflow.Action.Achievement;
using Workflow.Support.Report.Finance;

/// <summary>
/// 名    称: SearchCashOnDuty
/// 功能概要: 收银当班查询
/// 作    者: 张晓林
/// 创建时间: 2009-1-15
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class finance_find_SearchCashOnDuty : System.Web.UI.Page
{
    #region //Class Member
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction
    {
        set { findFinanceAction = value; }
    }

    protected OrderModel model;

    protected SearchAchievementAction searchAchievementAction;
    public SearchAchievementAction SearchAchievementAction 
    {
        set { searchAchievementAction = value; }
    }

    private string strQuery = "";
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.OrderModel;
        searchAchievementAction.GetEmployeeList();
        try
        {
            if (!IsPostBack)
            {
                //默认查询当天的记录
                ViewState.Add("BeginDateTime",DateTime.Now.ToString("yyyy-MM-dd"));
                ViewState.Add("EndDateTime",DateTime.Now.AddDays(+1).ToString("yyyy-MM-dd"));
                QueryNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //Search
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            Order order = new Order();
            //结算时间:
            if (null != Request.Form["txtBeginDateTime"] && "" != Request.Form["txtBeginDateTime"])
            {
                order.InsertDateTimeString = Request.Form["txtBeginDateTime"];
            }

            if (null != Request.Form["txtEndDateTime"] && "" != Request.Form["txtEndDateTime"])
            {
                order.BalanceDateTimeString = Request.Form["txtEndDateTime"];
            }

            if (!string.IsNullOrEmpty(Request.Form["sltEmployee"]))
            {
                order.EmployeeArray = Request.Form["sltEmployee"].Split(',');
            }

            order.CurrentPageIndex = 0;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);//每页显示的行数
            //order.Status2 = Constants.POSITION_CASHER_VALUE;//收银
            model.NewOrder = order;
            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.PageSize = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);//每页显示的行数
            AspNetPager1.RecordCount = Convert.ToInt32(findFinanceAction.SearchOrderInfoByCashPersonRowCount());
            findFinanceAction.SearchOrderInfoByCashPerson();
            //保存数据
            ViewState.Add("BeginDateTime", order.InsertDateTimeString);
            ViewState.Add("EndDateTime", order.BalanceDateTimeString);
            ViewState.Add("EmployeeArray", order.EmployeeArray);
            ViewState.Add("EmployeeNameList", hiddEmployeeList.Value);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion

    #region //分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            Order order = new Order();
            if (null != ViewState["BeginDateTime"] && "" != ViewState["BeginDateTime"].ToString())
            {
                order.InsertDateTimeString = ViewState["BeginDateTime"].ToString();
            }
            if (null != ViewState["EndDateTime"] && "" != ViewState["EndDateTime"].ToString())
            {
                order.BalanceDateTimeString = ViewState["EndDateTime"].ToString();
            }
            if (null != ViewState["EmployeeArray"] && "" != ViewState["EmployeeArray"].ToString())
            {
                order.EmployeeArray = (string[])ViewState["EmployeeArray"];
            }
            //order.CashName = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString();
            order.CurrentPageIndex = currentPageIndex - 1;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);//每页显示的行数
            //order.Status2 = Constants.POSITION_CASHER_VALUE;//收银
            model.NewOrder = order;
            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.RecordCount = Convert.ToInt32(findFinanceAction.SearchOrderInfoByCashPersonRowCount());
            AspNetPager1.PageSize = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);//每页显示的行数
            findFinanceAction.SearchOrderInfoByCashPerson();
            //保存数据
            ViewState.Add("BeginDateTime", order.InsertDateTimeString);
            ViewState.Add("EndDateTime", order.BalanceDateTimeString);
            ViewState.Add("EmployeeArray", order.EmployeeArray);
            ViewState.Add("EmployeeNameList", ViewState["EmployeeNameList"]);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion

    #region //Print
    protected void btnDispatchPrint_Click(object sender, EventArgs e)
    {
        try
        {
            Order order = new Order();

            if (null != ViewState["BeginDateTime"] && "" != ViewState["BeginDateTime"].ToString())
            {
                order.InsertDateTimeString = ViewState["BeginDateTime"].ToString();
                strQuery+="结算时间>="+ViewState["BeginDateTime"].ToString();
            }
            if (null != ViewState["EndDateTime"] && "" != ViewState["EndDateTime"].ToString())
            {
                order.BalanceDateTimeString = ViewState["EndDateTime"].ToString();
                strQuery+="结算时间<="+ViewState["EndDateTime"].ToString();
            }
            if (null != ViewState["EmployeeArray"] && "" != ViewState["EmployeeArray"].ToString())
            {
                order.EmployeeArray = (string[])ViewState["EmployeeArray"];
                if(null!=ViewState["EmployeeNameList"] && ""!=ViewState["EmployeeNameList"].ToString())
                {
                    strQuery += " 雇员:" + ViewState["EmployeeNameList"].ToString();
                }
                
            }
            //order.CashName = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString();
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            //order.Status2 = Constants.POSITION_CASHER_VALUE;//收银
            model.NewOrder = order;
            findFinanceAction.SearchOrderInfoByCashPersonPrint();

            ReportSearchOrderByCushPerson rart = new ReportSearchOrderByCushPerson();
            rart.QueryString += strQuery;//"收银人：" + ThreadLocalUtils.CurrentUserContext.CurrentUser.UserName + findFinanceAction.GetQueryConditionString();
            string reportFileName = "SearchCashOnDuty" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
            rart.CreateReport(findFinanceAction.OrderModel, "收银当班查询", "收银当班查询", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportFileName + "', '收银当班查询', 1024, 1024 , false, false, null);</script>");
            QueryNextPageData(AspNetPager1.CurrentPageIndex);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion   
}
