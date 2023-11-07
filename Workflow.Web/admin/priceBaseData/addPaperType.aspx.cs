using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;
/// <summary>
/// 名    称: addPaperType
/// 功能概要: 添加纸质
/// 作    者: 张晓林
/// 创建时间: 2009年5月6日9:28:44
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class priceBaseData_addPaperType : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "纸质";
    protected PriceBaseDataModel model;
    private PriceBaseDataModel Model 
    {
        set { model = value; }
        get {return model; }
    }

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
        if(!IsPostBack)
        {
            BingEdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.PaperType.Name = txtPaperTypeName.Value;
            if ("" != hidPaperTypeId.Value.Trim())//更新
            {
                priceBaseDataAction.Model.PaperType.Id = Convert.ToInt32(hidPaperTypeId.Value);
                priceBaseDataAction.UpdatePaperType();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else//插入 
            {
                priceBaseDataAction.AddPaperType();
                Response.Write("<script>window.navigate('addPaperType.aspx');</script>");
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmitData() 
    {

        if (null != Request.QueryString["actionTag"] && "edmit" == Request.QueryString["actionTag"])
        {
            txtPaperTypeName.Value = Request.QueryString["PaperTypeName"];
            hidPaperTypeId.Value = Request.QueryString["PaperTypeId"];
            strTitle = "编辑纸质";
            btnCancel.Visible = true;
            tr1.Visible = false;
        }
    }
    /// <summary>
    /// 删除数据 
    /// </summary>
    private void DeleteData() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            priceBaseDataAction.Model.PaperType.Id = Convert.ToInt32(hidPaperTypeId.Value);
            priceBaseDataAction.LogicDeletePaperType();
            hidPaperTypeId.Value = "";
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        searchPriceBaseDataAction.Model.PaperType.Id = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        searchPriceBaseDataAction.Model.PaperType.InsertUser = Convert.ToInt32(currentPageIndex-1);
        searchPriceBaseDataAction.SearchPaperType();

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
