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

        #region 通过OrdersId查询订单数量
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

        #region //结算订单时更新订单明细
        /// <summary>
        /// 结算订单时更新订单明细
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
        /// 按照订单号 查询欠发票信息
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
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;//已完成的订单
            order.PaidTicket = Constants.TAKE_TICKET_STATUS_OWE;//欠发票
            return sqlMap.QueryForList<Order>("OrderItem.SelectTicketAmountInfo", order);
        }

        /// <summary>
        /// 按照订单号统计欠发票信息的总记录数
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
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;//已完成的订单
            order.PaidTicket = Constants.TAKE_TICKET_STATUS_OWE;//欠发票
            return sqlMap.QueryForObject<long>("OrderItem.SelectTicketAmountInfoTotal", order);
        }

        /// <summary>
        /// 按照订单号 查询欠发票Order(输出)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2009年11月30日15:39:16
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public IList<Order> SearchTicketAmountInfoPrintByOrderNo(Order order) 
        {
            return sqlMap.QueryForList<Order>("OrderItem.SearchTicketAmountInfoPrintByOrderNo", order);
        }

        /// <summary>
        /// 领取发票:操作完成后将订单的发票状态改为否
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
        /// 按照收银人查询订单收款信息
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
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//订单冲减
            order.OrderBlankOut = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//舍入多收
            return sqlMap.QueryForList<Order>("OrderItemEmployee.SearchOrderByCashPerson", order);
        }
        /// <summary>
        /// 按照收银人查询订单收款信息记录数
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
            //order.OrderFinished = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//舍入多收
            return sqlMap.QueryForObject<long>("OrderItemEmployee.SearchOrderByCashPersonRowCount", order);
        }

        /// <summary>
        /// 按照收银人查询订单收款信息(打印)
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
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//订单冲减
            order.OrderBlankOut = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//舍入多收
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


        #region//查找已经付款明细(应收款)
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
        public IList<Order> SelectCustomerPaidAmountDetail(Order order)
        {
            return sqlMap.QueryForList<Order>("OrderItem.SelectCustomerPaidAmountDetail", order);
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
        public IList<Order> SelectOrderPaidAmountDetail(Order order) 
        {
            return sqlMap.QueryForList<Order>("OrderItem.SelectOrderPaidAmountDetail", order);
        }
        #endregion

        /// <summary>
        /// 查找已经付款明细记录数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月1日15:52:46
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long SelectCustomerPaidAmountDetailRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("OrderItem.SelectCustomerPaidAmountDetailRowCount", order);
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
        public long SelectCustomerOweMoneyDetailRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("OrderItem.SelectCustomerOweMoneyDetailRowCount", order);
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
        public IList<Order> SelectCustomerOweMoneyDetail(Order order) 
        {
            return sqlMap.QueryForList<Order>("OrderItem.SelectCustomerOweMoneyDetail", order);
        }

        #region//报红订单统计
        /// <summary>
        /// 获取报红的订单列表按照条件
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2009年12月5日9:56:48
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public IList<Order> SearchMatureOrderList(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            return sqlMap.QueryForList<Order>("OrderItem.SearchMatureOrderList", order);
        }

        /// <summary>
        /// 获取报红的订单记录数
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2009年12月5日9:56:48
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public long SearchMatureOrderListRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("OrderItem.SearchMatureOrderListRowCount",order);
        }

        /// <summary>
        /// 获取输出的报红的订单列表
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2009年12月5日9:56:48
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public IList<Order> SearchMatureOrderPrintList(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            return sqlMap.QueryForList<Order>("OrderItem.SearchMatureOrderPrintList", order);
        }
        #endregion

        ///// <summary>
        ///// 更新订单明细的输出状态
        ///// </summary>
        ///// <param name="orderItemIdArr"></param>
        ///// <remarks>
        ///// 作    者：张晓林
        ///// 创建时间：2010年3月2日16:38:15
        ///// 修正履历：
        ///// 修正时间：
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
        ///获取订单下明细中的最大版本号
        /// </summary>
        /// <param name="orderNo"></param>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2010年3月3日17:00:04
        /// 修正履历：
        /// 修正时间：
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
        ///插入一条订单明细
        /// </summary>
        /// <param name="orderNo"></param>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2010年3月3日17:20:56
        /// 修正履历：
        /// 修正时间：
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
        /// 获取分配员工的所有订单信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年4月2日16:56:02
        /// 修正履历：添加时间段
        /// 修正时间: 2010年4月9日14:20
        /// </remarks>
        public OrderItem GetEmployeeReceptionOrderInfo(long employeeId) 
        {
            OrderItem oi = new OrderItem();
            oi.BusinessTypeId = employeeId;//接待人雇员Id
            oi.StatusSucessed = Constants.ORDER_STATUS_SUCCESSED_VALUE;//已完成
            oi.StatusNotSubmited = Constants.ORDER_STATUS_RECEPTING_VALUE;//未提交
            //oi.StatusSubmited = Constants.ORDER_STATUS_CONFIRM_VALUE;//已提交
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
        /// 获取分配员工明细
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年4月6日10:21:49
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetReceptionOrderDetail(OrderItem oi) 
        {
            oi.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            oi.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Order>("OrderItem.GetReceptionOrderDetail", oi);
        }

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
        public Order BluringSearchOrderByOrderNo(string orderNo, bool isSucessed)
        {
            OrderItem oi = new OrderItem();
            oi.Name = orderNo;
            if (isSucessed) { oi.Memo = "已完成"; oi.StatusSucessed = Constants.ORDER_STATUS_SUCCESSED_VALUE; }
            oi.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            oi.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<Order>("OrderItem.BluringSearchOrderByOrderNo", oi);
        }

        /// <summary>
        /// 根据工单Id获取工单状态
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年6月8日15:58:20
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public int GetOrderStatusByOrderId(long orderId) 
        {
            return sqlMap.QueryForObject<int>("OrderItem.GetOrderStatusByOrderId", orderId);
        }
    }
}
