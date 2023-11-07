using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using Workflow.Da;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Finance;
using Workflow.Support.Report.Finance;
using iTextSharp.text;
/// <summary>
/// 应收款处理
/// </summary>
/// <remarks>
/// 作    者: 付强
/// 创建时间: 2007-10-13
/// 修正履历: 张晓林
/// 修正时间: 增加预存款冲减与添加预存款
/// </remarks>
public partial class RecevableAccount : Workflow.Web.PageBase
{
    #region Class Member
    private FinanceAction financeAction;
    public FinanceAction FinanceAction
    {
        set { financeAction = value; }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        { 
        }
    }
    #endregion

    #region Save
    protected void Save(object sender, EventArgs e)
    {
        try
        {
            string[] orderIdArr = Request.Form["OrdersId"].Split(',');
            string[] money = Request.Form["Money"].Split(',');
            financeAction.Model.OrderList = new List<Order>();
            financeAction.Model.GatheringList = new List<Gathering>();
            //预存款冲减
            decimal amountDiff = 0;
            if ("on" == Request.Form["usePreDeposits"])
            {
                amountDiff = decimal.Parse(Request.Form["realUsePreDepositsAmount"]);
                financeAction.Model.IsUsePreAmount = true;//使用预存款
                financeAction.Model.CustomerPreDeposits = amountDiff;//冲减的预存款
                financeAction.Model.CustomerId = Convert.ToInt32(Request.Form["CustomerId"]);
            }
            bool useCon = false;
            decimal concessionAmount = 0;
            for (int i = 0; i < orderIdArr.Length; i++)
            {
                if (StringUtils.IsEmpty(orderIdArr[i])) continue;
                if (!useCon)//减掉折让金额
                {
                    concessionAmount = decimal.Parse(Request.Form["Concession"]);
                    useCon = true;
                }
                if (amountDiff > 0)//使用预存款
                {
                    if ((amountDiff + concessionAmount) >= decimal.Parse(money[i]))//仅用预存款冲减
                    {
                        Order or = new Order();
                        or.Id = long.Parse(orderIdArr[i]);
                        or.PaidAmount = decimal.Parse(money[i])-concessionAmount;
                        financeAction.Model.OrderList.Add(or);

                        GatheringOrder gpPreDeDiff = new GatheringOrder();
                        gpPreDeDiff.PayKind =Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;
                        gpPreDeDiff.OrdersId = int.Parse(orderIdArr[i]);
                        financeAction.Model.GatheringOrderList.Add(gpPreDeDiff);

                        Gathering gaPreDeDiff = new Gathering();
                        gaPreDeDiff.Amount = decimal.Parse(money[i]) - concessionAmount;
                        gaPreDeDiff.GatheringDateTime = DateTime.Now;
                        financeAction.Model.GatheringList.Add(gaPreDeDiff);
                        amountDiff = amountDiff - decimal.Parse(money[i])+concessionAmount;
                    }
                    else //预存款冲减和现金冲减
                    {
                        Order or = new Order();
                        or.Id = long.Parse(orderIdArr[i]);
                        or.PaidAmount =decimal.Parse(money[i])-concessionAmount;
                        financeAction.Model.OrderList.Add(or);

                        GatheringOrder gpPreDeDiff = new GatheringOrder();
                        gpPreDeDiff.PayKind = Workflow.Support.Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;
                        gpPreDeDiff.OrdersId = int.Parse(orderIdArr[i]);
                        financeAction.Model.GatheringOrderList.Add(gpPreDeDiff);

                        Gathering gaPreDeDiff = new Gathering();
                        gaPreDeDiff.Amount =amountDiff;
                        gaPreDeDiff.GatheringDateTime = DateTime.Now;
                        financeAction.Model.GatheringList.Add(gaPreDeDiff);

                        GatheringOrder gO = new GatheringOrder();
                        gO.PayKind = Workflow.Support.Constants.PAY_KIND_ARREARAGE_VALUE;
                        gO.OrdersId = int.Parse(orderIdArr[i]);
                        financeAction.Model.GatheringOrderList.Add(gO);

                        Gathering ga = new Gathering();
                        ga.Amount = decimal.Parse(money[i]) - amountDiff-concessionAmount;
                        ga.GatheringDateTime = DateTime.Now;
                        financeAction.Model.GatheringList.Add(ga);
                        amountDiff = amountDiff - decimal.Parse(money[i]) + concessionAmount;
                    }
                   
                }
                else
                {
                    Order order = new Order();
                    order.Id = long.Parse(orderIdArr[i]);
                    order.PaidAmount = decimal.Parse(money[i])-concessionAmount;
                    financeAction.Model.OrderList.Add(order);
                    GatheringOrder gatheringOrder = new GatheringOrder();
                    gatheringOrder.PayKind = Workflow.Support.Constants.PAY_KIND_ARREARAGE_VALUE;
                    gatheringOrder.OrdersId = int.Parse(orderIdArr[i]);
                    financeAction.Model.GatheringOrderList.Add(gatheringOrder);

                    Gathering gathering = new Gathering();
                    gathering.Amount = decimal.Parse(money[i])-concessionAmount;
                    gathering.GatheringDateTime = DateTime.Now;
                    financeAction.Model.GatheringList.Add(gathering);
                }
                concessionAmount = 0;
               
            }
            //折让
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            if (!StringUtils.IsEmpty(Request.Form["Concession"]) && decimal.Parse(Request.Form["Concession"]) != 0)
            {
                PaymentConcession paymentConcession = new PaymentConcession();
                paymentConcession.AuthUsers = user;
                paymentConcession.ConcessionAmount = decimal.Parse(Request.Form["Concession"]);
                paymentConcession.ConcessionType = Workflow.Support.Constants.CONCESSION_TYPE_RENDERUP_VALUE;
                paymentConcession.OperateUsers = user;
                paymentConcession.Memo = Workflow.Support.Constants.CONSESSION_TYPE_RENDERUP_LABEL;
                financeAction.Model.PaymentConcessionList.Add(paymentConcession);
            }
            //预存
            if ("on"==Request.Form["savePreDeposits"])
            {
                financeAction.Model.IsUsePreDeposits = true;//是否预存
                financeAction.Model.PreDeposits = Convert.ToDecimal(Request.Form["savePreDepositsAmount"]);
                financeAction.Model.CustomerId = Convert.ToInt32(Request.Form["CustomerId"]);
            }
            financeAction.ArrearageMoneyHandler();
            Print();
        }
        catch (Exception ex)
        {
            Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }    
    #endregion

    #region Print
    private void Print()
    {
        Order order = new Order();

        order.CustomerId = long.Parse(Request.Form["CustomerId"]);
        order.Status = Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE;
        order.Status1 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_ZERO_VALUE);
        order.Status2 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_CONCESSION_VALUE);
        order.Status3 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_RENDERUP_VALUE);
        //order.LastTelNo = Constants.PAY_KIND_CLOSED_VALUE;//结算款
        //order.LinkManName = Constants.PAY_KIND_USE_PREPAY_VALUE;//预付款冲减
        //order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//应收款处理金额
        //order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
        //order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减
        order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
        order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
        financeAction.Model.Orders = order;
        financeAction.SelectNotHaveBeenPaidOrder();
        string[] orderIdArr = Request.Form["OrdersId"].Split(',');
        string[] money = Request.Form["Money"].Split(',');
        decimal paidAmount = 0;
        for (int i = 0; i < orderIdArr.Length; i++)
        {
            if (StringUtils.IsEmpty(orderIdArr[i])) continue;

            for (int j = 0; j < financeAction.Model.OrderList.Count; j++)
            {
                if (financeAction.Model.OrderList[j].Id.ToString().Equals(orderIdArr[i]))
                {
                    financeAction.Model.OrderList[j].Selected = true;
                    financeAction.Model.OrderList[j].CurrentMoney = decimal.Parse(money[i]);
                    //financeAction.Model.OrderList[i].CustomerName = Request.Form["textfield"];
                    paidAmount += decimal.Parse(money[i]);
                }
            }

        }

        ReportArreage ro = new ReportArreage();
        string reportName = "OrderArreage" + DateTime.Now.Ticks.ToString() + ".pdf";
        ro.FileName = Server.MapPath("~") + @"\reports\" + reportName;
        ro.rData.Concession = decimal.Parse(Request.Form["Concession"]);
        ro.rData.CustomerName = Request.Form["textfield"];
        ro.rData.PayMoney = paidAmount;//decimal.Parse(Request.Form["PayMoney"]);
        ro.rData.ShouldPay = decimal.Parse(Request.Form["showPayMoney"]);
        ro.CreateReport(financeAction.Model, "", Request.Form["textfield"]+" 应收款一览" , PageSize.A4, 0, 0, 30, 30);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script>showPage('../reports/" + reportName + "', '_blank', 1024, 1024 , false, false, null);window.location.href='RecevableAccount.aspx';</script>");

    }
    #endregion

}
