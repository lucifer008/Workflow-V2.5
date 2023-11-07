using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

/// <summary>
///  名    称：addPrintDemandDetail
///  功能概要: 印制要求明细 操作
///  作    者: 张晓林
///  创建时间: 2009年5月26日10:24:01
///  修正履历:
///  修正时间:
/// </summary>

public partial class orderBaseData_addPrintDemandDeteil : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "印制要求明细",strPrintDemandId;
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
        Response.Expires = -1;
        model = searchOrderBaseDataAction.Model;
        searchOrderBaseDataAction.GetAllPrintDemand();
        if (!IsPostBack)
        {
            BindEdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
    }

    /// <summary>
    ///  绑定编辑数据
    /// </summary>
    private void BindEdmitData() 
    {
        if(null!=Request.QueryString["action"] && "edmit"==Request.QueryString["action"])
        {
            tr1.Visible = false;
            btnCancel.Visible = true;
            strTitle = "编辑印制要求明细";
            txtMemo.Value = Request.QueryString["Memo"];
            txtPrintDemandDetailName.Value = Request.QueryString["PrintDemandDetailName"];
            hidPrintDemandDetailId.Value = Request.QueryString["PrintDemandDetailId"];
            strPrintDemandId = Request.QueryString["PrintDemandId"];
        }
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData()
    {
        if("delete"==Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.PrintDemandDetail.Id = Convert.ToInt32(hidPrintDemandDetailId.Value);
            orderBaseDataAction.LogicDeletePrintDemandDetail();
            hidPrintDemandDetailId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            orderBaseDataAction.Model.PrintDemandDetail.Name = txtPrintDemandDetailName.Value;
            orderBaseDataAction.Model.PrintDemandDetail.Memo = txtMemo.Value;
            orderBaseDataAction.Model.PrintDemandDetail.PrintDemandId = Convert.ToInt32(Request.Form["printDemand"]);
            if ("" != hidPrintDemandDetailId.Value.Trim())//更新
            {
                orderBaseDataAction.Model.PrintDemandDetail.Id = Convert.ToInt32(hidPrintDemandDetailId.Value);
                orderBaseDataAction.UpdatePrintDemandDetail();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else 
            {
                orderBaseDataAction.AddPrintDemandDetail();
                txtPrintDemandDetailName.Value = "";
                txtMemo.Value = "";
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
        model.PrintDemandDetail.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.PrintDemandDetail.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchOrderBaseDataAction.SearchPrintDemandDetail();

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
