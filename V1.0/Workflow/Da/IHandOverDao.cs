using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;
namespace Workflow.Da
{
	/// <summary>
	/// Table HAND_OVER ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IHandOverDao : IDaoBase<HandOver>
    {
        /// <summary>
        /// ��    ��:Stage_Work_Start_Time
        /// ���ܸ�Ҫ:��ȡǰ̨���࿪ʼʱ��
        /// ��    ��:
        /// ����ʱ��:
        /// ��������:������
        /// ����ʱ��:2009��3��21��15:08:08
        /// ��������:��ȡ��һ�ν����ʱ��
        /// </summary>
        /// <returns></returns>
        string Stage_Work_Start_Time();

        /// <summary>
        /// ��    ��:Cash_Work_Start_Time
        /// ���ܸ�Ҫ:��ȡ��������Ŀ�ʼʱ��(��ȡ��һ�ν����ʱ��)
        /// ��    ��:������
        /// ����ʱ��:2009��3��21��17:22:31
        /// ��������:
        /// ����ʱ��:
        /// ��������:
        /// </summary>
        /// <returns></returns>
        string Cash_Work_Start_Time();


        /// <summary>
        /// ��    ��:DailyPaperMinHandOverDateTime
        /// ���ܸ�Ҫ:�������ڻ�ȡ�����������罻���ʱ��
        /// ��    ��:������
        /// ����ʱ��:2009��3��27��17:03:15
        /// ��������:
        /// ����ʱ��:
        /// ��������:
        /// </summary>
        /// <returns></returns>
        string DailyPaperMinHandOverDateTime(string QueryDateTime);


         /// <summary>
        /// �����·ݻ�ȡ���½��������ʱ������ʱ��
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��3��30��9:33:32
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        HandOver MonthPaperMinHandOverDateTime(string QueryDateTime);

        /// <summary>
        /// ��ȡ������Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��3��26��9:57:47
        /// ��������:
        /// ����ʱ�䣺
        /// ��������:
        /// </remarks>
        IList<HandOver> SearchHandOver(HandOver handOver);

         /// <summary>
        /// ��ȡ������Ϣ��¼��
        /// </summary>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��3��26��9:57:47
        /// ��������:
        /// ����ʱ�䣺
        /// ��������:
        /// </remarks>
        long SearchHandOverRowCount(HandOver handOver);

        /// <summary>
        /// ��ȡǰ̨����Ļ�Ա����Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��3��26��9:57:47
        /// ��������:
        /// ����ʱ�䣺
        /// ��������:
        /// </remarks>
        IList<MemberCard> GetHandOverMemberCard(HandOver handOver);

        /// <summary>
        /// ��ȡǰ̨����Ĺ�����Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��3��26��9:57:47
        /// ��������:
        /// ����ʱ�䣺
        /// ��������:
        /// </remarks>
        IList<Order> GetHandOverOrders(HandOver handOver);

        /// <summary>
        /// ��ȡ��������Ĺ���Ԥ������Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��3��26��9:57:47
        /// ��������:
        /// ����ʱ�䣺
        /// ��������:
        /// </remarks>
        IList<Order> GetHandOverPreMoneyInfo(HandOver handOver);

        /// <summary>
        /// ��ȡ�������������������Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��:������
        /// ����ʱ��:2009��3��26��9:57:47
        /// ��������:
        /// ����ʱ�䣺
        /// ��������:
        /// </remarks>
        CashHandOver GetHandOverOtherFundInfo(HandOver handOver);

        /// <summary>
        /// ��ȡ�Ӱ���(ֻ����:ǰ̨���곤,����������Ա)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��7��12:10:29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Employee> GetHandOverEmployeeList();

        /// <summary>
        /// ��ȡ�Ӱಿ��(ֻ����:ǰ̨���곤,��������)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��7��12:10:29
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Position> GetHandOverPositionList();

        /// <summary>
        /// ��    ��:LastHandOverId
        /// ���ܸ�Ҫ:��ȡ��ǰ�û�Ϊ�Ӱ��˵�����Ľ���Id
        /// ��    ��:������
        /// ����ʱ��:2009��4��12��17:37:16
        /// ����ʱ��:
        /// ��������:
        /// ��������:
        /// </summary>
        long LastHandOverId();
    }
}
