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
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;
/// <summary>
/// 名    称: AddPrice
/// 功能概要: 基础门市价格的增加
/// 作    者: 麻少华
/// 创建时间: 2007-9-21
/// 修正履历: 付强
/// 修正时间: 2009-1-17
/// </summary>
public partial class AddPrice : Workflow.Web.PageBase
{
    #region 类成员
    protected long sltBusinessType;
    protected bool closeSelf = false;
    protected BaseBusinessTypePriceSetModel model;
    protected int intAction = Constants.ACTION_INIT;
    private BaseBusinessTypePriceSetAction baseBusinessTypePriceSetAction;
    public BaseBusinessTypePriceSetAction BaseBusinessTypePriceSetAction
    {
        set { baseBusinessTypePriceSetAction = value; }
    }
    #endregion 
    
    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = baseBusinessTypePriceSetAction.Model;

        if (!this.IsPostBack)
        {
            sltBusinessType = -1;
            if (Request.QueryString["sltBusinessType"] != null)
            {
                long ln;
                long.TryParse(Request.QueryString["sltBusinessType"], out ln);
                sltBusinessType = ln;

            }

            if (sltBusinessType <= 0)
                sltBusinessType = -1;

            InitData(sltBusinessType);

        }
    }
    #endregion

    #region 数据绑定
    /// <summary>
    /// 方法名称: InitData
    /// 功能概要: 初始化需要数据
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-21
    /// 修正履历: 
    ///             2008-11-07  增加前允许选择业务类型, 减少客户选择次数.
    /// 修正时间: 
    /// </summary>
    private void InitData(long SelectedBusinessTypeID)
    {

        baseBusinessTypePriceSetAction.InitData();
        //绑定数据
        ddlistBusinessType.DataSource = model.BusinessTypeList;
        ddlistBusinessType.DataTextField = "Name";
        ddlistBusinessType.DataValueField = "Id";
        ddlistBusinessType.DataBind();

        if (SelectedBusinessTypeID >= 0)
        {
            for (int i = 0; i < ddlistBusinessType.Items.Count; i++)
            {
                if (ddlistBusinessType.Items[i].Value == SelectedBusinessTypeID.ToString())
                {
                    ddlistBusinessType.SelectedIndex = i;
                    intAction = Constants.ACTION_SEARCH;
                    break;
                }
            }

            model.Factorrelation = new FactorRelation();
            model.Factorrelation.BusinessTypeId = long.Parse(ddlistBusinessType.SelectedValue);
            baseBusinessTypePriceSetAction.ReInitData(model);

        }
        else
        {
            //如果增加之前没有选择任何业务类型,多加一项 text="请选择",value=-1
            ListItem item = new ListItem(Constants.SELECT_VALUE_NOT_SELECTED_TEXT, Constants.SELECT_VALUE_NOT_SELECTED_KEY);
            ddlistBusinessType.Items.Insert(0, item);
            ddlistBusinessType.SelectedIndex = 0;
        }

        //MakeSelectDefaultItem(ddlistBusinessType);

    }

    /// <summary>
    /// 方法名称: ReInitData
    /// 功能概要: 重新加载业务类型下的价格因素
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-24
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void ReInitData()
    {
        try
        {
            model.Factorrelation = new FactorRelation();
            model.Factorrelation.BusinessTypeId = long.Parse(ddlistBusinessType.SelectedValue);

            baseBusinessTypePriceSetAction.ReInitData(model);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    /// <summary>
    /// 方法名称: PrepareModel
    /// 功能概要: 准备数据
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-21
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void PrepareModel()
    {
        try
        {
            model.BaseBusinessTypePriceSetList = new List<BaseBusinessTypePriceSet>();
            BaseBusinessTypePriceSet baseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            model.BaseBusinessTypePriceSetList.Add(baseBusinessTypePriceSet);


            string[] strPriceFactorList = null;
            int intPriceFactorLength = 0;
            if (Request.Form["sltPriceFactor"] != null)
            {
                strPriceFactorList = Request.Form["sltPriceFactor"].Split(',');
                intPriceFactorLength = strPriceFactorList.Length;
            }
            for (int i = 0; i < intPriceFactorLength; i++)
            {
                model.BaseBusinessTypePriceSetList[0].SetItem(i, long.Parse(strPriceFactorList[i]));
            }


            //成本价格
            model.BaseBusinessTypePriceSetList[0].CostPrice = decimal.Parse(txtCostPrice.Text);
            //标准价格
            model.BaseBusinessTypePriceSetList[0].StandardPrice = decimal.Parse(txtStandardPrice.Text);
            //活动价格
            model.BaseBusinessTypePriceSetList[0].ActivityPrice = decimal.Parse(txtActivityPrice.Text);
            //备用价格
            model.BaseBusinessTypePriceSetList[0].ReservePrice = decimal.Parse(txtReservePrice.Text);
            //业务类型
            model.BaseBusinessTypePriceSetList[0].BusinessType = new Workflow.Da.Domain.BusinessType();
            model.BaseBusinessTypePriceSetList[0].BusinessType.Id = long.Parse(ddlistBusinessType.SelectedValue);

        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    #endregion

    #region 页面控件事件
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        intAction = Constants.ACTION_INSERT;
        PrepareModel();
        try
        {
            baseBusinessTypePriceSetAction.Add(model);
        }
        catch (WorkflowException ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
        closeSelf = true;
    }
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        closeSelf = true;
    }
    protected void ddlistBusinessType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlistBusinessType.SelectedValue == Constants.SELECT_VALUE_NOT_SELECTED_KEY)
        {
            intAction = Workflow.Support.Constants.ACTION_INIT;
            InitData(-1);
        }
        else
        {
            intAction = Constants.ACTION_SEARCH;
            ReInitData();
        }
    }
    #endregion
}
