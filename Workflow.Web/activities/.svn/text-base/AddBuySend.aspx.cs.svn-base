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

using Workflow.Action.Activities.Model;
using Workflow.Action.Activities;
using Workflow.Da.Domain;
using System.Text;
using Workflow.Support;

/// <summary>
/// 名    称: activities_AddBuySend
/// 功能概要: 买M送N活动
/// 作    者: 白晓宇
/// 创建时间: 2010年4月16日
/// </summary>
public partial class activities_AddBuySend : Workflow.Web.PageBase
{

	#region 类成员
	private BuySendAction buySendAction;
	/// <summary>
	/// BuySendAction
	/// </summary>
	public BuySendAction BuySendAction
	{
		set { buySendAction = value; }
	}

	/// <summary>
	/// Model
	/// </summary>
	protected BuySendModel model;

	/// <summary>
	/// 价格信息
	/// </summary>
	protected string priceInfo= "";
	#endregion

	#region PageLoad
	/// <summary>
	/// PageLoad
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
	protected void Page_Load(object sender, EventArgs e)
	{
		model = buySendAction.Model;
		if (!Page.IsPostBack)
		{
			this.InitData();
		}

		if (Page.IsPostBack)
		{
			this.SaveProcess();
		}
	}
	#endregion
	
	#region 页面数据初始化
	/// 名    称: InitData
	/// 功能概要: 页面数据初始化
	/// 作    者: 白晓宇
	/// 创建时间: 2010年4月16日
	private void InitData()
	{
		int buySendId = 0;
		int.TryParse(Request.QueryString["buySendId"], out buySendId);
		model.BuySendId = buySendId;

		buySendAction.GetAllBusinessType();
		buySendAction.GetAllCampaignList();
		model.ActionInfo = (model.BuySendId == 0) ? "添加" : "修改";

		
		if (0 != model.BuySendId) 
		{
			buySendAction.GetBuySendCampaingById();
			if (null != model.BuySend)
			{
				hidBuySendId.Value = model.BuySendId.ToString();

				model.CampaignId = model.BuySend.CampaignId;
				model.BuySendName = model.BuySend.Name;
				model.BuySendMemo = model.BuySend.Memo;
				model.BuySendDescription = model.BuySend.Description;
				model.BuyCount = model.BuySend.BuyCount;
				model.SendCount = model.BuySend.SendCount;
				model.PaperCount = model.BuySend.PaperCount;

				//获取门市价格
				buySendAction.GetBaseBusinessTypePriceSetInfo();
				model.BusinessTypeId = model.BaseBusinessTypePriceSet.BusinessType.Id;

				StringBuilder builder = new StringBuilder();
				builder.Append("factorValuex1:");
				builder.Append(model.BaseBusinessTypePriceSet.Factor1);
				builder.Append(",");

				builder.Append("factorValuex2:");
				builder.Append(model.BaseBusinessTypePriceSet.Factor2);
				builder.Append(",");

				builder.Append("factorValuex3:");
				builder.Append(model.BaseBusinessTypePriceSet.Factor3);
				builder.Append(",");

				builder.Append("factorValuex4:");
				builder.Append(model.BaseBusinessTypePriceSet.Factor4);
				builder.Append(",");

				builder.Append("factorValuex5:");
				builder.Append(model.BaseBusinessTypePriceSet.Factor5);
				builder.Append(",");

				priceInfo = builder.ToString();
				//获取价格因素
				//buySendAction.GetPriceFactor();
			}
			else
			{
				hidBuySendId.Value = "0";
			}
		}
	}
	#endregion

	#region 保存处理
	/// 名    称: SaveProcess
	/// 功能概要: 保存处理
	/// 作    者: 白晓宇
	/// 创建时间: 2010年4月16日
	private void SaveProcess() 
	{
		int campaignId = 0;
		int.TryParse(Request.Form["selectCapaign"], out campaignId);

		string buySendName = Request.Form["campaignName"];
		string buySendDescription = Request.Form["description"];
		string buySendMemo = Request.Form["inputMemo"];

		int buyCount = 0;
		int sendCount = 0;
		int.TryParse(Request.Form["inputBuyCount"], out buyCount);
		int.TryParse(Request.Form["inputSendCount"], out sendCount);

		decimal total = 0;
		decimal.TryParse(Request.Form["inputTotalCount"], out total);
		
		int businessTypeId = 0;
		int processContent = 0;
		int machineTypeId = 0;
		int pagerTypeId = 0;
		int paperSpecification = 0;
		int factorValueTicket = 0;

		int.TryParse(Request.Form["sltBusinessType"], out businessTypeId);
		int.TryParse(Request.Form["factorValuex1"], out processContent);
		int.TryParse(Request.Form["factorValuex2"], out machineTypeId);
		int.TryParse(Request.Form["factorValuex3"], out pagerTypeId);
		int.TryParse(Request.Form["factorValuex4"], out paperSpecification);
		int.TryParse(Request.Form["factorValuex5"], out factorValueTicket);

		int buySendId = 0;
		int.TryParse(hidBuySendId.Value, out buySendId);
		model.BuySendId = buySendId;

		if (model.BuySendId == 0)
		{
			model.BuySend = new Workflow.Da.Domain.BuySend();
		}
		else
		{
			model.BuySendId = int.Parse(hidBuySendId.Value);
			buySendAction.GetBuySendCampaingById();

		}

		//基本价格
		model.BuySend.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();

		model.BuySend.BaseBusinessTypePriceSet.BusinessTypeId = businessTypeId;
		//加工内容
		model.BuySend.BaseBusinessTypePriceSet.Factor1 = processContent;
		//机器型号
		model.BuySend.BaseBusinessTypePriceSet.Factor2 = machineTypeId;
		//纸质
		model.BuySend.BaseBusinessTypePriceSet.Factor3 = pagerTypeId;
		//纸型
		model.BuySend.BaseBusinessTypePriceSet.Factor4 = paperSpecification;
		//是否使用发票
		model.BuySend.BaseBusinessTypePriceSet.Factor5 = factorValueTicket;

		model.BuySend.Description = buySendDescription;
		model.BuySend.Name = buySendName;
		//购买的印章数
		model.BuySend.BuyCount = buyCount;
		//送的印章数
		model.BuySend.SendCount = sendCount;
		//计划送出印章数
		model.BuySend.PaperCount = total;
		//活动
		model.BuySend.CampaignId = campaignId;
		//备注
		model.BuySend.Memo = buySendMemo;

		try
		{
			if (0 != model.BuySendId)
			{
				buySendAction.EditBuySendCampaign();
				Response.Write("<script>window.returnValue=true;</script>");
				Response.Write("<script>window.close();</script>");
				Response.End();
			}
			else
			{
				buySendAction.AddBuySendCampaign();
				Response.Redirect("BuySendList.aspx");
			}
			
		}
		catch(Exception ex)
		{
			Page.RegisterClientScriptBlock("","<script>alert("+ex.ToString()+");</script>");
			Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);

			InitData();
		}

	}
	#endregion
}

