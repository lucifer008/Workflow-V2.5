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
        IList<PaymentConcession> SearchConcession(PaymentConcession paymentConcession);

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
        IList<PaymentConcession> SearchConcessionPrint(PaymentConcession paymentConcession);
        #endregion
    }
}
