using System;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Membercard;
using Workflow.Support.Report.MemberCard;
/// <summary>
/// 名    称: MemberCardConsumeSum
/// 功能概要: 会员消费统计
/// 作    者: mashaohua
/// 创建时间: 2007-10-25
/// 修正履历：fuqiang
/// 修正时间: 2007-10-29
/// 修正履历: 张晓林
/// 修正时间: 
///             完善查询功能；
///             增加分页功能；
///             增加异常处理；
///             调整页面控件命名规范；
/// </summary>
public partial class MemberCardConsumeSum : System.Web.UI.Page
{
    #region //ClassMember
    private SearchMemberCardAction searchMemberCardAction;
    public SearchMemberCardAction SearchMemberCardAction
    {
        set { searchMemberCardAction = value; }
    }
    protected MemberCardModel model;
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchMemberCardAction.Model;
        if (!IsPostBack) 
        {
            QueryNextPageData(1);
        }
    }
    #endregion

    #region //Search
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            Order order = new Order();
            if (!StringUtils.IsEmpty(Request.Form["txtBeginDateTime"]))
            {
                order.BalanceDateTimeString = Request.Form["txtBeginDateTime"];
            }

            if (!StringUtils.IsEmpty(Request.Form["txtTo"]))
            {
                order.InsertDateTimeString = Request.Form["txtTo"];
            }
            if (!StringUtils.IsEmpty(Request.Form["txtMemberCardNo"]))
            {
                order.MemberCardNo = Request.Form["txtMemberCardNo"];
            }
            order.Status =Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.CurrentPageIndex = 0;
            order.OrderCount = Constants.ROW_COUNT_FOR_PAGER;
            model.Order = order;
            searchMemberCardAction.GetMemberCardConsume();

            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.RecordCount = (int)model.MemberCardConcessionRecordCount;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

            ViewState.Add("BeginDate", order.BalanceDateTimeString);
            ViewState.Add("EndDate", order.InsertDateTimeString);
            ViewState.Add("MemberCardNo", order.MemberCardNo);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        Order order = new Order();
        if (null != ViewState["BeginDate"] && "" != ViewState["BeginDate"].ToString())
        {
            order.BalanceDateTimeString = ViewState["BeginDate"].ToString();
        }
        if (null != ViewState["EndDate"] && "" != ViewState["EndDate"].ToString())
        {
            order.InsertDateTimeString = ViewState["EndDate"].ToString();
        }
        if (null != ViewState["MemberCardNo"] && "" != ViewState["MemberCardNo"].ToString())
        {
            order.MemberCardNo = ViewState["MemberCardNo"].ToString();
        }

        order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
        order.CurrentPageIndex = currentPageIndex-1;
        order.OrderCount = Constants.ROW_COUNT_FOR_PAGER;
        model.Order = order;
        searchMemberCardAction.GetMemberCardConsume();

        AspNetPager1.CurrentPageIndex =currentPageIndex;
        AspNetPager1.RecordCount = (int)model.MemberCardConcessionRecordCount;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

        ViewState.Add("BeginDate", order.BalanceDateTimeString);
        ViewState.Add("EndDate", order.InsertDateTimeString);
        ViewState.Add("MemberCardNo", order.MemberCardNo);

    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion

    #region //Print
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        QueryNextPageData(AspNetPager1.CurrentPageIndex);
        string strQuery = "";
        if (!string.IsNullOrEmpty(model.Order.BalanceDateTimeString))
        {
            strQuery += "消费时间>=" + model.Order.BalanceDateTimeString;
        }
        if(!string.IsNullOrEmpty(model.Order.InsertDateTimeString))
        {
            strQuery += " 消费时间<=" + model.Order.InsertDateTimeString;
        }
        if (!string.IsNullOrEmpty(model.Order.MemberCardNo))
        {
            strQuery += " 卡号为:" + model.Order.MemberCardNo;
        }
        ReportMemberCardConsumeSum rart = new ReportMemberCardConsumeSum();
        rart.QueryString += strQuery;
        string reportFileName = "MemberCardConsumeSum" + DateTime.Now.Ticks.ToString() + ".pdf";
        rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

        rart.CreateReport(model, "会员消费统计", "会员消费统计", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '会员消费统计', 1024, 1024 , false, false, null);</script>");
    }
    #endregion
}
