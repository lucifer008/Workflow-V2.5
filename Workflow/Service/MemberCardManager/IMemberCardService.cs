using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da;
using Workflow.Da.Domain;
using System.Collections;
namespace Workflow.Service
{
    /// <summary>
    /// ��    ��: IMemberCardService
    /// ���ܸ�Ҫ: ��Ա��������Service�ӿ�
    /// ��    ��: ������
    /// ����ʱ��: 2009-1-19
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    public interface IMemberCardService
    {

        /// <summary>
        /// ��    ��: InsertMemberCard
        /// ���ܸ�Ҫ: �����Ա��
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-9-30
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="memberCard">��Ա��Ϣ</param>
        /// <param name="customer">��Ա�����Ŀͻ���Ϣ</param>
        /// <param name="memberOperateLog">��Ա��������¼</param>
        void InsertMemberCard(MemberCard memberCard, Customer customer, MemberOperateLog memberOperateLog);

        /// <summary>
        /// ��    ��: UpdateMemberCard
        /// ���ܸ�Ҫ: �޸Ļ�Ա����Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2009��2��13��
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="memberCard">��Ա��Ϣ</param>
        /// <param name="customer">��Ա�����ͻ���Ϣ</param>
        /// <param name="memberOperateLog">��Ա��������¼</param>
        void UpdateMemberCard(MemberCard memberCard,Customer customer,MemberOperateLog memberOperateLog);
       
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="orderId">Id,NewMemberCardNo,PassWord</param>
        /// <returns</returns>
        /// <remarks>
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-7
        /// ��������:
        /// ����ʱ��:
        /// </remarks>	
        void RepairNewMemberCard(ChangeMemberCard changeMemberCard, string PassWord, long Id, MemberOperateLog memberOperateLog);
       
        ///// <summary>
        ///// ��Ա����ֵ
        ///// </summary>
        ///// <param name="campaign">��ֵ��Ϣ</param>
        ///// <returns</returns>
        ///// <remarks>
        ///// ��    ��: ��ΰ
        ///// ����ʱ��: 2007-10-8
        ///// ��������:
        ///// ����ʱ��:
        ///// </remarks>	
        //void InsertCampaignMemberCard(MemberCardConcession memberCardConcession);


        /// <summary>
        /// ��Ա��ֵ
        /// </summary>
        /// <param name="memberCardConcession" name="ChargeSum"></param>
        /// <remarks>
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-22
        /// ��������: ����ط
        /// ����ʱ��: 2009.5.14
		/// ��������: ���������޸�
        /// </remarks>
		void InsertConcessionMemberCard(MemberCardConcession memberCardConcession, MemberCardConcessionGathering memberCardConcessionGathering,OtherGatheringAndRefundmentRecord ogr);
   


        ///// <summary>
        ///// �����Ա��������¼
        ///// </summary>
        ///// <param name="memberOperateLog"></param>
        ///// <remarks>
        ///// ��    ��: ������
        ///// ����ʱ��: 2008-12-18
        ///// ��������:
        ///// ����ʱ��:
        ///// </remarks>
        //void InsertMemberOprateLog(MemberOperateLog memberOperateLog);

        /// <summary>
        /// ���ݻ�Ա��Id���»�Ա����״̬Ϊ����(Member_State=1)
        /// </summary>
        /// <param name="memberOperateLog"></param>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2008-12-18
        /// ��������:
        /// ����ʱ��:
        /// </remarks>
        void UpdateMemberCard(MemberCard memberCard);

        /// <summary>
        /// ����ע����Ϣ
        /// </summary>
        /// <param name="orderId">LogoffMemberCard</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-6
        /// ��������:
        /// ����ʱ��:
        /// </remarks>

        void InsertLogoffMemberCard(LogoffMemberCard logoffMemberCard,MemberOperateLog memberOperateLog);

        /// <summary>
        /// ��    ��: InsertReprotLossMemberCard
        /// ���ܸ�Ҫ: �����ʧ��Ϣ
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-5
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        void InsertReprotLossMemberCard(ReportLossMemberCard reportLossMemberCard, MemberOperateLog memberOperateLog);

        /// <summary>
        /// ��    ��: DeleteByMemberCardId
        /// ���ܸ�Ҫ: ��Ա���ָ�
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-6
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        void DeleteByMemberCardId(long Id,MemberOperateLog memberOperateLog);

        /// <summary>
        /// ��    ��: InsertMemberOperateLong
        /// ���ܸ�Ҫ: ����Ի�Ա���Ĳ�����Ϣ
        /// ��    ��: ������
        /// ����ʱ��: 2008-12-25
        /// ��������:
        /// ����ʱ��:
        /// </summary>
        /// <param name="memberOperateLog"></param>
        void InsertMemberOperateLong(MemberOperateLog memberOperateLog);

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

		#region ��Ա�����ۻ��ֵ

		/// <summary>
		/// ��Ա�����ۻ��ֵ
		/// </summary>
		/// <param name="memberCardDiscountConcession">��Ա���μӵĴ����Żݻ</param>
		/// <param name="memberCardConcessionGathering">��Ա���μ��Żݻ�ĸ����¼</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.14
		/// </remarks>
		void InsertDiscountConcessionMemberCard(MemberCardDiscountConcession memberCardDiscountConcession, MemberCardConcessionGathering memberCardConcessionGathering,OtherGatheringAndRefundmentRecord ogr);

		#endregion
		
	}
}
