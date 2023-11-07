using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
using System.Collections;
/// <summary>
/// ��    ��: PaymentConcessionDaoImpl
/// ���ܸ�Ҫ: �����Żݽӿ�IPaymentConcessionDaoʵ����
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table PAYMENT_CONCESSION ��Ӧ��Dao ʵ��
	/// </summary>
    public class PaymentConcessionDaoImpl : Workflow.Da.Base.DaoBaseImpl<PaymentConcession>, IPaymentConcessionDao
    {
        #region ���ݶ���Id��ȡ�������Ż�
        /// <summary>
        /// ���ݶ���Id��ȡ�������Ż�
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        public IList<PaymentConcession> GetOrderPaymentConcessionByOrderId(long ordersId)
        {
            PaymentConcession pc = new PaymentConcession();
            pc.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            pc.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            pc.Memo = Constants.PAY_KIND_INVALIDATE_VALUE;//�ų����ϵĶ���
            pc.Id = ordersId;
            return sqlMap.QueryForList<PaymentConcession>("PaymentConcession.SelectOrderConcessionByOrderId", pc);
        }
        #endregion

        #region//�Żݲ�ѯ
        /// <summary>
        /// �Żݲ�ѯ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��14:15:22
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Gathering> SearchConcession(PaymentConcession paymentConcession) 
        {
            paymentConcession.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            paymentConcession.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            paymentConcession.PayTypeBalance=Constants.PAY_KIND_CLOSED_VALUE;//�����
            paymentConcession.PayTypePreDiff=Constants.PAY_KIND_USE_PREPAY_VALUE;//Ԥ������
            paymentConcession.PayTypeOwe=Constants.PAY_KIND_ARREARAGE_VALUE;//Ӧ�տ�
            paymentConcession.PayTypeMemberCardDiff=Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE;//��Ա�����
            paymentConcession.PreDepositsDiff = Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����(����)
            paymentConcession.AccountPreDepositsDiff = Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE;//�ͻ�Ԥ�����(Ӧ�տ��)

            paymentConcession.InsertUser = Convert.ToInt32(Constants.CONCESSION_TYPE_ZERO_VALUE);//Ĩ��
            paymentConcession.UpdateUser = Convert.ToInt32(Constants.CONCESSION_TYPE_CONCESSION_VALUE);//�Ż�
            paymentConcession.Memo = Constants.CONCESSION_TYPE_RENDERUP_VALUE;//����
            paymentConcession.Version = Convert.ToInt32(Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);//��������
            paymentConcession.ConcessionType = Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE;//�������
            return sqlMap.QueryForList<Gathering>("PaymentConcession.SearchConcession", paymentConcession);
        }

        /// <summary>
        /// �Żݲ�ѯ��¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��14:15:22
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public long SearchConcessionRowCount(PaymentConcession paymentConcession) 
        {
            return sqlMap.QueryForObject<long>("PaymentConcession.SearchConcessionRowCount", paymentConcession);
        }

        /// <summary>
        /// �Żݲ�ѯ��¼(���)
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��21��11:56:54
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        public IList<Gathering> SearchConcessionPrint(PaymentConcession paymentConcession) 
        {
            return sqlMap.QueryForList<Gathering>("PaymentConcession.SearchConcessionPrint", paymentConcession);
        }
        #endregion

        #region//��ȡǰ�������Ķ���Id
        /// <summary>
        /// ���ݶ����Ż�ȡǰ�������Ķ���Id
        /// </summary>
        /// <param name="orderNo">order</param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��11��15:25:18
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        public long GetPhophaseOrderId(Order order) 
        {
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("PaymentConcession.GetPhophaseOrderId", order);
        }
        #endregion

		#region ��������ͳ���Ż���Ϣ
	    /// <summary>
		/// ��    ��: SelectPayConcessionListByUserId
		/// ���ܸ�Ҫ: ��������ͳ���Ż���Ϣ
		/// ��    ��: 
		/// ����ʱ��: 
		/// �� �� ��: ������
		/// ����ʱ��: 2010-05-17
		/// ��    ��: 
	    /// </summary>
	    /// <param name="paymentConcession"></param>
	    /// <returns></returns>
		public IList<PaymentConcession> SelectPayConcessionListByUserId(PaymentConcession paymentConcession)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

			Hashtable para = new Hashtable();
			para.Add("CompanyId", user.CompanyId);
			para.Add("BaranchShopId", user.BranchShopId);

			para.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE); //�����
			para.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
			para.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//Ӧ�տ�
			para.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//��Ա�����
			para.Add("PreDepositsDiff", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(����)
			para.Add("AccountPreDepositsDiff", Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(Ӧ�տ��)

			para.Add("ConcessionType1", Constants.CONCESSION_TYPE_ZERO_VALUE);//Ĩ��
			para.Add("ConcessionType2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);//�Ż�
			para.Add("ConcessionType3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);//����
			para.Add("ConcessionType4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);//��������
			para.Add("ConcessionType5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//�������

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

		#region ��������ͳ���Ż���Ϣ(ͳ�Ƽ�¼��)
		/// <summary>
		/// ��    ��: SelectPayConcessionCountByUserId
		/// ���ܸ�Ҫ: ��������ͳ���Ż���Ϣ(ͳ�Ƽ�¼��)
		/// ��    ��: 
		/// ����ʱ��: 
		/// �� �� ��: ������
		/// ����ʱ��: 2010-05-17
		/// ��    ��: 
		/// </summary>
		/// <param name="paymentConcession"></param>
		/// <returns></returns>
		public int SelectPayConcessionCountByUserId(PaymentConcession paymentConcession)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

			Hashtable para = new Hashtable();
			para.Add("CompanyId", user.CompanyId);
			para.Add("BaranchShopId", user.BranchShopId);

			para.Add("PayTypeBalance", Constants.PAY_KIND_CLOSED_VALUE); //�����
			para.Add("PayTypePreDiff", Constants.PAY_KIND_USE_PREPAY_VALUE);//Ԥ������
			para.Add("PayTypeOwe", Constants.PAY_KIND_ARREARAGE_VALUE);//Ӧ�տ�
			para.Add("PayTypeMemberCardDiff", Constants.PAY_KIND_MEMBERCARD_DIFF_VALUE);//��Ա�����
			para.Add("PreDepositsDiff", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(����)
			para.Add("AccountPreDepositsDiff", Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//�ͻ�Ԥ�����(Ӧ�տ��)

			para.Add("ConcessionType1", Constants.CONCESSION_TYPE_ZERO_VALUE);//Ĩ��
			para.Add("ConcessionType2", Constants.CONCESSION_TYPE_CONCESSION_VALUE);//�Ż�
			para.Add("ConcessionType3", Constants.CONCESSION_TYPE_RENDERUP_VALUE);//����
			para.Add("ConcessionType4", Constants.CONCESSION_TYPE_ROUND_NEGTIVE_VALUE);//��������
			para.Add("ConcessionType5", Constants.CONCESSION_TYPE_ROUND_POSITIVE_VALUE);//�������

			para.Add("OperateUsersId", paymentConcession.OperateUsersId);

			para.Add("BeiginDateTimeString", paymentConcession.BeiginDateTimeString);
			para.Add("EndDateTimeString", paymentConcession.EndDateTimeString);
			para.Add("OperateUsersIdList", paymentConcession.OperateUserIdList);

			return sqlMap.QueryForObject<int>("PaymentConcession.SelectPayConcessionCountByUserId",para);
		}
		#endregion

		#region ͨ�������˻�ȡ�Żݶ�����Ϣ
		/// <summary>
		/// ��    ��: SelectPayConcessionOrderInfoByOperateUserId
		/// ���ܸ�Ҫ: ͨ�������˻�ȡ�Żݶ�����Ϣ
		/// ��    ��: ������
		/// ����ʱ��: 2010-05-18
		/// �� �� ��: 
		/// ����ʱ��: 
		/// ��    ��:
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
