using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Exception;

/// <summary>
/// 名    称: 
/// 功能概要: 批量添加门市价格
/// 作    者: 张晓林
/// 创建时间: 2009年6月23日10:07:55
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class system_pricemanager_batchAddPrice : System.Web.UI.Page
{
    #region//ClassMember
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

    #region//Page_Load
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

    #region //数据绑定
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
        ddlistBusinessType.SelectedValue = "-1";
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
            //throw ex;
        }

    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            //获取价格因素
            baseBusinessTypePriceSetAction.GetPriceFactor();
            List<LabelValue> strPriceFactor = new List<LabelValue>();
            foreach(PriceFactor pf in model.PriceFactor)
            {
                if (null!=Request.Form["sltPriceFactor"+pf.DisplayText])
                {
                    LabelValue lv = new LabelValue(Request.Form["sltPriceFactor" + pf.DisplayText], pf.DisplayText);
                    strPriceFactor.Add(lv);
                }
            }
            model.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            //成本价格
            model.BaseBusinessTypePriceSet.CostPrice = decimal.Parse(txtCostPrice.Text);
            //标准价格
            model.BaseBusinessTypePriceSet.StandardPrice = decimal.Parse(txtStandardPrice.Text);
            //活动价格
            model.BaseBusinessTypePriceSet.ActivityPrice = decimal.Parse(txtActivityPrice.Text);
            //备用价格
            model.BaseBusinessTypePriceSet.ReservePrice = decimal.Parse(txtReservePrice.Text);
            //业务类型
            model.BaseBusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
            model.BaseBusinessTypePriceSet.BusinessType.Id = long.Parse(ddlistBusinessType.SelectedValue);
            model.BaseBusinessTypePriceSet.StrPriceFactorList = strPriceFactor;
            baseBusinessTypePriceSetAction.AddBaseBusinessTypePrice();
            ddlistBusinessType.SelectedValue = "-1";
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion

    #region//业务类型改变处理程序 
    protected void ddlistBusinessType_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlistBusinessType.SelectedValue != Constants.SELECT_VALUE_NOT_SELECTED_KEY)
        {
            intAction = Constants.ACTION_SEARCH;
            ReInitData();
        }
    }
    #endregion
}
