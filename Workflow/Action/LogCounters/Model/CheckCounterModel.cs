using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Action.LogCounters
{
	/// <summary>
	/// ��    ��: CheckCounterModel
	/// ���ܸ�Ҫ: �����¼�ĺ�ʵ
	/// ��    ��: ����ط
	/// ����ʱ��: 2009.4.29
	/// </summary>
	public class CheckCounterModel
	{
		#region ��Ҫ����Ļ�������

		private IList<MachineType> machineTypeList;
		/// <summary>
		/// ��Ҫ����Ļ���
		/// </summary>
		public IList<MachineType> MachineTypeList
		{
			get { return machineTypeList; }
			set { machineTypeList = value; }
		}

		#endregion

		#region conversionList

		private IList<MachineWatchConversionPaper> conversionList;
		public IList<MachineWatchConversionPaper> ConversionList
		{
			get { return conversionList; }
			set { conversionList = value; }
		}

		#endregion

		#region �����б�

		private IList<CompensateUsedPaper> compensateUsedPaperList;
		/// <summary>
		/// �����б� 
		/// </summary>
		public IList<CompensateUsedPaper> CompensateUsedPaperList
		{
			get { return compensateUsedPaperList; }
			set { compensateUsedPaperList = value; }
		}


		#endregion

		#region �����¼id

		private long recordMachineWatchId;
		/// <summary>
		/// �����¼id
		/// </summary>
		public long RecordMachineWatchId
		{
			get { return recordMachineWatchId; }
			set { recordMachineWatchId = value; }
		}

		#endregion

		#region ֽ��

		private string paperSharp;
		/// <summary>
		/// ֽ��
		/// </summary>
		public string PaperSharp
		{
			get { return paperSharp; }
			set { paperSharp = value; }
		}

		#endregion

		#region ֽɫ

		private string paperColor;
		/// <summary>
		/// ֽɫ
		/// </summary>
		public string PaperColor
		{
			get { return paperColor; }
			set { paperColor = value; }
		}

		#endregion

		#region �ϴμ���

		private int lastNumber;
		/// <summary>
		/// �ϴμ���
		/// </summary>
		public int LastNumber
		{
			get { return lastNumber; }
			set { lastNumber = value; }
		}

		#endregion

		#region ���μ���

		private int newNumber;
		/// <summary>
		/// ���μ���
		/// </summary>
		public int NewNumber
		{
			get { return newNumber; }
			set { newNumber = value; }
		}

		#endregion

		#region ʵ��������

		private int makeNumber;
		/// <summary>
		/// ʵ��������
		/// </summary>
		public int MakeNumber
		{
			get { return makeNumber; }
			set { makeNumber = value; }
		}

		#endregion

		#region ������

		private int cashNumber;
		/// <summary>
		/// ������
		/// </summary>
		public int CashNumber
		{
			get { return cashNumber; }
			set { cashNumber = value; }
		}

		#endregion

		#region ������

		private int pathNumber;
		/// <summary>
		/// ������
		/// </summary>
		public int PathNumber
		{
			get { return pathNumber; }
			set { pathNumber = value; }
		}

		#endregion

		#region ���

		private int result;
		/// <summary>
		/// ���
		/// </summary>
		public int Result
		{
			get { return result; }
			set { result = value; }
		}

		#endregion

		#region ����id

		private long compensateUsedPaperId;
		/// <summary>
		/// ����id
		/// </summary>
		public long CompensateUsedPaperId
		{
			get { return compensateUsedPaperId; }
			set { compensateUsedPaperId = value; }
		}

		#endregion

		#region ��ʱ���ʵ�ʶ���������

		private Hashtable makeMap;
		public Hashtable MakeMap
		{
			get
			{
				if (null == makeMap)
					makeMap = new Hashtable();
				return makeMap;
			}
			set { makeMap = value; }
		}

		#endregion

		#region �Ƿ���Ժ�ʵ

		private bool isAllowVerify;
		/// <summary>
		/// �Ƿ���Ժ�ʵ
		/// </summary>
		public bool IsAllowVerify
		{
			get { return isAllowVerify; }
			set { isAllowVerify = value; }
		}

		#endregion

		#region �Ƿ��ʵ���

		private int isVerify;
		/// <summary>
		/// �Ƿ��ʵ���
		/// </summary>
		public int IsVerify
		{
			get { return isVerify; }
			set { isVerify = value; }
		}

		#endregion
	}
}
