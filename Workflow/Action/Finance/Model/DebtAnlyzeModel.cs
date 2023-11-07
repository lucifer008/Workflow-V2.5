using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Workflow.Action.Finance
{
	public class DebtAnalyzeModel
	{
		#region 用户名称

		private string userName;
		/// <summary>
		/// 用户名称
		/// </summary>
		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}


		#endregion

		#region 经手人Id

		private long employeeId;
		/// <summary>
		/// 经手人Id
		/// </summary>
		public long EmployeeId
		{
			get { return employeeId; }
			set { employeeId = value; }
		}


		#endregion

		#region 需要分析的日期段

		private IList<AnalyzeTime> analyzeTimes;
		/// <summary>
		/// 需要分析的日期段
		/// </summary>
		public IList<AnalyzeTime> AnalyzeTimes
		{
			get {
				if (analyzeTimes == null)
					analyzeTimes = new List<AnalyzeTime>();
				return analyzeTimes;
				}
			set { analyzeTimes = value; }
		}

		#endregion

		#region 帐龄分析结果

		private Hashtable map;
		/// <summary>
		/// 帐龄分析结果
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

		#region 帐龄总和

		private decimal[] resultSum;
		/// <summary>
		/// 帐龄总和
		/// </summary>
		public decimal[] ResultSum
		{
			get
			{
				if (resultSum == null)
					resultSum = new decimal[7];
				return resultSum;
			}
			set { resultSum = value; }
		}

		#endregion
	}
	/// <summary>
	/// 分析的日期段
	/// </summary>
	public class AnalyzeTime
	{
		#region 开始时间

		private DateTime beginTime;
		/// <summary>
		/// 开始时间
		/// </summary>
		public DateTime BeginTime
		{
			get { return beginTime; }
			set { beginTime = value; }
		}

		#endregion

		#region 结束时间

		private DateTime endTime;
		/// <summary>
		/// 结束时间
		/// </summary>
		public DateTime EndTime
		{
			get { return endTime; }
			set { endTime = value; }
		}
	
		#endregion
	}

	public class AnalyzeData
	{

		#region 客户名

		private string customerName;
		/// <summary>
		/// 客户名
		/// </summary>
		public string CustomerName
		{
			get { return customerName; }
			set { customerName = value; }
		}

		#endregion

		#region 帐龄统计

		private decimal[] result;
		/// <summary>
		/// 帐龄统计
		/// </summary>
		public decimal[] Result
		{
			get
			{
				if (result == null)
					result = new decimal[7];
				return result;
			}
			set { result = value; }
		}

		#endregion

	}
}
