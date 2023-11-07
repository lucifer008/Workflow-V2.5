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
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: GetPrintDemandListAjax
/// 功能概要: 选择制作要求
/// 作    者: 付强
/// 创建时间: 2007-9-19
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class OrderPrintRequest : Workflow.Web.PageBase
{
    #region 类成员
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            newOrderAction.InitMasterData();
            model = newOrderAction.Model;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
        if (!IsPostBack)
        { 
        }
    }
    #endregion
}
