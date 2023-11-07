using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
using Spring.Transaction.Interceptor;
using Workflow.Service;
using Workflow.Util;
using Workflow.Support;
using System.Collections;
namespace Workflow.Service.Impl
{
    public class AchievementServiceImpl:IAchinevementService
    {
        private IAchievementDao achievementDao;
        public IAchievementDao AchievementDao
        {
            set { achievementDao = value; }
            get { return achievementDao; }
        }
        private IEmployeeDao employeeDao;
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
            get { return employeeDao; }
        }
        private IPositionDao positionDao;
        public IPositionDao PositionDao
        {
            set { positionDao = value; }
            get { return positionDao; }
        }

        private IOrderItemEmployeeDao orderItemEmployeeDao;
        public IOrderItemEmployeeDao OrderItemEmployeeDao 
        {
            set { orderItemEmployeeDao = value; }
        }

        /// <summary>
        /// 业绩调整
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        [Transaction]
        public void AdjustAchievement(IList<Achievement> achievementList)
        {
            if (achievementList.Count > 0)
            {
                achievementDao.DeleteAchievementByOrdersId(achievementList[0]);
            }
            foreach (Achievement achv in achievementList)
            {
                achievementDao.Insert(achv);
            }
        }


        #region  Add:Cry Date: 2009-1-6

        /// <summary>
        /// 更新业绩数据
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历: 张晓林
        /// 修正时间: 2009年5月9日13:27:53
        /// 修正描述：同时更新订单明细信息
        /// </remarks>
        [Spring.Transaction.Interceptor.Transaction]
        public void UpdateAchievementInit(IList<Achievement> achievementList, IList<Employee> employeeList)
        {
            if (0 != achievementList.Count)
            {
                //long userId=ThreadLocalUtils.CurrentUserContext.CurrentUser.Id;
                achievementDao.DeleteAchievement(achievementList[0].OrdersId);
                foreach (Workflow.Da.Domain.Achievement achievement in achievementList)
                {
                    //Workflow.Da.Domain.Achievement achievementObj = achievementDao.GetAchievement(achievement.OrderItemId, achievement.EmployeeId);
                    //if (achievementObj != null)//更新
                    //{
                    //    achievementObj.UpdateUser = userId;
                    //    achievementObj.AchievementValue = achievement.AchievementValue;
                    //    UpdateAchievement(achievementObj);
                    //}
                    //else//新增员工业绩
                    //{
                    //    achievementDao.Insert(achievement);
                    //}
                    achievementDao.Insert(achievement);
                }
                UpdateOrdersPerson(employeeList);//更新订单明细
            }
        }

        /// <summary>
        /// 更新Achievement
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void UpdateAchievement(Achievement achievementObj)
        {
            achievementDao.Update(achievementObj);
        }

        #endregion

        /// <summary>
        /// 更新订单制作人员
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月7日11:55:31
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void UpdateOrdersPerson(IList<Employee> employeeList) 
        {
            OrderItemEmployee orderItemEmployee;
            if (0!=employeeList.Count)
            {
                orderItemEmployeeDao.DeleteOrderItemEmployee(employeeList[0].UpdateUser);
            }
            foreach(Employee employee in employeeList)
            {

                orderItemEmployee = new OrderItemEmployee();
                orderItemEmployee.EmployeeId = employee.Id;
                orderItemEmployee.OrderItemId = employee.InsertUser;
                orderItemEmployeeDao.Insert(orderItemEmployee); 
            }
        }
    }
}
