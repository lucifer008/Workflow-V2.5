#region imports
using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
#endregion

namespace Workflow.Da
{
	/// <summary>
	/// Table OTHER_GATHERING_AND_REFUNDMENT_RECORD (其它收退款记录)对应的Dao 接口
	/// </summary>
	public interface IOtherGatheringAndRefundmentRecordDao : IDaoBase<OtherGatheringAndRefundmentRecord>
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
        void DiffOrderTicket(IList<string> strOrderList);

        /// <summary>
        /// 取消收款完成的订单的欠发票
        /// </summary>
        /// <remarks>
        ///  作    者：张晓林
        ///  创建时间: 2009年12月31日10:36:31
        ///  修正履历：
        ///  修正时间:
        /// </remarks>
        void CancelOrderDrawTicket(IList<string> strOrderList);

        /// <summary>
        /// 作废结算差生的税费
        /// </summary>
        /// <remarks>
        ///  作    者：张晓林
        ///  创建时间: 2009年12月19日9:29:34
        ///  修正履历：
        ///  修正时间:
        /// </remarks>
        void InvalidateScotRecord(OtherGatheringAndRefundmentRecord otherGatheringAndRefundRecord);

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
        IList<OtherGatheringAndRefundmentRecord> SearchAccountRecord(Order order);

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
        long SearchAccountRecordRowCount(Order order);

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
        IList<OtherGatheringAndRefundmentRecord> SearchAccountRecordPrint(Order order);

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
        IList<OtherGatheringAndRefundmentRecord> SearchDrawTicketRecord(OtherGatheringAndRefundmentRecord oGatheringRecord);

        /// <summary>
        /// 功能概要: 补领发票记录数目
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        long SearchDrawTicketRecordRowCount(OtherGatheringAndRefundmentRecord oGatheringRecord);
        /// <summary>
        /// 功能概要: 补领发票记录输出记录
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年12月30日9:50:18
        /// 修正履历:
        /// 修正时间: 
        ///</remarks>
        IList<OtherGatheringAndRefundmentRecord> SearchDrawTicketRecordPrint(OtherGatheringAndRefundmentRecord oGatheringRecord);
        #endregion
	}
}