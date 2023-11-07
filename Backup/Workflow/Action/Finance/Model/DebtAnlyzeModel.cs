using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace Workflow.Action.Finance
{
	public class DebtAnalyzeModel
	{
		#region �û�����

		private string userName;
		/// <summary>
		/// �û�����
		/// </summary>
		public string UserName
		{
			get { return userName; }
			set { userName = value; }
		}


		#endregion

		#region ������Id

		private long employeeId;
		/// <summary>
		/// ������Id
		/// </summary>
		public long EmployeeId
		{
			get { return employeeId; }
			set { employeeId = value; }
		}


		#endregion

		#region ��Ҫ���������ڶ�

		private IList<AnalyzeTime> analyzeTimes;
		/// <summary>
		/// ��Ҫ���������ڶ�
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

		#region ����������

		private Hashtable map;
		/// <summary>
		/// ����������
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

		#region �����ܺ�

		private decimal[] resultSum;
		/// <summary>
		/// �����ܺ�
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
	/// ���������ڶ�
	/// </summary>
	public class AnalyzeTime
	{
		#region ��ʼʱ��

		private DateTime beginTime;
		/// <summary>
		/// ��ʼʱ��
		/// </summary>
		public DateTime BeginTime
		{
			get { return beginTime; }
			set { beginTime = value; }
		}

		#endregion

		#region ����ʱ��

		private DateTime endTime;
		/// <summary>
		/// ����ʱ��
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

		#region �ͻ���

		private string customerName;
		/// <summary>
		/// �ͻ���
		/// </summary>
		public string CustomerName
		{
			get { return customerName; }
			set { customerName = value; }
		}

		#endregion

		#region ����ͳ��

		private decimal[] result;
		/// <summary>
		/// ����ͳ��
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
