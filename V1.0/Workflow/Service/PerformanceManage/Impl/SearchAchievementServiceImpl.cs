using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service.Impl
{
    public class SearchAchievementServiceImpl : ISearchAchievementService
    {
        #region //依赖注入Dao

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
        #endregion

        /// <summary>
        /// 获得员工列表
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Employee> GetEmployeeList()
        {
            return employeeDao.GetEmployeeList();
        }
        /// <summary>
        /// 获得部门列表
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-2
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Position> GetPositionList()
        {
            return positionDao.SelectAll();
        }
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
        public IList<Achievement> SearchAchievement(Hashtable achievement)
        {
            return achievementDao.SearchAchievement(achievement);
        }
        /// <summary>
        /// 业绩统计总记录数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月5日10:05:52
        /// 修正履历:
        /// 修正时间:
        /// </remarks>

        public long SearchAchievementRowCount(Hashtable achievement)
        {
            return achievementDao.SearchAchievementRowCount(achievement);
        }

        /// <summary>
        /// 业绩统计(打印)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月5日10:05:52
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> SearchAchievementPrint(Hashtable achievement)
        {
            return achievementDao.SearchAchievementPrint(achievement);
        }

        /// <summary>
        /// 工单业绩统计
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetAchievementCount(Hashtable achievement)
        {
            return achievementDao.GetAchievementCount(achievement);
        }
        /// <summary>
        /// 工单业绩统计总记录数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:2009年1月6日11:06:17
        /// </remarks>
        public long GetAchievementCountTotal(Hashtable achievement)
        {
            return achievementDao.GetAchievementCountTotal(achievement);
        }

        /// <summary>
        /// 工单业绩统计(打印)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009-1-6
        /// 修正履历:
        /// 修正时间:2009年1月6日11:06:17
        /// </remarks>
        public IList<Achievement> GetAchievementCountPrint(Hashtable achievement)
        {
            return achievementDao.GetAchievementCountPrint(achievement);
        }

        /// <summary>
        /// 员工业绩统计(分页)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementCount(Hashtable achievement)
        {
            return achievementDao.GetCustomerAchievementCount(achievement);
        }
        /// <summary>
        /// 员工业绩统计总记录数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月7日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long GetCustomerAchievementCountTotal(Hashtable achievement)
        {
            return achievementDao.GetCustomerAchievementCountTotal(achievement);
        }

        /// <summary>
        /// 员工业绩统计(打印)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月7日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementCountPrint(Hashtable achievement)
        {
            return achievementDao.GetCustomerAchievementCountPrint(achievement);
        }
        /// <summary>
        /// 员工业绩详情
        /// </summary>.
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementDetail(Hashtable achievement)
        {
            return achievementDao.GetCustomerAchievementDetail(achievement);
        }

        /// <summary>
        /// 员工业绩详情记录数
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 修正履历:2009年4月23日11:25:25
        /// 修正时间:
        /// </remarks>
        public long GetCustomerAchievementDetailRowCount(Hashtable achievement)
        {
            return achievementDao.GetCustomerAchievementDetailRowCount(achievement);
        }

        /// <summary>
        /// 员工业绩详情(输出)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月23日11:25:35
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Achievement> GetCustomerAchievementDetailPrint(Hashtable achievement) 
        {
            return achievementDao.GetCustomerAchievementDetailPrint(achievement);
        }

        /// <summary>
        /// 获取员工的业绩信息
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月9日17:06:39
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public Achievement GetOrderAchievementInfoByOrderIdOrEmployeeId(Hashtable condition) 
        {
            return achievementDao.GetOrderAchievementInfoByOrderIdOrEmployeeId(condition);
        }

        /// <summary>
        /// 根据工单号获取前期和后加工参与制作的工单明细信息
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月11日13:41:37
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<OrderItem> GetOrderItemByOrderNo(string orderNo) 
        {
            return achievementDao.GetOrderItemByOrderNo(orderNo);
        }

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
        public IList<Achievement> SearchAchievementByShoperAndManager(Achievement achievement) 
        {
            return achievementDao.SearchAchievementByShoperAndManager(achievement);
        }
    }
}
