using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table LINK_MAN ��Ӧ��Dao ʵ��
	/// </summary>
    public class LinkManDaoImpl : Workflow.Da.Base.DaoBaseImpl<LinkMan>, ILinkManDao
    {
        #region �ϲ��ͻ��и��Ŀͻ�Id
        /// <summary>
        /// �ϲ��ͻ�:�����ϲ��ͻ�����ϵ����ӵ��¿ͻ�������
        /// </summary>
        /// <param name="linkman"></param>
        /// <remarks>
        ///  ��    �ߣ�
        ///  ����ʱ��:
        ///  ��������:
        ///  ����ʱ��:
        /// </remarks>
        public void UpdateConbinationCustomerId(System.Collections.Hashtable linkman)
        {
           sqlMap.Update("LinkMan.ConbinationUpdateCustomerId", linkman);
        }
        #endregion

        #region ͨ��CustomerId��ѯ��ϵ����
        public int SelectLinkManCount(long Id)
        {
            object obj = sqlMap.QueryForObject("LinkMan.SelectLinkManCount", Id);

            return (int)obj;
        }
        #endregion

        #region ͨ��CustomerId��ѯ��ϵ��
        public IList<LinkMan> SelectLinkManByCustomerId(long Id)
        {
            return sqlMap.QueryForList<LinkMan>("LinkMan.SelectLinkManByCustomerId", Id);
        }
        #endregion

    }
}
