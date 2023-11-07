#region imports
using System;
using Workflow.Da.Domain.Base;
#endregion

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table ORDER_TIMEOUT_ALARM_RECORD (订单超时记录) 对应的DotNet Object 实体类
	/// </summary>
	[Serializable]
	public class OrderTimeoutAlarmRecord : OrderTimeoutAlarmRecordBase
	{
		public OrderTimeoutAlarmRecord()
		{
		}
	}
}