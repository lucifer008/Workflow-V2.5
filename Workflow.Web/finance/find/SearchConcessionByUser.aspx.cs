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


using Workflow.Action.Finance.Model;
using Workflow.Action.Finance;
using Workflow.Support;

public partial class finance_find_SearchConcessionByUser : System.Web.UI.Page
{
	#region 类成员
	private FindFinanceAction action;
	/// <summary>
	/// action
	/// </summary>
	public FindFinanceAction FindFinanceAction
	{
		set { action = value; }
	}

	/// <summary>
	/// Model
	/// </summary>
	protected FindFinanceModel model;
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
		model = action.Model;

		if (!Page.IsPostBack)
		{
			//this.InitData();
		}
	}

	#region 初始化页面数据
	/// <summary>
	/// 名    称: InitData
	/// 功能概要: 初始化页面数据
	/// 作    者: 
	/// 创建时间: 
	/// 修 正 人: 白晓宇
	/// 修正时间: 2010-05-17
	/// 描    述: 
	/// </summary>>
	public void InitData()
	{
		ProcesPage(1);
	}
	#endregion

	#region 分页处理
	/// <summary>
	/// 分页处理
	/// </summary>
	/// <param name="currentIndex">当前页数</param>
	public void ProcesPage(int currentIndex) 
	{
		string operatorUser = Request.Form["txtOperateUser"];

		model.Operator1 = operatorUser;

		string beginDate = Workflow.Util.StringUtils.IsEmpty(txtBeginDateTime.Value) ? null : txtBeginDateTime.Value;
		string endDate = Workflow.Util.StringUtils.IsEmpty(txtEndDateTime.Value) ? null : txtEndDateTime.Value;

		model.PaymentConcession = new Workflow.Da.Domain.PaymentConcession();
		model.PaymentConcession.CurrentPageIndex = currentIndex - 1;
		model.PaymentConcession.RowCount = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
		model.PaymentConcession.BeiginDateTimeString = beginDate;
		model.PaymentConcession.EndDateTimeString = endDate;

		action.GetPayConcessionListByUserId();
		action.GetPayConcessionCountByUserId();

		AspNetPager1.RecordCount = model.RecordCount;
		AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
		
	}
	#endregion

	/// <summary>
	/// 查询
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void btnSearch_Click(object sender, EventArgs e)
	{
		ProcesPage(1);
	}

	/// <summary>
	/// 分页
	/// </summary>
	/// <param name="src"></param>
	/// <param name="e"></param>
	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
	{
		ProcesPage(e.NewPageIndex);
	}
}
