using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MEMBER_OPERATE_LOG 对应的Dao 实现
	/// </summary>
    public class MemberOperateLogDaoImpl : Workflow.Da.Base.DaoBaseImpl<MemberOperateLog>, IMemberOperateLogDao
    {
        #region 查询会员操作纪录
        public IList<MemberOperateLog> SelectOperateLog(System.Collections.Hashtable condition)
        {
            return sqlMap.QueryForList<MemberOperateLog>("MemberOperateLog.SelectOperateLog", condition);
        }
        #endregion
    }
}
