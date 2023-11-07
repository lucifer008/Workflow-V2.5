using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table CHANGE_MEMBER_CARD ��Ӧ��Dao �ӿ�
	/// </summary>
    public interface IChangeMemberCardDao : IDaoBase<ChangeMemberCard>
    {
        ///// <summary>
        ///// ��ѯ������¼
        ///// </summary>
        ///// <param name="condition"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// ��    ��: liuwei
        ///// ����ʱ��: 2007-10-24
        ///// ��������:
        ///// ����ʱ��:
        ///// </remarks>
        //IList<ChangeMemberCard> SelectChangMemberCard(System.Collections.Hashtable condition);

        #region //��Ա��������¼
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
        IList<ChangeMemberCard> SearchChangeMemberCard(Hashtable condition);


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
        long SearchChangeMemberCardRowCount(Hashtable condition);

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
        IList<ChangeMemberCard> SearchChangeMemberCardPrint(Hashtable condition);
        #endregion
    }
}
