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
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;


/// <summary>
/// 名    称: SpecialPriceSetting
/// 功能概要: 特殊会员卡价格设置一览/追加/修改/删除
/// 作    者: 麻少华
/// 创建时间: 2007-9-27
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
/// 修正履历: 陈汝胤
///			  重新写（以前的写的业务变更）
/// </summary>
public partial class SpecialPriceSetting : Workflow.Web.PageBase
{
    #region 暂时注释以前的
	//private long lngBusinessTypeId = 0;
	//private long lngMemberCardId = 0;
	//protected int intAction = Constants.ACTION_INIT;
	//protected BusinessTypePriceSetModel model;
	//protected BusinessTypePriceSetAction businessTypePriceSetAction;
	//public BusinessTypePriceSetAction BusinessTypePriceSetAction
	//{
	//    set { businessTypePriceSetAction = value; }
	//}
	//protected void Page_Load(object sender, EventArgs e)
	//{
	//    model = businessTypePriceSetAction.Model;
	//    businessTypePriceSetAction.InitDataPriceTypeSpecial(intAction);

	//    //获得页面动作
	//    if (Request.Form["txtAction"] != null)
	//    {
	//        intAction = int.Parse(Request.Form["txtAction"]);
	//    }
	//    //判断页面动作执行不同的处理
	//    if (intAction == Constants.ACTION_INIT)
	//    {
	//        QueryProcess();
	//        //初始化显示
	//        //businessTypePriceSetAction.InitDataPriceTypeSpecial(intAction);
	//    }
	//    else if (intAction == Constants.ACTION_SEARCH)
	//    {
	//        //查询
	//        QueryProcess();
	//        //businessTypePriceSetAction.InitDataPriceTypeSpecial(intAction);
	//    }
	//    else if (intAction == Constants.ACTION_DELETE)
	//    {
	//        //删除
	//        DeleteProcess();
	//        //businessTypePriceSetAction.InitDataPriceTypeSpecial(intAction);
	//        //再检索一遍
	//        QueryProcess();
	//    }
	//    else if (intAction == Constants.ACTION_UPDATE)
	//    {
	//        //编辑后再重新检索一遍
	//        QueryProcess();
	//    }
	//}

   
	///// <summary>
	///// 方法名称: QueryProcess
	///// 功能概要: 自定义查询
	///// 作    者: 麻少华
	///// 创建时间: 2007-9-27
	///// 修正履历: 
	///// 修正时间: 
	///// </summary>
	//private void QueryProcess()
	//{
	//    //获得查询条件
	//    if (Request.Form["sltBusinessType"] != null)
	//    {
	//        lngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
	//    }
	//    if (Request.Form["sltMemberCardLevel"] != null)
	//    {
	//        lngMemberCardId = long.Parse(Request.Form["txtMemberCardId"]);
	//    }
	//    //设定查询条件
	//    model.BusinessTypePriceSet = new BusinessTypePriceSet();
	//    model.BusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
	//    //取得业务类型ID
	//    model.BusinessTypePriceSet.BusinessType.Id = lngBusinessTypeId;
	//    //取得会员卡ID
	//    model.BusinessTypePriceSet.TargetId = lngMemberCardId;
	//    //设定价格类型
	//    model.BusinessTypePriceSet.PriceType = Constants.PRICE_TYPE_SPECIAL;

	//    //查询
	//    businessTypePriceSetAction.InitCustomQuery(businessTypePriceSetAction.Model);
	//}

    
	///// <summary>
	///// 方法名称: DeleteProcess
	///// 功能概要: 删除价格
	///// 作    者: 麻少华
	///// 创建时间: 2007-9-27
	///// 修正履历: 
	///// 修正时间: 
	///// </summary>
	//private void DeleteProcess()
	//{
	//    model.BusinessTypePriceSet = new BusinessTypePriceSet();
	//    model.BusinessTypePriceSet.Id = int.Parse(txtId.Value);
	//    businessTypePriceSetAction.Delete(model);

	//}
    #endregion

	#region 类成员
	//业务类型ID
	protected long lngBusinessTypeId = -1;
	protected BusinessTypePriceSetModel model;
	protected long pageID = 1;
	private Hashtable currentmap;
	protected BusinessTypePriceSetAction businessTypePriceSetAction;
	public BusinessTypePriceSetAction BusinessTypePriceSetAction
	{
		set { businessTypePriceSetAction = value; }
	}
	#endregion

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			this.AspNetPager1.CurrentPageIndex = 1;
			BindData(0);
		}
		//string txtAction = Request.Form["txtAction"];
	}

	#region 数据初始化
	/// <summary>
	/// 方法名称: BindData
	/// 功能概要: 初始化页面
	/// 作    者: 陈汝胤
	/// 创建时间: 2009-1-9
	/// 修正履历: 
	/// 修正时间: 
	/// </summary>
	private void BindData(int pageIndex)
	{
		model = businessTypePriceSetAction.Model;
		long tmplngBusinessTypeId = -1;
		model.BusinessTypePriceSet = new BusinessTypePriceSet();
		model.BusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
		model.BusinessTypePriceSet.BusinessType.Id = tmplngBusinessTypeId;
		if (this.isQuery.Value == "1")
		{
			if (null != Request.Form["sltBusinessType"])
			{
				tmplngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
			}
			model.BusinessTypePriceSet.BusinessType.Id = tmplngBusinessTypeId;

			currentmap = new Hashtable();

			ViewState.Add(ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString(), currentmap);

			currentmap.Add("businesstype", tmplngBusinessTypeId);
		}
		else
		{
			if (ViewState[ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString()] != null)
			{
				currentmap = (Hashtable)ViewState[ThreadLocalUtils.CurrentUserContext.CurrentUser.Id.ToString()];

				model.BusinessTypePriceSet.BusinessType.Id = (long)currentmap["businesstype"];
			}
		}

		//获取价格因素
		businessTypePriceSetAction.GetPriceFactor();
		//获取价格因素的条件
		GetQueryPriceCondition();

		this.AspNetPager1.RecordCount = 1000;
		this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
		//model.BusinessTypePriceSet.BeginRow = pageIndex * Constants.ROW_COUNT_FOR_PAGER + 1;
		//model.BusinessTypePriceSet.EndRow = pageIndex * Constants.ROW_COUNT_FOR_PAGER + Constants.ROW_COUNT_FOR_PAGER;
		//businessTypePriceSetAction.InitCustomQuery_Page();
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
				if (currentmap != null && this.isQuery.Value == "0")
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

	#region 分页控件事件
	protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
	{
		this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
		BindData(e.NewPageIndex - 1);
	}
	#endregion
}
