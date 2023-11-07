using System;
using System.Collections.Generic;
using System.Text;
using Spring.Transaction.Interceptor;
using Workflow.Service;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Support;
using System.Collections;

namespace Workflow.Service.Impl
{
    /// <summary>
    /// 交班管理相关实现
    /// </summary>
    public class HandOverServiceImpl:IHandOverService
    {
        #region DAO
        /// <summary>
        /// 交班
        /// </summary>
        private IHandOverDao handOverDao;
        public IHandOverDao HandOverDao
        {
            set { handOverDao = value; }
        }

        /// <summary>
        /// 交班会员卡
        /// </summary>
        private IHandOverMemberCardDao handOverMemberCardDao;
        public IHandOverMemberCardDao HandOverMemberCardDao
        {
            set { handOverMemberCardDao = value; }
        }

        /// <summary>
        /// 交班工单
        /// </summary>
        private IHandOverOrderDao handOverOrderDao;
        public IHandOverOrderDao HandOverOrderDao
        {
            set { handOverOrderDao = value; }
        }

        /// <summary>
        /// 收银交班
        /// </summary>
        private ICashHandOverDao cashHandOverDao;
        public ICashHandOverDao CashHandOverDao
        {
            set { cashHandOverDao = value; }
        }

        /// <summary>
        /// 收银交班工单
        /// </summary>
        private ICashHandOverOrderDao cashHandOverOrderDao;
        public ICashHandOverOrderDao CashHandOverOrderDao
        {
            set { cashHandOverOrderDao = value; }
        }
        
        /// <summary>
        /// 工单
        /// </summary>
        private IOrderDao orderDao;
        public IOrderDao OrderDao
        {
            set { orderDao = value; }
        }

        /// <summary>
        /// 付款记录
        /// </summary>
        private IGatheringDao gatheringDao;
        public IGatheringDao GatheringDao
        {
            set { gatheringDao = value; }
        }

        private IApplicationPropertyDao applicationPropertyDao;
        public IApplicationPropertyDao ApplicationPropertyDao
        {
            set { applicationPropertyDao = value; }
        }

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
        public string Stage_Work_Start_Time()
        {
            return handOverDao.Stage_Work_Start_Time();
        }

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
        public string Cash_Work_Start_Time() 
        {
            return handOverDao.Cash_Work_Start_Time();
        }

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
        public string DailyPaperMinHandOverDateTime(string QueryDateTime)
        {
            return handOverDao.DailyPaperMinHandOverDateTime(QueryDateTime);
        }

        /// <summary>
        /// 按照日期获取本月最早交班的时间和最迟交班时间
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月30日9:33:32
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public HandOver MonthPaperMinHandOverDateTime(string QueryDateTime) 
        {
            return handOverDao.MonthPaperMinHandOverDateTime(QueryDateTime);
        } 
        #endregion

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
        [Transaction]
        public void InsertHandOver(HandOver handOver, IList<HandOverMemberCard> handOverMemberCardList, IList<HandOverOrder> handOverOrderList)
        {
            //插入交班信息
            handOverDao.Insert(handOver);
            //插入前台交班时会员卡信息
            foreach (HandOverMemberCard var in handOverMemberCardList)
            {   
                var.HandOverId = handOver.Id;
                handOverMemberCardDao.Insert(var);
            }
            //插入前台交班时工单信息
            foreach (HandOverOrder var in handOverOrderList)
            {
                var.HandOverId = handOver.Id;
                handOverOrderDao.Insert(var);
            }
        }

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
        public void AuditHandOver(HandOver handOver)
        {
            handOverDao.Update(handOver);
        }
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
        [Transaction]
        public void InsertCashHandOver(HandOver handOver, CashHandOver cashHandOver, IList<CashHandOverOrder> cashHandOverOrderList)
        {
            //插入交班信息
            handOverDao.Insert(handOver);
            ////插入收银交班信息
            cashHandOver.HandOver = new HandOver();
            cashHandOver.HandOver.Id = handOver.Id;
            cashHandOverDao.Insert(cashHandOver);
            //插入收银交班时工单信息
            foreach (CashHandOverOrder var in cashHandOverOrderList)
            {
                //var.CashHandOverId = cashHandOver.Id;
                //cashHandOverOrderDao.Insert(var);
                CashHandOverOrder choo = new CashHandOverOrder();
                choo.CashHandOverId = cashHandOver.Id;
                choo.No = var.No;
                choo.OrdersId = var.OrdersId;
                choo.EarnestAmount = var.EarnestAmount;
                cashHandOverOrderDao.Insert(choo);
            }
        }

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
        public void AuditCashHandOver(HandOver handOver)
        {
            AuditHandOver(handOver);
        }
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
        public IList<HandOver> SearhHandOver(HandOver handOver)
        {
            //return handOverDao.SelectAll();
            return handOverDao.SearchHandOver(handOver);
        }

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
        public long SearchHandOverRowCount(HandOver handOver) 
        {
            return handOverDao.SearchHandOverRowCount(handOver);
        }

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
        public IList<MemberCard> GetHandOverMemberCard(HandOver handOver) 
        {
            return handOverDao.GetHandOverMemberCard(handOver);
        }


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
        public IList<Order> GetHandOverOrders(HandOver handOver) 
        {
            return handOverDao.GetHandOverOrders(handOver);
        }

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
        public IList<Order> GetHandOverPreMoneyInfo(HandOver handOver) 
        {
            return handOverDao.GetHandOverPreMoneyInfo(handOver);
        }

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
        public CashHandOver GetHandOverOtherFundInfo(HandOver handOver) 
        {
            return handOverDao.GetHandOverOtherFundInfo(handOver);
        }

        ///// <summary>
        ///// 获得交班工单一览(未完工)
        ///// </summary>
        ///// <param name="handOverOrder"></param>
        ///// <returns></returns>
        //public IList<Order> GetHandOverOrderListCustomQuery(HandOverOrder handOverOrder)
        //{
        //   return orderDao.SelectAll();
        //}

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
        public IList<CashHandOver> GetCashHandOverListCustomQuery(CashHandOver cashHandOver)
        {
            return cashHandOverDao.SelectAll();
        }

        ///// <summary>
        ///// 获得收银交班工单一览(预付/定金)
        ///// </summary>
        ///// <param name="cashHandOverOrder"></param>
        ///// <returns></returns>
        //public IList<Order> GetCashHandOverOrderListCustomQuery(CashHandOverOrder cashHandOverOrder)
        //{
        //    return orderDao.SelectAll();
        //}

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
        public HandOver GetHandOverById(HandOver handOver)
        {
            return handOverDao.SelectByPk(handOver.Id);
        }

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
        //public CashHandOver GetCashHandOverById(HandOver handOver)
        //{
        //    return cashHandOverDao.SelectByHandOverId(handOver.Id);
        //}
        #endregion

        /// <summary>
        ///  取得预付定金/笔数
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-25
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public CashHandOver GetDebtAmount(Hashtable condition)
        {
            return orderDao.SelectDebtAmount(condition);
        }

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
        public CashHandOver GetKeepBusinessRecordAmount(Hashtable condition)
        {
            return orderDao.SelectKeepBusinessRecordAmount(condition);
        }

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
        public CashHandOver GetPayForAmount(Hashtable condition)
        {
            return gatheringDao.SelectPayForAmount(condition);
        }

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
        public CashHandOver GetTicketAmount(Hashtable condition)
        {
            return orderDao.SelectTicketAmount(condition);
        }

        /// <summary>
        /// 前台交班时加工单数据抽取
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetStageHandOverOrderList()
        {
            return orderDao.SelectStageHandOverOrder();
        }
        /// <summary>
        /// 前台交班时加工单数据抽取2008-11-04
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 朱静程
        /// 创建时间: 2008-11-04
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetFrontHandOverOrderList(Hashtable condition)
        {
            return orderDao.SelectFrontHandOverOrder(condition);
        }

        /// <summary>
        /// 收银交班时加工单数据抽取
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-13
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Order> GetCashHandOverOrderList(Hashtable condition)
        {
            return orderDao.SelectCashHandOverOrder(condition);
        }

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
        public IList<Employee> GetHandOverEmployeeList() 
        {
            return handOverDao.GetHandOverEmployeeList();
        }

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
        public IList<Position> GetHandOverPositionList() 
        {
            return handOverDao.GetHandOverPositionList();
        }

        /// <summary>
        /// 名    称:LastHandOverId
        /// 功能概要:获取当前用户为接班人的最近的交班Id
        /// 作    者:张晓林
        /// 创建时间:2009年4月12日17:37:16
        /// 修正时间:
        /// 修正履历:
        /// 修正描述:
        /// </summary>
        public long LastHandOverId() 
        {
            return handOverDao.LastHandOverId();
        }
    }
}

