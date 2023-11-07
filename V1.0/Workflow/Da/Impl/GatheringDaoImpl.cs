using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
/// <summary>
/// ��    ��: GatheringDaoImpl
/// ���ܸ�Ҫ: ������ϸ�ӿ�IGatheringDaoʵ����
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table GATHERING ��Ӧ��Dao ʵ��
	/// </summary>
    public class GatheringDaoImpl : Workflow.Da.Base.DaoBaseImpl<Gathering>, IGatheringDao
    {
        #region //����ĳ���ͻ�ĳ��ʱ���ڵĸ�����ϸ
        /// <summary>
        /// ����ĳ���ͻ�ĳ��ʱ���ڵĸ�����ϸ
        /// </summary>
        /// <param name="condition">��ѯ����</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-25
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public IList<Gathering> GetCustomerPayment(Order order)
        {
            return base.sqlMap.QueryForList<Gathering>("Gathering.SelectCustomerPayment", order);
        }
        #endregion

        #region //ȡ�ý�����/�����
        /// <summary>
        /// ȡ�ý�����/�����
        /// </summary>
        /// <param name="cashhandOver"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-25
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public CashHandOver SelectPayForAmount(Hashtable condition)
        {
            //condition.Add("PayType", Constants.PAY_KIND_CLOSED_VALUE);//�����
            condition.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE);//�����
            condition.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
            condition.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//Ӧ�տ�
            condition.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//��Ա�����
            condition.Add("PreDeposits",Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(����)
            condition.Add("AccountPreDepositsDiff",Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(Ӧ�տ��)
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
        /// ɾ������������Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��12��10:20:28 
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public void DeleteGatheringOrderInfo(long orderId) 
        {
            Gathering gathering = new Gathering();
            gathering.Id = orderId;
            gathering.InsertUser = Convert.ToInt32(Constants.PAY_KIND_PREPAY_VALUE);
            gathering.CompanyId=ThreadLocalUtils.CurrentSession.CurrentUser.CompanyId;
            gathering.BranchShopId=ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId;

            sqlMap.Delete("Gathering.DeleteGatheringPaymentConcessionInfo",gathering);//�Ż���Ϣ
            sqlMap.Delete("Gathering.DeleteGatheringOrderInfo", gathering);//�������������Ϣ
            sqlMap.Delete("Gathering.DeleteGatheringInfo",gathering);//�������Ϣ
        }
    }
}
