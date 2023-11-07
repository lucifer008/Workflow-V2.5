using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

/// <summary>
///  名    称：addProcessContentAchievementRate
///  功能概要: 加工内容业绩比例操作
///  作    者: 张晓林
///  创建时间: 2009年6月2日
///  修正履历:
///  修正时间:
/// </summary>

public partial class orderBaseData_addProcessContentAchievementRate : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "加工内容业绩比例",strProcessContent;
    protected OrderBaseDataModel model;
    private OrderBaseDataAction orderBaseDataAction;
    public OrderBaseDataAction OrderBaseDataAction
    {
        set { orderBaseDataAction = value; }
    }
    private SearchOrderBaseDataAction searchOrderBaseDataAction;
    public SearchOrderBaseDataAction SearchOrderBaseDataAction
    {
        set { searchOrderBaseDataAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchOrderBaseDataAction.Model;
        searchOrderBaseDataAction.GetAllProcessContent();
        if (!IsPostBack)
        {
            BindEdmitData();
        }
        DeleteData();
        btnSave.Visible = false;
        //QueryNextPageData(1);
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BindEdmitData()
    {
        if (null != Request.QueryString["action"] && "edmit" == Request.QueryString["action"])
        {
            Response.Expires = -1;
            btnCancel.Visible = true;
            tr1.Visible = false;
            strTitle = "编辑加工内容业绩比例";
            txtAcievementRateValue.Value = Request.QueryString["AchievementRateValue"];
            txtMemo.Value = Request.QueryString["Memo"];
            hidProcessContentAchievementRateId.Value= Request.QueryString["ProcessContentAchievementRateId"];
            strProcessContent = Request.QueryString["ProcessContentId"];
        }
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData()
    {
        if ("delete" == Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.ProcessContentAchievementRate.Id = Convert.ToInt32(hidProcessContentAchievementRateId.Value);
            orderBaseDataAction.LogicDeleteProcessContentAchievementRate();
            hidProcessContentAchievementRateId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            orderBaseDataAction.Model.ProcessContentAchievementRate.ProcessContentId = Convert.ToInt32(Request.Form["processContent"]);
            orderBaseDataAction.Model.ProcessContentAchievementRate.Memo = txtMemo.Value;
            orderBaseDataAction.Model.ProcessContentAchievementRate.AchievementValue = Convert.ToDecimal(txtAcievementRateValue.Value);
            if ("" != hidProcessContentAchievementRateId.Value.Trim())
            {
                orderBaseDataAction.Model.ProcessContentAchievementRate.Id = Convert.ToInt32(hidProcessContentAchievementRateId.Value);
                orderBaseDataAction.UpdateProcessContentAchievementRate();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else
            {
                orderBaseDataAction.AddProcessContentAchievementRate();
                txtAcievementRateValue.Value = "";
                txtMemo.Value = "";
                QueryNextPageData(1);
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        model.ProcessContentAchievementRate.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.ProcessContentAchievementRate.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchOrderBaseDataAction.SearchProcessContentAchievementValue();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.RowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
