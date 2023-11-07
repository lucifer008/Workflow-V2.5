using System;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;
/// <summary>
/// 名    称: machineTypeDetail
/// 功能概要: 机器类型详情
/// 作    者: 张晓林
/// 创建时间: 2009年5月5日11:18:28
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class priceBaseData_machineTypeDetail : System.Web.UI.Page
{
    #region //ClassMember
    protected  MachineType machineType;
    private SearchPriceBaseDataAction searchPriceBaseDataAction;
    public SearchPriceBaseDataAction SearchPriceBaseDataAction
    {
        set { searchPriceBaseDataAction = value; }
        get { return searchPriceBaseDataAction; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        BingData();
    }
    private void BingData() 
    {
        Response.Expires = -1;
        searchPriceBaseDataAction.Model.MachineType.Id = 0;//行索引
        searchPriceBaseDataAction.Model.MachineType.InsertUser =1;//行数
        searchPriceBaseDataAction.Model.MachineType.Name = Request.QueryString["MachineTypeId"];
        searchPriceBaseDataAction.SearchMachineType();
        machineType = searchPriceBaseDataAction.Model.MachineTypeList[0];
    }
    #endregion

}
