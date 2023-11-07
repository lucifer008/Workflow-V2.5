using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

/// <summary>
/// 名    称: addPriceFactor
/// 功能概要: 添加价格因素操作
/// 作    者: 张晓林
/// 创建时间: 2009年5月6日13:29:31
/// </summary>

public partial class priceBaseData_addPriceFactor : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "价格因素",strIsDisplay,strIsUsed;
    protected string strMachineType;
    protected PriceBaseDataModel model;
    private SearchPriceBaseDataAction searchPriceBaseDataAction;
    public SearchPriceBaseDataAction SearchPriceBaseDataAction
    {
        set { searchPriceBaseDataAction = value; }
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
        Response.Expires = -1;
        model = searchPriceBaseDataAction.Model;
        if(!IsPostBack)
        {
            BingEdmitData();
        }
        DeletePriceFactor();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeletePriceFactor() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            priceBaseDataAction.Model.PriceFactor.Id = Convert.ToInt32(hidPriceFactorId.Value);
            priceBaseDataAction.LogicDeletePriceFactor();
            hidPriceFactorId.Value = "";
        }
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmitData() 
    {
        if (null != Request.QueryString["actionTag"] && "edmit" == Request.QueryString["actionTag"])
        {
            strTitle = "编辑价格因素";
            tr1.Visible = false;
            hidPriceFactorId.Value = Request.QueryString["PriceFactorId"];
            txtPriceFactorName.Value = Request.QueryString["Name"];
            txtDisplayText.Value = Request.QueryString["Text"];
            txtTargetTable.Value = Request.QueryString["Table"];
            txtTargetTextColumn.Value = Request.QueryString["TextColumn"];
            txtTargeValueColumn.Value = Request.QueryString["Column"];
            strIsDisplay = Request.QueryString["IsDisplay"];
            strIsUsed = Request.QueryString["Used"];
            btnNewPriceFactor.Visible = false;
            btnCancel.Visible = true;
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.PriceFactor.Name = txtPriceFactorName.Value;
            priceBaseDataAction.Model.PriceFactor.DisplayText = txtDisplayText.Value;
            priceBaseDataAction.Model.PriceFactor.IsDisplay = Request.Form["isDisplay"];
            priceBaseDataAction.Model.PriceFactor.Used = Request.Form["isUsed"];
            priceBaseDataAction.Model.PriceFactor.TargetTable = txtTargetTable.Value;
            priceBaseDataAction.Model.PriceFactor.TargetTextColumn = txtTargetTextColumn.Value;
            priceBaseDataAction.Model.PriceFactor.TargetValueColumn = txtTargeValueColumn.Value;
            if ("" != hidPriceFactorId.Value.Trim())//更新
            {
                priceBaseDataAction.Model.PriceFactor.Id = Convert.ToInt32(hidPriceFactorId.Value);
                priceBaseDataAction.UpdatePriceFactor();
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                priceBaseDataAction.AddPriceFactor();
                QueryNextPageData(1);
                Response.Write("<script>window.returnValue=true</script>");
            }
            txtPriceFactorName.Value = "";
            txtTargetTable.Value = "";
            txtDisplayText.Value = "";
            txtTargetTextColumn.Value = "";
            txtTargeValueColumn.Value = "";
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        searchPriceBaseDataAction.Model.PriceFactor.Id =Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        searchPriceBaseDataAction.Model.PriceFactor.InsertUser = Convert.ToInt32(currentPageIndex-1);
        searchPriceBaseDataAction.SearchPriceFactor();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.BusinessTypeRowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
