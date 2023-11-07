using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
/// <summary>
/// ��    ��: IAchievementDao
/// ���ܸ�Ҫ: ��Ч����ӿ�
/// ��    ��: 
/// ����ʱ��: 
/// ��������: ������
/// ����ʱ��: 2009-02-07
///             ��������
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table ACHIEVEMENT ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IAchievementDao : IDaoBase<Achievement>
    {
        /// <summary>
        /// ҵ������ ɾ����ҵ��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-2
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void DeleteAchievementByOrdersId(Achievement achievement);
        /// <summary>
        /// ҵ����ѯ(��ҳ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-3
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<Achievement> SearchAchievement(Hashtable achievement);

        /// <summary>
        /// ҵ��ͳ���ܼ�¼��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��5��10:05:52
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        
        long SearchAchievementRowCount(Hashtable achievement);

        /// <summary>
        /// ҵ��ͳ��(��ӡ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��5��10:05:52
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<Achievement> SearchAchievementPrint(Hashtable achievement);

        /// <summary>
        /// ����ҵ��ͳ��(��ҳ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-3
        /// ��������:
        /// ����ʱ��:2009��1��6��11:06:17
        /// </remarks>
        IList<Achievement> GetAchievementCount(Hashtable achievement);

        /// <summary>
        /// ����ҵ��ͳ���ܼ�¼��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009-1-6
        /// ��������:
        /// ����ʱ��:2009��1��6��11:06:17
        /// </remarks>
        long GetAchievementCountTotal(Hashtable achievement);

        /// <summary>
        /// ����ҵ��ͳ��(��ӡ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009-1-6
        /// ��������:
        /// ����ʱ��:2009��1��6��11:06:17
        /// </remarks>
        IList<Achievement> GetAchievementCountPrint(Hashtable achievement);

        /// <summary>
        /// Ա��ҵ��ͳ��(��ҳ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-3
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<Achievement> GetCustomerAchievementCount(Hashtable achievement);

        /// <summary>
        /// Ա��ҵ��ͳ���ܼ�¼��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��7��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        long GetCustomerAchievementCountTotal(Hashtable achievement);

        /// <summary>
        /// Ա��ҵ��ͳ��(��ӡ)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��1��7��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<Achievement> GetCustomerAchievementCountPrint(Hashtable achievement);
        

        /// <summary>
        /// Ա��ҵ������
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-11-��
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<Achievement> GetCustomerAchievementDetail(Hashtable achievement);

        /// <summary>
        /// Ա��ҵ�������¼��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ��������:2009��4��23��11:25:25
        /// ����ʱ��:
        /// </remarks>
        long GetCustomerAchievementDetailRowCount(Hashtable achievement);

        /// <summary>
        /// Ա��ҵ������(���)
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��23��11:25:35
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<Achievement> GetCustomerAchievementDetailPrint(Hashtable achievement);

        /// <summary>
        /// ��ȡҵ������ͨ��������ϸ�͹͹�id
        /// </summary>
        /// <remarks>
        /// ��    ��: ����ط
        /// ����ʱ��: 2009-1-6
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        Achievement GetAchievement(long orderItemId, long employeeId);

        /// <summary>
        /// ����OrderIdɾ��ҵ��
        /// </summary>
        /// <param name="orderId"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��9��16:00:10
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void DeleteAchievement(long orderId);

        /// <summary>
        /// ����Ա����ҵ����Ϣ
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��9��17:06:39
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        Achievement GetOrderAchievementInfoByOrderIdOrEmployeeId(Hashtable condition);


        /// <summary>
        /// ���ݹ����Ż�ȡǰ�ںͺ�ӹ����������Ĺ�����ϸ��Ϣ
        /// </summary>
        /// <param name="orderNo"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��11��13:41:37
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<OrderItem> GetOrderItemByOrderNo(string orderNo);

        /// <summary>
        /// �곤����Чͳ��
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��5��23��14:33:36
        /// ��������:
        /// ����ʱ��:
        ///</remarks>
        IList<Achievement> SearchAchievementByShoperAndManager(Achievement achievement); 
    }
}
