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
using Workflow.Web;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: BlankOutRecord
/// 功能概要: 废稿
/// 作    者: 付强
/// 创建时间: 2007-10-6
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class OrderBlankOutRecord : PageBase
{
    #region 类成员
    protected Boolean closeFlag = false;
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
            newOrderAction.GetOrderInfo(Request.QueryString["strNo"]);
            newOrderAction.GetOrderItemByOrderNo(Request.QueryString["strNo"]);

            newOrderAction.GetRealOrderItemAll(Request.QueryString["strNo"]);
            //newOrderAction.GetOrderItemListByOrderNo(Request.QueryString["strNo"]);
            //newOrderAction.GetOrderItemPrintRequeireDetail(Request.QueryString["strNo"]);
            //newOrderAction.GetOrderItemFactorValueByOrderNo(Request.QueryString["strNo"]);
            newOrderAction.GetFactorValue(false);
            InitData();
            OrderItemEmployee orderItemEmployee = new OrderItemEmployee();
            orderItemEmployee.No = Request.QueryString["strNo"];
            orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionId2 = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            newOrderAction.Model.OrderItemEmployee.Add(orderItemEmployee);
            newOrderAction.SelectOldEmployee();
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

    #region 数据绑定
    protected void InitData()
    {
        newOrderAction.InitMasterData();
        //支付方式
        this.cbPaymentType.DataSource = newOrderAction.Model.PaymentTypes;
        this.cbPaymentType.DataTextField = "label";
        this.cbPaymentType.DataValueField = "value";
        this.cbPaymentType.DataBind();
        for (int i = 0; i < this.cbPaymentType.Items.Count; i++)
        {
            if (cbPaymentType.Items[i].Value == newOrderAction.Model.NewOrder.PayType.ToString())
            {
                cbPaymentType.Items[i].Selected = true; ;
            }
        }
        //送货方式
        this.cbDeliveryType.DataSource = newOrderAction.Model.DevileryTypes;
        this.cbDeliveryType.DataTextField = "label";
        this.cbDeliveryType.DataValueField = "value";
        this.cbDeliveryType.DataBind();
        for (int i = 0; i < this.cbDeliveryType.Items.Count; i++)
        {
            if (cbDeliveryType.Items[i].Value == newOrderAction.Model.NewOrder.DeliveryType.ToString())
            {
                cbDeliveryType.Items[i].Selected = true;
            }
        }
        model = newOrderAction.Model;
    }
    #endregion

    #region 控件事件
    protected void Save(object sender, EventArgs e)
    {
        string[] strRealOrderItem = Request.Form["orderItemId"].Split(',');
        string[] strNumArr = Request.Form["blankOutNum"].Split(',');
        string[] strReasonArr = Request.Form["Reason"].Split(',');

        try
        {
            for (int i = 0; i<newOrderAction.Model.RealOrderItem.Count; i++)
            {
                string[] strEmployeeArr = Request.Form["employeeId"+i.ToString()].Split(',');
               

                for (int j = 0; j < strEmployeeArr.Length; j++)
                {
                    if ("" == strEmployeeArr[j]) continue;
                    TrashPaperEmployee trashPaperEmployee = new TrashPaperEmployee();
                    trashPaperEmployee.RealOrderItemId = Int64.Parse(strRealOrderItem[i]);
                    trashPaperEmployee.EmployeeId = Int64.Parse(strEmployeeArr[j]);
                    trashPaperEmployee.TrashPapers = Decimal.Parse(strNumArr[i]) / strEmployeeArr.Length;
                    newOrderAction.Model.TrashPaperEmployeeList.Add(trashPaperEmployee);
                }
                RealOrderItemTrashReason realOrderItemTrashReason = new RealOrderItemTrashReason();
                realOrderItemTrashReason.RealOrderItemId = Int64.Parse(strRealOrderItem[i]);
                realOrderItemTrashReason.TrashReasonId = Int64.Parse(strReasonArr[i]);
                newOrderAction.Model.RealOrderItemTrashReason.Add(realOrderItemTrashReason);

                newOrderAction.Model.RealOrderItem[i].TrashPapers = Decimal.Parse(strReasonArr[i]);
            }
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.Memo = "废张登记";
            orderStatusAlter.OrdersId = newOrderAction.SelectOrderIdByOrderNo(Request.QueryString["strNo"]);
            orderStatusAlter.Status = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
            newOrderAction.Model.OrderStatusAlter = orderStatusAlter;

            newOrderAction.TrashPaperRecord(Request.QueryString["strNo"]);
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
