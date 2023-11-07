using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// ��    ��: IGatheringDao
/// ���ܸ�Ҫ: ������ϸ�ӿ�
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table GATHERING ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IGatheringDao : IDaoBase<Gathering>
    {
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
		IList<Gathering> GetCustomerPayment(Order order);

		/// <summary>
		/// ����ĳ���ͻ�ĳ��ʱ���ڵĸ�����ϸ
		/// </summary>
		/// <param name="condition">��ѯ����</param>
		/// <returns></returns>
		/// <remarks>
		/// ��    ��: Cry	
		/// ����ʱ��: 2010.1.4
		/// ��������:
		/// ����ʱ��:
		/// </remarks>
		int GetCustomerPaymentCount(Order order);

		/// <summary>
		/// ����ĳ���ͻ�ĳ��ʱ���ڵĸ�����ϸ�ܼ�
		/// </summary>
		/// <param name="order"></param>
		/// <returns></returns>
		decimal GetCustomerPaymentAmount(Order order);
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
        CashHandOver SelectPayForAmount(Hashtable condition);

        /// <summary>
        /// ��ȡ������ȡ��˰��(����˰��+Ӧ�տ��˰��)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��12��21��12:02:58
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        decimal GetDailyScotAmount(Hashtable condition);

        IList<Gathering> SelectGatheringByOrderId(long orderId);

         /// <summary>
        /// ɾ������������Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��12��10:20:28 
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void DeleteGatheringOrderInfo(long orderId);

        /// <summary>
        /// ��ȡ��ǰ�û����ڰ�Ļ�Ա����ֵ���
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2010��1��14��14:55:59
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        decimal GetCurrentHandOverMemChargeAmount(Hashtable condition);

    }
}
