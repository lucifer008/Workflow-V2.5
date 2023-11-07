using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// ��    ��: IPaymentConcessionDao
/// ���ܸ�Ҫ: �����Żݽӿ�
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table PAYMENT_CONCESSION ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IPaymentConcessionDao : IDaoBase<PaymentConcession>
    {
        /// <summary>
        /// ��ȡ�������Ż�
        /// </summary>
        /// <param name="ordersId"></param>
        /// <returns></returns>
        IList<PaymentConcession> GetOrderPaymentConcessionByOrderId(long ordersId);

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
        IList<Gathering> SearchConcession(PaymentConcession paymentConcession);

        /// <summary>
        /// �Żݲ�ѯ��¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��20��14:15:22
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        long SearchConcessionRowCount(PaymentConcession paymentConcession);

        /// <summary>
        /// �Żݲ�ѯ��¼(���)
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��21��11:56:54
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Gathering> SearchConcessionPrint(PaymentConcession paymentConcession);
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
        long GetPhophaseOrderId(Order order);
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
		IList<PaymentConcession> SelectPayConcessionListByUserId(PaymentConcession paymentConcession);
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
		int SelectPayConcessionCountByUserId(PaymentConcession paymentConcession);
		#endregion
    }
}
