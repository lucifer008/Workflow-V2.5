using System;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Support;
using Workflow.Support.Report.Finance;
using iTextSharp.text;

public partial class SearchOrderItem : Workflow.Web.PageBase
{
    protected string[] amounts;
    private FindFinanceAction findFinanceAction;
    public FindFinanceAction FindFinanceAction 
    {
        set { findFinanceAction = value; }
    }
    protected FindFinanceModel model;

    protected void Page_Load(object sender, EventArgs e)
    {
        model = findFinanceAction.Model;

        if (!IsPostBack)
        {
            InitData();
        }
    }

    #region 页面初始化
    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-25
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void InitData()
    {
        findFinanceAction.GetBusinessType();

        foreach (Workflow.Da.Domain.BusinessType bt in model.BusinessTypeList)
        {
            BusinessType.Items.Add(new System.Web.UI.WebControls.ListItem(bt.Name, bt.Id.ToString()));
        }
    }

    #endregion

    #region 订单查询(事件)
    /// <summary>
    /// 订单查询
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-25
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void SearchOrders(object sender, EventArgs e)
    {
		QueryNextData(1);
    }
    #endregion

	#region 分页

	private void QueryNextData(int currentPageIndex)
	{
		model.BeginRow = (currentPageIndex - 1) * Constants.ROW_COUNT_FOR_PAGER + 1;
		model.EndRow = currentPageIndex * Constants.ROW_COUNT_FOR_PAGER;

		//业务类型
		model.BusinessTypeId = BusinessType.SelectedValue;
		//数量
		model.AmountCondtition = AmountSelect.SelectedIndex.ToString();
		model.Amount = Amount.Value;
		//金额
		model.PriceCondition = UnitPrice.SelectedIndex.ToString();
		model.Price = Price.Value;
		//时间
		model.BeginDate = txtFrom.Value;
		model.EndDate = txtTo.Value;

		findFinanceAction.SearchOrdersItem();

		AspNetPager1.CurrentPageIndex = currentPageIndex;
		AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
		AspNetPager1.RecordCount = model.RecordCount;
	}


	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
	{
		QueryNextData(e.NewPageIndex);
	}

	#endregion

	#region print

	protected void Print(object sender, EventArgs e)
	{
		QueryNextData(1);

		model.IsPrint = true;

		findFinanceAction.SearchOrdersItem();

		ReportOrderItem print = new ReportOrderItem();
		string reportFileName = "DebtOrderItem" + DateTime.Now.Ticks.ToString() + ".pdf";
		print.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
		print.CreateReport(model, "订单消费查询报表", "订单消费查询报表", PageSize.A4, 10, 10, 10, 10);
		Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('/reports/" + reportFileName + "', '订单消费查询报表', 1024, 1024 , false, false, null);</script>");
	}

	#endregion
}
