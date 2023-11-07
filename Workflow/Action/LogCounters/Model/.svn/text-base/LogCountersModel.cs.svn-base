using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;

namespace Workflow.Action.Model
{
    public class LogCountersModel
	{
		#region 职员一览(初期显示用)
		private IList<Workflow.Da.Domain.Employee> employeeList;
		/// <summary>
		/// 职员一览(初期显示用)
		/// </summary>
		public IList<Workflow.Da.Domain.Employee> EmployeeList
		{
			get { return employeeList; }
			set { employeeList = value; }
		}
		#endregion

		#region 机器类型一览
		
		private IList<MachineType> machineTypeList;
		/// <summary>
		/// 机器类型一览
		/// </summary>
		public IList<MachineType> MachineTypeList
		{
			get { return machineTypeList; }
			set { machineTypeList = value; }
		}
		#endregion

		#region 订单
		private IList<Order> orderList;
		/// <summary>
		/// 订单
		/// </summary>
		public IList<Order> OrderList
		{
			get { return orderList; }
			set { orderList = value; }
		}
		#endregion

		#region 机器
		private IList<Machine> machineList;
		/// <summary>
		/// 机器
		/// </summary>
		public IList<Machine> MachineList
		{
			get { return machineList; }
			set { machineList = value; }
		}
		#endregion

		#region 纸型

		private IList<PaperSpecification> paperSpecificationList;
		/// <summary>
		/// 纸型
		/// </summary>
		public IList<PaperSpecification> PaperSpecificationList
		{
			get { return paperSpecificationList; }
			set { paperSpecificationList = value; }
		}
		#endregion

		#region 抄表
		private RecordMachineWatch recordMachineWatch;
		/// <summary>
		/// 抄表
		/// </summary>
		public RecordMachineWatch RecordMachineWatch
		{
			get { return recordMachineWatch; }
			set { recordMachineWatch = value; }
		}
		#endregion

		#region 抄表读数
		private IList<MachineWatchScale> machineWatchScaleList;
		/// <summary>
		/// 抄表读数
		/// </summary>
		public IList<MachineWatchScale> MachineWatchScaleList
		{
			get { return machineWatchScaleList; }
			set { machineWatchScaleList = value; }
		}
		#endregion

		#region 抄表记录一览
		private IList<RecordMachineWatch> recordMachineWatchList;
		/// <summary>
		/// 抄表记录一览
		/// </summary>
		public IList<RecordMachineWatch> RecordMachineWatchList
		{
			get { return recordMachineWatchList; }
			set { recordMachineWatchList = value; }
		}
		#endregion

		#region 机器计数器表
		private MachineWatch machineWatch;
		/// <summary>
		/// 机器计数器表
		/// </summary>
        public MachineWatch MachineWatch
        {
            get { return machineWatch;  }
            set { machineWatch = value; }
        }
		#endregion

		#region 机器抄表
		private IList<MachineWatchRecordLog> machineWatchRecordLogList;
		/// <summary>
        /// 机器抄表
        /// </summary>
        public IList<MachineWatchRecordLog> MachineWatchRecordLogList
        {
            get { return machineWatchRecordLogList; }
            set { machineWatchRecordLogList = value; }
        }
		#endregion

		#region 机器抄表换算纸张
		private MachineWatchConversionPaper machineWatchConversionPaper;
		/// <summary>
        /// 机器抄表换算纸张
        /// </summary>
        public MachineWatchConversionPaper MachineWatchConversionPaper
        {
            get { return machineWatchConversionPaper; }
            set { machineWatchConversionPaper = value; }
        }
		#endregion

		#region 机器抄表数据转换成纸张的数据
		private IList<MachineWatchConversionPaper> machineWatchConversionPaperList;
		/// <summary>
        /// 机器抄表数据转换成纸张的数据
        /// </summary>
        public IList<MachineWatchConversionPaper> MachineWatchConversionPaperList
        {
            get { return machineWatchConversionPaperList; }
            set { machineWatchConversionPaperList = value; }
        }
		#endregion

		#region 未完工订单用纸情况
		private IList<UncompleteOrdersUsedPaper> uncompleteOrdersUsedPaperList;
		/// <summary>
        /// 未完工订单用纸情况
        /// </summary>
        public IList<UncompleteOrdersUsedPaper> UncompleteOrdersUsedPaperList
        {
            get { return uncompleteOrdersUsedPaperList; }
            set { uncompleteOrdersUsedPaperList = value; }
        }
		#endregion

		#region 补单订单用纸情况
		private CompensateUsedPaper compensateUsedPaper;
		/// <summary>
        /// 补单订单用纸情况
        /// </summary>
        public CompensateUsedPaper CompensateUsedPaper
        {
            get { return compensateUsedPaper;   }
            set { compensateUsedPaper = value;  }
        }
		#endregion

		#region 责任人一览
		private IList<CompensateEmployee> compensateEmployeeList;
		/// <summary>
        /// 责任人一览
        /// </summary>
        public IList<CompensateEmployee> CompensateEmployeeList
        {
            get { return compensateEmployeeList; }
            set { compensateEmployeeList = value; }
        }
		#endregion

		#region 每次抄表基本信息记录
		private IList<DailyRecordMachine> dailyRecordMachineList;
		/// <summary>
        /// 每次抄表基本信息记录
        /// </summary>
        public IList<DailyRecordMachine> DailyRecordMachineList
        {
            get { return dailyRecordMachineList; }
            set { dailyRecordMachineList = value; }
        }
		#endregion

		#region 每次抄表基本信息记录(打印)
		private IList<DailyRecordMachine> dailyRecordMachineTempList;
		/// <summary>
        /// 每次抄表基本信息记录(打印)
        /// </summary>
        public IList<DailyRecordMachine> DailyRecordMachineTempList
        {
            get { return dailyRecordMachineTempList; }
            set { dailyRecordMachineTempList = value; }
        }
		#endregion

		#region 每次抄表数量
		private long dailyRecordMachineRecordCount;
		/// <summary>
		/// 每次抄表数量
		/// </summary>
        public long DailyRecordMachineRecordCount 
        {
            set { dailyRecordMachineRecordCount = value; }
            get { return dailyRecordMachineRecordCount; }
        }
		#endregion

		#region 每次抄表基本信息记录
		private DailyRecordMachine dailyRecordMachine;
		/// <summary>
        /// 每次抄表基本信息记录
        /// </summary>
        public DailyRecordMachine DailyRecordMachine
        {
            get { return dailyRecordMachine;    }
            set { dailyRecordMachine = value;   }
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

		#region 机器id

		private long machineTypeId;
		/// <summary>
		/// 机器id
		/// </summary>
		public long MachineTypeId
		{
			get { return machineTypeId; }
			set { machineTypeId = value; }
		}

		#endregion

		#region 纸型id

		private long paperId;
		/// <summary>
		/// 纸型id
		/// </summary>
		public long PaperId
		{
			get { return paperId; }
			set { paperId = value; }
		}

		#endregion

		#region 补单数量

		private int compensateCount;
		/// <summary>
		/// 补单数量
		/// </summary>
		public int CompensateCount
		{
			get { return compensateCount; }
			set { compensateCount = value; }
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

		#region 责任人列表

		private IList<string> employeeNameList;
		/// <summary>
		/// 责任人列表
		/// </summary>
		public IList<string> EmployeeNameList
		{
			get
			{
				if (null == employeeNameList)
					employeeNameList = new List<string>();
				return employeeNameList;
			}
			set { employeeNameList = value; }
		}

		#endregion
	}
}
