using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

/// <summary>
/// 名    称: addFactorValue
/// 功能概要: 添加价格因素值操作
/// 作    者: 张晓林
/// 创建时间: 2009年5月6日13:29:31
/// </summary>
public partial class priceBaseData_addFactorValue : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "价格因素值";
    protected long priceFactorId; 

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
        model = searchPriceBaseDataAction.Model;
        btnCancel.Visible = false;
        searchPriceBaseDataAction.GetAllPriceFactor();
        if(!IsPostBack)
        {
            BingEdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            priceBaseDataAction.Model.FactorValue.Id = Convert.ToInt32(hidFactorValueId.Value);
            priceBaseDataAction.LogicDeleteFactorValue();
            hidFactorValueId.Value = "";
        }
    }
    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmitData() 
    {
        if (null != Request.QueryString["actionTag"] && "edmit" == Request.QueryString["actionTag"])
        {
            Response.Expires = -1;
            strTitle = "编辑价格因素值";
            txtFactorValue.Value = Request.QueryString["FactorText"];
            btnCancel.Visible = true;
            tr1.Visible = false;
            priceFactorId = Convert.ToInt32(Request.QueryString["PriceFactorId"]);
            hidFactorValueId.Value = Request.QueryString["FactorValueId"];
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        priceBaseDataAction.Model.FactorValue.Text = txtFactorValue.Value;
        priceBaseDataAction.Model.FactorValue.PriceFactorId = Convert.ToInt32(Request.Form["priceFactor"]);
        if ("" != hidFactorValueId.Value.Trim())//更新
        {
            priceBaseDataAction.Model.FactorValue.Id = Convert.ToInt32(hidFactorValueId.Value);
            priceBaseDataAction.UpdateFactorValue();
            Response.Write("<script>window.returnValue=true</script>");
            Response.Write("<script>window.close();</script>");
        }
        else//插入 
        {
            priceBaseDataAction.AddFactorValue();
            QueryNextPageData(1);
            //Response.Write("<script>window.navigate('addFactorValue.aspx');</script>");
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        searchPriceBaseDataAction.Model.FactorValue.Id = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        searchPriceBaseDataAction.Model.FactorValue.InsertUser = Convert.ToInt32(currentPageIndex-1);
        searchPriceBaseDataAction.SearchFactorValue();

        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.RecordCount = (int)model.BusinessTypeRowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
