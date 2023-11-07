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

        #region 通过OrderId获取工单信息
        /// <summary>
        /// 通过OrderId获取工单信息
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

        #region 通过工单号查找工单ID
        /// <summary>
        /// 名    称: SelectOrderIdByOrderNo
        /// 功能概要: 通过工单号查找工单ID
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

        #region  查找等待结算的工单
        /// <summary>
        /// 查找等待结算的工单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-16
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public virtual void SelectUnClosedOrder()
        {
            model.OrderList= financeService.SelectUnClosedOrder(model.Orders);
        }

        public virtual void SelectUnClosedOrderCount()
        {
            model.UnClosedOrderCount = financeService.SelectUnClosedOrderCount(model.Orders);
        }
        #endregion

        #region 工单结算
        /// <summary>
        /// 工单结算
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

        #region 查找有欠款的工单
        /// <summary>
        /// 查找有欠款的工单
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

        #region 返回工单
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
        /// 按照工单号查询 欠发票信息
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
        }

        
        /// <summary>
        /// 按照工单号查询 欠发票信息的总记录数
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
            financeService.DrawTicket(model.Orders);
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
    } 
}
