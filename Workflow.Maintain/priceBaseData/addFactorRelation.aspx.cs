using System;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

/// <summary>
/// 名    称: addFactorRelation
/// 功能概要：价格因素之间的依赖关系操作
/// 作    者: 张晓林
/// 创建时间: 2009年5月14日9:39:03
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class priceBaseData_addFactorRelation : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "价格因素之间的关系依赖";
    protected string businessTypeId, priceFactorId,passivePriceFactorId;
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

    #region//Page_load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchPriceBaseDataAction.Model;
        btnCancel.Visible = false;
        Response.Expires = -1;
        if(!IsPostBack)
        {
            EdmitData();
        }
        searchPriceBaseDataAction.GetAllBusinessTypeList();
        searchPriceBaseDataAction.GetAllPriceFactor();
        DeleteData();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 删除因素之间依赖
    /// </summary>
    private void DeleteData() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            priceBaseDataAction.Model.FactorRelation.Id = Convert.ToInt32(hidFactorRelationId.Value);
            priceBaseDataAction.LogicDeleteFactorRelation();
            hidFactorRelationId.Value = "";
        }
    }

    /// <summary>
    /// 编辑因素之间的依赖关系
    /// </summary>
    private void EdmitData() 
    {
        if(null!=Request.QueryString["actionTag1"] && "edmit"==Request.QueryString["actionTag1"])
        {
            btnCancel.Visible = true;
            tr1.Visible = false;
            strTitle = "编辑因素之间的依赖";
            businessTypeId = Request.QueryString["BusinessTypeId"];
            priceFactorId = Request.QueryString["PriceFactorId"];
            passivePriceFactorId = Request.QueryString["PriceFactorId2"];
            hidFactorRelationId.Value = Request.QueryString["FactorRelationId"];
            Memo.Text = Request.QueryString["Memo"] ;
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.FactorRelation.BusinessTypeId = Convert.ToInt32(Request.Form["businessType"]);
            priceBaseDataAction.Model.FactorRelation.PriceFactorId = Convert.ToInt32(Request.Form["pricesFactor"]);
            priceBaseDataAction.Model.PriceFactorIds = Request.Form["cbPriceFactor"].Split(',');
            priceBaseDataAction.Model.FactorRelation.Memo = Memo.Text;
            if ("" != hidFactorRelationId.Value)
            {
                priceBaseDataAction.Model.FactorRelation.Id = Convert.ToInt32(hidFactorRelationId.Value);
                priceBaseDataAction.UpdateFactorRelation();
                hidFactorRelationId.Value = "";
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else 
            {
                priceBaseDataAction.AddFactorRelation();
                Memo.Text = "";
                QueryNextPageData(1);
            }
            
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        searchPriceBaseDataAction.Model.FactorRelation.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        searchPriceBaseDataAction.Model.FactorRelation.UpdateUser = Convert.ToInt32(currentPageIndex - 1);
        searchPriceBaseDataAction.SearchFactorRelation();

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
