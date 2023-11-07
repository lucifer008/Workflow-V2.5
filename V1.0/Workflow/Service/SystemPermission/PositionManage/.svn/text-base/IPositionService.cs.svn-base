using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Workflow.Da.Domain;
/// <summary>
/// 功能概要: 岗位 Service 接口
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-14
/// 修 正 人: 
/// 修正时间: 
/// 修正描述: 
/// </summary>

namespace Workflow.Service.SystemPermission.PositionManage
{
	public interface IPositionService
	{
		#region 获取全部岗位
		
		/// <summary>
		/// 获取全部岗位
		/// </summary>
		/// <returns>岗位列表</returns>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		IList<Position> GetAllPositionList();

		#endregion

		#region 插入岗位信息

		/// <summary>
		/// 插入岗位信息
		/// </summary>
		/// <param name="position">岗位</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		void InsertPosition(Position position);

		#endregion

		#region 删除岗位

		/// <summary>
		/// 删除岗位
		/// </summary>
		/// <param name="positionId">岗位Id</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		void DeletePositionById(long positionId);
		
		#endregion

		#region 通过岗位id获取岗位信息

		/// <summary>
		/// 通过岗位id获取岗位信息
		/// </summary>
		/// <param name="positionId">岗位Id</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		Position GetPositionById(long positionId);

		#endregion

		#region 更新岗位信息

		/// <summary>
		/// 更新岗位信息
		/// </summary>
		/// <param name="position">岗位</param>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		void UpdatePosition(Position position);

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
        IList<Employee> GetEmployeeListByPositionId(Hashtable condition);
        #endregion
    }
}
