using System;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Web;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
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
public partial class StandardPriceNext_Select : PageBase
{
    #region 类成员
    protected BusinessTypePriceSetModel model;
    protected BaseBusinessTypePriceSetModel basModel;
    ////当前处理阿业务类型
    protected long lngBusinessTypeId = 0;
    //当前价格处理的类型
    protected int intPageType = 0;
    //当前取得的价格类型名称
    protected string strPageTypeName = "";
    //当前的查询标题
    protected string strQueryTitle = "";
    //获得当前的TargetId
    protected long lngTargetId = 0;

    protected int intAction = Constants.ACTION_INIT;
    //要处理的ID列表
    protected string strIdList = "";
    protected bool closeSelf = false;
    private BusinessTypePriceSetAction businessTypePriceSetAction;
    public BusinessTypePriceSetAction BusinessTypePriceSetAction
    {
        set { businessTypePriceSetAction = value; }
    }
    private BaseBusinessTypePriceSetAction baseBusinessTypePriceSetAction;
    public BaseBusinessTypePriceSetAction BaseBusinessTypePriceSetAction
    {
        set { baseBusinessTypePriceSetAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = businessTypePriceSetAction.Model;
            basModel = baseBusinessTypePriceSetAction.Model;

            //获得页面动作
            if (Request.Form["txtAction"] != null)
            {
                intAction = int.Parse(Request.Form["txtAction"]);
            }
            //获得页面类型
            if (Request.Form["txtPageType"] != null)
            {
                intPageType = int.Parse(Request.Form["txtPageType"]);
            }

            //获得业务类型

            if (Request.Form["sltBusinessType"] != null)
            {
                lngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
            }

            //判断页面动作执行不同的处理
            //初始化显示
            if (intAction == Constants.ACTION_INIT)
            {
                //初时化
                InitData();
            }
            else if (intAction == Constants.ACTION_INSERT)
            {
                //保存价格
                SavePriceSet();
            }
            else if (intAction == Constants.ACTION_OTHER)
            {
                InitData();
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 数据准备
    /// <summary>
    /// 方法名称: InitData
    /// 功能概要: 初始化价格设置
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-30
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void InitData()
    {
        switch (intPageType)
        {
            case 1:
                strPageTypeName = "(会员卡)";
                strQueryTitle = "会员卡级别";
                break;
            case 2:
                strPageTypeName = "(行业价格)";
                strQueryTitle = "行业";
                break;
            case 3:
                strPageTypeName = "(特殊会员价格)";
                strQueryTitle = "会员卡卡号";
                break;
        }

        if (Request.Form["txtIdList"] != null)
        {
            strIdList = Request.Form["txtIdList"];
        }

        BaseBusinessTypePriceSetModel model=baseBusinessTypePriceSetAction.Model;
        model.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
        model.BaseBusinessTypePriceSet.IdList = strIdList;

        model.BaseBusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
        model.BaseBusinessTypePriceSet.BusinessType.Id = lngBusinessTypeId;

        businessTypePriceSetAction.InitDataSelectPriceNext(model,intPageType);
        
    }
    /// <summary>
    /// 方法名称: PrepareModel
    /// 功能概要: 准备数据
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-30
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void PrepareModel()
    {
        string[] strId = null;
        string[] strPriceFactorList = null;
        string[] strNewPriceList = null;
        string[] strPriceConcessionList = null;
        int intLength = 0;
        //获取要处理的ID
        if (Request.Form["txtIdList"] != null)
        {
            strId = Request.Form["txtIdList"].Split(',');
            intLength = strId.Length;
        }
        //获取TargetId
        if (Request.Form["sltTargetId"] != null)
        {
            lngTargetId = long.Parse(Request.Form["sltTargetId"]);
        }

        //获得页面类型
        if (Request.Form["txtPageType"] != null)
        {
            intPageType = int.Parse(Request.Form["txtPageType"]);
        }

        //获取业务类型ID
        if (Request.Form["txtBusinessTypeId"] != null)
        {
            lngBusinessTypeId = long.Parse(Request.Form["txtBusinessTypeId"]);
        }

        //获取新价格
        if (Request.Form["txtNewPrice"] != null)
        {
            strNewPriceList = Request.Form["txtNewPrice"].Split(',');
        }

        //获取折扣
        if (Request.Form["txtPriceConcession"] != null)
        {
            strPriceConcessionList = Request.Form["txtPriceConcession"].Split(',');
        }


        model.BusinessTypePriceSetList = new List<BusinessTypePriceSet>();
        StringBuilder sbTemp =new StringBuilder();
        for (int i = 0; i < intLength; i++)
        {   
            
            model.BusinessTypePriceSetList.Add(new BusinessTypePriceSet());
            //设置门市价格ID
            model.BusinessTypePriceSetList[i].BaseBusinessTypePriceSetId = long.Parse(strId[i]);
            model.BusinessTypePriceSetList[i].BusinessType = new Workflow.Da.Domain.BusinessType();
            model.BusinessTypePriceSetList[i].BusinessType.Id = lngBusinessTypeId;
            model.BusinessTypePriceSetList[i].PriceType = intPageType;
            model.BusinessTypePriceSetList[i].TargetId = lngTargetId;
            sbTemp.Remove(0, sbTemp.Length);
            sbTemp.AppendFormat("hddFactorValueId{0}", i);
            //获取当前行的值ID列表
            if (Request.Form[sbTemp.ToString()] != null)
            {
                strPriceFactorList = Request.Form[sbTemp.ToString()].Split(',');
            }
            for (int j = 0; j < strPriceFactorList.Length; j++)
            {
                model.BusinessTypePriceSetList[i].SetItem(j, long.Parse(strPriceFactorList[j]));
            }

            //设置新价格
            if (!StringUtils.IsEmpty(strNewPriceList[i]))
            {
                model.BusinessTypePriceSetList[i].NewPrice = Decimal.Parse(strNewPriceList[i]);
            }
            //设置折扣
            if (!StringUtils.IsEmpty(strPriceConcessionList[i]))
            {
                model.BusinessTypePriceSetList[i].PriceConcession = int.Parse(strPriceConcessionList[i]);
            }
        }
    }
    #endregion

    #region 操作保存
    private void SavePriceSet()
    {
        //准备数据
        PrepareModel();
        //保存价格
        businessTypePriceSetAction.Add(model);
        closeSelf = true;
    }
    #endregion
}
