using System;
using System.Web.UI.WebControls.WebParts;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称:CustomerValidate
/// 功能概要: 客户确认
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
///      修正人:张晓林
///      修正时间:2009-02-09
///      修正描述：增加分页功能
/// </summary>

public partial class CustomerValidate : Workflow.Web.PageBase
{
	#region //类成员
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
        try
        {
            model = action.Model;
            if (!IsPostBack)
            {
                CurrentNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
	#endregion

    #region //客户确认
    /// <summary>
    /// 将客户从未确认制为确认
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-9-29
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    protected void UpdateCustomerValidate(object sender, EventArgs e)
    {
        try
        {
            if (Request["cbCutomer"] != null)
            {
                string strChecked = Request["cbCutomer"];
                string[] checkedId = strChecked.Split(new char[] { ',' });
                for (int i = 0; i < checkedId.Length; i++)
                {
                    model.Customer = new Workflow.Da.Domain.Customer();
                    model.Customer.Id = NumericUtils.ToLong(checkedId[i]);
                    action.UpdateCustomerValidate();
                }
            }
            CurrentNextPageData(1);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region  //合并客户
    /// <summary>
    /// 合并客户
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-9-29
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void ConbinationCustomer(object sender, EventArgs e)
    {
        if (Request["cbCutomer"] != null)
        {
            string strConbinationId = Request["cbCutomer"];
            Response.Redirect("CustomerConbination.aspx?strConbinationId=" + strConbinationId);
        }
        action.SearchAllNotValidate(1);
    }
    #endregion

    #region //分页处理事件

    private void CurrentNextPageData(int currentPageIndex)
    {
        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.RecordCount = Convert.ToInt32(action.SearchAllNotValidateRowCount());
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        action.SearchAllNotValidate(currentPageIndex);

    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        CurrentNextPageData(e.NewPageIndex);
    }
    #endregion
}
