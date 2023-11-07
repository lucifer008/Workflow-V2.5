using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

/// <summary>
/// 名    称: addPaperSecifiation
/// 功能概要: 添加纸型
/// 作    者: 张晓林
/// 创建时间: 2009年5月5日15:06:12
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class priceBaseData_addPaperSpecifiation : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "纸型";
    protected PriceBaseDataModel model;
    private PriceBaseDataAction priceBaseDataAction;
    public PriceBaseDataAction PriceBaseDataAction 
    {
        set { priceBaseDataAction = value; }
    }

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
        btnCancel.Visible= false;
        Response.Expires = -1;
        if(!IsPostBack)
        {
            BingEdmitData();
        }
        DeleteSpecification(); 
        QueryNextData(1);
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmitData() 
    {
        if (null != Request.QueryString["actionTag"] && "edmit" == Request.QueryString["actionTag"])
        {
            tr1.Visible = false;
            btnCancel.Visible = true;
            strTitle = "编辑纸型";
            hidPaperId.Value = Request.QueryString["PaperSpecifiationId"];
            txtPaperSpecificationName.Value = Request.QueryString["PaperSpecifiationName"];
        }
    }

    /// <summary>
    /// 删除纸型
    /// </summary>
    private void DeleteSpecification() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            priceBaseDataAction.Model.PaperSecification.Id = Convert.ToInt32(hidPaperId.Value);
            priceBaseDataAction.LogicDeleteSpecification();
            hidPaperId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.PaperSecification.Name = txtPaperSpecificationName.Value;
            if ("" != hidPaperId.Value)//更新
            {
                priceBaseDataAction.Model.PaperSecification.Id = Convert.ToInt32(hidPaperId.Value);
                priceBaseDataAction.UpdateSpecification();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                priceBaseDataAction.AddPaperSpecification();
                Response.Write("<script>window.navigate('addPaperSpecifiation.aspx');</script>");
            }
           
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//分页处理程序

    private void QueryNextData(int currentPageIndex) 
    {
        searchPriceBaseDataAction.Model.PaperSecification.Id = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        searchPriceBaseDataAction.Model.PaperSecification.InsertUser = Convert.ToInt32(currentPageIndex-1);
        searchPriceBaseDataAction.SearchPaperSecification();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.BusinessTypeRowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextData(e.NewPageIndex);
    }
    #endregion
}
