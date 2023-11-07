using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table LINK_MAN 对应的Dao 实现
	/// </summary>
    public class LinkManDaoImpl : Workflow.Da.Base.DaoBaseImpl<LinkMan>, ILinkManDao
    {
        #region 合并客户中更改客户Id
        /// <summary>
        /// 合并客户:将被合并客户的联系人添加到新客户名称下
        /// </summary>
        /// <param name="linkman"></param>
        /// <remarks>
        ///  作    者：
        ///  创建时间:
        ///  修正履历:
        ///  修正时间:
        /// </remarks>
        public void UpdateConbinationCustomerId(System.Collections.Hashtable linkman)
        {
           sqlMap.Update("LinkMan.ConbinationUpdateCustomerId", linkman);
        }
        #endregion

        #region 通过CustomerId查询联系人数
        public int SelectLinkManCount(long Id)
        {
            object obj = sqlMap.QueryForObject("LinkMan.SelectLinkManCount", Id);

            return (int)obj;
        }
        #endregion

        #region 通过CustomerId查询联系人
        public IList<LinkMan> SelectLinkManByCustomerId(long Id)
        {
            return sqlMap.QueryForList<LinkMan>("LinkMan.SelectLinkManByCustomerId", Id);
        }
        #endregion

    }
}
