using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using System.Collections;
/// <summary>
/// 名    称: PaymentConcessionDaoImpl
/// 功能概要: 订单优惠接口IPaymentConcessionDao实现类
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
        #region 根据订单Id获取订单的优惠
        /// <summary>
        /// 根据订单Id获取订单的优惠
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public IList<PaymentConcession> GetOrderPaymentConcessionByOrderId(long ordersId)
        {
            PaymentConcession pc = new PaymentConcession();
            pc.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            pc.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            pc.Memo = Constants.PAY_KIND_INVALIDATE_VALUE;//排除作废的订单
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
        public IList<Gathering> SearchConcession(PaymentConcession paymentConcession) 
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
            return sqlMap.QueryForList<Gathering>("PaymentConcession.SearchConcession", paymentConcession);
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
        public IList<Gathering> SearchConcessionPrint(PaymentConcession paymentConcession) 
        {
            return sqlMap.QueryForList<Gathering>("PaymentConcession.SearchConcessionPrint", paymentConcession);
        }
        #endregion

        #region//获取前期修正的订单Id
        /// <summary>
        /// 根据订单号获取前期修正的订单Id
        /// </summary>
        /// <param name="orderNo">order</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月11日15:25:18
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long GetPhophaseOrderId(Order order) 
        {
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("PaymentConcession.GetPhophaseOrderId", order);
        }
        #endregion

		#region 按操作人统计优惠信息
	    /// <summary>
		/// 名    称: SelectPayConcessionListByUserId
		/// 功能概要: 按操作人统计优惠信息
		/// 作    者: 
		/// 创建时间: 
		/// 修 正 人: 白晓宇
		/// 修正时间: 2010-05-17
		/// 描    述: 
	    /// </summary>
	    /// <param name="paymentConcession"></param>
	    /// <returns></returns>
		public IList<PaymentConcession> SelectPayConcessionListByUserId(PaymentConcession paymentConcession)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

			Hashtable para = new Hashtable();
			para.Add("CompanyId", user.CompanyId);
			para.Add("BaranchShopId", user.BranchShopId);

			para.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE); //结算款
			para.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
			para.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
			para.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
			para.Add("PreDepositsDiff", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
			para.Add("AccountPreDepositsDiff", Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(应收款处理)

			para.Add("ConcessionType1", Constants.CONCESSION_TYPE_ZERO_VALUE);//抹零
			para.Add("ConcessionType2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);//优惠
			para.Add("ConcessionType3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);//折让
			para.Add("ConcessionType4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);//舍入少收
			para.Add("ConcessionType5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//舍入多收

			para.Add("BeiginDateTimeString", paymentConcession.BeiginDateTimeString);
			para.Add("EndDateTimeString", paymentConcession.EndDateTimeString);

			para.Add("OperateUsersId", paymentConcession.OperateUsersId);

			para.Add("CurrentPageIndex", paymentConcession.CurrentPageIndex);
			para.Add("RowCount", paymentConcession.RowCount);
			para.Add("OperateUsersIdList", paymentConcession.OperateUserIdList);

			IList<PaymentConcession> paymentConcessionList = sqlMap.QueryForList<PaymentConcession>("PaymentConcession.SelectPayConcessionListByUserId", para);

			PaymentConcession domain = null;
			foreach (PaymentConcession item in paymentConcessionList)
			{

				domain = this.SelectPayConcessionOrderInfoByOperateUserId(item.OperateUsersId, paymentConcession.BeiginDateTimeString, paymentConcession.EndDateTimeString);
				if (null != domain)
				{
					item.OrderCount = domain.OrderCount;
					item.SumAmountTotal = domain.SumAmountTotal;
					item.RealAmountTotal = domain.RealAmountTotal;
				}
			}

			return paymentConcessionList;
		}
		#endregion

		#region 按操作人统计优惠信息(统计记录数)
		/// <summary>
		/// 名    称: SelectPayConcessionCountByUserId
		/// 功能概要: 按操作人统计优惠信息(统计记录数)
		/// 作    者: 
		/// 创建时间: 
		/// 修 正 人: 白晓宇
		/// 修正时间: 2010-05-17
		/// 描    述: 
		/// </summary>
		/// <param name="paymentConcession"></param>
		/// <returns></returns>
		public int SelectPayConcessionCountByUserId(PaymentConcession paymentConcession)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

			Hashtable para = new Hashtable();
			para.Add("CompanyId", user.CompanyId);
			para.Add("BaranchShopId", user.BranchShopId);

			para.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE); //结算款
			para.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
			para.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
			para.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
			para.Add("PreDepositsDiff", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
			para.Add("AccountPreDepositsDiff", Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(应收款处理)

			para.Add("ConcessionType1", Constants.CONCESSION_TYPE_ZERO_VALUE);//抹零
			para.Add("ConcessionType2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);//优惠
			para.Add("ConcessionType3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);//折让
			para.Add("ConcessionType4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);//舍入少收
			para.Add("ConcessionType5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//舍入多收

			para.Add("OperateUsersId", paymentConcession.OperateUsersId);

			para.Add("BeiginDateTimeString", paymentConcession.BeiginDateTimeString);
			para.Add("EndDateTimeString", paymentConcession.EndDateTimeString);
			para.Add("OperateUsersIdList", paymentConcession.OperateUserIdList);

			return sqlMap.QueryForObject<int>("PaymentConcession.SelectPayConcessionCountByUserId",para);
		}
		#endregion

		#region 通过操作人获取优惠订单信息
		/// <summary>
		/// 名    称: SelectPayConcessionOrderInfoByOperateUserId
		/// 功能概要: 通过操作人获取优惠订单信息
		/// 作    者: 白晓宇
		/// 创建时间: 2010-05-18
		/// 修 正 人: 
		/// 修正时间: 
		/// 描    述:
		/// </summary>
		/// <param name="operateUserId"></param>
		/// <returns></returns>
		public PaymentConcession SelectPayConcessionOrderInfoByOperateUserId(long operateUserId, string beiginDateTimeString, string endDateTimeString)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			Hashtable para = new Hashtable();
			para.Add("OperateUsersId", operateUserId);
			para.Add("BeiginDateTimeString", beiginDateTimeString);
			para.Add("EndDateTimeString", endDateTimeString);
			para.Add("CompanyId", user.CompanyId);
			para.Add("BaranchShopId", user.BranchShopId);

			return sqlMap.QueryForObject<PaymentConcession>("PaymentConcession.SelectPayConcessionOrderInfoByOperateUserId", para);
		}
		#endregion
	}
}
