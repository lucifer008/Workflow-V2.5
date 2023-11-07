using System;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using Workflow.Web;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;

/// <summary>
/// 名    称:GetOneCustomer
/// 功能概要: 客户查询
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
/// 修 正 人: 张晓林
/// 修正时间: 2009-02-09
/// 修正描述: 完善分页功能,增加异常捕获
/// </summary>

public partial class SearchCustomer : Workflow.Web.PageBase
{
	#region //类成员
    protected int currentPageIndex = 0;
    protected SelectCustomerModel model;
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
        if (!IsPostBack)
        {
            InitData();
        }
        CurrentNextPageData(1);
    }

    /// <summary>
    /// 初始化页面信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-9-27
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void InitData()
    {
        try
        {
            action.Init();

            foreach (Workflow.Da.Domain.MasterTrade mt in model.MasterTradeList)
            {
                ListItem item = new ListItem(mt.Name, mt.Id.ToString());
                item.Attributes.Add("disabled", "disabled");
                Trade.Items.Add(item);
                foreach (Workflow.Da.Domain.SecondaryTrade st in mt.SecondaryTradeList)
                {
                    Trade.Items.Add(new ListItem("　" + st.Name, st.Id.ToString()));
                }
            }
            MakeSelectDefaultItem(Trade);

            CustomerLevel.DataSource = model.CustomerLevelList;
            CustomerLevel.DataTextField = "Name";
            CustomerLevel.DataValueField = "Id";
            CustomerLevel.DataBind();
            MakeSelectDefaultItem(CustomerLevel);

            CustomerType.DataSource = model.CustomerTypeList;
            CustomerType.DataTextField = "Name";
            CustomerType.DataValueField = "Id";
            CustomerType.DataBind();
            MakeSelectDefaultItem(CustomerType);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
	#endregion

    #region //查询
    /// <summary>
    /// 客户查询
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-9-27
	/// 修 正 人: 付强
    /// 修正时间:2008-11-5
	/// 修正描述:
    /// </remarks>
    protected void SearchCustomerInfo(object sender, EventArgs e)
    {
        try
        {
            //获取查询数据

            if (!StringUtils.IsEmpty(Name.Text.Trim()))
            {
                model.Name = Name.Text;
            }
            else 
            {
                model.Name = null;
            }
            model.SecondaryTradeId = NumericUtils.ToLong(Trade.SelectedValue, 0);
            model.CustomerLevelId = NumericUtils.ToLong(CustomerLevel.SelectedValue, 0);
            model.CustomerTypeId = NumericUtils.ToLong(CustomerType.SelectedValue, 0);

            if (!StringUtils.IsEmpty(LinkMan.Text))
            {
                model.LinkMan = LinkMan.Text;
            }
            else 
            {
                model.LinkMan = null;
            }

            if (!StringUtils.IsEmpty(BeginDate.Value))
            {
                model.BeginDate = BeginDate.Value;
            }
            else 
            {
                model.BeginDate = null;
            }

            if (!StringUtils.IsEmpty(EndDate.Value))
            {
                model.EndDate = EndDate.Value;
            }
            else 
            {
                model.EndDate = null;
            }
            model.IsNotDisplay = "true";//是否显示 散客和学生客户
            this.ViewState.Add("Name", model.Name);
            this.ViewState.Add("SecondaryTradeId", model.SecondaryTradeId.ToString());
            this.ViewState.Add("CustomerLevelId", model.CustomerLevelId.ToString());
            this.ViewState.Add("CustomerTypeId", model.CustomerTypeId.ToString());
            this.ViewState.Add("LinkMan", model.LinkMan);
            this.ViewState.Add("BeginDate", model.BeginDate);
            this.ViewState.Add("EndDate", model.EndDate);
            this.ViewState.Add("LinkMan", model.LinkMan);

            action.QueryCustomer(0);
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(action.GetCustomerCount());
            AspNetPager1.CurrentPageIndex = 1;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //分页处理程序
    private void CurrentNextPageData(int currentPageIndex) 
    {
        if (null != this.ViewState["Name"])
        {
            model.Name = this.ViewState["Name"].ToString();
        }
        if (null != this.ViewState["SecondaryTradeId"])
        {
            model.SecondaryTradeId = long.Parse(this.ViewState["SecondaryTradeId"].ToString());
        }
        if (null != this.ViewState["CustomerLevelId"])
        {
            model.CustomerLevelId = long.Parse(this.ViewState["CustomerLevelId"].ToString());
        }
        if (null != this.ViewState["CustomerTypeId"])
        {
            model.CustomerTypeId = long.Parse(this.ViewState["CustomerTypeId"].ToString());
        }
        if (null != this.ViewState["BeginDate"])
        {
            model.BeginDate = this.ViewState["BeginDate"].ToString();
        }
        if (null != this.ViewState["EndDate"])
        {
            model.EndDate = this.ViewState["EndDate"].ToString();
        }
        if (null != this.ViewState["LinkMan"])
        {
            model.LinkMan = this.ViewState["LinkMan"].ToString();
        }
        model.IsNotDisplay = "true";//是否显示 散客和学生客户
        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(action.GetCustomerCount());
        action.QueryCustomer(currentPageIndex - 1);
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        try
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            CurrentNextPageData(e.NewPageIndex);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
