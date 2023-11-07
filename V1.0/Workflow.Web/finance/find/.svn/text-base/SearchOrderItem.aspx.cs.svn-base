using System;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;

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
            BusinessType.Items.Add(new ListItem(bt.Name, bt.Id.ToString()));
        }
    }

    #endregion

    #region 工单查询(事件)
    /// <summary>
    /// 工单查询
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
        //业务类型
        model.BusinessTypeId = BusinessType.SelectedValue;        
        //数量
        model.AmountCondtition = AmountSelect.SelectedIndex;
        model.Amount = Amount.Value;
        //金额
        model.PriceCondition = UnitPrice.SelectedIndex;
        model.Price = Price.Value;
        //时间
        model.BeginDate = txtFrom.Value;
        model.EndDate = txtTo.Value;

        findFinanceAction.SearchOrdersItem();

        amounts = model.Amounts.Split(new char[] { ','});
    }
    #endregion
}
