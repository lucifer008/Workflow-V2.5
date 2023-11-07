using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

/// <summary>
///名    称：addMemberCardLevel
///功能概要: 会员卡级别操作JS
///作    者: 张晓林
///创建时间: 2009年5月23日10:01:30
///修正履历:
///修正时间:
/// </summary>
public partial class orderBaseData_addMemberCardLevel : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "会员卡级别";
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
        Response.Expires = -1;
        if(!IsPostBack)
        {
            BingEdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData() 
    {
        if ("delete" == Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.MemberCardLevel.Id = Convert.ToInt32(hidMemberCardLevelId.Value);
            orderBaseDataAction.LogicDeleteMemberCardLevel();
            hidMemberCardLevelId.Value = "";
        }
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmitData() 
    {
        if(null!=Request.QueryString["action"] && "edmit"==Request.QueryString["action"])
        {
            btnCancel.Visible = true;
            tr1.Visible = false;
            txtMemberCardLevelName.Value = Request.QueryString["MemberCardLevelName"];
            hidMemberCardLevelId.Value = Request.QueryString["MemberCardLevelId"];
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            orderBaseDataAction.Model.MemberCardLevel.Name = txtMemberCardLevelName.Value;
            if ("" != hidMemberCardLevelId.Value.Trim())
            {
                orderBaseDataAction.Model.MemberCardLevel.Id = Convert.ToInt32(hidMemberCardLevelId.Value);
                orderBaseDataAction.UpdateMemberCardLevel();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else 
            {
                orderBaseDataAction.AddMemberCardLevel();
                txtMemberCardLevelName.Value = "";
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
        model.MemberCardLevel.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.MemberCardLevel.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchOrderBaseDataAction.SearchMemberCardLevel();

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
