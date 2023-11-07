using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

/// <summary>
///  名    称：addCustomerLevel
///  功能概要: 客户级别操作
///  作    者: 张晓林
///  创建时间: 2009年5月19日9:21:00
///  修正履历:
///  修正时间:
/// </summary>
public partial class orderBaseData_addCustomerLevel : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "客户级别";
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
        
        if(!IsPostBack)
        {
            BingEdmit(); 
        }
        DeleteData();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmit() 
    {
        if(null!=Request.QueryString["action"] && "edmit"==Request.QueryString["action"])
        {
            txtCustomerLevelName.Value = Request.QueryString["CustomerLevelName"];
            hidCutomerLevelId.Value = Request.QueryString["CustomerLevelId"];
            tr1.Visible = false;
            btnCancel.Visible = true;
            strTitle = "编辑客户级别";
        }
    }

    /// <summary>
    /// 逻辑删除数据
    /// </summary>
    private void DeleteData() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.CustomerLevel.Id = Convert.ToInt32(hidCutomerLevelId.Value);
            orderBaseDataAction.LogicDeleteCustomerLevel();
            hidCutomerLevelId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            model.CustomerLevel.Name = txtCustomerLevelName.Value;
            orderBaseDataAction.Model = model;
            if ("" != hidCutomerLevelId.Value.Trim())//更新
            {
                model.CustomerLevel.Id = Convert.ToInt32(hidCutomerLevelId.Value);
                orderBaseDataAction.UpdateCustomerLevel();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                orderBaseDataAction.AddCustomerLevel();
                QueryNextPageData(1);
                txtCustomerLevelName.Value = "";
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
        model.CustomerLevel.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.CustomerLevel.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchOrderBaseDataAction.SearchCustomerLevel();

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
