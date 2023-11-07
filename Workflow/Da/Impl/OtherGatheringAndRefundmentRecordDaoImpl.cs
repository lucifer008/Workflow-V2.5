#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
#endregion

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table OTHER_GATHERING_AND_REFUNDMENT_RECORD (其它收退款记录) 对应的Dao 实现
	/// </summary>
    public class OtherGatheringAndRefundmentRecordDaoImpl : Workflow.Da.Base.DaoBaseImpl<OtherGatheringAndRefundmentRecord>, IOtherGatheringAndRefundmentRecordDao
    {
        /// <summary>
        /// 冲减付款完成的订单发票(不欠款的订单)
        /// </summary>
        /// <param name="strOrderList"></param>
        /// <remarks>
        ///  作    者：张晓林
        ///  创建时间: 2009年12月17日16:32:48
        ///  修正履历：
        ///  修正时间:
        /// </remarks>
        public void DiffOrderTicket(IList<string> strOrderList) 
        {
            Order order =new Order();
            foreach(string str in strOrderList)
            {
                order.Id = Convert.ToInt32(str);
                sqlMap.Update("OtherGatheringAndRefundmentRecord.DiffOrderTicket", order);
            }
        }

        /// <summary>
        /// 取消收款完成的订单的欠发票
        /// </summary>
        /// <remarks>
        ///  作    者：张晓林
        ///  创建时间: 2009年12月31日10:36:31
        ///  修正履历：
        ///  修正时间:
        /// </remarks>
        public void CancelOrderDrawTicket(IList<string> strOrderList) 
        {
            Order order = new Order();
            foreach (string str in strOrderList)
            {
                order.Id = Convert.ToInt32(str);
                order.PaidTicket = Workflow.Support.Constants.NEED_TICKET_NOT_KEY;
                sqlMap.Update("OtherGatheringAndRefundmentRecord.CancelOrderDrawTicket", order);
            }
        }

        /// <summary>
        /// 作废结算产生的税费
        /// </summary>
        /// <remarks>
        ///  作    者：张晓林
        ///  创建时间: 2009年12月19日9:29:34
        ///  修正履历：
        ///  修正时间:
        /// </remarks>
        public void InvalidateScotRecord(OtherGatheringAndRefundmentRecord otherGatheringAndRefundRecord) 
        {
            otherGatheringAndRefundRecord.TempPayKind = Workflow.Support.Constants.INVALIDATE_KEY;
            otherGatheringAndRefundRecord.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            otherGatheringAndRefundRecord.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.Update("OtherGatheringAndRefundmentRecord.InvalidateScotRecord",otherGatheringAndRefundRecord);
        }

        /// <summary>
        /// 获取应收款记录列表
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日15:42:10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<OtherGatheringAndRefundmentRecord> SearchAccountRecord(Order order) 
        {
            order.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<OtherGatheringAndRefundmentRecord>("OtherGatheringAndRefundmentRecord.SearchAccountRecord", order);
        }

        /// <summary>
        /// 获取应收款记录列表记录数
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日15:42:10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long SearchAccountRecordRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("OtherGatheringAndRefundmentRecord.SearchAccountRecordRowCount", order);
        }

        /// <summary>
        /// 获取应收款记录列表(输出)
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月21日15:42:10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<OtherGatheringAndRefundmentRecord> SearchAccountRecordPrint(Order order)
        {
            return sqlMap.QueryForList<OtherGatheringAndRefundmentRecord>("OtherGatheringAndRefundmentRecord.SearchAccountRecordPrint", order);
        }

        #region//补领取发票记录
        /// <summary>
        /// 功能概要: 补领发票记录
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public IList<OtherGatheringAndRefundmentRecord> SearchDrawTicketRecord(OtherGatheringAndRefundmentRecord oGatheringRecord) 
        {
            oGatheringRecord.PayKind = Workflow.Support.Constants.DRAW_TICKET_AMOUNT_KEY.ToString();
            oGatheringRecord.CompanyId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            oGatheringRecord.BranchShopId = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<OtherGatheringAndRefundmentRecord>("OtherGatheringAndRefundmentRecord.SearchDrawTicketRecord", oGatheringRecord);
        }

        /// <summary>
        /// 功能概要: 补领发票记录数目
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public long SearchDrawTicketRecordRowCount(OtherGatheringAndRefundmentRecord oGatheringRecord) 
        {
            return sqlMap.QueryForObject<long>("OtherGatheringAndRefundmentRecord.SearchDrawTicketRecordRowCount", oGatheringRecord);
        }

        /// <summary>
        /// 功能概要: 补领发票记录输出记录
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        public IList<OtherGatheringAndRefundmentRecord> SearchDrawTicketRecordPrint(OtherGatheringAndRefundmentRecord oGatheringRecord) 
        {
            return sqlMap.QueryForList<OtherGatheringAndRefundmentRecord>("OtherGatheringAndRefundmentRecord.SearchDrawTicketRecordPrint", oGatheringRecord);
        }
        #endregion
    }
}