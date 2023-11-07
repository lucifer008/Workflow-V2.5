using System;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Membercard;
using Workflow.Support.Report.MemberCard;
/// <summary>
/// 名    称:OprationRecord
/// 功能概要:会员管理记录
/// 作    者:liuwei
/// 创建时间:2007-10-24
/// 修正履历:张晓林
/// 修正时间:2009年4月6日9:52:51
/// 修正描述:完善查询;增加分页功能
/// </summary>
public partial class OperationRecord : Workflow.Web.PageBase
{
    #region //ClassMember
    protected bool SearchTag = false;
    protected MemberCardModel model;
    private SearchMemberCardAction searchMemberCardAction;
    public SearchMemberCardAction SearchMemberCardAction 
    {
        set { searchMemberCardAction = value; }
    }
    #endregion

    #region // Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchMemberCardAction.Model;
    }
    #endregion

    #region //查询
    /// <summary>
    /// 查询会员卡操作纪录
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-24
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void SearchOperateLog(object sender, EventArgs e)
    {
        try
        {
            model.BeginDate = txtFrom.Value;
            model.EndDate = txtTo.Value;
            model.MemberCardNo = txtMemberCardNo.Value;
            model.CurrentPageIndex = 1;
            model.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            searchMemberCardAction.SearchOperateLog();

            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = (int)model.MemberCardConcessionRecordCount;

            ViewState.Add("BeginDate",model.BeginDate);
            ViewState.Add("EndDate",model.EndDate);
            ViewState.Add("MemberCardNo", model.MemberCardNo);
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
            if (null != ViewState["BeginDate"] && ""!=ViewState["BeginDate"].ToString())
            {
                model.BeginDate = ViewState["BeginDate"].ToString();
            }
            if (null != ViewState["EndDate"] && "" != ViewState["EndDate"].ToString())
            {
                model.EndDate = ViewState["EndDate"].ToString();
            }
            if (null != ViewState["MemberCardNo"] && "" != ViewState["MemberCardNo"].ToString())
            {
                model.MemberCardNo = ViewState["MemberCardNo"].ToString();
            }

            model.CurrentPageIndex = currentPageIndex;
            model.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            searchMemberCardAction.SearchOperateLog();

            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = (int)model.MemberCardConcessionRecordCount;

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

    #region //Print
    protected void btnPrint_Click(object sender, EventArgs e)
    {
        string strQuery = "";
        if(null!=ViewState["BeginDate"] && ""!=ViewState["BeginDate"].ToString())
        {
            strQuery += " 操作时间>=" + ViewState["BeginDate"].ToString();
        }

        if(null!=ViewState["EndDate"] && ""!=ViewState["EndDate"].ToString())
        {
            strQuery += " 操作时间<=" + ViewState["EndDate"].ToString();
        }

        if (null != ViewState["MemberCardNo"] && "" != ViewState["MemberCardNo"].ToString())
        {
            strQuery += " 会员卡号包含:"+ViewState["MemberCardNo"].ToString();
        }

        QueryNextPageData(AspNetPager1.CurrentPageIndex);
        ReportOperationRecord rart = new ReportOperationRecord();
        rart.QueryString += strQuery;
        string reportFileName = "OperationRecord" + DateTime.Now.Ticks.ToString() + ".pdf";
        rart.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

        rart.CreateReport(model, "会员卡管理记录", "会员卡管理记录", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '会员卡管理记录', 1024, 1024 , false, false, null);</script>");

        ViewState.Add("BeginDate", model.BeginDate);
        ViewState.Add("EndDate", model.EndDate);
        ViewState.Add("MemberCardNo", model.MemberCardNo);
    }
    #endregion
}
