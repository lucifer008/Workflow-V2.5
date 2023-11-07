using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MEMBER_CARD_CONCESSION ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IMemberCardConcessionDao : IDaoBase<MemberCardConcession>
	{
		#region MyRegion
		/// <summary>
        /// �¿����滻ԭ����
        /// </summary>
        /// <param name="orderId">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ΰ
        /// ����ʱ��: 2007-10-7
        /// ��������:
        /// ����ʱ��:
        /// </remarks>	

        void UpdateMemberCardId(System.Collections.Hashtable condition);
        /// <summary>
        /// ����ĳһ����Ա���µ��Żݻ
        /// </summary>
        /// <param name="memberCardConcession">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </remarks>	
        IList<MemberCardConcession> SelectMemberCardConcessionByPriceIdAndConcessionId(MemberCardConcession memberCardConcession);
        /// <summary>
        /// ��Ա�����ѡ�����ʣ��ӡ����
        /// </summary>
        /// <param name="memberCardConcession">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </remarks>	
        void UpdateMemberCardConcessionById(MemberCardConcession memberCardConcession);

        ///// <summary>
        ///// ��ѯ��Ա��ֵ��¼
        ///// </summary>
        ///// <param>condition</param>
        ///// <returns></returns>
        ///// <remarks>
        ///// ��    ��: ��ΰ
        ///// ����ʱ��: 2007-10-23
        ///// ��������:
        ///// ����ʱ��:
        ///// </remarks>	
        //IList<MemberCardConcession> SelectChargeRecord(System.Collections.Hashtable condition);

        /// <summary>
        /// ��ѯ��Ա����ֵ��¼
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��11:39:40
        /// ��������:
        /// ����ʱ��:
        /// 
        IList<MemberCardConcession> SearchChargeRecord(Hashtable condition);

        /// <summary>
        /// ��ѯ��Ա����ֵ��¼��
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��3��11:39:40
        /// ��������:
        /// ����ʱ��:
        /// 
        long SearchChargeRecordRowCount(Hashtable condition);


        /// <summary>
        /// ��ȡƥ��Ļ�Ա�μ��Ż���Ϣ
        /// </summary>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��17��14:56:27
        /// ��������:
        /// ����ʱ��:
        /// ��    ��:
        /// </remarks>
        MemberCardConcession GetMemberCardConcession(MemberCardConcession memberCardConcession);
		#endregion

		#region ��ȡ��Ч�Ļ�Ա���μӵ��Żݻͨ����Ա��id

		/// <summary>
		/// ��ȡ��Ч�Ļ�Ա���μӵ��Żݻͨ����Ա��id
		/// </summary>
		/// <param name="memberCardId">��Ա��id</param>
		/// <returns>��Ա���μӵ��Żݻ�б�</returns>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.19
		/// </remarks>
		IList<MemberCardConcession> SelectValidMemberCardConcession(long memberCardId);

		#endregion

		#region ʹ��ָ�����,����ʣ������

		/// <summary>
		/// ʹ��ָ�����,����ʣ������
		/// </summary>
		/// <param name="id">�id</param>
		/// <param name="count">�������</param>
		/// <remarks>
		/// ��    ��: ����ط
		/// ����ʱ��: 2009.5.26
		/// </remarks>
		void UpdateRestPaperCount(long id, decimal count);

		#endregion

		
	}
}