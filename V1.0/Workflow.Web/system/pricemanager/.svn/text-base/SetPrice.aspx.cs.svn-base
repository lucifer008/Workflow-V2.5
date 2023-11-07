using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
/// <summary>
/// 名    称: SetPrice
/// 功能概要: 设置价格的基本信息
/// 作    者: 麻少华
/// 创建时间: 2007-9-26
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
/// </summary>
public partial class SetPrice : Workflow.Web.PageBase
{
    #region 类成员
    protected BusinessTypePriceSetModel model;
    //当前处理的ID
    protected long lngCurId = 0;
    //当前价格处理的类型
    protected int intPageType = 0;
    //当前取得的价格类型名称
    protected string strPageTypeName = "";
    protected int intAction = Constants.ACTION_INIT;
    protected bool closeSelf = false;
    private BusinessTypePriceSetAction businessTypePriceSetAction;
    public BusinessTypePriceSetAction BusinessTypePriceSetAction
    {
        set { businessTypePriceSetAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = businessTypePriceSetAction.Model;

        //获得页面动作
        if (Request.Form["txtAction"]!=null)
        {
            intAction = int.Parse(Request.Form["txtAction"]);    
        }

        //判断页面动作执行不同的处理
        //初始化显示
        if (intAction == Constants.ACTION_INIT)
        {
            InitData();
        } 
        else if(intAction==Constants.ACTION_UPDATE)
        {
            SavePriceSet();
        }
    }
    #endregion

    #region 数据准备
    /// <summary>
    /// 方法名称: InitData
    /// 功能概要: 初始化价格设置
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-27
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void InitData()
    {
        if (Request.QueryString["ID"] != null)
        {
            lngCurId = long.Parse(Request.QueryString["ID"]);
        }
        if (Request.QueryString["PageType"] != null)
        {
            intPageType = int.Parse(Request.QueryString["PageType"]);
        }

        model.BusinessTypePriceSet = new BusinessTypePriceSet();
        model.BusinessTypePriceSet.Id = lngCurId;
        switch (intPageType)
        {
            case 1:
                strPageTypeName = "设置会员卡价格";
                model.BusinessTypePriceSet.PriceType = Constants.PRICE_TYPE_MEMBER;
                businessTypePriceSetAction.InitDataPriceSetMember(model, intAction);
                break;
            case 2:
                strPageTypeName = "设置行业价格";
                model.BusinessTypePriceSet.PriceType = Constants.PRICE_TYPE_TRADE;
                businessTypePriceSetAction.InitDataPriceSetMember(model, intAction);
                break;
            case 3:
                strPageTypeName = "设置特殊会员价格";
                model.BusinessTypePriceSet.PriceType = Constants.PRICE_TYPE_SPECIAL;
                businessTypePriceSetAction.InitDataPriceSetMember(model, intAction);
                break;
            default:
                strPageTypeName = "设置价格";
                break;
        }
        
    }

    /// <summary>
    /// 方法名称: PrepareModel
    /// 功能概要: 准备数据
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-26
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void PrepareModel()
    {
        model.BusinessTypePriceSetList = new List<BusinessTypePriceSet>();
        BusinessTypePriceSet businessTypePriceSet = new BusinessTypePriceSet();
        model.BusinessTypePriceSetList.Add(businessTypePriceSet);
        model.BusinessTypePriceSetList[0].BusinessType = new Workflow.Da.Domain.BusinessType();

        string[] strPriceFactorList = null;
        int intPriceFactorLength = 0;
        int intPageType = 0;
        long lngId = 0;
        long lngBusinesstypeId = 0;
        decimal decCostPrice = 0, decStandardPrice = 0, decActivityPrice = 0, decReservePrice = 0, decNewPrice = 0;
        decimal lngConcession = 0;
        
        //获取页面类型
        if (!StringUtils.IsEmpty(Request.Form["txtPageType"]))
        {
            intPageType = int.Parse(Request.Form["txtPageType"]);
        }
        //获取当前处理ID
        if (!StringUtils.IsEmpty(Request.Form["txtId"]))
        {
            lngId = int.Parse(Request.Form["txtId"]);
        }
        //获取业务类型
        if (!StringUtils.IsEmpty(Request.Form["sltBusinessType"]))
        {
            lngBusinesstypeId = int.Parse(Request.Form["sltBusinessType"]);
        }

        //获取客户选择的价格因素的值
        if (!StringUtils.IsEmpty(Request.Form["sltPriceFactor"]))
        {
            strPriceFactorList = Request.Form["sltPriceFactor"].Split(',');
            intPriceFactorLength = strPriceFactorList.Length;
        }

        //获取客户输入的价格
        //成本价格
        if (!StringUtils.IsEmpty(Request.Form["txtCostPrice"]))
        {
            decCostPrice = decimal.Parse(Request.Form["txtCostPrice"]);
        }
        //标准价格
        if (!StringUtils.IsEmpty(Request.Form["txtStandardPrice"]))
        {
            decStandardPrice = decimal.Parse(Request.Form["txtStandardPrice"]);
        }
        //活动价格
        if (!StringUtils.IsEmpty(Request.Form["txtActivityPrice"]))
        {
            decActivityPrice = decimal.Parse(Request.Form["txtActivityPrice"]);
        }
        //备用价格
        if (!StringUtils.IsEmpty(Request.Form["txtReservePrice"]))
        {
            decReservePrice = decimal.Parse(Request.Form["txtReservePrice"]);
        }

        //新价格

        if (!StringUtils.IsEmpty(Request.Form["txtNewPrice"]))
        {
            decNewPrice = decimal.Parse(Request.Form["txtNewPrice"]);
        }
        //折扣
        if (!StringUtils.IsEmpty(Request.Form["txtConcession"]))
        {
            lngConcession = decimal.Parse(Request.Form["txtConcession"]);
        }

        //设置页面类型
        model.BusinessTypePriceSetList[0].PriceType = intPageType;
        //设置当前处理ID
        model.BusinessTypePriceSetList[0].Id = lngId;
        //设置业务类型
        model.BusinessTypePriceSetList[0].BusinessType.Id = lngBusinesstypeId;
        //设置客户选择的价格因素的值
        for (int i = 0; i < intPriceFactorLength; i++)
        {
            model.BusinessTypePriceSetList[0].SetItem(i, long.Parse(strPriceFactorList[i]));
        }
        //设置客户输入的价格
        //成本价格
        model.BusinessTypePriceSetList[0].CostPrice = decCostPrice;
        //标准价格
        model.BusinessTypePriceSetList[0].StandardPrice = decStandardPrice;
        //活动价格
        model.BusinessTypePriceSetList[0].ActivityPrice = decActivityPrice;
        //备用价格
        model.BusinessTypePriceSetList[0].ReservePrice = decReservePrice;
        //新价格
        model.BusinessTypePriceSetList[0].NewPrice = decNewPrice;
        //折扣
        model.BusinessTypePriceSetList[0].PriceConcession = lngConcession;
    }
    #endregion

    #region 操作保存
    /// <summary>
    /// 方法名称: SavePriceSet
    /// 功能概要: 保存价格设置
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-27
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void SavePriceSet()
    {
        PrepareModel();
        try
        {
            businessTypePriceSetAction.Update(model);
        }
        catch (WorkflowException ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
        closeSelf = true;

    }
    #endregion
}
