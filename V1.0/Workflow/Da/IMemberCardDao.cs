using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Da
{
	/// <summary>
	/// Table MEMBER_CARD ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IMemberCardDao : IDaoBase<MemberCard>
    {

		
        /// <summary>
        /// ��    ��: SearchMemberCard
        /// ���ܸ�Ҫ: ��ѯ��Ա����Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-9-29
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        IList<MemberCard> SearchMemberCard(Hashtable condition);

        /// <summary>
        /// ��    ��: SearchMemberCardRowCount
        /// ���ܸ�Ҫ: ��ѯ��Ա����Ϣ��¼��
        /// ��    ��: ������
        /// ����ʱ��: 2009-02-11
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        long SearchMemberCardRowCount(Hashtable condition);

        /// <summary>
        /// ��    ��: SearchMemberCardByIdentityCard
        /// ���ܸ�Ҫ: ͨ��IdentityCardNo��ѯMemberCardInfo
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-5
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        IList<MemberCard> SearchMemberCardByIdentityCard(Hashtable hashtable);

        /// <summary>
        /// ��    ��: UpdateMemberState
        /// ���ܸ�Ҫ: ����MemberCard��״̬
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-6
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        void UpdateMemberState(System.Collections.Hashtable condition);
        /// <summary>
        /// ��    ��: SelectMemberCardByMemberCardNoAndPassWord
        /// ���ܸ�Ҫ: ͨ��MemberCardNo��PassWord��ѯ��Ա����Ϣ
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-6
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        ///
        int SelectMemberCardByMemberCardNoAndPassWord(System.Collections.Hashtable condition);
        /// <summary>
        /// ͨ��MemberCardId��ѯ��Ա����Ϣ(ֻ��ѯ����״̬��)
        /// </summary>
        /// <param name="memberCardNo">��Ա����</param>
        /// <returns>MemberCard</returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-7
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        MemberCard SearchSelectMemberCardByCardNo(string memberCardNo);
        /// <summary>
        /// ͨ��MemberCardId��ѯ��Ա����Ϣ(��ѯ����)
        /// </summary>
        /// <param name="memberCardNo">��Ա����</param>
        /// <returns>MemberCard</returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-23
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        MemberCard SelectAllMemberCardByCardNo(string memberCardNo);


         /// <summary>
        /// ���ݿ��Ż�ȡ�ÿ����ѵ��ܽ��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��17:57:34
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        MemberCard SearchMemberCardConsumeAmount(long memberCardId); 

        /// <summary>
        /// �ж��ÿ��Ƿ����
        /// </summary>
        /// <param name="memberCardNo">��Ա����</param>
        /// <returns>int</returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-10
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        int SearchWheterMemberCardNo(string memberCardNo);
        /// <summary>
        /// ͨ��CustomerId����deleted
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: liuwei
        /// ����ʱ��: 2007-10-12
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void UpdateByCustomerId(long Id);

        /// ѡ�����°���Ļ�Ա��һ��
        /// </summary>
        /// <returns>Member</returns>
        /// <remarks>
        /// ��    ��: ���ٻ�
        /// ����ʱ��: 2007-10-13
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<MemberCard> SelectTodayNewMemberCard();

        /// <summary>
        /// ��ʱ�λ�ȡ����Ļ�Ա��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: �쾲��
        /// ����ʱ��: 2008-11-04
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<MemberCard> SelectSomeNewMemberCard(System.Collections.Hashtable condition);

        /// ͨ����Ա��ID���»�Ա�������ѽ��
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void UpdateMemberCardConsumeAmount(MemberCard memberCard);
        /// ��ѯ��Ա��ֵ��¼(MemberCard)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-23
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<MemberCard> SelectChargeRecord(System.Collections.Hashtable condition);
        /// ͨ����Ա���Ų�����ؿͻ���Ϣ
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-23
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        MemberCard SelectCustomerInfoByMemberCardNo(string memberCardNo);
        /// ��ѯ��Ա��������¼(MemberCard)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-24
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<MemberCard> SelectOperateLog(System.Collections.Hashtable condition);
        /// ��ѯ������¼
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-24
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<MemberCard> SelectChangeMemberCard(System.Collections.Hashtable condition);

        /// <summary>
        /// ���ݿ�Id�͹�ԱID���жϿ��ŵ�
        /// </summary>
        /// <param name="hashCondition"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2008-12-17
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<MemberCard> CheckMemberCardNo(Hashtable hashCondition);

        #region //��Ա����ͳ��
        /// <summary>
        /// ��Ա��������ͳ��
        /// </summary>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-27
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetMemberCardConsume(Order order);

        /// <summary>
        /// ��Ա��������ͳ�Ƽ�¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��10:53:10
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        long GetMemberCardConsumeRowCount(Order order);

        /// <summary>
        /// ��Ա��������ͳ��(��ӡ)
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��10:53:10
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        IList<Order> GetMemberCardConsumePrint(Order order);
        #endregion 

        /// <summary>
        /// ��    ��: SearchMemberById
        /// ���ܸ�Ҫ: ͨ��Id��ѯ��Ա��Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��12��11:35:57
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        MemberCard SearchMemberById(long Id);

        /// <summary>
        /// ��ȡ�û�Ա��Order�еļ�¼��
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��13��
        /// ��������: 
        /// ����ʱ��:
        /// </remarks>
        long SearchMemberCardIdInOrdersRowCount(string membercardId);

        /// <summary>
        /// ��    ��: DeleteMemberCardById
        /// ���ܸ�Ҫ: ͨ����ԱIdɾ����Ա
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��13��16:29:48
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        ///<param name="Id">��ԱId</param>
        void DeleteMemberCardById(long Id);

         #region //��Ա������¼

        /// <summary>
        ///��ȡ��Ա�������б�(��ҳ) 
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ�䣺2009��4��6��10:19:40
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<MemberCard> SearchOperateLog(Hashtable condition);

        /// <summary>
        ///��ȡ��Ա������¼��
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ�䣺2009��4��6��10:19:40
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        long SearchOperateLogRowCount(Hashtable condition);

        /// <summary>
        ///��ȡ��Ա������¼(��ӡ)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��     ��:������
        /// ����ʱ�䣺2009��4��6��10:19:40
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        IList<MemberCard> SearchOperateLogPrint(Hashtable condition);
        #endregion

        #region //��ȡ��Ա�μ��Żݵ�ҵ�����������б�
        /// <summary>
        /// ��ȡ��Ա�μ��Żݵ�ҵ�����������б�
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��15��13:54:16
        /// ��������:
        /// ����ʱ��:
        /// ��    ��:
        /// </remarks>
        IList<MemberCardConcession> GetMemberCardConcessionBaseBusniessInfo(long memberCardId); 
        #endregion

        #region //��Ա�����
        /// <summary>
        /// ��Ա�����
        /// </summary>
        /// <param name="memberCardBaseBusinessTypeItem"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��16��13:35:42
        /// ��������:
        /// ����ʱ��:
        /// ��    ��:
        /// </remarks>
        void MemberCardDiff(MemberCard.MemberCardBaseBusinessTypeItem memberCardBaseBusinessTypeItem);
        #endregion

        /// <summary>
        /// ��   ��:  UpdateMemberCardMarkingSetting
        /// ���ܸ�Ҫ: ���»�Ա����
        /// ��    ��: ������
        /// ����ʱ��: 2009��10��29��13:29:39
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        void UpdateMemberCardMarkingSetting(MemberCard memberCard);
    }
}
