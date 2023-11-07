using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflow.Action.Positions;
using System.Web.UI.MobileControls;
using System.Data.SqlClient;
/// <summary>
/// 名    称: PositionList
/// 功能概要: 岗位一览
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-15
/// 修正履历: 
/// 修正时间: 
/// </summary>

public partial class popedomManagement_position_PositionList : Workflow.Web.PageBase
{
	#region class Member
	protected PositionModel model;

    private PositionAction positionAction;
    public PositionAction PositionAction
    {
        set { positionAction = value; }
    }
	#endregion

	#region Page_Load
	protected void Page_Load(object sender, EventArgs e)
    {
        string id = Request.Form["txtValue"];
        model = positionAction.Model;
        if (null != id && id != "")
        {
			try
			{
				model.Id = long.Parse(id);
				positionAction.DelPosition();
			}
			catch (SqlException ex)
			{
				Workflow.Support.Log.LogHelper.WriteError(ex, Workflow.Support.Constants.LOGGER_NAME);
				Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script lanuage=javascript>alert('当前岗位已经分配了雇员!\\n请先取消此岗位上的雇员!');</script>");
			}
			catch (Exception ex)
			{
				Workflow.Support.Log.LogHelper.WriteError(ex, Workflow.Support.Constants.LOGGER_NAME);
				Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script lanuage=javascript>alert('发生未知异常,请联系管理员!');</script>");
			}
        }
        positionAction.GetAllPositionList();
    }
	#endregion
	
}
