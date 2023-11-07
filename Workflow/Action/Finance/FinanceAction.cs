using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.OrderManage;
using Workflow.Action.Finance.Model;
/// <summary>
/// 名    称: FinanceAction
/// 功能概要: 财务处理Action
/// 作    者: 张晓林
/// 创建时间: 2009-01-23
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action.Finance
{  
    public class FinanceAction : BaseAction
    {
        #region Service
        private IFinanceService financeService;
        public IFinanceService FinanceService
        {
            set { financeService = value; }
        }
        private IOrderService orderService;
        public IOrderService OrderService
        {
            set { orderService = value; }
        }
        private IApplicationProperty applicationProperty;
        public IApplicationProperty ApplicationProperty
        {
            set { applicationProperty = value; }
        }
        #endregion

        #region Model

        private FinanceModel model=new FinanceModel();
        public FinanceModel Model
        {
            get { return model; }
        }

        private OrderModel orderModel=new OrderModel();
        public OrderModel OrdelModel 
        {
            get { return orderModel; }
        }
        #endregion

        #region 通过OrderId获取订单信息
        /// <summary>
        /// 通过OrderId获取订单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-15
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public virtual void GetOrderByOrderId(long orderId)
        {
            model.Orders = financeService.GetOrderByOrderId(orderId);
        }
        #endregion

        #region 包含时机已经预付款金额的order
        /// <summary>
        /// 包含时机已经预付款金额的order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public virtual void SelectOrderInfoByOrderIdPrePaid(long orderId)
        {
            model.Orders = orderService.SelectOrderInfoByOrderIdPrePaid(orderId);
        }
        #endregion

        #region 收预收款
        /// <summary>
        /// 收预收款
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-15
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public virtual void PrepayHandler(string orderNo, int orderStatusFlag)
        {
            financeService.PrepayHandler(model.Gatherings, model.GatheringOrders, model.OrderStatusAlter, model.RelationEmployee, orderNo, orderStatusFlag);
        }
        #endregion

        #region 获取预付款限制方式
        /// <summary>
        /// 获取预付款限制方式
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual string GetPrePayLimitType()
        {
            return applicationProperty.GetPrePayLimit();// applicationProperty.GetPrePayLimit();
        }
        #endregion

        #region 通过订单号查找订单ID
        /// <summary>
        /// 名    称: SelectOrderIdByOrderNo
        /// 功能概要: 通过订单号查找订单ID
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public virtual long SelectOrderIdByOrderNo(string strOrderNo)
        {
            return orderService.SelectOrderIdByOrderNo(strOrderNo);
        }
        #endregion

        #region  查找等待结算的订单
        /// <summary>
        /// 查找等待结算的订单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-16
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void SelectUnClosedOrder()
        {
            model.OrderList= financeService.SelectUnClosedOrder(model.Orders);
        }

        public void SelectUnClosedOrderCount()
        {
            model.UnClosedOrderCount = financeService.SelectUnClosedOrderCount(model.Orders);
        }
        /// <summary>
        /// 通过各种号码查询客户ID
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：付强
        /// 创建时间: 2010-1-8
        /// </remarks>
        public void GetCustomerIdByNo()
        { 
            //Order order=new Order();
            //order.No=strOrderNo;
            //order.CustomerName=strMemberCardNo;
            //order.CodeNo=strCodeNo;
            model.CustomerId = financeService.GetCustomerIdByNo(model.Orders);

            if (model.CustomerId == 1 || model.CustomerId == 2)//如果是散客 或是学生
            {
                if (!string.IsNullOrEmpty(model.Orders.MemberCardNo))
                {
                    model.Orders.No = orderService.GetOrderNoByMemberCardNo(model.Orders.MemberCardNo);
                }
                model.CustomerName = orderService.GetOrderInfoByOrderNo(model.Orders.No).CustomerName;
            }

        }
        #endregion

        #region 订单结算
        /// <summary>
        /// 订单结算
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public virtual void CloseOrder()
        {
            financeService.CloseOrder(model.Orders,model.OrderItemList,model.OrdersForRecordMachineSumList, model.Gatherings, model.GatheringOrders,model.PaymentConcessionList, model.OrderStatusAlter, model.RelationEmployee,model);
        }
        #endregion

        #region 查找有欠款的订单
        /// <summary>
        /// 查找有欠款的订单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public virtual void SelectNotHaveBeenPaidOrder()
        {
            model.OrderList = financeService.SelectNotHaveBeenPaidOrder(model.Orders);
        }


        /// <summary>
        /// 查找有欠款的订单记录数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月1日16:52:29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void SelectCustomerOweMoneyDetailRowCount()
        {
            model.CustomerId = financeService.SelectCustomerOweMoneyDetailRowCount(model.Orders);
        }

        /// <summary>
        /// 查找客户欠款的订单明细
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月2日13:33:36
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void SelectCustomerOweMoneyDetail() 
        {
            model.OrderList = financeService.SelectCustomerOweMoneyDetail(model.Orders);
        }
        #endregion

        #region// 查找已经付款明细
        /// <summary>
        /// 查找已经付款明细
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月1日15:52:46
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void SelectCustomerPaidAmountDetail() 
        {
            model.OrderList = financeService.SelectCustomerPaidAmountDetail(model.Orders);
        }

        /// <summary>
        /// 查找订单付款明细
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月5日10:52:15
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void SelectOrderPaidAmountDetail() 
        {
            model.OrderList = financeService.SelectOrderPaidAmountDetail(model.Orders);
        }
        #endregion

        #region 应收款处理
        /// <summary>
        /// 应收款处理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        //[Transaction]
        public virtual void ArrearageMoneyHandler()
        {
            financeService.ArrearageMoneyHandler(model.OrderList, model.GatheringList, model.GatheringOrderList, model.PaymentConcessionList,model);
        }
        #endregion

        #region 通过ID查找加工内容的颜色
        /// 通过ID查找加工内容的颜色
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual string GetProcessContentById(long Id)
        {
            return financeService.GetProcessContentById(Id);
        }
        #endregion

        #region 返回订单
        /// <summary>
        /// 返回订单
        /// </summary>
        /// <remarks>
        /// 作     者：张晓林
        /// 创建时间：2008-12-23
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public virtual void ReturnOrder() 
        {
            financeService.ReturnOrder(model.OrderStatusAlter);
        }

        #endregion

        #region //领取发票
        /// <summary>
        /// 按照订单号查询 欠发票信息
        /// </summary>
        /// <remarks>
        /// 作     者：张晓林
        /// 创建时间：2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public virtual void SearchTicketAmountInfoByOrderNo(int currentPageIndex)
        {
            model.Orders.CurrentPageIndex = currentPageIndex - 1;
            model.Orders.EveryPageCount = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
            model.OrderList=financeService.SearchTicketAmountInfoByOrderNo(model.Orders);
            model.OrderPrintList = financeService.SearchTicketAmountInfoPrintByOrderNo(model.Orders);
        }

        
        /// <summary>
        /// 按照订单号查询 欠发票信息的总记录数
        /// </summary>
        /// <remarks>
        /// 作     者：张晓林
        /// 创建时间：2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public virtual long SearchTicketAmountInfoByOrderNoTotal() 
        {
            return financeService.SearchTicketAmountInfoByOrderNoTotal(model.Orders);
        }

        /// <summary>
        /// 领取发票
        /// </summary>
        /// <remarks>
        /// 作     者：张晓林
        /// 创建时间：2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public virtual void DrawTicket() 
        {
            financeService.DrawTicket(model.OrderList,model.OtherGatheringAndRefundmentRecordList);
        }
         
        /// <summary>
        ///  取消发票领取
        /// </summary>
        /// <remarks>
        ///  作    者：张晓林
        ///  创建时间：2009年12月2日11:04:25
        ///  修正履历：
        ///  修正时间:
        /// </remarks>
        public void CancelDrawTicket() 
        {
            financeService.CancelNotPaidTicket(model.OrderList, model.OtherGatheringAndRefundmentRecordList);
        }
        #endregion

		#region 解析活动的字符串信息


		/// <summary>
		///  解析活动的字符串信息
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-5-26
		/// </remarks>
		public void ParseCampaignData()
		{
			model.MemberCardOrderItemCounteractLogList=new List<MemberCardOrderItemCounteractLog>();
			MemberCardOrderItemCounteractLog itemLog=null;
			string[] orderItemCampaignArr = model.CampaignData.Split('|');
			foreach(string orderItemCampaign in orderItemCampaignArr)
			{
				itemLog = new MemberCardOrderItemCounteractLog();
				itemLog.MemberCardId = model.MemberCardId;
				string[] itemLogArr = orderItemCampaign.Split(',');
				foreach (string itemlogstr in itemLogArr)
				{
					string[] itemlogVal = itemlogstr.Split(':');
					switch (itemlogVal.GetValue(0).ToString())
					{
						case "OrderItemId" :
							itemLog.OrderItemId = Convert.ToInt64(itemlogVal.GetValue(1));
							break;
						case "CampaignId" :
							itemLog.CampaignTempId = Convert.ToInt64(itemlogVal.GetValue(1));
							break;
						case "UsedAmount" :
							itemLog.UsedAmount = Convert.ToDecimal(itemlogVal.GetValue(1));
							break;
						case "Type" :
							itemLog.CampaignType = itemlogVal.GetValue(1).ToString();
							break;
						case "ItemPrice":
							itemLog.CashUnitPrice = Convert.ToDecimal(itemlogVal.GetValue(1));
							break;
						case "CampaignPrice" :
							itemLog.CampaignUnitPrice = Convert.ToDecimal(itemlogVal.GetValue(1));
							break;
						case "Payment" :
							itemLog.CashConsumeAmount=Convert.ToDecimal(itemlogVal.GetValue(1));
							break;
						case "orderItemAllPrice" :
							itemLog.OrderItemDiscountPrice = Convert.ToDecimal(itemlogVal.GetValue(1));
							break;
						default :
							throw new ArgumentException("解析活动信息时,指定信息为空");
					}
				}
				itemLog.OrderItemDiscountPrice = itemLog.OrderItemDiscountPrice - itemLog.CashConsumeAmount;
				if (itemLog.CampaignType == "1")
				{
					itemLog.MemberCardConcessionId = itemLog.CampaignTempId;
					itemLog.IsUseSavedPaper = Constants.TRUE;
					itemLog.PaperConsumeCount = itemLog.UsedAmount;
					itemLog.CashConsumeCount = itemLog.CashConsumeAmount / itemLog.CashUnitPrice;
					itemLog.UnitDifferencePrice = itemLog.CashUnitPrice - itemLog.CampaignUnitPrice;
					itemLog.ConsumePaperAmount = itemLog.CashConsumeCount * itemLog.UnitDifferencePrice;
				}
				else
				{
					itemLog.MemberCardDiscountConcessionId = itemLog.CampaignTempId;
					itemLog.IsUseSavedPaper = Constants.FALSE;
					itemLog.Amount = itemLog.UsedAmount;
				}


				model.MemberCardOrderItemCounteractLogList.Add(itemLog);
			}
		}

		#endregion

        #region//累计会员积分
        /// <summary>
        /// 名   称:  UpdateMemberCardMarkingSetting
        /// 功能概要: 更新会员积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void UpdateMemberCardMarkingSetting(long orderId) 
        {
            financeService.UpdateMemberCardMarkingSetting(orderId);
        }
        #endregion

        #region//获取客户预存款
        /// <summary>
        ///  名    称: GetCustomerPreDeposit
        ///  功能概要: 获取客户预存款
        ///  作    者: 张晓林
        ///  创建时间: 2009年11月3日11:45:39
        ///  修正履历:
        ///  修正时间:
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public decimal GetCustomerPreDeposit(long customerId) 
        {
            long cuId = Constants.scatteredClientId(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            if (cuId == customerId) return 0;
            return financeService.GetCustomerPreDeposit(customerId);
        }
        #endregion

        #region//订单修正
        /// <summary>
        /// 名    称: GetAmendmentOrder
        /// 功能概要: 获取要修正的订单
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月17日13:10:40
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public void GetAmendmentOrder() 
        {
            model.Orders = financeService.GetAmendmentOrder(model.Orders);
            if (null != model.Orders) model.CustomerPayType = orderService.GetCustomerPayTypeByCustomerId(model.Orders.CustomerId);
        }
         /// <summary>
        /// 订单修正
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月18日17:04:51
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public virtual void AmendmentOrder() 
        {
            financeService.AmendmentOrder(model.Orders, model.OrderItemList, model.OrdersForRecordMachineSumList, model.Gatherings, model.GatheringOrders, model.PaymentConcessionList, model.OrderStatusAlter, model.RelationEmployee, model);
        }
        #endregion

        #region//订单报红统计
        /// <summary>
        /// 获取报红的订单按照条件
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2009年12月5日9:56:48
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public void SearchMatureOrderList() 
        {
            model.OrderList = financeService.SearchMatureOrderList(model.Orders);
            model.CustomerId = financeService.SearchMatureOrderListRowCount(model.Orders);
        }

        /// <summary>
        /// 获取输出的报红订单
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2009年12月5日9:58:17
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public void SearchMatureOrderPrintList() 
        {
            model.OrderPrintList=financeService.SearchMatureOrderPrintList(model.Orders);
        }
        #endregion

        /// <summary>
        /// 获取税费比列
        /// </summary>
        /// <returns></returns>
        ///<remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月16日18:03:56
        /// 修正履历：
        /// 修正时间:
        ///</remarks>
        public string GetScotInverse()
        {
            return applicationProperty.GetScotInverse();
        }
    } 
}
