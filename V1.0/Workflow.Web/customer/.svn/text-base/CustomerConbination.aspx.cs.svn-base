using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Action.Model;
using Workflow.Support.Log;

/// <summary>
/// 名    称:CustomerConbination
/// 功能概要: 合并客户
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
/// 修 正 人: 张晓林
/// 修正时间: 2009-02-09
/// 修正描述: 增加异常捕获
/// </summary>

public partial class CustomerConbination : Workflow.Web.PageBase
{
	#region //类成员
	protected NewCustomerAction action;
    protected NewCustomerModel model;
    protected string[] ConbinationId = null;
    protected bool ShowTag = false;
    //合并客户
    protected bool ConbinationTag = false;

    /// <summary>
    /// Sets the new customer action.
    /// </summary>
    /// <value>The new customer action.</value>
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
            //显示合并客户信息            
            string strConbination = Request.QueryString["strConbinationId"];
            HiddenConbination.Value = strConbination;
        }
        ConbinationId = HiddenConbination.Value.Split(new char[] { ',' });
    }
	#endregion

	#region //合并客户
	/// <summary>
    /// 方法名称: ConbinationCustomer
    /// 功能概要: 合并客户
    /// 作    者: liuwei
    /// 创建时间: 2007-9-28
    /// </summary>
    protected void ConbinationCustomer(object sender, EventArgs e)
    {
        //判断是否存在要合并的主客户　
        try
        {
            if (string.Compare(Request.Form.Get("customerid"), "") != 0)
            {
                long Id = NumericUtils.ToLong(Request.Form.Get("customerid"));
                for (int i = 0; i < ConbinationId.Length; i++)
                {
                    long OldId = NumericUtils.ToLong(ConbinationId[i]);
                    if (Id != OldId)
                    {
                        model.LinkMan = new Workflow.Da.Domain.LinkMan();
                        model.LinkMan.CustomerId = Id;
                        model.Id = OldId;

                        //更改联系人中的CustomerId和工单中的CustomerId信息
                        action.UpdateConbinationCustomerId();
                        action.LogicDelete();
                    }
                }

                model.Customer = new Workflow.Da.Domain.Customer();
                model.Customer.Id = Id;

                action.UpdateCustomerValidate();
                ShowTag = true;
            }

            ConbinationTag = true;
            Response.Redirect("CustomerValidate.aspx");
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
	#endregion	
}
