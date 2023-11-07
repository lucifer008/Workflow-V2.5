using System;
using System.Text;
using iTextSharp.text;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Report.ReportOrderQuery;

/// <summary>
/// 名    称: SearchOrder
/// 功能概要: 工单查询
/// 作    者: liuwei
/// 创建时间: 
/// 修正履历: 
/// 修正时间: 2008-12-8
/// 修 正 人:张晓林
///         处理 查询，分页，打印问题
///         2009-01-17
///         调整页面
///</summary>

public partial class SearchOrder : Workflow.Web.PageBase
{
    #region //Class Member
    private NewOrderAction action;
    public NewOrderAction NewOrderAction
    {
        set { action = value; }
    }
    protected OrderModel model;
    private SearchOrderAction sAction;
    public SearchOrderAction SearchOrderAction
    {
        set { sAction = value; }
    }

    #endregion

    #region //Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                InitData();
                ViewState.Add("ComporeCondition", SelectCondition.Value);
            }
            model = sAction.Model;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
        }

    }

    protected void InitData() 
    {
        action.GetOperatorList();
        int index = 0;
        for(int i=action.Model.OperatorList.Count-1;i>=0;i--)
        {
            SelectCondition.Items.Add(action.Model.OperatorList[i].Label);
            SelectCondition.Items[index].Value = action.Model.OperatorList[i].Value;
            index++;
        }        
    }
    #endregion

    #region //Search
    /// <summary>
    /// 查询工单信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-9
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    /// 
    protected void SearchOrdersInfo(object sender, EventArgs e)
    {
        try
        {
            sAction.Model.NewOrder.No = OrderNo.Value;
            sAction.Model.NewOrder.MemberCardNo = MemberCardNo.Value;
            sAction.Model.NewOrder.CustomerName = CustomerName.Value;
            sAction.Model.NewOrder.BeginBalanceDate = Request.Form.Get("txtFrom");
            sAction.Model.NewOrder.EndBalanceDate = Request.Form.Get("txtTo");
            sAction.Model.NewOrder.ComporeCondition = SelectCondition.Value;
            if (!string.IsNullOrEmpty(Money.Value))
            {
                sAction.Model.NewOrder.SumAmount = decimal.Parse(Money.Value);
            }

            this.AspNetPager1.CurrentPageIndex = 1;
            sAction.SearchOrderInfo(this.AspNetPager1.CurrentPageIndex-1);
            this.AspNetPager1.RecordCount = (int)sAction.GetSearchOrderInfoCount();//总记录数
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数

            ViewState.Add("No", OrderNo.Value);
            ViewState.Add("MemberCardNo", MemberCardNo.Value);
            ViewState.Add("CustomerName", CustomerName.Value);
            ViewState.Add("BeginDate", Request.Form["txtFrom"]);
            ViewState.Add("EndDate", Request.Form["txtTo"]);
            if (!string.IsNullOrEmpty(Money.Value)) 
            {
                ViewState.Add("Money", Money.Value);
            }
            ViewState.Add("ComporeCondition", SelectCondition.Value);
            ViewState.Add("currentPageIndex", this.AspNetPager1.CurrentPageIndex.ToString());
         }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }                 
    }
    #endregion

    #region //Print

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            QueryNextPageData(1);
            sAction.SearchOrderInfoNo();
            ReportOrderQuery ro = new ReportOrderQuery();
            StringBuilder sb = new StringBuilder();
            if (null != ViewState["No"] && !string.IsNullOrEmpty(ViewState["No"].ToString()))
            {
                sb.Append("工单号:" + ViewState["No"].ToString());
            }
            if (null != ViewState["MemberCardNo"] && !string.IsNullOrEmpty(ViewState["MemberCardNo"].ToString()))
            {
                sb.Append(" 会员卡号:" + ViewState["MemberCardNo"].ToString());
            }
            if (null != ViewState["CustomerName"] && !string.IsNullOrEmpty(ViewState["CustomerName"].ToString()))
            {
                sb.Append(" 客户名称:" + ViewState["CustomerName"].ToString());
            }
            if (null != ViewState["BeginDate"] && !string.IsNullOrEmpty(ViewState["BeginDate"].ToString()))
            {
                sb.Append(" 开始时间:" + ViewState["BeginDate"].ToString());
            }
            if (null != ViewState["EndDate"] && !string.IsNullOrEmpty(ViewState["EndDate"].ToString()))
            {
                sb.Append(" 结束时间:" + ViewState["EndDate"].ToString());
            }
            if (null != ViewState["Money"] && !string.IsNullOrEmpty(ViewState["Money"].ToString()))
            {
                sb.Append(" 金额:" + ViewState["ComporeCondition"] + ViewState["Money"].ToString());
            }
            ro.ConditionText = sb.ToString(); //查询条件
            string reportname = "orders" + DateTime.Now.Ticks.ToString() + ".pdf";
            ro.FileName = Server.MapPath("~") + @"\reports\" + reportname;
            ro.CreateReport(sAction.Model, "工单查询", "工单查询", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportname + "', '打印委托加工单', 1024, 1024 , false, false, null);</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }

    }
    
    #endregion

    #region //分页处理事件
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    protected void QueryNextPageData(int currentPageIndex)
    {
        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["No"])))
        {
            sAction.Model.NewOrder.No = ViewState["No"].ToString();
        }

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["MemberCardNo"])))
        {
            sAction.Model.NewOrder.MemberCardNo = ViewState["MemberCardNo"].ToString();
        }

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["CustomerName"])))
        {
            sAction.Model.NewOrder.CustomerName = ViewState["CustomerName"].ToString();
        }

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["BeginDate"])))
        {
            sAction.Model.NewOrder.BeginBalanceDate = ViewState["BeginDate"].ToString();
        }

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["EndDate"])))
        {
            sAction.Model.NewOrder.EndBalanceDate = ViewState["EndDate"].ToString();
        }

        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["Money"])))
        {
            sAction.Model.NewOrder.SumAmount = Convert.ToDecimal(ViewState["Money"].ToString());
        }
        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["ComporeCondition"])))
        {
            sAction.Model.NewOrder.ComporeCondition = ViewState["ComporeCondition"].ToString();
        }
        sAction.SearchOrderInfo(currentPageIndex - 1);
        this.AspNetPager1.RecordCount = (int)sAction.GetSearchOrderInfoCount();//总记录数
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数

        ViewState.Add("No", ViewState["No"]);
        ViewState.Add("MemberCardNo", ViewState["MemberCardNo"]);
        ViewState.Add("CustomerName", ViewState["CustomerName"]);
        ViewState.Add("BeginDate", ViewState["BeginDate"]);
        ViewState.Add("EndDate", ViewState["EndDate"]);
        ViewState.Add("ComporeCondition", ViewState["ComporeCondition"]);
        if (!string.IsNullOrEmpty(Convert.ToString(ViewState["Money"])))
        {
            ViewState.Add("Money", ViewState["Money"]);
        }
        ViewState.Add("currentPageIndex", currentPageIndex.ToString());
    }
    #endregion
}
