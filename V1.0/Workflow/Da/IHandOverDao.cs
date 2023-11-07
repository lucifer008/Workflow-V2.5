using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;
namespace Workflow.Da
{
	/// <summary>
	/// Table HAND_OVER 对应的Dao 接口
	/// </summary>
    public interface IHandOverDao : IDaoBase<HandOver>
    {
        /// <summary>
        /// 名    称:Stage_Work_Start_Time
        /// 功能概要:获取前台交班开始时间
        /// 作    者:
        /// 创建时间:
        /// 修正履历:张晓林
        /// 修正时间:2009年3月21日15:08:08
        /// 修正描述:获取上一次交班的时间
        /// </summary>
        /// <returns></returns>
        string Stage_Work_Start_Time();

        /// <summary>
        /// 名    称:Cash_Work_Start_Time
        /// 功能概要:获取收银交班的开始时间(获取上一次交班的时间)
        /// 作    者:张晓林
        /// 创建时间:2009年3月21日17:22:31
        /// 修正履历:
        /// 修正时间:
        /// 修正描述:
        /// </summary>
        /// <returns></returns>
        string Cash_Work_Start_Time();


        /// <summary>
        /// 名    称:DailyPaperMinHandOverDateTime
        /// 功能概要:按照日期获取该日期内最早交班的时间
        /// 作    者:张晓林
        /// 创建时间:2009年3月27日17:03:15
        /// 修正履历:
        /// 修正时间:
        /// 修正描述:
        /// </summary>
        /// <returns></returns>
        string DailyPaperMinHandOverDateTime(string QueryDateTime);


         /// <summary>
        /// 按照月份获取本月交班的最早时间和最迟时间
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月30日9:33:32
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        HandOver MonthPaperMinHandOverDateTime(string QueryDateTime);

        /// <summary>
        /// 获取交班信息
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        IList<HandOver> SearchHandOver(HandOver handOver);

         /// <summary>
        /// 获取交班信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        long SearchHandOverRowCount(HandOver handOver);

        /// <summary>
        /// 获取前台交班的会员卡信息
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        IList<MemberCard> GetHandOverMemberCard(HandOver handOver);

        /// <summary>
        /// 获取前台交班的工单信息
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        IList<Order> GetHandOverOrders(HandOver handOver);

        /// <summary>
        /// 获取收银交班的工单预付款信息
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        IList<Order> GetHandOverPreMoneyInfo(HandOver handOver);

        /// <summary>
        /// 获取收银交班的其他款项信息
        /// </summary>
        /// <remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年3月26日9:57:47
        /// 修正履历:
        /// 修正时间：
        /// 修正描述:
        /// </remarks>
        CashHandOver GetHandOverOtherFundInfo(HandOver handOver);

        /// <summary>
        /// 获取接班人(只包含:前台，店长,收银部门人员)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月7日12:10:29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Employee> GetHandOverEmployeeList();

        /// <summary>
        /// 获取接班部门(只包含:前台，店长,收银部门)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月7日12:10:29
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Position> GetHandOverPositionList();

        /// <summary>
        /// 名    称:LastHandOverId
        /// 功能概要:获取当前用户为接班人的最近的交班Id
        /// 作    者:张晓林
        /// 创建时间:2009年4月12日17:37:16
        /// 修正时间:
        /// 修正履历:
        /// 修正描述:
        /// </summary>
        long LastHandOverId();
    }
}
