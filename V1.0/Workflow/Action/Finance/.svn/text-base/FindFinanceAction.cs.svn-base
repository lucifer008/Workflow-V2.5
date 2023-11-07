using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Log;
using Workflow.Action.Finance.Model;
/// <summary>
/// 名    称: FinanceAction
/// 功能概要: 财务查询Action
/// 作    者: 张晓林
/// 创建时间: 2009-01-23
/// 修正履历: 
/// 修正时间: 
/// </summary>
namespace Workflow.Action.Finance
{
    public class FindFinanceAction : BaseAction
    {
        #region Service

        private IFindFinanceService findFinanceService;
        public IFindFinanceService FindFinanceService
        {
            set { findFinanceService = value; }
        }

        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService 
        {
            set { masterDataService = value; }
        }

        private Service.OrderManage.IOrderService orderService;
        public Service.OrderManage.IOrderService OrderService 
        {
            set { orderService = value; }
        }
        #endregion

        #region Dao
        private IApplicationPropertyDao applicationPropertyDao;
        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }
        #endregion

        #region Model
        private FindFinanceModel model=new FindFinanceModel();
        public FindFinanceModel Model
        {
            set { model = value; }
            get { return model; }
        }
        private OrderModel orderModel = new OrderModel();
        public OrderModel OrderModel 
        {
            set { orderModel = value; }
            get { return orderModel; }
        }
        #endregion

        #region 根据查询条件获取帐龄工单信息
        /// <summary>
        /// 根据查询条件获取帐龄工单信息
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void GetAnalyzeDebt()
        {
            model.OrderList=findFinanceService.GetAnalyzeDebt(model.Order);
            model.OList = findFinanceService.GetAnalyzeAssistantDebt(model.Order);
        }

        #endregion

        #region 获取某部门人员
        /// <summary>
        /// 获取某部门人员
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void GetCasherEmployeeList(long positionId)
        {
            model.EmployeeList=findFinanceService.GetCasherEmployeeList(positionId);

        }
        #endregion

        #region //应收款查询
        public void GetOperatorList()
        {
            model.OperatorList = findFinanceService.GetOperator();
        }

        /// <summary>
        /// 应收款查询(分页)
        /// </summary>
        public void GetCustomerArrearage()
        {
            model.OrderList = findFinanceService.GetCustomerArrearage(model.Order);
        }

        /// <summary>
        ///  获取应收款打印数据（打印）
        /// </summary>
        public void GetaAllCustomerArrearage()
        {
            model.OrderPrintList = findFinanceService.GetaAllCustomerArrearage(model.Order);
        }

        /// <summary>
        /// 获取应收款总记录数
        /// </summary>
        /// <returns></returns>
        public long GetSelectCustomerArrearageCount()
        {

            return findFinanceService.GetSelectCustomerArrearageCount(model.Order);
        }
        #endregion

        #region //月报
       
        /// <summary>
        /// 获取月报列表(orderList)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2008-12-9
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void SearchMonthPaperOrder_ToPrint() 
        {
            Hashtable hashCondition = new Hashtable();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashCondition.Add("BranchShopId", user.BranchShopId);
            hashCondition.Add("CompanyId", user.CompanyId);
            hashCondition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);
            hashCondition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            hashCondition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            hashCondition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            hashCondition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            hashCondition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
            hashCondition.Add("BeginHandOverDateTime", model.NewOrder.CurrentHandOverBeginDate);
            hashCondition.Add("EndHandOverDateTime", model.NewOrder.CurrentHandOverEndDate);
            model.OrderTempList= findFinanceService.GetMonthPaperPrint(hashCondition);
        }
        #endregion

        #region //日报
        /// <summary>
        /// 名    称: SearDailyPaper
        /// 功能概要: 查询日报(分页)
        /// 作    者: 张晓林
        /// 创建时间: 2007-12-2
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchDailyPaperOrder(int currentPageIndex)
        {
            Hashtable hashCondition = new Hashtable();
            hashCondition.Clear();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashCondition.Add("BranchShopId", user.BranchShopId);
            hashCondition.Add("CompanyId", user.CompanyId);
            hashCondition.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            hashCondition.Add("PageCount", currentPageIndex);
            hashCondition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//工单状态为:已经完成
            hashCondition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            hashCondition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            hashCondition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            hashCondition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
            hashCondition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            hashCondition.Add("BeginHandOverDateTime", orderModel.NewOrder.CurrentHandOverBeginDate);
            hashCondition.Add("EndHandOverDateTime", orderModel.NewOrder.CurrentHandOverEndDate);
            OrderModel.OrderTempList = findFinanceService.GetDailyPaper(hashCondition);//分页显示数据
            AddMoney(findFinanceService.GetDailyPaperPrint(hashCondition));//合计当前查询的记账金额，发票金额，现金 
            orderModel.NeedPrePayOrdersCount = findFinanceService.GetDailyPaperTotal(hashCondition);//满足条件的记录数
        }

        private void AddMoney(IList<Order> orderList) 
        {
            foreach(Order o in orderList)
            {
                OrderModel.CashTotal += o.PaidAmount;
                OrderModel.TicketTotal += o.NotPayTicketAmount;
                if (o.AccountReceviableOweMomeyTotal>=0)
                {
                    OrderModel.OweTotal += o.AccountReceviableOweMomeyTotal;
                }
            }
        }
        /// <summary>
        /// 名    称: SearchDailyPaperOrder_ToPrint
        /// 功能概要: 查询日报(打印)
        /// 作    者: 张晓林
        /// 创建时间: 2007-12-4
        /// 修正履历: 
        /// 修正时间: 2008-12-12
        /// </summary>
        public void SearchDailyPaperOrder_ToPrint()
        {
            Hashtable hashCondition = new Hashtable();
            hashCondition.Clear();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashCondition.Add("BranchShopId", user.BranchShopId);
            hashCondition.Add("CompanyId", user.CompanyId);
            hashCondition.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//工单状态为:已经完成
            hashCondition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            hashCondition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            hashCondition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            hashCondition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            hashCondition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
            hashCondition.Add("BeginHandOverDateTime", orderModel.NewOrder.CurrentHandOverBeginDate);
            hashCondition.Add("EndHandOverDateTime", orderModel.NewOrder.CurrentHandOverEndDate);
            OrderModel.OrderList = findFinanceService.GetDailyPaperPrint(hashCondition);
        }
        #endregion

        #region //计算当前月有多少天
        /// <summary>
        /// 当前月有多少天
        /// </summary>
        /// <param name="y">当前年份</param>
        /// <param name="m">当前月份</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月1日9:14:16
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public int HowMonthDay(int y, int m)
        {
            int mnext;
            int ynext;
            if (m < 12)
            {
                mnext = m + 1;
                ynext = y;
            }
            else
            {
                mnext = 1;
                ynext = y + 1;
            }
            DateTime dt1 = System.Convert.ToDateTime(y + "-" + m + "-1");
            DateTime dt2 = System.Convert.ToDateTime(ynext + "-" + mnext + "-1");
            TimeSpan diff = dt2 - dt1;
            return diff.Days;
        }
        #endregion

        #region //应收款按照时间段统计

        /// <summary>
        /// 名    称: SearchAccountReceivableAccordingToTime
        /// 功能概要: 按时间段统计和客户统计 应收款(分页)
        /// 作    者: 张晓林
        /// 创建时间: 2007-11-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        /// <param name="currentPageIndex">当前的页码</param>
        public void SearchAccountReceivableAccordingToTime(int currentPageIndex)
        {
            Hashtable hashtable = new Hashtable();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashtable.Add("BranchShopId", user.BranchShopId);
            hashtable.Add("CompanyId", user.CompanyId);
            hashtable.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//统计状态为 已经结算 的工单

            if (OrderModel.NewOrder.CustomerName != null && OrderModel.NewOrder.CustomerName != "")
            {
                hashtable.Add("CustomerName", "%" + OrderModel.NewOrder.CustomerName + "%");
            }

            if (OrderModel.NewOrder.BeginBalanceDate != null && OrderModel.NewOrder.BeginBalanceDate != "")
            {
                hashtable.Add("BeginBalanceDate", OrderModel.NewOrder.BeginBalanceDate);
            }
            if (OrderModel.NewOrder.EndBalanceDate != null && OrderModel.NewOrder.EndBalanceDate != "")
            {
                hashtable.Add("EndBalanceDate", OrderModel.NewOrder.EndBalanceDate);
            }
            hashtable.Add("RowCount", Constants.ROW_COUNT_FOR_PAGER);
            hashtable.Add("PagerCount", currentPageIndex);
            OrderModel.OrderTempList = findFinanceService.GetAccountReceviableAccordingToTimeSectTotal(hashtable);
        }

        ///<summary>
        /// 名    称: SearchAccountReceivableAccordingToTime
        /// 功能概要: 应收款按时间段统计的总记录数
        /// 作    者: 张晓林
        /// 创建时间: 2007-11-28
        /// 修正履历: 
        /// 修正时间: 
        /// <returns></returns>
        /// </summary>
        public long GetSearchAccountReceviableInfoCount()
        {
            Hashtable hashtable = new Hashtable();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashtable.Add("BranchShopId", user.BranchShopId);
            hashtable.Add("CompanyId", user.CompanyId);
            hashtable.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//统计状态为 已经结算 的工单

            //OrderModel.OrderTempList = findFinanceService.GetAccountReceviableAccordingToTimeSectTotal(hashtable);
            if (OrderModel.NewOrder.CustomerName != null && OrderModel.NewOrder.CustomerName != "")
            {
                hashtable.Add("CustomerName", "%" + OrderModel.NewOrder.CustomerName + "%");
            }

            if (OrderModel.NewOrder.BeginBalanceDate != null && OrderModel.NewOrder.BeginBalanceDate != "")
            {
                hashtable.Add("BeginBalanceDate", OrderModel.NewOrder.BeginBalanceDate);
            }
            if (OrderModel.NewOrder.EndBalanceDate != null && OrderModel.NewOrder.EndBalanceDate != "")
            {
                hashtable.Add("EndBalanceDate", OrderModel.NewOrder.EndBalanceDate);
            }
            return findFinanceService.GetSearchAccountReceviableInfoCount(hashtable);
        }

        /// <summary>
        /// 名    称: SearchAccountReceivableAccordingToTime
        /// 功能概要: 按时间段统计和客户统计 应收款(打印)
        /// 作    者: 张晓林
        /// 创建时间: 2007-11-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchAllAccountReceviable()
        {
            Hashtable hashtable = new Hashtable();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            hashtable.Add("BranchShopId", user.BranchShopId);
            hashtable.Add("CompanyId", user.CompanyId);
            hashtable.Add("Status", Constants.ORDER_STATUS_SUCCESSED_VALUE);//统计状态为 已经结算 的工单

            if (OrderModel.NewOrder.CustomerName != null && OrderModel.NewOrder.CustomerName != "")
            {
                hashtable.Add("CustomerName", "%" + OrderModel.NewOrder.CustomerName + "%");
            }

            if (OrderModel.NewOrder.BeginBalanceDate != null && OrderModel.NewOrder.BeginBalanceDate != "")
            {
                hashtable.Add("BeginBalanceDate", OrderModel.NewOrder.BeginBalanceDate);
            }
            if (OrderModel.NewOrder.EndBalanceDate != null && OrderModel.NewOrder.EndBalanceDate != "")
            {
                hashtable.Add("EndBalanceDate", OrderModel.NewOrder.EndBalanceDate);
            }
            OrderModel.OrderList = findFinanceService.GetAllAccountReceiviable(hashtable);
        }
        #endregion

        #region //收银当班查询

        /// <summary>
        /// 按照收银人查询工单收款信息(分页)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月15日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public void SearchOrderInfoByCashPerson()
        {
            OrderModel.OrderTempList = findFinanceService.SearchOrderByCashPerson(orderModel.NewOrder);
            AddMoney(findFinanceService.SearchOrderByCashPersonPrint(orderModel.NewOrder));//分别合计满足条件的:现金；记账:发票金额
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
        public long SearchOrderInfoByCashPersonRowCount()
        {
            return findFinanceService.SearchOrderByCashPersonRowCount(orderModel.NewOrder);
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
        public void SearchOrderInfoByCashPersonPrint()
        {
            OrderModel.OrderList = findFinanceService.SearchOrderByCashPersonPrint(orderModel.NewOrder);
        }

        ///// <summary>
        ///// 获取查询条件字符串
        ///// </summary>
        ///// <remarks>
        ///// 作    者: 张晓林
        ///// 创建时间: 2009年1月15日
        ///// 修正履历:
        ///// 修正时间:
        ///// </remarks>	
        //public string GetQueryConditionString()
        //{
        //    string startDate = DateTime.Now.ToString("yyyy-MM") + "-" + (DateTime.Now.Day - 1) + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_START_TIME_KEY);
        //    string endDate = DateTime.Now.ToShortDateString() + " " + applicationPropertyDao.GetValue(Constants.APPLICATION_END_TIME_KEY);
        //    string queryConditionString = " 开始日期：" + startDate;
        //    queryConditionString += " 截至日期:" + endDate;
        //    return queryConditionString;
        //}
        #endregion

        #region //预付款查询
        /// <summary>
        /// 查询客户预付款情况
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-26
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void GetCustomerPrepay(int currentPageIndex)
        {
            model.Order.CurrentPageIndex = currentPageIndex;
            model.Order.EveryPageCount = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
            if (null != model.Order.No && "" != model.Order.No)
            {
                model.Order.No = "%" + model.Order.No + "%";
            }

            if (null != model.Order.CustomerName && "" != model.Order.CustomerName)
            {
                model.Order.CustomerName = "%" + model.Order.CustomerName + "%";
            }
            model.OrderList = findFinanceService.GetCustomerPrepay(model.Order);
        }

        /// <summary>
        /// 按照条件 获取预付款信息的总记录数
        /// </summary>
        /// <returns></returns>
        public long GetCustomerPrepayRowsCount()
        {
            if (null != model.Order.No && "" != model.Order.No)
            {
                model.Order.No = "%" + model.Order.No + "%";
            }

            if (null != model.Order.CustomerName && "" != model.Order.CustomerName)
            {
                model.Order.CustomerName = "%" + model.Order.CustomerName + "%";
            }
            return findFinanceService.GetCustomerPrepayRowsCount(model.Order);
        }

        /// <summary>
        /// 按照条件获取 预付款信息(打印)
        /// </summary>
        public void GetCustomerPrepayPrint()
        {
            if (null != model.Order.No && "" != model.Order.No)
            {
                model.Order.No = "%" + model.Order.No + "%";
            }

            if (null != model.Order.CustomerName && "" != model.Order.CustomerName)
            {
                model.Order.CustomerName = "%" + model.Order.CustomerName + "%";
            }
            model.OrderTempList = findFinanceService.GetCustomerPrepayPrint(model.Order);
        }
        #endregion

        #region //波动客户查询
        public void GetExceptionConsumeCustomer()
        {
            model.OrderList = findFinanceService.GetExceptionConsumeCustomer(model.Order);
        }
        #endregion

        #region //无消费客户查询 
        public void GetAllMasterDate()
        {
            model.MemberCardLevelList = masterDataService.GetMemberCardLevels();
            model.CustomerLevelList = masterDataService.GetCustomerLevel();
            model.CustomerTypeList = masterDataService.GetCustomerTypes();
        }
        /// <summary>
        /// 名    称: SelectWithoutConsumeCustomer
        /// 功能概要: 查询没有消费的客户
        /// 作    者: 付强
        /// 创建时间: 2007-10-31
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public void GetWithoutConsumeCustomer(Hashtable customer)
        {

            model.CustomerList = findFinanceService.GetWithoutConsumeCustomer(customer);
        }
        #endregion

        #region //客户消费统计
        /// <summary>
        /// 获取某段时间内所有客户的消费情况
        /// </summary>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-24
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void GetCustomerConsume()
        {
            model.OrderList = findFinanceService.GetCustomerConsume(model.Order);
        }
        #endregion

        #region //新老客户消费统计
        public void GetNewAndOldCustomerConsumeCount()
        {
            model.OrderList = findFinanceService.GetNewAndOldCustomerConsumeCount(model.Order);
        }
        #endregion

        #region //客户付款明细
        /// <summary>
        /// 查找某个客户某段时间内的付款明细
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-25
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void GetCustomerPayment()
        {

            model.GatheringList = findFinanceService.GetCustomerPayment(model.Order);
        }
        #endregion

        #region //工单查询(财务查询)

        #region 业务类型
        /// <summary>
        /// 业务类型
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-25
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void GetBusinessType()
        {
            model.BusinessTypeList = masterDataService.GetBusinessTypes();
        }
        #endregion

        public void SearchOrdersItem()
        {
            System.Collections.Hashtable condition = new System.Collections.Hashtable();

            if (model.BusinessTypeId != "0")
            {
                condition.Add("BusinessTypeId", model.BusinessTypeId);
            }

            if (!StringUtils.IsEmpty(model.Amount))
            {
                condition.Add("Amount", model.Amount);
            }
            else
            {
                condition.Add("Amount", "");
            }

            condition.Add("AmountCondition", model.AmountCondtition);

            if (!StringUtils.IsEmpty(model.Price))
            {
                condition.Add("Price", model.Price);
            }
            else
            {
                condition.Add("Price", "");
            }

            condition.Add("PriceCondition", model.PriceCondition);

            if (!StringUtils.IsEmpty(model.BeginDate))
            {
                condition.Add("BeginDate", model.BeginDate);
                condition.Add("EnddDate", model.EndDate);
            }

            model.OrderList = orderService.SearchOrdersItem(condition);
            model.Amounts = orderService.SearchAmounts(model.OrderList);
        }
        #endregion

        #region //异常消费会员查询
        public void GetExceptionConsumeMemberCount()
        {
            model.OrderList = findFinanceService.GetExceptionMemberCustomerConsumeCount(model.Order);
        }
        #endregion

        #region //客户对账表
        public void GetCustomerHistory()
        {
            model.OList = findFinanceService.GetCustomerHistory(model.Order);
            model.OrderList = findFinanceService.GetCustomerOrdersHistory(model.Order);
        }
        #endregion

        #region //异常价格加工单汇总
        public void GetExceptionPriceOrdersCount()
        {
            model.OrderList = findFinanceService.GetExceptionPriceOrdesCount(model.Order);
        }
        #endregion

        #region //门店营业额查询
        public void SelectBranShopTurnover()
        {
            model.OrderList = findFinanceService.GetBranchShopTurnover(model.Order);
        }
        #endregion

        #region//优惠查询

        /// <summary>
        /// 名    称: SearchConcession
        /// 功能概要: 查询优惠
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日14:36:50
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchConcession() 
        {
            model.PaymentConcessionList = findFinanceService.SearchConcession(model.PaymentConcession);
            model.Operator1 = Convert.ToString(findFinanceService.SearchConcessionRowCount(model.PaymentConcession));
            model.PaymentConcessionPrintList = findFinanceService.SearchConcessionPrint(model.PaymentConcession);
            AddConcessionMoney(model.PaymentConcessionPrintList);
        }
        private void AddConcessionMoney(IList<PaymentConcession> paymentConcessionList)
        {
            foreach (PaymentConcession p in paymentConcessionList)
            {
                model.Amount1+= p.ConcessionAmountTotal;
                model.Amount2 += p.MoreConcessionAmountTotal;
            }
        }
        #endregion

        #region//按照人员统计开单量
        /// <summary>
        /// 名    称: SearchOrderCount
        /// 功能概要: 按照人员统计开单量
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日10:43:07
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchOrderCount() 
        {
            model.OtherEmployeeList = findFinanceService.SearchOrderCount(model.Employee);
            model.Operator1 = findFinanceService.SearchOrderCountRowCount(model.Employee).ToString();
            model.PrintEmployeeList = findFinanceService.SearchOrderCountPrint(model.Employee);
        }

        /// <summary>
        /// 名    称: SearchPositionOrEmployee
        /// 功能概要: 获取指定的部门与人员
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public void SearchPositionOrEmployee() 
        {
            model.Employee = new Workflow.Da.Domain.Employee();
            long branchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            model.Employee.PositionName = Constants.POSITION_PROPHASE_VALUE(branchShopId).ToString();//前期
            model.Employee.PositionIdString = Constants.POSITION_ANAPHASE_VALUE(branchShopId).ToString();//后加工
            model.PositionList = findFinanceService.SearchPositionByCondition(model.Employee);
            model.Employee.PositionIdString = null;
            model.EmployeeList= findFinanceService.SearchEmployeeByPosition(model.Employee);
        }

        /// <summary>
        /// 名    称: SearchPositionByEmployeeId
        /// 功能概要: 根据雇员Id获取岗位
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月16日11:07:37
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public long SearchPositionByEmployeeId(long employeeId) 
        {
            model.Employee = new Workflow.Da.Domain.Employee();
            model.Employee.Id = employeeId;
            return findFinanceService.SearchPositionByEmployeeId(model.Employee).Id;
        }
        #endregion
    }
}
