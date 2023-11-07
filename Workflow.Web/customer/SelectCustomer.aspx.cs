using System;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称:GetOneCustomer
/// 功能概要: 选择客户对话框
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
/// 修 正 人:张晓林
/// 修正描述:增加捕获异常功能
/// 修正时间:2009年2月10日
/// </summary>

public partial class GetOneCustomer : System.Web.UI.Page//Workflow.Web.PageBase
{
	#region //类成员
    protected SelectCustomerModel model;
    protected string returnMethod = Constants.DEFAULT_CALLBACK_SELECT_CUSTOMER;
    protected static readonly string PREFIX_CATEGORY = "　";
    protected string customerName = null;

    private SelectCustomerAction action;
    public SelectCustomerAction SelectCustomerAction
    {
        set { action = value; }
	}
	#endregion
	
	#region //页面属性加载
	protected void Page_Load(object sender, EventArgs e)
    {
        model = action.Model;
        if (Request.QueryString[Constants.KEY_CALLBACK] != null)
        {
            returnMethod = Request.QueryString[Constants.KEY_CALLBACK];
        }
        if (!this.IsPostBack)
        {
            InitData();
            //SerachData(1);
        }
	}
	
	#region //InitData
	private void InitData()
    {
        try
        {
            action.Init();

            foreach (Workflow.Da.Domain.MasterTrade mt in model.MasterTradeList)
            {
                ListItem item = new ListItem(mt.Name, mt.Id.ToString());
                sltTrade.Items.Add(item);
                foreach (SecondaryTrade st in mt.SecondaryTradeList)
                {
                    sltTrade.Items.Add(new ListItem(PREFIX_CATEGORY + st.Name, st.Id.ToString() + "x" + mt.Id.ToString()));
                }
            }
            ///MakeSelectDefaultItem(sltTrade);

            sltCustomerLevel.DataSource = model.CustomerLevelList;
            sltCustomerLevel.DataTextField = "Name";
            sltCustomerLevel.DataValueField = "Id";
            sltCustomerLevel.DataBind();
            //MakeSelectDefaultItem(sltCustomerLevel);


            sltCustomerType.DataSource = model.CustomerTypeList;
            sltCustomerType.DataTextField = "Name";
            sltCustomerType.DataValueField = "Id";
            sltCustomerType.DataBind();
            //MakeSelectDefaultItem(sltCustomerType);
            //支付方式
            ListItem listPayTypeCash = new ListItem();
            listPayTypeCash.Text = Constants.PAYMENT_TYPE_CASHER_GET_LABEL;
            listPayTypeCash.Value =Constants.PAYMENT_TYPE_CASHER_GET_VALUE.ToString();
            ListItem listPayTypeOwe = new ListItem();
            listPayTypeOwe.Text = Constants.PAYMENT_TYPE_ACCOUNT_GET_LABEL;
            listPayTypeOwe.Value = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE.ToString();
            sltPayType.Items.Add(listPayTypeCash);
            sltPayType.Items.Add(listPayTypeOwe);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
	#endregion
	#endregion

	#region //查询
	/// <summary>
    /// 方法名称: QueryCustomer
    /// 功能概要: 查询用户需要的数据
    /// 作    者: liuwei
    /// 创建时间: 2007-9-18
    /// 修正履历: 崔肖
    /// 修正时间: 2008-12-16
    /// </summary>
    protected void QueryCustomer(object sender, EventArgs e)
    {
        SerachData(1);
    }
    /// <summary>
    /// 按条件查询客户
    /// 崔肖
    /// 2008-12-16
    /// </summary>
    /// <param name="currentPageIndex"></param>
    private void SerachData(int currentPageIndex)
    {
        //从页面获取数据
        try
        {
            if (!StringUtils.IsEmpty(txtCustomerName.Value.Trim()))
            {
                model.Name = txtCustomerName.Value;
                ViewState.Add("Name", model.Name);
            }
            else
            {
                model.Name = null;
                ViewState.Add("Name", null);
            }
            model.SecondaryTradeId = NumericUtils.ToLong(sltTrade.SelectedValue.ToString().Split('x')[0], 0);
            model.CustomerLevelId = NumericUtils.ToLong(sltCustomerLevel.SelectedValue, 0);
            model.CustomerTypeId = NumericUtils.ToLong(sltCustomerType.SelectedValue, 0);
            model.PayType = int.Parse(sltPayType.SelectedValue);
                       
            ViewState.Add("SecondaryTradeId", model.SecondaryTradeId);
            ViewState.Add("CustomerLevelId", model.CustomerLevelId);
            ViewState.Add("CustomerTypeId", model.CustomerTypeId);
            ViewState.Add("PayType",model.PayType);

            if (!StringUtils.IsEmpty(txtLinkMan.Text))
            {
                model.LinkMan = txtLinkMan.Text;
                ViewState.Add("LinkMan", model.LinkMan);
            }
            else
            {
                model.LinkMan = null;
                ViewState.Add("LinkMan", null);
            }
            if (!StringUtils.IsEmpty(txtBeginDate.Text))
            {
                model.BeginDate = txtBeginDate.Text;
                ViewState.Add("BeginDate", model.BeginDate);
            }
            else
            {
                model.BeginDate = null;
                ViewState.Add("BeginDate", null);
            }
            if (!StringUtils.IsEmpty(txtEndDate.Text))
            {
                model.EndDate = txtEndDate.Text;
                ViewState.Add("EndDate", model.EndDate);
            }
            else
            {
                model.EndDate = null;
                ViewState.Add("EndDate", null);
            }
            action.QueryCustomer(currentPageIndex - 1);
            this.AspNetPager1.CurrentPageIndex = 1;
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            this.AspNetPager1.RecordCount = (int)action.GetCustomerCount();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
	#endregion

	#region //分页处理程序
	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
       // this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        SerachData(e.NewPageIndex);
    }
	#endregion

}
