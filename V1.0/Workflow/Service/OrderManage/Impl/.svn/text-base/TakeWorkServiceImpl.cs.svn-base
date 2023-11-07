using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da;
using Workflow.Da.Domain;
using Spring.Transaction.Interceptor;

namespace Workflow.Service.OrderManage
{
    /// <summary>
    /// 名    称: TakeWorkServiceImpl
    /// 功能概要: 上门取活的Service实现
    /// 作    者: liuwei
    /// 创建时间: 2007-10-9
    /// 修 正 人: 付强
    /// 修正时间: 2009-1-22
    /// 描    述: 代码整理
    /// </summary>
    public  class TakeWorkServiceImpl:ITakeWorkService
    {
        #region 类成员
        private ITakeWorkDao takeWorkDao;
        public ITakeWorkDao TakeWorkDao
        {
            get { return takeWorkDao; }
            set { takeWorkDao = value; }
        }
        private IEmployeeDao employeeDao;
        public IEmployeeDao EmployeeDao
        {
            get { return employeeDao; }
            set { employeeDao = value; }
        }
        #endregion

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
        [Transaction]
        public void InsertTakeWord(TakeWork takeWork)
        {
            takeWorkDao.Insert(takeWork);
        }
        /// <summary>
        /// 名    称: DeleteTakeWork
        /// 功能概要: 删除取活
        /// 作    者: liuwei
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="Id">取活Id</param>
        [Transaction]
        public void DeleteTakeWork(long Id)
        {
            takeWorkDao.Delete(Id);
        }
        /// <summary>
        /// 名    称: UpdateTakeWork
        /// 功能概要: 更新取活信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param name="takeWork">取活实例</param>
        [Transaction]
        public void UpdateTakeWork(TakeWork takeWork)
        {
            takeWorkDao.Update(takeWork);
        }
        #endregion

        #region 取活查询
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
        public TakeWork SearchTakeWorkById(long Id)
        {
            return takeWorkDao.SearchTakeWorkById(Id);
        }
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
        public IList<TakeWork> SearchTakeWork()
        {
            return takeWorkDao.SearchTakeWork();
        }
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
        public IList<Employee> SearchAllEmployee()
        {
            return employeeDao.SelectAll();
        }
        #endregion

    }
}
