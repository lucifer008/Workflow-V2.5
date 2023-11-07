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
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support;

public partial class finance_find_SearchCustomerOrderList : Workflow.Web.PageBase
{
	private FindFinanceAction action;
	public FindFinanceAction FindFinanceAction
	{
		set { action = value; }
	}
	protected FindFinanceModel model;

	protected void Page_Load(object sender, EventArgs e)
	{
		model = action.Model;
		if (!string.IsNullOrEmpty(Request.QueryString["id"]))
		{
			model.CustomerId = long.Parse(Request.QueryString["id"]);
			if (!IsPostBack)
			{ 
				QueryNextData(1);
			}
		}
	}

	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
	{
		QueryNextData(e.NewPageIndex);
	}

	private void QueryNextData(int currentPageIndex)
	{
		model.BeginRow = (currentPageIndex - 1) * Constants.ROW_COUNT_FOR_PAGER + 1;
		model.EndRow = currentPageIndex * Constants.ROW_COUNT_FOR_PAGER;

		action.GetCustomerOrders();

		AspNetPager1.CurrentPageIndex = currentPageIndex;
		AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
		AspNetPager1.RecordCount = model.RecordCount;
	}
}
