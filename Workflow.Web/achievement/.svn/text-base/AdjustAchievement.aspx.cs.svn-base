using System;
using System.Collections.Generic;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Achievement;
using Workflow.Action.Achievement.Model;

/// <summary>
/// 名    称:AdjustAchievement
/// 功能概要:绩效调整
/// 作    者:
/// 创建时间:
/// 修正履历：张晓林
/// 修正时间:2009年4月6日17:57:32
/// 修正描述:调整代码
/// </summary>
public partial class AdjustAchievement : Workflow.Web.PageBase
{
    #region //ClassMember
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    private AdjustAchievementAction adjustAchievementAction;
    public AdjustAchievementAction AdjustAchievementAction
    {
        set { adjustAchievementAction = value; }
    }

    private SearchAchievementAction searchAchievementAction;
    public SearchAchievementAction SearchAchievementAction
    {
        set { searchAchievementAction = value; }
    }

    //检索指定订单
    protected AdjustAchievementModel model = null;
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack){}
    }
    #endregion

    #region //通过订单号检索订单信息
    /// <summary>
    /// 名    称: Search
    /// 功能概要: 检索员工业绩
    /// 作    者: 陈汝胤
    /// 创建时间: 2009-01-04
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    protected void Search(object sender, EventArgs e)
    {
        try
        {
            newOrderAction.GetOrderByOrderNo(Request.Form["strNo"]);
            if (null == newOrderAction.Model.NewOrder) return;
            if (Constants.ORDER_STATUS_SUCCESSED_VALUE != newOrderAction.Model.NewOrder.Status) return;
            model = searchAchievementAction.Model;
            model.No = Request.Form["strNo"];
            searchAchievementAction.Search();
            searchAchievementAction.GetOrderBeforeOrBehindPerson();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region  //调整绩效
    protected void Save(object sender, EventArgs e)
    {
        try
        {
            model = adjustAchievementAction.Model;
            long ordersId = Convert.ToInt32(Request.Form["orderId"]);
            string[] orderItemIds = Request.Form["itemid"].Split(',');
            adjustAchievementAction.Model.EmployeeList = new List<Employee>();
            for (int i = 0; i < orderItemIds.Length; i++)
            {
                string strEmployeeIds = Request.Form["employee" + orderItemIds[i]];
                if (null != strEmployeeIds)
                {
                    string[] employeeIds = Request.Form["employee" + orderItemIds[i]].Split(',');
                    string[] positionIds = Request.Form["position" + orderItemIds[i]].Split(',');
                    for (int j = 0; j < employeeIds.Length; j++)
                    {
                        string money = Request.Form["money" + orderItemIds[i] + employeeIds[j] + positionIds[j]];
                        if (money != null)
                        {
                            Achievement achinevement = new Achievement();
                            achinevement.OrdersId = ordersId;//OrdersId
                            achinevement.OrderItemId = long.Parse(orderItemIds[i]);
                            achinevement.EmployeeId = long.Parse(employeeIds[j]);
                            achinevement.AchievementValue = decimal.Round(decimal.Parse(money), 2);
                            achinevement.Position = positionIds[j];
                            model.AchievementList.Add(achinevement);
                        }
                        Employee employee = new Employee();
                        employee.Id = Convert.ToInt32(employeeIds[j]);
                        employee.InsertUser = Convert.ToInt32(orderItemIds[i]);
                        employee.UpdateUser = ordersId;
                        adjustAchievementAction.Model.EmployeeList.Add(employee);
                    }
                }
            }
            //更新员工的业绩
            adjustAchievementAction.UpdateJustAchievement();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
            //Response.Write("<script>var message='数据错误,"+Server.UrlEncode(ex.Message)+"';</script>");
        }
    }
    #endregion
}
