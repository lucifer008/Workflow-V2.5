using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflow.Action.Activities;
using Wuqi.Webdiyer;
using Workflow.Support;

/// <summary>
/// 名    称: DiscountConcessionModel
/// 功能概要: 打折活动列表
/// 作    者: 陈汝胤
/// 创建时间: 2009.5.9
/// </summary>
public partial class activities_DiscountConcessionList : System.Web.UI.Page
{
	#region class Member

	protected DiscountConcessionModel model;

	private DiscountConcessionAction discountConcessionAction;
	/// <summary>
	/// 注入
	/// </summary>
	public DiscountConcessionAction DiscountConcessionAction
	{
		set { discountConcessionAction = value; }
	}

	private static int currentRow;

	#endregion

	#region Page_Load
	
	protected void Page_Load(object sender, EventArgs e)
	{
		model = discountConcessionAction.Model;
		if (!IsPostBack)
		{
			QueryNextPageData(1);
		}
		else
		{
			string delRowId = Request.Form["delRow"];
			if(!string.IsNullOrEmpty(delRowId))
			{
				model.DiscountConcessionId = long.Parse(delRowId);
				discountConcessionAction.DeleteDiscountConcession();
				QueryNextPageData(currentRow);
			}
		}
	}

	#endregion

	#region 分页处理

	private void QueryNextPageData(int currentPageIndex)
	{
		discountConcessionAction.GetAllDiscountConcessionCount();
		AspNetPager1.RecordCount = model.DiscountConcessionCount;
		model.BeginRow = (currentPageIndex - 1) * Constants.ROW_COUNT_FOR_PAGER + 1;
		if (model.BeginRow > AspNetPager1.RecordCount)
		{
			currentPageIndex -= 1;
			model.BeginRow = (currentPageIndex - 1) * Constants.ROW_COUNT_FOR_PAGER + 1;
		}
		model.EndRow = currentPageIndex * Constants.ROW_COUNT_FOR_PAGER;
		AspNetPager1.CurrentPageIndex = currentRow = currentPageIndex;
		AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
		discountConcessionAction.GetPaginationDiscountConcession();
	}
	protected void AspNetPager1_PageChanging(object sender, PageChangingEventArgs e)
	{
		QueryNextPageData(e.NewPageIndex);
	}

	#endregion
}
