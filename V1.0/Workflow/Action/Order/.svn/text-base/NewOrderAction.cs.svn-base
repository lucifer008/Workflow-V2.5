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

        #region 本日工单列表
        /// <summary>
        /// 名    称: GetDailyOrderPager
        /// 功能概要: 获取本日工单
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public void GetDailyOrderPager()
        {
            model.DailyOrder = orderService.SelectDailyOrderPager(model.NewOrder);
        }
        /// <summary>
        /// 名    称: GetDailyOrderPager
        /// 功能概要: 获取本日工单总数
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public int GetDailyOrderCount()
        {
            return orderService.GetDailyOrderCount(model.NewOrder);
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

        #region 工单开单
        /// <summary>
        /// 名    称: AddOrder
        /// 功能概要: 保存工单
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
        /// 功能概要: 更新工单
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


        #region 工单返工
        /// <summary>
        /// 名    称: ReDoOrder
        /// 功能概要: 返工
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="orderStatusFlag">工单状态</param>
        public void RedoOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.ReDoOrder(model.OrderStatusAlter, model.OrdersDuty, model.OrderItemEmployee, model.RelationEmployeeList, model.DutyEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region 分配工单
        /// <summary>
        /// 名    称: DispatchOrder
        /// 功能概要: 分配工单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployeeList">工单明细的参与人员</param>
        /// <param name="orderStatusAlter">工单状态的变更履历</param>
        /// <param name="relationEmployeeList">工单状态变更的相关人员</param>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="OrderStatusFlag">工单状态</param>
        public void DispatchOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.DispatchOrder(model.OrderItemEmployee, model.OrderStatusAlter, model.RelationEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region 工单完工
        /// <summary>
        /// 名    称: FinishOrder
        /// 功能概要: 完工
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="orderStatusFlag">工单状态</param>
        public void FinishOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.FinishOrder(model.OrderItemEmployee, model.OrderStatusAlter, model.RelationEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region 作废工单
        /// <summary>
        /// 名    称: BlankOutOrder
        /// 功能概要: 作废工单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="orderStatusFlag">工单状态</param>
        public void BlankOutOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.BlankOutOrder(model.OrderStatusAlter, model.RelationEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region 修正加工单
        /// <summary>
        /// 名    称: RealFactureOrder
        /// 功能概要: 实际(修改加工单)
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
        /// 功能概要: 通过工单号删除工单雇员
        /// 作    者: 付强
        /// 创建时间: 2008-9-26
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
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
        /// <param name="strOrderNo">工单号</param>
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
        /// <param name="orderNo">工单号</param>
        public void TrashPaperRecord(string orderNo)
        {
            orderService.TrashPaperRecord(model.RealOrderItemList, model.TrashPaperEmployeeList, model.RealOrderItemTrashReason, model.OrderStatusAlter, orderNo);
        }
        #endregion


        #endregion

        #region 获取工单信息
        /// <summary>
        /// 名    称: SelectOrderIdByOrderNo
        /// 功能概要: 通过工单号查找工单ID
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        public long SelectOrderIdByOrderNo(string strOrderNo)
        {
            return orderService.SelectOrderIdByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderInfo
        /// 功能概要: 通过工单号获取工单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        public void GetOrderInfo(string strOrderNo)
        {
            GetOrderItemIDByOrderNo(strOrderNo);
            GetOrderByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: 
        /// 功能概要: 通过工单号获取工单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        public void GetOrderByOrderNo(string strOrderNo)
        {
            model.NewOrder = orderService.GetOrderInfoByOrderNo(strOrderNo);
            model.CustomerPayType = orderService.GetCustomerPayTypeByCustomerId(model.NewOrder.CustomerId);
            
        }
        /// <summary>
        /// 名    称: GetOrderItemIDByOrderNo
        /// 功能概要: 通过工单号获取工单明细
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        public void GetOrderItemIDByOrderNo(string strOrderNo)
        {
            model.OrderItemList = masterDataService.GetOrderItemIDByOrderNo(strOrderNo);
        }

        /// <summary>
        /// 名    称: GetOrderItemListByOrderNo
        /// 功能概要: 通过工单号查找工单明细
        /// 作    者: 付强
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        public void GetOrderItemListByOrderNo(string strOrderNo)
        {
            model.OrderItemList = orderService.GetOrderItemListByOrderNo(strOrderNo);
            model.OrderItem = model.OrderItemList;
        }
        /// <summary>
        /// 名    称: GetOrderItemByOrderNo
        /// 功能概要: 通过工单号查找工单明细ID
        /// 作    者: 付强
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        public void GetOrderItemByOrderNo(string strOrderNo)
        {
            model.OrderItem = orderService.GetOrderItemByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemPrintRequeireDetail
        /// 功能概要: 通过工单号查找工单明细印制要求
        /// 作    者: 付强
        /// 创建时间: 2007-9-30
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        public void GetOrderItemPrintRequeireDetail(string strOrderNo)
        {
            model.OrderItemPrintRequireDetailList = orderService.GetOrderItemPrintRequireByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemEmployeeByOrderNo
        /// 功能概要: 通过工单号查找工单明细前后期的参与人员
        /// 作    者: 付强
        /// 创建时间: 2008-11-01
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        public void GetOrderItemEmployeeByOrderNo(string strOrderNo)
        {
            model.OrderItemEmployee = orderService.GetOrderItemEmployeeByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemFactorValueByOrderNo
        /// 功能概要: 通过工单号查找工单明细因素的值
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
        /// 名    称: SelectOldEmployee
        /// 功能概要: 获取原工单雇员信息
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

        #region 获取实际工单明细
        /// <summary>
        /// 名    称: GetRealOrderItemAll
        /// 功能概要: 通过工单号获取实际工单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="orderNo">工单号</param>
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
        /// 功能概要: 通过工单号获取工单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="orderNo">工单号</param>
        public void GetOrderItemAll(string orderNo)
        {
            model.OrderItem = orderService.GetCashOrderItemByOrderId(orderNo);
            model.OrderItemList = orderService.GetCashOrderItemFactorValueByOrderId(orderNo);
            model.OrderItemPrintRequireDetail = orderService.GetCashOrderItemPrintRequire(orderNo);
            model.OrderItemEmployeeList = orderService.GetCashOrderItemEmployeebyOrderId(orderNo);
        }
        /// <summary>
        /// 名    称: SelectOrderItemEmployee
        /// 功能概要: 查找工单明细的相关人员
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
        /// 功能概要: 核销工单送货
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
        /// <param name="orderStatusFlag">工单状态</param>
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
        /// 功能概要: 通过工单号获取送货状态工单       
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">工单号</param>
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
        /// 获取所有需要交预付款的工单
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
        /// 获取工单下实际已预付款
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


    }
}
