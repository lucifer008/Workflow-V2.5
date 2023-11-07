using System;

using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Action.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;

/// <summary>
/// 功能概要: 结算小票打印确认
/// 作    者：张晓林
/// 日    期: 2010年4月2日9:33:05
/// </summary>
public partial class finance_SmallTicketPrintConfirm : System.Web.UI.Page
{
    #region//ClassMember
    protected string orderNo;
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }

	protected SystemModel systemModel;
	private SystemAction systemAction;
	public SystemAction SystemAction
	{
		set { systemAction = value; }
	}
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        orderNo = Request.QueryString["OrderNo"];
        model = newOrderAction.Model;
		systemModel = systemAction.Model;

        if (!IsPostBack) 
        {
            newOrderAction.GetOrderInfo(orderNo);
			newOrderAction.GetOrderItemFactorValueByOrderNo(orderNo);

			//获取公司信息
			systemModel.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
			systemAction.GetCompanyInfo();

			//获取分店信息
			systemModel.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
			systemAction.GetBranchShopInfo();
        }
    }
    #endregion

    protected void imgBtnSumbit_Click(object sender, System.Web.UI.ImageClickEventArgs e)
    {

    }
}
