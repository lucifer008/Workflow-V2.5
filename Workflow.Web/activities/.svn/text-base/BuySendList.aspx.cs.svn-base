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

using Workflow.Action.Activities.Model;
using Workflow.Action.Activities;
using Workflow.Support;

public partial class activities_BuySendList : System.Web.UI.Page
{
	#region 类成员
	private BuySendAction buySendAction;
	/// <summary>
	/// BuySendList.aspx
	/// </summary>
	public BuySendAction BuySendAction
	{
		set { buySendAction = value; }
	}

	protected BuySendModel model;
	#endregion

	/// <summary>
	/// 页面加载
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		model = buySendAction.Model;
		if (!Page.IsPostBack)
		{
			InitData(1);
		}

		if (Page.IsPostBack)
		{
			//编辑和删除后刷新数据
			if ("True" == hiddTag.Value.Trim())
			{
				if ("delete" == hiddDeletedTag.Value)
				{
					model.BuySendId = Convert.ToInt32(hiddDeletedId.Value);//活动Id
					buySendAction.RemoveBuySend();
				}
				InitData(1);
			}
		}
	}

	#region 初始化页面数据
	/// <summary>
	/// 名    称: InitData
	/// 功能概要: 初始化页面数据
	/// 作    者: 白晓宇
	/// 创建时间: 2010年4月19日
	/// 修 正 人: 
	/// 修正时间: 
	/// 描    述: 
	/// </summary>
	public void InitData(int currentPageIndex)
	{
		buySendAction.GetAllBuySendListInfoRowCount();

		AspNetPager1.CurrentPageIndex = currentPageIndex;
		AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
		AspNetPager1.RecordCount = model.RecordCount;

		buySendAction.GetAllBuySendListInfo(currentPageIndex);
	}
	#endregion

	#region 初始化页面数据
	/// <summary>
	/// 名    称: AspNetPager1_PageChanging
	/// 功能概要: 分页处理程序
	/// 作    者: 白晓宇
	/// 创建时间: 2010年4月19日
	/// 修 正 人: 
	/// 修正时间: 
	/// 描    述: 
	/// </summary>
	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
	{
		InitData(e.NewPageIndex);
	}
	#endregion
}
