using System;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
using System.Collections.Generic;
using Workflow.Support;

/// <summary>
/// 名    称: CopyCounter
/// 功能概要: 抄表处理Model
/// 作    者: 陈汝胤
/// 创建时间: 2009-2-10 - 2009-2-11
/// </summary>
namespace Workflow.Action.LogCounters
{
	public class CopyCounterModel
	{
		#region  抄表相关数据
		private IList<MachineType> machineTypeList;
		/// <summary>
		/// 抄表相关数据
		/// </summary>
		public IList<MachineType> MachineTypeList
		{
			get { return machineTypeList; }
			set { machineTypeList = value; }
		}
		#endregion

		#region 未完工订单

		private IList<UncompleteOrdersUsedPaper> uncompleteOrderList;
		/// <summary>
		/// 未完工订单
		/// </summary>
		public IList<UncompleteOrdersUsedPaper> UncompleteOrderList
		{
			get { return uncompleteOrderList; }
			set { uncompleteOrderList = value; }
		}

		#endregion

		#region recordMachineWatchId

		private string recordMachineWatchId;
		/// <summary>
		/// 抄表id
		/// </summary>
		public string RecordMachineWatchId
		{
			get {
				if (null == recordMachineWatchId)
					return "";
				return recordMachineWatchId; }
			set { recordMachineWatchId = value; }
		}

		#endregion

		#region uncompleteOrderId

		private string uncompleteOrderId;
		/// <summary>
		/// 未完工订单id
		/// </summary>
		public string UncompleteOrderId
		{
			get { return uncompleteOrderId; }
			set { uncompleteOrderId = value; }
		}

		#endregion

		#region 抄表信息

		private IList<string[]> recordWathInfoList;
		/// <summary>
		/// 抄表信息
		/// </summary>
		public IList<string[]> RecordWathInfoList
		{
			get { if(null==recordWathInfoList)
					recordWathInfoList= new List<string[]>();
				  return recordWathInfoList;
				}
			set { recordWathInfoList = value; }
		}

		#endregion

		#region 当前登记人

		private User register;
		/// <summary>
		/// 当前登记人
		/// </summary>
		public User Register
		{
			get {
				if (null == register)
					register = ThreadLocalUtils.CurrentUserContext.CurrentUser;
				return register;
			}
			set { register = value; }
		}

		#endregion

		#region 所有用户

		private IList<User> userList;
		/// <summary>
		/// 所有用户
		/// </summary>
		public IList<User> UserList
		{
			get { return userList; }
			set { userList = value; }
		}

		#endregion

		#region 抄表的第1次初始化

		private int init;
		/// <summary>
		/// 抄表的第1次初始化
		/// </summary>
		public int Init
		{
			get { return init; }
			set { init = value; }
		}


		#endregion
	}
}
