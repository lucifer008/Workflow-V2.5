using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Workflow.Support;
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table HAND_OVER 对应的Dao 实现
	/// </summary>
    public class HandOverDaoImpl : Workflow.Da.Base.DaoBaseImpl<HandOver>, IHandOverDao
    {
        /// <summary>
        /// 名    称:Stage_Work_Start_Time
        /// 功能概要:获取加班时间
        /// 作    者:
        /// 创建时间:
        /// 修正履历:张晓林
        /// 修正时间:2009年3月21日15:08:08
        /// 修正描述:获取上一次交班的时间
        /// </summary>
        /// <returns></returns>
        public string Stage_Work_Start_Time()
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("HandOverType", Constants.HANDER_OVER_FRONT);//前台交班
            HandOver handOver = sqlMap.QueryForObject<HandOver>("HandOver.GetWorkStartDateTime", condition);
            if (null == handOver)//第一次交班
            {
                return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            }
            else 
            {
                return handOver.HandOverDateTime.ToString();
            }
        }

        /// <summary>
        /// 名    称:Cash_Work_Start_Time
        /// 功能概要:获取收银交班的开始时间
        /// 作    者:
        /// 创建时间:
        /// 修正履历:张晓林
        /// 修正时间:2009年3月21日15:08:08
        /// 修正描述:获取上一次交班的时间
        /// </summary>
        /// <returns></returns>
        public string Cash_Work_Start_Time() 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("HandOverType", Constants.HANDER_OVER_CASHER);//收银交班
            HandOver handOver = sqlMap.QueryForObject<HandOver>("HandOver.GetWorkStartDateTime", condition);
            if (null == handOver)//第一次交班
            {
                return DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");//DateTime.Now.ToShortDateString();
            }
            else
            {
                return handOver.HandOverDateTime.ToString();
            }
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
        public string DailyPaperMinHandOverDateTime(string queryDateTime)
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("HandOverType", Constants.HANDER_OVER_CASHER);//收银交班
            condition.Add("HandOverDateTime", queryDateTime);
            return sqlMap.QueryForObject<string>("HandOver.DailyPaperMinHandOverDateTime", condition);
        }

        /// <summary>
        /// 按照月份获取本月最早交班的时间与最迟交班时间
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月30日9:33:32
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public HandOver MonthPaperMinHandOverDateTime(string queryDateTime) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("HandOverType", Constants.HANDER_OVER_CASHER);//收银交班
            condition.Add("HandOverDateTime", queryDateTime);
            return sqlMap.QueryForObject<HandOver>("HandOver.MonthPaperMinHandOverDateTime", condition);
        }
        #region //交班查询

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
        public IList<HandOver> SearchHandOver(HandOver handOver) 
        {
            handOver.HandOverTypeCasher = Constants.HANDER_OVER_CASHER;//收银交班
            handOver.HandOverType = Constants.HANDER_OVER_FRONT.ToString();//前台交班
            handOver.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            handOver.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<HandOver>("HandOver.SearchHandOver", handOver);
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
            handOver.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            handOver.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("HandOver.SearchHandOverRowCount", handOver);
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
            handOver.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            handOver.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<MemberCard>("HandOver.GetHandOverMemberCard", handOver);
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
            handOver.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            handOver.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Order>("HandOver.GetHandOverOrders", handOver);
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
            handOver.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            handOver.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Order>("HandOver.GetHandOverPreMoneyInfo", handOver);
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
            handOver.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            handOver.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<CashHandOver>("HandOver.GetHandOverOtherFundInfo", handOver);
        }

        #endregion

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
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("PositionStage", Constants.POSITION_RECEPTION_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId));//前台
            condition.Add("PositionShop", Constants.POSITION_SHOP_MASTER_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId));//店长
            condition.Add("PositionCash", Constants.POSITION_CASHER_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId));//收银
            return sqlMap.QueryForList<Employee>("HandOver.GetHandOverEmployeeList", condition);
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
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("PositionStage", Constants.POSITION_RECEPTION_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId));//前台
            condition.Add("PositionShop", Constants.POSITION_SHOP_MASTER_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId));//店长
            condition.Add("PositionCash", Constants.POSITION_CASHER_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId));//收银
            return sqlMap.QueryForList<Position>("HandOver.GetHandOverPositionList", condition);
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
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("CurrentUserEmployeeId",ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeId);
            condition.Add("HandOverType", Constants.HANDER_OVER_FRONT);
            return sqlMap.QueryForObject<long>("HandOver.CurrentUserEmplLastHandOverId", condition);
        }
    }
}
