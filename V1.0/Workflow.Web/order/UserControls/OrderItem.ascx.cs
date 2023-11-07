using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Util;
using Workflow.Action;
using Workflow.Da.Domain;
using Workflow.Action.Model;

/// <summary>
/// 名    称: OrderUserControlsOrderItem
/// 功能概要: 工单明细用户控件
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class OrderUserControlsOrderItem : Workflow.Web.UserControlBase
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
        newOrderAction.InitMasterData();
        model = newOrderAction.Model;
        if (!IsPostBack)
        {
        }
    }
    #endregion

    #region 控件事件
    protected void BusinessType_ServerChange(object sender, EventArgs e)
    {
        newOrderAction.GetActiveRelation();
        model = newOrderAction.Model;
    }
    #endregion


    //protected void GetPrice(object sender, EventArgs e)
    //{
    //    long memberCardId=long.Parse(Request.Form["MemberCardId"]);
    //    long tradeId=long.Parse(Request.Form["TradeId"]);
    //    long customerId = long.Parse(Request.Form["txtCustomerId"]);
    //    string[] strfactorsId =Request.Form["txtFactorId" + Request.Form["RowNo"]].Split(',');
    //    long[] factorId =new long[strfactorsId.Length];
    //    for(int i=0 ;i<strfactorsId.Length;i++)
    //    {
    //        factorId[i] = long.Parse(strfactorsId[i]);
    //    }
    //    //price = newOrderAction.GetPrice(factorId, memberCardId, tradeId, customerId);
    //}
}
