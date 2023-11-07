using System;
using System.Collections.Generic;
//using System.Data;
//using System.Configuration;
//using System.Collections;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 日期导航选项卡控制类
/// </summary>
/// <remarks>
/// 作    者: 张晓林
/// 创建时间: 2010年7月6日9:35:38 
/// 修正履历:
/// 修正时间:
/// </remarks>
public partial class userControl_WebUserControl : System.Web.UI.UserControl
{
    #region//ClassMember
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    protected int CurrentDate=0;
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = newOrderAction.Model;
            string action=Request.Form["action"];
            CurrentDate = Convert.ToInt16(hidDateType.Value);
            //默认加载与单击右Div处理程序
            if ("T" != action)
            {
                Order.DateOptionCard dateOptionCard = new Order.DateOptionCard();
                dateOptionCard.Text = "前一天";
                dateOptionCard.Key = -1;
                model.DateList.Add(dateOptionCard);
                dateOptionCard = new Order.DateOptionCard();
                dateOptionCard.IndirectKey = "No";
                dateOptionCard.Text = "今日";
                dateOptionCard.Key = 0;
                model.DateList.Add(dateOptionCard);
            }
            else
            {
                newOrderAction.GetOptionCardList(CurrentDate);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion
}
