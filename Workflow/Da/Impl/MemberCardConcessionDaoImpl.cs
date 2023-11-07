using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Support;
using Workflow.Da.Domain;
namespace Workflow.Da.Impl
{
	/// <summary>
    /// ��    �ƣ�MemberCardConcessionDaoImpl
    /// ���ܸ�Ҫ:��Ա����ֵDaoʵ����
    /// ��    �ߣ�
    /// ����ʱ��:
    /// ��������:
    /// ����ʱ��:
	/// </summary>
    public class MemberCardConcessionDaoImpl : Workflow.Da.Base.DaoBaseImpl<MemberCardConcession>, IMemberCardConcessionDao
    {
        #region �¿����滻ԭ����
        public void UpdateMemberCardId(System.Collections.Hashtable condition)
        {
            sqlMap.Update("MemberCardConcession.UpdateMemberCardId", condition);
        }
        #endregion

        #region //����ĳһ����Ա���µ��Żݻ
        /// <summary>
        /// ����ĳһ����Ա���µ��Żݻ
        /// </summary>
        /// <param name="orderId">condition</param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ��ǿ
        /// ����ʱ��: 2007-10-22
        /// ��������:
        /// ����ʱ��:
        /// </remarks>	
        public IList<MemberCardConcession> SelectMemberCardConcessionByPriceIdAndConcessionId(MemberCardConcession memberCardConcession)
        {
            return sqlMap.QueryForList<MemberCardConcession>("MemberCardConcession.SelectMemberCardConcession", memberCardConcession);
        }
        #endregion

        #region //��Ա�����ѡ�����ʣ��ӡ����
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
        public void UpdateMemberCardConcessionById(MemberCardConcession memberCardConcession)
        {
            sqlMap.Update("MemberCardConcession.UpdateMemberCardConcessionRestPaperCount", memberCardConcession);
        }
        #endregion

        #region ��ѯ��Ա��ֵ��Ϣ

        //public IList<MemberCardConcession> SelectChargeRecord(Hashtable condition)
        //{
        //    return sqlMap.QueryForList<MemberCardConcession>("MemberCardConcession.SelectChargeRecord", condition);
        //}

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
        public IList<MemberCardConcession> SearchChargeRecord(Hashtable condition) 
        {
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<MemberCardConcession>("MemberCard.SearchChargeRecord", condition);
        }

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
        public long SearchChargeRecordRowCount(Hashtable condition)
        {
            //condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            //condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForObject<long>("MemberCard.SearchChargeRecordRowCount", condition);
        }
        #endregion

		#region MyRegion
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
        public MemberCardConcession GetMemberCardConcession(MemberCardConcession memberCardConcession) 
        {
            Hashtable condition=new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("BaseBusinessTypePriceSetId", memberCardConcession.Id);//BaseBusinessTypePriceSetId
            condition.Add("MemberCardId", memberCardConcession.MemberCardId);
            return sqlMap.QueryForObject<MemberCardConcession>("MemberCardConcession.GetMemberCardConcession", condition);
        }
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
		public IList<MemberCardConcession> SelectValidMemberCardConcession(long memberCardId)
		{
			Hashtable map = new Hashtable();
			map.Add("memberCardId", memberCardId);
			map.Add("time", DateTime.Now);
			return sqlMap.QueryForList<MemberCardConcession>("MemberCardConcession.SelectValidMemberCardConcession", map);
		}

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
		public void UpdateRestPaperCount(long id, decimal count)
		{
			Hashtable map = new Hashtable();
			map.Add("id", id);
			map.Add("count", count);
			sqlMap.Update("MemberCardConcession.UpdateRestPaperCount", map);
		}

		#endregion
	}
}
