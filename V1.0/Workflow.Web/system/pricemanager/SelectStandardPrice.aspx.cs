using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Exception;
/// <summary>
/// 名    称: SelectStandardPrice
/// 功能概要: 选择标准的门市价格
/// 作    者: 麻少华
/// 创建时间: 2007-9-27
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
/// </summary>
public partial class SelectOnePrice : Workflow.Web.PageBase
{

    #region 类成员
    protected BusinessTypePriceSetModel model;
    ////当前处理的ID
    //protected long lngCurId = 0;
    //当前价格处理的类型
    protected int intPageType = 0;
    //当前取得的页面类型名称
    protected string strPageTypeName = "";
    protected int intAction = Constants.ACTION_INIT;
    //protected bool closeSelf = false;
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
        if (Request.Form["txtAction"] != null)
        {
            intAction = int.Parse(Request.Form["txtAction"]);
        }
        //获得页面类型
        if (Request.QueryString["PageType"] != null)
        {
            intPageType = int.Parse(Request.QueryString["PageType"]);
        }

        //判断页面动作执行不同的处理
        //初始化显示
        if (intAction == Constants.ACTION_INIT)
        {
            //初时化
            InitData();
        }
        else if (intAction == Constants.ACTION_OTHER)
        {   
            //跳转到下一个页面
            Server.Transfer("SelectStandardPriceNext.aspx");
        }
    }
    #endregion 

    #region 准备数据

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
        switch (intPageType)
        {
            case 1:
                strPageTypeName = "(会员卡)";
                break;
            case 2:
                strPageTypeName = "(行业价格)";
                break;
            case 3:
                strPageTypeName = "(特殊会员价格)";
                break;
        }
        businessTypePriceSetAction.InitDataSelectPrice();
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
        //model.BusinessTypePriceSetList = new List<BusinessTypePriceSet>();
        //BusinessTypePriceSet businessTypePriceSet = new BusinessTypePriceSet();
        //model.BusinessTypePriceSetList.Add(businessTypePriceSet);
        //model.BusinessTypePriceSetList[0].BusinessType = new Workflow.Da.Domain.BusinessType();

        //string[] strPriceFactorList = null;
        //int intPriceFactorLength = 0;
        //int intPageType = 0;
        //long lngId = 0;
        //long lngBusinesstypeId = 0;
        //decimal decCostPrice = 0, decStandardPrice = 0, decActivityPrice = 0, decReservePrice = 0, decNewPrice = 0;
        //long lngDiscount = 0;
        //string strMemo = "";

        ////获取页面类型
        //if (Request.Form["txtPageType"] != null)
        //{
        //    intPageType = int.Parse(Request.Form["txtPageType"]);
        //}
        ////获取当前处理ID
        //if (Request.Form["txtId"] != null)
        //{
        //    lngId = int.Parse(Request.Form["txtId"]);
        //}
        ////获取业务类型
        //if (Request.Form["sltBusinessType"] != null)
        //{
        //    lngBusinesstypeId = int.Parse(Request.Form["sltBusinessType"]);
        //}

        ////获取客户选择的价格因素的值
        //if (Request.Form["sltPriceFactor"] != null)
        //{
        //    strPriceFactorList = Request.Form["sltPriceFactor"].Split(',');
        //    intPriceFactorLength = strPriceFactorList.Length;
        //}

        ////获取客户输入的价格
        ////成本价格
        //if (Request.Form["txtCostPrice"] != null)
        //{
        //    decCostPrice = decimal.Parse(Request.Form["txtCostPrice"]);
        //}
        ////标准价格
        //if (Request.Form["txtStandardPrice"] != null)
        //{
        //    decStandardPrice = decimal.Parse(Request.Form["txtStandardPrice"]);
        //}
        ////活动价格
        //if (Request.Form["txtActivityPrice"] != null)
        //{
        //    decActivityPrice = decimal.Parse(Request.Form["txtActivityPrice"]);
        //}
        ////备用价格
        //if (Request.Form["txtReservePrice"] != null)
        //{
        //    decReservePrice = decimal.Parse(Request.Form["txtReservePrice"]);
        //}
        //decNewPrice = 0;
        //lngDiscount = 0;
        //strMemo = "我的暂时测试";

        //////新价格
        ////if (Request.Form["txtNewPrice"] != null)
        ////{
        ////    decNewPrice = long.Parse(Request.Form["txtNewPrice"]);
        ////}
        //////折扣
        ////if (Request.Form["txtDiscount"] != null)
        ////{
        ////    lngDiscount = long.Parse(Request.Form["txtDiscount"]);
        ////}
        //////备注
        ////if (Request.Form["txtMemo"] != null)
        ////{
        ////    strMemo = Request.Form["txtMemo"];
        ////}

        ////设置页面类型
        //model.BusinessTypePriceSetList[0].PriceType = intPageType;
        ////设置当前处理ID
        //model.BusinessTypePriceSetList[0].Id = lngId;
        ////设置业务类型
        //model.BusinessTypePriceSetList[0].BusinessType.Id = lngBusinesstypeId;
        ////设置客户选择的价格因素的值
        //for (int i = 0; i < intPriceFactorLength; i++)
        //{
        //    model.BusinessTypePriceSetList[0].SetItem(i, long.Parse(strPriceFactorList[i]));
        //}
        ////设置客户输入的价格
        ////成本价格
        //model.BusinessTypePriceSetList[0].CostPrice = decCostPrice;
        ////标准价格
        //model.BusinessTypePriceSetList[0].StandardPrice = decStandardPrice;
        ////活动价格
        //model.BusinessTypePriceSetList[0].ActivityPrice = decActivityPrice;
        ////备用价格
        //model.BusinessTypePriceSetList[0].ReservePrice = decReservePrice;
    }
    #endregion
}
