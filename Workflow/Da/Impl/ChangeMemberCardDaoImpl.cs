using System;
using System.Collections;
using System.Collections.Generic;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
    /// ��    �ƣ�ChangeMemberCardDaoImpl
    /// ���ܸ�Ҫ:IChangeMemberCardDao�ӿ�ʵ��
    /// ��    ��:
    /// ����ʱ��:
    /// ����������
    /// ����ʱ��:
	/// </summary>
    public class ChangeMemberCardDaoImpl : Workflow.Da.Base.DaoBaseImpl<ChangeMemberCard>, IChangeMemberCardDao
    {
        #region //��ѯ������¼
        //public IList<ChangeMemberCard> SelectChangMemberCard(System.Collections.Hashtable condition)
        //{
        //    return sqlMap.QueryForList<ChangeMemberCard>("ChangeMemberCard.SelectChageMemberCard", condition);
        //}

        /// <summary>
        /// ��ѯ��Ա���Ῠ��¼
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��2��10:24:42
        /// ��������:
        /// ����ʱ��: 
        ///</remarks>
        public IList<ChangeMemberCard> SearchChangeMemberCard(Hashtable condition)
        {
            condition.Add("CompanyId",ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<ChangeMemberCard>("ChangeMemberCard.SearchChangeMemberCard", condition);
        }

        /// <summary>
        /// ��ѯ��Ա���Ῠ��¼��
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��2��10:24:42
        /// ��������:
        /// ����ʱ��: 
        ///</remarks>
        public long SearchChangeMemberCardRowCount(Hashtable condition) 
        {
            return sqlMap.QueryForObject<long>("ChangeMemberCard.SearchChangeMemberCardRowCount", condition);
        }

        /// <summary>
        /// ��ѯ��Ա���Ῠ��¼(��ӡ)
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        /// <remarks>
        /// ��    ��: ������
        /// ����ʱ��: 2009��4��2��10:24:42
        /// ��������:
        /// ����ʱ��: 
        ///</remarks>
        public IList<ChangeMemberCard> SearchChangeMemberCardPrint(Hashtable condition) 
        {
            return sqlMap.QueryForList<ChangeMemberCard>("ChangeMemberCard.SearchChangeMemberCardPrint", condition);
        }
        #endregion
    }
}
