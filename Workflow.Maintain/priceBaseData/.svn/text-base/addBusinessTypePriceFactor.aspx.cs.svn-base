using System;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

/// <summary>
/// 名    称: addBusinessTypePriceFactor
/// 功能概要: 管理业务类型包含的价格因素操作
/// 作    者: 张晓林
/// 创建时间: 2009年5月13日9:55:38
/// </summary>
public partial class priceBaseData_addBusinessTypePriceFactor : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "业务类型包含的价格因素";
    protected string businessTypeId, priceFactorIds;
    protected PriceBaseDataModel model;
    private SearchPriceBaseDataAction searchPriceBaseDataAction;
    public SearchPriceBaseDataAction SearchPriceBaseDataAction
    {
        set { searchPriceBaseDataAction = value; }
        get { return searchPriceBaseDataAction; }
    }
    private PriceBaseDataAction priceBaseDataAction;
    public PriceBaseDataAction PriceBaseDataAction
    {
        set { priceBaseDataAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchPriceBaseDataAction.Model;
        btnCancel.Visible = false;
        searchPriceBaseDataAction.GetAllPriceFactor();
        searchPriceBaseDataAction.GetAllBusinessTypeList();
        if (!IsPostBack)
        {
            Response.Expires = -1;
            EdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 删除业务类型包含的价格因素
    /// </summary>
    private void DeleteData() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"]) 
        {
            priceBaseDataAction.Model.BusinessTypePriceFactor.BusinessTypeId = Convert.ToInt32(hidBusinessTypeId.Value);
            priceBaseDataAction.DeleteBusinessTypePriceFactorByBusinessTypeId();
        }
    }

    /// <summary>
    ///编辑业务类型包含的价格因素 
    /// </summary>
    private void EdmitData() 
    {
        if (null != Request.QueryString["actionTag1"] && "edmit" == Request.QueryString["actionTag1"])
        {
            businessTypeId = Request.QueryString["BusinessTypeId"];
            searchPriceBaseDataAction.SearchBusinessTypePriceFactor(Convert.ToInt32(businessTypeId));
            int index = 0;
            foreach(BusinessTypePriceFactor bt in model.BusinessTypePriceFactorList)
            {
                if (0 == index)
                {
                    priceFactorIds += bt.PriceFactorId;
                }
                else 
                {
                    priceFactorIds += "," + bt.PriceFactorId;
                }
                index++;
            }
            tr1.Visible = false;
            btnCancel.Visible = true;
            strTitle = "编辑业务类型包含的价格因素";
            hidBusinessTypeId.Value = "edmit";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.BusinessTypePriceFactor.BusinessTypeId = Convert.ToInt32(Request.Form["businessType"]);
            priceBaseDataAction.Model.PriceFactorIds= Request.Form["cbPriceFactor"].Split(',');
            if ("edmit" == hidBusinessTypeId.Value)
            {
                priceBaseDataAction.UpdateBusinessTypePriceFactor();
                hidBusinessTypeId.Value = "";
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else
            {
                priceBaseDataAction.AddBusinessTypePriceFactor();
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        searchPriceBaseDataAction.Model.BusinessType.Name = Convert.ToString(currentPageIndex - 1);
        searchPriceBaseDataAction.Model.BusinessType.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        searchPriceBaseDataAction.GetBusniessTypeLists();

        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.BusinessTypeRowCount;
        AspNetPager1.CurrentPageIndex = currentPageIndex - 1;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
