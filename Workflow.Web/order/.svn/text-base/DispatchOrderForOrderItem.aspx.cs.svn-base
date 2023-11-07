using System;
using System.Web;
using System.Text;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Report;
using Workflow.Support.Report.Orders;
using iTextSharp.text;
using Jayrock.Json;
using Jayrock.Json.Conversion;
/// <summary>
/// 名    称: DispatchOrderForOrderItem
/// 功能概要: 订单分配
/// 作    者: 付强
/// 创建时间: 2009-1-6
/// 修正履历: 张晓林
/// 修正时间: 2010年1月6日17:54:21
/// 修正描述: 将订单分配给前期人员修正 适应新的流程
/// </summary>
public partial class order_DispatchOrderForOrderItem : PageBase
{
    #region 类成员
    protected bool closeFlag = false;
    protected string actionType;
    protected string strOrderNo;
    protected StringBuilder sb = new StringBuilder();
    protected OrderModel model;
    private NewOrderAction newOrderAction;
    public NewOrderAction NewOrderAction
    {
        set { newOrderAction = value; }
    }
    private SearchOrderAction sAction;
    public SearchOrderAction SearchOrderAction
    {
        set { sAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = newOrderAction.Model;
        actionType = Request.QueryString["IsPrint"];
        if (!IsPostBack)
        {
            InitData();
        }
        //分配
        if ("Finish" == Request.Form["actionTag"])
        {
            SaveDispatchReceive();
        }
    }

    /// <summary>
    /// 功能概要：初始化数据
    /// 作    者：张晓林
    /// 创建时间: 2010年1月7日9:54:18
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
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//分配接待人(前期)
    /// <summary>
    /// 功能概要：分配接待人
    /// 作    者：张晓林
    /// 创建时间: 2010年1月7日9:54:18
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public void SaveDispatchReceive() 
    {
        try 
        {
            string strResult = Request.Form["SelectResult"];
            JsonArray jsonArray = (JsonArray)JsonConvert.Import(strResult);
            JsonObject jsItem = (JsonObject)JsonConvert.Import(jsonArray[0].ToString());
            string strP = jsItem["prophaseIds"].ToString();
            JsonArray pArr = (JsonArray)JsonConvert.Import(strP);

            //订单状态
            Order order = new Order();
            order.No = Request.QueryString["strNo"];
            order.ReceptionUser = Convert.ToInt32(pArr[0].ToString());
            if ("PrintOrders" == actionType) order.Status = Constants.ORDER_STATUS_FACTURING_VALUE;//直接开单
            else order.Status = Constants.ORDER_STATUS_RECEPTING_VALUE;//间接订单

            //订单状态履历
            OrdersStatusAlter ordersStatusAlter = new OrdersStatusAlter();
            ordersStatusAlter.OrdersId =newOrderAction.SelectOrderIdByOrderNo(order.No);
            ordersStatusAlter.Status = Constants.ORDER_STATUS_NODISPATCHED_VALUE;
            ordersStatusAlter.Memo = "分配订单";

            //前期
            for (int i = 0; i < jsonArray.Length; i++)
            {
                JsonObject jsItem1 = (JsonObject)JsonConvert.Import(jsonArray[i].ToString());
                long orderItemId = long.Parse(jsItem1["orderItemId"].ToString());
                foreach (string str in pArr)
                {
                    OrderItemEmployee OIE = new OrderItemEmployee();
                    OIE.OrderItemId = orderItemId;
                    OIE.EmployeeId = Convert.ToInt64(str);
                    newOrderAction.Model.OrderItemEmployee.Add(OIE);
                }
            }
            newOrderAction.Model.NewOrder = order;
            newOrderAction.Model.OrderStatusAlter = ordersStatusAlter;
            newOrderAction.NewDispatchOrder();
            closeFlag = true;
            if ("PrintOrders" != actionType) PrintDispatchReport(order.No);
            strOrderNo = order.No;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    /// <summary>
    /// 输出分配订单报表
    /// </summary>
    /// <param name="orderNo"></param>
    private void PrintDispatchReport(string orderNo) 
    {
        try
        {
            //订单详细信息
            newOrderAction.GetOrderInfo(orderNo);
            ReportReceptionOrder ro = new ReportReceptionOrder();
            ro.IsDisplayBarCode = true;
            string reportName = "ReceptionOrder" + DateTime.Now.Ticks.ToString() + ".pdf";
            ro.FileName = Server.MapPath("~") + @"\reports\" + reportName;
            ro.CreateReport(newOrderAction.Model,"接待订单", "接待订单", PageSize.A4, 0, 0, 30, 30);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
  }
