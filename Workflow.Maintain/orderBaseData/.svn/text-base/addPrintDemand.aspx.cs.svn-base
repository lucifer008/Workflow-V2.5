using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.OrderBaseData;
using Workflow.Action.SystemMaintenance.OrderBaseData.Model;

/// <summary>
///  名    称：addPrintDemand
///  功能概要: 印制要求操作
///  作    者: 张晓林
///  创建时间: 2009年5月26日10:24:01
///  修正履历:
///  修正时间:
/// </summary>
public partial class orderBaseData_addPrintDemand : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "印制要求";
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
        if(null!=Request.QueryString["action"] && "edmit"==Request.QueryString["action"])
        {
            Response.Expires = -1;
            btnCancel.Visible = true;
            tr1.Visible = false;
            btnPrintDemandValue.Visible = false;
            strTitle = "编辑印制要求";
            txtPrintDemandName.Value = Request.QueryString["PrintDemandName"];
            txtMemo.Value = Request.QueryString["Memo"];
            hidPrintDemandId.Value = Request.QueryString["PrintDemandId"];
        }
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData() 
    {
        if ("delete" == Request.Form["actionTag"])
        {
            orderBaseDataAction.Model.PrintDemand.Id = Convert.ToInt32(hidPrintDemandId.Value);
            orderBaseDataAction.LogicDeletePrintDemand();
            hidPrintDemandId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            orderBaseDataAction.Model.PrintDemand.Memo = txtMemo.Value;
            orderBaseDataAction.Model.PrintDemand.Name = txtPrintDemandName.Value;
            if ("" != hidPrintDemandId.Value.Trim())//更新
            {
                orderBaseDataAction.Model.PrintDemand.Id = Convert.ToInt32(hidPrintDemandId.Value);
                orderBaseDataAction.UpdatePrintDemand();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                orderBaseDataAction.AddPrintDemand();
                txtMemo.Value = "";
                txtPrintDemandName.Value = "";
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
        model.PrintDemand.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.PrintDemand.UpdateUser = Convert.ToInt32(currentPageIndex-1);
        searchOrderBaseDataAction.SearchPrintDemand();

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
