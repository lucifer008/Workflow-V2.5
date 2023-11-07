using System;
using System.Collections;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Log;
using System.Collections.Generic;
/// <summary>
/// 功能概要: 门市价格批量删除
/// 作    者: 张晓林
/// 创建时间: 2010年1月15日9:33:19
/// 修正履历: 门市价格批量修改
/// 修 改 人: 陈汝胤
/// 修正时间: 2010.2.1
/// </summary>
public partial class system_pricemanager_BatchUpdatePrice : System.Web.UI.Page
{
    #region ClassMember
    protected long lngBusinessTypeId = -1;
    protected BaseBusinessTypePriceSetModel model;
    protected long pageID = 1;

	protected bool arrangUpdate;
	protected decimal costPrice; //成本价格
	protected decimal standardPrice; //标准价格
	protected decimal activityPrice;   //活动价格
	protected decimal reservePrice; //备用价格
    private Hashtable currentmap;
	protected bool isUpdate;
    protected BaseBusinessTypePriceSetAction baseBusinessTypePriceSetAction;
    public BaseBusinessTypePriceSetAction BaseBusinessTypePriceSetAction
    {
        set { baseBusinessTypePriceSetAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
		model = baseBusinessTypePriceSetAction.Model;
		if (IsPostBack)
		{
			if (this.isQuery.Value == "4")
			{
				BatchUpdatePrice();
				BindData();
			}
			if (this.isQuery.Value == "3")
			{
				arrangUpdate = true;
				BindData();
				if (!string.IsNullOrEmpty(Request.Form["txtCostPrice"]))
					costPrice = decimal.Parse(Request.Form["txtCostPrice"]);
				if (!string.IsNullOrEmpty(Request.Form["txtStandardPrice"]))
					standardPrice = decimal.Parse(Request.Form["txtStandardPrice"]);
				if (!string.IsNullOrEmpty(Request.Form["txtActivityPrice"]))
					activityPrice = decimal.Parse(Request.Form["txtActivityPrice"]);
				if (!string.IsNullOrEmpty(Request.Form["txtReservePrice"]))
					reservePrice = decimal.Parse(Request.Form["txtReservePrice"]);
			}
		}
		else
		{
			baseBusinessTypePriceSetAction.GetPriceFactor();
		}
    }
    #endregion

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
        long tmplngBusinessTypeId = -1;
        model.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
        model.BaseBusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
        model.BaseBusinessTypePriceSet.BusinessType.Id = tmplngBusinessTypeId;
        if (this.isQuery.Value == "1")
        {
            if (null != Request.Form["sltBusinessType"])
            {
                tmplngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
            }
            model.BaseBusinessTypePriceSet.BusinessType.Id = tmplngBusinessTypeId;

            currentmap = new Hashtable();

			ViewState.Add(ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString(), currentmap);

            currentmap.Add("businesstype", tmplngBusinessTypeId);
        }
        else
        {
			if (ViewState[ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString()] != null)
			{
				currentmap = (Hashtable)ViewState[ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString()];

                model.BaseBusinessTypePriceSet.BusinessType.Id = (long)currentmap["businesstype"];
            }
        }

        //获取价格因素
        baseBusinessTypePriceSetAction.GetPriceFactor();
        //获取价格因素的条件
        GetQueryPriceCondition();

		baseBusinessTypePriceSetAction.InitCustomerQuery();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindData();
    }
    #endregion

    #region //获取价格因素的条件
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
                if (currentmap != null && this.isQuery.Value!="1")
                {
					//int key=int.Parse(priceFactor.Id.ToString()) - 1;
					if (currentmap.ContainsKey(intFoundPos))
					{
						model.BaseBusinessTypePriceSet[intFoundPos] = (long)currentmap[intFoundPos];
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
							model.BaseBusinessTypePriceSet[intFoundPos] = long.Parse(factorValue);
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
		string bbtplId = Request.Form["cbBBTPS"];
		if (!string.IsNullOrEmpty(bbtplId))
		{
			model.BaseBusinessTypePriceSetList = new List<BaseBusinessTypePriceSet>();

			string[] bbtplIds = bbtplId.Split(',');
			foreach (string id in bbtplIds)
			{
				BaseBusinessTypePriceSet price = new BaseBusinessTypePriceSet();
				price.Id = long.Parse(id);
				price.CostPrice = decimal.Parse(Request.Form["costPrice" + id]);
				price.StandardPrice = decimal.Parse(Request.Form["standardPrice" + id]);
				price.ActivityPrice = decimal.Parse(Request.Form["activityPrice" + id]);
				price.ReservePrice = decimal.Parse(Request.Form["reservePrice" + id]);
				model.BaseBusinessTypePriceSetList.Add(price);
			}
			baseBusinessTypePriceSetAction.BatchUpdatePrice();
		}
	}

	#endregion
}
