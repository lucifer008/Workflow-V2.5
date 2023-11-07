using System;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Report.Logcounters;
using Workflow.Action.LogCounters;
/// <summary>
/// 名    称：SearchCounter
/// 功能概要: 计数器查询
/// 作    者: 陈汝胤
/// 创建时间: 2009.12.17
/// </summary>
public partial class SearchCounter : Workflow.Web.PageBase
{
    #region ClassMember
	
	protected SearchCounterModel model;

	private SearchCounterAction action;
	public SearchCounterAction SearchCounterAction
    {
		set { action = value; }
    }

    #endregion

    #region Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
		model = action.Model;

		string actionName = Request.Form["hiddAction"];
		if (actionName == Constants.ACTION_INIT.ToString())
		{
			QueryNextData(1);
		}
    }
    
    #endregion

    #region 分页处理程序

    private void QueryNextData(int currentPageIndex) 
    {
		model.BeginRow = (currentPageIndex - 1) * Constants.ROW_COUNT_FOR_PAGER + 1;
		model.EndRow = currentPageIndex * Constants.ROW_COUNT_FOR_PAGER;
		model.BeginDate = Request.Form["txtbeginDate"];
		model.EndDate = Request.Form["txtEndDate"];

		action.Init();

		AspNetPager1.CurrentPageIndex = currentPageIndex;
		AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
		AspNetPager1.RecordCount = model.RecordCount;
    }
	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
		QueryNextData(e.NewPageIndex);
    }
    #endregion
}
