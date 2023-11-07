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
using Workflow.Action.Activities;

/// <summary>
/// 名    称: DiscountConcessionModel
/// 功能概要: 打折活动添加
/// 作    者: 陈汝胤
/// 创建时间: 2009.5.11
/// </summary>
public partial class activities_AddDiscountConcession : System.Web.UI.Page
{
	#region class_memebr

	protected DiscountConcessionModel model;
	private DiscountConcessionAction discountConcessionAction;
	public DiscountConcessionAction DiscountConcessionAction
	{
		set { discountConcessionAction = value; }
	}

	private static long actionId;

	#endregion

	#region page_load

	protected void Page_Load(object sender, EventArgs e)
	{
		model=discountConcessionAction.Model;
		if (!IsPostBack)
		{
			string id = Request.QueryString["id"];
			if (!string.IsNullOrEmpty(id))
			{
				model.DiscountConcessionId = actionId = long.Parse(id);
			}
			discountConcessionAction.GetInitData();
		}
		else
		{
			model.DiscountConcessionId = actionId;
			model.CampaignId=long.Parse(Request.Form["campaign"]);
			model.DiscountName = Request.Form["project"];
			model.DiscountMemo = Request.Form["memo"];
			model.DiscountInfo = Request.Form["discountInfo"];
			model.ChargeAmount = decimal.Parse(Request.Form["chargeAmount"]);
			discountConcessionAction.EditDiscountApplyMachineAndPaper();
			Response.Redirect("DiscountConcessionList.aspx");
		}
		model.ActionInfo = (actionId == 0) ? "添加" : "修改";
	}

	#endregion
}
