using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;

/// <summary>
/// 名    称: addMachine
/// 功能概要: 添加机器
/// 作    者: 张晓林
/// 创建时间: 2009年5月4日14:05:09
/// 修正履历：
/// 修正时间:
/// </summary>
public partial class priceBaseData_addMachine : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "机器";
    protected string strMachineType;
    protected PriceBaseDataModel model;
    private SearchPriceBaseDataAction searchPriceBaseDataAction;
    public SearchPriceBaseDataAction SearchPriceBaseDataAction
    {
        set { searchPriceBaseDataAction = value; }
    }
    private PriceBaseDataAction priceBaseDataAction;
    public PriceBaseDataAction PriceBaseDataAction
    {
        set { priceBaseDataAction = value; }
    }
    #endregion

    #region //Page_load
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        btnCancel.Visible = false;
        model = searchPriceBaseDataAction.Model;
        InitData();
        if(!IsPostBack)
        {
            BingEdmit();
        }
        DeleteMachine();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 初始化数据
    /// </summary>
    private void InitData() 
    {
        searchPriceBaseDataAction.SearchAllMachineType();
    }

    /// <summary>
    /// 绑定编辑数据
    /// </summary>
    private void BingEdmit() 
    {
        if (null != Request.QueryString["actionTag"] && "edmit" == Request.QueryString["actionTag"])
        {
            tr1.Visible = false;
            btnCancel.Visible = true;
            strTitle = "编辑机器";
            txtMachineNo.Value = Request.QueryString["MachineNo"];
            txtMachineName.Value = Request.QueryString["MachineName"];
           hidMachineId.Value= Request.QueryString["MachineId"];
           strMachineType = Request.QueryString["MachineTypeId"];
        }
    }

    private void DeleteMachine() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            priceBaseDataAction.Model.Machine.Id = Convert.ToInt32(hidMachineId.Value);
            priceBaseDataAction.LogicDeleteMachine();
            hidMachineId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.Machine.No = txtMachineNo.Value;
            priceBaseDataAction.Model.Machine.Name = txtMachineName.Value;
            priceBaseDataAction.Model.Machine.MachineType = new MachineType();
            priceBaseDataAction.Model.Machine.MachineType.Id = Convert.ToInt32(Request.Form["machineType"]);
            if ("" != hidMachineId.Value.Trim())//更新
            {
                priceBaseDataAction.Model.Machine.Id = Convert.ToInt32(hidMachineId.Value);
                priceBaseDataAction.UpdateMachine();
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                priceBaseDataAction.AddMachine();
                //Response.Write("<script>window.navigate('addMachine.aspx');</script>");
                QueryNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        searchPriceBaseDataAction.Model.Machine.Id =Convert.ToInt32(currentPageIndex - 1);
        searchPriceBaseDataAction.Model.Machine.InsertUser =Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        searchPriceBaseDataAction.SearchMachine();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.RecordCount = (int)model.BusinessTypeRowCount;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
