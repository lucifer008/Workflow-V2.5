using System;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Jayrock.Json;
using Jayrock.Json.Conversion;
/// <summary>
/// 名    称: FinishOrderForOrderItem
/// 功能概要: 订单完工
/// 作    者: 付强
/// 创建时间: 2009-1-7
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class order_FinishOrderForOrderItem : PageBase
{
    #region 类成员
    protected string strReceptionEmployee;
    protected string strReceptionUser;
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
        model = newOrderAction.Model;
        if (!IsPostBack) 
        {
            InitData();
        }
        //分配
        if ("Finish" == Request.Form["actionTag"])
        {
            SaveFinish();
        }
    }
    /// <summary>
    /// 功能概要: 初始化数据
    /// 作    者：张晓林
    /// 创建时间: 2010年1月7日11:08:36
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void InitData() 
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
            strReceptionEmployee = model.NewOrder.ReceptionEmployee;
            strReceptionUser = model.NewOrder.ReceptionUser.ToString();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //完工设置
    /// <summary>
    /// 功能概要: 保存完工所需人员
    /// 作    者：张晓林
    /// 创建时间: 2010年1月7日11:08:36
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    private void SaveFinish()
    {
        try
        {
            string strResult = Request.Form["SelectResult"];
            JsonArray jsonArray = (JsonArray)JsonConvert.Import(strResult);

            for (int i = 0; i < jsonArray.Length; i++)
            {
                JsonObject jsItem = (JsonObject)JsonConvert.Import(jsonArray[i].ToString());
                long orderItemId = long.Parse(jsItem["orderItemId"].ToString());
                string strP = jsItem["prophaseIds"].ToString();
                string strA = jsItem["anaphaseIds"].ToString();
                JsonArray aArr = (JsonArray)JsonConvert.Import(strA);
                JsonArray pArr = (JsonArray)JsonConvert.Import(strP);
                foreach (string str in pArr)
                {
                    OrderItemEmployee OIE = new OrderItemEmployee();
                    OIE.OrderItemId = orderItemId;
                    OIE.EmployeeId = Convert.ToInt64(str);
                    newOrderAction.Model.OrderItemEmployee.Add(OIE);
                }
                foreach (string str in aArr)
                {
                    OrderItemEmployee OIE = new OrderItemEmployee();
                    OIE.OrderItemId = orderItemId;
                    OIE.EmployeeId = Convert.ToInt64(str);
                    newOrderAction.Model.OrderItemEmployee.Add(OIE);
                }

            }

            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();

            orderStatusAlter.Status = Constants.ORDER_STATUS_FACTURING_VALUE;
            Int64 orderId = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString[0]);
            orderStatusAlter.OrdersId = orderId;
            orderStatusAlter.Memo = "订单完工";
            newOrderAction.Model.OrderStatusAlter = orderStatusAlter;

            RelationEmployee relationEmployee = new RelationEmployee();
            relationEmployee.EmployeeId = ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeId;
            relationEmployee.OrdersStatusAlterId = orderStatusAlter.Id;
            newOrderAction.Model.RelationEmployeeList.Add(relationEmployee);

            newOrderAction.FinishOrder(Request.Form["strOrderNo"], Constants.ORDER_STATUS_FINISHED_VALUE);



            #region//注释掉的代码
            //string[] arrOrderItemId = Request.Form["orderItemArr"].Split(',');
            //for (int i = 0; i < arrOrderItemId.Length; i++)
            //{
            //    string strP = Request.Form["sltProphase" + arrOrderItemId[i]];
            //    string strA = Request.Form["sltAnaphase" + arrOrderItemId[i]];
            //    string[] strPArr = { };
            //    string[] strAArr = { };
            //    if (!string.IsNullOrEmpty(strP))
            //    {
            //        strPArr = strP.Split(',');
            //    }
            //    if (!string.IsNullOrEmpty(strA))
            //    {
            //        strAArr = strA.Split(',');
            //    }

            //    foreach (string str in strPArr)
            //    {
            //        OrderItemEmployee OIE = new OrderItemEmployee();
            //        OIE.OrderItemId = Convert.ToInt64(arrOrderItemId[i]);
            //        OIE.EmployeeId = Convert.ToInt64(str);
            //        newOrderAction.Model.OrderItemEmployee.Add(OIE);
            //    }
            //    foreach (string str in strAArr)
            //    {
            //        OrderItemEmployee OIE = new OrderItemEmployee();
            //        OIE.OrderItemId = Convert.ToInt64(arrOrderItemId[i]);
            //        OIE.EmployeeId = Convert.ToInt64(str);
            //        newOrderAction.Model.OrderItemEmployee.Add(OIE);
            //    }
            //}

            //OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();

            //orderStatusAlter.Status = Constants.ORDER_STATUS_FACTURING_VALUE;
            //Int64 orderId = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString[0]);
            //orderStatusAlter.OrdersId = orderId;
            //orderStatusAlter.Memo = Request.Form["Memo"];
            //newOrderAction.Model.OrderStatusAlter = orderStatusAlter;

            //RelationEmployee relationEmployee = new RelationEmployee();
            //relationEmployee.EmployeeId = ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeId;
            //relationEmployee.OrdersStatusAlterId = orderStatusAlter.Id;
            //newOrderAction.Model.RelationEmployeeList.Add(relationEmployee);

            //newOrderAction.FinishOrder(Request.Form["strOrderNo"], Constants.ORDER_STATUS_FINISHED_VALUE);
            //closeFlag = true;
            #endregion

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
