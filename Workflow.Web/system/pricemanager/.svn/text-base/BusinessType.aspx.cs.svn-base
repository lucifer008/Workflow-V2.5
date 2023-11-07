using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Action;
using Workflow.Support;
using Workflow.Action.Model;
/// <summary>
/// 名    称: BusinessType
/// 功能概要: 业务类型的一览查询,显示,修改,删除
/// 作    者: 麻少华
/// 创建时间: 2007-9-30
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
/// </summary>
public partial class BusinessType : Workflow.Web.PageBase
{
    #region 类成员
    //业务类型ID
    protected long lngBusinessTypeId = 0;
    //动作标记
    private int intAction = Constants.ACTION_INIT;
    protected PriceModel model;
    protected string ErrMsg="";
    public PriceAction priceAction;
    public PriceAction PriceAction
    {
        set { priceAction = value; }
    }

    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = priceAction.Model;
        ErrMsg = "";

        if (!this.IsPostBack)
        {
            priceAction.InitDataForBusinessTypeList_Set();
            
        }
        //获得页面动作
        if (Request.Form["txtAction"] != null)
        {
            intAction = int.Parse(Request.Form["txtAction"]);
        }

        if (intAction == Constants.ACTION_DELETE)
        {
            DeleteProcess();
            priceAction.InitDataForBusinessTypeList_Set();
        }
        else if (intAction == Constants.ACTION_SEARCH)
        {
            QueryProcess();
        }
        //追加保存后继续刷新页面
        else if (intAction == Constants.ACTION_INSERT)
        {
            priceAction.InitDataForBusinessTypeList_Set();
        }
        //编辑后继续刷新页面
        else if (intAction == Constants.ACTION_UPDATE)
        {
            priceAction.InitDataForBusinessTypeList_Set();
        }
    }
    #endregion

    #region 操作保存
    private void QueryProcess()
    {
        if (Request.Form["sltBusinessTypeName"] != null)
        {
            lngBusinessTypeId = long.Parse(Request.Form["sltBusinessTypeName"]);
        }
        priceAction.Model.BusinessType = new Workflow.Da.Domain.BusinessType();
        priceAction.Model.BusinessType.Id = lngBusinessTypeId;
        //priceAction.InitCustomQuery(priceAction.Model);
        priceAction.ShowSetData(priceAction.Model);

    }

    /// <summary>
    /// 方法名称: DeleteProcess
    /// 功能概要: 删除当前选中的业务类型
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-30
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void DeleteProcess() 
    {
        //获得业务ID
        if (Request.Form["txtId"] != null)
        {
            lngBusinessTypeId = long.Parse(Request.Form["txtId"]);
            //准备Model
            priceAction.Model.BusinessType = new Workflow.Da.Domain.BusinessType();
            priceAction.Model.BusinessType.Id = lngBusinessTypeId;
            //删除业务类型
            string returnStr=  priceAction.DeleteBusinessType(priceAction.Model);
            if (returnStr.Length > 0)
            {
                Response.Write("<script language='javascript'>alert('" + returnStr + "')</script>");
            }
        }
    }
    #endregion
}
