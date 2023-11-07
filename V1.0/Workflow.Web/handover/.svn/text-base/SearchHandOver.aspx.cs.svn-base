using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;

/// <summary>
/// 名    称：SearchHandOver
/// 功能概要: 交班查询
/// 作    者:
/// 创建时间:
/// 修正履历: 张晓林
/// 修正时间: 2009年3月26日9:25:31
/// 修正描述: 增加分页处理,完成查询功能 ，增加异常捕获
/// </summary>
/// 
public partial class SearchHandOver : Workflow.Web.PageBase
{
    #region //ClassMember
    protected HandOverQueryModel model;

    private HandOverQueryAction handOverQueryAction;
    public HandOverQueryAction HandOverQueryAction
    {
        set { handOverQueryAction = value; }
    }
    #endregion

    #region //Page_Load

    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-11
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = handOverQueryAction.Model;
            handOverQueryAction.InitData();
            if (!IsPostBack)
            {
                ViewState.Add("HandOverBeginDate", DateTime.Now.ToShortDateString());
                QueryNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //查询

    /// <summary>
    /// 查询交班信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-11
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected void QueryProcess(object sender, EventArgs e)
    {
        try
        {
            HandOver handOver= new HandOver();

            //部门
            if ("-1" != Request.Form["sltPosition"])
            {
                handOver.HandOverPositionId =Request.Form["sltPosition"];
            }

            //交班人
            if ("-1" != Request.Form["sltHandOverPerson"])
            {
                handOver.HandOverOtherPersonId = Request.Form["sltHandOverPerson"];
            }

            //开始时间
            if ("" != Request.Form["txtBeginDate"].Trim())
            {
                handOver.HandOverDateTimeFrom =Request.Form["txtBeginDate"];
            }

            //结束时间
            if(""!=Request.Form["txtEndDate"].Trim())
            {
                handOver.HandOverDateTimeTo =Request.Form["txtEndDate"];
            }

            handOver.CurrentPageIndex = 0;
            handOver.PageRowCount =Constants.ROW_COUNT_FOR_PAGER;
            handOverQueryAction.Model.HandOver = handOver;
            handOverQueryAction.SearchHandOver();

            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.RecordCount = (int)handOverQueryAction.SearchHandOverRowCount();
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

            ViewState.Add("PositionId", Request.Form["sltPosition"]);
            ViewState.Add("HandOverId", Request.Form["sltHandOverPerson"]);
            ViewState.Add("HandOverBeginDate", Request.Form["txtBeginDate"].Trim());
            ViewState.Add("HandOverEndDate", Request.Form["txtEndDate"].Trim());
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion 

    #region //分页处理
    private void QueryNextPageData(int currentPageIndex) 
    {
        HandOver handOver = new HandOver();
        if (null != ViewState["PositionId"] && "-1"!=ViewState["PositionId"].ToString())
        {
            handOver.HandOverPositionId = ViewState["PositionId"].ToString();
        }
        if (null != ViewState["HandOverId"] && "-1" != ViewState["HandOverId"].ToString())
        {
            handOver.HandOverOtherPersonId = ViewState["HandOverId"].ToString();
        }
        if (null != ViewState["HandOverBeginDate"] && "" != ViewState["HandOverBeginDate"].ToString())
        {
            handOver.HandOverDateTimeFrom = ViewState["HandOverBeginDate"].ToString();
        }
        if (null != ViewState["HandOverEndDate"] && "" != ViewState["HandOverEndDate"].ToString())
        {
            handOver.HandOverDateTimeTo = ViewState["HandOverEndDate"].ToString();
        }
        handOver.CurrentPageIndex = currentPageIndex-1;
        handOver.PageRowCount = Constants.ROW_COUNT_FOR_PAGER;
        handOverQueryAction.Model.HandOver = handOver;
        handOverQueryAction.SearchHandOver();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.RecordCount = (int)handOverQueryAction.SearchHandOverRowCount();
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

        ViewState.Add("PositionId", ViewState["PositionId"]);
        ViewState.Add("HandOverId", ViewState["HandOverId"]);
        ViewState.Add("HandOverBeginDate", ViewState["HandOverBeginDate"]);
        ViewState.Add("HandOverEndDate", ViewState["HandOverEndDate"]);

    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
