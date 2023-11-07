using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using Spring.Transaction.Interceptor;
using Workflow.Da;
using Workflow.Util;
using Workflow.Da.Domain;
using Workflow.Action.LogCounters;
using Workflow.Support;

namespace Workflow.Service.LogCounterManage
{
    /// <summary>
    /// 名    称: LogCountersServiceImpl
    /// 功能概要: 机器抄表相关接口的实现类
    /// 作    者: 
    /// 创建时间: 
    /// 修 正 人: 付强
    /// 修正时间: 2007-9-13
	/// 修正描述: 完成未完成的功能
    /// 描    述: 代码整理
	/// 修 正 人: 陈汝胤
	/// 修正时间: 2009.4.26-
    /// </summary>
    public class LogCountersServiceImpl : ILogCountersService
    {
        #region 类成员
        /// <summary>
        /// 机器类型
        /// </summary>
        private IMachineTypeDao machineTypeDao;
        public IMachineTypeDao MachineTypeDao
        {
            set { machineTypeDao = value; }
        }

        /// <summary>
        /// 职员
        /// </summary>
        private IEmployeeDao employeeDao;
        public IEmployeeDao EmployeeDao
        {
            set { employeeDao = value; }
        }
        
        /// <summary>
        /// 未完成加工单用纸情况
        /// </summary>
        private IUncompleteOrdersUsedPaperDao uncompleteOrdersUsedPaperDao;
        public IUncompleteOrdersUsedPaperDao UncompleteOrdersUsedPaperDao
        {
            set { uncompleteOrdersUsedPaperDao = value; }
        }

        /// <summary>
        /// 补单用纸情况
        /// </summary>
        private ICompensateUsedPaperDao compensateUsedPaperDao;
        public ICompensateUsedPaperDao CompensateUsedPaperDao
        {
            set { compensateUsedPaperDao = value; }
        }

        /// <summary>
        /// 补单责任人
        /// </summary>
        private ICompensateEmployeeDao compensateEmployeeDao;
        public ICompensateEmployeeDao CompensateEmployeeDao
        {
            set { compensateEmployeeDao = value; }
        }

        private IRecordMachineWatchDao recordMachineWatchDao;
        public IRecordMachineWatchDao RecordMachineWatchDao
        {
            set { recordMachineWatchDao = value; }
        }

        /// <summary>
        /// 抄表
        /// </summary>
        private IMachineWatchDao machineWatchDao;
        public IMachineWatchDao MachineWatchDao
        {
            set { machineWatchDao = value; }
        }

        /// <summary>
        /// 抄表记录
        /// </summary>
        private IMachineWatchRecordLogDao machineWatchRecordLogDao;
        public IMachineWatchRecordLogDao MachineWatchRecordLogDao
        {
            set { machineWatchRecordLogDao = value; }
        }

        /// <summary>
        /// 抄表读数换算纸张表
        /// </summary>
        private IMachineWatchConversionPaperDao machineWatchConversionPaperDao;
        public IMachineWatchConversionPaperDao MachineWatchConversionPaperDao
        {
            set { machineWatchConversionPaperDao = value; }
        }

        /// <summary>
        /// 机器表读数
        /// </summary>
        private IMachineWatchScaleDao machineWatchScaleDao;
        public IMachineWatchScaleDao MachineWatchScaleDao
        {
            set { machineWatchScaleDao = value; }
		}
		

		

		
		#endregion

		#region 注入

		#region 注入 dailyRecordMachineDao
		private IDailyRecordMachineDao dailyRecordMachineDao;
		/// <summary>
		/// 每次抄表基本信息记录
		/// </summary>
		public IDailyRecordMachineDao DailyRecordMachineDao
		{
			set { dailyRecordMachineDao = value; }
		}
		#endregion

		#region 注入 ordersForRecordMachineSumDao

		private IOrdersForRecordMachineSumDao ordersForRecordMachineSumDao;
		/// <summary>
		/// 工单中抄表数据的汇总
		/// </summary>
        public IOrdersForRecordMachineSumDao OrdersForRecordMachineSumDao
        {
            set { ordersForRecordMachineSumDao = value; }
        }
        #endregion

		#region 注入 machineDao

		private IMachineDao machineDao;
		/// <summary>
		/// 注入machineDao
		/// </summary>
		public IMachineDao MachineDao
		{
			set { machineDao = value; }
		}

		#endregion

		#region 注入 paperSpecification

		private IPaperSpecificationDao paperSpecificationDao;
		/// <summary>
		/// 注入 paperSpecification
		/// </summary>
		public IPaperSpecificationDao PaperSpecificationDao
		{
			set { paperSpecificationDao = value; }
		}

		#endregion

		#endregion

		#region 机器抄表的操作
		/// <summary>
        /// 名    称: SaveUncompleteOrdersUsedPaper
        /// 功能概要: 保存未完工用纸数量
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="uncompleteOrdersUsedPaper">未完工用纸数量</param>
        [Transaction]
        public void SaveUncompleteOrdersUsedPaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper)
        {
            uncompleteOrdersUsedPaperDao.Insert(uncompleteOrdersUsedPaper);
        }
        /// <summary>
        /// 名    称: UpdateUncompleteOrdersUsedPaper
        /// 功能概要: 更新未完工用纸数量
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="uncompleteOrdersUsedPaper">要更新的未完工用纸情况</param>
        [Transaction]
        public void UpdateUncompleteOrdersUsedPaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper)
        {
            uncompleteOrdersUsedPaperDao.Update(uncompleteOrdersUsedPaper);
        }
        /// <summary>
        /// 名    称: DeleteUncompleteOrdersUsedPaper
        /// 功能概要: 删除未完工用纸数量
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="uncompleteOrdersUsedPaper">要删除的未完工用纸情况</param>
        [Transaction]
        public void DeleteUncompleteOrdersUsedPaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper)
        {
            uncompleteOrdersUsedPaperDao.Delete(uncompleteOrdersUsedPaper.Id);
        }
        /// <summary>
        /// 名    称: SaveCompensateUsedPaper
        /// 功能概要: 保存补单
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <returns></returns>
        [Transaction]
        public void SaveCompensateUsedPaper(CompensateUsedPaper compensateUsedPaper, IList<CompensateEmployee> compensateEmployeeList)
        {
            //保存补单
            compensateUsedPaperDao.Insert(compensateUsedPaper);
            foreach (CompensateEmployee var in compensateEmployeeList)
            {
                var.CompensateUsedPaperId = compensateUsedPaper.Id;
                compensateEmployeeDao.Insert(var);
            }
        }
        /// <summary>
        /// 名    称: UpdateCompensateUsedPaper
        /// 功能概要: 编辑补单用纸数量
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <returns></returns>
        [Transaction]
        public void UpdateCompensateUsedPaper(CompensateUsedPaper compensateUsedPaper, IList<CompensateEmployee> compensateEmployeeList)
        {
            //删除补单负责人
            compensateEmployeeDao.DeleteByCompensateUsedPaperId(compensateUsedPaper.Id);
            //更新补单数据
            compensateUsedPaperDao.Update(compensateUsedPaper);
            //插入补单责任人
            foreach (CompensateEmployee var in compensateEmployeeList)
            {
                var.CompensateUsedPaperId = compensateUsedPaper.Id;
                compensateEmployeeDao.Insert(var);
            }
        }
        /// <summary>
        /// 名    称: DeleteCompensateUsedPaper
        /// 功能概要: 删除补单用纸数量
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <returns></returns>
        [Transaction]
        public void DeleteCompensateUsedPaper(long id)
        {
            //删除补单负责人
            compensateEmployeeDao.DeleteByCompensateUsedPaperId(id);
            //删除补单数据
            compensateUsedPaperDao.Delete(id);
        }
        /// <summary>
        /// 名    称: SaveCompensateEmployee
        /// 功能概要: 插入责任人信息
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="compensateEmployeeList"></param>
        [Transaction]
        public void SaveCompensateEmployee(IList<CompensateEmployee> compensateEmployeeList)
        {
            foreach (CompensateEmployee var in compensateEmployeeList)
            {
                compensateEmployeeDao.Insert(var);
            }
        }
        /// <summary>
        /// 名    称: SaveMachineWatchRecordCheckData
        /// 功能概要: 每次抄表基本信息记录
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="dailyRecordMachineList"></param>
        [Transaction]
        public void SaveLogCounter(RecordMachineWatch recordMachineWatch, IList<MachineWatchRecordLog> machineWatchRecordLogList, IList<UncompleteOrdersUsedPaper> uncompleteOrdersUsedPaperList)
        {
            //插入抄表动作记录
            recordMachineWatchDao.Insert(recordMachineWatch);
            //插入抄表实际数
            foreach (MachineWatchRecordLog var in machineWatchRecordLogList)
            {
                var.RecordMachineWatchId = recordMachineWatch.Id;
                machineWatchRecordLogDao.Insert(var);
                //更新该表的最新读数
                machineWatchScaleDao.UpdateLastNumber(var);
            }
            //插入未完工用纸数量
            foreach (UncompleteOrdersUsedPaper var in uncompleteOrdersUsedPaperList)
            {
                var.RecordMachineWatchId = recordMachineWatch.Id;
                uncompleteOrdersUsedPaperDao.Insert(var);
            }
        }
        #endregion

        #region 抄表查询
        /// <summary>
        /// 名    称: GetMachineTypeList
        /// 功能概要: 获得需要抄表的机器类型
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <returns>机器类型列表</returns>
        public IList<MachineType> GetMachineTypeList()
        {
            //TODO MARK 此方法将来要重写,取出机器类型中需要抄表的机器进行抄表.(数据库需要增加FLAG)
            return machineTypeDao.SelectAll();
        }
        /// <summary>
        /// 名    称: GetUncompleteOrdersUsedPaperList
        /// 功能概要: 获得未完工用纸数量一览
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <returns></returns>
        public IList<UncompleteOrdersUsedPaper> GetUncompleteOrdersUsedPaperList()
        {
            return uncompleteOrdersUsedPaperDao.SelectAll();
        }
        /// <summary>
        /// 名    称: GetCompensateUsedPaperList
        /// 功能概要: 获得补单用纸数量一览
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <returns></returns>
        public IList<CompensateUsedPaper> GetCompensateUsedPaperList()
        {
            return compensateUsedPaperDao.SelectAll();
        }
        /// <summary>
        /// 名    称: GetCompensateEmployeeList
        /// 功能概要: 获得责任人一览
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <returns></returns>
        public IList<Employee> GetCompensateEmployeeList()
        {
            return employeeDao.SelectAll();
        }
        /// <summary>
        /// 名    称: GetRecordMachineWatchById
        /// 功能概要: 通过ID获得抄表记录
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="id">抄表记录ID</param>
        /// <returns></returns>
        public RecordMachineWatch GetRecordMachineWatchById(long id)
        {
            return recordMachineWatchDao.SelectByPk(id);
        }
        /// <summary>
        /// 名    称: GetCompensateUsedPaperById
        /// 功能概要: 通过ID获得补单用纸情况
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CompensateUsedPaper GetCompensateUsedPaperById(long id)
        {
            return compensateUsedPaperDao.SelectByPk(id);
        }
        /// <summary>
        /// 名    称: GetLastNumberByMachineId
        /// 功能概要: 获得某一台机器的上期读数
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="id">机器ID</param>
        /// <returns></returns>
        public IList<MachineWatchScale> GetLastNumberByMachineId(long id)
        {
            return machineWatchScaleDao.SelectLastNumberByMachineId(id);
        }
        /// <summary>
        /// 名    称: GetMachineWatchRecordCheckDataList
        /// 功能概要: 获得机器抄表读数转换为纸张的数据
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="machineWatchConversionPaper"></param>
        /// <param name="lngRecordMachineWatchId"></param>
        /// <returns></returns>
        public IList<MachineWatchConversionPaper> GetMachineWatchRecordCheckDataList(MachineWatchConversionPaper machineWatchConversionPaper, long lngRecordMachineWatchId)
        {
            IList<MachineWatchConversionPaper> machineWatchConversionPaperList;
            machineWatchConversionPaperList = machineWatchConversionPaperDao.SelectMachineWatchRecordCheckData(machineWatchConversionPaper);

            CompensateUsedPaper compensateUsedPaper = new CompensateUsedPaper();
            compensateUsedPaper.Machine = new Machine();
            compensateUsedPaper.PaperSpecification = new PaperSpecification();

            //获得废单
            foreach (MachineWatchConversionPaper var in machineWatchConversionPaperList)
            {
                #region 1.求出机器产生的数量(理论值)
                var.MakeCountTheory = GetMachineWatchRecordMakeCount(var, lngRecordMachineWatchId);
                #endregion

                #region 2.求出上次机器抄表信息
                RecordMachineWatch recordMachineWatch = new RecordMachineWatch();
                recordMachineWatch.Id = lngRecordMachineWatchId;
                recordMachineWatch = GetLastTimeRecordMachineWatch(recordMachineWatch);
                #endregion

                #region 3.求出实际制作数量和废张数量
                OrdersForRecordMachineSum ordersForRecordMachineSum = new OrdersForRecordMachineSum();
                //设置查询条件
                //机器
                ordersForRecordMachineSum.MachineId = var.MachineId;
                //纸型
                if (var.PaperSpecification != null)
                {
                    ordersForRecordMachineSum.PaperSpecification = new PaperSpecification();
                    ordersForRecordMachineSum.PaperSpecification.Id = var.PaperSpecification.Id;
                }
                //颜色
                ordersForRecordMachineSum.ColorType = var.ColorType;
                //上期抄表时间
                ordersForRecordMachineSum.BalanceDateTime = recordMachineWatch.InsertDateTime;
                //求数值
                ordersForRecordMachineSum = GetOrdersForRecordMachineSum(ordersForRecordMachineSum);
                #endregion

                #region 4.求出未完工补单量和上次未完工补单量
                UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper = new UncompleteOrdersUsedPaper();
                uncompleteOrdersUsedPaper.Machine = new Machine();

                //设置查询条件
                //机器ID
                uncompleteOrdersUsedPaper.Machine.Id = var.MachineId;
                //纸型ID
                if (var.PaperSpecification != null)
                {
                    uncompleteOrdersUsedPaper.PaperSpecification = new PaperSpecification();
                    uncompleteOrdersUsedPaper.PaperSpecification.Id = var.PaperSpecification.Id;
                }
                //颜色ID
                uncompleteOrdersUsedPaper.ColorType = var.ColorType;
                //抄表ID
                uncompleteOrdersUsedPaper.RecordMachineWatchId = lngRecordMachineWatchId;
                //上次抄表ID
                uncompleteOrdersUsedPaper.LastRecordMachineWatchId = recordMachineWatch.Id;
                uncompleteOrdersUsedPaper = GetUncompeleteOrderUsePaper(uncompleteOrdersUsedPaper);
                #endregion

                #region 5.求出本次补单量
                //设置记录抄表ID,求补单量的时候专用
                compensateUsedPaper.RecordMachineWatchId = lngRecordMachineWatchId;
                compensateUsedPaper.Machine.Id = var.MachineId;
                compensateUsedPaper.ColorType = var.ColorType;
                compensateUsedPaper.PaperSpecification.Id = (var.PaperSpecification == null) ? 0 : var.PaperSpecification.Id;
                #endregion

                #region 6.将结果保存
                if (ordersForRecordMachineSum != null)
                {
                    //实际制作数
                    //var.OrderUsePaperCount = ordersForRecordMachineSum.PaperCount;
                    //废张数
                    //var.CashCount = ordersForRecordMachineSum.TrashPapers;
                }
                //未完工用纸量
                var.UncompeleteOrderUsePaperCount = uncompleteOrdersUsedPaper.UsedPaperCount;
                //上次未完工用纸量
                var.LastTimeUncompeleteOrderUsePaperCount = uncompleteOrdersUsedPaper.LastTimeUsedPaperCount;
                // 补单量
                var.PatchCount = GetMachineWatchRecordPatchCount(compensateUsedPaper);
                //制作数量=实际工单数+未完工数量+废单+补单-上次未完工数量
                var.MakeCount = var.OrderUsePaperCount + var.UncompeleteOrderUsePaperCount + var.CashCount + var.PatchCount - var.LastTimeUncompeleteOrderUsePaperCount;
                #endregion
            }
            return machineWatchConversionPaperList;
        }
        /// <summary>
        /// 名    称: GetMachineWatchRecordMakeCount
        /// 功能概要: 获得机器抄表核对时的制作数量
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="machineWatchConversionPaper"></param>
        /// <param name="lngRecordMachineWatchId"></param>
        /// <returns></returns>
        public int GetMachineWatchRecordMakeCount(MachineWatchConversionPaper machineWatchConversionPaper, long lngRecordMachineWatchId)
        {
            string strFormula;
            strFormula = GetMachineWatchByComputeFormula(machineWatchConversionPaper, lngRecordMachineWatchId);
            return ComputeFormula.EvalToInt(strFormula);
        }
        /// <summary>
        /// 名    称: GetMachineWatchRecordPatchCount
        /// 功能概要: 获得机器抄表核对时的补单数量
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="compensateUsedPaper"></param>
        /// <returns></returns>
        public int GetMachineWatchRecordPatchCount(CompensateUsedPaper compensateUsedPaper)
        {
            return compensateUsedPaperDao.SelectMachineWatchRecordPatchCount(compensateUsedPaper);
        }

        #region //机器数查询
        /// <summary>
        /// 名    称: GetDailyRecordMachineListCustomQuery
        /// 功能概要: 计数器查询
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        public IList<DailyRecordMachine> GetDailyRecordMachineListCustomQuery(DailyRecordMachine dailyRecordMachine)
        {
            return dailyRecordMachineDao.SelectDailyRecordMachineListCustomQuery(dailyRecordMachine);
        }

        /// <summary>
        /// 名    称: GetDailyRecordMachineListCustomQueryPrint
        /// 功能概要: 计数器查询(打印)
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月27日10:49:55
        /// 修 正 人: 
        /// 修正时间: 
        /// 描    述: 
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        public IList<DailyRecordMachine> GetDailyRecordMachineListCustomQueryPrint(DailyRecordMachine dailyRecordMachine) 
        {
            return dailyRecordMachineDao.GetDailyRecordMachineListCustomQueryPrint(dailyRecordMachine);
        }

        /// <summary>
        /// 名    称: GetDailyRecordMachineListCustomQueryRowCount
        /// 功能概要: 计数器查询记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年4月27日10:49:55
        /// 修 正 人: 
        /// 修正时间: 
        /// 描    述: 
        /// </summary>
        /// <param name="dailyRecordMachine"></param>
        /// <returns></returns>
        public long GetDailyRecordMachineListCustomQueryRowCount(DailyRecordMachine dailyRecordMachine) 
        {
            return dailyRecordMachineDao.GetDailyRecordMachineListCustomQueryRowCount(dailyRecordMachine);
        }
        #endregion

        /// <summary>
        /// 名    称: GetMachineWatchByComputeFormula
        /// 功能概要: 求出真正的计算公式
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="machineWatchConversionPaper"></param>
        /// <param name="lngRecordMachineWatchId"></param>
        /// <returns></returns>
        public string GetMachineWatchByComputeFormula(MachineWatchConversionPaper machineWatchConversionPaper, long lngRecordMachineWatchId)
        {
            string[] strComputeFormulaList = null;
            long lngNumber = 0;
            //计数器读数List
            IList<long> intNumberList = new List<long>();
            //计数器计算公式中的变量List
            //ArrayList strComputeFormulaValueList = new ArrayList();
            IList<string> strComputeFormulaValueList = new List<string>();
            //计算公式的串
            string strComputeFormula = machineWatchConversionPaper.ComputeFormula;
            //真正的表达式的串
            string strComputeFormulaResult = machineWatchConversionPaper.ComputeFormula;

            strComputeFormula = strComputeFormula.Replace('+', ',');
            strComputeFormula = strComputeFormula.Replace('-', ',');
            strComputeFormulaList = strComputeFormula.Split(',');


            for (int i = 0; i < strComputeFormulaList.Length; i++)
            {
                strComputeFormulaList[i] = strComputeFormulaList[i].Replace("[", "").Replace("]", "");
                strComputeFormulaValueList.Add(strComputeFormulaList[i].ToString());
            }
            MachineWatchRecordLog machineWatchRecordLog = new MachineWatchRecordLog();
            machineWatchRecordLog.Machine = new Machine();
            machineWatchRecordLog.MachineWatch = new MachineWatch();
            //机器抄表ID
            machineWatchRecordLog.RecordMachineWatchId = lngRecordMachineWatchId;
            //机器ID
            machineWatchRecordLog.Machine.Id = machineWatchConversionPaper.MachineId;

            for (int i = 0; i < strComputeFormulaValueList.Count; i++)
            {
                //计数器ID
                machineWatchRecordLog.MachineWatch.Id = long.Parse(strComputeFormulaValueList[i]);
                lngNumber = GetMachineWatchValue(machineWatchRecordLog);
                //将计算结果增加到intNumberList中
                intNumberList.Add(lngNumber);
            }
            //换算成真正的表达式
            for (int i = 0; i < intNumberList.Count; i++)
            {
                strComputeFormulaResult = strComputeFormulaResult.Replace("[" + strComputeFormulaValueList[i] + "]", intNumberList[i].ToString());
            }

            return strComputeFormulaResult;
        }
        /// <summary>
        /// 名    称: GetMachineWatchValue
        /// 功能概要: 求出计数器的差值(计数器读数)
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="machineWatchRecordLog"></param>
        /// <returns></returns>
        public int GetMachineWatchValue(MachineWatchRecordLog machineWatchRecordLog)
        {
            return machineWatchRecordLogDao.SelectMachineWatchValue(machineWatchRecordLog);
        }
        /// <summary>
        /// 名    称: GetLastTimeRecordMachineWatch
        /// 功能概要: 上次抄表的记录情况
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="recordMachineWatch"></param>
        /// <returns></returns>
        public RecordMachineWatch GetLastTimeRecordMachineWatch(RecordMachineWatch recordMachineWatch)
        {
            return recordMachineWatchDao.SelectLastTimeRecordMachineWatch(recordMachineWatch);
        }
        /// <summary>
        /// 名    称: GetOrdersForRecordMachineSum
        /// 功能概要: 工单中抄表数据的汇总
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="ordersForRecordMachineSum"></param>
        /// <returns></returns>
        public OrdersForRecordMachineSum GetOrdersForRecordMachineSum(OrdersForRecordMachineSum ordersForRecordMachineSum)
        {
            return ordersForRecordMachineSumDao.SelectOrdersForRecordMachineSum(ordersForRecordMachineSum);
        }
        /// <summary>
        /// 名    称: GetUncompeleteOrderUsePaper
        /// 功能概要: 取得未完工用纸量
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="uncompleteOrdersUsedPaper)"></param>
        /// <returns></returns>
        public UncompleteOrdersUsedPaper GetUncompeleteOrderUsePaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper)
        {
            return uncompleteOrdersUsedPaperDao.SelectUncompeleteOrderUsePaper(uncompleteOrdersUsedPaper);
        }
        #endregion

		#region 每次抄表基本信息记录
		/// <summary>
        /// 每次抄表基本信息记录
        /// </summary>
        /// <param name="dailyRecordMachineList"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-20
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        [Transaction]
        public void SaveMachineWatchRecordCheckData(IList<DailyRecordMachine> dailyRecordMachineList)
        {
            foreach (DailyRecordMachine var in dailyRecordMachineList)
            {
                dailyRecordMachineDao.Insert(var);
            }
		}
		#endregion

		#region 获取机器上的表的最新刻度
		/// <summary>
		/// 功能概要: 获取机器上的表的最新刻度
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-2-10
		/// </remarks>
		public IList<Machine> GetMachineLastestNumBer()
		{
			return machineDao.GetMachineLastestNumBer();
		}

		#endregion

		#region 获取需要抄表的机器和机器上的表

		/// <summary>
		/// 获取需要抄表的机器和机器上的表
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.22
		/// </remarks>
		public IList<Machine> GetNeedRecordWarchMachineAndMachineWatch()
		{
			//获取最后1次抄表记录
			//RecordMachineWatch recordMachineWatch = new RecordMachineWatch();
			//recordMachineWatch = recordMachineWatchDao.SelectLastTimeRecordMachineWatch(recordMachineWatch);
			//获取所有机器
			IList<Machine> machineList = machineDao.SelectNeedRecordWarchMachine();
			foreach (Machine machine in machineList)
			{
				machine.watchs = machineWatchDao.SelectMachineWatchByMachineTypeId(machine.MachineType.Id);
				//foreach (MachineWatch machineWatch in machine.watchs)
				//{ 
				//    MachineWatchRecordLog machineWatchRecordLog=new MachineWatchRecordLog();
				//    machineWatchRecordLog.Machine= machine;
				//    machineWatchRecordLog.MachineWatch = machineWatch;
				//    machineWatchRecordLog.RecordMachineWatchId = recordMachineWatch.Id;
				//    machineWatch.Number = machineWatchRecordLogDao.SelectMachineWatchValue(machineWatchRecordLog);
				//}
			}
			return machineList;
		}

		#endregion

		#region 获取需要抄表的机器

		/// <summary>
		/// 获取需要抄表的机器
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.23
		/// </remarks>
		/// <returns></returns>
		public IList<Machine> GetNeedRecordWarchMachine()
		{
			return machineDao.SelectNeedRecordWarchMachine();
		}

		#endregion

		#region 获取所有纸型

		/// <summary>
		/// 获取所有纸型
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.22
		/// </remarks>
		/// <returns></returns>
		public IList<PaperSpecification> GetPaperSpecification()
		{
			return paperSpecificationDao.SelectAll();
		}

		#endregion

		#region 获取一个可用的抄表记录

		/// <summary>
		/// 获取一个可用的抄表记录
		/// 用于临时存放当前的抄表信息,本次信息进行核实后才有效
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.22
		/// </remarks>
		public RecordMachineWatch GetCanUsedRecordMachineWatch()
		{
			RecordMachineWatch recordMachineWatch = recordMachineWatchDao.SelectCompleteRecordMachineWatch();
			if (null == recordMachineWatch)
			{
				recordMachineWatch = new RecordMachineWatch();
				recordMachineWatch.RecordDateTime = DateTime.Now;
				recordMachineWatch.IsConfirmed = Constants.FALSE;
				recordMachineWatchDao.Insert(recordMachineWatch);
			}
			else
			{
				recordMachineWatch.RecordDateTime = DateTime.Now;
				recordMachineWatchDao.Update(recordMachineWatch);
			}

			return recordMachineWatch;
		}

		#endregion

		#region 添加一项未完成工单用纸情况

		/// <summary>
		/// 添加一项未完成工单用纸情况
		/// </summary>
		/// <param name="uncompleteOrderUsedPaper">uncompleteOrderUsedPaper</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		public void AddUncompleteOrderUsedPaper(UncompleteOrdersUsedPaper uncompleteOrderUsedPaper)
		{
			uncompleteOrdersUsedPaperDao.Insert(uncompleteOrderUsedPaper);
		}

		#endregion

		#region 获取未完工工单列表通过抄表id

		/// <summary>
		/// 获取未完工工单列表通过抄表id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <returns>UncompleteOrdersUsedPaperList</returns>
		public IList<UncompleteOrdersUsedPaper> GetUncompleteOrderByRecordWatchId(long recordMachineWatchId)
		{
			return uncompleteOrdersUsedPaperDao.SelectUncompleteOrdersByRecordWatchId(recordMachineWatchId);
		}

		#endregion

		#region 删除未完工工单用纸情况

		/// <summary>
		/// 删除未完工工单用纸情况
		/// </summary>
		/// <param name="uncompleteOrderUsedPaperId">未完工工单用纸情况Id</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		public void DeleteUnCompensateUsedPaper(long uncompleteOrderUsedPaperId)
		{
			uncompleteOrdersUsedPaperDao.Delete(uncompleteOrderUsedPaperId);
		}

		#endregion

		#region 清理未完成核实抄表记录的相关数据

		/// <summary>
		/// 清理未完成核实抄表记录的相关数据
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		[Spring.Transaction.Interceptor.Transaction]
		public void CleanUpUncompleteRecordWatchData()
		{
			//清理未完工工单
			RecordMachineWatch recordMachineWatch = recordMachineWatchDao.SelectCompleteRecordMachineWatch();
			if (null != recordMachineWatch)
			{
				uncompleteOrdersUsedPaperDao.DeleteUncompleteOrderByRecordWatchId(recordMachineWatch.Id);

				machineWatchRecordLogDao.DeleteUncompleteOrderByRecordWatchId(recordMachineWatch.Id);
				//获取所有的补单记录
				IList<CompensateUsedPaper> compensateUsedPaperList = compensateUsedPaperDao.SelectCompensateUsedPaper(recordMachineWatch.Id);
				foreach (CompensateUsedPaper compensateUsedPaper in compensateUsedPaperList)
				{
					compensateEmployeeDao.DeleteByCompensateUsedPaperId(compensateUsedPaper.Id);
				}
				compensateUsedPaperDao.DeleteByRecordMachieWatch(recordMachineWatch.Id);
			}
			//清理表数据
		}

		#endregion

		#region 获取最后一次抄表记录

		/// <summary>
		/// 获取最后一次抄表记录
		/// </summary>
		/// <returns>RecordMachineWatch</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		public RecordMachineWatch GetLastRecordMachineWatch()
		{
			return recordMachineWatchDao.SelectLastRecordMachineWatch();
		}

		#endregion

		#region 获取表的读数通过抄表记录id和机器表id
		/// <summary>
		/// 获取表的读数通过抄表记录id和机器表id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表记录id</param>
		/// <param name="machineWatchId">机器表id</param>
		/// <returns>读书</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		public int GetLastMachineWatchNumber(long recordMachineWatchId, long machineWatchId)
		{
			return machineWatchRecordLogDao.GetLastMachineWatchNumber(recordMachineWatchId, machineWatchId); 
		}

		#endregion

		#region 保存机器抄表记录

		/// <summary>
		/// 保存机器抄表记录
		/// </summary>
		/// <param name="machineWatchRecordLog">机器抄表记录</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.28
		/// </remarks>
		public void SaveVerifyRecordWatchData(MachineWatchRecordLog machineWatchRecordLog)
		{
			machineWatchRecordLogDao.Insert(machineWatchRecordLog);
		}

		#endregion

		#region 获取所有计数器换算纸张

		/// <summary>
		/// 获取所有计数器换算纸张
		/// </summary>
		/// <returns>计数器换算纸张</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.30
		/// </remarks>
		public IList<MachineWatchConversionPaper> GetAllMachineWatchConversionPaper()
		{
			return machineWatchConversionPaperDao.GetAllMachineWatchConversionPaper();
		}

		#endregion

		#region 获取需要核对的抄表记录,通过抄表id和机器id

		/// <summary>
		/// 获取需要核对的抄表记录,通过抄表id和机器id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <param name="machineId">机器id</param>
		/// <returns>抄表记录列表</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.30
		/// </remarks>
		public IList<MachineWatchRecordLog> GetNeedVerifyRecordLog(long recordMachineWatchId, long machineId)
		{
			return machineWatchRecordLogDao.GetNeedVerifyRecordLog(recordMachineWatchId, machineId);
		}

		#endregion

		#region 获取核实抄表,完成的工单的用纸数,通过上次抄表时间,机器id,纸型id

		/// <summary>
		/// 获取核实抄表,完成的工单的用纸数,通过上次抄表时间,机器id,纸型id
		/// </summary>
		/// <returns>数量</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.4
		/// </remarks>
		public int GetVerifyRecordWatchCompleteOrderUsedCount(Hashtable map)
		{
			return recordMachineWatchDao.GetVerifyRecordWatchCompleteOrderUsedCount(map);
		}

		#endregion

		#region 获取补单的用纸数量

		/// <summary>
		/// 获取补单的用纸数量
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <param name="machineId">机器id</param>
		/// <param name="paperId">纸型id</param>
		/// <param name="colorType">纸色区分</param>
		/// <returns>数量</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.4
		/// </remarks>
		public int GetCompensateUsedPaperCount(long recordMachineWatchId,long machineId, long paperId, string colorType)
		{
			int count = 0;

			IList<CompensateUsedPaper> compenstateUsedPaperList = compensateUsedPaperDao.SelectCompensateUsedPaper(recordMachineWatchId, machineId, paperId, colorType);
			foreach (CompensateUsedPaper compensateUsedPaper in compenstateUsedPaperList)
			{
				count += compensateUsedPaper.UsedPaperCount;
			}

			return count;
		}

		#endregion

		#region 获取未完工的工单用纸情况,通过id

		/// <summary>
		/// 获取未完工的工单用纸情况,通过id
		/// </summary>
		/// <param name="id">id</param>
		/// <returns>UncompleteOrdersUsedPaper</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.5
		/// </remarks>
		public UncompleteOrdersUsedPaper GetUncompeleteOrderUsePaperById(long id)
		{
			return uncompleteOrdersUsedPaperDao.SelectByPk(id);
		}

		#endregion

		#region 获取机器类型id通过机器id

		/// <summary>
		/// 获取机器类型id通过机器id
		/// </summary>
		/// <param name="machineId">机器id</param>
		/// <returns>机器类型id</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.5
		/// </remarks>
		public long GetMachineTypeIdByMachineId(long machineId)
		{
			Machine machine = machineDao.SelectByPk(machineId);
			return machine.MachineType.Id;
		}

		#endregion

		#region 保存每次抄表的基本信息

		/// <summary>
		/// 保存每次抄表的基本信息
		/// </summary>
		/// <param name="iList">计算器换算纸张列表</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.7
		/// </remarks>
		[Spring.Transaction.Interceptor.Transaction]
		public void DailyRecordMachine(IList<MachineWatchConversionPaper> iList,long recordMachineWatchId)
		{
			DailyRecordMachine dailyRecordMachine = null;
			foreach (MachineWatchConversionPaper val in iList)
			{
				dailyRecordMachine = new DailyRecordMachine();
				dailyRecordMachine.Machine = new Machine();
				dailyRecordMachine.Machine.Id = val.MachineId;
				dailyRecordMachine.PaperSpecification = new PaperSpecification();
				dailyRecordMachine.PaperSpecification.Id = val.PaperId;
				dailyRecordMachine.ColorType = val.ColorType;
				dailyRecordMachine.InWatchCount = val.NewCount - val.LastCount;
				dailyRecordMachine.MakeCount = val.OrderUsePaperCount;
				dailyRecordMachine.CashCount = val.CashCount;
				dailyRecordMachine.PatchCount = val.PatchCount;
				dailyRecordMachine.Memo = string.Empty;
				dailyRecordMachine.DoWatchDateTime = DateTime.Now;
				dailyRecordMachineDao.Insert(dailyRecordMachine);
			}
			recordMachineWatchDao.UpdateIsConfirmedById(recordMachineWatchId,Constants.TRUE);
		}

		#endregion
	}
}
