using System;
using System.Collections.Generic;
using iTextSharp.text;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Support.Report.Finance;
using Workflow.Action.Finance.Model;

/// <summary>
/// 名    称: DrawTicket
/// 功能概要: 发票领取
/// 作    者: 张晓林
/// 创建时间: 2008-12-25
/// 修正履历: 张晓林 修正:
///                 1>:一次领取/取消多个欠票订单;
///                 2>:增加打印输出功能;
///                 3>:只显示以现金方式结款的订单
/// 修正时间: 2009年11月30日10:08:41
/// </summary>
public partial class finance_DrawTicket : System.Web.UI.Page
{
    #region //Class Member
    private bool tag = false;
    private string queryCondition = "";
    protected FinanceModel model;
    private FinanceAction financeAction;
    public FinanceAction FinanceAction 
    {
        set { financeAction = value; }
    }
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = financeAction.Model;
            //领取
            if ("True" == Request.Form["ActionTag"])
            {
                DrawTicket();
            }
            //取消
            if ("False" == Request.Form["ActionTag"])
            {
                CancelDrawTicket();
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//DrawTicket
    /// <summary>
    ///  领取发票
    /// </summary>
    /// <remarks>
    ///  作    者：张晓林
    ///  创建时间：2009年11月30日12:02:36
    ///  修正履历：
    ///  修正时间:
    /// </remarks>
    private void DrawTicket()
    {
        try
        {
            string[] strOrderId = Request.Form["orderId"].Split(',');
            IList<Order> orderList = new List<Order>();
            IList<OtherGatheringAndRefundmentRecord> otherGathAndList = new List<OtherGatheringAndRefundmentRecord>();
            foreach (string str in strOrderId)
            {
                if ("on" == Request.Form["cbDrawTicket" + str])
                {
                    model.Orders = new Order();
                    model.Orders.Id = Convert.ToInt32(str);
                    model.Orders.NotPayTicketAmount = Convert.ToDecimal(Request.Form["oweTicketAmount" + str]);
                    orderList.Add(model.Orders);

                    //补领发票记录
                    model.OtherGatheringAndRefundmentRecord = new OtherGatheringAndRefundmentRecord();
                    model.OtherGatheringAndRefundmentRecord.Amount = 0;
                    model.OtherGatheringAndRefundmentRecord.TicketAmountSum = Convert.ToDecimal(Request.Form["oweTicketAmount" + str]);
                    model.OtherGatheringAndRefundmentRecord.Memo = "发票领取:领取发票记录";
                    model.OtherGatheringAndRefundmentRecord.OrdersId = Convert.ToInt32(str);
                    model.OtherGatheringAndRefundmentRecord.CustomerId = Convert.ToInt32(Request.Form["customerIdArr" + str]);
                    model.OtherGatheringAndRefundmentRecord.PayKind = Constants.DRAW_TICKET_AMOUNT_KEY.ToString();
                    otherGathAndList.Add(model.OtherGatheringAndRefundmentRecord);
                }
            }

            tag = true;
            QueryNextPageData(1);
            PrintDrawTicketReport();

            financeAction.Model.OrderList = orderList;
            financeAction.Model.OtherGatheringAndRefundmentRecordList = otherGathAndList;
            financeAction.DrawTicket();
            QueryNextPageData(1);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//CancelDrawTicket
    /// <summary>
    ///  取消发票领取
    /// </summary>
    /// <remarks>
    ///  作    者：张晓林
    ///  创建时间：2009年12月2日11:04:25
    ///  修正履历：
    ///  修正时间:
    /// </remarks>
    private void CancelDrawTicket()
    {
        try 
        {
            string[] strOrderId = Request.Form["orderId"].Split(',');
            IList<Order> orderList = new List<Order>();
            IList<OtherGatheringAndRefundmentRecord> otherGathAndList = new List<OtherGatheringAndRefundmentRecord>();
            foreach (string str in strOrderId)
            {
                if ("on" == Request.Form["cbDrawTicket" + str])
                {
                    model.Orders = new Order();
                    model.Orders.Id = Convert.ToInt32(str);
                    model.Orders.PaidTicket = Constants.NEED_TICKET_NOT_KEY;
                    orderList.Add(model.Orders);

                     //取消发票记录
                    model.OtherGatheringAndRefundmentRecord = new OtherGatheringAndRefundmentRecord();
                    model.OtherGatheringAndRefundmentRecord.Amount = 0;
                    model.OtherGatheringAndRefundmentRecord.TicketAmountSum = Convert.ToDecimal(Request.Form["oweTicketAmount" + str]);
                    model.OtherGatheringAndRefundmentRecord.Memo = "发票领取:取消领取发票记录";
                    model.OtherGatheringAndRefundmentRecord.OrdersId = Convert.ToInt32(str);
                    model.OtherGatheringAndRefundmentRecord.CustomerId = Convert.ToInt32(Request.Form["customerIdArr" + str]);
                    model.OtherGatheringAndRefundmentRecord.PayKind = Constants.CANCEL_DRAW_TICKET_AMOUNT_KEY.ToString();
                    otherGathAndList.Add(model.OtherGatheringAndRefundmentRecord);
                }
            }
            financeAction.Model.OrderList = orderList;
            financeAction.Model.OtherGatheringAndRefundmentRecordList = otherGathAndList;
            financeAction.CancelDrawTicket();
            QueryNextPageData(1);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //Search
    protected void Search_Click(object sender, EventArgs e)
    {
        QueryNextPageData(1);
    }
    #endregion

    #region //分页处理程序
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }

    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            Order order = new Order();
            if ("" != OrderNo.Value.Trim())
            {
                order.No = "%" + OrderNo.Value.Trim()+ "%";
                queryCondition = "订单号:"+OrderNo.Value;
            }
            if ("" != txtCustomerName.Value.Trim())
            {
                order.CustomerName = "%" + txtCustomerName.Value.Trim() + "%";
                queryCondition += "   客户名称:" + txtCustomerName.Value;
            }
            if ("" != memberNo.Value.Trim()) 
            {
                order.MemberCardNo = memberNo.Value;
                queryCondition += "   会员卡号:" + memberNo.Value;
            }
            order.PayType = Constants.PAYMENT_TYPE_CASHER_GET_VALUE;//过滤掉记账订单
            financeAction.Model.Orders = order;
            this.AspNetPager1.CurrentPageIndex = currentPageIndex;
            financeAction.SearchTicketAmountInfoByOrderNo(currentPageIndex);

            AspNetPager1.RecordCount = (int)financeAction.SearchTicketAmountInfoByOrderNoTotal();
            AspNetPager1.PageSize = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//Print
    private void PrintDrawTicketReport() 
    {
        try
        {

            if (!tag) 
            { 
                QueryNextPageData(1); 
            }
            else
            {
                string[] strOrderId = Request.Form["orderId"].Split(',');
                List<Order> orderPrintList = new List<Order>();
                foreach (string str in strOrderId)
                {
                    if ("on" == Request.Form["cbDrawTicket" + str])
                    {
                        foreach (Order o in model.OrderList)
                        {

                            if (o.Id.ToString() == str)
                            {
                                Order oPrint = new Order();
                                oPrint = o;
                                oPrint.RealPaidAmount = Convert.ToDecimal(Request.Form["oweTicketAmount" + str]);//本次支付发票金额
                                orderPrintList.Add(oPrint);
                            }
                        }
                    }
                }
                model.OrderPrintList = orderPrintList;
            }
            ReportDrawTicket rdTicket = new ReportDrawTicket();
            rdTicket.Tag = tag;
            rdTicket.QueryString +=queryCondition;
            string reportFileName = "DrawTicket" + DateTime.Now.Ticks.ToString() + ".pdf";
            rdTicket.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;

            rdTicket.CreateReport(model, "发票领取", "发票领取", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '发票领取', 1024, 1024 , false, false, null);</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    protected void printClick(object sender, EventArgs e)
    {
        PrintDrawTicketReport();
    }
    #endregion
}
