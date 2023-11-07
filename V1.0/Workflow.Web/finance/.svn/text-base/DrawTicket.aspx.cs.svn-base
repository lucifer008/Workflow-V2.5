using System;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;

/// <summary>
/// 名    称: DrawTicket
/// 功能概要: 发票领取
/// 作    者: 张晓林
/// 创建时间: 2008-12-25
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class finance_DrawTicket : System.Web.UI.Page
{
    #region //Class Member
    protected FinanceModel model;
    private FinanceAction financeAction;
    public FinanceAction FinanceAction 
    {
        set { financeAction = value; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = financeAction.Model;
            if (!IsPostBack)
            {
                QueryNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion

    #region //Search
    protected void Search_Click(object sender, EventArgs e)
    {
        try
        {
            Order order = new Order();       
            if (null != Request.Form["OrderNo"] && "" != Request.Form["OrderNo"])
            {
                order.No = "%" + Request.Form["OrderNo"] + "%";
            }
            financeAction.Model.Orders = order;
            this.AspNetPager1.CurrentPageIndex = 1;
            financeAction.SearchTicketAmountInfoByOrderNo(1);
            AspNetPager1.RecordCount = (int)financeAction.SearchTicketAmountInfoByOrderNoTotal();
            AspNetPager1.PageSize = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
            ViewState.Add("No", order.No);
            ViewState.Add("currentPageIndex", this.AspNetPager1.CurrentPageIndex.ToString());
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion

    #region //分页处理程序
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        QueryNextPageData(e.NewPageIndex);
    }

    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            Order order = new Order();
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["No"])))
            {
                order.No = ViewState["No"].ToString();
            }
            financeAction.Model.Orders = order;
            financeAction.SearchTicketAmountInfoByOrderNo(currentPageIndex);
            AspNetPager1.RecordCount = (int)financeAction.SearchTicketAmountInfoByOrderNoTotal();
            AspNetPager1.PageSize = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
            ViewState.Add("No", order.No);
            ViewState.Add("currentPageIndex", currentPageIndex.ToString());
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion
}
