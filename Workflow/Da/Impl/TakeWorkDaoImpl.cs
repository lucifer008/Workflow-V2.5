using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table TAKE_WORK 对应的Dao 实现
	/// </summary>
    public class TakeWorkDaoImpl : Workflow.Da.Base.DaoBaseImpl<TakeWork>, ITakeWorkDao
    {
        #region 查询所有取活
        public IList<TakeWork> SearchTakeWork()
        {
            return sqlMap.QueryForList<TakeWork>("TakeWork.SelectTakeWorkInfo", null);
        }
        #endregion

        #region 通过Id查询取活信息
        public TakeWork SearchTakeWorkById(long Id)
        {
            IList<TakeWork> takeWorkList = sqlMap.QueryForList<TakeWork>("TakeWork.SelectTakeWorkById", Id);
            TakeWork takeWork = takeWorkList[0];

            return takeWork;
        }
        #endregion
    }
}
