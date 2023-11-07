using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: IPaymentConcessionDao
/// 功能概要: 工单优惠接口
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table PAYMENT_CONCESSION 对应的Dao 接口
	/// </summary>
    public interface IPaymentConcessionDao : IDaoBase<PaymentConcession>
    {
        /// <summary>
        /// 获取工单的优惠
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        IList<PaymentConcession> GetOrderPaymentConcessionByOrderId(long ordersId);

        #region//优惠查询
        /// <summary>
        /// 优惠查询
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日14:15:22
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<PaymentConcession> SearchConcession(PaymentConcession paymentConcession);

        /// <summary>
        /// 优惠查询记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日14:15:22
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        long SearchConcessionRowCount(PaymentConcession paymentConcession);

        /// <summary>
        /// 优惠查询记录(输出)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月21日11:56:54
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<PaymentConcession> SearchConcessionPrint(PaymentConcession paymentConcession);
        #endregion
    }
}
