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
using Workflow.Da;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: Finish
/// 功能概要: 订单完工
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class Finish : PageBase
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
    protected void OrderFinish(object sender, EventArgs e)
    {
        try
        {
            string strPId = Request.Form["sltProphase"];
            string[] strEmployeeId=null;
            string[] empArr = null;
            if (strPId != null && strPId != "")
            {
                strEmployeeId = strPId.Split(',');
            }
            string strAId = Request.Form["sltAnaphase"];
            string[] strTmp=null;
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
            if (null == empArr) return;

            newOrderAction.GetOrderItemIDByOrderNo(Request.Form["strOrderNo"].ToString());
            //newOrderAction.DeleteOrderItemEmployeeByOrderNo(Request.Form["strOrderNo"]);
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
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.Status = Constants.ORDER_STATUS_FINISHED_VALUE;
            Int64 orderId = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString[0]);
            orderStatusAlter.OrdersId = orderId;
            orderStatusAlter.Memo = Request.Form["Memo"];
            newOrderAction.Model.OrderStatusAlter = orderStatusAlter;

            for (int i = 0; i < empArr.Length; i++)
            {
                RelationEmployee relationEmployee = new RelationEmployee();
                relationEmployee.EmployeeId = Int64.Parse(empArr[i]);
                relationEmployee.OrdersStatusAlterId = orderStatusAlter.Id;
                newOrderAction.Model.RelationEmployeeList.Add(relationEmployee);
            }

            if (newOrderAction.Model.OrderItemList.Count > 0)
            {
                newOrderAction.FinishOrder( Request.Form["strOrderNo"], Constants.ORDER_STATUS_FINISHED_VALUE);
            }
            else
            {
                //该订单没有明细
                newOrderAction.FinishOrder(Request.Form["strOrderNo"], Constants.ORDER_STATUS_FINISHED_VALUE);
            }
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
