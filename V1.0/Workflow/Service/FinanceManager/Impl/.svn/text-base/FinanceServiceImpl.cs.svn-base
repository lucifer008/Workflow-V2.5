using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
using Spring.Transaction.Interceptor;
using Workflow.Support;
using Workflow.Util;
using System.Collections;

using Workflow.Action.Finance.Model;
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
        #endregion

        [Transaction]
        public void PrepayHandler(Gathering gather, GatheringOrder gatherOrder,OrdersStatusAlter orderStatusAlter,RelationEmployee relationEmployee,string orderNo,int orderStatusFlag)
        {
            gatheringDao.Insert(gather);
            gatherOrder.GatheringId = gather.Id;
            gatheringOrderDao.Insert(gatherOrder);
            ordersStatusAlterDao.Insert(orderStatusAlter);
            relationEmployee.OrdersStatusAlterId = orderStatusAlter.Id;
            relationEmployeeDao.Insert(relationEmployee);
            Order order = new Order();
            order.No = orderNo;
            order.PrepareMoney = Constants.TRUE;
            order.PrepareMoneyAmount = gather.Amount;//累计预收款总额
            UpdateOrderStatus(order,orderStatusFlag);
        }
        [Transaction]
        public void UpdateOrderStatus(Order order, int orderStatusFlag)
        {
            order.Status = orderStatusFlag;
            orderDao.UpdatePrepayOrder(order);
        }

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
            return orderDao.SelectUnClosedOrder(order);
        }
        /// <summary>
        /// 查找等待结算的工单数量
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
        /// 工单结算
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
            orderDao.UpdateOrderForClose(order);
            foreach (OrderItem oi in orderItemList)
            {
                //orderItemDao.Update(oi);
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
                    for (int i = 0; i < gatheringaAndGatheringorder.GatheringList.Count;i++ )
                    {
                        //付款明细
                        Gathering tmpgathering = gatheringaAndGatheringorder.GatheringList[i];
                        gatheringDao.Insert(tmpgathering);
                        gatheringId = tmpgathering.Id;
                        //工单收款记录
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

            //工单状态履历
            ordersStatusAlterDao.Insert(orderStatusAlter);
            //谁操作的工单状态履历
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
            if (orderItemList == null) throw new Exception("");//为了回滚事务
            //计算业绩
            CalculateCustomerAchievement(order.Id, orderItemList);
            //冲减客户预存款
            if(FinanceModel.PreDeposits>0)
            {
                Customer customer = new Customer();
                customer.Id = order.CustomerId;
                customer.Amount = FinanceModel.PreDeposits;
                customerDao.DiffPreDeposits(customer);
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
            }
        }

        ///<summary>
        /// 计算某个工单下所有参与人的业绩
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
            return orderDao.SelectNotHaveBeenPaidOrder(order);
        }
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
            //foreach (GatheringOrder gO in gatheringOrderList)
            for(int i=0;i<gatheringOrderList.Count;i++)
            {
                gatheringOrderList[i].GatheringId = gatheringList[i].Id;
                //gO.GatheringId = gathering.Id;
                gatheringOrderDao.Insert(gatheringOrderList[i]);
            }
            foreach (PaymentConcession pc in paymentConcessionList)
            {
                pc.GatheringId = gatheringList[0].Id;// gathering.Id;
                pc.OperateDateTime = DateTime.Now;
                paymentConcessionDao.Insert(pc);
            }
            if(model.IsUsePreDeposits)//添加 预存款
            {
                Customer customer = new Customer();
                customer.Id = model.CustomerId;
                customer.Amount = model.PreDeposits;
                customerDao.SavePreDeposit(customer);
            }
            if(model.IsUsePreAmount)//冲减预存款
            {
                Customer customer = new Customer();
                customer.Id = model.CustomerId;
                customer.Amount = model.CustomerPreDeposits;
                customerDao.DiffPreDeposits(customer);
            }
        }


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

        #region //返回工单
        /// <summary>
        /// 返回工单
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
            hashCondition.Add("Status", Constants.ORDER_STATUS_FINISHED_VALUE);

            ordersStatusAlterDao.UpdateOrderStatusById(hashCondition);//更改工单的状态
            ordersStatusAlterDao.Insert(orderStatusAlter); //添加返回记录
        }
        #endregion

        #region // 领取发票
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
            return orderItemDao.SearchTicketAmountInfoByOrderNo(order);
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
            return orderItemDao.SearchTicketAmountInfoByOrderNoTotal(order);
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
        public void DrawTicket(Order order) 
        {
            orderItemDao.DrawTicket(order);
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
    }
}
