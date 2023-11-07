using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
/// <summary>
/// 名    称: IEmployeeDao
/// 功能概要: 雇员接口
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da
{
	/// <summary>
	/// Table EMPLOYEE 对应的Dao 接口
	/// </summary>
    public interface IEmployeeDao : IDaoBase<Employee>
    {
        IList<Employee> GetEmployeeList();

        IList<Employee> GetCasherEmployeeList(long positionId);
		//IList<Role> GetRoleList();

        /// <summary>
        /// 通过工单明细id获取工单明细下所有的雇工
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        IList<Employee> GetEmployeeByOrderItemId(long orderItemId);

        /// <summary>
        /// 通过雇员Id删除雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009-1-9
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        /// 
        void DeleteEmployeeInfoByEmployee(Employee employee);

         /// <summary>
        /// 查询雇员信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        /// 
        IList<Employee> SearechEmployeeInfo(Employee employee);

        /// <summary>
        /// 获取雇员信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long SearchEmployeeRowCount(Employee employee);

        /// <summary>
        /// 查询雇员职位信息信息
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年3月2日16:09:33
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        /// 
        IList<Employee> SearchEmployeePositionInfo();

        /// <summary>
        /// 获取雇员名称通过雇员id
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009年1月14日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        string GetEmployeeNameByEmployeeId(long employeeId);

        /// <summary>
        /// 检查改雇员是否正在使用
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月25日14:38:38
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long CheckEmployeeIsNotUse(long employeeId); 

         /// <summary>
        /// 获取所有雇员
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月25日14:38:38
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        IList<Employee> GetAllEmployee();

        /// <summary>
        /// 检查雇员是否已经存在
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年9月25日11:37:00
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        long checkEmployeeNameIsExist(string employeeName);


        #region//按照人员统计开单量
        /// <summary>
        /// 名    称: SearchOrderCount
        /// 功能概要: 按照人员统计开单量
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:55
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<Employee> SearchOrderCount(Employee employee);

        /// <summary>
        /// 名    称: SearchOrderCountRowCount
        /// 功能概要: 按照人员统计开单量记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:48
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        long SearchOrderCountRowCount(Employee employee);

        /// <summary>
        /// 名    称: SearchOrderCountPrint
        /// 功能概要: 按照人员统计开单量)
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:48
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<Employee> SearchOrderCountPrint(Employee employee);

        /// <summary>
        /// 名    称: SearchPosition
        /// 功能概要: 获取指定的部门
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<Position> SearchPositionByCondition(Employee employee);

        /// <summary>
        /// 名    称: SearchEmployeeByPosition
        /// 功能概要: 获取指定的部门的人员
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        IList<Employee> SearchEmployeeByPosition(Employee employee);

        /// <summary>
        /// 名    称: SearchPositionByEmployeeId
        /// 功能概要: 根据雇员Id获取岗位
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月16日11:07:37
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        Position SearchPositionByEmployeeId(Employee employee);
        #endregion
    }
}
