using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Da
{
	/// <summary>
	/// Table TAKE_WORK 对应的Dao 接口
	/// </summary>
    public interface ITakeWorkDao : IDaoBase<TakeWork>
    {
        /// <summary>
        /// 查询所有取活信息
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        IList<TakeWork> SearchTakeWork();
        /// <summary>
        /// 通过Id获取取活信息
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </remarks>	
        TakeWork SearchTakeWorkById(long Id);
    }
}
