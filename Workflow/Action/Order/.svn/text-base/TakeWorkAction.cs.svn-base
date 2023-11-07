using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.OrderManage;

namespace Workflow.Action
{
    /// <summary>
    /// 名    称: TakeWorkAction
    /// 功能概要: 上门取活的Action
    /// 作    者: liuwei
    /// 创建时间: 2007-10-9
    /// 修 正 人: 付强
    /// 修正时间: 2009-1-22
    /// 描    述: 代码整理
    /// </summary>
    public class TakeWorkAction
    {
        #region 类成员
        private TakeWorkModel model = new TakeWorkModel();
        public TakeWorkModel Model
        {
            get{ return model;}
        }
        private ITakeWorkService takeWorkService;
        public ITakeWorkService TakeWorkService
        {
            set { takeWorkService = value; }
        }
        #endregion

        #region 取活的基本操作
        /// <summary>
        /// 名    称: InsertTakeWork
        /// 功能概要: 插入客户信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        public void InsertTakeWork()
        {
            takeWorkService.InsertTakeWord(model.TakeWork);
        }
        /// <summary>
        /// 名    称: DeleteTakeWork
        /// 功能概要: 删除取活
        /// 作    者: liuwei
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        public void DeleteTakeWork()
        {
            takeWorkService.DeleteTakeWork(model.Id);
        }
        /// <summary>
        /// 名    称: UpdateTakeWork
        /// 功能概要: 更新取活信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        public void UpdateTakeWork()
        {
            takeWorkService.UpdateTakeWork(model.TakeWork);
        }
        #endregion

        #region 查询取活
        /// <summary>
        /// 名    称: SearchTakeWork
        /// 功能概要: 查询所有取活信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-9
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        public void SearchTakeWork()
        {
            model.TakeWorkList = takeWorkService.SearchTakeWork();
        }
        /// <summary>
        /// 名    称: SearchTakeWorkById
        /// 功能概要: 通过Id获取取活信息
        /// 作    者: liuwei
        /// 创建时间: 2007-10-10
        /// 修正履历:
        /// 修正时间:
        /// </summary>
        /// <param></param>
        public void SearchTakeWorkById()
        {
            model.TakeWork = takeWorkService.SearchTakeWorkById(model.Id);
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
        public void SearchAllEmployee()
        {
            model.EmployeeList = takeWorkService.SearchAllEmployee();
        }
        #endregion
    }
}
