using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDER_ITEM ��Ӧ��Dao ʵ��
	/// </summary>
    public class OrderItemDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrderItem>, IOrderItemDao
    {

        #region IOrderItemDao ��Ա

        public IList<OrderItem> GetOrderItemByOrderNo(string strOrderNo)
        {
            OrderItem orderItem = new OrderItem();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItem.BranchShopId = user.BranchShopId;
            orderItem.CompanyId = user.CompanyId;
            orderItem.Values = strOrderNo;
            return base.sqlMap.QueryForList<OrderItem>("OrderItem.SelectOrderItemIDByOrderNo", orderItem);
        }
        public IList<OrderItem> GetOrderItemListByOrderNo(string strOrderNo)
        {
            OrderItem orderItem = new OrderItem();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItem.BranchShopId = user.BranchShopId;
            orderItem.CompanyId = user.CompanyId;
            orderItem.Values = strOrderNo;
            return base.sqlMap.QueryForList<OrderItem>("OrderItem.SelectOrderItemByOrderNo", orderItem);
        }
        public int GetOrderItemCount(string strOrderNo)
        {
            OrderItem orderItem = new OrderItem();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItem.BranchShopId = user.BranchShopId;
            orderItem.CompanyId = user.CompanyId;
            orderItem.Values = strOrderNo;
            return int.Parse(base.sqlMap.QueryForObject("OrderItem.SelectOrderItemCount", orderItem).ToString());
        }
        public IList<OrderItem> GetOrderItemFactorValueByOrderNo(string strOrderNo)
        {
            OrderItem orderItem = new OrderItem();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItem.BranchShopId = user.BranchShopId;
            orderItem.CompanyId = user.CompanyId;
            orderItem.Values = strOrderNo;
            return base.sqlMap.QueryForList<OrderItem>("OrderItem.SelectOrderItemFactorValueByOrderNo", orderItem);
        }
        public void DeleteOrderItemByOrderNo(string strOrderNo)
        {
            OrderItem orderItem = new OrderItem();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            orderItem.BranchShopId = user.BranchShopId;
            orderItem.CompanyId = user.CompanyId;
            orderItem.Values = strOrderNo;
            base.sqlMap.Delete("OrderItem.DeleteOrderItemByOrderNo", orderItem);
        }
        #endregion

        #region ͨ��OrdersId��ѯ��������
        public string SelectAmountByOrderId(long Id)
        {
            object obj = sqlMap.QueryForObject("OrderItem.SelectAmountByOrderId", Id);

            if (obj == null)
            {
                return "0";
            }

            return obj.ToString();
        }
        #endregion

        #region //���㶩��ʱ���¶�����ϸ
        /// <summary>
        /// ���㶩��ʱ���¶�����ϸ
        /// ��     ��:��ǿ
        /// ����ʱ��:2008-12-29
        /// ����������
        /// ����ʱ�䣺
        /// </summary>
        /// <param name="oi"></param>
        public void UpdateOrderItemForCloseOrder(OrderItem oi)
        {
            oi.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            oi.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            sqlMap.Update("OrderItem.UpdateOrderItemForCloseOrder", oi);
        }
        #endregion

        #region //��Ʊ��ȡ
        /// <summary>
        /// ���ն����� ��ѯǷ��Ʊ��Ϣ
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ��:2008-12-24
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public IList<Order> SearchTicketAmountInfoByOrderNo(Order order)
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //order.Status1 = Constants.POSITION_CASHER_VALUE;//������Id
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;//����ɵĶ���
            order.PaidTicket = Constants.TAKE_TICKET_STATUS_OWE;//Ƿ��Ʊ
            return sqlMap.QueryForList<Order>("OrderItem.SelectTicketAmountInfo", order);
        }

        /// <summary>
        /// ���ն�����ͳ��Ƿ��Ʊ��Ϣ���ܼ�¼��
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ��:2008-12-24
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public long SearchTicketAmountInfoByOrderNoTotal(Order order)
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //order.Status1 = Constants.POSITION_CASHER_VALUE;//������Id
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;//����ɵĶ���
            order.PaidTicket = Constants.TAKE_TICKET_STATUS_OWE;//Ƿ��Ʊ
            return sqlMap.QueryForObject<long>("OrderItem.SelectTicketAmountInfoTotal", order);
        }

        /// <summary>
        /// ���ն����� ��ѯǷ��ƱOrder(���)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ��:2009��11��30��15:39:16
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public IList<Order> SearchTicketAmountInfoPrintByOrderNo(Order order) 
        {
            return sqlMap.QueryForList<Order>("OrderItem.SearchTicketAmountInfoPrintByOrderNo", order);
        }

        /// <summary>
        /// ��ȡ��Ʊ:������ɺ󽫶����ķ�Ʊ״̬��Ϊ��
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ��:2008-12-24
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public void DrawTicket(Order order)
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //order.PaidTicket = Constants.TAKE_TICKET_STATUS_NOT_OWE;//��Ƿ��Ʊ
            //order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            sqlMap.Update("OrderItem.UpdateOrdersTicketStatus", order);
        }
        #endregion

        #region //���������ѯ
        /// <summary>
        /// ���������˲�ѯ�����տ���Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��15��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SearchOrderByCashPerson(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.Status2 = Convert.ToInt32(Constants.PAY_KIND_CLOSED_VALUE);//�����
            order.Status3 = Convert.ToInt32(Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//�յ���Ӧ�տ�
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//��Ա�����
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//�������
            order.OrderBlankOut = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//�������
            return sqlMap.QueryForList<Order>("OrderItemEmployee.SearchOrderByCashPerson", order);
        }
        /// <summary>
        /// ���������˲�ѯ�����տ���Ϣ��¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��15��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public long SearchOrderByCashPersonRowCount(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.Status2 = Convert.ToInt32(Constants.PAY_KIND_CLOSED_VALUE);//�����
            order.Status3 = Convert.ToInt32(Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//�յ���Ӧ�տ�
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//��Ա�����
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����
            //order.OrderFinished = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//�������
            return sqlMap.QueryForObject<long>("OrderItemEmployee.SearchOrderByCashPersonRowCount", order);
        }

        /// <summary>
        /// ���������˲�ѯ�����տ���Ϣ(��ӡ)
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��15��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SearchOrderByCashPersonPrint(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.Status2 = Convert.ToInt32(Constants.PAY_KIND_CLOSED_VALUE);//�����
            order.Status3 = Convert.ToInt32(Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//�յ���Ӧ�տ�
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//��Ա�����
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//�������
            order.OrderBlankOut = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//�������
            return sqlMap.QueryForList<Order>("OrderItemEmployee.SearchOrderByCashPersonPrint",order);
        }
        #endregion

		#region ��ȡδ��ɵĶ�������ؼ۸�������Ϣ Add Cry

		/// <summary>
		/// ��ȡδ��ɵĶ�������ؼ۸�������Ϣ
		/// </summary>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009-2-11
		/// </remarks>
		public IList<OrderItem> GetNotFinishedOrderWithInfo()
		{
			return sqlMap.QueryForList<OrderItem>("OrderItem.GetNotFinishedOrderWithInfo",null);
		}

		#endregion


        #region//�����Ѿ�������ϸ(Ӧ�տ�)
        /// <summary>
        /// �����Ѿ�������ϸ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��12��1��15:52:46
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SelectCustomerPaidAmountDetail(Order order)
        {
            return sqlMap.QueryForList<Order>("OrderItem.SelectCustomerPaidAmountDetail", order);
        }

        /// <summary>
        /// ���Ҷ���������ϸ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��2��5��10:52:15
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SelectOrderPaidAmountDetail(Order order) 
        {
            return sqlMap.QueryForList<Order>("OrderItem.SelectOrderPaidAmountDetail", order);
        }
        #endregion

        /// <summary>
        /// �����Ѿ�������ϸ��¼��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��12��1��15:52:46
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public long SelectCustomerPaidAmountDetailRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("OrderItem.SelectCustomerPaidAmountDetailRowCount", order);
        }

        /// <summary>
        /// ������Ƿ��Ķ�����¼��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��12��1��16:52:29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public long SelectCustomerOweMoneyDetailRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("OrderItem.SelectCustomerOweMoneyDetailRowCount", order);
        }

        /// <summary>
        /// ���ҿͻ�Ƿ��Ķ�����ϸ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��12��2��13:33:36
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> SelectCustomerOweMoneyDetail(Order order) 
        {
            return sqlMap.QueryForList<Order>("OrderItem.SelectCustomerOweMoneyDetail", order);
        }

        #region//���충��ͳ��
        /// <summary>
        /// ��ȡ����Ķ����б�������
        /// </summary>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ�䣺2009��12��5��9:56:48
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public IList<Order> SearchMatureOrderList(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            return sqlMap.QueryForList<Order>("OrderItem.SearchMatureOrderList", order);
        }

        /// <summary>
        /// ��ȡ����Ķ�����¼��
        /// </summary>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ�䣺2009��12��5��9:56:48
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public long SearchMatureOrderListRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("OrderItem.SearchMatureOrderListRowCount",order);
        }

        /// <summary>
        /// ��ȡ����ı���Ķ����б�
        /// </summary>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ�䣺2009��12��5��9:56:48
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public IList<Order> SearchMatureOrderPrintList(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            return sqlMap.QueryForList<Order>("OrderItem.SearchMatureOrderPrintList", order);
        }
        #endregion

        ///// <summary>
        ///// ���¶�����ϸ�����״̬
        ///// </summary>
        ///// <param name="orderItemIdArr"></param>
        ///// <remarks>
        ///// ��    �ߣ�������
        ///// ����ʱ�䣺2010��3��2��16:38:15
        ///// ����������
        ///// ����ʱ�䣺
        ///// </remarks>
        //public void UpdateOrderItemPrintStatus(string[] orderItemIdArr) 
        //{
        //    OrderItem oi = new OrderItem();
        //    foreach(string str in orderItemIdArr)
        //    {
        //        oi.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
        //        oi.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
        //        oi.Id = Convert.ToInt32(str);
        //        oi.Memo = Constants.ORDER_ITEM_PRINT_STATUS.ToString();
        //        sqlMap.Update("OrderItem.UpdateOrderItemPrintStatus", oi);
        //    }
        //}

        /// <summary>
        ///��ȡ��������ϸ�е����汾��
        /// </summary>
        /// <param name="orderNo"></param>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ�䣺2010��3��3��17:00:04
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public int SelectOrderItemMaxVersion(string orderNo) 
        {
            OrderItem oi = new OrderItem();
            oi.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            oi.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            oi.Memo = orderNo;
            return sqlMap.QueryForObject<int>("OrderItem.SelectOrderItemMaxVersion", oi);
        }

        /// <summary>
        ///����һ��������ϸ
        /// </summary>
        /// <param name="orderNo"></param>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ�䣺2010��3��3��17:20:56
        /// ����������
        /// ����ʱ�䣺
        /// </remarks>
        public void InsertOrderItem(OrderItem orderItem) 
        {
            orderItem.Deleted = '0';
            orderItem.UpdateUser = 0;
            orderItem.InsertDateTime = DateTime.Now;
            orderItem.UpdateDateTime = DateTime.Now;
            orderItem.InsertUser = ThreadLocalUtils.CurrentSession.CurrentUser.Id;
            orderItem.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            orderItem.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            sqlMap.Insert("OrderItem.InsertOrderItem", orderItem);
        }

        /// <summary>
        /// ��ȡ����Ա�������ж�����Ϣ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��4��2��16:56:02
        /// �������������ʱ���
        /// ����ʱ��: 2010��4��9��14:20
        /// </remarks>
        public OrderItem GetEmployeeReceptionOrderInfo(long employeeId) 
        {
            OrderItem oi = new OrderItem();
            oi.BusinessTypeId = employeeId;//�Ӵ��˹�ԱId
            oi.StatusSucessed = Constants.ORDER_STATUS_SUCCESSED_VALUE;//�����
            oi.StatusNotSubmited = Constants.ORDER_STATUS_RECEPTING_VALUE;//δ�ύ
            //oi.StatusSubmited = Constants.ORDER_STATUS_CONFIRM_VALUE;//���ύ
            oi.OrderStatusList.Add(Constants.ORDER_STATUS_CONFIRM_VALUE);
            oi.OrderStatusList.Add(Constants.ORDER_STATUS_FINISHED_VALUE);
            oi.OrderStatusList.Add(Constants.ORDER_STATUS_FACTURING_VALUE);
            oi.OrderStatusList.Add(Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE);
            oi.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            oi.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;

			oi.BeginDateTime = DateTime.Now.Date;
			oi.EndDateTime = oi.BeginDateTime.AddDays(1);
            return sqlMap.QueryForObject<OrderItem>("OrderItem.GetEmployeeReceptionOrderInfo", oi);
        }

        /// <summary>
        /// ��ȡ����Ա����ϸ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��4��6��10:21:49
        /// ����������
        /// ����ʱ��:
        /// </remarks>
        public IList<Order> GetReceptionOrderDetail(OrderItem oi) 
        {
            oi.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            oi.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Order>("OrderItem.GetReceptionOrderDetail", oi);
        }

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
        public Order BluringSearchOrderByOrderNo(string orderNo, bool isSucessed)
        {
            OrderItem oi = new OrderItem();
            oi.Name = orderNo;
            if (isSucessed) { oi.Memo = "�����"; oi.StatusSucessed = Constants.ORDER_STATUS_SUCCESSED_VALUE; }
            oi.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            oi.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<Order>("OrderItem.BluringSearchOrderByOrderNo", oi);
        }

        /// <summary>
        /// ���ݹ���Id��ȡ����״̬
        /// </summary>
        /// <remarks>
        /// ��    �ߣ�������
        /// ����ʱ��: 2010��6��8��15:58:20
        /// ����������
        /// ����ʱ��:
        /// </remarks>
        public int GetOrderStatusByOrderId(long orderId) 
        {
            return sqlMap.QueryForObject<int>("OrderItem.GetOrderStatusByOrderId", orderId);
        }
    }
}
