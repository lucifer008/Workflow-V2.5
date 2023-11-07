using System;
using System.Text;
using System.Collections.Generic;
using Workflow.Da.Domain;
using Workflow.Action.LogCounters;
using System.Collections;

namespace Workflow.Service.LogCounterManage
{
    /// <summary>
    /// 名    称: ILogCountersService
    /// 功能概要: 机器抄表相关接口声明
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-19
    /// 修 正 人: 付强
    /// 修正时间: 2009-1-22
    /// 描    述: 代码整理
	/// 修 正 人: 陈汝胤
	/// 修正时间: 2009.4.22
	/// 描    述: 完成未完成的功能
    /// </summary>
    public interface ILogCountersService
    {
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
        void SaveUncompleteOrdersUsedPaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper);
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
        void UpdateUncompleteOrdersUsedPaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper);
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
        void DeleteUncompleteOrdersUsedPaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper);
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
        void SaveCompensateUsedPaper(CompensateUsedPaper compensateUsedPaper, IList<CompensateEmployee> compensateEmployeeList);

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
        void UpdateCompensateUsedPaper(CompensateUsedPaper compensateUsedPaper, IList<CompensateEmployee> compensateEmployeeList);

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
        void DeleteCompensateUsedPaper(long id);
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
        void SaveCompensateEmployee(IList<CompensateEmployee> compensateEmployeeList);
        /// <summary>
        /// 名    称: SaveLogCounter
        /// 功能概要: 保存抄表记录
        /// 作    者: 
        /// 创建时间: 
        /// 修 正 人: 付强
        /// 修正时间: 2009-1-22
        /// 描    述: 代码整理
        /// </summary>
        /// <param name="recordMachineWatch"></param>
        /// <param name="machineWatchRecordLogList"></param>
        /// <param name="uncompleteOrdersUsedPaperList"></param>
        void SaveLogCounter(RecordMachineWatch recordMachineWatch, IList<MachineWatchRecordLog> machineWatchRecordLogList, IList<UncompleteOrdersUsedPaper> uncompleteOrdersUsedPaperList);
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
        void SaveMachineWatchRecordCheckData(IList<DailyRecordMachine> dailyRecordMachineList);

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
        IList<MachineType> GetMachineTypeList();
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
        IList<UncompleteOrdersUsedPaper> GetUncompleteOrdersUsedPaperList();
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
        IList<CompensateUsedPaper> GetCompensateUsedPaperList();
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
        IList<Employee> GetCompensateEmployeeList();
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
        RecordMachineWatch GetRecordMachineWatchById(long id);
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
        CompensateUsedPaper GetCompensateUsedPaperById(long id);
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
        IList<MachineWatchScale> GetLastNumberByMachineId(long id);
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
        IList<MachineWatchConversionPaper> GetMachineWatchRecordCheckDataList(MachineWatchConversionPaper machineWatchConversionPaper, long lngRecordMachineWatchId);
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
        int GetMachineWatchRecordMakeCount(MachineWatchConversionPaper machineWatchConversionPaper, long lngRecordMachineWatchId);
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
        int GetMachineWatchRecordPatchCount(CompensateUsedPaper compensateUsedPaper);

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
        IList<DailyRecordMachine> GetDailyRecordMachineListCustomQuery(DailyRecordMachine dailyRecordMachine);

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
        IList<DailyRecordMachine> GetDailyRecordMachineListCustomQueryPrint(DailyRecordMachine dailyRecordMachine);

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
        long GetDailyRecordMachineListCustomQueryRowCount(DailyRecordMachine dailyRecordMachine);

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
        string GetMachineWatchByComputeFormula(MachineWatchConversionPaper machineWatchConversionPaper, long lngRecordMachineWatchId);
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
        int GetMachineWatchValue(MachineWatchRecordLog machineWatchRecordLog);

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
        RecordMachineWatch GetLastTimeRecordMachineWatch(RecordMachineWatch recordMachineWatch);

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
        OrdersForRecordMachineSum GetOrdersForRecordMachineSum(OrdersForRecordMachineSum ordersForRecordMachineSum);
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
        UncompleteOrdersUsedPaper GetUncompeleteOrderUsePaper(UncompleteOrdersUsedPaper uncompleteOrdersUsedPaper);
        #endregion

		#region 获取机器上的表的最新刻度
		/// <summary>
		/// 功能概要: 获取机器上的表的最新刻度
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009-2-10
		/// </remarks>
		IList<Machine> GetNeedRecordWarchMachineAndMachineWatch();

		#endregion

		#region 获取需要抄表的机器和机器上的表
		
		/// <summary>
		/// 获取需要抄表的机器和机器上的表
		/// </summary>
		/// <param name="machineList">机器列表</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.22
		/// </remarks>
		IList<Machine> GetNeedRecordWarchMachine();

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
		IList<PaperSpecification> GetPaperSpecification();

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
		RecordMachineWatch GetCanUsedRecordMachineWatch();

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
		void AddUncompleteOrderUsedPaper(UncompleteOrdersUsedPaper uncompleteOrderUsedPaper);
		
		#endregion

		#region 获取未完工工单列表通过抄表id

		/// <summary>
		/// 获取未完工工单列表通过抄表id
		/// </summary>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <returns>UncompleteOrdersUsedPaperList</returns>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		IList<UncompleteOrdersUsedPaper> GetUncompleteOrderByRecordWatchId(long recordMachineWatchId);

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
		void DeleteUnCompensateUsedPaper(long uncompleteOrderUsedPaperId);

		#endregion

		#region 清理未完成核实抄表记录的相关数据

		/// <summary>
		/// 清理未完成核实抄表记录的相关数据
		/// </summary>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.4.24
		/// </remarks>
		void CleanUpUncompleteRecordWatchData();

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
		RecordMachineWatch GetLastRecordMachineWatch();

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
		int GetLastMachineWatchNumber(long recordMachineWatchId, long machineWatchId);
		
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
		void SaveVerifyRecordWatchData(MachineWatchRecordLog machineWatchRecordLog);

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
		IList<MachineWatchConversionPaper> GetAllMachineWatchConversionPaper();

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
		IList<MachineWatchRecordLog> GetNeedVerifyRecordLog(long recordMachineWatchId, long machineId);

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
		int GetVerifyRecordWatchCompleteOrderUsedCount(Hashtable map);

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
		int GetCompensateUsedPaperCount(long recordMachineWatchId, long machineId, long paperId, string colorType);

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
		UncompleteOrdersUsedPaper GetUncompeleteOrderUsePaperById(long id);

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
		long GetMachineTypeIdByMachineId(long machineId);

		#endregion


		#region 保存每次抄表的基本信息

		/// <summary>
		/// 保存每次抄表的基本信息
		/// </summary>
		/// <param name="iList">计算器换算纸张列表</param>
		/// <param name="recordMachineWatchId">抄表id</param>
		/// <remarks>
		/// 作    者: 陈汝胤
		/// 创建时间: 2009.5.7
		/// </remarks>
		void DailyRecordMachine(IList<MachineWatchConversionPaper> iList,long recordMachineWatchId);

		#endregion
		
	}
}
