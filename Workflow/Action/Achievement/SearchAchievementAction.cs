using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Service;
using Workflow.Action;
using Workflow.Support;
using System.Collections;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.OrderManage;
using Workflow.Action.Achievement.Model;
using Workflow.Service.CustomerManager;

/// <summary>
/// 名    称: SearchAchievementAction
/// 功能概要: 绩效调整查询的Action
/// 作    者: 付强
/// 创建时间: 2008-11-02
/// 修正履历: 张晓林
/// 修正时间: 2009-02-01
///             调整代码结构
/// </summary>
namespace Workflow.Action.Achievement
{
    public class SearchAchievementAction
    {
        #region//ClassMember

        #region 注入searchachievementService
        private AdjustAchievementModel model = new AdjustAchievementModel();
        public AdjustAchievementModel Model
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
        private ISearchAchievementService searchAchinevementService;
        public ISearchAchievementService SearchAchinevementService
        {
            set { searchAchinevementService = value; }
        }
        #endregion

        #region 注入 applicationProperty

        private IApplicationProperty applicationProperty;
        /// <summary>
        /// Add:Cry Date:2009-1-6
        /// </summary>
        public IApplicationProperty ApplicationProperty
        {
            set { applicationProperty = value; }
        }

        #endregion

        #region 注入 orderService

        private IOrderService orderService;
        /// <summary>
        /// Add:Cry Date:2009-1-6
        /// </summary>
        public IOrderService OrderService
        {
            set { orderService = value; }
        }

        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }

        private ISearchCustomerService searchCustomerService;
        public ISearchCustomerService SearchCustomerService
        {
            set { searchCustomerService = value; }
        }
                #endregion

        #region //注入IApplicationProperty

        private IApplicationPropertyDao applicationPropertyDao;
        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }
        #endregion

        #endregion

        #region //获得部门列表和雇员列表
        /// <summary>
        /// 获得雇员列表
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void GetEmployeeList()
        {

            model.EmployeeList = searchAchinevementService.GetEmployeeList();
            
        }

        /// <summary>
        /// 获取部门列表
        /// </summary>
        public virtual void GetPositionList() 
        {
            model.PositionList = searchAchinevementService.GetPositionList();
        }
        #endregion

        #region //业绩查询
        /// <summary>
        /// 业绩查询
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void SearchAchievement(Hashtable achievement)
        {
            model.AchievementList = searchAchinevementService.SearchAchievement(achievement);
        }

        /// <summary>
        /// 统计业绩(打印)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月5日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void SearchAchievementPrint(Hashtable achievement)
        {
            model.AchievementTempList = searchAchinevementService.SearchAchievementPrint(achievement);
        }

        /// <summary>
        /// 统计业绩总记录数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月5日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual long SearchAchievementRowCount(Hashtable achievement)
        {
            return searchAchinevementService.SearchAchievementRowCount(achievement);
        }

        /// <summary>
        /// 获取每天上班的时间
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月26日15:27:01
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public string GetWorkBeginHoursString() 
        {
            return applicationPropertyDao.GetValue(Constants.APPLICATION_START_TIME_KEY);
        }

        /// <summary>
        /// 获取每天下班的时间
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月26日15:27:01
        /// 修正履历:
        /// 修正时间:
        ///</remarks>
        public string GetWorkEndHoursString() 
        {
            return applicationPropertyDao.GetValue(Constants.APPLICATION_END_TIME_KEY);
        }
        #endregion

        #region //订单绩效分配情况

        /// <summary>
        /// 订单业绩统计(分页)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-5
        /// 修正履历:
        /// 修正时间:2009年1月6日11:31:08
        /// </remarks>
        public virtual void GetAchievementCount(int currentPageIndex, int orderId)
        {
            Hashtable hashCondition = new Hashtable();
            if (0 != orderId)
            {
                hashCondition.Add("OrdersId", orderId);
            }
            hashCondition.Add("currentPageIndex", currentPageIndex - 1);
            hashCondition.Add("RowCount", Workflow.Support.Constants.ROW_COUNT_FOR_PAGER);
            model.AchievementList = searchAchinevementService.GetAchievementCount(hashCondition);
        }

        /// <summary>
        /// 订单业绩统计总记录
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月6日11:21:17
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual long GetAchievementCountTotal(int orderId)
        {
            Hashtable hashCondition = new Hashtable();
            if (0 != orderId)
            {
                hashCondition.Add("OrdersId", orderId);
            }
            return searchAchinevementService.GetAchievementCountTotal(hashCondition);
        }

        /// <summary>
        /// 订单业绩统计(打印)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月6日11:21:17
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void GetAchievementCountPrint(int orderId)
        {
            Hashtable hashCondition = new Hashtable();
            if (0 != orderId)
            {
                hashCondition.Add("OrdersId", orderId);
            }
            model.AchievementTempList = searchAchinevementService.GetAchievementCountPrint(hashCondition);
        }

        /// <summary>
        /// 通过订单号获取订单信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void GetOrderInfo(string strOrderNo)
        {
            GetOrderItemIDByOrderNo(strOrderNo);
            GetOrderByOrderNo(strOrderNo);
        }

        /// <summary>
        /// 通过订单号获取订单明细
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        public virtual void GetOrderItemIDByOrderNo(string strOrderNo)
        {
            orderModel.OrderItemList = masterDataService.GetOrderItemIDByOrderNo(strOrderNo);
        }

        /// <summary>
        /// 通过订单号获取订单信息
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-9-11
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public virtual void GetOrderByOrderNo(string strOrderNo)
        {
            orderModel.NewOrder = orderService.GetOrderInfoByOrderNo(strOrderNo);
        }
        /// <summary>
        /// 名    称: SelectOrderIdByOrderNo
        /// 功能概要: 通过订单号查找订单ID
        /// 作    者: 付强
        /// 创建时间: 2007-9-26
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public virtual long SelectOrderIdByOrderNo(string strOrderNo)
        {
            return orderService.SelectOrderIdByOrderNo(strOrderNo);
        }
        #endregion

        #region //员工业绩统计

        /// <summary>
        /// 员工业绩统计(分页)
        /// </summary>
        /// <param name="achievement">查询条件列表</param>
        /// <remarks></remarks>
        ///作  者:张晓林 
        ///创建时间:2009年1月7日11:09:56
        ///修正履历:
        ///修正时间:
        public virtual void GetCustomerAchievementCount(Hashtable achievement)
        {
            model.AchievementList = searchAchinevementService.GetCustomerAchievementCount(achievement);
        }

        /// <summary>
        /// 员工业绩统计总记录数
        /// </summary>
        /// <param name="achievement">查询条件列表</param>
        /// <remarks></remarks>
        ///作  者:张晓林 
        ///创建时间:2009年1月7日11:09:56
        ///修正履历:
        ///修正时间:
        public virtual long GetCustomerAchievmentCountTotal(Hashtable hashAchievement)
        {
            return searchAchinevementService.GetCustomerAchievementCountTotal(hashAchievement);
        }

        /// <summary>
        /// 员工业绩统计(打印)
        /// </summary>
        /// <param name="achievement">查询条件列表</param>
        /// <remarks></remarks>
        ///作  者:张晓林 
        ///创建时间:2009年1月7日11:09:56
        ///修正履历:
        ///修正时间:
        public virtual void GetCustomerAchevmentCountPrint(Hashtable hashAchievement)
        {
            model.AchievementTempList = searchAchinevementService.GetCustomerAchievementCountPrint(hashAchievement);
        }

        /// <summary>
        /// 员工业绩详情
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:张晓林
        /// 修正时间:2009年4月23日11:08:27
        /// 描    述:增加分页功能
        /// </remarks>
        public virtual void GetCustomerAchievementDetail(Hashtable achievement)
        {
            model.AchievementList = searchAchinevementService.GetCustomerAchievementDetail(achievement);
            model.OrderId = searchAchinevementService.GetCustomerAchievementDetailRowCount(achievement);
            model.AchievementTempList = searchAchinevementService.GetCustomerAchievementDetailPrint(achievement);
            AddMoney(model.AchievementTempList);
        }
        private void AddMoney(IList<Workflow.Da.Domain.Achievement> achievementList)
        {
            foreach (Workflow.Da.Domain.Achievement a in achievementList)
            {
                model.AchievementValueTotal+= a.AchievementValue;
                model.WastePaperTotal += a.TrashPaper;
            }
        }
        #endregion

        #region //查询员工业绩
        /// <summary>
        /// 查询员工业绩
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历: 张晓林
        /// 修正时间: 2009年5月9-11日16:35:21
        /// 修正描述：修改获取员工绩效的方式
        /// </remarks>
        public void Search()
        {
            Order order = orderService.GetOrderInfoByOrderNo(model.No);
            if (null == order) return;
            if (Constants.ORDER_STATUS_SUCCESSED_VALUE != order.Status) return; 
            model.OrderId = order.Id;
            model.CustomerName = order.CustomerName;
            model.ProjectName = order.ProjectName;
            model.OrderItemList = searchAchinevementService.GetOrderItemByOrderNo(model.No);
            int index = 1;
            foreach (OrderItem orderItem in model.OrderItemList)
            {
                //获取加工类型
                orderItem.ProcessContentName = orderService.GetProcessContent(orderItem.Id);
                orderItem.No = index;
                orderItem.AnaphaseMoney = orderService.GetProcessContentAchievementRate(orderItem.Id);
                orderItem.Money = decimal.Round(orderItem.Amount * orderItem.UnitPrice,2);//明细金额
                model.SumMoney += orderItem.Amount * orderItem.UnitPrice;
                //获取当前的加工人员
                IList<Workflow.Da.Domain.Employee> employees = searchCustomerService.GetOrderItemEmployeeByOrderItemId(orderItem.Id);
                orderItem.Employees = new List<CustomEmployee>();
                foreach (Workflow.Da.Domain.Employee employee in employees)
                {
                    //获取前期和后加工人员 
                    if (employee.PositionName == Constants.POSITION_PROPHASE_TEXT || employee.PositionName == Constants.POSITION_ANAPHASE_TEXT)
                    {
                        CustomEmployee customEmployee = new CustomEmployee();
                        if (employee.PositionName == Constants.POSITION_PROPHASE_TEXT)
                        {
                            customEmployee.IsProphase = true;
                        }
                        else
                        {
                            customEmployee.IsProphase = false;
                        }
                        //获取制作人员的业绩(按照：订单Id,订单明细Id,雇员Id,参与的制作的岗位Id获取特定人员的业绩)
                        Hashtable condtion = new Hashtable();
                        condtion.Add("OrderId", model.OrderId);
                        condtion.Add("OrderItemId",orderItem.Id);
                        condtion.Add("EmployeeId", employee.Employeeid);
                        condtion.Add("Prophase", employee.Positionid);
                        Workflow.Da.Domain.Achievement achievement = searchAchinevementService.GetOrderAchievementInfoByOrderIdOrEmployeeId(condtion);
                        customEmployee.Id = employee.Employeeid;
                        customEmployee.Position = employee.PositionName;
                        customEmployee.Name = employee.Name;
                        customEmployee.PositionId = employee.Positionid;
                        if (null != achievement)
                        {
                            customEmployee.Money = decimal.Round(achievement.AchievementValue, 2);
                        }
                        orderItem.Employees.Add(customEmployee);
                    }
                }
                index++;
            }
            model.SumMoney = decimal.Round(model.SumMoney, 2);
        }
        #endregion

        #region //获取制作订单的前期和后期的人员
        /// <summary>
        /// 获取制作订单的前期和后期的人员
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月7日10:53:03
        /// 修正履历:
        /// 修正时间:
        ///</remarks>
        public void GetOrderBeforeOrBehindPerson() 
        {
            model.EmployeeList=masterDataService.GetEmployeeList();
        }
        #endregion

        #region //店长经理绩效统计
        /// <summary>
        /// 店长经理绩效统计
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月23日14:33:36
        /// 修正履历:
        /// 修正时间:
        ///</remarks>
        public void SearchAchievementByShoperAndManager() 
        {
            model.AchievementList = searchAchinevementService.SearchAchievementByShoperAndManager(model.NewAchievement);
        }
        #endregion
    }
}
