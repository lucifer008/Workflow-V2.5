using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

/// <summary>
///  名    称：addSecondaryTrade
///  功能概要: 客户子行业操作
///  作    者: 张晓林
///  创建时间: 2009年5月20日9:32:32
///  修正履历:
///  修正时间:
/// </summary>
public partial class orderBaseData_addSecondaryTrade : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "客户子行业",masterTradeId;
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
        searchOrderBaseDataAction.GetAllMasterTrade();
        Response.Expires = -1;
        if(!IsPostBack)
        {
            BingEdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmitData() 
    {
        if(null!=Request.QueryString["action"] && "edmit"==Request.QueryString["action"])
        {
            masterTradeId = Request.QueryString["MasterTradeId"];
            txtSecondaryTradeName.Value = Request.QueryString["SecondaryTradeName"];
            hidSecondaryId.Value = Request.QueryString["SecondaryTradeId"];
            strTitle = "编辑客户子行业";
            btnCancel.Visible = true;
            tr1.Visible = false;
        }
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData() 
    {
        if ("delete"==Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.SecondaryTrade.Id = Convert.ToInt32(hidSecondaryId.Value);
            orderBaseDataAction.LogicDeleteSecondaryTrade();
            hidSecondaryId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            orderBaseDataAction.Model.SecondaryTrade.MasterTradeId = Convert.ToInt32(Request.Form["masterTrade"]);
            orderBaseDataAction.Model.SecondaryTrade.Name = txtSecondaryTradeName.Value;
            if ("" != hidSecondaryId.Value.Trim())//更新
            {
                orderBaseDataAction.Model.SecondaryTrade.Id = Convert.ToInt32(hidSecondaryId.Value);
                orderBaseDataAction.UpdateSecondaryTrade();
                //Response.Write("<script>window.returnValue=true;</script>");
                //Response.Write("<scrip>window.close();</script>");
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                orderBaseDataAction.AddSecondaryTrade();
                txtSecondaryTradeName.Value = "";
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
        model.SecondaryTrade.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.SecondaryTrade.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchOrderBaseDataAction.SearchSecondaryTrade();

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
