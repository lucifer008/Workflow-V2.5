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
/// 名    称:SwapMemberCardRecord
/// 功能概要:统计会员卡换卡记录
/// 作    者:liuwei
/// 创建时间:2007-10-24
/// 修正履历:张晓林
/// 修正时间:2009年4月2日9:31:32
/// 修正描述:完善查询功能
/// </summary>
public partial class SwapMemberCardRecord : Workflow.Web.PageBase
{
    #region //成员变量定义
    protected MemberCardModel model;

    private SearchMemberCardAction searchMemberCardAction;
    public SearchMemberCardAction SearchMemberCardAction
    {
        set { searchMemberCardAction = value; }
    }
    #endregion

    #region //页面属性加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchMemberCardAction.Model;
    }
    #endregion

    #region //查询
    /// <summary>
    /// 查询会员卡换卡纪录
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-24
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void SearchChageMemberCard(object sender, EventArgs e)
    {
        try
        {
            model.BeginDate = txtFrom.Value;
            model.EndDate = txtTo.Value;
            model.MemberCardNo = txtMemberCardNo.Value;
            model.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            model.CurrentPageIndex = 1;
            searchMemberCardAction.SearchChangeMemberCard();

            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.RecordCount = (int)model.MemberCardConcessionRecordCount;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

            ViewState.Add("BeginDate",model.BeginDate);
            ViewState.Add("EndDate",model.EndDate);
            ViewState.Add("MemberCardNo",model.MemberCardNo);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        try 
        {
            if (null != ViewState["BeginDate"] && "" != ViewState["BeginDate"].ToString())
            {
                model.BeginDate = ViewState["BeginDate"].ToString();
            }
            if (null != ViewState["EndDate"] && ""!=ViewState["EndDate"].ToString())
            {
                model.EndDate = ViewState["EndDate"].ToString();
            }
            if (null != ViewState["MemberCardNo"] && "" != ViewState["MemberCardNo"].ToString())
            {
                model.MemberCardNo = ViewState["MemberCardNo"].ToString();
            }
            model.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            model.CurrentPageIndex =currentPageIndex;
            searchMemberCardAction.SearchChangeMemberCard();

            AspNetPager1.CurrentPageIndex =currentPageIndex;
            AspNetPager1.RecordCount = (int)model.MemberCardConcessionRecordCount;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

            ViewState.Add("BeginDate", model.BeginDate);
            ViewState.Add("EndDate", model.EndDate);
            ViewState.Add("MemberCardNo", model.MemberCardNo);
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

    #region //打印
    protected void btnPrintClick(object sender, EventArgs e)
    {
        string pStrQueryString = "";
        try
        {
            QueryNextPageData(AspNetPager1.CurrentPageIndex);
            if (null != model.BeginDate && "" != model.BeginDate)
            {
                pStrQueryString += "换卡时间>=" + model.BeginDate;
            }
            if(null!=model.EndDate && ""!=model.EndDate)
            {
                pStrQueryString += " 换卡时间<=" + model.BeginDate;
            }

            if (null != model.MemberCardNo && "" != model.MemberCardNo)
            {
                pStrQueryString += "  新卡号包含" + model.MemberCardNo;
            }
            ReportSwapMemberCardRecord rart = new ReportSwapMemberCardRecord();
            rart.QueryString += pStrQueryString;
            string reportFileName = "SwapMemberCardRecord" + DateTime.Now.Ticks.ToString() + ".pdf";
            rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rart.CreateReport(model, "会员换卡记录", "会员换卡记录", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '会员换卡记录', 1024, 1024 , false, false, null);</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
       
    }
    #endregion
}
