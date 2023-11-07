using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table ORDER_ITEM 对应的Dao 实现
	/// </summary>
    public class OrderItemDaoImpl : Workflow.Da.Base.DaoBaseImpl<OrderItem>, IOrderItemDao
    {

        #region IOrderItemDao 成员

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

        #region 通过OrdersId查询工单数量
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

        #region //结算工单时更新工单明细
        /// <summary>
        /// 结算工单时更新工单明细
        /// 作     者:付强
        /// 创建时间:2008-12-29
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        /// <param name="oi"></param>
        public void UpdateOrderItemForCloseOrder(OrderItem oi)
        {
            oi.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            oi.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            sqlMap.Update("OrderItem.UpdateOrderItemForCloseOrder", oi);
        }
        #endregion

        #region //发票领取
        /// <summary>
        /// 按照工单号 查询欠发票信息
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public IList<Order> SearchTicketAmountInfoByOrderNo(Order order)
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //order.Status1 = Constants.POSITION_CASHER_VALUE;//收银人Id
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;//已完成的工单
            order.PaidTicket = Constants.TAKE_TICKET_STATUS_OWE;//欠发票
            return sqlMap.QueryForList<Order>("OrderItem.SelectTicketAmountInfo", order);
        }

        /// <summary>
        /// 按照工单号统计欠发票信息的总记录数
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public long SearchTicketAmountInfoByOrderNoTotal(Order order)
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //order.Status1 = Constants.POSITION_CASHER_VALUE;//收银人Id
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;//已完成的工单
            order.PaidTicket = Constants.TAKE_TICKET_STATUS_OWE;//欠发票
            return sqlMap.QueryForObject<long>("OrderItem.SelectTicketAmountInfoTotal", order);
        }

        /// <summary>
        /// 领取发票:操作完成后将工单的发票状态改为否
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public void DrawTicket(Order order)
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            //order.PaidTicket = Constants.TAKE_TICKET_STATUS_NOT_OWE;//不欠发票
            //order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            sqlMap.Update("OrderItem.UpdateOrdersTicketStatus", order);
        }
        #endregion

        #region //收银当班查询
        /// <summary>
        /// 按照收银人查询工单收款信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Order> SearchOrderByCashPerson(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.Status2 = Convert.ToInt32(Constants.PAY_KIND_CLOSED_VALUE);//结算款
            order.Status3 = Convert.ToInt32(Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//收到的应收款
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减
            return sqlMap.QueryForList<Order>("OrderItemEmployee.SearchOrderByCashPerson", order);
        }
        /// <summary>
        /// 按照收银人查询工单收款信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long SearchOrderByCashPersonRowCount(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.Status2 = Convert.ToInt32(Constants.PAY_KIND_CLOSED_VALUE);//结算款
            order.Status3 = Convert.ToInt32(Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//收到的应收款
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减
            return sqlMap.QueryForObject<long>("OrderItemEmployee.SearchOrderByCashPersonRowCount", order);
        }

        /// <summary>
        /// 按照收银人查询工单收款信息(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Order> SearchOrderByCashPersonPrint(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.Status2 = Convert.ToInt32(Constants.PAY_KIND_CLOSED_VALUE);//结算款
            order.Status3 = Convert.ToInt32(Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//收到的应收款
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减
            return sqlMap.QueryForList<Order>("OrderItemEmployee.SearchOrderByCashPersonPrint",order);
        }
        #endregion

		#region 获取未完成的订单及相关价格因素信息 Add Cry

		/// <summary>
		/// 获取未完成的订单及相关价格因素信息
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-2-11
		/// </remarks>
		public IList<OrderItem> GetNotFinishedOrderWithInfo()
		{
			return sqlMap.QueryForList<OrderItem>("OrderItem.GetNotFinishedOrderWithInfo",null);
		}

		#endregion
	}
}
