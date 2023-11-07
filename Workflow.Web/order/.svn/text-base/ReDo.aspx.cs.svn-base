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
/// 名    称: OrderReDo
/// 功能概要: 返工
/// 作    者: 付强
/// 创建时间: 2007-10-8
/// 修正履历: 
/// 修正时间: 
///           
/// </summary>
public partial class OrderReDo : Workflow.Web.PageBase
{
    #region 类成员
    public bool closeFlag = false;
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
    protected void ReDoOk(object sender, EventArgs e)
    {
        try
        {
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            OrdersDuty orderDuty = new OrdersDuty();

            orderStatusAlter.Status = Constants.ORDER_STATUS_FACTURING_VALUE;
            Int64 orderId = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString[0]);
            orderStatusAlter.OrdersId = orderId;
            orderStatusAlter.Memo = "";

            newOrderAction.Model.OrderStatusAlter = orderStatusAlter;
            newOrderAction.Model.OrdersDuty = orderDuty;

            orderDuty.DutyAmount=decimal.Parse(Request.Form["strDutyMoney"]);
            orderDuty.Memo = Request.Form["strReason"];
            orderDuty.DutyFlag = "1";//1:表示返工 2:表示补单
            orderDuty.OrdersId = orderId;

            string strPId = Request.Form["sltProphase"];
            string[] strEmployeeId = null;
            string[] empArr = null;
            if (strPId != null && strPId != "")
            {
                strEmployeeId = strPId.Split(',');
            }
            string strAId = Request.Form["sltAnaphase"];
            string[] strTmp = null;
            if (strAId != null && strAId != "")
            {
                strTmp = strAId.Split(',');
            }
            if (strEmployeeId != null && strTmp != null)
            {
                empArr = new string[strEmployeeId.Length + strTmp.Length];
            }
            else if (strEmployeeId != null && strTmp == null)
            {
                empArr = new string[strEmployeeId.Length];
            }
            else if (strEmployeeId == null && strTmp != null)
            {
                empArr = new string[strTmp.Length];
            }
            else
            {
                return;
            }
            int index = 0;
            if (strTmp != null)
            {
                strTmp.CopyTo(empArr, 0);
                index = strTmp.Length;
            }
            if (strEmployeeId != null)
            {
                strEmployeeId.CopyTo(empArr, index);
            }
            if (null==empArr) return;
            string strDutyId = Request.Form["DutyMan"];
            string[] dutyArr = null;
            if (strDutyId != null && strDutyId != "")
            {
                dutyArr = strDutyId.Split(',');
            }
            if (null==dutyArr) return;
            for(int i=0;i<empArr.Length;i++)
            {
                RelationEmployee relationEmployee = new RelationEmployee();
                relationEmployee.EmployeeId=Int64.Parse(empArr[i]);
                relationEmployee.OrdersStatusAlterId = orderStatusAlter.Id;
                newOrderAction.Model.RelationEmployeeList.Add(relationEmployee);
            }

            newOrderAction.GetOrderItemIDByOrderNo(Request.Form["strOrderNo"]);
            for (int i = 0; i < newOrderAction.Model.OrderItemList.Count; i++)
            {
                for (int j = 0; j < empArr.Length; j++)
                {
                    OrderItemEmployee OIE = new OrderItemEmployee();
                    OIE.OrderItemId = newOrderAction.Model.OrderItemList[i].Id;
                    OIE.EmployeeId = Convert.ToInt64(empArr[j]);
                    newOrderAction.Model.OrderItemEmployee.Add(OIE);
                }
            }

            for (int i = 0; i < dutyArr.Length; i++)
            {
                DutyEmployee dutyEmployee = new DutyEmployee();
                dutyEmployee.EmployeeId = Int64.Parse(dutyArr[i]);
                dutyEmployee.OrdersDutyId = orderDuty.Id;
                newOrderAction.Model.DutyEmployeeList.Add(dutyEmployee);
            }
            newOrderAction.RedoOrder(Request.QueryString[0], Constants.ORDER_STATUS_FACTURING_VALUE);

            closeFlag = true;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
