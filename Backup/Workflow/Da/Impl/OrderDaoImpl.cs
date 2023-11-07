using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Da.Support;
using System.Collections;

namespace Workflow.Da.Impl
{
    /// <summary>
    /// 名    称: OrderDaoImpl
    /// 功能概要: 订单Dao
    /// 作    者: 付强
    /// 创建时间: 
    /// 修正履历: 张晓林
    /// 修正时间: 2009-02-06
    ///             调整代码
    /// </summary>
    public class OrderDaoImpl : Workflow.Da.Base.DaoBaseImpl<Order>, IOrderDao
    {

         #region IOrderDao 成员

        public IList<Order> SelectDailyOrder(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return base.sqlMap.QueryForList<Order>("Order.SelectDailyOrder", order);  
        }

        /// <summary>
        /// 带分页的本日订单
        /// 付强
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IList<Order> SelectDailyOrderPager(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return base.sqlMap.QueryForList<Order>("Order.SelectDailyOrderPager", order);  

        }

        /// <summary>
        /// 获取本日订单总数
        /// 付强
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public int GetDailyOrderCount(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return (int)base.sqlMap.QueryForObject("Order.GetDailyOrderCount",order);

        }

        public void UpdateOrderStatusByOrderNo(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            base.sqlMap.Update("Order.UpdateTheOrderStatusToFacturing", order);
        }

        public void UpdatePrepayOrder(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            base.sqlMap.Update("Order.UpdatePrepayOrder", order);

        }

        public long SelectOrderIdByOrderNo(string strOrderNo)
        {
            Order order = new Order();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.No = strOrderNo;
            Object obj=base.sqlMap.QueryForObject("Order.SelectOrderIdByOrderNo", order);
            if (null != obj)
            {
                return Int64.Parse(obj.ToString());
            }
            else
            {
                return -1;//没有找到
            }
        }

        /// <summary>
        /// 获取订单下实际已预付款
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public decimal GetPrePayAmount(Order order)
        {
            return sqlMap.QueryForObject<decimal>("Order.GetPrePayAmount", order);

        }

        public void InsertOrder(Order order)
        {
            //lock (this)
            //{
            //    if (idGeneratorSupport == null)
            //    {
            //        idGeneratorSupport = (IdGeneratorSupport)springContext.GetObject("idGeneratorSupport");
            //    }
            //    order.Id = idGeneratorSupport.NextId(typeof(Order));
            //    order.No = noGenerator.GetOrderNo(order.Id);

            //}
            order.InsertDateTime = DateTime.Now;
            order.InsertUser = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
            order.UpdateDateTime = DateTime.Now;
            order.UpdateUser = ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
            order.Version = 1;
            order.Deleted = '0';
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            
            sqlMap.Insert("Order.InsertOrder", order);
        }

        public void UpdateOrder(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.UpdateUser= user.Id;
            order.UpdateDateTime = DateTime.Now;
            sqlMap.Update("Order.UpdateOrder", order);
        }

        public Order SelectOrderInfoByOrderId(long orderId)
        {
            Order order = new Order();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.Id = orderId;
            return base.sqlMap.QueryForObject<Order>("Order.SelectOrderInfoByOrderId", order);
        }

        #region 合并客户时更改Orders中的CustomerId
        /// <summary>
        /// 合并客户:将被合并的客户消费的订单添加到 新合并的客户名称下
        /// </summary>
        /// <param name="linkman"></param>
        /// <remarks>
        ///  作   者：
        ///  创建时间:
        ///  修正履历：
        ///  修正时间:
        /// </remarks>
        public void UpdateConbinationCustomerId(System.Collections.Hashtable linkman)
        {
            sqlMap.Update("Order.ConbinationUpdateCustomerId", linkman);
        }
        #endregion

        #region 订单查询(订单管理)
        /// <summary>
        /// 订单查询(分页)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<Order> SearchOrdersInfo(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("POSITION_CASHER_VALUE", Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
            condition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//订单状态：为已完成的
            return sqlMap.QueryForList<Order>("Order.SearchOrdersInfo", condition);
        }

        /// <summary>
        /// 订单查询（打印数据）
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<Order> SearchOrdersInfoPrint(Hashtable condition)
        {
            return sqlMap.QueryForList<Order>("Order.SearchOrdersInfoPrint", condition); 
        }
        /// <summary>
        /// 获取订单查询记录数
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public long GetSearchOrderInfoCount(Hashtable condition)
        {
            return (long)sqlMap.QueryForObject("Order.GetSearchOrderInfoCount", condition);
        }
        public long GetCustomerCount(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return (long)sqlMap.QueryForObject("Customer.GetCustomerCount", condition);
        }
        #endregion

		#region 订单查询(财务查询)
		public IList<Order> SearchOrdersItem(Hashtable condition)
		{
			return sqlMap.QueryForList<Order>("Order.SelectOrdersItem", condition);
		}

		public int SearchOrdersItemCount(Hashtable condition)
		{
			return sqlMap.QueryForObject<int>("Order.SearchOrdersItemCount", condition);
		}

		public Order SearchOrdersItemAmount(Hashtable condition)
		{
			return sqlMap.QueryForObject<Order>("Order.SearchOrdersItemAmount", condition);
		}

		#endregion


        #region 通过订单号查询送货人
        public string SearchDelivery(string NO)
        {
            Employee ep = new Employee();
            ep.No = NO;
            ep.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            ep.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            object obj = sqlMap.QueryForObject("Order.SelectDelivery", ep);
            return (string)obj;
        }
        #endregion

        #region 通过CustomerId查询在Orders中的数
        /// <summary>
        /// 通过CustomerId查询在Orders中的数
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-11
        /// 修正履历: 张晓林
        /// 修正时间: 2009年2月13日
        /// 修正描述: 添加查询条件 公司和分店      
        /// </remarks>
        public int SearchCustomerInOrder(long Id)
        {
            Hashtable condition = new Hashtable();
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("CustomerId", Id);
            object obj = sqlMap.QueryForObject("Order.SelectCustomerInOrder", condition);

            return (int)obj;
        }
        #endregion

        /// <summary>
        /// 前台交班时加订单数据抽取
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> SelectStageHandOverOrder()
        {
            return sqlMap.QueryForList<Order>("Order.SelectStageHandOverOrder", null);
        }

        /// <summary>
        /// 前台交班时加订单数据抽取2008-11-04
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-04
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> SelectFrontHandOverOrder(System.Collections.Hashtable condition)
        {
            //condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            //condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Order>("Order.SelectFrontHandOverOrder", condition);
        }

        /// <summary>
        /// 收银交班时加订单数据抽取
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> SelectCashHandOverOrder(Hashtable condition)
        {
            condition.Add("Status1", Constants.ORDER_STATUS_BLANKOUT_VALUE);//排除掉已经作废的订单
            condition.Add("PayType5", Workflow.Support.Constants.PAY_KIND_PREPAY_VALUE);
            condition.Add("PayType2", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            return sqlMap.QueryForList<Order>("Order.SelectCashHandOverOrder", condition);
        }
        #endregion

        #region //查找等待结算的订单

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
        public IList<Order> SelectUnClosedOrder(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectUnClosedOrder", order);
        }
   
        /// <summary>
        /// 查找等待结算的订单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2008-11-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public int SelectUnClosedOrderCount(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return (int)sqlMap.QueryForObject("Order.SelectUnClosedOrderCount", order);
        }
        /// <summary>
        /// 通过会员卡号查订单号
        /// </summary>
        /// <param name="strMemberCardNo">会员卡号</param>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2010-1-26
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public string GetOrderNoByMemberCardNo(string strMemberCardNo)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            Order order = new Order();
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.MemberCardNo = strMemberCardNo;
            return (string)sqlMap.QueryForObject("Order.GetOrderNoByMemberCardNo", order);
        }
        /// <summary>
        /// 通过各种号码查询客户ID
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：付强
        /// 创建时间: 2010-1-8
        /// </remarks>
        public long GetCustomerIdByNo(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            object result=sqlMap.QueryForObject("Order.GetCustomerIdByNo", order);
            long customerId = -1;
            if (null!=result)
            {
                long.TryParse(result.ToString(), out customerId);
            }
            return customerId;
        }
        #endregion

        #region //结算时修改订单
        /// <summary>
        /// 结算时修改订单
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void UpdateOrderForClose(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.UpdateDateTime = DateTime.Now;
            order.UpdateUser = user.Id;
            sqlMap.Update("Order.UpdateOrderForClose", order);
        }
        #endregion

        #region //查找有欠款的订单
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
        public IList<Order> SelectNotHaveBeenPaidOrder(Order order)
        {
            return sqlMap.QueryForList<Order>("Order.SelectNotHaveBeenPaidOrder", order);
        }
        #endregion


        #region //收应收款时更新订单表
        /// <summary>
        /// 收应收款时更新订单表
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void UpdateOrderForArearage(Order order)
        {
            sqlMap.Update("Order.UpdateOrderForArearage", order);
        }
        #endregion

        #region //计算会员卡的刷卡次数
        /// <summary>
        /// 统计会员卡刷卡次数
        /// </summary>
        /// <param name="MemberCardNo"></param>
        /// <returns></returns>
        public int SelectMemberCardBrushNumber(string MemberCardNo)
        {
            Hashtable condition = new Hashtable();
            condition.Add("BranchShopId",ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("MemberCardNo",MemberCardNo);
            return sqlMap.QueryForObject<int>("MemberCard.SelectMemberCardBrushNumber", condition);
        }
        #endregion

        #region //根据查询条件获取帐龄订单信息
        /// <summary>
        /// 根据查询条件获取帐龄订单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetAnalyzeDebt(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.AnalyzeDebtTime", order);
        }
        #endregion

        #region //根据查询条件获取帐龄订单信息
        /// <summary>
        /// 根据查询条件获取帐龄订单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetAnalyzeAssistantDebt(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.AnalyzeAssistantDebtTime", order);
        }
        #endregion

		#region 客户消费查询

		/// <summary>
		/// 获取某段时间内所有客户的消费情况
		/// </summary>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-24
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> GetCustomerConsume(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
			return sqlMap.QueryForList<Order>("Order.SelectCustomerConsume", order);
		}

		/// <summary>
		/// 获取客户消费记录数
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2007-10-24
		/// </remarks>
		public int GetCustomerConsumeCount(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
			return sqlMap.QueryForObject<int>("Order.SelectCustomerConsumeCount", order);
		}

		public Order GetCustomerConsumeAmount(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
			return sqlMap.QueryForObject<Order>("Order.SelectCustomerConsumeAmount", order);
		}

		#endregion

        #region //客户对帐表的客户信息
        /// <summary>
        /// 客户对帐表的客户信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-27
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetCustomerHistory(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectCustomerHistory", order);
        }

        #endregion

		#region //客户对帐表的订单信息
		/// <summary>
		/// 客户对帐表的订单信息
		/// </summary>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-27
		/// 修正履历: 陈汝胤
		/// 修正时间: 2010.01.14
		/// </remarks>
		public IList<Order> GetCustomerOrdersHistory(string memberCardNo, string customerName, int beginRow, int endRow)
		{
			Hashtable map = new Hashtable();
			map.Add("beginRow", beginRow);
			map.Add("endRow", endRow);
			map.Add("memberCardNo", memberCardNo);
			map.Add("customerName", customerName);
			map.Add("orderStatus", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			map.Add("payKind1", Constants.PAY_KIND_PREPAY_VALUE);
			map.Add("payKind2", Constants.PAY_KIND_RETURN_VALUE);
			map.Add("payKind3", Constants.PAY_KIND_INVALIDATE_VALUE);
			map.Add("concessionType1", Constants.CONCESSION_TYPE_ZERO_VALUE);
			map.Add("concessionType2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);
			map.Add("concessionType3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);
			map.Add("concessionType4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
			map.Add("concessionType5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
			return sqlMap.QueryForList<Order>("Order.SelectCustomerOrdersHistory", map);
		}

		public Order GetCustomerOrderHistoryTotalize(string memberCardNo, string customerName)
		{
			Hashtable map = new Hashtable();
			map.Add("memberCardNo", memberCardNo);
			map.Add("customerName", customerName);
			map.Add("orderStatus", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			map.Add("payKind1", Constants.PAY_KIND_PREPAY_VALUE);
			map.Add("payKind2", Constants.PAY_KIND_RETURN_VALUE);
			map.Add("payKind3", Constants.PAY_KIND_INVALIDATE_VALUE);
			map.Add("concessionType1", Constants.CONCESSION_TYPE_ZERO_VALUE);
			map.Add("concessionType2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);
			map.Add("concessionType3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);
			map.Add("concessionType4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
			map.Add("concessionType5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
			return sqlMap.QueryForObject<Order>("Order.SelectCustomerOrdersHistoryTotalize", map);
		}

		public int GetCustomerOrdersHistoryCount(string memberCardNo, string customerName)
		{
			Hashtable map = new Hashtable();
			map.Add("memberCardNo", memberCardNo);
			map.Add("customerName", customerName);
			map.Add("orderStatus", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
			return sqlMap.QueryForObject<int>("Order.SelectCustomerOrdersHistoryCount", map);
		}

		#endregion

        //#region //会员卡的消费统计
        ///// <summary>
        ///// 会员卡的消费统计
        ///// </summary>
        ///// <remarks>
        ///// 作    者: 付强
        ///// 创建时间: 2007-10-27
        ///// 修正履历: 
        ///// 修正时间:
        ///// </remarks>
        //public IList<Order> GetMemberCardConsume(Order order)
        //{
        //    User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
        //    order.BranchShopId = user.BranchShopId;
        //    order.CompanyId = user.CompanyId;
        //    return sqlMap.QueryForList<Order>("Order.SelectMemberCardConsume", order);
        //}
        //#endregion

        #region 异常价格订单统计
        /// <summary>
        /// 异常价格订单统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionPriceOrdes(Hashtable map)
        {
            return sqlMap.QueryForList<Order>("Order.ExceptionPriceOrders", map);
        }

		public int GetExceptionPriceOrdesCount(Hashtable map)
		{
			return sqlMap.QueryForObject<int>("Order.ExceptionPriceOrdesCount", map);
		}

		public Order GetExceptionPriceOrdesTotalize(Hashtable map)
		{
			return sqlMap.QueryForObject<Order>("Order.ExceptionPriceOrdesTotalize", map);
		}

        #endregion

        #region //新老客户消费统计
        /// <summary>
        /// 新老客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetNewAndOldCustomerConsumeCount(Hashtable map)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("branchShopId", user.BranchShopId);
			map.Add("companyId", user.CompanyId);
            return sqlMap.QueryForList<Order>("Order.SearchNewAndOldCusotmerConsumeCount", map);
        }
        #endregion

        #region //异常会员客户消费统计
        /// <summary>
        /// 异常会员客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionMemberCustomerConsume(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.NewOrderName = Convert.ToString(Convert.ToDateTime(order.BalanceDateTimeString).AddYears(-1));
            order.CashName = Convert.ToString(Convert.ToDateTime(order.InsertDateTimeString).AddYears(-1));
            return sqlMap.QueryForList<Order>("Order.GetExceptionMemberCustomerConsume", order);
        }

        /// <summary>
        /// 异常会员客户消费统计记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日9:47:19
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long GetExceptionMemberCustomerConsumeRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("Order.GetExceptionMemberCustomerConsumeRowCount", order);
        }

        /// <summary>
        /// 异常会员客户消费统计输出数据
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月3日9:49:51
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionMemberCustomerConsumePrint(Order order) 
        {
            return sqlMap.QueryForList<Order>("Order.GetExceptionMemberCustomerConsumePrint", order);
        }
        #endregion

        #region //波动客户消费统计
        /// <summary>
        /// 波动客户消费统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionConsumeCustomer(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.NewOrderName = Convert.ToString(Convert.ToDateTime(order.BalanceDateTimeString).AddYears(-1));
            order.CashName = Convert.ToString(Convert.ToDateTime(order.InsertDateTimeString).AddYears(-1));
            return sqlMap.QueryForList<Order>("Customer.ExceptionConsumeCustomer", order);
        }
        /// <summary>
        /// 波动客户消费统计记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月23日14:48:09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long GetExceptionConsumeCustomerRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("Customer.GetExceptionConsumeCustomerRowCount", order);
        }

        /// <summary>
        /// 波动客户消费统计输出数据
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年2月23日14:47:37
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionConsumeCustomerPrint(Order order) 
        {
            return sqlMap.QueryForList<Order>("Customer.GetExceptionConsumeCustomerPrint", order);
        }
        #endregion

        #region //获取所有参与订单制作的人员
        /// <summary>
        /// 获取所有参与订单制作的人员
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-5
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetOrderAllUserByOrdersId(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectOrderAllUserByOrderId", order);
        }
        #endregion

        #region //获取开单核收银人员
        /// <summary>
        /// 获取开单核收银人员
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-5
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetOrderReceptionAndCashUserByOrderId(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectOrderReceptionAndCashUserByOrderId", order);
        }
        #endregion

        #region //收银交班相关
        /// <summary>
        /// 取得预付定金/笔数
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public CashHandOver SelectDebtAmount(Hashtable condition)
        {
            condition.Add("PayType1", Constants.PAY_KIND_PREPAY_VALUE);//预付款
            //condition.Add("PayType2",Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            return sqlMap.QueryForObject<CashHandOver>("Order.SelectDebtAmount", condition);
        }

        /// <summary>
        /// 取得记帐笔数/记帐金额
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public CashHandOver SelectKeepBusinessRecordAmount(Hashtable condition)
        {
            condition.Add("PayType", Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE);//只过滤记账客户
            return sqlMap.QueryForObject<CashHandOver>("Order.SelectKeepBusinessRecordAmount", condition);
        }

        /// <summary>
        /// 取得发票笔数/发票金额
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public CashHandOver SelectTicketAmount(Hashtable condition)
        {
            condition.Add("Status2",Constants.ORDER_STATUS_SUCCESSED_VALUE);
            condition.Add("balanceTicket", Constants.BALANCE_TICKET_AMOUNT_KEY);
            return sqlMap.QueryForObject<CashHandOver>("Order.SelectTicketAmount", condition);
        }
		/// <summary>
		/// 查询门店营业额
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-26
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> SelectBranchShopTurnover(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			return sqlMap.QueryForList<Order>("Order.SelectBranchShopTurnover", order);
		}

		public long GetOrderCount(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			return sqlMap.QueryForObject<long>("Order.GetOrderCount", order);
		}

		#endregion

        #region //获取所有需要预付款订单的列表
        /// <summary>
        /// 获取所有需要预付款订单的列表
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        public IList<Order> GetAllNeedPrePayOrders(Order iorder)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            iorder.BranchShopId = user.BranchShopId;
            iorder.CompanyId = user.CompanyId;
            iorder.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            iorder.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            return sqlMap.QueryForList<Order>("Order.SelectAllNeedPrePay", iorder);
        }
        #endregion

        #region //获取所有需要预付款订单的总数
        /// <summary>
        /// 获取所有需要预付款订单的总数
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        public long GetAllNeedPrePayOrdersCount(Order iorder)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            iorder.BranchShopId = user.BranchShopId;
            iorder.CompanyId = user.CompanyId;
            iorder.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            iorder.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            return sqlMap.QueryForObject<int>("Order.SelectAllNeedPrePayCount", iorder);
        }

        /// <summary>
        /// 合计订单总金额和预收款总金额
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月11日9:03:24
        /// 修正履历: 
        /// 修正时间: 
        ///</remarks>
        public Order GetOrderPrepayAmountTotalAndSumAmountTotal(Order order) 
        {
            order.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId=ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            return sqlMap.QueryForObject<Order>("Order.GetOrderPrepayAmountTotalAndSumAmountTotal",order);
        }
        #endregion

        #region //包含时机已经预付款金额的order
        /// <summary>
        /// 包含时机已经预付款金额的order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order SelectOrderInfoByOrderIdPrePaid(long orderId)
        {
            return base.sqlMap.QueryForObject<Order>("Order.SelectByPk_PrePaid", orderId);
        }
        #endregion

        #region //应收款
        /// <summary>
        /// 查询应收款(分页)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 崔肖（加分页）
        /// 修正时间:2008-12-4
        /// </remarks>
        public IList<Order> SelectCustomerArrearage(Order order)
        {
            order.Status1 = int.Parse(Constants.CONCESSION_TYPE_ZERO_VALUE);
            order.Status2 = int.Parse(Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            order.Status3 = int.Parse(Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            order.Status4 = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            order.LastTelNo = Constants.PAY_KIND_CLOSED_VALUE;//结算款
            order.LinkManName = Constants.PAY_KIND_USE_PREPAY_VALUE;//预付款冲减
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//应收款处理金额
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(结算)
            order.CashName = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(应收款处理)
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//订单冲减
            order.OrderNoDispatch = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//舍入多收
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.PayType = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;
            return sqlMap.QueryForList<Order>("Order.SelectCustomerArrearage", order);
        }

        /// <summary>
        /// 查询应收款信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 崔肖
        /// 创建时间: 2008-12-4
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <returns></returns>
        public long GetSelectCustomerArrearageCount(Order order)
        {
            order.Status1 = int.Parse(Constants.CONCESSION_TYPE_ZERO_VALUE);
            order.Status2 = int.Parse(Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            order.Status3 = int.Parse(Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            order.Status4 = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            order.LastTelNo = Constants.PAY_KIND_CLOSED_VALUE;//结算款
            order.LinkManName = Constants.PAY_KIND_USE_PREPAY_VALUE;//预付款冲减
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//应收款处理金额
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(结算)
            order.CashName = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(应收款处理)
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//订单冲减
            order.OrderNoDispatch = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//舍入多收
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.PayType = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;
            return sqlMap.QueryForObject<long>("Order.SelectCustomerArrearagePage", order);
        }

        /// <summary>
        /// 查询应收款(打印数据)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 崔肖（加分页）
        /// 修正时间:2008-12-4
        /// </remarks>
        public IList<Order> GetaAllCustomerArrearage(Order order)
        {
            order.Status1 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_ZERO_VALUE);
            order.Status2 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            order.Status3 = int.Parse(Workflow.Support.Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            order.Status4 = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            order.LastTelNo =Constants.PAY_KIND_CLOSED_VALUE;//结算款
            order.LinkManName=Constants.PAY_KIND_USE_PREPAY_VALUE;//预付款冲减
            order.Memo = Constants.PAY_KIND_ARREARAGE_VALUE;//应收款处理金额
            order.OrderWorking = Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
            order.Address = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减
            order.CashName = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(应收款处理)
            order.OrderFinished = Constants.PAY_KIND_ORDER_DIFF_VALUE;//订单冲减
            order.OrderNoDispatch = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//舍入多收
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.PayType = Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;
            return sqlMap.QueryForList<Order>("Order.GetaAllCustomerArrearage", order);
        }
        #endregion

        #region //应收款按照时间段合计
        /// <summary>
		/// 应收款按时间段获取查询(分页)
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-11-26
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> GetAccountReceviableAccordingToTimeSectTotal(Hashtable hashtable) 
		{
            hashtable.Add("Status1", Constants.CONCESSION_TYPE_ZERO_VALUE);
            hashtable.Add("Status2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            hashtable.Add("Status3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            hashtable.Add("Status4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            hashtable.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            hashtable.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            hashtable.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            hashtable.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            hashtable.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
            hashtable.Add("AccountPreDepositsDiff",Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(应收款处理)
            hashtable.Add("Status5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//舍入多收
            hashtable.Add("PayTypeOrderDiff", Constants.PAY_KIND_ORDER_DIFF_VALUE);//订单冲减
            hashtable.Add("PayType", Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE);//只过滤记账客户
			return sqlMap.QueryForList<Order>("Order.SelectAccountReceviableAccordingToTimeSectTotal", hashtable);
		}
		/// <summary>
		/// 获取 应收款按时间段统计的个数
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-11-28
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public long GetSearchAccountReceviableInfoCount(Hashtable hashCondition) 
		{
            hashCondition.Add("Status1", Constants.CONCESSION_TYPE_ZERO_VALUE);
            hashCondition.Add("Status2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            hashCondition.Add("Status3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            hashCondition.Add("Status4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            hashCondition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            hashCondition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            hashCondition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            hashCondition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            hashCondition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减
            hashCondition.Add("AccountPreDepositsDiff", Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(应收款处理)
            hashCondition.Add("Status5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//舍入多收
            hashCondition.Add("PayTypeOrderDiff", Constants.PAY_KIND_ORDER_DIFF_VALUE);//订单冲减
            hashCondition.Add("PayType", Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE);//只过滤记账客户
			return sqlMap.QueryForObject<long>("Order.GetAccountRecivableTotalCount", hashCondition);
		}
		/// <summary>
		/// 应收款按时间段获取的Order(获取打印数据)
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-11-29
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> GetAccountReceviableTotal(Hashtable hashCondition) 
		{
            hashCondition.Add("Status1", Workflow.Support.Constants.CONCESSION_TYPE_ZERO_VALUE);
            hashCondition.Add("Status2", Workflow.Support.Constants.CONCESSION_TYPE_CONCESSION_VALUE);
            hashCondition.Add("Status3", Workflow.Support.Constants.CONCESSION_TYPE_RENDERUP_VALUE);
            hashCondition.Add("Status4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            hashCondition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            hashCondition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            hashCondition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            hashCondition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            hashCondition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减
            hashCondition.Add("AccountPreDepositsDiff", Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(应收款处理)
            hashCondition.Add("Status5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//舍入多收
            hashCondition.Add("PayTypeOrderDiff", Constants.PAY_KIND_ORDER_DIFF_VALUE);//订单冲减
            hashCondition.Add("PayType", Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE);//只过滤记账客户
			return sqlMap.QueryForList<Order>("Order.SelectGetAccountRecivableTotal", hashCondition);
        }
        #endregion

        #region //日报
        /// <summary>
		/// (按照日期查询)日报Order(分页)
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-12-2
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> GetDailyPaper(Hashtable hashCondition)
		{
            return sqlMap.QueryForList<Order>("GatheringOrder.SelectDailyPaper", hashCondition);
		}

		/// <summary>
		/// (按照日期查询)日报总记录数
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-12-2
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public long GetDailyPaperTotal(Hashtable hashCondition) 
		{
            return sqlMap.QueryForObject<long>("GatheringOrder.SelectDailyPaperRowTotal", hashCondition);
		}

        /// <summary>
        /// (按照日期查询)日报(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-4
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetDailyPaperPrint(Hashtable hashCondition)
        {
            return sqlMap.QueryForList<Order>("GatheringOrder.SelectDailyPaperPrint", hashCondition);
        }

        /// <summary>
        /// 统计满足条件的税费
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月17日11:34:08
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public decimal GetDailyScotAmount(Hashtable condition) 
        {
            return sqlMap.QueryForObject<decimal>("GatheringOrder.GetDailyScotAmount", condition);
        }
        #endregion

        #region //月报
        ///// <summary>
        ///// (按照月份查询)月报(分页)
        ///// </summary>
        ///// <remarks>
        ///// 作    者: 张晓林
        ///// 创建时间: 2008-12-9
        ///// 修正履历: 
        ///// 修正时间:
        ///// </remarks>
        //public IList<Order> GetMonthPaper(Hashtable hashCondition) 
        //{
        //    return sqlMap.QueryForList<Order>("OrderItem.SelectMonthPaperPagination", hashCondition);
        //}

        /// <summary>
        /// (按照月份查询)月报(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-9
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetMonthPaperPrint(Hashtable hashCondition) 
        {
            return sqlMap.QueryForList<Order>("OrderItem.SelectMonthPaperPrint", hashCondition);
        }

        #endregion

		#region //查询客户预付款情况
		/// <summary>
		/// 查询客户预付款情况(分页)
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 付强
		/// 创建时间: 2007-10-26
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> SelectCustomerPrepay(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.StatusList.Add(Constants.ORDER_STATUS_SUCCESSED_VALUE.ToString());
			order.StatusList.Add(Constants.ORDER_STATUS_BLANKOUT_VALUE.ToString());
			order.PayType = int.Parse(Constants.PAY_KIND_PREPAY_VALUE);//预付款
			return sqlMap.QueryForList<Order>("OrderItem.SelectCustomerPrepay", order);
		}
		/// <summary>
		/// 查询客户预付款情况(打印)
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-12-24
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> GetCustomerPrepayPrint(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
			order.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
			order.PayType = int.Parse(Constants.PAY_KIND_PREPAY_VALUE);//预付款
			return sqlMap.QueryForList<Order>("OrderItem.SelectCustomerPrepayPrint", order);
		}

		/// <summary>
		/// 查询客户预付款信息的总记录数
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-12-24
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public int GetCustomerPrepayRowsCount(Order order)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			order.BranchShopId = user.BranchShopId;
			order.CompanyId = user.CompanyId;
			order.StatusList.Add(Constants.ORDER_STATUS_SUCCESSED_VALUE.ToString());
			order.StatusList.Add(Constants.ORDER_STATUS_BLANKOUT_VALUE.ToString());
			order.PayType = int.Parse(Constants.PAY_KIND_PREPAY_VALUE);//预付款
			return sqlMap.QueryForObject<int>("OrderItem.SelectCustomerPrepayRowsCount", order);
		}
		#endregion

        #region //按照订单Id查询订单信息
        public Order SelectOrderByOrderNo(long orderId) 
        {
            Order order = new Order();
            order.Id = orderId;
            order.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            return sqlMap.QueryForObject<Order>("Order.SelectOrderInfoByOrderNo", order);
        }
        #endregion

        #region //根据订单号获取收银人
        /// <summary>
        ///根据订单号获取收银人
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        public string cashUserName(string orderNo)
        {
            Order order = new Order();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.No = orderNo;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);//收银人Id
            return sqlMap.QueryForObject<string>("OrderItem.SelectCushUserNameByOrderNo", order);
        }
        #endregion

        #region //根据客户名称获取客户Id
        /// <summary>
        /// 名    称: GetCustomerIdByCustomerName
        /// 功能概要: 根据客户名称获取客户Id
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月9日16:19:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public Customer GetCustomerInfoByName(string customerName)
        {
            Customer customer=new Customer();
            customer.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customer.BranchShopId=ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            customer.Name = customerName;
            return sqlMap.QueryForObject<Customer>("Customer.GetCustomerIdByCustomerName", customer);
        }
        #endregion


		#region 获取订单列表通过订单状态

		/// <summary>
		/// 获取订单列表通过订单状态
		/// </summary>
		/// <returns>OrderList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.23
		/// </remarks>
		public IList<Order> GetOrderListByStatus(Hashtable map)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			return sqlMap.QueryForList<Order>("Order.GetOrderListByStatus", map);
		}

		#endregion


        /// <summary>
        /// 名    称: GetCustomerPayTypeByCustomerId
        /// 功能概要: 根据客户Id获取客户支付方式
        /// 作    者: 张晓林
        /// 创建时间: 2009年8月24日9:30:14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public long GetCustomerPayTypeByCustomerId(long customerId) 
        {
            Customer customer = new Customer();
            customer.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            customer.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            customer.Id = customerId;
            return sqlMap.QueryForObject<long>("Customer.GetCustomerPayTypeByCustomerId", customer);
        }

        /// <summary>
        /// 返回订单到已登记状态
        /// </summary>
        /// <remarks>
        /// 作者:张晓林
        /// 创建时间:2009年10月12日10:57:17
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void UpdateOrderByReturnOrder(Order order) 
        {
            sqlMap.Update("Order.UpdateOrderByReturnOrder", order);
        }

        /// <summary>
        /// 取消欠发票
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年10月24日15:06:31
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public void CancelNotPaidTicket(Order order) 
        {
            order.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            sqlMap.Update("Order.CancelNotPaidTicket", order);
        }

        #region//订单修正
        /// <summary>
        /// 名    称: GetAmendmentOrder
        /// 功能概要: 获取要修正的订单
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月17日13:10:40
        /// 修正履历:
        /// 修正时间：
        /// </summary>
        public Order GetAmendmentOrder(Order order) 
        {
            order.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId=ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<Order>("Order.GetAmendmentOrder", order);
        }

        /// <summary>
        /// 作废已经结算的订单
        /// </summary>
        /// <param name="order"></param>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2009年11月19日9:22:24
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public void ReturnOrderForPay(Order order)
        {
            order.Status4 = Constants.INVALIDATE_KEY;//作废税费记录
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.QueryForObject<long>("Order.ReturnOrderForPay", order);//将订单返回到结算前的状态
            sqlMap.QueryForObject<long>("Order.UpdateOrderForPayKind", order);//作废付款明细,
            sqlMap.Update("Order.InvaliDatePayOrderScotRecord",order);
        }
        #endregion

		#region 获取需要抄表的所有订单


		public IList<Order> SelectNeedRecordMachineWatch(RecordMachineWatch lastRecordWath)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			if (lastRecordWath != null)
			{
				map.Add("dateTime", lastRecordWath.InsertDateTime);
			}
			return sqlMap.QueryForList<Order>("Order.SelectNeedRecordMachineWatch", map);
		}

		#endregion

		#region 获取订单

		public IList<Order> GetOrders(DateTime beginTime, DateTime endTime, int paymentType, int orderStatus, string userName)
		{
			Hashtable map = new Hashtable();
			map.Add("beginTime", beginTime);
			map.Add("endTime", endTime);
			map.Add("paymentType", paymentType);
			map.Add("orderStatus", orderStatus);
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			map.Add("companyId", user.CompanyId);
			map.Add("branchShopId", user.BranchShopId);
			map.Add("userName", userName);
			map.Add("payKind", Constants.PAY_KIND_INVALIDATE_VALUE);
			return sqlMap.QueryForList<Order>("Order.GetOrders", map);
		}

		#endregion

        #region 新流程订单分配
        /// <summary>
        /// 名    称: NewDispatchOrder
        /// 功能概要: 新流程-分配订单
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月7日15:06:46
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void NewDispatchOrder(Order order) 
        {
            sqlMap.Update("Order.NewDispatchOrder", order);
        }
        #endregion

        #region //新流程-修正打印
        /// <summary>
        /// 名    称: AdmendmentPrint
        /// 功能概要: 新流程-修正打印
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月7日17:25:53
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void AdmendmentPrint(Order order) 
        {
            sqlMap.Update("Order.AdmendmentPrint", order);
        }

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
        public void ReturnOrder(Order order) 
        {
            sqlMap.Update("Order.AdmendmentPrint", order);
        }

        /// <summary>
        /// 名    称: AddBarCodeToOrder
        /// 功能概要: 新流程-给订单添加条码
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月12日9:46:54
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void AddBarCodeToOrder(Order order) 
        {
            sqlMap.Update("Order.AddBarCodeToOrder", order);
        }
        #endregion

		#region 获取客户的所有订单


		public IList<Order> GetCustomerOrders(long customerId,int beginRow,int endRow)
		{
			Hashtable map = new Hashtable();
			map.Add("customerId", customerId);
			map.Add("status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			map.Add("beginRow", beginRow);
			map.Add("endRow", endRow);
			return sqlMap.QueryForList<Order>("Order.SelectCustomerOrders", map);
		}

		public int GetCustomerOrderCount(long customerId)
		{
			Hashtable map = new Hashtable();
			map.Add("customerId", customerId);
			map.Add("status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
			return sqlMap.QueryForObject<int>("Order.SelectCustomerOrderCount", map);
		}

		#endregion
    }
}
