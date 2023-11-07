using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: IGatheringDao
/// 功能概要: 付款明细接口
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table GATHERING 对应的Dao 接口
	/// </summary>
    public interface IGatheringDao : IDaoBase<Gathering>
    {
        /// <summary>
        /// 查找某个客户某段时间内的付款明细
        /// </summary>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 付强
        /// 创建时间: 2007-10-25
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Gathering> GetCustomerPayment(Order order);
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
        CashHandOver SelectPayForAmount(Hashtable condition);


        IList<Gathering> SelectGatheringByOrderId(long orderId);

         /// <summary>
        /// 删除工单结算信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月12日10:20:28 
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void DeleteGatheringOrderInfo(long orderId);

    }
}
