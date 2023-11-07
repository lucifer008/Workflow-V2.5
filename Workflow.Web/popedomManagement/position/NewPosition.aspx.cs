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
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Positions;
/// <summary>
/// 名    称: NewPosition
/// 功能概要: 添加，修改岗位
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-15
/// 修正履历: 
/// 修正时间: 
/// </summary>

public partial class popedomManagement_position_NewPosition : Workflow.Web.PageBase
{
	#region class Member
	protected PositionModel model;
    private PositionAction positionAction;
    public PositionAction PositionAction
    {
        set { positionAction = value; }
    }

    private static long action;
	#endregion

	#region Page_Load
	protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("pragma", "no-cache");
        Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
        Response.AppendHeader("expires", "0");


        model = positionAction.Model;

        if (!IsPostBack)
        {
            action = 0;
            string id = Request.QueryString["id"];
            if (null != id && id != "")
            {
                model.Action = "修改";
                model.Id = long.Parse(id);
                action = model.Id;
                positionAction.GetPositionById();
            }

        }
        else
        {
            string positionName = Request.Form["txtPositionName"];
            string positionMemo = Request.Form["txtPositionMemo"];
            if (null != positionName && null != positionMemo && positionName != null)
            {
                if (0 == action)
                {
                    //插入
                    Position position = new Position();
                    position.Name = positionName;
                    position.Memo = positionMemo;
                    model.Position = position;
                    positionAction.InsertPosition();
                }
                else
                {
                    model.Id = action;
                    positionAction.GetPositionById();
                    //更新
                    model.Position.Name = positionName;
                    model.Position.Memo = positionMemo;
                    positionAction.UpdatePosition();
                }
            }
        }
    }
	#endregion

}
