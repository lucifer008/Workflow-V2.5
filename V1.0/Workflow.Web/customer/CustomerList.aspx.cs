using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Da.Domain;
using Workflow.Action.Model;
/// <summary>
/// 名    称：CustomerList
/// 功能概要: 客户一览
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
/// 修 正 人: 张晓林
/// 修正时间: 2009-02-09
/// 修正描述: 完善客户 查询功能,增加异常捕获
///           张晓林
///           2009年10月24日11:52:23
///           增加按照会员卡号查询客户
/// </summary>

public partial class CustomerList : Workflow.Web.PageBase
{
	#region //类成员
    protected NewCustomerModel model;
    private bool IsNullCondition = false;
    protected int intAction = Constants.ACTION_INIT;
    private NewCustomerAction action;
    public NewCustomerAction NewCustomerAction
    {
        set { action = value; }
    }

    private SelectCustomerAction selectCustomerAction;
    public SelectCustomerAction SelectCustomerAction
    {
        set { selectCustomerAction = value; }
	}
	#endregion
	
	#region //页面加载
	protected void Page_Load(object sender, EventArgs e)
    {
        model = action.Model;
        if (!IsPostBack)
        {
            //BindData(1);
        }

        string strDeleteTag = this.deleteTag.Value;
        if (string.Compare(strDeleteTag, "delete") == 0)
        {
            long deleteId = Workflow.Util.NumericUtils.ToLong(this.deleteId.Value);
            DeleteCustomer(deleteId);
            BindData(this.AspNetPager1.CurrentPageIndex);
        }
	}
	#endregion

	#region //初始化数据
	/// <summary>
    /// 方法名称: InitData
	/// 功能概要: 初始化数据
    /// 作    者: liuwei
    /// 创建时间: 2007-9-25
    /// 修正履历: 付强
    /// 修正时间: 2009-1-15
    /// </summary>
    /// <param name="model"></param>
    /// 
    private void BindData(int currentPageIndex)
    {
        try
        {
            //action.SearchAllCustomer();
            if (!StringUtils.IsEmpty(CustomerName.Value))
            {
                selectCustomerAction.Model.Name = CustomerName.Value.Trim();
                IsNullCondition = true;
            }

            if(""!=txtMemberCardNo.Value.Trim())
            {
                selectCustomerAction.Model.MemberCardNo = txtMemberCardNo.Value.Trim();
                IsNullCondition = true;
            }

            if(IsNullCondition)
            {
                //ViewState.Add("Name", model.Name);
                //ViewState.Add("SecondaryTradeId", -1);
                //ViewState.Add("CustomerLevelId", -1);
                //ViewState.Add("CustomerTypeId", -1);
                //ViewState.Add("BeginDate", null);
                //ViewState.Add("EndDate", null);
                selectCustomerAction.Model.SecondaryTradeId = -1;
                selectCustomerAction.Model.CustomerLevelId = -1;
                selectCustomerAction.Model.CustomerTypeId = -1;
                selectCustomerAction.Model.BeginDate = null;
                selectCustomerAction.Model.EndDate = null;
                selectCustomerAction.Model.IsNotDisplay = "true";//是否显示 散客和学生客户
                selectCustomerAction.QueryCustomer(currentPageIndex - 1);
                action.Model.CustomerList = selectCustomerAction.Model.CustomerList;

                this.AspNetPager1.CurrentPageIndex = currentPageIndex;
                this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
                this.AspNetPager1.RecordCount = (int)selectCustomerAction.GetCustomerCount();
            }
            else
            {
                selectCustomerAction.Model.Name = null;
                ViewState.Add("Name", null);
                this.AspNetPager1.RecordCount = 0;
            }
           
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }

    }
	#endregion
	
	#region //查询
    /// <summary>
    /// 方法名称: SelectCustomerCondition
    /// 功能概要: 根据条件查询客户
    /// 作    者: liuwei
    /// 创建时间: 2007-9-25
    /// </summary>
    /// <param name="model"></param>
    /// 
    protected void SelectCustomerCondition(object sender, EventArgs e)
    {
        BindData(1);
    }
    #endregion

	#region  //删除客户
    /// <summary>
    /// 方法名称: DeleteCustomer
    /// 功能概要: 删除客户
    /// 作    者: liuwei
    /// 创建时间: 2007-9-27
    /// </summary>
    /// <param name="model"></param>
    private void DeleteCustomer(long Id)
    {
        try
        {
            model.Id = Id;
            action.DeleteCustomer();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

	#region //分页处理程序	
	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        BindData(e.NewPageIndex );
	}
	#endregion
}
