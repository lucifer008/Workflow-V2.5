using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

/// <summary>
///  名    称：addTrashReason
///  功能概要: 废张原因操作
///  作    者: 张晓林
///  创建时间: 2009年6月2日9:59:10
///  修正履历:
///  修正时间:
/// </summary>

public partial class orderBaseData_addTrashReason : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "废张原因";
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
        if (!IsPostBack)
        {
            BindEdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
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
            strTitle = "编辑废张原因";
            txtTrashReasonName.Value= Request.QueryString["TrashReasonName"];
            txtMemo.Value = Request.QueryString["Memo"];
            hidTrashReasonId.Value= Request.QueryString["TrashReasonId"];
        }
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData()
    {
        if ("delete" == Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.TrashReason.Id = Convert.ToInt32(hidTrashReasonId.Value);
            orderBaseDataAction.LogicDeleteTrashReason();
            hidTrashReasonId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            orderBaseDataAction.Model.TrashReason.Name =txtTrashReasonName.Value;
            orderBaseDataAction.Model.TrashReason.Memo = txtMemo.Value;
            if ("" != hidTrashReasonId.Value.Trim())
            {
                orderBaseDataAction.Model.TrashReason.Id = Convert.ToInt32(hidTrashReasonId.Value);
                orderBaseDataAction.UpdateTrashReason();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else
            {
                orderBaseDataAction.AddTrashReason();
                txtTrashReasonName.Value = "";
                txtMemo.Value = "";
                QueryNextPageData(1);
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
        model.TrashReason.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.TrashReason.UpdateUser = Convert.ToInt32(currentPageIndex - 1);
        searchOrderBaseDataAction.SearchTrashReason();

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
