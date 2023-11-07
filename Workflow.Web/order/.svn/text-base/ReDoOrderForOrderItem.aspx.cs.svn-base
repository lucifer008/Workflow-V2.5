using System;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: ReDoOrderForOrderItem
/// 功能概要: 订单返工
/// 作    者: 付强
/// 创建时间: 2009-1-7
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class order_ReDoOrderForOrderItem : PageBase
{
    #region 类成员
    protected bool closeFlag = false;
    protected StringBuilder sb = new StringBuilder();
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
            string orderNo = Request.QueryString["strNo"];
            newOrderAction.InitMasterData();
            newOrderAction.GetOrderInfo(orderNo);
            newOrderAction.GetOrderItemByOrderNo(orderNo);
            newOrderAction.GetOrderItemFactorValueByOrderNo(orderNo);
            newOrderAction.GetFactorValue(true);
            for (int i = 0; i < newOrderAction.Model.OrderItem.Count; i++)
            {
                if (i + 1 < newOrderAction.Model.OrderItem.Count)
                {
                    sb.Append(newOrderAction.Model.OrderItem[i].Id + ",");
                }
                else
                {
                    sb.Append(newOrderAction.Model.OrderItem[i].Id);
                }

            }
            if (!IsPostBack)
            {
                OrderItemEmployee orderItemEmployee = new OrderItemEmployee();
                orderItemEmployee.No = Request.QueryString[0];
                orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                orderItemEmployee.PositionId2 = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                newOrderAction.Model.OrderItemEmployee.Add(orderItemEmployee);
                newOrderAction.SelectOldEmployee();
            }
            model = newOrderAction.Model;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 控件事件
    protected void SaveReDo(object sender, EventArgs e)
    {
        try
        {
            string strDutyId = Request.Form["DutyMan"];
            string[] dutyArr = null;
            if (strDutyId != null && strDutyId != "")
            {
                dutyArr = strDutyId.Split(',');
            }
            if (null == dutyArr) return;

            for (int i = 0; i < newOrderAction.Model.OrderItem.Count; i++)
            {
                string strP = Request.Form["sltProphase" + newOrderAction.Model.OrderItem[i].Id.ToString()];
                string strA = Request.Form["sltAnaphase" + newOrderAction.Model.OrderItem[i].Id.ToString()];

                string[] strPArr = { };
                string[] strAArr = { };
                if (!string.IsNullOrEmpty(strP))
                {
                    strPArr = strP.Split(',');
                }
                if (!string.IsNullOrEmpty(strA))
                {
                    strAArr = strA.Split(',');
                }

                foreach (string str in strPArr)
                {
                    OrderItemEmployee OIE = new OrderItemEmployee();
                    OIE.OrderItemId = newOrderAction.Model.OrderItem[i].Id;
                    OIE.EmployeeId = Convert.ToInt64(str);
                    newOrderAction.Model.OrderItemEmployee.Add(OIE);
                }
                foreach (string str in strAArr)
                {
                    OrderItemEmployee OIE = new OrderItemEmployee();
                    OIE.OrderItemId = newOrderAction.Model.OrderItem[i].Id;
                    OIE.EmployeeId = Convert.ToInt64(str);
                    newOrderAction.Model.OrderItemEmployee.Add(OIE);
                }
            }

            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();

            orderStatusAlter.Status = Constants.ORDER_STATUS_CONFIRM_VALUE;
            Int64 orderId = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString[0]);
            orderStatusAlter.OrdersId = orderId;
            orderStatusAlter.Memo = Request.Form["Memo"];
            newOrderAction.Model.OrderStatusAlter = orderStatusAlter;

            RelationEmployee relationEmployee = new RelationEmployee();
            relationEmployee.EmployeeId = ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeId;
            relationEmployee.OrdersStatusAlterId = orderStatusAlter.Id;
            newOrderAction.Model.RelationEmployeeList.Add(relationEmployee);

            OrdersDuty orderDuty = new OrdersDuty();
            orderDuty.DutyAmount = decimal.Parse(Request.Form["strDutyMoney"]);
            orderDuty.Memo = Request.Form["Memo"];
            orderDuty.DutyFlag = "1";//1:表示返工 2:表示补单
            orderDuty.OrdersId = orderId;
            newOrderAction.Model.OrdersDuty = orderDuty;

            for (int i = 0; i < dutyArr.Length; i++)
            {
                DutyEmployee dutyEmployee = new DutyEmployee();
                dutyEmployee.EmployeeId = Int64.Parse(dutyArr[i]);
                dutyEmployee.OrdersDutyId = orderDuty.Id;
                newOrderAction.Model.DutyEmployeeList.Add(dutyEmployee);
            }
            newOrderAction.RedoOrder(Request.Form["strOrderNo"], Constants.ORDER_STATUS_RECEPTING_VALUE);

            closeFlag = true;
            Response.Write("<script>opener.rVal='true';</script>");
            Response.Write("<script>window.close()</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    #endregion
}
