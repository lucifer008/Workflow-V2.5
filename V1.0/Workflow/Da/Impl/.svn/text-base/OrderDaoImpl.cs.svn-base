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
    /// 功能概要: 工单Dao
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
        /// 带分页的本日工单
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
        /// 获取本日工单总数
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
        /// 获取工单下实际已预付款
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
        public void UpdateConbinationCustomerId(System.Collections.Hashtable linkman)
        {
            sqlMap.Update("Order.ConbinationUpdateCustomerId", linkman);
        }
        #endregion

        #region 工单查询(工单管理)
        /// <summary>
        /// 按照条件查询已完成的工单(分页)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<Order> SearchOrdersInfo(System.Collections.Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            //condition.Add("POSITION_RECEPTION_VALUE", Constants.POSITION_RECEPTION_VALUE);
            condition.Add("POSITION_CASHER_VALUE", Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
            condition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//工单状态：为已完成的
            try 
            {
                return sqlMap.QueryForList<Order>("Order.SearchOrdersPagination", condition);
            }
            catch(Exception ex) 
            {
                throw ex;
            }
           
        }

        /// <summary>
        /// 按照条件查询已完成的工单
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public IList<Order> SearchOrdersInfoNo(System.Collections.Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//工单状态：为已完成的
            //condition.Add("POSITION_RECEPTION_VALUE", Constants.POSITION_RECEPTION_VALUE);
            condition.Add("POSITION_CASHER_VALUE", Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));//收银人
            try 
            { 
                return sqlMap.QueryForList<Order>("Order.SearchOrders", condition); 
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public long GetCustomerCount(Hashtable condition)
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return (long)sqlMap.QueryForObject("Customer.GetCustomerCount", condition);

        }

        public long GetSearchOrderInfoCount(Hashtable condition)
        {
           
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            //condition.Add("POSITION_RECEPTION_VALUE", Constants.POSITION_RECEPTION_VALUE);
            condition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//工单状态：为已完成的
            condition.Add("POSITION_CASHER_VALUE", Constants.POSITION_CASHER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
            return (long)sqlMap.QueryForObject("Order.GetSearchOrderInfoCount", condition);
        
        
        }
        #endregion

        #region 工单查询(财务查询)
        public IList<Order> SearchOrdersItem(System.Collections.Hashtable condition)
        {
            return sqlMap.QueryForList<Order>("Order.SelectOrdersItem", condition);
        }
        #endregion


        #region 通过工单号查询送货人
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
        /// 前台交班时加工单数据抽取
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
        /// 前台交班时加工单数据抽取2008-11-04
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
        /// 收银交班时加工单数据抽取
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
            condition.Add("Status1", Constants.ORDER_STATUS_BLANKOUT_VALUE);//排除掉已经作废的工单
            condition.Add("PayType5", Workflow.Support.Constants.PAY_KIND_PREPAY_VALUE);
            condition.Add("PayType2", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            return sqlMap.QueryForList<Order>("Order.SelectCashHandOverOrder", condition);
        }
        #endregion

        #region //查找等待结算的工单

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
        public IList<Order> SelectUnClosedOrder(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectUnClosedOrder", order);
        }
   
        /// <summary>
        /// 查找等待结算的工单
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

        #endregion

        #region //结算时修改工单
        /// <summary>
        /// 结算时修改工单
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

        #region //查找有欠款的工单
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
        public IList<Order> SelectNotHaveBeenPaidOrder(Order order)
        {
            order.Status4 = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);
            return sqlMap.QueryForList<Order>("Order.SelectNotHaveBeenPaidOrder", order);
        }
        #endregion

        #region //收应收款时更新工单表
        /// <summary>
        /// 收应收款时更新工单表
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

        #region //根据查询条件获取帐龄工单信息
        /// <summary>
        /// 根据查询条件获取帐龄工单信息
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

        #region //根据查询条件获取帐龄工单信息
        /// <summary>
        /// 根据查询条件获取帐龄工单信息
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

        #region //获取某段时间内所有客户的消费情况
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
            return sqlMap.QueryForList<Order>("Order.SelectCustomerConsume", order);
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

        #region //客户对帐表的工单信息
        /// <summary>
        /// 客户对帐表的工单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-27
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetCustomerOrdersHistory(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SelectCustomerOrdersHistory", order);
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

        #region //异常价格工单统计
        /// <summary>
        /// 异常价格工单统计
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetExceptionPriceOrdesCount(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.ExceptionPriceOrdersCount", order);
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
        public IList<Order> GetNewAndOldCustomerConsumeCount(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.SearchNewAndOldCusotmerConsumeCount", order);
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
        public IList<Order> GetExceptionMemberCustomerConsumeCount(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            return sqlMap.QueryForList<Order>("Order.ExceptionMemberCustomerConsume", order);
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
            return sqlMap.QueryForList<Order>("Order.ExceptionConsumeCustomer", order);
        }
        #endregion

        #region //获取所有参与工单制作的人员
        /// <summary>
        /// 获取所有参与工单制作的人员
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

        #endregion

        #region //获取所有需要预付款工单的列表
        /// <summary>
        /// 获取所有需要预付款工单的列表
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

        #region //获取所有需要预付款工单的总数
        /// <summary>
        /// 获取所有需要预付款工单的总数
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
			return sqlMap.QueryForList<Order>("Order.SelectDailyPaper", hashCondition);
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
			return sqlMap.QueryForObject<long>("Order.SelectDailyPaperRowTotal", hashCondition);
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
            return sqlMap.QueryForList<Order>("Order.SelectDailyPaperPrint",hashCondition);
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
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
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
        public long GetCustomerPrepayRowsCount(Order order)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            order.BranchShopId = user.BranchShopId;
            order.CompanyId = user.CompanyId;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            order.Status1 = Constants.ORDER_STATUS_BLANKOUT_VALUE;
            order.PayType = int.Parse(Constants.PAY_KIND_PREPAY_VALUE);//预付款
            return sqlMap.QueryForObject<long>("OrderItem.SelectCustomerPrepayRowsCount", order);
        }
        #endregion

        #region //按照工单Id查询工单信息
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

        #region //根据工单号获取收银人
        /// <summary>
        ///根据工单号获取收银人
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
		public IList<Order> GetOrderListByStatus(int status)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable map = new Hashtable();
			map.Add("companyid", user.CompanyId);
			map.Add("branchshopid", user.BranchShopId);
			map.Add("status", status);
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
        /// 返回工单到已登记状态
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
            sqlMap.Update("Order.CancelNotPaidTicket", order);
        }
	}
}
