using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table LINK_MAN 对应的Dao 接口
	/// </summary>
    public interface ILinkManDao : IDaoBase<LinkMan>
    {
        /// <summary>
        /// 合并客户时更改客户Id
        /// </summary>
        /// <param name="linkman">HashTable</param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-9-29
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        void UpdateConbinationCustomerId(System.Collections.Hashtable linkman);
        /// <summary>
        /// 通过CustomerId查询联系人数
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns>int</returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        int SelectLinkManCount(long Id);
        /// <summary>
        /// 通过CustomerId查询联系人
        /// </summary>
        /// <param name="Id">CustomerId</param>
        /// <returns>int</returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-15
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<LinkMan> SelectLinkManByCustomerId(long Id);
    }
}
