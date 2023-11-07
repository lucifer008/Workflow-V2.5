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
using Workflow.Da.Domain;
using System.Collections.Generic;

/// <summary>
/// 名    称: CopyCounter
/// 功能概要: 抄表处理
/// 作    者: 陈汝胤
/// 创建时间: 2009-2-10
/// </summary>
public partial class logcounters_CopyCounter : Workflow.Web.PageBase
{
	#region 类成员
	
	protected CopyCounterModel model;
	private CopyCounterAction copyCounterAction;
	public CopyCounterAction CopyCounterAction
	{
		set { copyCounterAction = value; }
	}
	#endregion

	#region Page_Load
	
	protected void Page_Load(object sender, EventArgs e)
	{
		Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
		model = copyCounterAction.Model;
		string verify = Request.Form["verify"];
		if (string.IsNullOrEmpty(verify))
		{
			model.RecordMachineWatchId = Request.Form["RecordMachineWatch"];
			model.UncompleteOrderId = Request.Form["UncompleteOrder"];
			copyCounterAction.InitCopyCounter();
			if (!IsPostBack)
			{
				copyCounterAction.CleanUpUncompleteRecordWatchData();
			}
		}
		else
		{
			copyCounterAction.InitCopyCounter();
			foreach (Machine machine in model.MachineList)
			{
				foreach (MachineWatch machineWatch in machine.watchs)
				{
					string watchValue=Request.Form[machineWatch.Name + machineWatch.Id];
					if (string.IsNullOrEmpty(watchValue))
					{
						throw new ArgumentException("数据不全");
					}
					else
					{
						machineWatch.Number = int.Parse(watchValue);
					}
				}
			}
			copyCounterAction.SaveVerifyRecordWatchData();

			Response.Redirect("CheckCounter.aspx?id="+model.RecordMachineWatchId);
		}
	}
	#endregion
}
