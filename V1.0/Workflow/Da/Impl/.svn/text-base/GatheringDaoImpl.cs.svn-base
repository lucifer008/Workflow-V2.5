using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
/// <summary>
/// 名    称: GatheringDaoImpl
/// 功能概要: 付款明细接口IGatheringDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table GATHERING 对应的Dao 实现
	/// </summary>
    public class GatheringDaoImpl : Workflow.Da.Base.DaoBaseImpl<Gathering>, IGatheringDao
    {
        #region //查找某个客户某段时间内的付款明细
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
        public IList<Gathering> GetCustomerPayment(Order order)
        {
            return base.sqlMap.QueryForList<Gathering>("Gathering.SelectCustomerPayment", order);
        }
        #endregion

        #region //取得结款笔数/结款金额
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
        public CashHandOver SelectPayForAmount(Hashtable condition)
        {
            //condition.Add("PayType", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            condition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//结算款
            condition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//预付款冲减
            condition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//应收款
            condition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//会员卡冲减
            condition.Add("PreDeposits",Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
            condition.Add("AccountPreDepositsDiff",Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(应收款处理)
            return sqlMap.QueryForObject<CashHandOver>("Gathering.SelectPayForAmount", condition);
        }
        #endregion

        public IList<Gathering> SelectGatheringByOrderId(long orderId)
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            Gathering g = new Gathering();
            g.Id = orderId;
            g.CompanyId = user.CompanyId;
            g.BranchShopId = user.BranchShopId;
            return sqlMap.QueryForList<Gathering>("Gathering.SelectGatheringByOrderId",g);

        }

        /// <summary>
        /// 删除工单结算信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年10月12日10:20:28 
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void DeleteGatheringOrderInfo(long orderId) 
        {
            Gathering gathering = new Gathering();
            gathering.Id = orderId;
            gathering.InsertUser = Convert.ToInt32(Constants.PAY_KIND_PREPAY_VALUE);
            gathering.CompanyId=ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            gathering.BranchShopId=ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;

            sqlMap.Delete("Gathering.DeleteGatheringPaymentConcessionInfo",gathering);//优惠信息
            sqlMap.Delete("Gathering.DeleteGatheringOrderInfo", gathering);//结算关联工单信息
            sqlMap.Delete("Gathering.DeleteGatheringInfo",gathering);//结算款信息
        }
    }
}
