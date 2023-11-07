using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Service
{
    /// <summary>
    /// 名    称: IHandOverService
    /// 功能概要: 交班管理Service的接口
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 付强
    /// 修正时间: 2009-1-19
    /// 描    述: 代码整理     
    /// </summary>
    public interface IHandOverService
    {
        #region 前台交班
        /// <summary>
        /// 插入交班信息公共表
        /// </summary>
        /// <param name="handOver"></param>
        /// <param name="handOverMemberCardList"></param>
        /// <param name="handOverOrderList"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void InsertHandOver(HandOver handOver, IList<HandOverMemberCard> handOverMemberCardList, IList<HandOverOrder> handOverOrderList);

        /// <summary>
        /// 审核前台交班
        /// </summary>
        /// <param name="handOver"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void AuditHandOver(HandOver handOver);
        #endregion
        
        #region 收银交班
        /// <summary>
        /// 插入收银交班的信息
        /// </summary>
        /// <param name="handOver"></param>
        /// <param name="cashHandOver"></param>
        /// <param name="cashHandOverOrderList"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void InsertCashHandOver(HandOver handOver, CashHandOver cashHandOver, IList<CashHandOverOrder> cashHandOverOrderList);

        /// <summary>
        /// 审核收银交班
        /// </summary>
        /// <param name="handOver"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        void AuditCashHandOver(HandOver handOver);
        #endregion

        #region 交班查询
        /// <summary>
        /// 交班一览
        /// </summary>
        /// <param name="handOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<HandOver> SearhHandOver(HandOver handOver);

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
        /// 收银交班一览
        /// </summary>
        /// <param name="cashHandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<CashHandOver> GetCashHandOverListCustomQuery(CashHandOver cashHandOver);

        ///// <summary>
        ///// 获得收银交班工单一览(预付/定金)
        ///// </summary>
        ///// <param name="cashHandOverOrder"></param>
        ///// <returns></returns>
        //IList<Order> GetCashHandOverOrderListCustomQuery(CashHandOverOrder cashHandOverOrder);

        /// <summary>
        /// 前台交班明细
        /// </summary>
        /// <param name="handOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-09
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        HandOver GetHandOverById(HandOver handOver);

        ///// <summary>
        ///// 收银交班明细
        ///// </summary>
        ///// <param name="handOver"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 作    者: 麻少华
        ///// 创建时间: 2007-10-09
        ///// 修正履历: 
        ///// 修正时间:
        ///// </remarks>
        //CashHandOver GetCashHandOverById(HandOver handOver);

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
        CashHandOver GetDebtAmount(Hashtable condition);

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
        CashHandOver GetKeepBusinessRecordAmount(Hashtable condition);

        /// <summary>
        /// 取得结款笔数/结款金额
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        CashHandOver GetPayForAmount(Hashtable condition);

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
        CashHandOver GetTicketAmount(Hashtable condition);
        /// <summary>
        /// 名    称: GetStageHandOverOrderList
        /// 功能概要: 前台交班时加工单数据抽取
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <returns></returns>
        IList<Order> GetStageHandOverOrderList();
        /// <summary>
        /// 名    称: GetFrontHandOverOrderList
        /// 功能概要: 按条件（时间）前台交班时加工单数据抽取
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-04
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns>工单列表</returns>
        /// <remarks>
        IList<Order> GetFrontHandOverOrderList(Hashtable condition);
        /// <summary>
        /// 名    称: GetCashHandOverOrderList
        /// 功能概要: 收银交班时加工单数据抽取
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </summary>
        /// <returns></returns>
        IList<Order> GetCashHandOverOrderList(Hashtable condition);

        #endregion

        /// <summary>
        /// 名    称:Work_Start_Time
        /// 功能概要:获取前台交班时间
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
        /// 功能概要:获取收银交班的开始时间
        /// 作    者:
        /// 创建时间:
        /// 修正履历:张晓林
        /// 修正时间:2009年3月21日17:12:39
        /// 修正描述:获取上一次交班的时间
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
        string DailyPaperMinHandOverDateTime(string handOverDateTime);

        /// <summary>
        /// 按照月份获取本月最早交班的时间
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月30日9:33:32
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        HandOver MonthPaperMinHandOverDateTime(string queryDateTime);

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
