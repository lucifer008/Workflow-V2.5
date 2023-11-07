using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using System.Collections;

namespace Workflow.Action.LogCounters
{
	/// <summary>
	/// 名    称: CheckCounterModel
	/// 功能概要: 抄表记录的核实
	/// 作    者: 陈汝胤
	/// 创建时间: 2009.4.29
	/// </summary>
	public class CheckCounterModel
	{
		#region 需要抄表的机器类型

		private IList<MachineType> machineTypeList;
		/// <summary>
		/// 需要抄表的机器
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

		#region 补单列表

		private IList<CompensateUsedPaper> compensateUsedPaperList;
		/// <summary>
		/// 补单列表 
		/// </summary>
		public IList<CompensateUsedPaper> CompensateUsedPaperList
		{
			get { return compensateUsedPaperList; }
			set { compensateUsedPaperList = value; }
		}


		#endregion

		#region 抄表记录id

		private long recordMachineWatchId;
		/// <summary>
		/// 抄表记录id
		/// </summary>
		public long RecordMachineWatchId
		{
			get { return recordMachineWatchId; }
			set { recordMachineWatchId = value; }
		}

		#endregion

		#region 纸型

		private string paperSharp;
		/// <summary>
		/// 纸型
		/// </summary>
		public string PaperSharp
		{
			get { return paperSharp; }
			set { paperSharp = value; }
		}

		#endregion

		#region 纸色

		private string paperColor;
		/// <summary>
		/// 纸色
		/// </summary>
		public string PaperColor
		{
			get { return paperColor; }
			set { paperColor = value; }
		}

		#endregion

		#region 上次计数

		private int lastNumber;
		/// <summary>
		/// 上次计数
		/// </summary>
		public int LastNumber
		{
			get { return lastNumber; }
			set { lastNumber = value; }
		}

		#endregion

		#region 本次计数

		private int newNumber;
		/// <summary>
		/// 本次计数
		/// </summary>
		public int NewNumber
		{
			get { return newNumber; }
			set { newNumber = value; }
		}

		#endregion

		#region 实际制作数

		private int makeNumber;
		/// <summary>
		/// 实际制作数
		/// </summary>
		public int MakeNumber
		{
			get { return makeNumber; }
			set { makeNumber = value; }
		}

		#endregion

		#region 废张数

		private int cashNumber;
		/// <summary>
		/// 废张数
		/// </summary>
		public int CashNumber
		{
			get { return cashNumber; }
			set { cashNumber = value; }
		}

		#endregion

		#region 补单数

		private int pathNumber;
		/// <summary>
		/// 补单数
		/// </summary>
		public int PathNumber
		{
			get { return pathNumber; }
			set { pathNumber = value; }
		}

		#endregion

		#region 结果

		private int result;
		/// <summary>
		/// 结果
		/// </summary>
		public int Result
		{
			get { return result; }
			set { result = value; }
		}

		#endregion

		#region 补单id

		private long compensateUsedPaperId;
		/// <summary>
		/// 补单id
		/// </summary>
		public long CompensateUsedPaperId
		{
			get { return compensateUsedPaperId; }
			set { compensateUsedPaperId = value; }
		}

		#endregion

		#region 临时存放实际订单制作数

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

		#region 是否可以核实

		private bool isAllowVerify;
		/// <summary>
		/// 是否可以核实
		/// </summary>
		public bool IsAllowVerify
		{
			get { return isAllowVerify; }
			set { isAllowVerify = value; }
		}

		#endregion

		#region 是否核实完成

		private int isVerify;
		/// <summary>
		/// 是否核实完成
		/// </summary>
		public int IsVerify
		{
			get { return isVerify; }
			set { isVerify = value; }
		}

		#endregion
	}
}
