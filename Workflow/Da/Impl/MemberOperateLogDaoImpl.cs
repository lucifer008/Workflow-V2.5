using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table MEMBER_OPERATE_LOG ��Ӧ��Dao ʵ��
	/// </summary>
    public class MemberOperateLogDaoImpl : Workflow.Da.Base.DaoBaseImpl<MemberOperateLog>, IMemberOperateLogDao
    {
        #region ��ѯ��Ա������¼
        public IList<MemberOperateLog> SelectOperateLog(System.Collections.Hashtable condition)
        {
            return sqlMap.QueryForList<MemberOperateLog>("MemberOperateLog.SelectOperateLog", condition);
        }
        #endregion
    }
}
