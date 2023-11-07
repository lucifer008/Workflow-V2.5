using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

/// <summary>
/// 名    称: priceFactorDetail
/// 功能概要: 价格因素详情
/// 作    者: 张晓林
/// 创建时间: 2009年5月6日
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class priceBaseData_PriceFactorDetail : System.Web.UI.Page
{
    #region//ClassMember
    protected PriceBaseDataModel model;
    private SearchPriceBaseDataAction searchPriceBaseDataAction;
    public SearchPriceBaseDataAction SearchPriceBaseDataAction
    {
        set { searchPriceBaseDataAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchPriceBaseDataAction.Model;
        Response.Expires = -1;
        if(!IsPostBack)
        {
            searchPriceBaseDataAction.Model.PriceFactor.Id = Convert.ToInt32(Request.QueryString["PriceFactorId"]);
            searchPriceBaseDataAction.GetPriceFactorDetail();
        }
    }
    #endregion
}
