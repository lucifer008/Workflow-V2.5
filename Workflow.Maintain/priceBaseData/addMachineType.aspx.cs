using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;
/// <summary>
/// 名    称: addMachineType
/// 功能概要: 添加机器类型
/// 作    者: 张晓林
/// 创建时间: 2009年5月4日9:25:38
/// 修正履历：
/// 修正时间:
/// </summary>
public partial class priceBaseData_addMachineType : System.Web.UI.Page
{
    #region //ClassMember
    protected string strTitle = "机器类型及机器";

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

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchPriceBaseDataAction.Model;
        Response.Expires = -1;
        btnCancel.Visible = false;//隐藏关闭按钮 
        if(!IsPostBack)
        {
            InitData();
            BingEdmitData();
        }
        DeleteMachineType();
        QueryNextPageData(1);
    }

    /// <summary>
    /// 初始化数据
    /// </summary>
    private void InitData() 
    {
        List<Label> listNeedInWatch = new List<Label>();
        Label label1 = new Label();
        label1.Text = Constants.NEED_IN_WATCH_NOT_TEXT;
        label1.ID = Constants.NEED_TICKET_NOT_KEY;

        Label label2 = new Label();
        label2.ID = Constants.NEED_IN_WATCH_KEY;
        label2.Text = Constants.NEED_IN_WATCH_TEXT;

        Label label3 = new Label();
        label3.Text = "请选择";
        label3.ID = "-1";
        listNeedInWatch.Add(label3);
        listNeedInWatch.Add(label1);
        listNeedInWatch.Add(label2);
        this.sltIsNotInWatch.DataSource = listNeedInWatch;
        this.sltIsNotInWatch.DataTextField = "Text";
        this.sltIsNotInWatch.DataValueField = "ID";
        this.sltIsNotInWatch.DataBind();
    }

    /// <summary>
    ///绑定编辑数据 
    /// </summary>
    private void BingEdmitData() 
    {
        if (null != Request.QueryString["actionTag"] && "edmit" == Request.QueryString["actionTag"])
        {
            tr1.Visible=false;
            btnCancel.Visible = true;//显示关闭按钮 
            strTitle = "编辑机器类型";
            txtMachineNo.Value = Request.QueryString["MachineNo"];
            txtMachineName.Value = Request.QueryString["MachineName"];
            for (int i = 0; i < sltIsNotInWatch.Items.Count;i++ )
            {
                if (Request.QueryString["MachineIsNoInW"] == sltIsNotInWatch.Items[i].Text)
                {
                    sltIsNotInWatch.SelectedIndex = i;
                    break;
                }
            }
            hidMachineTypeId.Value = Request.QueryString["MachineTypeId"];
            btnNewMachine.Visible = false;
            
        }
    }

    /// <summary>
    /// 删除机器类型
    /// </summary>
    private void DeleteMachineType() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            priceBaseDataAction.Model.MachineType.Id = Convert.ToInt32(hidMachineTypeId.Value);
            priceBaseDataAction.LogicDeleteMachineType();
            hidMachineTypeId.Value = "";
        }
    }
    #endregion

    #region //Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.MachineType.No = txtMachineNo.Value;
            priceBaseDataAction.Model.MachineType.Name = txtMachineName.Value;
            priceBaseDataAction.Model.MachineType.NeedRecordWarch = sltIsNotInWatch.Value;
            if ("" != hidMachineTypeId.Value.Trim())//更新
            {
                priceBaseDataAction.Model.MachineType.Id = Convert.ToInt32(hidMachineTypeId.Value);
                priceBaseDataAction.UpdateMachineType();
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else//插入
            {
                priceBaseDataAction.AddMachineType();
                Response.Write("<script>window.returnValue=true</script>");
                //QueryNextPageData(1);
                Response.Write("<script>window.navigate('addMachineType.aspx');</script>");
            }
            txtMachineName.Value = "";
            txtMachineNo.Value = "";
            sltIsNotInWatch.Value = "-1";
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
        searchPriceBaseDataAction.Model.MachineType.Id =Convert.ToInt32(currentPageIndex-1);//行索引
        searchPriceBaseDataAction.Model.MachineType.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);//行数
        searchPriceBaseDataAction.SearchMachineType();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.BusinessTypeRowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
