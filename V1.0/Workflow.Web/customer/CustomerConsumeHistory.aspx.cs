using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Action.Model;
using Workflow.Support.Log;

/// <summary>
/// 名    称:CustomerConsumeHistory
/// 功能概要: 客户消费历史
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
/// 修 正 人: 张晓林
/// 修正时间:2009-02-09
/// 修正描述:增加分页功能,异常捕获
/// </summary>

public partial class CustomerConsumeHistory : Workflow.Web.PageBase
{
	#region //类成员
    protected string CustomerName = "";
    protected NewCustomerModel model;

    private NewCustomerAction action;
    public NewCustomerAction NewCustomerAction
    {
        set { action = value; }
    }
	#endregion

	#region //页面加载
	protected void Page_Load(object sender, EventArgs e)
    {
        model = action.Model;
        if (!IsPostBack)
        {
            long Id = NumericUtils.ToLong(Request.QueryString["Id"]);
            CustomerName = Request.QueryString["CustomerName"];
            model.Id = Id;
            ViewState.Add("CustomerName", CustomerName);
            ViewState.Add("Id", Id);
            BindData(1);
        }
       
    }
	#endregion

    #region //分页事件处理程序
    private void BindData(int currentPageIndex)
    {
        try
        {
            if (null != ViewState["Id"] && "" != ViewState["Id"].ToString()) 
            {
                model.Id = Convert.ToInt32(ViewState["Id"]);
            }
            CustomerName = Convert.ToString(ViewState["CustomerName"]);
            action.SearchOrderByCustomerId(currentPageIndex-1);
            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.RecordCount =(int) action.SearchOrderRowCountByCustomerId();
            AspNetPager1.PageSize =Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Workflow.Support.Constants.LOGGER_NAME);
            throw ex;
        }
    }

    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        BindData(e.NewPageIndex);
    }

    #endregion   
}
