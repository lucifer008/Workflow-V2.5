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
        private IApplicationProperty applicationProperty;
        public IApplicationProperty ApplicationProperty
        {
            set { applicationProperty = value; }
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

        #region ���ն����б�
        /// <summary>
        /// ��    ��: GetDailyOrderPager
        /// ���ܸ�Ҫ: ��ȡ���ն���
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public IList<Order> GetDailyOrderPager()
        {
            return orderService.SelectDailyOrderPager(model.NewOrder);
            //model.MemberCardBrushNumber = orderService.GetDailyOrderCount(model.NewOrder);
        }

        /// <summary>
        /// ��    ��: GetDailyOrderPager
        /// ���ܸ�Ҫ: ��ȡ���ն�������
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-9-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public int GetDailyOrderCount()
        {
            return orderService.GetDailyOrderCount(model.NewOrder);
        }

        /// <summary>
        /// ��ȡ���ն����б�Ĭ����ʾ������
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ�䣺2010��2��25��15:12:40
        /// ��������:
        /// ����ʱ�䣺
        /// </remarks>
        public int GetDisplayOrderInnerDayCount() 
        {
            return orderService.GetDisplayOrderInnerDayCount();
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
        /// ���ܸ�Ҫ: ���涩��
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
        /// ���ܸ�Ҫ: ���¶���
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

        #region ���䶩��
        /// <summary>
        /// ��    ��: DispatchOrder
        /// ���ܸ�Ҫ: ���䶩��
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

        /// <summary>
        /// ��    ��: NewDispatchOrder
        /// ���ܸ�Ҫ: ������-���䶩��
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��7��15:06:46
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public void NewDispatchOrder()
        {
            orderService.NewDispatchOrder(model.NewOrder, model.OrderStatusAlter, model.OrderItemEmployee);
        }
        #endregion
        #region//������-������ӡ
        ///// <summary>
        ///// ��    ��: AdmendmentPrint
        ///// ���ܸ�Ҫ: ������-������ӡ
        ///// ��    ��: ������
        ///// ����ʱ��: 2010��1��7��17:25:53
        ///// ��������: 
        ///// ����ʱ��: 
        ///// </summary>
        //public void AdmendmentPrint() 
        //{
        //    orderService.AdmendmentPrint(model.NewOrder,model.OrderStatusAlter);
        //}
        #endregion

        #region//������-���ض���
        /// <summary>
        /// ��    ��: ReturnOrder
        /// ���ܸ�Ҫ: ������-���ض���
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��8��10:05:09
        /// ��������: 
        /// ����ʱ��: 
        /// </summary>
        public void ReturnOrder() 
        {
            orderService.ReturnOrder(model.NewOrder, model.OrderStatusAlter);//,model.IsPrint,model.OrderItemIdArr);
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

        #region ���϶���
        /// <summary>
        /// ��    ��: BlankOutOrder
        /// ���ܸ�Ҫ: ���϶���
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

        #region �����Ӷ���
        /// <summary>
        /// ��    ��: RealFactureOrder
        /// ���ܸ�Ҫ: ʵ��(�޸ļӶ���)
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
        /// ���ܸ�Ҫ: ͨ�������Ų��Ҷ���ID
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
            if (null != model.NewOrder)
            {
                model.CustomerPayType = orderService.GetCustomerPayTypeByCustomerId(model.NewOrder.CustomerId);
                if (Constants.ORDER_STATUS_SUCCESSED_VALUE == model.NewOrder.Status)
                    model.PaymentConcessionList = orderService.GetOrderPaymentConcessionByOrderId(model.NewOrder.Id);
            }
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
        /// ���ܸ�Ҫ: ͨ�������Ų��Ҷ�����ϸ
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
        /// ���ܸ�Ҫ: ͨ�������Ų��Ҷ�����ϸID
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
        /// ���ܸ�Ҫ: ͨ�������Ų��Ҷ�����ϸӡ��Ҫ��
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
        /// ���ܸ�Ҫ: ͨ�������Ų��Ҷ�����ϸǰ���ڵĲ�����Ա
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
        /// ���ܸ�Ҫ: ͨ�������Ų��Ҷ�����ϸ���ص�ֵ
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
        /// ��ȡ������ʽ��ӡ�Ĵ���
        /// </summary>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��3��2��14:57:10
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public void GetOrderPrintCountByOrderNo(string strOrderNo) 
        {
            model.OrderPrintCount =orderService.GetOrderPrintCountByOrderNo(strOrderNo);
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

        #region ��ȡʵ�ʶ�����ϸ
        /// <summary>
        /// ��    ��: GetRealOrderItemAll
        /// ���ܸ�Ҫ: ͨ�������Ż�ȡʵ�ʶ�����ϸ��Ϣ
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
        /// ���ܸ�Ҫ: ���Ҷ�����ϸ�������Ա
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
        /// ��ȡ������Ҫ��Ԥ����Ķ���
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

        #region//�������
        /// <summary>
        /// ��    ��: GetOrderItemEmployeeListByOrderNo
        /// ���ܸ�Ҫ: ���ݶ����Ż�ȡ������ϸ��Ա�б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��11��23��13:25:42
        /// ����������
        /// ����ʱ�䣺
        /// </summary>
        public void GetOrderItemEmployeeListByOrderNo(string orderNo) 
        {
            model.OrderItemEmployeeList = orderService.GetOrderItemEmployeeListByOrderNo(orderNo);
        }

        /// <summary>
        /// ��    ��: GetOrderItemFactorValueListByOrderNO
        /// ���ܸ�Ҫ: ���ݶ����Ż�ȡ������ϸ����ֵ�б�
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��11��23��13:26:05
        /// ����������
        /// ����ʱ�䣺
        /// </summary>
        public void GetOrderItemFactorValueListByOrderNO(string orderNo) 
        {
            model.OrderItemFactorValueList = orderService.GetOrderItemFactorValueListByOrderNO(orderNo);
        }

        /// <summary>
        /// ��    ��: GetOrderItemMortgageByOrderNo
        /// ���ܸ�Ҫ: ���ݶ����Ż�ȡ���������ϸ
        /// ��    ��: ������
        /// ����ʱ��: 2009��11��25��11:01:34
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        public void GetOrderItemMortgageByOrderNo(string orderNo) 
        {
            long orderId = SelectOrderIdByOrderNo(orderNo);
            model.OrderItemMortgageList = orderService.GetOrderItemMortgageByOrderNo(orderId);
        }

        /// <summary>
        /// ��ȡҪ����ĳ��������Ϣ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��12��9��11:36:30
        /// ����������
        /// ����ʱ��:
        /// </remarks>
        public void SearchMortgageOrderPrint() 
        {
            model.OrderMortgageRecord = financeService.SearchMortgageOrderPrint();
        }
        
        /// <summary>
        /// ��    ��: OrderMortgage
        /// ���ܸ�Ҫ: �������
        /// ��    �ߣ�������
        /// ����ʱ��: 2009��11��23��10:51:58
        /// ����������
        /// ����ʱ�䣺
        /// </summary>
        public void OrderMortgage() 
        {
            financeService.OrderMortgage(model);
        }
        #endregion

        #region//��ȡ˰�ѱ���
        /// <summary>
        /// ��ȡ˰�ѱ���
        /// </summary>
        /// <returns></returns>
        ///<remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��12��16��18:03:56
        /// ����������
        /// ����ʱ��:
        ///</remarks>
        public string GetScotInverse() 
        {
            return applicationProperty.GetScotInverse();
        }
        #endregion

        #region//��ȡǰ�������Ķ���Id
        /// <summary>
        /// ���ݶ����Ż�ȡǰ�������Ķ���Id
        /// </summary>
        /// <param name="orderNo">������</param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��11��15:25:18
        /// ��������:
        /// ����ʱ��:
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

        #region//��ȡ������ϸ�����汾
         /// <summary>
        /// ��ȡ������ϸ�汾���ֵ
        /// </summary>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��3��5��10:19:10
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public int SelectOrderItemMaxVersion(string orderNo) 
        {
            if (null==orderNo || "" == orderNo) return 0;
            if(0==GetPhophaseOrderId(orderNo)) return 0;
            return orderService.SelectOrderItemMaxVersion(orderNo);
        }
        #endregion

        #region//��ȡ����Ա�������ж�����Ϣ
        /// <summary>
        /// ��ȡ����Ա�������ж�����Ϣ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��4��2��16:56:02
        /// ����������
        /// ����ʱ��:
        /// </remarks>
        public void GetEmployeeReceptionOrderInfo(long employeeId) 
        {
            model.OrderItemTemp = orderService.GetEmployeeReceptionOrderInfo(employeeId);
        }
        #endregion

        #region//��ȡ����Ա����ϸ
        /// <summary>
        /// ��ȡ����Ա����ϸ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��4��6��10:12:21
        /// ����������
        /// ����ʱ��:
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

        #region//���ݸ�������(����������һ��)ģ����ѯ������Ϣ      
        /// <summary>
        /// ģ����ѯ������Ϣ�������������������ֻ�������е�һ������
        /// </summary>
        /// <param name="orderNo">������</param>
        /// <param name="isSucessed">�Ƿ�����ɵĶ���</param>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��4��10��9:43:01
        /// ����������
        /// ����ʱ��:
        /// </remarks>
        public void BluringSearchOrderByOrderNo(string orderNo,bool isSucessed) 
        {
            model.NewOrder = orderService.BluringSearchOrderByOrderNo("%" + orderNo + "%",isSucessed);
        }
        #endregion

        #region //�ͻ�����ʱ��/������ɫ/������ɫ
        /// <summary>
        /// ��ȡ�ͻ�����ʱ��/������ɫ/������ɫ
        /// </summary>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��5��20��15:59:20
        /// ����������
        /// ����ʱ��:
        /// </remarks>
        public string GetDeliverMaturityTime 
        {
            get { return orderService.GetDeliverMaturityTime(); }
        }
        #endregion

        /// <summary>
        /// ����ѡ������ڼ���ѡ��б�
        /// </summary>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��7��6��9:16:14
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void GetOptionCardList(int currentDateTime) 
        {
            model.DateList=orderService.GetOptionCardList(currentDateTime);
        }
    }
}
