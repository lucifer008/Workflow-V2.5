using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table MEMBER_OPERATE_LOG 对应的Dao 接口
	/// </summary>
    public interface IMemberOperateLogDao : IDaoBase<MemberOperateLog>
    {
        /// 查询会员卡操作记录(MemberCard)
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 刘伟
        /// 创建时间: 2007-10-24
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<MemberOperateLog> SelectOperateLog(System.Collections.Hashtable condition);
    }
}
