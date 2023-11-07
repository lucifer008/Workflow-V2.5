using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;
/// <summary>
/// 名    称: addBusinessType
/// 功能概要: 新增业务类型
/// 作    者: 张晓林
/// 创建时间: 2009年4月28日14:39:40
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class priceBaseData_addBusinessType : System.Web.UI.Page
{
    #region //ClassMember

    protected string businessTypeName,businessTypeIsNotInWath;
    protected string strTitle = "业务类型";
    protected PriceBaseDataModel model;
    private PriceBaseDataModel Model 
    {
        set { model = value; }
        get { return model; }
    }

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
        get { return priceBaseDataAction; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchPriceBaseDataAction.Model;
        Response.Expires = -1;
        //删除
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            DeleteBusinessType();
        }

        //编辑
        if (null != Request.QueryString["actionTag"] && "edmit" == Request.QueryString["actionTag"])
        {
            strTitle = "编辑业务类型";
            EdmitBusinessType();
        }
        QueryNextPageData(1);
    }
    #endregion

    #region //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.BusinessType.Name = Request.Form["businessTypeName"];
            priceBaseDataAction.Model.BusinessType.NeedRecordMachine = Request.Form["isNotInWatch"];
            if ("" != hidBusinessTypeId.Value)//更新
            {
                priceBaseDataAction.Model.BusinessType.Id = Convert.ToInt32(hidBusinessTypeId.Value);
                priceBaseDataAction.UpdateBusinessType();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                priceBaseDataAction.AddBusinessType();
            }
            QueryNextPageData(1);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //Edmit
    private void EdmitBusinessType() 
    {
        businessTypeName = Request.QueryString["BusinessName"];
        businessTypeIsNotInWath = Request.QueryString["BusinessIsNoInW"];
        hidBusinessTypeId.Value = Request.QueryString["BusinessTypeId"];
    }
    #endregion

    #region //Delete
    private void DeleteBusinessType() 
    {
        long businessTypeId = Convert.ToInt32(hidBusinessTypeId.Value);
        priceBaseDataAction.Model.BusinessType.Id = businessTypeId;
        priceBaseDataAction.DeleteBusinessType();
        hidBusinessTypeId.Value = "";
    }
    #endregion

    #region //分页处理程序
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
