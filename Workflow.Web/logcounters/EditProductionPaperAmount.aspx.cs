using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Workflow.Action.LogCounters;
using System.Web.UI.WebControls.WebParts;

/// <summary>
/// 名    称: EditProductionPaperAmount
/// 功能概要: 未完订单用纸情况
/// 作    者: 陈汝胤
/// 创建时间: 2009.4.23
/// </summary>
public partial class logcounters_EditProductionPaperAmount : Workflow.Web.PageBase
{
	#region 类成员

	protected EditProductionPaperAmountModel model;
	private EditProductionPaperAmountAction editProductionPaperAmountAction;
	public EditProductionPaperAmountAction EditProductionPaperAmountAction
	{
		set { editProductionPaperAmountAction = value; }
	}

	private static long actionType;

	#endregion

	#region Page_Load

	protected void Page_Load(object sender, EventArgs e)
	{
		Response.AppendHeader("pragma", "no-cache");
		Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
		Response.AppendHeader("expires", "0");
		model = editProductionPaperAmountAction.Model;
		if (!IsPostBack)
		{
			string id = Request.QueryString["id"];
			if (!string.IsNullOrEmpty(id))
			{
				actionType=long.Parse(id);
				model.ActionStr = (0 == actionType) ? "新增" : "修改";
				model.UncompleteOrdersUsedPaperId = actionType;
				editProductionPaperAmountAction.InitEditProductionPaperAmount();
			}
		}
		else
		{
			string orderId = Request.Form["orderNo"];
			string machineTypeId = Request.Form["machineType"];
			string paperShapeId = Request.Form["paperSpecification"];
			string paperColorType = Request.Form["paperColor"];
			string number=Request.Form["number"];
			//插入
			model.OrderId = long.Parse(orderId);
			model.MachineTypeId = long.Parse(machineTypeId);
			model.PaperShapeId = long.Parse(paperShapeId);
			model.PaperColorType = paperColorType;
			model.Number = int.Parse(number);
			if (0 == actionType)
			{
				//插入
				editProductionPaperAmountAction.AddUncompeteOrdersUsedPaper();
			}
			else
			{
				model.UncompleteOrdersUsedPaperId = actionType;
				//更新
				editProductionPaperAmountAction.UpdateUncompeteOrdersUsedPaper();
			}
		}
	}

	#endregion
	
}
