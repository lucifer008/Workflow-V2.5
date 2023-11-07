using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;
using Workflow.Da;
/// <summary>
/// 功能概要: 岗位 Service 实现
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-14
/// 修 正 人: 
/// 修正时间: 
/// 修正描述: 
/// </summary>

namespace Workflow.Service.SystemPermission.PositionManage
{
	public class PositionServiceImpl : IPositionService
	{
		#region 类成员

		#region 注入 positionDao
		private IPositionDao positionDao;
		/// <summary>
		/// 注入 positionDao
		/// </summary>
		public IPositionDao PositionDao
		{
			set { positionDao = value; }
		}
		#endregion
		

		#endregion

		#region 获取全部的职位信息

		/// <summary>
		/// 获取全部岗位
		/// </summary>
		/// <returns>岗位列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		/// </remarks>
		public IList<Position> GetAllPositionList()
		{
			return positionDao.SelectAll();
		}
		
		#endregion

		#region 插入岗位信息

		/// <summary>
		/// 插入岗位信息
		/// </summary>
		/// <param name="position">岗位</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		/// </remarks>
		public void InsertPosition(Position position)
		{
			positionDao.Insert(position);
		}

		#endregion

		#region 删除岗位

		/// <summary>
		/// 删除岗位
		/// </summary>
		/// <param name="positionId">岗位Id</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		public void DeletePositionById(long positionId)
		{
			positionDao.Delete(positionId);
		}

		#endregion

		#region 通过岗位id获取岗位信息

		/// <summary>
		/// 通过岗位id获取岗位信息
		/// </summary>
		/// <param name="positionId">岗位Id</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		public Position GetPositionById(long positionId)
		{
			return positionDao.SelectByPk(positionId);
		}

		#endregion

		#region 更新岗位信息

		/// <summary>
		/// 更新岗位信息
		/// </summary>
		/// <param name="position">岗位</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		public void UpdatePosition(Position position)
		{
			positionDao.Update(position);
		}

		#endregion

        #region //根据岗位获取雇员信息
        /// <summary>
        /// 根据岗位获取雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月26日10:39:43
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Employee> GetEmployeeListByPositionId(Hashtable condition) 
        {
           return positionDao.GetEmployeeListByPositionId(condition);
        }
        #endregion
    }
}
