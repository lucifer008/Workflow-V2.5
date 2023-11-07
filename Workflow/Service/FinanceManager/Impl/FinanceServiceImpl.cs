using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Da.Support;
using Workflow.Action.Model;
using Workflow.Action.Finance.Model;
using Spring.Transaction.Interceptor;
namespace Workflow.Service.Impl
{
    public class FinanceServiceImpl:IFinanceService
    {
        #region Dao
        private IOrderDao orderDao;
        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }
        private IOrderItemDao orderItemDao;
        public IOrderItemDao OrderItemDao
        {
            set { orderItemDao = value; }
        }
        private IGatheringDao gatheringDao;
        public IGatheringDao GatheringDao
        {
            set { gatheringDao = value; }
        }
        private IGatheringOrderDao gatheringOrderDao;
        public IGatheringOrderDao GatheringOrderDao
        {
            set { gatheringOrderDao = value; }
        }
        private IOrdersStatusAlterDao ordersStatusAlterDao;
        public IOrdersStatusAlterDao OrdersStatusAlterDao
        {
            set { ordersStatusAlterDao = value; }
        }
        private IRelationEmployeeDao relationEmployeeDao;
        public IRelationEmployeeDao RelationEmployeeDao
        {
            set { relationEmployeeDao = value; }
        }
        private IPaymentConcessionDao paymentConcessionDao;
        public IPaymentConcessionDao PaymentConcessionDao
        {
            set { paymentConcessionDao = value; }
        }
        private IOrdersForRecordMachineSumDao ordersForRecordMachineSumDao;
        public IOrdersForRecordMachineSumDao OrdersForRecordMachineSumDao
        {
            set { ordersForRecordMachineSumDao = value; }
        }
        
        
        public Order GetOrderByOrderId(long orderId)
        {
            //return orderDao.SelectByPk(orderId);
            return orderDao.SelectOrderByOrderNo(orderId);
        }
        private IProcessContentDao processContentDao;
        public IProcessContentDao ProcessContentDao
        {
            set { processContentDao = value; }
        }
        private IAchievementDao achievementDao;
        public IAchievementDao AchievementDao
        {
            set { achievementDao = value; }
            get { return achievementDao; }
        }
        private IOrderItemEmployeeDao orderItemEmployeeDao;
        public IOrderItemEmployeeDao OrderItemEmployeeDao
        {
            set { orderItemEmployeeDao = value; }
        }

        private IRequireAccountingInfoDao requireAccountingInfoDao;
        public IRequireAccountingInfoDao RequireAccountingInfoDao
        {
            get
            {
                return requireAccountingInfoDao;
            }
            set
            {
                requireAccountingInfoDao = value;
            }
        }
        private IApplicationPropertyDao applicationPropertyDao;
        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }

        private IOrderItemFactorValueDao orderItemFactorValueDao;
        public IOrderItemFactorValueDao OrderItemFactorValueDao
        {
            set { orderItemFactorValueDao = value; }
        }

		private IMemberCardConcessionDao memberCardConcessionDao;
		public IMemberCardConcessionDao MemberCardConcessionDao
		{
			set { memberCardConcessionDao = value; }
		}

		private IMemberCardDiscountConcessionDao memberCardDiscountConcessionDao;
		public IMemberCardDiscountConcessionDao MemberCardDiscountConcessionDao
		{
			set { memberCardDiscountConcessionDao = value; }
		}

		private IMemberCardOrderItemCounteractLogDao memberCardOrderItemCounteractLogDao;
		public IMemberCardOrderItemCounteractLogDao MemberCardOrderItemCounteractLogDao
		{
			set { memberCardOrderItemCounteractLogDao = value; }
		}

        private IMarkingSettingDao markingSettingDao;
        public IMarkingSettingDao MarkingSettingDao 
        {
            set { markingSettingDao = value; }
        }

        private IMemberCardDao memberCardDao;
        public IMemberCardDao MemberCardDao 
        {
            set { memberCardDao = value; }
        }

        private ICustomerDao customerDao;
        public ICustomerDao CustomerDao 
        {
            set { customerDao = value; }
        }
        private IOrderMortgageRecordDao orderMortgageRecordDao;
        public IOrderMortgageRecordDao OrderMortgageRecordDao
        {
            set { orderMortgageRecordDao = value; }
        }

        private IOrderItemMortgageDao orderItemMortgageDao;
        public IOrderItemMortgageDao OrderItemMortgageDao
        {
            set { orderItemMortgageDao = value; }
        }
        private IOrderItemPrintRequireDetailDao orderItemPrintRequireDetailDao;
        public IOrderItemPrintRequireDetailDao OrderItemPrintRequireDetailDao
        {
            set { orderItemPrintRequireDetailDao = value; }
        }

        private IdGeneratorSupport idGeneratorSupport;
        public IdGeneratorSupport IdGeneratorSupport
        {
            set { idGeneratorSupport = value; }
        }
        private INoGenerator noGenerator;
        public INoGenerator NoGenerator
        {
            set { noGenerator = value; }
        }
        private IOtherGatheringAndRefundmentRecordDao otherGatheringAndRefundmentRecordDao;
        public IOtherGatheringAndRefundmentRecordDao OtherGatheringAndRefundmentRecordDao 
        {
            set { otherGatheringAndRefundmentRecordDao = value; }
        }
        #endregion

        #region//预收款处理
        [Transaction]
        public void PrepayHandler(Gathering gather, GatheringOrder gatherOrder,OrdersStatusAlter orderStatusAlter,RelationEmployee relationEmployee,string orderNo,int orderStatusFlag)
        {
            Order order = new Order();
            order.No = orderNo;
            order.PrepareMoney = Constants.TRUE;
            order.PrepareMoneyAmount = gather.Amount;//累计预收款总额
            UpdateOrderStatus(order, orderStatusFlag);

            gatheringDao.Insert(gather);
            gatherOrder.GatheringId = gather.Id;
            gatheringOrderDao.Insert(gatherOrder);
            ordersStatusAlterDao.Insert(orderStatusAlter);//1
            relationEmployee.OrdersStatusAlterId = orderStatusAlter.Id;
            relationEmployeeDao.Insert(relationEmployee);
        }
        
        public void UpdateOrderStatus(Order order, int orderStatusFlag)
        {
            order.Status = orderStatusFlag;
            orderDao.UpdatePrepayOrder(order);
        }
        #endregion

        #region//统计等待收银的订单

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
            return orderDao.SelectUnClosedOrder(order);
        }
        /// <summary>
        /// 查找等待结算的订单数量
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
            return orderDao.SelectUnClosedOrderCount(order);
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
            return orderDao.GetCustomerIdByNo(order);
        }


        #endregion

        #region//订单结算
        /// <summary>
        /// 订单结算
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-17
        /// 修正履历: 
        ///         2008-11-18
        /// 修正时间:
        /// </remarks>
        [Transaction]
        public void CloseOrder(Order order, IList<OrderItem> orderItemList, IList<OrdersForRecordMachineSum> ordersForRecordMachineSumList, Gathering gathering, GatheringOrder gatheringOrder, IList<PaymentConcession> paymentConcessionList, OrdersStatusAlter orderStatusAlter, RelationEmployee realtionEmployee, Workflow.Action.Finance.Model.FinanceModel FinanceModel)
        {
			GatheringOrder discountGatheringOrder = null;
			Gathering discountGathering=null;
            DateTime balanceDateTime=DateTime.Now;
			//活动
			if (null != FinanceModel.MemberCardOrderItemCounteractLogList && FinanceModel.MemberCardOrderItemCounteractLogList.Count>0)
			{
				discountGatheringOrder=new GatheringOrder();
				discountGatheringOrder.PayKind=Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;
				discountGatheringOrder.OrdersId=order.Id;
				discountGathering = new Gathering();
                balanceDateTime = DateTime.Now;
                discountGathering.GatheringDateTime = balanceDateTime;
				foreach (MemberCardOrderItemCounteractLog orderItemLog in FinanceModel.MemberCardOrderItemCounteractLogList)
				{
					discountGathering.Amount += orderItemLog.OrderItemDiscountPrice;
					orderItemLog.Memo = string.Empty;
					memberCardOrderItemCounteractLogDao.Insert(orderItemLog);
					if (orderItemLog.IsUseSavedPaper == Constants.TRUE)
					{
						memberCardConcessionDao.UpdateRestPaperCount(orderItemLog.CampaignTempId, orderItemLog.UsedAmount);
					}
					else
					{
						memberCardDiscountConcessionDao.UpdateRestAmount(orderItemLog.CampaignTempId, orderItemLog.UsedAmount * orderItemLog.CampaignUnitPrice);
					}
				}
			}

            orderDao.UpdateOrderForClose(order);
            foreach (OrderItem oi in orderItemList)
            {
                orderItemDao.UpdateOrderItemForCloseOrder(oi);
            }
            foreach (OrderItemEmployee oie in FinanceModel.OrderItemEmployeeList)
            {
                orderItemEmployeeDao.Insert(oie);
            }
            bool HasInsertpaymentConcessionList = false;
            long gatheringId = 0;
            if (FinanceModel.GatheringAndGatheringOrder != null)
            {
				if (null != discountGathering)
				{
					//付款明细
					gatheringDao.Insert(discountGathering);
					//订单收款记录
					discountGatheringOrder.GatheringId = discountGathering.Id;
					gatheringOrderDao.Insert(discountGatheringOrder);
				}
                //付款
                foreach (Workflow.Action.Finance.Model.GatheringAndGatheringOrder gatheringaAndGatheringorder in FinanceModel.GatheringAndGatheringOrder)
                {
                    for (int i = 0; i < gatheringaAndGatheringorder.GatheringList.Count;i++ )
                    {
                        //付款明细
                        Gathering tmpgathering = gatheringaAndGatheringorder.GatheringList[i];
                        gatheringDao.Insert(tmpgathering);
                        gatheringId = tmpgathering.Id;
                        //订单收款记录
                        GatheringOrder tmpgatheringOrder = gatheringaAndGatheringorder.GatheringOrderList[i];
                        tmpgatheringOrder.GatheringId = tmpgathering.Id;
                        gatheringOrderDao.Insert(tmpgatheringOrder);
                    }
                 
                    //优惠,可能没有.
                    if (HasInsertpaymentConcessionList == false && paymentConcessionList != null)
                    {
                        foreach (PaymentConcession pc in paymentConcessionList)
                        {
                            pc.GatheringId = gatheringId;
                            paymentConcessionDao.Insert(pc);
                        }
                    }
                    HasInsertpaymentConcessionList = true;
                }
				
            }

            ////挂账记录
            //if (FinanceModel.RelationEmployee != null)
            //{
            //    RequireAccountingInfoDao.Insert(FinanceModel.RequireAccountingInfo );
            //}

            //订单状态履历
            ordersStatusAlterDao.Insert(orderStatusAlter);//2
            //谁操作的订单状态履历
            realtionEmployee.OrdersStatusAlterId = orderStatusAlter.Id;
            relationEmployeeDao.Insert(realtionEmployee);

            //机器的读数统计
            if (ordersForRecordMachineSumList != null)
            {
                foreach (OrdersForRecordMachineSum ofrms in ordersForRecordMachineSumList)
                {
                    ordersForRecordMachineSumDao.Insert(ofrms);
                }
            }
            //添加开发票记录
            if (null != FinanceModel.OtherGatheringAndRefundmentRecordPaidTicketRecord) 
            {
                otherGatheringAndRefundmentRecordDao.Insert(FinanceModel.OtherGatheringAndRefundmentRecordPaidTicketRecord);
            }

            //计算业绩
            CalculateCustomerAchievement(order.Id, orderItemList);

            //冲减客户预存款
            if(0<FinanceModel.PreDeposits)
            {
                Customer customer = new Customer();
                customer.Id = order.CustomerId;
                customer.Amount = FinanceModel.PreDeposits;
                customerDao.DiffPreDeposits(customer);

                //插入预存款冲减记录
                OtherGatheringAndRefundmentRecord og = new OtherGatheringAndRefundmentRecord();
                og.PayKind = Constants.BALANCE_PRE_POSITION_AMOUNT_DIFF_KEY.ToString();
                og.Memo = Constants.BALANCE_PRE_POSITION_AMOUNT_DIFF_TEXT;
                og.Amount =(-1)* FinanceModel.PreDeposits;
                og.OrdersId = order.Id;
                og.CustomerId = order.CustomerId;
                otherGatheringAndRefundmentRecordDao.Insert(og);
            }
            //统计会员消费积分
            if (order.IsNotStatisticsPoints)
            {
                UpdateMemberCardMarkingSetting(order.Id);
            }
            //添加 客户预存款
            if (FinanceModel.CustomerPreDeposits>0)
            {
                Customer customer = new Customer();
                customer.Id = order.CustomerId;
                customer.Amount = FinanceModel.CustomerPreDeposits;
                customerDao.SavePreDeposit(customer);

                //插入预存收款记录
                OtherGatheringAndRefundmentRecord og = new OtherGatheringAndRefundmentRecord();
                og.PayKind = Constants.BALANCE_PRE_POSITION_AMOUNT_KEY.ToString();
                og.Memo = "客户预存款";
                og.Amount = FinanceModel.CustomerPreDeposits;
                og.OrdersId = order.Id;
                og.CustomerId = order.CustomerId;
                otherGatheringAndRefundmentRecordDao.Insert(og);
            }
            //统计税费
            if(null!=FinanceModel.OtherGatheringAndRefundmentRecord)
            {
                otherGatheringAndRefundmentRecordDao.Insert(FinanceModel.OtherGatheringAndRefundmentRecord);
            }
            //添加抄表数据
            AddOrderForRecordMachine(order.Id, balanceDateTime);
        }
        #endregion

        #region//计算业绩

        ///<summary>
        /// 计算某个订单下所有参与人的业绩
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-5
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void CalculateCustomerAchievement(long ordersId, IList<OrderItem> orderItemList)
        {
            int orderItemListCount = orderItemList.Count;
            //decimal allotRate = decimal.Parse(applicationPropertyDao.GetValue(Constants.APPLICATION_ALLOT_RATE_KEY));
            Order order = new Order();
            order.Id = ordersId;
            order.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            IList<Order> orderList = new List<Order>();//存放前期参与人员
            IList<Order> orderAList = new List<Order>();//存放后期参与人员

            IList<ProcessContent> processContentList = processContentDao.SelectAll();

            Order od = orderDao.SelectByPk(ordersId);

            for (int m = 0; m < od.OrderItemList.Count;m++ )//m < orderItemList.Count; m++)
            {

                decimal allotRate = 1;

                for (int x = 0; x < processContentList.Count; x++)
                {
                    if (long.Parse(od.OrderItemList[m].OrderItemFactorValueList[0].Value)==processContentList[x].Id)
                    {
                        allotRate = processContentList[x].ProcessContentAchievementRateList[0].AchievementValue;
                        break;
                    }
                }

                order.Status1 = orderItemList[m].Id;
                order.MemberCardId = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                orderList = orderDao.GetOrderAllUserByOrdersId(order);
                order.MemberCardId = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                orderAList = orderDao.GetOrderAllUserByOrdersId(order);

                //前期的
                for (int i = 0; i < orderList.Count; i++)
                {
                    Order o = orderList[i];
                    Achievement ach = new Achievement();
                    //Employee emp = new Employee();
                    ach.OrdersId = ordersId;
                    ach.OrderItemId = o.CustomerId;
                    ach.Position = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId).ToString();
                    //emp.Id = o.MemberCardId;
                    //ach.Employee = emp;
                    ach.EmployeeId = o.MemberCardId;
                    if (orderAList.Count <= 0)//如果没有后期
                    {
                        if (i + 1 != orderList.Count)
                        {
                            ach.AchievementValue = Math.Round(o.SumAmount / orderList.Count, 2);
                        }
                        else
                        {
                            ach.AchievementValue = o.SumAmount - (Math.Round((o.SumAmount / orderList.Count), 2) * (orderList.Count - 1));
                        }
                    }
                    else
                    {
                        if (i + 1 != orderList.Count)
                        {
                            ach.AchievementValue = Math.Round((o.SumAmount * allotRate) / (orderList.Count), 2);
                        }
                        else
                        {
                            ach.AchievementValue = (o.SumAmount * allotRate) - (Math.Round((o.SumAmount * allotRate) / (orderList.Count), 2) * (orderList.Count - 1));
                        }
                    }
                    AchievementDao.Insert(ach);
                }
                //order.MemberCardId = Constants.POSITION_ANAPHASE_VALUE;
                //orderList.Clear();
                //orderList = orderDao.GetOrderAllUserByOrdersId(order);
                //后期的
                for (int i = 0; i < orderAList.Count; i++)
                {
                    Order o = orderAList[i];
                    Achievement ach = new Achievement();
                    //Employee emp = new Employee();
                    ach.OrdersId = ordersId;
                    ach.OrderItemId = o.CustomerId;
                    ach.Position = Constants.POSITION_ANAPHASE_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId).ToString();
                    //emp.Id = o.MemberCardId;
                    //ach.Employee = emp;
                    ach.EmployeeId = o.MemberCardId;
                    if (orderList.Count <= 0)//如果没有前期
                    {
                        if (i + 1 != orderAList.Count)
                        {
                            ach.AchievementValue = Math.Round(o.SumAmount / orderAList.Count, 2);
                        }
                        else
                        {
                            ach.AchievementValue = o.SumAmount - (Math.Round((o.SumAmount / orderAList.Count), 2) * (orderAList.Count - 1));
                        }
                    }
                    else
                    {
                        if (i + 1 != orderAList.Count)
                        {
                            ach.AchievementValue = Math.Round((o.SumAmount * (1 - allotRate)) / (orderAList.Count), 2);
                        }
                        else
                        {
                            ach.AchievementValue = (o.SumAmount * (1 - allotRate)) - (Math.Round((o.SumAmount * (1 - allotRate)) / (orderAList.Count), 2) * (orderAList.Count - 1));
                        }
                    }

                    AchievementDao.Insert(ach);

                }
            }
            //收银和开单的
            orderList.Clear();
            orderList = orderDao.GetOrderReceptionAndCashUserByOrderId(order);
            if (orderList.Count != 0)
            {
                if (!StringUtils.IsEmpty(orderList[0].Id.ToString()))
                {
                    Achievement ach = new Achievement();
                    //Employee emp = new Employee();
                    ach.OrdersId = ordersId;
                    ach.OrderItemId = orderItemList[0].Id;
                    ach.Position = Constants.POSITION_RECEPTION_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId).ToString();
                    //emp.Id = orderList[0].Id;
                    //ach.Employee = emp;
                    ach.EmployeeId = orderList[0].Id;
                    ach.AchievementValue = orderList[0].SumAmount;
                    achievementDao.Insert(ach);
                }
                if (!StringUtils.IsEmpty(orderList[0].MemberCardId.ToString()))
                {
                    Achievement achCash = new Achievement();
                    //Employee empCash = new Employee();
                    achCash.OrdersId = ordersId;
                    achCash.OrderItemId = orderItemList[0].Id;
                    achCash.Position = Constants.POSITION_CASHER_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId).ToString();
                    //empCash.Id = orderList[0].MemberCardId;
                    //achCash.Employee = empCash;
                    achCash.EmployeeId = orderList[0].MemberCardId;
                    achCash.AchievementValue = orderList[0].SumAmount;
                    achievementDao.Insert(achCash);
                }
            }
        }
        #endregion

        #region//记录抄表数据
        /// <summary>
        /// 记录抄表数据
        /// </summary>
        /// <param name="ordersId">订单Id</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 日    期: 2010年4月29日15:45:46
        /// </remarks>
        public void AddOrderForRecordMachine(long ordersId,DateTime balanceDateTime) 
        {
            try
            {
                IList<long> orderItemIdList = ordersForRecordMachineSumDao.GetOrderItemIdListNeedRecordMachine(ordersId);
                IList<OrdersForRecordMachineSum> ordersForRecordMachineSumList = new List<OrdersForRecordMachineSum>();
                foreach (long orderItemId in orderItemIdList)
                {
                    if (ordersForRecordMachineSumDao.CheckOrderItemIsUseMachine(orderItemId))
                    {
                        string machineValues = ordersForRecordMachineSumDao.GetOrderItemFactorValue(orderItemId, "MACHINE_TYPE").Value;
                        string processContentValues = ordersForRecordMachineSumDao.GetOrderItemFactorValue(orderItemId, "PROCESS_CONTENT").Value;
                        string paperSpacitifactionValues = ordersForRecordMachineSumDao.GetOrderItemFactorValue(orderItemId, "PAPER_SPECIFICATION").Value;
                        OrdersForRecordMachineSum ofrms = new OrdersForRecordMachineSum();
                        OrderItem oi = orderItemDao.SelectByPk(orderItemId);
                        ofrms.OrdersId = ordersId;
                        ofrms.PaperCount = oi.Amount;
                        ofrms.BalanceDateTime = balanceDateTime;
                        ofrms.MachineId = Convert.ToInt32(machineValues);
                        ofrms.PaperSpecification = new PaperSpecification();
                        ofrms.PaperSpecification.Id = Convert.ToInt32(paperSpacitifactionValues);
                        ofrms.ColorType = processContentDao.SelectByPk(Convert.ToInt32(processContentValues)).ColorType;
                        ordersForRecordMachineSumList.Add(ofrms);
                    }
                }
                foreach (OrdersForRecordMachineSum ofrms in ordersForRecordMachineSumList)
                {
                    ordersForRecordMachineSumDao.Insert(ofrms);
                }
            }
            catch 
            {
                Exception ex1 = new Exception("订单明细中存在有机器无纸型的情况!,请检查!");
                Workflow.Support.Log.LogHelper.WriteError(ex1, Workflow.Support.Constants.LOGGER_NAME);
                throw ex1;
            }
        }
        #endregion

        #region//查找有欠款的订单
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
            return orderDao.SelectNotHaveBeenPaidOrder(order);
        }
        #endregion

        #region//应收款欠款明细
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
            return orderItemDao.SelectCustomerOweMoneyDetail(order);
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
            return orderItemDao.SelectCustomerOweMoneyDetailRowCount(order);
        }
        #endregion

        #region//应收款付款明细

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
            return orderItemDao.SelectCustomerPaidAmountDetail(order);
        }

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
            return orderItemDao.SelectCustomerPaidAmountDetailRowCount(order);
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
            return orderItemDao.SelectOrderPaidAmountDetail(order);
        }
        #endregion

        #region//应收款处理
        /// <summary>
        /// 应收款处理
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-18
        /// 修正履历: 张晓林
        /// 修正时间: 2009年11月7日15:24:13
        ///           增加对预存款冲减与添加预存款
        /// </remarks>
        [Transaction]
        public void ArrearageMoneyHandler(IList<Order> orderList, IList<Gathering> gatheringList, IList<GatheringOrder> gatheringOrderList, IList<PaymentConcession> paymentConcessionList, FinanceModel model)
        {
            foreach (Order od in orderList)
            {
                orderDao.UpdateOrderForArearage(od);
            }
            foreach (Gathering g in gatheringList)
            {
                gatheringDao.Insert(g);
            }

            for(int i=0;i<gatheringOrderList.Count;i++)
            {
                gatheringOrderList[i].GatheringId = gatheringList[i].Id;
                gatheringOrderDao.Insert(gatheringOrderList[i]);
            }
            foreach (PaymentConcession pc in paymentConcessionList)
            {
                pc.GatheringId = gatheringList[0].Id;// gathering.Id;
                pc.OperateDateTime = DateTime.Now;
                paymentConcessionDao.Insert(pc);
            }
            //添加 预存款
            if(model.IsUsePreDeposits)
            {
                Customer customer = new Customer();
                customer.Id = model.CustomerId;
                customer.Amount = model.PreDeposits;
                customerDao.SavePreDeposit(customer);

                 //插入预存收款记录
                OtherGatheringAndRefundmentRecord og = new OtherGatheringAndRefundmentRecord();
                og.PayKind = Constants.ACCOUNT_PRE_POSITION_AMOUNT_KEY.ToString();
                og.Memo = "应收款处理:客户预存款";
                og.Amount = model.PreDeposits;
                og.OrdersId =0;
                og.CustomerId = model.CustomerId;
                otherGatheringAndRefundmentRecordDao.Insert(og);
            }
            //冲减预存款
            if(model.IsUsePreAmount)
            {
                Customer customer = new Customer();
                customer.Id = model.CustomerId;
                customer.Amount = model.CustomerPreDeposits;
                customerDao.DiffPreDeposits(customer);

                //插入预存款冲减记录
                OtherGatheringAndRefundmentRecord og = new OtherGatheringAndRefundmentRecord();
                og.PayKind = Constants.ACCOUNT_PRE_POSITION_AMOUNT_DIFF_KEY.ToString();
                og.Memo = "应收款处理:客户预存款冲减";
                og.Amount =(-1)* model.CustomerPreDeposits;
                og.OrdersId =0;
                og.CustomerId = model.CustomerId;
                otherGatheringAndRefundmentRecordDao.Insert(og);
            }
            //统计税费(给票)
            if (null != model.OtherGatheringAndRefundmentRecord)
            {
                otherGatheringAndRefundmentRecordDao.Insert(model.OtherGatheringAndRefundmentRecord);
                if (0 < model.DiffArrOrderList.Count)
                    otherGatheringAndRefundmentRecordDao.DiffOrderTicket(model.DiffArrOrderList);
            }
            else //(不给票)
            {
                if (0 < model.DiffArrOrderList.Count) otherGatheringAndRefundmentRecordDao.CancelOrderDrawTicket(model.DiffArrOrderList);
            }
        }
        #endregion

        #region//通过ID查找加工内容的颜色
        /// 通过ID查找加工内容的颜色
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public string GetProcessContentById(long Id)
        {
            return processContentDao.GetProcessContentById(Id);
        }
        #endregion

        #region //返回订单
        /// <summary>
        /// 返回订单
        /// </summary>
        /// <param name="orderStatusAlter"></param>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-23
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        [Transaction]
        public void ReturnOrder(OrdersStatusAlter orderStatusAlter) 
        {
            Hashtable hashCondition = new Hashtable();
            hashCondition.Add("Id", orderStatusAlter.OrdersId);
            hashCondition.Add("Status", Constants.ORDER_STATUS_FACTURING_VALUE);
            //3
            ordersStatusAlterDao.UpdateOrderStatusById(hashCondition);//更改订单的状态
            ordersStatusAlterDao.Insert(orderStatusAlter); //添加返回记录
        }
        #endregion

        #region // 领取发票
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
            return orderItemDao.SearchTicketAmountInfoByOrderNo(order);
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
            return orderItemDao.SearchTicketAmountInfoByOrderNoTotal(order);
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
            return orderItemDao.SearchTicketAmountInfoPrintByOrderNo(order);
        }

        /// <summary>
        /// 领取发票
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-24
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        [Transaction]
        public void DrawTicket(IList<Order> orderList,IList<OtherGatheringAndRefundmentRecord> otherGatheringAndRefundmentRecordList) 
        {
            foreach(Order order in orderList)
            {
                orderItemDao.DrawTicket(order);
            }
            foreach (OtherGatheringAndRefundmentRecord og in otherGatheringAndRefundmentRecordList)
            {
                otherGatheringAndRefundmentRecordDao.Insert(og);
            }
        }
        #endregion

        #region//取消欠发票

        /// <summary>
        /// 取消欠发票
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2009年10月24日15:06:31
        /// 修正履历：张晓林 一次取消多个
        /// 修正时间：2009年12月2日11:11:17
        /// </remarks>
        [Transaction]
        public void CancelNotPaidTicket(IList<Order> orderList, IList<OtherGatheringAndRefundmentRecord> otherGatheAndReList)
        {
            foreach (Order order in orderList)
            {
                orderDao.CancelNotPaidTicket(order);
            }
            foreach (OtherGatheringAndRefundmentRecord og in otherGatheAndReList)
            {
                otherGatheringAndRefundmentRecordDao.Insert(og);
            }
        }
        #endregion

        #region//积分会员
        /// <summary>
        /// 名   称:  GetAllMarkingSettingList
        /// 功能概要: 获取所有积分列表
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<MarkingSetting> GetAllMarkingSettingList() 
        {
            return markingSettingDao.GetAllMarkingSettingList();
        }

        /// <summary>
        /// 名   称:  UpdateMemberCardMarkingSetting
        /// 功能概要: 更新会员积分
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月29日13:29:39
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        [Transaction]
        public void UpdateMemberCardMarkingSetting(long orderId) 
        {
            Order order = new Order();
            order.Id = orderId;
            order.LinkManName = "加工内容";
            IList<Order> orderItemList=markingSettingDao.GetOrderItemList(order);
            IList<MarkingSetting> markingSettingList = markingSettingDao.GetAllMarkingSettingList();
            if (null != markingSettingList)
            {
                foreach (MarkingSetting markingSetting in markingSettingList)
                {
                    foreach (Order or in orderItemList)
                    {
                        if (markingSetting.ProcessContentId == or.ProcessContentId)
                        {
                            MemberCard memberCard = new MemberCard();
                            memberCard.Id = or.MemberCardId;
                            memberCard.Integral = Convert.ToInt32((or.ItemAmount / markingSetting.Amount) * markingSetting.Marking);    
                            memberCardDao.UpdateMemberCardMarkingSetting(memberCard);
                        }
                    }
                }
            }
        }
        #endregion

        #region//获取客户预存款
        /// <summary>
        ///  名    称: GetCustomerPreDeposit
        ///  功能概要: 获取客户预存款
        ///  作    者: 张晓林
        ///  创建时间: 2009年11月3日11:45:39
        ///  修正履历:
        ///  修正时间:
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public decimal GetCustomerPreDeposit(long customerId) 
        {
            Customer cus = customerDao.SelectByPk(customerId);
            if (null == cus) return 0;
            return cus.Amount;
        } 
        #endregion

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
            return orderDao.GetAmendmentOrder(order);
        }
        /// <summary>
        /// 订单修正
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月18日17:05:57
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        [Transaction]
        public void AmendmentOrder(Order order, IList<OrderItem> orderItemList, IList<OrdersForRecordMachineSum> ordersForRecordMachineSumList, Gathering gathering, GatheringOrder gatheringOrder, IList<PaymentConcession> paymentConcessionList, OrdersStatusAlter orderStatusAlter, RelationEmployee realtionEmployee, Workflow.Action.Finance.Model.FinanceModel FinanceModel) 
        {
            //作废结算的订单重新结算
            Order o = new Order();
            o.Id = order.Id;
            o.Status = Convert.ToInt32(Constants.PAY_KIND_INVALIDATE_VALUE);
            o.Status1 = Convert.ToInt32(Constants.PAY_KIND_PREPAY_VALUE);
            o.NeedTicket = Constants.FALSE;
            o.NotPayTicketAmount = 0;
            o.PaidAmount = 0;
            o.PaidTicketAmount = 0;
            o.PaidTicket = order.PaidTicket;
            orderDao.ReturnOrderForPay(o);

            //重新添加付款记录
            orderDao.UpdateOrderForClose(order);
            foreach (OrderItem oi in orderItemList)
            {
                orderItemDao.UpdateOrderItemForCloseOrder(oi);
            }
            foreach (OrderItemEmployee oie in FinanceModel.OrderItemEmployeeList)
            {
                orderItemEmployeeDao.Insert(oie);
            }
            bool HasInsertpaymentConcessionList = false;
            long gatheringId = 0;

            if (FinanceModel.GatheringAndGatheringOrder != null)
            {
                //付款
                foreach (Workflow.Action.Finance.Model.GatheringAndGatheringOrder gatheringaAndGatheringorder in FinanceModel.GatheringAndGatheringOrder)
                {
                    for (int i = 0; i < gatheringaAndGatheringorder.GatheringList.Count; i++)
                    {
                        //付款明细
                        Gathering tmpgathering = gatheringaAndGatheringorder.GatheringList[i];
                        gatheringDao.Insert(tmpgathering);
                        gatheringId = tmpgathering.Id;
                        //订单收款记录
                        GatheringOrder tmpgatheringOrder = gatheringaAndGatheringorder.GatheringOrderList[i];
                        tmpgatheringOrder.GatheringId = tmpgathering.Id;
                        gatheringOrderDao.Insert(tmpgatheringOrder);
                    }

                    //优惠,可能没有.
                    if (HasInsertpaymentConcessionList == false && paymentConcessionList != null)
                    {
                        foreach (PaymentConcession pc in paymentConcessionList)
                        {
                            pc.GatheringId = gatheringId;
                            paymentConcessionDao.Insert(pc);
                        }
                    }
                    HasInsertpaymentConcessionList = true;
                }
            }

            //订单状态履历
            ordersStatusAlterDao.Insert(orderStatusAlter);//4
            //谁操作的订单状态履历
            realtionEmployee.OrdersStatusAlterId = orderStatusAlter.Id;
            relationEmployeeDao.Insert(realtionEmployee);

            //机器的读数统计
            if (ordersForRecordMachineSumList != null)
            {
                foreach (OrdersForRecordMachineSum ofrms in ordersForRecordMachineSumList)
                {
                    ordersForRecordMachineSumDao.Insert(ofrms);
                }
            }
            //统计税费
            if (null != FinanceModel.OtherGatheringAndRefundmentRecord)
            {
                otherGatheringAndRefundmentRecordDao.InvalidateScotRecord(FinanceModel.OtherGatheringAndRefundmentRecord);
                otherGatheringAndRefundmentRecordDao.Insert(FinanceModel.OtherGatheringAndRefundmentRecord);
            }
            if (orderItemList == null) throw new Exception("");//为了回滚事务
        }
        #endregion

        #region//订单冲减
        /// <summary>
        /// 名    称: OrderMortgage
        /// 功能概要: 订单冲减
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日10:51:58
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        [Transaction]
        public void OrderMortgage(OrderModel model)
        {
            //生成一个冲减订单
            int branchShopId = (int)ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            Order order = model.NewOrder;
            long sourceOrderId = model.NewOrder.Id;
            order.Id = idGeneratorSupport.NextId(typeof(Order));
            order.No = noGenerator.GetOrderNo(order.Id, branchShopId);
            //order.CodeNo = order.No;
            orderDao.InsertOrder(order);
            IList<OrderItemMortgage> orderItemMortgageList = new List<OrderItemMortgage>();
            //生成订单明细
            foreach (OrderItem oi in model.OrderItemList)
            {
                oi.OrdersId = order.Id;
                long soureOrderItemId = oi.Id;
                orderItemDao.Insert(oi);
                foreach (OrderItemEmployee oie in oi.OrderItemEmployeeList)
                {
                    oie.OrderItemId = oi.Id;
                    orderItemEmployeeDao.Insert(oie);
                }
                foreach (OrderItemFactorValue oif in oi.OrderItemFactorValueList)
                {
                    oif.OrderItemId = oi.Id;
                    orderItemFactorValueDao.Insert(oif);
                }
                foreach (OrderItemPrintRequireDetail oip in oi.OrderItemPrintRequireDetailList)
                {
                    oip.OrderItemId = oi.Id;
                    orderItemPrintRequireDetailDao.Insert(oip);
                }

                OrderItemMortgage orderItemMortgage = new OrderItemMortgage();
                orderItemMortgage.SrcOrderItemId = soureOrderItemId;
                orderItemMortgage.OrderItemId = oi.Id;
                orderItemMortgage.Memo = "";
                orderItemMortgage.Amount = Convert.ToInt32(oi.Amount);
                orderItemMortgageList.Add(orderItemMortgage);
            }
            OrdersStatusAlter ordersStatusAlter = new OrdersStatusAlter();
            ordersStatusAlter.OrdersId = order.Id;
            ordersStatusAlter.Status = Constants.ORDER_STATUS_SUCCESSED_VALUE;
            ordersStatusAlter.Memo = "订单冲减";
            ordersStatusAlterDao.Insert(ordersStatusAlter);//5


            // 生成冲减记录
            OrderMortgageRecord orderMortgageRecord = new OrderMortgageRecord();
            orderMortgageRecord.OrdersId = order.Id;
            orderMortgageRecord.SrcOrderId = sourceOrderId;
            orderMortgageRecord.Memo = "订单冲减";
            orderMortgageRecordDao.Insert(orderMortgageRecord);
            foreach (OrderItemMortgage oim in orderItemMortgageList)
            {
                oim.OrderMortgageRecordId = orderMortgageRecord.Id;
                orderItemMortgageDao.Insert(oim);
            }

            //生成收款明细
            //若被冲减的订单付款方式为现金，则退钱;若为记账则减帐
            decimal paidAmount = 0;
            if (Constants.PAYMENT_TYPE_CASHER_GET_VALUE == order.PayType)
            {
                paidAmount = order.SumAmount;
            }
            Gathering gathering = new Gathering();
            gathering.Amount = paidAmount;
            gathering.GatheringDateTime = DateTime.Now;
            gatheringDao.Insert(gathering);

            GatheringOrder gatheringOrder = new GatheringOrder();
            gatheringOrder.OrdersId = order.Id;
            gatheringOrder.PayKind = Constants.PAY_KIND_ORDER_DIFF_VALUE;
            gatheringOrder.GatheringId = gathering.Id;
            gatheringOrderDao.Insert(gatheringOrder);

            //生成业绩
            CalculateCustomerAchievement(order.Id, model.OrderItemList);
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
        public OrderMortgageRecord SearchMortgageOrderPrint() 
        {
            return orderMortgageRecordDao.SearchMortgageOrderPrint();
        }
        #endregion

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
            return orderItemDao.SearchMatureOrderList(order);
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
            return orderItemDao.SearchMatureOrderListRowCount(order);
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
            return orderItemDao.SearchMatureOrderPrintList(order);
        }
        #endregion

        #region //获取工单状态
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
            return orderItemDao.GetOrderStatusByOrderId(orderId);
        }
        #endregion
    }
}
