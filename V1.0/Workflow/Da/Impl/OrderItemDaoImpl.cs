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

        #region //���㹤��ʱ���¹�����ϸ
        /// <summary>
        /// ���㹤��ʱ���¹�����ϸ
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
        /// ���չ����� ��ѯǷ��Ʊ��Ϣ
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
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;//����ɵĹ���
            order.PaidTicket = Constants.TAKE_TICKET_STATUS_OWE;//Ƿ��Ʊ
            return sqlMap.QueryForList<Order>("OrderItem.SelectTicketAmountInfo", order);
        }

        /// <summary>
        /// ���չ�����ͳ��Ƿ��Ʊ��Ϣ���ܼ�¼��
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
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;//����ɵĹ���
            order.PaidTicket = Constants.TAKE_TICKET_STATUS_OWE;//Ƿ��Ʊ
            return sqlMap.QueryForObject<long>("OrderItem.SelectTicketAmountInfoTotal", order);
        }

        /// <summary>
        /// ��ȡ��Ʊ:������ɺ󽫹����ķ�Ʊ״̬��Ϊ��
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
	}
}
