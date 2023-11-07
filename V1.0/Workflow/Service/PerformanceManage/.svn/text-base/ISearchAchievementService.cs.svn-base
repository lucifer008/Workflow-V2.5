using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
namespace Workflow.Service
{
    public interface ISearchAchievementService
    {
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
        IList<Employee> GetEmployeeList();
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
        IList<Position> GetPositionList();
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
        IList<Achievement> SearchAchievement(Hashtable achievement);

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

        long SearchAchievementRowCount(Hashtable achievement);

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
        IList<Achievement> SearchAchievementPrint(Hashtable achievement);

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
        IList<Achievement> GetAchievementCount(Hashtable achievement);

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
        long GetAchievementCountTotal(Hashtable achievement);

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
        IList<Achievement> GetAchievementCountPrint(Hashtable achievement);

        /// <summary>
        /// 员工业绩统计(分页)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:
        /// 修正时间:2009年1月7日
        /// </remarks>
        IList<Achievement> GetCustomerAchievementCount(Hashtable achievement);

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
        long GetCustomerAchievementCountTotal(Hashtable achievement);

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
        IList<Achievement> GetCustomerAchievementCountPrint(Hashtable achievement);

        /// <summary>
        /// 员工业绩详情(分页)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-11-3
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Achievement> GetCustomerAchievementDetail(Hashtable achievement);

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
        long GetCustomerAchievementDetailRowCount(Hashtable achievement);

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
        IList<Achievement> GetCustomerAchievementDetailPrint(Hashtable achievement);

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
        Achievement GetOrderAchievementInfoByOrderIdOrEmployeeId(Hashtable condition);

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
        IList<OrderItem>GetOrderItemByOrderNo(string orderNo);

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
        IList<Achievement> SearchAchievementByShoperAndManager(Achievement achievement);
    }
}
