using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

/// <summary>
/// 名    称: addProcessContent
/// 功能概要: 维护加工内容
/// 作    者: 张晓林
/// 创建时间: 2009年4月29日16:55:27
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class priceBaseData_addProcessContent : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "加工内容";

    protected string processContentName, colorType,strBusinessTypeId;
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

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model=searchPriceBaseDataAction.Model;
        Response.Expires = -1;
        searchPriceBaseDataAction.GetAllBusinessTypeList();
        if (!IsPostBack)
        {
            BingEdmitData();
        }
        DeleteLogicProcessContent();
        QueryNextPageData(1);
    }
    #endregion

    #region //保存
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.ProcessContent.Name = Request.Form["processContentName"];
            priceBaseDataAction.Model.ProcessContent.ColorType = Request.Form["reparttionColor"];
            priceBaseDataAction.Model.ProcessContent.BusinessTypeId = Convert.ToInt32(Request.Form["businessType"]);

           
            if ("" != hidProcessContentId.Value)//更新
            {
                priceBaseDataAction.Model.ProcessContentAchievementRate.ProcessContentId = Convert.ToInt32(hidProcessContentId.Value);
                priceBaseDataAction.Model.ProcessContentAchievementRate.AchievementValue = Convert.ToDecimal(txtAcievementRateValue.Value);
                priceBaseDataAction.Model.ProcessContentAchievementRate.Memo = txtMemo.Value;

                priceBaseDataAction.Model.ProcessContent.Id = Convert.ToInt32(hidProcessContentId.Value);
                priceBaseDataAction.UpdateProcessContent();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                priceBaseDataAction.Model.ProcessContentAchievementRate.AchievementValue = 1;
                priceBaseDataAction.Model.ProcessContentAchievementRate.Memo = "";
                priceBaseDataAction.AddProcessContent();
            }
            QueryNextPageData(1);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion

    #region //Delete
    private void DeleteLogicProcessContent() 
    {
        //删除
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
           priceBaseDataAction.Model.ProcessContent.Id = Convert.ToInt32(hidProcessContentId.Value);
           priceBaseDataAction.DeleteProcessContent();
           hidProcessContentId.Value = "";
        }
    }
    #endregion

    #region //BingEdmitData()
    private void BingEdmitData()
    {
        //编辑
        if (null != Request.QueryString["actionTag1"] && "edmit" == Request.QueryString["actionTag1"])
        {
            strTitle = "编辑加工内容";
            tr2.Visible = true;
            strBusinessTypeId = Request.QueryString["BusinessTypeId"];
            hidProcessContentId.Value =Request.QueryString["ProcessContentId"];
            colorType = Request.QueryString["ColorType"];
            processContentName = Request.QueryString["ProcessConName"];
            //获取加工内容的业绩比例
            priceBaseDataAction.Model.ProcessContent.Id = Convert.ToInt32(hidProcessContentId.Value);
            priceBaseDataAction.GetProcessContentAchievementRate();
            txtAcievementRateValue.Value = priceBaseDataAction.Model.ProcessContentAchievementRate.AchievementValue.ToString();
            txtMemo.Value = priceBaseDataAction.Model.ProcessContentAchievementRate.Memo;
        }
    }
    #endregion

    #region //分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            searchPriceBaseDataAction.Model.ProcessContent.Id = currentPageIndex - 1;//页索引
            searchPriceBaseDataAction.Model.ProcessContent.InsertUser = Constants.ROW_COUNT_FOR_PAGER;//每页显示行数
            searchPriceBaseDataAction.GetProcessContentList();

            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = (int)model.BusinessTypeRowCount;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
