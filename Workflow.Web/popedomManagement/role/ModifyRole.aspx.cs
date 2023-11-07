using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Da.Domain;
using Workflow.Action.Roles;
/// <summary>
/// 名    称: ModifyRole
/// 功能概要: 角色编辑
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-16
/// 修正履历: 
/// 修正时间: 
/// </summary>

public partial class ModifyRole : Workflow.Web.PageBase
{
	#region 类成员
	protected RoleModel model;
    private RoleAction roleAction;
    public RoleAction RoleAction
    {
        set { roleAction = value; }
    }

    private static long action;
	#endregion

	#region 页面加载
	protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("pragma", "no-cache");
        Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
        Response.AppendHeader("expires", "0");


        model = roleAction.Model;
        if (!IsPostBack)
        {
            action = 0;
            string id = Request.QueryString["id"];
            roleAction.GetRolePermissionGroup();
            if (null != id && id != "")
            {
                model.Action = "修改";
                model.Id = long.Parse(id);
                action = model.Id;
                roleAction.GetRoleByRoleId();
                roleAction.GetRoleUserdPermissionGroup();
            }
        }
        else
        {
            string operation = Request.Form["operation"];
            if (null != operation)
            {
                string accessory = Request.Form["roleCheckbox"];
                if (null != accessory)
                    model.Accessory = accessory;
                //添加
                string roleName = Request.Form["roleName"];
                if (null != roleName && roleName != "")
                {
                    if(0 == action)
                    {
                        model.Name = roleName;
                        roleAction.InsertRole();
                    }
                    else
                    {
                        model.Id=action;
                        roleAction.GetRoleByRoleId();
                        model.Name=roleName;
                        roleAction.UpdateRole();
                    }
                }
            }
        }
    }
	#endregion
	
}
