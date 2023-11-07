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
    /// ��    ��: NewOrderAction
    /// ���ܸ�Ҫ: ���������Action
    /// ��    ��: ��ǿ
    /// ����ʱ��: 2007-9-13
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public sealed class NewOrderAction : BaseAction
    {
        #region ���Ա
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

        #region ��ʼ����������
        /// <summary>
        /// ��    ��: InitMasterData
        /// ���ܸ�Ҫ: ��ʼ����������
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
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

        #region ���չ����б�
        /// <summary>
        /// ��    ��: GetDailyOrderPager
        /// ���ܸ�Ҫ: ��ȡ���չ���
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void GetDailyOrderPager()
        {
            model.DailyOrder = orderService.SelectDailyOrderPager(model.NewOrder);
        }
        /// <summary>
        /// ��    ��: GetDailyOrderPager
        /// ���ܸ�Ҫ: ��ȡ���չ�������
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public int GetDailyOrderCount()
        {
            return orderService.GetDailyOrderCount(model.NewOrder);
        }
        #endregion

        #region �۸�����
        /// <summary>
        /// ��    ��: GetActiveRelation
        /// ���ܸ�Ҫ: ��ȡ��̬����
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name=""></param>
        public void GetActiveRelation()
        {
            model.PriceFactor = selectActiveFactorService.GetRelatedPrice(model.Factorrelation);
        }
        /// <summary>
        /// ��    ��: GetFactorValue
        /// ��ȡ�۸����ص��ı�ֵ
        /// ��    ��: ��ǿ��
        /// ����ʱ��: 2007-10-6
        /// ��������:
        /// ����ʱ��: 2007-10-13
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
        /// ��ȡ�۸����ص��ı�ֵ
        /// ��    ��: 
        /// ����ʱ��: 2007-10-6
        /// �� �� ��: ��ǿ��
        /// ����ʱ��: 2007-10-13
        /// ��    ��: ��������
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

        #region ��ȡ�۸�
        /// <summary>
        /// ��ȡ�۸�
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ��
        /// ����ʱ��: 2007-10-6
        /// �� �� ��: ��ǿ��
        /// ����ʱ��: 2008-11-12
        /// ��������:
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

        #region ��ȡ������
        /// <summary>
        /// ��    ��: GetAmountSegmentList
        /// ���ܸ�Ҫ: ��ȡ������
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2009-1-4
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void GetAmountSegmentList()
        {
            model.AmountSegmentList = priceService.GetAmountSegmentList();
        }
        #endregion

        #region ��������
        /// <summary>
        /// ��    ��: AddOrder
        /// ���ܸ�Ҫ: ���湤��
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name=""></param>
        public void AddOrder()
        {
            orderService.SaveOrder(model.NewOrder, model.OrderStatusAlter, model.LinkMan, model.Customer);
        }
        /// <summary>
        /// ��    ��: UpdateOrder
        /// ���ܸ�Ҫ: ���¹���
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name=""></param>
        public void UpdateOrder()
        {
            orderService.UpdateOrder(model.NewOrder);
        }


        #region ��������
        /// <summary>
        /// ��    ��: ReDoOrder
        /// ���ܸ�Ҫ: ����
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-26
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo">������</param>
        /// <param name="orderStatusFlag">����״̬</param>
        public void RedoOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.ReDoOrder(model.OrderStatusAlter, model.OrdersDuty, model.OrderItemEmployee, model.RelationEmployeeList, model.DutyEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region ���乤��
        /// <summary>
        /// ��    ��: DispatchOrder
        /// ���ܸ�Ҫ: ���乤��
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-26
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="orderItemEmployeeList">������ϸ�Ĳ�����Ա</param>
        /// <param name="orderStatusAlter">����״̬�ı������</param>
        /// <param name="relationEmployeeList">����״̬����������Ա</param>
        /// <param name="strOrderNo">������</param>
        /// <param name="OrderStatusFlag">����״̬</param>
        public void DispatchOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.DispatchOrder(model.OrderItemEmployee, model.OrderStatusAlter, model.RelationEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region �����깤
        /// <summary>
        /// ��    ��: FinishOrder
        /// ���ܸ�Ҫ: �깤
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-26
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo">������</param>
        /// <param name="orderStatusFlag">����״̬</param>
        public void FinishOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.FinishOrder(model.OrderItemEmployee, model.OrderStatusAlter, model.RelationEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region ���Ϲ���
        /// <summary>
        /// ��    ��: BlankOutOrder
        /// ���ܸ�Ҫ: ���Ϲ���
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-26
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo">������</param>
        /// <param name="orderStatusFlag">����״̬</param>
        public void BlankOutOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.BlankOutOrder(model.OrderStatusAlter, model.RelationEmployeeList, strOrderNo, orderStatusFlag);
        }
        #endregion

        #region �����ӹ���
        /// <summary>
        /// ��    ��: RealFactureOrder
        /// ���ܸ�Ҫ: ʵ��(�޸ļӹ���)
        /// ��    ��: ��ǿ��
        /// ����ʱ��: 2007-10-10
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void RealFactureOrder()
        {
            orderService.RealFactureOrder(model.NewOrder, model.OrderStatusAlter);
            //��Ա������ʱ
            orderService.UpdateMemberCardConsume(model.MemberCardConcession, model.MemberCard);
        }
        /// <summary>
        /// ��    ��: DispatchDeleteOrderItemEmployeeByOrderNo
        /// ���ܸ�Ҫ: ͨ��������ɾ��������Ա
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2008-9-26
        /// ��������:
        /// ����ʱ��:        
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public void DispatchDeleteOrderItemEmployeeByOrderNo(string strOrderNo)
        {
            orderService.DispatchDeleteOrderItemEmployeeByOrderNo(strOrderNo);
        }
        #endregion

        #region ƴ��
        /// <summary>
        /// ��    ��: PatchUpOrder
        /// ���ܸ�Ҫ: ƴ��
        /// ��    ��: ��ǿ��
        /// ����ʱ��: 2007-10-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public void PatchUpOrder(string strOrderNo)
        {
            orderService.PatchUpOrder(model.RealOrderItem, model.OrderStatusAlter, strOrderNo);
        }
        #endregion

        #region ���ŵǼ�
        /// <summary>
        /// ��    ��: TrashPaperRecord
        /// ���ܸ�Ҫ: ���ŵǼ�
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-13
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="orderNo">������</param>
        public void TrashPaperRecord(string orderNo)
        {
            orderService.TrashPaperRecord(model.RealOrderItemList, model.TrashPaperEmployeeList, model.RealOrderItemTrashReason, model.OrderStatusAlter, orderNo);
        }
        #endregion


        #endregion

        #region ��ȡ������Ϣ
        /// <summary>
        /// ��    ��: SelectOrderIdByOrderNo
        /// ���ܸ�Ҫ: ͨ�������Ų��ҹ���ID
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-26
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public long SelectOrderIdByOrderNo(string strOrderNo)
        {
            return orderService.SelectOrderIdByOrderNo(strOrderNo);
        }
        /// <summary>
        /// ��    ��: GetOrderInfo
        /// ���ܸ�Ҫ: ͨ�������Ż�ȡ������Ϣ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public void GetOrderInfo(string strOrderNo)
        {
            GetOrderItemIDByOrderNo(strOrderNo);
            GetOrderByOrderNo(strOrderNo);
        }
        /// <summary>
        /// ��    ��: 
        /// ���ܸ�Ҫ: ͨ�������Ż�ȡ������Ϣ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public void GetOrderByOrderNo(string strOrderNo)
        {
            model.NewOrder = orderService.GetOrderInfoByOrderNo(strOrderNo);
            model.CustomerPayType = orderService.GetCustomerPayTypeByCustomerId(model.NewOrder.CustomerId);
            
        }
        /// <summary>
        /// ��    ��: GetOrderItemIDByOrderNo
        /// ���ܸ�Ҫ: ͨ�������Ż�ȡ������ϸ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public void GetOrderItemIDByOrderNo(string strOrderNo)
        {
            model.OrderItemList = masterDataService.GetOrderItemIDByOrderNo(strOrderNo);
        }

        /// <summary>
        /// ��    ��: GetOrderItemListByOrderNo
        /// ���ܸ�Ҫ: ͨ�������Ų��ҹ�����ϸ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-30
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public void GetOrderItemListByOrderNo(string strOrderNo)
        {
            model.OrderItemList = orderService.GetOrderItemListByOrderNo(strOrderNo);
            model.OrderItem = model.OrderItemList;
        }
        /// <summary>
        /// ��    ��: GetOrderItemByOrderNo
        /// ���ܸ�Ҫ: ͨ�������Ų��ҹ�����ϸID
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-30
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public void GetOrderItemByOrderNo(string strOrderNo)
        {
            model.OrderItem = orderService.GetOrderItemByOrderNo(strOrderNo);
        }
        /// <summary>
        /// ��    ��: GetOrderItemPrintRequeireDetail
        /// ���ܸ�Ҫ: ͨ�������Ų��ҹ�����ϸӡ��Ҫ��
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-30
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public void GetOrderItemPrintRequeireDetail(string strOrderNo)
        {
            model.OrderItemPrintRequireDetailList = orderService.GetOrderItemPrintRequireByOrderNo(strOrderNo);
        }
        /// <summary>
        /// ��    ��: GetOrderItemEmployeeByOrderNo
        /// ���ܸ�Ҫ: ͨ�������Ų��ҹ�����ϸǰ���ڵĲ�����Ա
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2008-11-01
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name="strOrderNo">������</param>
        public void GetOrderItemEmployeeByOrderNo(string strOrderNo)
        {
            model.OrderItemEmployee = orderService.GetOrderItemEmployeeByOrderNo(strOrderNo);
        }
        /// <summary>
        /// ��    ��: GetOrderItemFactorValueByOrderNo
        /// ���ܸ�Ҫ: ͨ�������Ų��ҹ�����ϸ���ص�ֵ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-8
        /// ��������: 
        /// ����ʱ��: 
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
        /// ��    ��: SelectOldEmployee
        /// ���ܸ�Ҫ: ��ȡԭ������Ա��Ϣ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name=""></param>
        public void SelectOldEmployee()
        {
            model.OrderItemEmployee = orderService.SelectOldEmployee(model.OrderItemEmployee[0]);
        }
        #endregion

        #region ��ȡʵ�ʹ�����ϸ
        /// <summary>
        /// ��    ��: GetRealOrderItemAll
        /// ���ܸ�Ҫ: ͨ�������Ż�ȡʵ�ʹ�����ϸ��Ϣ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="orderNo">������</param>
        public void GetRealOrderItemAll(string orderNo)
        {
            long id = this.SelectOrderIdByOrderNo(orderNo);
            model.RealOrderItem = orderService.GetRealOrderItemByOrderId(id);
            model.RealOrderItemList = orderService.GetRealOrderItemFactorValueByOrderId(id);
            model.RealOrderItemPrintRequire = orderService.GetRealOrderItemPrintRequire(id);
            model.RealOrderItemEmployeeList = orderService.GetRealOrderItemEmployeebyOrderId(id);
        }

        /// <summary>
        /// ��    ��: GetOrderItemAll
        /// ���ܸ�Ҫ: ͨ�������Ż�ȡ������ϸ��Ϣ
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="orderNo">������</param>
        public void GetOrderItemAll(string orderNo)
        {
            model.OrderItem = orderService.GetCashOrderItemByOrderId(orderNo);
            model.OrderItemList = orderService.GetCashOrderItemFactorValueByOrderId(orderNo);
            model.OrderItemPrintRequireDetail = orderService.GetCashOrderItemPrintRequire(orderNo);
            model.OrderItemEmployeeList = orderService.GetCashOrderItemEmployeebyOrderId(orderNo);
        }
        /// <summary>
        /// ��    ��: SelectOrderItemEmployee
        /// ���ܸ�Ҫ: ���ҹ�����ϸ�������Ա
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-2
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public void SelectOrderItemEmployee()
        {
            model.OrderItemEmployee = orderService.SelectOrderItemEmployee(model.OrderItemEmployee[0]);
        }
        #endregion
        
        #region �ͻ�
        /// <summary>
        /// ��    ��: DeliveryOrder
        /// ���ܸ�Ҫ: �ͻ�����
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-30
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public void DeliveryOrder(string strOrderNo, int orderStatusFlag)
        {
            orderService.DeliveryOrder(model.DeliveryOrderList);
            orderService.UpdateOrderStatusByOrderNo(strOrderNo, orderStatusFlag);
        }
        /// <summary>
        /// ��    ��: CancelAfterVerification
        /// ���ܸ�Ҫ: ���������ͻ�
        /// ��    ��: ��ǿ��
        /// ����ʱ��: 2007-10-5
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="strOrderNo">������</param>
        /// <param name="orderStatusFlag">����״̬</param>
        /// <param name="deliveryStatus">�ͻ�״̬</param>
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
        /// ��    ��: GetDeliveryOrderByOrderNo
        /// ���ܸ�Ҫ: ͨ�������Ż�ȡ�ͻ�״̬����       
        /// ��    ��: ��ǿ��
        /// ����ʱ��: 2007-10-5
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="strOrderNo">������</param>
        /// <returns></returns>
        /// <remarks>
        public void GetDeliveryOrderByOrderNo(string strOrderNo)
        {
            model.DeliveryOrderList.Add(orderService.GetDeliveryOrder(strOrderNo));
        }
        #endregion

        #region ��ȡ�����û�
        /// <summary>
        /// ��    ��: GetAllUser
        /// ���ܸ�Ҫ: ��ȡ�����û�       
        /// ��    ��: ��ǿ��
        /// ����ʱ��: 2007-10-5
        /// ��������:
        /// ����ʱ��:
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
        /// ��ȡ������Ҫ��Ԥ����Ĺ���
        /// </summary>
        public void GetAllNeedPrePayOrders()
        {
            model.OrderList = orderService.GetAllNeedPrePayOrders(model.NewOrder);
            model.NeedPrePayOrdersCount = orderService.GetAllNeedPrePayOrdersCount(model.NewOrder);
            model.NewOrder=orderService.GetOrderPrepayAmountTotalAndSumAmountTotal(model.NewOrder);//�ϼƶ����ܽ����Ԥ���ܽ��
        }

        public void GetAllNeedPrePayOrdersCount()
        {
            model.NeedPrePayOrdersCount = orderService.GetAllNeedPrePayOrdersCount(model.NewOrder);
        }


        /// <summary>
        /// ��ȡ������ʵ����Ԥ����
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public decimal GetPrePayAmount(Workflow.Da.Domain.Order order)
        {
            return orderService.GetPrePayAmount(order);
        }

        /// <summary>
        /// ����ĳһ����Ա���µ��Żݻ
        /// </summary>
        /// <param name="model">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </remarks>	
        public void SelectMemberCardConcessionByPriceIdAndConcessionId()
        {
            model.MemberCardConcessionList = orderService.SelectMemberCardConcessionByPriceIdAndConcessionId(model.MemberCardConcession);
        }

        #region ��ѯ��Ա����ˢ������
        /// <summary>
        /// ��ѯ��Ա����ˢ������
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-23
        /// ��������:
        /// ����ʱ��:
        /// </remarks>	
        public void SearchMemberCardBrushNumber()
        {
            model.MemberCardBrushNumber = orderService.SearchMemberCardBrushNumber(model.NewOrder.MemberCardNo);
        }
        #endregion
        /// ͨ����Ա���Ų�����ؿͻ���Ϣ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-23
        /// ��������:
        /// ����ʱ��:
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
        /// ��    ��: GetOperatorList
        /// ���ܸ�Ҫ: ��ȡ�������б�
        /// ��    ��: ������
        /// ����ʱ��: 2007-12-10
        /// ��������: 
        /// ����ʱ��: 
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
