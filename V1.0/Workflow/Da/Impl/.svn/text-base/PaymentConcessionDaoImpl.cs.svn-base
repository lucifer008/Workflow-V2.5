using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
/// <summary>
/// 名    称: PaymentConcessionDaoImpl
/// 功能概要: 工单优惠接口IPaymentConcessionDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table PAYMENT_CONCESSION 对应的Dao 实现
	/// </summary>
    public class PaymentConcessionDaoImpl : Workflow.Da.Base.DaoBaseImpl<PaymentConcession>, IPaymentConcessionDao
    {
        #region 根据工单Id获取工单的优惠
        /// <summary>
        /// 根据工单Id获取工单的优惠
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public IList<PaymentConcession> GetOrderPaymentConcessionByOrderId(long ordersId)
        {
            PaymentConcession pc = new PaymentConcession();
            pc.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            pc.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            pc.Id = ordersId;
            return sqlMap.QueryForList<PaymentConcession>("PaymentConcession.SelectOrderConcessionByOrderId", pc);
        }
        #endregion

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
        public IList<PaymentConcession> SearchConcession(PaymentConcession paymentConcession) 
        {
            paymentConcession.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            paymentConcession.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            paymentConcession.PayTypeBalance=Constants.PAY_KIND_CLOSED_VALUE;//结算款
            paymentConcession.PayTypePreDiff=Constants.PAY_KIND_USE_PREPAY_VALUE;//预付款冲减
            paymentConcession.PayTypeOwe=Constants.PAY_KIND_ARREARAGE_VALUE;//应收款
            paymentConcession.PayTypeMemberCardDiff=Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//会员卡冲减
            paymentConcession.PreDepositsDiff = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(结算)
            paymentConcession.AccountPreDepositsDiff = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//客户预存款冲减(应收款处理)

            paymentConcession.InsertUser = Convert.ToInt32(Constants.CONCESSION_TYPE_ZERO_VALUE);//抹零
            paymentConcession.UpdateUser = Convert.ToInt32(Constants.CONCESSION_TYPE_CONCESSION_VALUE);//优惠
            paymentConcession.Memo = Constants.CONCESSION_TYPE_RENDERUP_VALUE;//折让
            paymentConcession.Version = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);//舍入少收
            paymentConcession.ConcessionType = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//舍入多收
            return sqlMap.QueryForList<PaymentConcession>("PaymentConcession.SearchConcession", paymentConcession);
        }

        /// <summary>
        /// 优惠查询记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月20日14:15:22
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long SearchConcessionRowCount(PaymentConcession paymentConcession) 
        {
            return sqlMap.QueryForObject<long>("PaymentConcession.SearchConcessionRowCount", paymentConcession);
        }

        /// <summary>
        /// 优惠查询记录(输出)
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年5月21日11:56:54
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<PaymentConcession> SearchConcessionPrint(PaymentConcession paymentConcession) 
        {
            return sqlMap.QueryForList<PaymentConcession>("PaymentConcession.SearchConcessionPrint", paymentConcession);
        }
        #endregion
    }
}
