using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Da;
using Workflow.Util;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Da.Support;
using Workflow.Action.Model;
using Workflow.Support.Attributes;
using Spring.Transaction.Interceptor;

namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// 名    称: OrderServiceImpl
    /// 功能概要: 订单管理Service实现
    /// 作    者: 付强
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class OrderServiceImpl:IOrderService
    {
        #region 类成员
        private IOrderDao orderDao;
        private IOrderItemDao orderItemDao;
        private IOrderItemPrintRequireDetailDao orderItemPrintRequireDetailDao;
        private IOrderItemFactorValueDao orderItemFactorValueDao;
        private IOrderItemEmployeeDao orderItemEmployeeDao;
        private IOrdersStatusAlterDao ordersStatusAlterDao;
        private IRelationEmployeeDao relationEmployeeDao;
        private IOrdersDutyDao ordersDutyDao;
        private IDutyEmployeeDao dutyEmployeeDao;
        private IDeliveryOrderDao deliveryOrderDao;
        private INoGenerator noGenerator;
        private IFactorValueDao factorValueDao;
        private IMemberCardConcessionDao memberCardConcessionDao;
        private IMemberCardDao memberCardDao;
        private IGatheringDao gatheringDao;
        private IGatheringOrderDao gatheringOrderDao;
        private IdGeneratorSupport idGeneratorSupport;
        private IPaymentConcessionDao paymentConcessionDao;
        private IUserDao userDao;
        private IApplicationPropertyDao applicationPropertyDao;
        private IApplicationProperty applicationProperty;
        private IOrderTimeoutAlarmRecordDao orderTimeoutAlarmRecordDao;
        private IAchievementDao achievementDao;
        public IAchievementDao AchievementDao
        {
            set { achievementDao = value; }
        }

        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }
        public IPaymentConcessionDao PaymentConcessionDao
        {
            set { paymentConcessionDao = value; }
        }
        public IdGeneratorSupport IdGeneratorSupport
        {
            set { idGeneratorSupport = value; }
        }
        public IGatheringDao GatheringDao
        {
            set { gatheringDao = value; }
        }
        public IGatheringOrderDao GatheringOrderDao
        {
            set { gatheringOrderDao = value; }
        }
        public IMemberCardDao MemberCardDao
        {
            set { memberCardDao = value; }
        }
        public IMemberCardConcessionDao MemberCardConcessionDao
        {
            set { memberCardConcessionDao = value; }
        }
        private IRealOrderItemDao realOrderItemDao;
        public IRealOrderItemDao RealOrderItemDao
        {
            set { realOrderItemDao = value; }
        }
        private IRealOrderItemFactorValueDao realOrderItemFactorValueDao;
        public IRealOrderItemFactorValueDao RealOrderItemFactorValueDao
        {
            set { realOrderItemFactorValueDao = value; }
        }

        private IRealOrderItemPrintRequireDao realOrderItemPrintRequireDao;
        public IRealOrderItemPrintRequireDao RealOrderItemPrintRequireDao
        {
            set { realOrderItemPrintRequireDao = value; }
        }
        private IRealOrderItemTrashReasonDao realOrderItemTrashReasonDao;
        public IRealOrderItemTrashReasonDao RealOrderItemTrashReasonDao
        {
            set { realOrderItemTrashReasonDao = value; }
        }
        private IRealOrderItemEmployeeDao realOrderItemEmployeeDao;
        public IRealOrderItemEmployeeDao RealOrderItemEmployeeDao
        {
            set { realOrderItemEmployeeDao = value; }
        }

        private ITrashPaperEmployeeDao trashPaperEmployeeDao;
        public ITrashPaperEmployeeDao TrashPaperEmployeeDao
        {
            set { trashPaperEmployeeDao = value; }
        }
        private ILinkManDao linkManDao;
        public ILinkManDao LinkManDao
        {
            set { linkManDao = value; }
        }
        private ICustomerDao customerDao;
        public ICustomerDao CustomerDao
        {
            set { customerDao = value; }
        }

        public IFactorValueDao FactorValueDao
        {
            set { factorValueDao = value; }
        }

        public INoGenerator NoGenerator
        {
            set { noGenerator = value; }
        }

        public IDeliveryOrderDao DeliveryOrderDao
        {
            set { deliveryOrderDao = value; }
        }
        public IOrdersDutyDao OrdersDutyDao
        {
            set { ordersDutyDao = value; }
        }
        public IDutyEmployeeDao DutyEmployeeDao
        {
            set { dutyEmployeeDao = value; }
        }
        public IRelationEmployeeDao RelationEmployeeDao
        {
            set { relationEmployeeDao = value; }
        }

        public IOrdersStatusAlterDao OrdersStatusAlterDao
        {
            set { ordersStatusAlterDao = value; }
        }

        public IOrderItemEmployeeDao OrderItemEmployeeDao
        {
            set { orderItemEmployeeDao = value; }
        }

        public IOrderItemFactorValueDao OrderItemFactorValueDao
        {
            set { orderItemFactorValueDao = value; }
        }

        public IOrderItemPrintRequireDetailDao OrderItemPrintRequireDetailDao
        {
            set { orderItemPrintRequireDetailDao = value; }
        }

        public IOrderItemDao OrderItemDao
        {
            set { orderItemDao = value; }
        }
        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }
        public IUserDao UserDao
        {
            set { userDao = value; }
        }

        public IApplicationProperty ApplicationProperty 
        {
            set { applicationProperty = value; }
        }

        public IOrderTimeoutAlarmRecordDao OrderTimeoutAlarmRecordDao 
        {
            set { orderTimeoutAlarmRecordDao = value; }
        }

        #region 注入 processContentDao
        //Add: Cry Date:2009-1-9
        private IProcessContentDao processContentDao;
        /// <summary>
        /// processContentDao
        /// </summary>
        public IProcessContentDao ProcessContentDao
        {
            set { processContentDao = value; }
        }

        #endregion

        #region 注入 employeeDao

        private IEmployeeDao employeeDao;
        /// <summary>
        /// Add:Cry Date:2009-1-6
        ///  注入 employeeDao
        /// </summary>
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
        }

        #endregion

        private IOrderItemMortgageDao orderItemMortgageDao;
        public IOrderItemMortgageDao OrderItemMortgageDao 
        {
            set { orderItemMortgageDao = value; }
        }
        private IPositionDao positionDao;
        public IPositionDao PositionDao 
        {
            set { positionDao = value; }
        }
        #endregion

        #region 订单管理

        #region 保存订单
        /// <summary>
        /// 名    称: SaveOrder
        /// 功能概要: 保存订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">要保存的订单对象</param>
        /// <param name="orderStatusAlter">订单状态的变更履历对象</param>
        /// <param name="linkMan">联系人</param>
        /// <param name="customer">客户</param>
        [Transaction]
        public void SaveOrder(Order order, OrdersStatusAlter orderStatusAlter,LinkMan linkMan,Customer customer)
        {
            //linkManDao.Insert(linkMan);
            //customerDao.UpdateCustomerLinkManInfo(customer);
            //orderDao.Insert(order);
            int branchShopId=(int)ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            order.Id = idGeneratorSupport.NextId(typeof(Order));
            order.No = noGenerator.GetOrderNo(order.Id,branchShopId);
            order.CodeNo = order.No;
            orderDao.InsertOrder(order);
            orderStatusAlter.OrdersId = order.Id;
            //orderDao.Update(order);

            foreach (OrderItem oi in order.OrderItemList)
            {
                oi.OrdersId = order.Id;
                orderItemDao.Insert(oi);
                if (oi.PrintRequireDetailList != null)
                {
                    foreach (PrintRequireDetail prd in oi.PrintRequireDetailList)
                    {
                        OrderItemPrintRequireDetail oiprd = new OrderItemPrintRequireDetail();
                        oiprd.OrderItemId = oi.Id;
                        oiprd.PrintRequireDetailId = prd.PrintDemandDetailId;
                        orderItemPrintRequireDetailDao.Insert(oiprd);
                    }
                }
                if (oi.OrderItemFactorValueList != null)
                {
                    foreach (OrderItemFactorValue oifv in oi.OrderItemFactorValueList)
                    {
                        oifv.OrderItemId = oi.Id;
                        orderItemFactorValueDao.Insert(oifv);
                    }
                }
                //保存订单明细的雇员
                OrderItemEmployee oie = new OrderItemEmployee();
                oie.EmployeeId = order.NewOrderUser.EmployeeId;
                oie.OrderItemId = oi.Id;
                orderItemEmployeeDao.Insert(oie);
            }
            //订单变更履历
            ordersStatusAlterDao.Insert(orderStatusAlter);//6
            ////更新接待人 
            //if (0 != order.ReceptionUser)
            //{
            //    Order o = new Order();
            //    o.Status = Constants.ORDER_STATUS_FACTURING_VALUE;
            //    o.No = order.No;
            //    o.ReceptionUser = order.ReceptionUser;
            //    orderDao.NewDispatchOrder(o);
            //}
        }
        #endregion

        /// <summary>
        /// 名    称: UpdateOrder
        /// 功能概要: 更新订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">要更新的订单信息</param>
        [Transaction]
        public void UpdateOrder(Order order)
        {
            orderDao.Update(order);
        }
        /// <summary>
        /// 名    称: DeleteOrder
        /// 功能概要: 通过Id删除订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-14
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="ID">订单ID</param>
        [Transaction]
        public void DeleteOrder(int id)
        {
            orderDao.Delete(id);
        }

        #region 本日订单
        /// <summary>
        /// 名    称: SelectDailyOrderPager
        /// 功能概要: 显示近X天未完成订单 带分页
        /// 作    者: 付强
        /// 创建时间: 2008-12-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">显示订单的过滤条件</param>
        /// <returns>返回符合条件的订单List</returns>
        public IList<Order> SelectDailyOrderPager(Order order)
        {
            //借Status1传递每页显示行数
            order.Status1 = Constants.ROW_COUNT_FOR_PAGER;
            order.Status2 = order.CurrentPageIndex;
            int filterDayCount = int.Parse(applicationPropertyDao.GetValue(Constants.APPLICATION_DISPLAY_ORDER_INNER_DAY_COUNT_KEY));
            int diffValue = 0;
            if (filterDayCount - 1 <= 0 && filterDayCount != 0) diffValue = 0;
            else diffValue = filterDayCount - 1;
            if (diffValue >= 0)
            {
                order.InsertDateTimeString = DateTime.Now.Date.AddDays(-diffValue).ToShortDateString();
                order.BalanceDateTimeString = DateTime.Now.Date.AddDays(+1).ToShortDateString();
            }
            else 
            {
                foreach (string str in order.StatusList)
                {
                    if (Convert.ToInt32(str) == Constants.ORDER_STATUS_SUCCESSED_VALUE) 
                    {
                        order.InsertDateTimeString = DateTime.Now.Date.ToShortDateString();
                        break;
                    }
                }
            }
            return orderDao.SelectDailyOrderPager(order);

        }
        /// <summary>
        /// 名    称: GetDailyOrderCount
        /// 功能概要: 获取符合条件的本日订单总数
        /// 作    者: 付强
        /// 创建时间: 2008-12-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="order">传递过滤条件</param>
        /// <returns>符合过滤条件的订单总数</returns>
        public int GetDailyOrderCount(Order order)
        {
            return orderDao.GetDailyOrderCount(order);
        }
        /// <summary>
        /// 获取本日订单列表默认显示的天数
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间：2010年2月25日15:12:40
        /// 修正履历:
        /// 修正时间：
        /// </remarks>
        public int GetDisplayOrderInnerDayCount() 
        {
            return Convert.ToInt32(applicationPropertyDao.GetValue(Constants.APPLICATION_DISPLAY_ORDER_INNER_DAY_COUNT_KEY));
        }
        #endregion

        /// <summary>
        /// 名    称: UpdateOrderStatusByOrderNo
        /// 功能概要: 通过订单号更新订单状态
        /// 作    者: 付强
        /// 创建时间: 2008-9-26
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="OrderStatusFlag">要更新的订单状态</param>
        public void UpdateOrderStatusByOrderNo(string strOrderNo, int OrderStatusFlag)
        {
            Order order = new Order();
            order.No = strOrderNo;
            order.Status = OrderStatusFlag;
            orderDao.UpdateOrderStatusByOrderNo(order);
        }
        /// <summary>
        /// 名    称: DispatchDeleteOrderItemEmployeeByOrderNo
        /// 功能概要: 通过订单号删除订单雇员
        /// 作    者: 付强
        /// 创建时间: 2008-9-26
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public void DispatchDeleteOrderItemEmployeeByOrderNo(string strOrderNo)
        {
            orderItemEmployeeDao.DispatchDeleteOrderItemEmployeeByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: SelectOldEmployee
        /// 功能概要: 获取订单明细的订单雇员
        /// 作    者: 付强
        /// 创建时间: 2008-9-11
        /// 修正履历:
        /// 修正时间:        
        /// </summary>
        /// <param name="orderItemEmployee">查询条件</param>
        /// <returns>返回订单明细的相关雇员</returns>
        public IList<OrderItemEmployee> SelectOldEmployee(OrderItemEmployee orderItemEmployee)
        {
            return orderItemEmployeeDao.SelectOldEmployee(orderItemEmployee);
        }

        #region 订单返工
        /// <summary>
        /// 名    称: ReDoOrder
        /// 功能概要: 返工
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderStatusAlter">状态变更履历</param>
        /// <param name="ordersDuty">返工责任金额</param>
        /// <param name="orderItemEmployee">新的参与人员</param>
        /// <param name="relationEmployee">状态变更的相关人员</param>
        /// <param name="dutyEmployeeList">相关责任人</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        [UpdatePermission]
        [Transaction]
        public void ReDoOrder(OrdersStatusAlter orderStatusAlter, OrdersDuty ordersDuty, IList<OrderItemEmployee> orderItemEmployeeList, IList<RelationEmployee> relationEmployee, IList<DutyEmployee> dutyEmployeeList, string strOrderNo, int orderStatusFalg)
        {
            //在此判断是否有权限执行该操作
            //if 没有权限
            //{
            //没有权限执行此操作时抛出PermissionDeniedException异常   
            //    throw new Workflow.Support.Exception.PermissionDeniedException("你没有权限访问!");
            //}

            try
            {
                //更改订单状态
                UpdateOrderStatusByOrderNo(strOrderNo, orderStatusFalg);

                //删除原有参与人员
                OrderItemEmployee orderItemEmployee = new OrderItemEmployee();
                orderItemEmployee.No = strOrderNo;
                //orderItemEmployee.PositionId = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                //orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
                orderItemEmployee.PositionIdList.Add(Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
                orderItemEmployee.PositionIdList.Add(Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
                orderItemEmployeeDao.DeleteOrderItemEmployeeByOrderNo(orderItemEmployee);
                //增加新选择人员
                for (int i = 0; i < orderItemEmployeeList.Count; i++)
                {
                    orderItemEmployeeDao.Insert(orderItemEmployeeList[i]);
                }
                //保存状态变更履历
                ordersStatusAlterDao.Insert(orderStatusAlter);//6
                //保存订单责任
                ordersDutyDao.Insert(ordersDuty);
                //保存订单责任人
                for (int i = 0; i < dutyEmployeeList.Count; i++)
                {
                    dutyEmployeeList[i].OrdersDutyId = ordersDuty.Id;
                    dutyEmployeeDao.Insert(dutyEmployeeList[i]);

                }
                //保存状态参与人
                for (int i = 0; i < relationEmployee.Count; i++)
                {
                    relationEmployee[i].OrdersStatusAlterId = orderStatusAlter.Id;
                    relationEmployeeDao.Insert(relationEmployee[i]);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

        #region 订单分配
       /// <summary>
        /// 名    称: DispatchOrder
        /// 功能概要: 分配订单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployeeList">订单明细的参与人员</param>
        /// <param name="orderStatusAlter">订单状态的变更履历</param>
        /// <param name="relationEmployeeList">订单状态变更的相关人员</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="OrderStatusFlag">订单状态</param>
        [Transaction]
        public void DispatchOrder(IList<OrderItemEmployee> orderItemEmployeeList,OrdersStatusAlter orderStatusAlter,IList<RelationEmployee> relationEmployeeList,string strOrderNo,int orderStatusFlag)
        {
            //更改订单状态
            UpdateOrderStatusByOrderNo(strOrderNo, orderStatusFlag);

            //删除原来的参与人员(开单人除外)
            //DispatchDeleteOrderItemEmployeeByOrderNo(strOrderNo);
            OrderItemEmployee orderItemEmployee = new OrderItemEmployee();
            orderItemEmployee.No = strOrderNo;
            //orderItemEmployee.PositionId = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            //orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionIdList.Add(Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
            orderItemEmployee.PositionIdList.Add(Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
            orderItemEmployeeDao.DeleteOrderItemEmployeeByOrderNo(orderItemEmployee);

            //保存订单参与人员
            for(int i=0;i<orderItemEmployeeList.Count;i++)
            {
                orderItemEmployeeDao.Insert(orderItemEmployeeList[i]);
            }
            //保存订单状态变更履历
            ordersStatusAlterDao.Insert(orderStatusAlter);//7
            //保存订单状态变更参与人
            for (int i = 0; i < relationEmployeeList.Count; i++)
            {
                relationEmployeeList[i].OrdersStatusAlterId = orderStatusAlter.Id;
                relationEmployeeDao.Insert(relationEmployeeList[i]);
            }
        }

        /// <summary>
        /// 名    称: NewDispatchOrder
        /// 功能概要: 新流程-分配订单
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月7日15:06:46
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        [Transaction]
        public void NewDispatchOrder(Order order, OrdersStatusAlter osa,IList<OrderItemEmployee> orderItemEmployeeList) 
        {
            orderDao.NewDispatchOrder(order);
            orderItemEmployeeDao.DeleteOrderItemEmployee(osa.OrdersId);
            foreach(OrderItemEmployee oie in orderItemEmployeeList)
            {
                orderItemEmployeeDao.Insert(oie);
            }
            ordersStatusAlterDao.Insert(osa);//8
            
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
        [Transaction]
        public void AdmendmentPrint(Order order, OrdersStatusAlter osa) 
        {
            orderDao.AdmendmentPrint(order);
            ordersStatusAlterDao.Insert(osa);//9
        }

        #endregion

        #region//新流程-返回订单
        /// <summary>
        /// 名    称: ReturnOrder
        /// 功能概要: 新流程-返回订单
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月8日10:05:09
        /// 修正履历: 修正事务并发性带来的死锁问题，调整执行顺序
        /// 修正时间: 
        /// </summary>
        [Transaction]
        public void ReturnOrder(Order order, OrdersStatusAlter osa)//, bool isPrint,string[] orderItemIdArr)
        {
            orderDao.ReturnOrder(order);
            if (order.IsNotStatisticsPoints) orderDao.AddBarCodeToOrder(order);
            ordersStatusAlterDao.Insert(osa);//10
            
            //if (isPrint) 
            //{
            //    orderItemDao.UpdateOrderItemPrintStatus(orderItemIdArr);
            //} 
        }
        #endregion

        #region 订单完工
        /// <summary>
        /// 名    称: FinishOrder
        /// 功能概要: 订单完工
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployeeList">订单明细的参与人员</param>
        /// <param name="orderStatusAlter">订单状态的变更履历</param>
        /// <param name="relationEmployeeList">订单状态变更的相关人员</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        [Transaction]
        public void FinishOrder(IList<OrderItemEmployee> orderItemEmployeeList,OrdersStatusAlter orderStatusAlter,IList<RelationEmployee> relationEmployeeList,string strOrderNo,int orderStatusFlag)
        {
            //DispatchDeleteOrderItemEmployeeByOrderNo(strOrderNo);
            UpdateOrderStatusByOrderNo(strOrderNo, orderStatusFlag);
            OrderItemEmployee orderItemEmployee = new OrderItemEmployee();
            orderItemEmployee.No = strOrderNo;
            //orderItemEmployee.PositionId = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            //orderItemEmployee.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            orderItemEmployee.PositionIdList.Add(Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
            orderItemEmployee.PositionIdList.Add(Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId));
            orderItemEmployeeDao.DeleteOrderItemEmployeeByOrderNo(orderItemEmployee);

            for (int i = 0; i < orderItemEmployeeList.Count; i++)
            {
                orderItemEmployeeDao.Insert(orderItemEmployeeList[i]);
            }
            ordersStatusAlterDao.Insert(orderStatusAlter);//11
            for (int i = 0; i < relationEmployeeList.Count; i++)
            {
                relationEmployeeList[i].OrdersStatusAlterId = orderStatusAlter.Id;
                relationEmployeeDao.Insert(relationEmployeeList[i]);
            }
        }
        #endregion

        #region 作废订单
        /// <summary>
        /// 名    称: BlankOutOrder
        /// 功能概要: 作废订单
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderStatusAlter">订单状态的变更履历</param>
        /// <param name="relationEmployeeList">订单状态变更的相关人员</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        [Transaction]
        public void BlankOutOrder(OrdersStatusAlter orderStatusAlter, IList<RelationEmployee> relationEmployeeList, string strOrderNo, int orderStatusFlag)
        {
            UpdateOrderStatusByOrderNo(strOrderNo, orderStatusFlag);
            ordersStatusAlterDao.Insert(orderStatusAlter);//12
        }
        #endregion

        #region 订单预付
        /// <summary>
        /// 名    称: PrepayOrder
        /// 功能概要: 订单预付
        /// 作    者: 付强
        /// 创建时间: 2008-10-27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderStatusAlter">订单状态的变更履历</param>
        /// <param name="gathering">收款记录</param>
        /// <param name="gatheringOrder">订单收款记录</param>
        /// <param name="orderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        [Transaction]
        public void PrepayOrder(OrdersStatusAlter orderStatusAlter,Gathering gathering ,GatheringOrder gatheringOrder, string orderNo, int orderStatusFlag)
        {
            UpdateOrderStatusByOrderNo(orderNo, orderStatusFlag);

            ordersStatusAlterDao.Insert(orderStatusAlter);//13
            gatheringDao.Insert(gathering);
            gatheringOrder.GatheringId = gathering.Id;
            gatheringOrderDao.Insert(gatheringOrder);
            
        }
        #endregion

        #region 修正加订单
        /// <summary>
        /// 名    称: RealFactureOrder
        /// 功能概要: 修正加订单
        /// 作    者: 付强
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Order">要修正的订单</param>
        /// <param name="orderStatusAlter">订单状态变更履历</param>
        [Transaction]
        public void RealFactureOrder(Order order, OrdersStatusAlter orderStatusAlter)
        {
            orderDao.UpdateOrder(order);

            List<string> nUserList = new List<string>();
            List<long> orderItemIdList = new List<long>();

            IList<OrderItemEmployee> oieList = new List<OrderItemEmployee>();
            OrderItemEmployee oie = new OrderItemEmployee();
            oie.PositionId1 = Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            oie.PositionId2 = Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            oie.PositionId = Constants.POSITION_RECEPTION_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            oie.PositionId3 = Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            oie.PositionId4 = Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId);
            oie.No = order.No;
            //oieList = orderItemEmployeeDao.SelectOldEmployee(oie);
            oieList = orderItemEmployeeDao.SelectOrderItemEmployee(oie);

            foreach (OrderItemEmployee oiemp in oieList)
            {
                if (!orderItemIdList.Contains(oiemp.OrderItemId))
                {
                    orderItemIdList.Add(oiemp.OrderItemId);
                }

                if (!nUserList.Contains(oiemp.OrderItemId.ToString() + "-" + oiemp.EmployeeId.ToString()))
                {
                    nUserList.Add(oiemp.OrderItemId.ToString() + "-" + oiemp.EmployeeId.ToString());
                }
            }
            //删除原有参与人员
            OrderItemEmployee orderItemEmployee = new OrderItemEmployee();
            orderItemEmployee.No = order.No;
            IList<Position> positionList = positionDao.SelectAll();
            foreach (Position ps in positionList)
            {
                orderItemEmployee.PositionIdList.Add(ps.Id);
            }
            int maxVersion = orderItemDao.SelectOrderItemMaxVersion(order.No);
            //int printCount = GetOrderPrintCountByOrderNo(order.No);
            orderItemEmployeeDao.DeleteOrderItemEmployeeByOrderNo(orderItemEmployee);
            //删除原订单明细因素的值
            orderItemFactorValueDao.DeleteOrderItemFactorValueByOrderNo(order.No);
            //删除原订单明细印制要求
            orderItemPrintRequireDetailDao.DeleteOrderItemPrintRequireByOrderNo(order.No);

            //删除原订单明细
            orderItemDao.DeleteOrderItemByOrderNo(order.No);
            int count=0;
            foreach (OrderItem oi in order.OrderItemList)
            {
                if (0 == oi.Id) oi.Version = maxVersion + 1;
                if (1 == oi.Version) oi.Version = 2;
                oi.Id =idGeneratorSupport.NextId(typeof(OrderItem));
                oi.OrdersId = order.Id;
                orderItemDao.InsertOrderItem(oi);
                foreach (PrintRequireDetail prd in oi.PrintRequireDetailList)
                {
                    OrderItemPrintRequireDetail oiprd = new OrderItemPrintRequireDetail();
                    oiprd.OrderItemId = oi.Id;
                    oiprd.PrintRequireDetailId = prd.PrintDemandDetailId;
                    orderItemPrintRequireDetailDao.Insert(oiprd);
                }
                foreach (OrderItemFactorValue oifv in oi.OrderItemFactorValueList)
                {
                    oifv.OrderItemId = oi.Id;
                    orderItemFactorValueDao.Insert(oifv);
                }
                if (count >= orderItemIdList.Count) continue;
                long oldOrderItemId = orderItemIdList[count];

                foreach (string str in nUserList)
                {
                    string[] dataArr = str.Split('-');
                    if (dataArr[0].Equals(oldOrderItemId.ToString()))
                    {
                        OrderItemEmployee oiemp = new OrderItemEmployee();
                        oiemp.EmployeeId = long.Parse(dataArr[1]);
                        oiemp.OrderItemId = oi.Id;
                        orderItemEmployeeDao.Insert(oiemp);
                    }
                }
                count++;
            }
            //订单变更履历
            ordersStatusAlterDao.Insert(orderStatusAlter);//14
        }

        #endregion

        #region 拼板
        /// <summary>
        /// 名    称: PatchUpOrder
        /// 功能概要: 拼版
        /// 作    者: 付强
        /// 创建时间: 2007-10-11
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="realOrderItemList">实际订单明细</param>
        /// <param name="orderStatusAlter">订单状态变更履历</param>
        /// <param name="orderNo">订单号</param>
        [Transaction]
        public void PatchUpOrder(IList<RealOrderItem> realOrderItemList, OrdersStatusAlter orderStatusAlter, string orderNo)
        {
            UpdateOrderStatusByOrderNo(orderNo, Workflow.Support.Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE);

            //删除废张原因
            realOrderItemTrashReasonDao.DeleteRealOrderItemTrashReasonByOrderId(realOrderItemList[0].OrdersId);
            //删除废张责任人
            trashPaperEmployeeDao.DeleteTrashPaperEmployeeByOrderId(realOrderItemList[0].OrdersId);
            //删除RealOrderItemFactorValue
            realOrderItemFactorValueDao.DeleteRealOrderItemFactorValueByOrderId(realOrderItemList[0].OrdersId);
            //删除RealOrderItemPrintRequire
            realOrderItemPrintRequireDao.DeleteRealOrderItemPrintRequireByOrderId(realOrderItemList[0].OrdersId);
            //删除RealOrderItemEmployee
            realOrderItemEmployeeDao.DeleteRealOrderItemEmployeeByOrderId(realOrderItemList[0].OrdersId);
            //删除RealOrderItem
            realOrderItemDao.DeleteRealOrderItemByOrderId(realOrderItemList[0].OrdersId);
            foreach (RealOrderItem oi in realOrderItemList)
            {
                realOrderItemDao.Insert(oi);
                foreach (PrintRequireDetail prd in oi.PrintRequireDetailList)
                {
                    RealOrderItemPrintRequire oiprd = new RealOrderItemPrintRequire();
                    oiprd.RealOrderItemId = oi.Id;
                    oiprd.PrintRequireDetailId = prd.PrintDemandDetailId;
                    realOrderItemPrintRequireDao.Insert(oiprd);
                }
                foreach (RealOrderItemFactorValue oifv in oi.RealOrderItemFactorValueList)
                {
                    oifv.RealOrderItemId = oi.Id;
                    realOrderItemFactorValueDao.Insert(oifv);
                }
                foreach (RealOrderItemEmployee roiei in oi.RealOrderItemEmployeeList)
                {
                    roiei.RealOrderItemId = oi.Id;
                    realOrderItemEmployeeDao.Insert(roiei);
                }

            }
            //订单变更履历
            ordersStatusAlterDao.Insert(orderStatusAlter);//15
        }
        #endregion

        #region 废张登记
        /// <summary>
        /// 名    称: TrashPaperRecord
        /// 功能概要: 废张登记
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="realOrderItemList">实际订单明细</param>
        /// <param name="trashPaperEmployeeList">雇员废张信息</param>
        /// <param name="realOrderItemTrashReasonList">实际订单明细废张原因</param>
        /// <param name="orderStatusAlter">订单状态变更履历</param>
        /// <param name="orderNo">订单号</param>
        [Transaction]
        public void TrashPaperRecord(IList<RealOrderItem> realOrderItemList,IList<TrashPaperEmployee> trashPaperEmployeeList, IList<RealOrderItemTrashReason> realOrderItemTrashReasonList, OrdersStatusAlter orderStatusAlter, string orderNo)
        {
            foreach (TrashPaperEmployee tpe in trashPaperEmployeeList)
            {
                trashPaperEmployeeDao.Insert(tpe);
            }
            foreach (RealOrderItemTrashReason roitr in realOrderItemTrashReasonList)
            {
                realOrderItemTrashReasonDao.Insert(roitr);
            }
            ordersStatusAlterDao.Insert(orderStatusAlter);//16
            foreach(RealOrderItem roi in realOrderItemList)
            {
                realOrderItemDao.UpdateTrashPapersOfRealOrderItemById(roi);
            }

        }
        #endregion

        #region 订单送货
                /// <summary>
        /// 名    称:IsExistRecord
        /// 功能概要: 判断是否是首次送货
        /// 作    者: 付强
        /// 创建时间: 2007-10-6
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        private int IsExistRecord(long orderId)
        {
            return deliveryOrderDao.ExistsRecord(orderId);
        }
        /// <summary>
        /// 名    称: DeliveryOrder
        /// 功能概要: 订单送货
        /// 作    者: 刘伟
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="deliveryOrderList"></param>
        [Transaction]
        public void DeliveryOrder(IList<DeliveryOrder> deliveryOrderList)
        { 
            for(int i=0;i<deliveryOrderList.Count;i++)
            {
                if (IsExistRecord(deliveryOrderList[i].OrdersId) <= 0)
                {
                    deliveryOrderDao.Insert(deliveryOrderList[i]);
                }
            }
        }
        /// <summary>
        /// 名    称: UpdateDeliveryOrder
        /// 功能概要: 核销订单  活没有送出
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="deliveryOrder"></param>
        public void UpdateDeliveryOrder(DeliveryOrder deliveryOrder)
        {
            deliveryOrderDao.Update(deliveryOrder);
        }


        /// <summary>
        /// 名    称:CancelAfterVerification
        /// 功能概要: 核销订单 活已经送出
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="deliveryOrder"></param>
        /// <param name="orderStatusAlter">状态变更履历</param>
        /// <param name="strOrderNo">订单号</param>
        /// <param name="orderStatusFlag">订单状态</param>
        public void CancelAfterVerification(DeliveryOrder deliveryOrder, OrdersStatusAlter orderStatusAlter, string strOrderNo, int orderStatusFlag)
        {
            deliveryOrderDao.Update(deliveryOrder);
            UpdateOrderStatusByOrderNo(strOrderNo, orderStatusFlag);
            //保存订单状态变更履历
            ordersStatusAlterDao.Insert(orderStatusAlter);//17

        }
        /// <summary>
        /// 名    称: GetDeliveryOrder
        /// 功能概要: 根据订单号获得送货状态信息
        /// 作    者: 付强　
        /// 创建时间: 2007-10-5
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        public DeliveryOrder GetDeliveryOrder(string strOrderNo)
        {
            return deliveryOrderDao.GetDeliveryOrderByOrdersId(SelectOrderIdByOrderNo(strOrderNo));
        }
        #endregion


        #region 返回价格因素的文本值
               /// <summary>
        /// 名    称: GetFactorValueText
        /// 功能概要: 返回相应的价格因素的文本值
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// </summary>
        /// <param name="orderItemList">订单价格因素列表</param>
        public void GetFactorValueText(IList<OrderItem> orderItemList)
        {
            bool flag=false;
            for(int i=0;i<orderItemList.Count;i++)
            {
                PriceFactor priceFactor=new PriceFactor();
                priceFactor.TargetTable = orderItemList[i].TargetTable;
                priceFactor.TargetValueColumn = orderItemList[i].TargetValueColumn;
                priceFactor.TargetTextColumn = orderItemList[i].TargetTextColumn;
                if(StringUtils.IsEmpty(orderItemList[i].TargetTable))
                {
                    priceFactor.PriceFactorId=orderItemList[i].PriceFactorId;
                    priceFactor.PriceValueId=Int64.Parse(orderItemList[i].Values);
                    flag = true;
                }
                else
                {
                    priceFactor.PriceValueId=Int64.Parse(orderItemList[i].Values);
                }
                orderItemList[i].Name=factorValueDao.GetFactorValueByFactorValueId(priceFactor,flag);
                flag = false;
            }
        }
        /// <summary>
        /// 名    称: GetFactorValueText
        /// 功能概要: 返回相应的价格因素的文本值
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="realOrderItemList">实际订单价格因素列表</param>
        public void GetFactorValueText(IList<RealOrderItem> realOrderItemList)
        {
            bool flag = false;
            for (int i = 0; i < realOrderItemList.Count; i++)
            {
                PriceFactor priceFactor = new PriceFactor();
                priceFactor.TargetTable = realOrderItemList[i].TargetTable;
                priceFactor.TargetValueColumn = realOrderItemList[i].TargetValueColumn;
                priceFactor.TargetTextColumn = realOrderItemList[i].TargetTextColumn;
                if (StringUtils.IsEmpty(realOrderItemList[i].TargetTable))
                {
                    priceFactor.PriceFactorId = realOrderItemList[i].PriceFactorId;
                    priceFactor.PriceValueId = Int64.Parse(realOrderItemList[i].Values);
                    flag = true;
                }
                else
                {
                    priceFactor.PriceValueId = Int64.Parse(realOrderItemList[i].Values);
                }
                realOrderItemList[i].Name = factorValueDao.GetFactorValueByFactorValueId(priceFactor, flag);
                flag = false;

            }
        }
        #endregion

        #region 获取订单信息

        /// <summary>
        /// 名    称: SelectOrderIdByOrderNo
        /// 功能概要: 通过订单号查找订单ID
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单ID</returns>
        public long SelectOrderIdByOrderNo(string strOrderNo)
        {
            return orderDao.SelectOrderIdByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderInfoByOrderNo
        /// 功能概要: 通过订单号查找订单信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单信息</returns>
        public Order GetOrderInfoByOrderNo(string strOrderNo)
        {
            return orderDao.SelectOrderInfoByOrderId(SelectOrderIdByOrderNo(strOrderNo));
        }
        /// <summary>
        /// 名    称: GetOrderItemListByOrderNo
        /// 功能概要: 通过订单号查询订单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单明细</returns>
        public IList<OrderItem> GetOrderItemListByOrderNo(string strOrderNo)
        {
            return orderItemDao.GetOrderItemListByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemByOrderNo
        /// 功能概要: 通过订单号查询订单明细信息
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单明细</returns>
        public IList<OrderItem> GetOrderItemByOrderNo(string strOrderNo)
        {
            return orderItemDao.GetOrderItemByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemEmployeeByOrderNo
        /// 功能概要: 查找订单明细的参与人员
        /// 作    者: 付强
        /// 创建时间: 2008-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="strOrderNo"></param>
        /// <returns></returns>
        public IList<OrderItemEmployee> GetOrderItemEmployeeByOrderNo(string strOrderNo)
        {
            return orderItemEmployeeDao.GetOrderItemEmployeeByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemFactorValueByOrderNo
        /// 功能概要: 通过订单号查询订单明细因素的值
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单明细因素值列表</returns>
        public IList<OrderItem> GetOrderItemFactorValueByOrderNo(string strOrderNo)
        {
            return orderItemDao.GetOrderItemFactorValueByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: GetOrderItemPrintRequireByOrderNo
        /// 功能概要: 通过订单号查询订单明细的印制要求
        /// 作    者: 付强
        /// 创建时间: 2007-9-28
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="strOrderNo">订单号</param>
        /// <returns>订单明细的印制要求</returns>
        public IList<OrderItemPrintRequireDetail> GetOrderItemPrintRequireByOrderNo(string strOrderNo)
        {
            return orderItemPrintRequireDetailDao.GetOrderItemPrintRequireDetailByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: 
        /// 功能概要: 查找订单明细的相关人员
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="orderItemEmployee"></param>
        /// <returns>订单明细雇员列表</returns>
        public IList<OrderItemEmployee> SelectOrderItemEmployee(OrderItemEmployee orderItemEmployee)
        {
            return orderItemEmployeeDao.SelectOrderItemEmployee(orderItemEmployee);
        }
        #endregion

        #region 获取实际订单明细
        /// <summary>
        /// 名    称: GetRealOrderItemByOrderId
        /// 功能概要: 通过OrderId获取实际订单名细
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <returns>实际订单明细</returns>
        public IList<RealOrderItem> GetRealOrderItemByOrderId(long orderId)
        {
            return realOrderItemDao.GetRealOrderItemByOrderId(orderId);
        }
        /// <summary>
        /// 名    称: GetRealOrderItemFactorValueByOrderId
        /// 功能概要: 通过OrderId获取实际订单明细因素的值
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns>实际订单明细</returns>
        public IList<RealOrderItem> GetRealOrderItemFactorValueByOrderId(long orderId)
        {
            return realOrderItemDao.GetRealOrderItemFactorValueByOrderId(orderId);
        }
        /// <summary>
        /// 名    称: GetRealOrderItemPrintRequire
        /// 功能概要: 通过OrderId获取实际订单明细印制要求的值
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">订单ID</param>
        /// <returns>订单明细的印制要求</returns>
        public IList<RealOrderItemPrintRequire> GetRealOrderItemPrintRequire(long orderId)
        {
            return realOrderItemPrintRequireDao.GetRealOrderItemPrintRequire(orderId);
        }
        /// <summary>
        /// 名    称: GetRealOrderItemEmployeebyOrderId
        /// 功能概要: 通过OrderId获取实际订单明细的人员
        /// 作    者: 付强
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <returns>实际订单明细的雇员</returns>
        public IList<RealOrderItemEmployee> GetRealOrderItemEmployeebyOrderId(long orderId)
        { 
            return realOrderItemEmployeeDao.GetRealOrderItemEmployeeByOrderId(orderId);
        }
        #endregion

        //#region 通过Customer_Id查询Orders信息
        ///// <summary>
        ///// 名    称: SearchOrderByCustomerId
        ///// 功能概要: 通过Customer_Id查询Orders信息
        ///// 作    者: 刘伟
        ///// 创建时间: 2007-10-5
        ///// 修正履历:
        ///// 修正时间:
        ///// </summary>
        ///// <param name="Id">CustomerId</param>
        ///// <returns>符合条件的订单列表</returns>
        //public IList<Order> SearchOrderByCustomerId(long Id)
        //{
        //    return orderDao.SelectOrderByCustomerId(Id);
        //}
        //#endregion

        #region 通过会员卡号查找相关客户信息
        /// <summary>
        /// 名    称: SelectCustomerInfoByMemberCardNo
        /// 功能概要: 通过会员卡号查找相关客户信息
        /// 作    者: 付强
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <returns>返回会员信息</returns>
        public MemberCard SelectCustomerInfoByMemberCardNo(string memberCardNo)
        {
            return memberCardDao.SelectCustomerInfoByMemberCardNo(memberCardNo);
        }
        #endregion

        #endregion

        #region IOrderService 成员

        /// <summary>
        /// 获取订单下实际已预付款
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public decimal GetPrePayAmount(Order order)
        {
            return orderDao.GetPrePayAmount(order);
        }
        #endregion

        #region
        public int SearchCustomerInOrder(long Id)
        {
            return orderDao.SearchCustomerInOrder(Id);
        }
        #endregion

		#region 订单查询(财务管理)
		/// <summary>
		/// 订单查询
		/// </summary>
		/// <returns></returns>
		/// <remarks>
		/// 作    者: 刘伟
		/// 创建时间: 2007-10-25
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> SearchOrdersItem(Hashtable condition)
		{
			return orderDao.SearchOrdersItem(condition);
		}

		public int SearchOrdersItemCount(Hashtable condition)
		{
			return orderDao.SearchOrdersItemCount(condition);
		}

		public Order SearchOrdersItemAmount(Hashtable condition)
		{
			return orderDao.SearchOrdersItemAmount(condition);
		}

		#endregion

        #region 通过订单号查询消费数量
        public string SearchAmounts(IList<Order> orderList)
        {
            string amounts = "";
            if (orderList.Count != 0)
            {
                foreach (Workflow.Da.Domain.Order order in orderList)
                {
                    amounts += orderItemDao.SelectAmountByOrderId(order.Id);
                    amounts += ",";
                }
            }

            return amounts;
        }
        #endregion

        #region 结账用

        public IList<OrderItem> GetCashOrderItemByOrderId(string StrOrderNo)
        {
            return orderItemDao.GetOrderItemByOrderNo(StrOrderNo);
        }

        public IList<OrderItem> GetCashOrderItemFactorValueByOrderId(string StrOrderNo)
        {
            return orderItemDao.GetOrderItemFactorValueByOrderNo(StrOrderNo);
        }


        public IList<OrderItemPrintRequireDetail> GetCashOrderItemPrintRequire(string StrOrderNo)
        {
            return orderItemPrintRequireDetailDao.GetOrderItemPrintRequireDetailByOrderNo(StrOrderNo);
        }


        public IList<OrderItemEmployee> GetCashOrderItemEmployeebyOrderId(string StrOrderNo)
        {
            return orderItemEmployeeDao.GetOrderItemEmployeeByOrderNo(StrOrderNo);
        }

        #endregion

        /// <summary>
        /// 查找某一个会员卡下的优惠活动
        /// </summary>
        /// <param name="orderId">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public IList<MemberCardConcession> SelectMemberCardConcessionByPriceIdAndConcessionId(MemberCardConcession memberCardConcession)
        {
            return memberCardConcessionDao.SelectMemberCardConcessionByPriceIdAndConcessionId(memberCardConcession);
        }
        /// <summary>
        /// 会员卡消费
        /// </summary>
        /// <param name="orderId">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-22
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        [Transaction]
        public void UpdateMemberCardConsume(MemberCardConcession memberCardConcession, MemberCard memberCard)
        {
            if (null != memberCardConcession && null != memberCard)
            {
                memberCardConcessionDao.UpdateMemberCardConcessionById(memberCardConcession);
                memberCardDao.UpdateMemberCardConsumeAmount(memberCard);
            }
        }

        #region 计算会员卡刷卡次数
        /// <summary>
        /// 计算会员卡刷卡次数
        /// </summary>
        /// <param name="orderId">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-23
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public int SearchMemberCardBrushNumber(string MemberCardNo)
        {
            return orderDao.SelectMemberCardBrushNumber(MemberCardNo);
        }


        #endregion

        /// <summary>
        /// 获取所以需要预付款的订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public IList<Order> GetAllNeedPrePayOrders(Order iorder)
        { 
            return orderDao.GetAllNeedPrePayOrders(iorder);
        }

        /// <summary>
        /// 获取所有需要预付款的订单的数量
        /// </summary>
        /// <param name="iorder"></param>
        /// <returns></returns>
        public long GetAllNeedPrePayOrdersCount(Order iorder)
        {
            return orderDao.GetAllNeedPrePayOrdersCount(iorder);
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
            return orderDao.GetOrderPrepayAmountTotalAndSumAmountTotal(order);
        }

        /// <summary>
        /// 获取客户的支付方式
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer GetCustomerInfoByCustomerId(long customerId)
        {
            return customerDao.SelectByPk(customerId);
        }
        /// <summary>
        /// 包含时机已经预付款金额的order
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Order SelectOrderInfoByOrderIdPrePaid(long orderId)
        {
            return orderDao.SelectOrderInfoByOrderIdPrePaid(orderId);
        }

        #region//按照时间段查询应收款

        /// <summary>
		/// 名    称: 
		/// 功能概要: 按时间段和客户名称获取应收款信息的Order(限制行数)
		/// 作    者: 张晓林
		/// 创建时间: 2008-11-26
		/// 修正履历: 
		/// 修正时间: 
		/// </summary>
		/// <param name="hashtable">时间段和客户条件的组合条件或者其中的单一条件</param>
		/// <returns></returns>
		public IList<Order> GetAccountReceviableAccordingToTimeSectTotal(Hashtable hashtable)
		{
			return orderDao.GetAccountReceviableAccordingToTimeSectTotal(hashtable);
		}

		/// <summary>
		/// 名    称: 
		/// 功能概要: 按时间段和客户名称获取应收款信息的总记录数
		/// 作    者: 张晓林
		/// 创建时间: 2008-11-28
		/// 修正履历: 
		/// 修正时间:
		/// </summary>
		/// <param name="hashCondition"></param>
		/// <returns></returns>
		public long GetSearchAccountReceviableInfoCount(Hashtable hashCondition)
		{
			return orderDao.GetSearchAccountReceviableInfoCount(hashCondition);
		}

		/// <summary>
		/// 名    称: 
		/// 功能概要: 按时间段和客户名称获取应收款信息的Order(没有限制行数)
		/// 作    者: 张晓林
		/// 创建时间: 2008-11-29
		/// 修正履历: 
		/// 修正时间: 
		/// </summary>
		/// <param name="hashCondition"></param>
		/// <returns></returns>
		public IList<Order> GetAllAccountReceiviable(Hashtable hashCondition) 
		{
			return orderDao.GetAccountReceviableTotal(hashCondition);
        }
        #endregion

        #region//日报

        /// <summary>
		///	(按照日期查询)日报Order(限制行数的)
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-12-2
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public IList<Order> GetDailyPaper(Hashtable hashCondition) 
		{
			return orderDao.GetDailyPaper(hashCondition);
		}

		/// <summary>
		/// 按照日期查询 日报总记录数
		/// </summary>
		/// <remarks>
		/// 作    者: 张晓林
		/// 创建时间: 2008-12-2
		/// 修正履历: 
		/// 修正时间:
		/// </remarks>
		public long GetDailyPaperTotal(Hashtable hashCondition) 
		{
			return orderDao.GetDailyPaperTotal(hashCondition);
		}

        /// <summary>
        /// (按照日期查询)日报Orders(打印)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-4
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetDailyPaperPrint(Hashtable hashCondition) 
        {
            return orderDao.GetDailyPaperPrint(hashCondition);
        }
        #endregion

        #region//返回订单(返回到"修正"状态)
        /// <summary>
        /// 返回订单(返回到"修正"状态)
        /// </summary>
        /// <param name="orderStatusAlter"></param>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2008-12-23
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public void ReturnOrder(OrdersStatusAlter orderStatusAlter) 
        {
            ordersStatusAlterDao.Insert(orderStatusAlter);//18
        }
        #endregion

        /// <summary>
        /// 获取订单的优惠
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public IList<PaymentConcession> GetOrderPaymentConcessionByOrderId(long ordersId)
        {
            return paymentConcessionDao.GetOrderPaymentConcessionByOrderId(ordersId);
        }


        public IList<User> GetAllUser()
        {
            return userDao.SelectAll();
        }

        #region 获取业绩中需要的订单详情的信息

        /// <summary>
        /// 获取业绩中需要的订单详情的信息
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// </remarks>
        public string GetProcessContent(long orderItemId)
        {
            return processContentDao.GetProcessContentByOrderItemId(orderItemId);
        }

        #endregion

        #region 通过订单明细id获取订单明细下所有的雇工

        /// <summary>
        /// 通过订单明细id获取订单明细下所有的雇工
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// </remarks>
        public IList<Employee> GetOrderItemEmployeeByOrderItemId(long orderItemId)
        {
            return employeeDao.GetEmployeeByOrderItemId(orderItemId);
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
			return orderItemDao.GetNotFinishedOrderWithInfo();
		}

		#endregion

        #region //根据客户名称获取客户Id
        /// <summary>
        /// 名    称: GetCustomerIdByCustomerName
        /// 功能概要: 根据客户名称获取客户信息
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月9日16:19:38
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public Customer GetCustomerInfoByName(string customerName) 
        {
            return orderDao.GetCustomerInfoByName(customerName);
        }
        #endregion

		#region 通过订单id,获取 订单明细的价格因素值

		/// <summary>
		/// 通过订单id,获取 订单明细的价格因素值
		/// </summary>
		/// <param name="orderId">订单id</param>
		/// <returns>订单明细的价格因素值列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-5-19
		/// </remarks>
		public IList<OrderItemPriceFactor> GetAllOrderItemPriceFactorByOrderNo(string orderNo)
		{
			IList<OrderItem> orderItemList = GetCashOrderItemFactorValueByOrderId(orderNo);

			GetFactorValueText(orderItemList);

			


			return null;
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
            return orderDao.GetCustomerPayTypeByCustomerId(customerId);
        }

        #region//返回订单(返回到"已登记"状态)
        
        /// <summary>
        /// 返回订单(返回到"修正"状态)
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// 作     者:张晓林
        /// 创建时间:2009年10月12日9:50:37
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        [Transaction]
        public long ReurnOrderToNoblankoutrecord(long orderId) 
        {
            //更新订单
            Order order = new Order();
            order.Id = orderId;
            order.Status = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
            order.BranchShopId = ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;
            order.CompanyId = ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            order.NotPayTicketAmount = 0;
            order.PaidAmount = 0;
            order.PaidTicketAmount = 0;
            order.RealPaidAmount = 0;
            orderDao.UpdateOrderByReturnOrder(order);

            //删除业绩
            Achievement achievement=new Achievement();
            achievement.OrdersId=orderId;
            achievementDao.DeleteAchievementByOrdersId(achievement);

            //删除订单结算信息
            gatheringDao.DeleteGatheringOrderInfo(orderId);

            //记录本次订单变更信息
            OrdersStatusAlter orderStatusAlter = new OrdersStatusAlter();
            orderStatusAlter.Memo = "返回订单";
            orderStatusAlter.OrdersId = orderId;
            orderStatusAlter.Status = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
            ordersStatusAlterDao.Insert(orderStatusAlter);//19
            return 1;
        }
        #endregion

        /// <summary>
        /// 名    称: GetOrderItemEmployeeListByOrderNo
        /// 功能概要: 根据订单号获取订单明细雇员列表
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日13:25:42
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        public IList<OrderItemEmployee> GetOrderItemEmployeeListByOrderNo(string orderNo) 
        {
            return orderItemEmployeeDao.GetOrderItemEmployeeListByOrderNo(orderNo);
        }

        /// <summary>
        /// 名    称: GetOrderItemFactorValueListByOrderNO
        /// 功能概要: 根据订单号获取订单明细因素值列表
        /// 作    者：张晓林
        /// 创建时间: 2009年11月23日13:26:05
        /// 修正履历：
        /// 修正时间：
        /// </summary>
        public IList<OrderItemFactorValue> GetOrderItemFactorValueListByOrderNO(string orderNo) 
        {
            return orderItemFactorValueDao.GetOrderItemFactorValueListByOrderNO(orderNo);
        }

        /// <summary>
        /// 名    称: GetOrderItemMortgageByOrderNo
        /// 功能概要: 根据订单Id获取订单冲减明细
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月25日11:01:34
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        public IList<OrderItemMortgage> GetOrderItemMortgageByOrderNo(long orderId) 
        {
            return orderItemMortgageDao.GetOrderItemMortgageByOrderNo(orderId);
        }

        /// <summary>
        /// 记录送货到期的订单
        /// </summary>
        /// <param name="orderList">condition</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月3日11:23:10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        [Transaction]
        public void RecordMaturenessOrders(IList<Order> orderList) 
        {
            OrderTimeoutAlarmRecord ota=null;
            foreach(Order order in orderList)
            {
                if (!orderTimeoutAlarmRecordDao.CheckOrderTimeoutAlarmRecordIsExist(order.Id))
                {
                    ota = new OrderTimeoutAlarmRecord();
                    ota.OrdersId = order.Id;
                    ota.Memo = "到期订单";
                    orderTimeoutAlarmRecordDao.Insert(ota);
                }
            }
        }
       
        /// <summary>
        /// 获取当天下单的所有未完成且未作废的订单
        /// </summary>
        /// <param name="order">condition</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月3日15:54:39
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public IList<Order> GetAllNotSucessedOrdersList(Order order) 
        {
            return orderTimeoutAlarmRecordDao.GetAllNotSucessedOrdersList(order);
		}

		#region 获取订单


		public IList<Order> GetOrders(DateTime beginTime, DateTime endTime, int paymentType,int orderStatus,string userName)
		{
			return orderDao.GetOrders(beginTime, endTime, paymentType, orderStatus,userName);
		}

		#endregion


        #region
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
            return orderDao.GetOrderNoByMemberCardNo(strMemberCardNo);
        }
        #endregion

        #region//获取前期修正的订单Id
        /// <summary>
        /// 根据订单号获取前期修正的订单Id
        /// </summary>
        /// <param name="orderNo">order</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月11日15:25:18
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long GetPhophaseOrderId(Order order) 
        {
            return paymentConcessionDao.GetPhophaseOrderId(order);
        }
        public Order GetOrderById(long orderId) 
        {
            return orderDao.SelectByPk(orderId);
        }
        #endregion

        /// <summary>
        /// 获取订单正式打印的次数
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年3月2日14:57:10
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public int GetOrderPrintCountByOrderNo(string strOrderNo) 
        {
            return ordersStatusAlterDao.GetOrderPrintCountByOrderNo(strOrderNo);
        }

        /// <summary>
        /// 获取订单明细版本最大值
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年3月5日10:19:10
        /// 修正履历：
        /// 修正时间：
        /// </remarks>
        public int SelectOrderItemMaxVersion(string orderNo)
        {
            return orderItemDao.SelectOrderItemMaxVersion(orderNo);
        }

        /// <summary>
        /// 获取分配员工的所有订单信息
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年4月2日16:56:02
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public OrderItem GetEmployeeReceptionOrderInfo(long employeeId) 
        {
            return orderItemDao.GetEmployeeReceptionOrderInfo(employeeId);
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
            return orderItemDao.GetReceptionOrderDetail(oi);
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
            return orderItemDao.BluringSearchOrderByOrderNo(orderNo,isSucessed);
        }

        /// <summary>
        /// 获取当前订单明细的加工类型的前期业绩比例
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年5月11日16:23:51
        /// </remarks>
        public decimal GetProcessContentAchievementRate(long orderItemId) 
        {
            return processContentDao.GetProcessContentAchievementRate(orderItemId);
        }

        /// <summary>
        /// 获取送货到期时间/到期颜色/过期颜色
        /// </summary>
        /// <remarks>
        /// 作    者：张晓林
        /// 创建时间: 2010年5月20日15:59:20
        /// 修正履历：
        /// 修正时间:
        /// </remarks>
        public string GetDeliverMaturityTime() 
        {
            string strList;
            strList = applicationProperty.GetProperty("Matureness_Color") + ",";//到期颜色
            strList += applicationProperty.GetProperty("Overdue_Color") + ",";//过期颜色
            strList += applicationProperty.GetProperty("Matureness_Time");   //到期时间
            return strList;
        }


        /// <summary>
        /// 根据选择的日期计算选项卡列表
        /// </summary>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年7月6日9:16:14
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Order.DateOptionCard> GetOptionCardList(int DateTag) 
        {
            
            List<Order.DateOptionCard> dateOptionCardList = new List<Order.DateOptionCard>();
            DateTime currentDateTime = DateTime.Now.AddDays(DateTag);
            Order.DateOptionCard docBeforeDay = new Order.DateOptionCard();
            docBeforeDay.Key = DateTag - 1;
            docBeforeDay.Text = "前一天";
            dateOptionCardList.Add(docBeforeDay);
            if (DateTime.Now.ToShortDateString() == currentDateTime.ToShortDateString())
            {
                Order.DateOptionCard docCurrentDay = new Order.DateOptionCard();
                docCurrentDay.Key = 0;
                docCurrentDay.Text = "今日";
                docCurrentDay.IndirectKey = "No";
                dateOptionCardList.Add(docCurrentDay);
            }
            else 
            {
                Order.DateOptionCard docCurrentDay = new Order.DateOptionCard();
                docCurrentDay.Key = 0;
                docCurrentDay.Text = GetCurrentDateString(currentDateTime);
                dateOptionCardList.Add(docCurrentDay);

                docCurrentDay.IndirectKey = "No";
                Order.DateOptionCard docAfterDay = new Order.DateOptionCard();
                docAfterDay.Key = DateTag+1;
                docAfterDay.Text = "后一天";
                dateOptionCardList.Add(docAfterDay);
            }
            return dateOptionCardList;
        }
        /// <summary>
        /// 根据选择的日期计算选项卡列表
        /// </summary>
        /// <param name="currentDateTime"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年7月6日9:16:14
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public string GetCurrentDateString(DateTime time) 
        {
            string str="";
            string[] textArry ={ "周一", "周二", "周三", "周四", "周五", "周六", "周日" };
            string[] keyArry ={ "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
            List<string> textList = new List<string>();
            List<string> keyList = new List<string>();
            textList.AddRange(textArry);
            keyList.AddRange(keyArry);
            List<Order.DateOptionCard> DateList = new List<Order.DateOptionCard>();
            foreach (string text in textList)
            {
                Order.DateOptionCard dateOptionCard = new Order.DateOptionCard();
                dateOptionCard.Text = text;
                foreach (string key in keyList)
                {
                    dateOptionCard.IndirectKey = key;
                    break;
                }
                keyList.Remove(dateOptionCard.IndirectKey);
                DateList.Add(dateOptionCard);
            }
            DateTime dateTime = DateTime.Now;
            string strTemp = "";//临界日期;当前时间距离最近的周一日期
            string strTempEndDate = "";
            string strB = "", strE = "";//本周始末时间
            switch(dateTime.DayOfWeek.ToString())
            {
                case "Monday":
                    strB = dateTime.ToShortDateString();
                    strE = dateTime.AddDays(6).ToShortDateString();
                    strTemp = dateTime.ToShortDateString();
                    strTempEndDate = dateTime.AddDays(-7).ToShortDateString();
                    break;
                case "Tuesday":
                    strB = dateTime.AddDays(-1).ToShortDateString();
                    strE = dateTime.AddDays(5).ToShortDateString();
                    strTemp = dateTime.AddDays(-1).ToShortDateString();
                    strTempEndDate = dateTime.AddDays(-8).ToShortDateString();
                    break;
                case "Wednesday":
                    strB = dateTime.AddDays(-2).ToShortDateString();
                    strE = dateTime.AddDays(4).ToShortDateString();
                    strTemp = dateTime.AddDays(-2).ToShortDateString();
                    strTempEndDate = dateTime.AddDays(-9).ToShortDateString();
                    break;
                case "Thursday":
                    strB = dateTime.AddDays(-3).ToShortDateString();
                    strE = dateTime.AddDays(3).ToShortDateString();
                    strTemp = dateTime.AddDays(-3).ToShortDateString();
                    strTempEndDate = dateTime.AddDays(-10).ToShortDateString();
                    break;
                case "Friday":
                    strB = dateTime.AddDays(-4).ToShortDateString();
                    strE = dateTime.AddDays(2).ToShortDateString();
                    strTemp = dateTime.AddDays(-4).ToShortDateString();
                    strTempEndDate = dateTime.AddDays(-11).ToShortDateString();
                    break;
                case "Saturday":
                    strB = dateTime.AddDays(-5).ToShortDateString();
                    strE = dateTime.AddDays(1).ToShortDateString();
                    strTemp = dateTime.AddDays(-5).ToShortDateString();
                    strTempEndDate = dateTime.AddDays(-12).ToShortDateString();
                    break;
                case "Sunday":
                    strB = dateTime.AddDays(-6).ToShortDateString();
                    strE = dateTime.ToShortDateString();
                    strTemp = dateTime.AddDays(-6).ToShortDateString();
                    strTempEndDate = dateTime.AddDays(-13).ToShortDateString();
                    break;
            }
            foreach(Order.DateOptionCard doc in DateList)
            {
                if (doc.IndirectKey == time.DayOfWeek.ToString())
                {
                    TimeSpan ts=dateTime - time;
                    if (1 == ts.Days) str = "昨日";
                    else if (2 == ts.Days) str = "前日";
                    else 
                    {
                        if (time < Convert.ToDateTime(strTemp) && time > Convert.ToDateTime(strTempEndDate))
                        {
                            str = "上" + doc.Text;
                        }
                        else if (time > Convert.ToDateTime(strB) && time < Convert.ToDateTime(strE))
                        {
                            str ="本" + doc.Text;
                        }
                        else
                        {
                            str=time.ToShortDateString();
                        }
                    }
                    break;
                }
            }
            return str;
        }
	}
}
