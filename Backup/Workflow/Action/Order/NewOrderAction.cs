using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Util;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.OrderManage;
using Workflow.Service.CustomerManager;
using Workflow.Service.SystemManege.PriceManage;
namespace Workflow.Action
{
    /// <summary>
    /// 名    称: NewOrderAction
    /// 功能概要: 开单界面的Action
    /// 作    者: 付强
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public sealed class NewOrderAction : BaseAction
    {
        #region 类成员
        private IOrderService orderService;
        public IOrderService OrderService
        {
            set { orderService = value; }
        }
        private IPriceService priceService;
        public IPriceService PriceService
        {
            get { return priceService; }
            set { priceService = value; }
        }
        private ISelectActiveFactorService selectActiveFactorService;
        public ISelectActiveFactorService SelectActiveFactorService
        {
            set { selectActiveFactorService = value; }
            get { return selectActiveFactorService; }
        }
        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        public IFindFinanceService findFinanceService;
        public IFindFinanceService FindFinanceService
        {
            set { findFinanceService = value; }
        }

        private IFinanceService financeService;
        public IFinanceService FinanceService
        {
            set { financeService = value; }
        }

        private OrderModel model = new OrderModel();
        public OrderModel Model
        {
            get { return model; }
        }

        private OrderModel orderModelTemp = new OrderModel();
        public OrderModel OrderModelTemp
        {
            set { orderModelTemp = value; }
            get { return orderModelTemp; }
        }

        private ISearchCustomerService searchCustomerService;
        public ISearchCustomerService SearchCustomerService 
        {
            set { searchCustomerService = value; }
        }
        private IApplicationProperty applicationProperty;
        public IApplicationProperty ApplicationProperty
        {
            set { applicationProperty = value; }
        }
        #endregion

        #region 初始化基础数据
        /// <summary>
        /// 名    称: InitMasterData
        /// 功能概要: 初始化基础数据
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void InitMasterData()
        {
            model.CustomerTypes = masterDataService.GetCustomerTypes();
            model.DevileryTypes = masterDataService.GetDeliveryTypes();
            model.PaymentTypes = masterDataService.GetPaymentTypes();
            model.BusinessType = selectActiveFactorService.GetbusinessType();
            model.PriceFactor = selectActiveFactorService.GetPriceFactor();
            model.PrintDemandList = masterDataService.GetPrintDemandList();
            model.EmployeeList = masterDataService.GetEmployeeList();
            model.TrashReason = masterDataService.GetTrashReasonList();
        }
        #endregion

        #region 本日订单列表
        /// <summary>
        /// 名    称: GetDailyOrderPager
        /// 功能概要: 获取本日订单
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<Order> GetDailyOrderPager()
        {
            return orderService.SelectDailyOrderPager(model.NewOrder);
            //model.MemberCardBrushNumber = orderService.GetDailyOrderCount(model.NewOrder);
        }

        /// <summary>
        /// 名    称: GetDailyOrderPager
        /// 功能概要: 获取本日订单总数
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public int GetDailyOrderCount()
        {
            return orderService.GetDailyOrderCount(model.NewOrder);
        }

        /// <summary>
        /// 获取本日订单列表默认显示的天数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2010年2月25日15:12:40
        /// 修正履历:
        /// 修正时间：
        /// </remarks>
        public int GetDisplayOrderInnerDayCount() 
        {
            return orderService.GetDisplayOrderInnerDayCount();
        }
        #endregion

        #region 价格因素
        /// <summary>
        /// 名    称: GetActiveRelation
        /// 功能概要: 获取动态因素
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name=""></param>
        public void GetActiveRelation()
        {
            model.PriceFactor = selectActiveFactorService.GetRelatedPrice(model.Factorrelation);
        }
        /// <summary>
        /// 名    称: GetFactorValue
        /// 获取价格因素的文本值
        /// 作    者: 付强　
        /// 创建时间: 2007-10-6
        /// 修正履历:
        /// 修正时间: 2007-10-13
        /// </summary>
        /// <param name="flag">true:OrderItem;false:RealOrderItem</param>
        public void GetFactorValue(bool flag)
        {
            if (flag)
            {
                if (model.NewOrder != null)
                {
                    orderService.GetFactorValueText(model.NewOrder.OrderItemList);
                }
            }
            else
            {
                orderService.GetFactorValueText(model.RealOrderItemList);
            }
        }

        /// <summary>
        /// 获取价格因素的文本值
        /// 作    者: 
        /// 创建时间: 2007-10-6
        /// 修 正 人: 付强　
        /// 修正时间: 2007-10-13
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="flag">true:OrderItem;false:RealOrderItem</param>
        public void GetFactorValue2(bool flag)
        {
            if (flag)
            {
                if (model.NewOrder != null)
                {
                    orderService.GetFactorValueText(model.NewOrder.OrderItemList);
                }
            }
            else
            {
                orderService.GetFactorValueText(model.OrderItemList);
            }
        }
        #endregion

        #region 获取价格
        /// <summary>
        /// 获取价格
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强　
        /// 创建时间: 2007-10-6
        /// 修 正 人: 付强　
        /// 修正时间: 2008-11-12
        /// 修正履历:
        /// 
        /// </remarks>	
        public void GetPrice()
        {
            if (-1 != model.BusinessTypePriceSet.CustomerId || -1 != model.BusinessTypePriceSet.MemberCardId ||
                -1 != model.BusinessTypePriceSet.TradeId || -1 != model.BusinessTypePriceSet.MemberCardLevelId)
            {
                model.BusinessTypePriceSet = priceService.GetPrice(model.BusinessTypePriceSet);
            }
            else
            {
                model.BaseBusinessTypePriceSet = priceService.GetPrice(model.BaseBusinessTypePriceSet);
            }
        }
        #endregion

        #region 获取数量段
        /// <summary>
        /// 名    称: GetAmountSegmentList
        /// 功能概要: 获取数量段
        /// 作    者: 付强
        /// 创建时间: 2009-1-4
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetAmountSegmentList()
        {
            model.AmountSegmentList = priceService.GetAmountSegmentList();
        }
        #endregion

        #region 订单开单
        /// <summary>
        /// 名    称: AddOrder
        /// 功能概要: 保存订单
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name=""></param>
        public void AddOrder()
        {
            orderService.SaveOrder(model.NewOrder, model.OrderStatusAlter, model.LinkMan, model.Customer);
        }
        /// <summary>
        /// 名    称: UpdateOrder
        /// 功能概要: 更新订单
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name=""></param>
        public void UpdateOrder()
        {
            orderService.UpdateOrder(model.NewOrder);
        }


        #region 订单返工
        /// <summary>
        /// 名    称: ReDoOrder
        /// 功能概要: 返工
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        public void RedoOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.ReDoOrder(model.OrderStatusAlter, model.OrdersDuty, model.OrderItemEmployee, model.RelationEmployeeList, model.DutyEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region 分配订单
        /// <summary>
        /// 名    称: DispatchOrder
        /// 功能概要: 分配订单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployeeList">订单明细的参与人员</param>
        /// <param name="orderStatusAlter">订单状态的变更履历</param>
        /// <param name="relationEmployeeList">订单状态变更的相关人员</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="OrderStatusFlag">订单状态</param>
        public void DispatchOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.DispatchOrder(model.OrderItemEmployee, model.OrderStatusAlter, model.RelationEmployeeList, strOrderNo, orderStatusFlag);
        }

        /// <summary>
        /// 名    称: NewDispatchOrder
        /// 功能概要: 新流程-分配订单
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月7日15:06:46
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void NewDispatchOrder()
        {
            orderService.NewDispatchOrder(model.NewOrder, model.OrderStatusAlter, model.OrderItemEmployee);
        }
        #endregion
        #region//新流程-修正打印
        ///// <summary>
        ///// 名    称: AdmendmentPrint
        ///// 功能概要: 新流程-修正打印
        ///// 作    者: 张晓林
        ///// 创建时间: 2010年1月7日17:25:53
        ///// 修正履历: 
        ///// 修正时间: 
        ///// </summary>
        //public void AdmendmentPrint() 
        //{
        //    orderService.AdmendmentPrint(model.NewOrder,model.OrderStatusAlter);
        //}
        #endregion

        #region//新流程-返回订单
        /// <summary>
        /// 名    称: ReturnOrder
        /// 功能概要: 新流程-返回订单
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月8日10:05:09
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void ReturnOrder() 
        {
            orderService.ReturnOrder(model.NewOrder, model.OrderStatusAlter);//,model.IsPrint,model.OrderItemIdArr);
        } 
        #endregion

        #region 订单完工
        /// <summary>
        /// 名    称: FinishOrder
        /// 功能概要: 完工
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        public void FinishOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.FinishOrder(model.OrderItemEmployee, model.OrderStatusAlter, model.RelationEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region 作废订单
        /// <summary>
        /// 名    称: BlankOutOrder
        /// 功能概要: 作废订单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        public void BlankOutOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.BlankOutOrder(model.OrderStatusAlter, model.RelationEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region 修正加订单
        /// <summary>
        /// 名    称: RealFactureOrder
        /// 功能概要: 实际(修改加订单)
        /// 作    者: 付强　
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void RealFactureOrder()
        {
            orderService.RealFactureOrder(model.NewOrder, model.OrderStatusAlter);
            //会员卡消费时
            orderService.UpdateMemberCardConsume(model.MemberCardConcession, model.MemberCard);
        }
        /// <summary>
        /// 名    称: DispatchDeleteOrderItemEmployeeByOrderNo
        /// 功能概要: 通过订单号删除订单雇员
        /// 作    者: 付强
        /// 创建时间: 2008-9-26
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void DispatchDeleteOrderItemEmployeeByOrderNo(string strOrderNo)
        {
            orderService.DispatchDeleteOrderItemEmployeeByOrderNo(strOrderNo);
        }
        #endregion

        #region 拼板
        /// <summary>
        /// 名    称: PatchUpOrder
        /// 功能概要: 拼版
        /// 作    者: 付强　
        /// 创建时间: 2007-10-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void PatchUpOrder(string strOrderNo)
        {
            orderService.PatchUpOrder(model.RealOrderItem, model.OrderStatusAlter, strOrderNo);
        }
        #endregion

        #region 废张登记
        /// <summary>
        /// 名    称: TrashPaperRecord
        /// 功能概要: 废张登记
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="orderNo">订单号</param>
        public void TrashPaperRecord(string orderNo)
        {
            orderService.TrashPaperRecord(model.RealOrderItemList, model.TrashPaperEmployeeList, model.RealOrderItemTrashReason, model.OrderStatusAlter, orderNo);
        }
        #endregion


        #endregion

        #region 获取订单信息
        /// <summary>
        /// 名    称: SelectOrderIdByOrderNo
        /// 功能概要: 通过订单号查找订单ID
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public long SelectOrderIdByOrderNo(string strOrderNo)
        {
            return orderService.SelectOrderIdByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderInfo
        /// 功能概要: 通过订单号获取订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void GetOrderInfo(string strOrderNo)
        {
            GetOrderItemIDByOrderNo(strOrderNo);
            GetOrderByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过订单号获取订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void GetOrderByOrderNo(string strOrderNo)
        {
            model.NewOrder = orderService.GetOrderInfoByOrderNo(strOrderNo);
            if (null != model.NewOrder)
            {
                model.CustomerPayType = orderService.GetCustomerPayTypeByCustomerId(model.NewOrder.CustomerId);
                if (Constants.ORDER_STATUS_SUCCESSED_VALUE == model.NewOrder.Status)
                    model.PaymentConcessionList = orderService.GetOrderPaymentConcessionByOrderId(model.NewOrder.Id);
            }
        }
        /// <summary>
        /// 名    称: GetOrderItemIDByOrderNo
        /// 功能概要: 通过订单号获取订单明细
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void GetOrderItemIDByOrderNo(string strOrderNo)
        {
            model.OrderItemList = masterDataService.GetOrderItemIDByOrderNo(strOrderNo);
        }

        /// <summary>
        /// 名    称: GetOrderItemListByOrderNo
        /// 功能概要: 通过订单号查找订单明细
        /// 作    者: 付强
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void GetOrderItemListByOrderNo(string strOrderNo)
        {
            model.OrderItemList = orderService.GetOrderItemListByOrderNo(strOrderNo);
            model.OrderItem = model.OrderItemList;
        }
        /// <summary>
        /// 名    称: GetOrderItemByOrderNo
        /// 功能概要: 通过订单号查找订单明细ID
        /// 作    者: 付强
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void GetOrderItemByOrderNo(string strOrderNo)
        {
            model.OrderItem = orderService.GetOrderItemByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemPrintRequeireDetail
        /// 功能概要: 通过订单号查找订单明细印制要求
        /// 作    者: 付强
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void GetOrderItemPrintRequeireDetail(string strOrderNo)
        {
            model.OrderItemPrintRequireDetailList = orderService.GetOrderItemPrintRequireByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemEmployeeByOrderNo
        /// 功能概要: 通过订单号查找订单明细前后期的参与人员
        /// 作    者: 付强
        /// 创建时间: 2008-11-01
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void GetOrderItemEmployeeByOrderNo(string strOrderNo)
        {
            model.OrderItemEmployee = orderService.GetOrderItemEmployeeByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemFactorValueByOrderNo
        /// 功能概要: 通过订单号查找订单明细因素的值
        /// 作    者: 付强
        /// 创建时间: 2007-10-8
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void GetOrderItemFactorValueByOrderNo(string strOrderNo)
        {
            if (null != model.NewOrder)
            {
                model.NewOrder.OrderItemList = orderService.GetOrderItemFactorValueByOrderNo(strOrderNo);
                orderService.GetFactorValueText(model.NewOrder.OrderItemList);
            }
        }

        /// <summary>
        /// 获取订单正式打印的次数
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年3月2日14:57:10
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public void GetOrderPrintCountByOrderNo(string strOrderNo) 
        {
            model.OrderPrintCount =orderService.GetOrderPrintCountByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: SelectOldEmployee
        /// 功能概要: 获取原订单雇员信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name=""></param>
        public void SelectOldEmployee()
        {
            model.OrderItemEmployee = orderService.SelectOldEmployee(model.OrderItemEmployee[0]);
        }
        #endregion

        #region 获取实际订单明细
        /// <summary>
        /// 名    称: GetRealOrderItemAll
        /// 功能概要: 通过订单号获取实际订单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="orderNo">订单号</param>
        public void GetRealOrderItemAll(string orderNo)
        {
            long id = this.SelectOrderIdByOrderNo(orderNo);
            model.RealOrderItem = orderService.GetRealOrderItemByOrderId(id);
            model.RealOrderItemList = orderService.GetRealOrderItemFactorValueByOrderId(id);
            model.RealOrderItemPrintRequire = orderService.GetRealOrderItemPrintRequire(id);
            model.RealOrderItemEmployeeList = orderService.GetRealOrderItemEmployeebyOrderId(id);
        }

        /// <summary>
        /// 名    称: GetOrderItemAll
        /// 功能概要: 通过订单号获取订单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="orderNo">订单号</param>
        public void GetOrderItemAll(string orderNo)
        {
            model.OrderItem = orderService.GetCashOrderItemByOrderId(orderNo);
            model.OrderItemList = orderService.GetCashOrderItemFactorValueByOrderId(orderNo);
            model.OrderItemPrintRequireDetail = orderService.GetCashOrderItemPrintRequire(orderNo);
            model.OrderItemEmployeeList = orderService.GetCashOrderItemEmployeebyOrderId(orderNo);
        }
        /// <summary>
        /// 名    称: SelectOrderItemEmployee
        /// 功能概要: 查找订单明细的相关人员
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public void SelectOrderItemEmployee()
        {
            model.OrderItemEmployee = orderService.SelectOrderItemEmployee(model.OrderItemEmployee[0]);
        }
        #endregion
        
        #region 送货
        /// <summary>
        /// 名    称: DeliveryOrder
        /// 功能概要: 送货保存
        /// 作    者: 付强
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void DeliveryOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.DeliveryOrder(model.DeliveryOrderList);
            orderService.UpdateOrderStatusByOrderNo(strOrderNo, orderStatusFlag);
        }
        /// <summary>
        /// 名    称: CancelAfterVerification
        /// 功能概要: 核销订单送货
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        /// <param name="deliveryStatus">送货状态</param>
        public void CancelAfterVerification(string strOrderNo, int orderStatusFlag, bool deliveryStatus)
        {
            if (deliveryStatus)
            {
                orderService.CancelAfterVerification(model.DeliveryOrderList[0], model.OrderStatusAlter, strOrderNo, orderStatusFlag);
            }
            else
            {
                orderService.UpdateOrderStatusByOrderNo(strOrderNo, orderStatusFlag);
            }
        }
        /// <summary>
        /// 名    称: GetDeliveryOrderByOrderNo
        /// 功能概要: 通过订单号获取送货状态订单       
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns></returns>
        /// <remarks>
        public void GetDeliveryOrderByOrderNo(string strOrderNo)
        {
            model.DeliveryOrderList.Add(orderService.GetDeliveryOrder(strOrderNo));
        }
        #endregion

        #region 获取所有用户
        /// <summary>
        /// 名    称: GetAllUser
        /// 功能概要: 获取所有用户       
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetAllUser()
        {
            if (model.UserList == null)
            {
                model.UserList = new List<User>();
            }
            model.UserList = orderService.GetAllUser();
        }
        #endregion



        /// <summary>
        /// 获取所有需要交预付款的订单
        /// </summary>
        public void GetAllNeedPrePayOrders()
        {
            model.OrderList = orderService.GetAllNeedPrePayOrders(model.NewOrder);
            model.NeedPrePayOrdersCount = orderService.GetAllNeedPrePayOrdersCount(model.NewOrder);
            model.NewOrder=orderService.GetOrderPrepayAmountTotalAndSumAmountTotal(model.NewOrder);//合计订单总金额与预收总金额
        }

        public void GetAllNeedPrePayOrdersCount()
        {
            model.NeedPrePayOrdersCount = orderService.GetAllNeedPrePayOrdersCount(model.NewOrder);
        }


        /// <summary>
        /// 获取订单下实际已预付款
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public decimal GetPrePayAmount(Workflow.Da.Domain.Order order)
        {
            return orderService.GetPrePayAmount(order);
        }

        /// <summary>
        /// 查找某一个会员卡下的优惠活动
        /// </summary>
        /// <param name="model">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public void SelectMemberCardConcessionByPriceIdAndConcessionId()
        {
            model.MemberCardConcessionList = orderService.SelectMemberCardConcessionByPriceIdAndConcessionId(model.MemberCardConcession);
        }

        #region 查询会员卡的刷卡次数
        /// <summary>
        /// 查询会员卡的刷卡次数
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public void SearchMemberCardBrushNumber()
        {
            model.MemberCardBrushNumber = orderService.SearchMemberCardBrushNumber(model.NewOrder.MemberCardNo);
        }
        #endregion
        /// 通过会员卡号查找相关客户信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void SelectCustomerInfoByMemberCardNo(string memberCardNo)
        {
            model.MemberCard = searchCustomerService.SelectCustomerInfoByMemberCardNo(memberCardNo);
        }


        public void GetCustomerInfoById(long customerId)
        {
            model.Customer = orderService.GetCustomerInfoByCustomerId(customerId);
        }

        /// <summary>
        /// 名    称: GetOperatorList
        /// 功能概要: 获取操作符列表
        /// 作    者: 张晓林
        /// 创建时间: 2007-12-10
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void GetOperatorList()
        {
            model.OperatorList = findFinanceService.GetOperator();
        }

        public void GetOrderPaymentConcessionByOrderId(long ordersId)
        {
            model.PaymentConcessionList = new List<PaymentConcession>();
            model.PaymentConcessionList = orderService.GetOrderPaymentConcessionByOrderId(ordersId);
        }

        #region//订单冲减
        /// <summary>
        /// 名    称: GetOrderItemEmployeeListByOrderNo
        /// 功能概要: 根据订单号获取订单明细雇员列表
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日13:25:42
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        public void GetOrderItemEmployeeListByOrderNo(string orderNo) 
        {
            model.OrderItemEmployeeList = orderService.GetOrderItemEmployeeListByOrderNo(orderNo);
        }

        /// <summary>
        /// 名    称: GetOrderItemFactorValueListByOrderNO
        /// 功能概要: 根据订单号获取订单明细因素值列表
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日13:26:05
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        public void GetOrderItemFactorValueListByOrderNO(string orderNo) 
        {
            model.OrderItemFactorValueList = orderService.GetOrderItemFactorValueListByOrderNO(orderNo);
        }

        /// <summary>
        /// 名    称: GetOrderItemMortgageByOrderNo
        /// 功能概要: 根据订单号获取订单冲减明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月25日11:01:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetOrderItemMortgageByOrderNo(string orderNo) 
        {
            long orderId = SelectOrderIdByOrderNo(orderNo);
            model.OrderItemMortgageList = orderService.GetOrderItemMortgageByOrderNo(orderId);
        }

        /// <summary>
        /// 获取要输出的冲减订单信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2009年12月9日11:36:30
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public void SearchMortgageOrderPrint() 
        {
            model.OrderMortgageRecord = financeService.SearchMortgageOrderPrint();
        }
        
        /// <summary>
        /// 名    称: OrderMortgage
        /// 功能概要: 订单冲减
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日10:51:58
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        public void OrderMortgage() 
        {
            financeService.OrderMortgage(model);
        }
        #endregion

        #region//获取税费比列
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
        #endregion

        #region//获取前期修正的订单Id
        /// <summary>
        /// 根据订单号获取前期修正的订单Id
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月11日15:25:18
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long GetPhophaseOrderId(string orderNo) 
        {
            long orderId = 0;
            Order order=new Order();
            order.No="%"+orderNo+"%";
            order.CustomerId=ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeId;
            order.StatusList.Add(Constants.ORDER_STATUS_RECEPTING_VALUE.ToString());
            order.StatusList.Add(Constants.ORDER_STATUS_CONFIRM_VALUE.ToString());
            order.StatusList.Add(Constants.ORDER_STATUS_FACTURING_VALUE.ToString());
            orderId = orderService.GetPhophaseOrderId(order);
            return orderId; 
        }
        public Order GetOrderById(long orderId) 
        {
            return orderService.GetOrderById(orderId);
        }
        #endregion

        #region//获取订单明细的最大版本
         /// <summary>
        /// 获取订单明细版本最大值
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年3月5日10:19:10
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public int SelectOrderItemMaxVersion(string orderNo) 
        {
            if (null==orderNo || "" == orderNo) return 0;
            if(0==GetPhophaseOrderId(orderNo)) return 0;
            return orderService.SelectOrderItemMaxVersion(orderNo);
        }
        #endregion

        #region//获取分配员工的所有订单信息
        /// <summary>
        /// 获取分配员工的所有订单信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年4月2日16:56:02
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public void GetEmployeeReceptionOrderInfo(long employeeId) 
        {
            model.OrderItemTemp = orderService.GetEmployeeReceptionOrderInfo(employeeId);
        }
        #endregion

        #region//获取分配员工明细
        /// <summary>
        /// 获取分配员工明细
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年4月6日10:12:21
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public void GetReceptionOrderDetail(string lookType)
        {
            OrderItem oi = new OrderItem();
            if ("NotSubmited" == lookType)
            {
                oi.OrderStatusList.Add(Constants.ORDER_STATUS_RECEPTING_VALUE);
            }
            else if ("Sucessed" == lookType)
            {
                oi.OrderStatusList.Add(Constants.ORDER_STATUS_SUCCESSED_VALUE);
            }
            else if ("Submited" == lookType)
            {
                oi.OrderStatusList.Add(Constants.ORDER_STATUS_CONFIRM_VALUE);
                oi.OrderStatusList.Add(Constants.ORDER_STATUS_FINISHED_VALUE);
                oi.OrderStatusList.Add(Constants.ORDER_STATUS_FACTURING_VALUE);
                oi.OrderStatusList.Add(Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE);
            }
            long employeeId = ThreadLocalUtils.CurrentSession.CurrentUser.EmployeeId;
            oi.BusinessTypeId = employeeId;
            model.OrderList = orderService.GetReceptionOrderDetail(oi);
        }
        #endregion

        #region//根据根据条件(订单号其中一个)模糊查询订单信息      
        /// <summary>
        /// 模糊查询订单信息，若检索到多个订单则只返回其中的一个订单
        /// </summary>
        /// <param name="orderNo">订单号</param>
        /// <param name="isSucessed">是否是完成的订单</param>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年4月10日9:43:01
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public void BluringSearchOrderByOrderNo(string orderNo,bool isSucessed) 
        {
            model.NewOrder = orderService.BluringSearchOrderByOrderNo("%" + orderNo + "%",isSucessed);
        }
        #endregion

        #region //送货到期时间/到期颜色/过期颜色
        /// <summary>
        /// 获取送货到期时间/到期颜色/过期颜色
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年5月20日15:59:20
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public string GetDeliverMaturityTime 
        {
            get { return orderService.GetDeliverMaturityTime(); }
        }
        #endregion

        /// <summary>
        /// 根据选择的日期计算选项卡列表
        /// </summary>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年7月6日9:16:14
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void GetOptionCardList(int currentDateTime) 
        {
            model.DateList=orderService.GetOptionCardList(currentDateTime);
        }
    }
}
