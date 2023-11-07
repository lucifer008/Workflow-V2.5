using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Support;
using Workflow.Service.SystemPermission.PositionManage;
/// <summary>
/// 功能概要: 岗位 Action
/// 作    者: 陈汝胤
/// 创建时间: 2009-1-14
/// 修 正 人: 
/// 修正时间: 
/// 修正描述: 
/// </summary>

namespace Workflow.Action.Positions
{
    public class PositionAction
	{
		#region 类成员

		#region model
		
		private PositionModel model = new PositionModel();
        public PositionModel Model
        {
            get { return model; }
        }

		#endregion

		#region 注入 positionService
		private IPositionService positionService;
		/// <summary>
		/// 注入 positionService
		/// </summary>
		public IPositionService PositionService
		{
			set { positionService = value; }
		}
		#endregion

		#endregion

		#region 获取所有的岗位信息
		/// <summary>
        /// 获取所有的岗位信息
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		public void GetAllPositionList()
        {
			model.PositionList = positionService.GetAllPositionList();
        }
		#endregion

		#region 插入新的岗位
		/// <summary>
        /// 插入新的岗位
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		public void InsertPosition()
        {
			positionService.InsertPosition(model.Position);
        }	
		#endregion


		#region 删除岗位
		/// <summary>
        /// 删除岗位
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		public void DelPosition()
        {
			positionService.DeletePositionById(model.Id);
        }
		#endregion

		#region 通过岗位id获取岗位信息
		/// <summary>
        /// 通过岗位id获取岗位信息
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		public void GetPositionById()
        {
			model.Position = positionService.GetPositionById(model.Id);
			if (null != model.Position)
			{
				model.NameValue = model.Position.Name;
				model.MemoValue = model.Position.Memo;
			}
        }
		#endregion

		#region 更新岗位信息
		/// <summary>
        /// 更新岗位信息
        /// </summary>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-1-14
		public void UpdatePosition()
        {
			positionService.UpdatePosition(model.Position);
        }
		#endregion


		
    }
}
