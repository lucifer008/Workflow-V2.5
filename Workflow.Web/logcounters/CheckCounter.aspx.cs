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
using Workflow.Action.LogCounters;
using Workflow.Util;
using System.Collections.Generic;
using Workflow.Da.Domain;

/// <summary>
/// 名    称: CheckCounter
/// 功能概要: 抄表的核实
/// 作    者: 陈汝胤
/// 创建时间: 2009.4.29
/// </summary>
public partial class logcounters_CheckCounter : Workflow.Web.PageBase
{
	#region 类成员

	protected CheckCounterModel model;
	private CheckCounterAction checkCounterAction=new CheckCounterAction();
	public CheckCounterAction CheckCounterAction
	{
		set { checkCounterAction = value; }
	}

	#endregion

	private static Hashtable table;

	private static IList<MachineWatchConversionPaper> ConversionList; 

	#region Page_Load

	protected void Page_Load(object sender, EventArgs e)
	{
		string id=null;
		if (!IsPostBack)
		{
			id = Request.QueryString["id"];
			table = null;
		}
		else
		{
			id = Request.Form["id"];
		}
		if (string.IsNullOrEmpty(id))
		{
			throw new ArgumentException("参数错误");
		}
		else
		{
			model = checkCounterAction.Model;
			model.RecordMachineWatchId = int.Parse(id);
			string compensateVerify = Request.Form["compensateVerify"];
			if (!string.IsNullOrEmpty(compensateVerify))
			{
				model.ConversionList = ConversionList;
				checkCounterAction.CompleteVerify();
				model.IsVerify = 1;
			}

			if (null != table) model.MakeMap = table;

			string compensateUsedPaperId = Request.Form["compensateUsedPaperId"];
			if (!string.IsNullOrEmpty(compensateUsedPaperId))
			{
				model.CompensateUsedPaperId = long.Parse(compensateUsedPaperId);
				checkCounterAction.DeleteCompensateUsedPaper();
			}
			checkCounterAction.GetVerifyData();
			table = model.MakeMap;
			ConversionList = model.ConversionList;
		}
	}

	#endregion
}
