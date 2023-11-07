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
using Workflow.Action;
using Workflow.Action.Model;
using Workflow.Support;
using Workflow.Da.Domain;
using System.Collections.Generic;

public partial class system_pricemanager_BatchUpdateMemberPrice : System.Web.UI.Page
{
	#region //类成员
	protected long lngBusinessTypeId = -1;
	protected long lngMemberCardLevel = -1;
	protected int intAction = Constants.ACTION_INIT;
	protected BusinessTypePriceSetModel model;
	private Hashtable currentmap;
	protected long pageID = 1;


	protected bool arrangUpdate;
	protected decimal newPrice; //备用价格
	protected BusinessTypePriceSetAction businessTypePriceSetAction;
	public BusinessTypePriceSetAction BusinessTypePriceSetAction
	{
		set { businessTypePriceSetAction = value; }
	}
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
		model = businessTypePriceSetAction.Model;
		//初始化显示
		businessTypePriceSetAction.InitDataPriceTypeMember(intAction);
		if (IsPostBack)
		{
			if (Request.Form["sltBusinessType"] != null)
			{
				lngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
			}
			if (Request.Form["sltMemberCardLevel"] != null)
			{
				lngMemberCardLevel = long.Parse(Request.Form["sltMemberCardLevel"]);
			}

			if (this.isQuery.Value == "4")
			{
				BatchUpdatePrice();
			}
			if (this.isQuery.Value == "3")
			{
				arrangUpdate = true;
				if (!string.IsNullOrEmpty(Request.Form["txtNewPrice"]))
					newPrice = decimal.Parse(Request.Form["txtNewPrice"]);
			}

			BindData();
		}
	}

	#region//查询

	/// <summary>
	/// 方法名称: BindData
	/// 功能概要: 初始化页面
	/// 作    者: 陈汝胤
	/// 创建时间: 2009-1-9
	/// 修正履历: 
	/// 修正时间: 
	/// </summary>
	private void BindData()
	{
		//设定查询条件
		model.BusinessTypePriceSet = new BusinessTypePriceSet();
		//model.BusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
		//取得业务类型ID
		model.BusinessTypePriceSet.BusinessTypeId = lngBusinessTypeId;
		//取得卡级别类型ID
		model.BusinessTypePriceSet.TargetId = lngMemberCardLevel;
		//设定价格类型
		model.BusinessTypePriceSet.PriceType = Constants.PRICE_TYPE_MEMBER;

		if (this.isQuery.Value == "1")
		{
			currentmap = new Hashtable();

			ViewState.Add(ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString(), currentmap);

			currentmap.Add("businesstype", lngBusinessTypeId);
			currentmap.Add("targetId", lngMemberCardLevel);
		}
		else
		{
			if (ViewState[ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString()] != null)
			{
				currentmap = (Hashtable)ViewState[ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString()];

				model.BusinessTypePriceSet.BusinessTypeId = (long)currentmap["businesstype"];
				model.BusinessTypePriceSet.TargetId = (long)currentmap["targetId"];
			}
		}
		//获取价格因素的条件
		GetQueryPriceCondition();

		businessTypePriceSetAction.GetOnlyBusinessTypePriceSets();
	}
	#endregion

	#region 获取价格因素的条件
	/// <summary>
	/// 方法名称: GetQueryPriceCondition
	/// 功能概要: 获取查询门市价格的条件
	/// 作    者: 陈汝胤
	/// 创建时间: 2009-1-12
	/// 修正履历: 
	/// 修正时间: 
	/// </summary>
	private void GetQueryPriceCondition()
	{
		if (null != model.PriceFactor && model.PriceFactor.Count > 0)
		{
			int intFoundPos = 0;
			foreach (PriceFactor priceFactor in model.PriceFactor)
			{
				if (currentmap != null && this.isQuery.Value != "1")
				{
					//int key=int.Parse(priceFactor.Id.ToString()) - 1;
					if (currentmap.ContainsKey(intFoundPos))
					{
						model.BusinessTypePriceSet[intFoundPos] = (long)currentmap[intFoundPos];
						intFoundPos++;
					}
				}
				else
				{
					string factorValue = Request.Form["factorValuex" + priceFactor.Id];
					if (null != factorValue)
					{
						if (factorValue.Trim().Equals("-1"))
						{
							intFoundPos++;
							continue;
						}
						try
						{
							model.BusinessTypePriceSet[intFoundPos] = long.Parse(factorValue);
							currentmap.Add(intFoundPos, long.Parse(factorValue));
						}
						catch (Exception ex)
						{
							Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
						}
						intFoundPos++;
					}
				}
			}
			this.isQuery.Value = "0";
		}
	}

	#endregion

	#region 批量修改价格

	/// <summary>
	/// 批量修改价格
	/// </summary>
	private void BatchUpdatePrice()
	{
		string bbtplId = Request.Form["chky"];
		if (!string.IsNullOrEmpty(bbtplId))
		{
			model.BusinessTypePriceSetList = new List<BusinessTypePriceSet>();

			string[] bbtplIds = bbtplId.Split(',');
			foreach (string id in bbtplIds)
			{
				BusinessTypePriceSet price = new BusinessTypePriceSet();
				price.Id = long.Parse(id);
				price.NewPrice= decimal.Parse(Request.Form["newPrice" + id]);
				model.BusinessTypePriceSetList.Add(price);
			}
			businessTypePriceSetAction.BatchUpdatePrice();
		}
	}

	#endregion
}
