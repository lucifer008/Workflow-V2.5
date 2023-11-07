using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Service.OrderManage;
using Workflow.Service.LogCounterManage;

namespace Workflow.Action
{
    /// <summary>
    /// 名    称: Workflow.Action.LogCountersAction
    /// 功能概要: 机器抄表,查询,换算等
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-17
    /// 修 正 人: 付强
    /// 修正时间: 2007-9-13
    /// 描    述: 代码整理
    /// </summary>
    public sealed class LogCountersAction :BaseAction
    {
        #region 类成员
        /// <summary>
        /// 基本Master
        /// </summary>
        private IMasterDataService masterDataService;
        public IMasterDataService MasterDataService
        {
            set { masterDataService = value; }
        }
        /// <summary>
        /// 机器抄表
        /// </summary>
        private ILogCountersService logCountersService;
        public ILogCountersService LogCountersService
        {
            set { logCountersService = value; }
        }
        /// <summary>
        /// 工单
        /// </summary>
        private IOrderService orderService;
        public IOrderService OrderService
        {
            set { orderService = value; }
        }
        /// <summary>
        /// 机器抄表Model
        /// </summary>
        private LogCountersModel model = new LogCountersModel();
        public LogCountersModel Model
        {
            get { return model; }
        }
        #endregion 对象传递

        #region 初始化
        /// <summary>
        /// 初始化
        /// </summary>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void InitData()
        {

            //机器类型
            model.MachineTypeList = logCountersService.GetMachineTypeList();
            //工单
            //model.OrderList = orderService.SelectDailyOrder();
            //机器
            model.MachineList = masterDataService.GetMachineList();
            //纸型
            model.PaperSpecificationList = masterDataService.GetPaperSpecificationList();
        }

        /// <summary>
        /// 初始化(机器抄表核对页面)
        /// </summary>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void InitCheckData(MachineWatchConversionPaper machineWatchConversionPaper, long lngRecordMachineWatchId)
        {
            //机器抄表数据转换成纸张的数据
            model.MachineWatchConversionPaperList = logCountersService.GetMachineWatchRecordCheckDataList(machineWatchConversionPaper, lngRecordMachineWatchId);
            //抄表记录
            model.RecordMachineWatch = logCountersService.GetRecordMachineWatchById(lngRecordMachineWatchId);
        }

        /// <summary>
        /// 初始化数据(新增补单页面)
        /// </summary>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void InitCompensateData()
        {
            ////机器类型
            //model.MachineTypeList = logCountersService.GetMachineTypeList();
            //机器
            model.MachineList = masterDataService.GetMachineList();
            //纸型
            model.PaperSpecificationList = masterDataService.GetPaperSpecificationList();
            //责任人
            model.EmployeeList = masterDataService.GetEmployeeList();

			if (0 != model.CompensateUsedPaperId)
			{
				CompensateUsedPaper compensateUsedPaper = logCountersService.GetCompensateUsedPaperById(model.CompensateUsedPaperId);
				model.MachineId = compensateUsedPaper.Machine.Id;
				model.PaperId = compensateUsedPaper.PaperSpecification.Id;
				model.PaperColor = compensateUsedPaper.ColorType;
				model.CompensateCount = compensateUsedPaper.UsedPaperCount;
				foreach (Workflow.Da.Domain.Employee employee in compensateUsedPaper.EmployeeList)
				{
					model.EmployeeNameList.Add(employee.Name);
				}
			}
        }

        /// <summary>
        /// 初始化数据(编辑补单页面)
        /// </summary>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void InitEditCompensateData(long id)
        {
            ////机器类型
            //model.MachineTypeList = logCountersService.GetMachineTypeList();
            //机器
            model.MachineList = masterDataService.GetMachineList();
            //纸型
            model.PaperSpecificationList = masterDataService.GetPaperSpecificationList();
            ////责任人
            model.EmployeeList = masterDataService.GetEmployeeList();
            //补单用纸情况
            model.CompensateUsedPaper = logCountersService.GetCompensateUsedPaperById(id);
        }

        /// <summary>
        /// 获得最后一次的读数
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void GetLastNumber(long id)
        {
            model.MachineWatchScaleList = logCountersService.GetLastNumberByMachineId(id);
        }

        /// <summary>
        /// 初始化计数器查询页面
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-23
        /// 修正履历: 张晓林
        /// 修正时间:2009年4月27日10:43:43
        /// 修正描述:增加分页功能
        /// </remarks>
        public void InitDailyRecordMachineCustomQuery()
        {
            //计数器查询结果
            model.DailyRecordMachineList = logCountersService.GetDailyRecordMachineListCustomQuery(Model.DailyRecordMachine);
            model.DailyRecordMachineRecordCount = logCountersService.GetDailyRecordMachineListCustomQueryRowCount(Model.DailyRecordMachine);
        }

        /// <summary>
        ///获取计数器打印数据 
        /// </summary>
        ///<remarks>
        /// 作    者:张晓林
        /// 创建时间:2009年4月27日11:07:29
        /// 修正履历:
        /// 修正时间:
        /// 修正描述:
        ///</remarks>
        public void GetDailyRecordMachineListCustomQueryPrint() 
        {
            model.DailyRecordMachineTempList = logCountersService.GetDailyRecordMachineListCustomQueryPrint(Model.DailyRecordMachine);
        }
        #endregion

        #region 业务处理
        /// <summary>
        /// 保存机器抄表(机器抄表页面)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public long SaveLogCounters(LogCountersModel model)
        {
            logCountersService.SaveLogCounter(model.RecordMachineWatch, model.MachineWatchRecordLogList, model.UncompleteOrdersUsedPaperList);
            return model.RecordMachineWatch.Id;
        }

        /// <summary>
        /// 保存补单(新增补单页面)
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void SaveCompensate()
        {
            //保存补单
            logCountersService.SaveCompensateUsedPaper(model.CompensateUsedPaper, model.CompensateEmployeeList);
        }

        /// <summary>
        /// 修改补单(编辑补单页面)
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-18
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void UpdateCompensate()
        {
            //修改补单
            logCountersService.UpdateCompensateUsedPaper(model.CompensateUsedPaper, model.CompensateEmployeeList);
        }

        /// <summary>
        /// 删除补单
        /// </summary>
        /// <param name="id"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-19
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void DeleteCompensate(long id)
        {
            //删除补单
            logCountersService.DeleteCompensateUsedPaper(id);
        }

        /// <summary>
        /// 每次抄表基本信息记录
        /// </summary>
        /// <param name="model"></param>
        /// <remarks>
        /// 作    者: 麻少华
        /// 创建时间: 2007-10-22
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public void SaveMachineWatchRecordCheckData(LogCountersModel model)
        {
            logCountersService.SaveMachineWatchRecordCheckData(model.DailyRecordMachineList);
        }

        public void GetMachineList() 
        {
            //机器一览
            model.MachineList = masterDataService.GetMachineList();
        }
        #endregion

		#region 获取补单信息

		/// <summary>
		/// 获取补单信息
		/// </summary>
		/// <returns>补单信息</returns>
		public void GetCompensateUsedPaper()
		{
			model.CompensateUsedPaper=logCountersService.GetCompensateUsedPaperById(model.CompensateUsedPaperId);
		}

		#endregion
	}
}
