using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;

namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table CASH_HAND_OVER 对应的Dao 实现
	/// </summary>
    public class CashHandOverDaoImpl : Workflow.Da.Base.DaoBaseImpl<CashHandOver>, ICashHandOverDao
    {
        #region //通过交班单ID获得收银交班信息
        ///// <summary>
        ///// 通过交班单ID获得收银交班信息
        ///// </summary>
        ///// <param name="handOver"></param>
        ///// <returns></returns>
        ///// <remarks>
        ///// 作    者: 麻少华
        ///// 创建时间: 2007-10-11
        ///// 修正履历: 
        ///// 修正时间:
        ///// </remarks>
        //public CashHandOver SelectByHandOverId(long id)
        //{
        //    return sqlMap.QueryForObject <CashHandOver>("CashHandOver.SelectByHandOverId", id);
        //}
        #endregion
    }
}
