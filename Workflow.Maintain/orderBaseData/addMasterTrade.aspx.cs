using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

/// <summary>
///  名    称：addMasterTrade
///  功能概要: 客户主行业操作
///  作    者: 张晓林
///  创建时间: 2009年5月20日9:32:32
///  修正履历:
///  修正时间:
/// </summary>
public partial class orderBaseData_addMasterTrade : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "客户行业";
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

    #region//Page_load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchOrderBaseDataAction.Model;
        if(!IsPostBack)
        {
            EdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void EdmitData() 
    {
        if(null!=Request.QueryString["action"] && "edmit"==Request.QueryString["action"])
        {
            Response.Expires = -1;
            btnCancel.Visible = true;
            tr1.Visible = false;
            btnNewSceondaryTrade.Visible = false;
            strTitle = "编辑客户主行业";
            txtMasterTradeName.Value = Request.QueryString["MasterTradeName"];
            hidMasterTradelId.Value = Request.QueryString["MasterTradeId"];
        }
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData() 
    {
        if ("delete" == Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.MasterTrade.Id = Convert.ToInt32(hidMasterTradelId.Value);
            orderBaseDataAction.LogicDeleteMasterTrade();
            hidMasterTradelId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            orderBaseDataAction.Model.MasterTrade.Name = txtMasterTradeName.Value;
            if ("" != hidMasterTradelId.Value.Trim())//更新
            {
                orderBaseDataAction.Model.MasterTrade.Id = Convert.ToInt32(hidMasterTradelId.Value);
                orderBaseDataAction.UpdateMasterTrade();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                orderBaseDataAction.AddMasterTrade();
                QueryNextPageData(1);
                txtMasterTradeName.Value = "";
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
        model.MasterTrade.InsertUser= Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.MasterTrade.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchOrderBaseDataAction.SearchMasterTrade();

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
