using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;
/// <summary>
///  名    称：addCustomerType
///  功能概要: 客户类型操作
///  作    者: 张晓林
///  创建时间: 2009年5月19日12:08:03
///  修正履历:
///  修正时间:
/// </summary>

public partial class orderBaseData_addCustomerType : System.Web.UI.Page
{
     #region//ClassMember
    protected string strTitle = "客户类型";
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
        Response.Expires = -1;
        if (null != Request.QueryString["action"] && "edmit" == Request.QueryString["action"])
        {
            txtCustomerTypeName.Value = Request.QueryString["CustomerTypeName"];
            hidCustomerTypelId.Value = Request.QueryString["CustomerTypeId"];
            tr1.Visible = false;
            btnCancel.Visible = true;
            strTitle = "编辑客户类型";
        }
    }

    /// <summary>
    /// 逻辑删除数据
    /// </summary>
    private void DeleteData()
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.CustomerType.Id = Convert.ToInt32(hidCustomerTypelId.Value);
            orderBaseDataAction.LogicDeleteCustomerType();
            hidCustomerTypelId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            model.CustomerType.Name = txtCustomerTypeName.Value;
            orderBaseDataAction.Model = model;
            if ("" != hidCustomerTypelId.Value.Trim())//更新
            {
                orderBaseDataAction.Model.CustomerType.Id = Convert.ToInt32(hidCustomerTypelId.Value);
                orderBaseDataAction.UpdateCustomerTypel();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                orderBaseDataAction.AddCustomerType();
                QueryNextPageData(1);
                txtCustomerTypeName.Value = "";
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
        model.CustomerType.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.CustomerType.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchOrderBaseDataAction.SearchCustomerType();

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
