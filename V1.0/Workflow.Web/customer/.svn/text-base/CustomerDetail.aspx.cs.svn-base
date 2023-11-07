using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称:CustomerDetail
/// 功能概要: 客户详情
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
/// 修 正 人: 张晓林
/// 修正时间: 2009-02-09
/// 修正描述: 增加异常捕获
/// </summary>

public partial class CustomerDetail : Workflow.Web.PageBase
{
	#region //类成员
	private NewCustomerAction action;
    protected NewCustomerModel model;
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
                InitData();
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
	#endregion

	#region //初始化数据
	/// <summary>
    /// 方法名称: InitData
    /// 功能概要: 页面初始化
    /// 作    者: liuwei
    /// 创建时间: 2007-9-25
    /// </summary> 
    private void InitData()
    {
         long Id = NumericUtils.ToLong(Request.QueryString["Id"]);
         model.Id = Id;
         action.SearchCustomerById();
    }
	#endregion
}
