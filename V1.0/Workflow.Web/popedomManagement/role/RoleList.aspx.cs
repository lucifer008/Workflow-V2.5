using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Da.Domain;
using Workflow.Action.Roles;
/// <summary>
/// 名    称: RoleList
/// 功能概要: 角色一览
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-16
/// 修 正 人: 
/// 修正时间:
/// 修正描述:
/// </summary>

public partial class RoleList : Workflow.Web.PageBase
{
	#region 类成员
	/// <summary>
	/// 功能概要: 类成员
	/// 作    者: 陈汝胤
	/// 创建时间: 2009-1-16
	/// </summary>
	protected RoleModel model;
    private RoleAction roleAction;
	/// <summary>
	/// 功能概要: 类成员
	/// 作    者: 陈汝胤
	/// 创建时间: 2009-1-16
	/// </summary>
    public RoleAction RoleAction
	{
        set { roleAction = value; }
	}
	#endregion

	#region 页面加载
	/// <summary>
	/// 功能概要: 页面加载
	/// 作    者: 陈汝胤
	/// 创建时间: 2009-1-16
	/// </summary>
	protected void Page_Load(object sender, EventArgs e)
    {
        string delAction = Request.Form["txtValue"];
        model = roleAction.Model;
        if (null != delAction && delAction != "")
        {
			try
			{
				model.Id = long.Parse(delAction);
				roleAction.DeleteRoleById();
			}
			catch (SqlException ex)
			{
				Workflow.Support.Log.LogHelper.WriteError(ex, Workflow.Support.Constants.LOGGER_NAME);
				Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('当前角色已经分配了雇员!\\n请先取消此角色上的雇员!')</script>");
			}
			catch (Exception ex)
			{
				Workflow.Support.Log.LogHelper.WriteError(ex, Workflow.Support.Constants.LOGGER_NAME);
				Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('发生未知异常,请联系管理员!')</script>");
			}
        }
        roleAction.GetRoleList();
    }
	#endregion
}
