using System;
using Workflow.Da.Domain.Base;
using Workflow.Support;

namespace Workflow.Da.Domain
{
	/// <summary>
	/// Table MACHINE_WATCH_CONVERSION_PAPER��Ӧ��DotNet Object
	/// </summary>
	[Serializable]
	public class MachineWatchConversionPaper : MachineWatchConversionPaperBase
	{
		public MachineWatchConversionPaper()
		{
		}

		#region ����id

		private long machineId;
		/// <summary>
		/// ����id
		/// </summary>
		public long MachineId
		{
			get { return machineId; }
			set { machineId = value; }
		}
	

		#endregion

		#region ��������

		private string machineName;
		/// <summary>
		/// ��������
		/// </summary>
		public string MachineName
		{
			get { return machineName; }
			set { machineName = value; }
		}


		#endregion

		#region ��������id

		private long machineTypeId;
		/// <summary>
		/// ��������id
		/// </summary>
		public long MachineTypeId
		{
			get { return machineTypeId; }
			set { machineTypeId = value; }
		}


		#endregion

		#region ������(����ֵ)
		
		private long makeCountTheory;
        /// <summary>
        /// ������(����ֵ)
        /// </summary>
        public long MakeCountTheory
        {
            get { return this.makeCountTheory;  }
            set { this.makeCountTheory = value; }
		}

		#endregion

		#region ʵ��������
		
		private decimal makeCount;
        /// <summary>
        /// ʵ��������
        /// </summary>
        public decimal MakeCount
        {
            get { return this.makeCount;    }
            set { this.makeCount = value;   }
		}

		#endregion

		#region ʵ�ʶ�����ֽ��
		
		private int orderUsePaperCount;
        /// <summary>
        /// ʵ�ʶ�����ֽ��
        /// </summary>
        public int OrderUsePaperCount
        {
            get { return this.orderUsePaperCount; }
            set { this.orderUsePaperCount = value; }
		}

		#endregion

		#region δ�깤��ֽ����
		
		private long uncompeleteOrderUsePaperCount;
        /// <summary>
        /// δ�깤��ֽ����
        /// </summary>
        public long UncompeleteOrderUsePaperCount
        {
            get { return this.uncompeleteOrderUsePaperCount;    }
            set { this.uncompeleteOrderUsePaperCount = value;   }
		}

		#endregion

		#region �ϴ�δ�깤��ֽ����

		private long lastTimeUncompeleteOrderUsePaperCount;
        /// <summary>
        /// �ϴ�δ�깤��ֽ����
        /// </summary>
        public long LastTimeUncompeleteOrderUsePaperCount
        {
            get { return this.lastTimeUncompeleteOrderUsePaperCount;    }
            set { this.lastTimeUncompeleteOrderUsePaperCount = value;   }
		}

		#endregion

		#region �ϴμ���

		private int lastCount;
		/// <summary>
		/// �ϴμ���
		/// </summary>
		public int LastCount
		{
			get { return lastCount; }
			set { lastCount = value; }
		}

		#endregion

		#region ���μ���

		private int newCount;
		/// <summary>
		/// ���μ���
		/// </summary>
		public int NewCount
		{
			get { return newCount; }
			set { newCount = value; }
		}

		#endregion

		#region ������

		private decimal cashCount;
        /// <summary>
        /// ������
        /// </summary>
        public decimal CashCount
        {
            get { return this.cashCount;    }
            set { this.cashCount = value;   }
		}

		#endregion

		#region ������

		private int patchCount;
        /// <summary>
        /// ������
        /// </summary>
        public int PatchCount
        {
            get { return this.patchCount;   }
            set { this.patchCount = value;  }
		}
		#endregion

		#region ֽ��id

		private long  paperId;
		/// <summary>
		/// ֽ��id
		/// </summary>
		public long  PaperId
		{
			get { return paperId; }
			set { paperId = value; }
		}
	

		#endregion

		#region ��2��ֽ��

		private long paperSpcId2;
		/// <summary>
		/// ��2��ֽ��
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

		#region ��3��ֽ��
		private long paperSpcId3;
		/// <summary>
		/// ��3��ֽ��
		/// </summary>
		public long PaperSpcId3
		{
			get { return paperSpcId3; }
			set { paperSpcId3 = value; }
		}
		#endregion

		#region ֽ����������
		private string paperName;
		/// <summary>
		/// ֽ����������
		/// </summary>
		public string PaperName
		{
			get
			{
				if (ColorType == Constants.COLOR_BLACKWHITE)
				{
					paperName = "A3/A3��Ѫ/A4";
				}
				else if (this.ColorType == Constants.COLOR_MULTICOLOR)
				{
					if (this.paperName == "A3")
					{
						paperName = "A3/A3��Ѫ";
					}
				}
				return paperName;
			}
			set { paperName = value; }
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

		#region ���

		private bool result;
		/// <summary>
		/// ���
		/// </summary>
		public bool Result
		{
			get { return result; }
			set { result = value; }
		}

		#endregion

		#region ����Ĳ�ֵ

		private long resultValue;
		/// <summary>
		/// ����Ĳ�ֵ
		/// </summary>
		public long ResultValue
		{
			get { return resultValue; }
			set { resultValue = value; }
		}

		#endregion

		#region �Ƿ���Ҫ����

		private bool needRecordWatch;
		/// <summary>
		/// �Ƿ���Ҫ����
		/// </summary>
		public bool NeedRecordWatch
		{
			get { return needRecordWatch; }
			set { needRecordWatch = value; }
		}

		#endregion
	}
}
