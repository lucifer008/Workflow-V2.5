using System;
using Workflow.Da.Domain.Base;
using Workflow.Support;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MACHINE_WATCH_CONVERSION_PAPER对应的DotNet Object
	/// </summary>
	[Serializable]
	public class MachineWatchConversionPaper : MachineWatchConversionPaperBase
	{
		public MachineWatchConversionPaper()
		{
		}

		#region 机器id

		private long machineId;
		/// <summary>
		/// 机器id
		/// </summary>
		public long MachineId
		{
			get { return machineId; }
			set { machineId = value; }
		}
	

		#endregion

		#region 机器名称

		private string machineName;
		/// <summary>
		/// 机器名称
		/// </summary>
		public string MachineName
		{
			get { return machineName; }
			set { machineName = value; }
		}


		#endregion

		#region 机器类型id

		private long machineTypeId;
		/// <summary>
		/// 机器类型id
		/// </summary>
		public long MachineTypeId
		{
			get { return machineTypeId; }
			set { machineTypeId = value; }
		}


		#endregion

		#region 制作数(理论值)
		
		private long makeCountTheory;
        /// <summary>
        /// 制作数(理论值)
        /// </summary>
        public long MakeCountTheory
        {
            get { return this.makeCountTheory;  }
            set { this.makeCountTheory = value; }
		}

		#endregion

		#region 实际制作数
		
		private decimal makeCount;
        /// <summary>
        /// 实际制作数
        /// </summary>
        public decimal MakeCount
        {
            get { return this.makeCount;    }
            set { this.makeCount = value;   }
		}

		#endregion

		#region 实际订单用纸数
		
		private int orderUsePaperCount;
        /// <summary>
        /// 实际订单用纸数
        /// </summary>
        public int OrderUsePaperCount
        {
            get { return this.orderUsePaperCount; }
            set { this.orderUsePaperCount = value; }
		}

		#endregion

		#region 未完工用纸数量
		
		private long uncompeleteOrderUsePaperCount;
        /// <summary>
        /// 未完工用纸数量
        /// </summary>
        public long UncompeleteOrderUsePaperCount
        {
            get { return this.uncompeleteOrderUsePaperCount;    }
            set { this.uncompeleteOrderUsePaperCount = value;   }
		}

		#endregion

		#region 上次未完工用纸数量

		private long lastTimeUncompeleteOrderUsePaperCount;
        /// <summary>
        /// 上次未完工用纸数量
        /// </summary>
        public long LastTimeUncompeleteOrderUsePaperCount
        {
            get { return this.lastTimeUncompeleteOrderUsePaperCount;    }
            set { this.lastTimeUncompeleteOrderUsePaperCount = value;   }
		}

		#endregion

		#region 上次计数

		private int lastCount;
		/// <summary>
		/// 上次计数
		/// </summary>
		public int LastCount
		{
			get { return lastCount; }
			set { lastCount = value; }
		}

		#endregion

		#region 本次计数

		private int newCount;
		/// <summary>
		/// 本次计数
		/// </summary>
		public int NewCount
		{
			get { return newCount; }
			set { newCount = value; }
		}

		#endregion

		#region 废张数

		private decimal cashCount;
        /// <summary>
        /// 废张数
        /// </summary>
        public decimal CashCount
        {
            get { return this.cashCount;    }
            set { this.cashCount = value;   }
		}

		#endregion

		#region 补单量

		private int patchCount;
        /// <summary>
        /// 补单量
        /// </summary>
        public int PatchCount
        {
            get { return this.patchCount;   }
            set { this.patchCount = value;  }
		}
		#endregion

		#region 纸型id

		private long  paperId;
		/// <summary>
		/// 纸型id
		/// </summary>
		public long  PaperId
		{
			get { return paperId; }
			set { paperId = value; }
		}
	

		#endregion

		#region 第2种纸型

		private long paperSpcId2;
		/// <summary>
		/// 第2种纸型
		/// </summary>
		public long PaperSpcId2
		{
			get
			{
				//if (ColorType == Constants.COLOR_BLACKWHITE)
				//    paperSpcId2 = 6;
				return paperSpcId2;
			}
			set { paperSpcId2 = value; }
		}
		#endregion

		#region 第3种纸型
		private long paperSpcId3;
		/// <summary>
		/// 第3种纸型
		/// </summary>
		public long PaperSpcId3
		{
			get { return paperSpcId3; }
			set { paperSpcId3 = value; }
		}
		#endregion

		#region 纸的类型名称
		private string paperName;
		/// <summary>
		/// 纸的类型名称
		/// </summary>
		public string PaperName
		{
			get
			{
				if (ColorType == Constants.COLOR_BLACKWHITE)
				{
					paperName = "A3/A3出血/A4";
				}
				else if (this.ColorType == Constants.COLOR_MULTICOLOR)
				{
					if (this.paperName == "A3")
					{
						paperName = "A3/A3出血";
					}
				}
				return paperName;
			}
			set { paperName = value; }
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

		#region 结果

		private bool result;
		/// <summary>
		/// 结果
		/// </summary>
		public bool Result
		{
			get { return result; }
			set { result = value; }
		}

		#endregion

		#region 结果的差值

		private long resultValue;
		/// <summary>
		/// 结果的差值
		/// </summary>
		public long ResultValue
		{
			get { return resultValue; }
			set { resultValue = value; }
		}

		#endregion

		#region 是否需要抄表

		private bool needRecordWatch;
		/// <summary>
		/// 是否需要抄表
		/// </summary>
		public bool NeedRecordWatch
		{
			get { return needRecordWatch; }
			set { needRecordWatch = value; }
		}

		#endregion
	}
}
