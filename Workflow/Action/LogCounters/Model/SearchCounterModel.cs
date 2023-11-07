using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;
/// <summary>
/// 名    称：SearchCounterModel
/// 功能概要: 计数器查询Model
/// 作    者: 陈汝胤
/// 创建时间: 2009.12.23
/// </summary>
namespace Workflow.Action.LogCounters
{
	public class SearchCounterModel
	{
		#region 抄表记录

		private IList<RecordMachineWatch> recordMachineWatchs;
		/// <summary>
		/// 抄表记录
		/// </summary>
		public IList<RecordMachineWatch> RecordMachineWatchs
		{
			get {
					if (recordMachineWatchs == null)
						recordMachineWatchs = new List<RecordMachineWatch>();
					return recordMachineWatchs;
				}
			set { recordMachineWatchs = value; }
		}

		#endregion

		#region 抄表记录数的总数量

		private int recordCount;
		//抄表记录数的总数量
		public int RecordCount
		{
			get { return recordCount; }
			set { recordCount = value; }
		}

		#endregion

		#region 开始时间

		private string beginDate;
		/// <summary>
		/// 开始时间
		/// </summary>
		public string BeginDate
		{
			get { return beginDate; }
			set { beginDate = value; }
		}

		#endregion

		#region 结束时间

		private string endDate;
		/// <summary>
		/// 结束时间
		/// </summary>
		public string EndDate
		{
			get { return endDate; }
			set { endDate = value; }
		}

		#endregion

		#region 开始行

		private int beginRow;
		/// <summary>
		/// 开始行
		/// </summary>
		public int BeginRow
		{
			get { return beginRow; }
			set { beginRow = value; }
		}

		#endregion

		#region 结束行

		private int endRow;
		/// <summary>
		/// 结束行
		/// </summary>
		public int EndRow
		{
			get { return endRow; }
			set { endRow = value; }
		}

		#endregion

		#region 抄表id

		private long recordMachineWatchId;
		/// <summary>
		/// 抄表id
		/// </summary>
		public long RecordMachineWatchId
		{
			get { return recordMachineWatchId; }
			set { recordMachineWatchId = value; }
		}

		#endregion

		#region 查表结果

		private IList<DailyRecordMachine> dailyRecordMachines;
		/// <summary>
		/// 查表结果
		/// </summary>
		public IList<DailyRecordMachine> DailyRecordMachines
		{
			get { return dailyRecordMachines; }
			set { dailyRecordMachines = value; }
		}

		#endregion

		#region 查找结果合并

		private Hashtable map;
		/// <summary>
		/// 查找结果合并
		/// </summary>
		public Hashtable Map
		{
			get
			{
				if (map == null)
					map = new Hashtable();
				return map;
			}
			set { map = value; }
		}


		#endregion
	}
	public class DataUnite
	{
		#region 合并数量

		private int uniteCount;

		public int UniteCount
		{
			get { return uniteCount; }
			set { uniteCount = value; }
		}

		#endregion

		#region 总数量

		private decimal amount;
		/// <summary>
		/// 总数量
		/// </summary>
		public decimal Amount
		{
			get { return amount; }
			set { amount = value; }
		}

		#endregion
	}
}
