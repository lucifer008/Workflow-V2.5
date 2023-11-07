using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;

namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// 名    称: ITakeWorkService
    /// 功能概要: 上门取活的Service接口
    /// 作    者: liuwei
    /// 创建时间: 2007-10-9
    /// 修 正 人: 付强
    /// 修正时间: 2009-1-22
    /// 描    述: 代码整理
    /// </summary>
    public  interface ITakeWorkService
    {
        #region 取活的基本操作
        /// <summary>
        /// 名    称: InsertTakeWord
        /// 功能概要: 插入取活信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param>取活实例</param>
        void InsertTakeWord(TakeWork takeWork);
        /// <summary>
        /// 名    称: DeleteTakeWork
        /// 功能概要: 删除取活
        /// 作    者: liuwei
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">取活Id</param>
        void DeleteTakeWork(long Id);
        /// <summary>
        /// 名    称: UpdateTakeWork
        /// 功能概要: 更新取活信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="takeWork">取活实例</param>
        void UpdateTakeWork(TakeWork takeWork);
        #endregion

        #region 查询取活
        /// <summary>
        /// 名    称: SearchTakeWorkById
        /// 功能概要: 通过Id获取取活信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param>取活Id</param>
        /// <returns>一个取活实例</returns>
        TakeWork SearchTakeWorkById(long Id);
        /// <summary>
        /// 名    称: SearchTakeWork
        /// 功能概要: 查询所有取活信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns>取活列表</returns>
        IList<TakeWork> SearchTakeWork();
        /// <summary>
        /// 名    称: SearchAllEmployee
        /// 功能概要: 获取所有员工
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        /// <returns>雇员列表</returns>
        IList<Employee> SearchAllEmployee();
        #endregion
    }
}
