using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Da.Domain;
using Workflow.Da;
using Workflow.Support;
/// <summary>
/// 名    称: EmployeeDaoImpl
/// 功能概要: 雇员接口IEmployeeDao实现类
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009-02-07
///             调整代码
/// </summary>
namespace Workflow.Da.Impl
{
	/// <summary>
	/// Table EMPLOYEE 对应的Dao 实现
	/// </summary>
    public class EmployeeDaoImpl : Workflow.Da.Base.DaoBaseImpl<Employee>, IEmployeeDao
    {

        #region IEmployeeDao 成员

       

        public IList<Employee> GetCasherEmployeeList(long positionId)
        {
            Employee employee = new Employee();
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            employee.BranchShopId = user.BranchShopId;
            employee.CompanyId = user.CompanyId;
            employee.Positionid = positionId;
            return base.sqlMap.QueryForList<Employee>("Employee.SelectCashEmployee", employee);
        }

        /// <summary>
        /// 获取所有的雇员列表
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009-1-8
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
		public IList<Employee> GetEmployeeList()
		{
			Employee employee = new Employee();
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
			employee.BranchShopId = user.BranchShopId;
			employee.CompanyId = user.CompanyId;
            return base.sqlMap.QueryForList<Employee>("Employee.SelectAllEmployee", employee);
		}

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
        public void DeleteEmployeeInfoByEmployee(Employee employee) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            employee.BranchShopId = user.BranchShopId;
            employee.CompanyId = user.CompanyId;
            base.sqlMap.Update("Employee.DeleteEmployeeInfo", employee);
        }
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
        public IList<Employee> SearechEmployeeInfo(Employee employee) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            employee.BranchShopId = user.BranchShopId;
            employee.CompanyId = user.CompanyId;
            return base.sqlMap.QueryForList<Employee>("Employee.SearchEmployeeInfo", employee);
        }
        /// <summary>
        /// 获取雇员信息记录数
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年1月9日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        /// 
        public long SearchEmployeeRowCount(Employee employee) 
        {
            User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;
            employee.BranchShopId = user.BranchShopId;
            employee.CompanyId = user.CompanyId;
            return base.sqlMap.QueryForObject<long>("Employee.SearchEmployeeInfoRowCount", employee);
        }

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
        public IList<Employee> SearchEmployeePositionInfo() 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            return sqlMap.QueryForList<Employee>("Employee.SearchEmployeePositionInfo", condition);
        }
        /// <summary>
        /// 检查改雇员是否正在使用
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月25日14:38:38
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long CheckEmployeeIsNotUse(long employeeId) 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId",ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
            condition.Add("EmployeeId", employeeId);
            return sqlMap.QueryForObject<long>("Employee.CheckEmployeeIsNotUse", condition);
        }

        /// <summary>
        /// 获取所有雇员
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年2月25日14:38:38
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public IList<Employee> GetAllEmployee() 
        {
            Hashtable condition = new Hashtable();
            condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
            condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);;
            return sqlMap.QueryForList<Employee>("Employee.GetAllEm", condition);
        }
        #endregion

        #region 通过订单明细id获取订单明细下所有的雇工

        /// <summary>
        /// 通过订单明细id获取订单明细下所有的雇工
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009-1-6
        /// 修正履历: 
        /// 修正时间:
        /// </remarks>
        public IList<Employee> GetEmployeeByOrderItemId(long orderItemId)
        {
            return sqlMap.QueryForList<Employee>("Employee.GetEmployeeByOrderItemId",orderItemId);
        }

        #endregion

        #region 获取雇员名称通过雇员id

        /// <summary>
        /// 获取雇员名称通过雇员id
        /// </summary>
        /// <remarks>
        /// 作    者: 陈汝胤
        /// 创建时间: 2009年1月14日
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public string GetEmployeeNameByEmployeeId(long employeeId)
        {
            return sqlMap.QueryForObject<string>("Employee.GetEmployeeNameByEmployeeId", employeeId);
        }

        #endregion

        #region//检查用户名称是否已经存在
        /// <summary>
        /// 检查雇员是否已经存在
        /// </summary>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2009年9月25日11:37:00
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public long checkEmployeeNameIsExist(string employeeName) 
        {
            Employee employee = new Employee();
            employee.Name = employeeName;
            employee.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            employee.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<long>("Employee.checkEmployeeNameIsExist", employee);
        }
        #endregion

        #region//按照人员统计开单量
        /// <summary>
        /// 名    称: SearchOrderCount
        /// 功能概要: 按照人员统计开单量
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:55
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Employee> SearchOrderCount(Employee employee) 
        {
            employee.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            employee.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Employee>("Employee.SearchOrderCount", employee);
        }

        /// <summary>
        /// 名    称: SearchOrderCountRowCount
        /// 功能概要: 按照人员统计开单量记录数
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:48
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public long SearchOrderCountRowCount(Employee employee) 
        {
            return sqlMap.QueryForObject<long>("Employee.SearchOrderCountRowCount", employee);
        }

        /// <summary>
        /// 名    称: SearchOrderCountPrint
        /// 功能概要: 按照人员统计开单量)
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月11日16:19:48
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Employee> SearchOrderCountPrint(Employee employee) 
        {
            return sqlMap.QueryForList<Employee>("Employee.SearchOrderCountPrint", employee);
        }

        /// <summary>
        /// 名    称: SearchPosition
        /// 功能概要: 获取指定的部门
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Position> SearchPositionByCondition(Employee employee)
        {
            employee.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            employee.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Position>("Employee.SearchPositionByCondition", employee);
        }

        /// <summary>
        /// 名    称: SearchEmployeeByPosition
        /// 功能概要: 获取指定的部门的人员
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月13日10:32:27
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Employee> SearchEmployeeByPosition(Employee employee)
        {
            return sqlMap.QueryForList<Employee>("Employee.SearchEmployeeByPosition", employee);
        }

        /// <summary>
        /// 名    称: SearchPositionByEmployeeId
        /// 功能概要: 根据雇员Id获取岗位
        /// 作    者: 张晓林
        /// 创建时间: 2009年11月16日11:07:37
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public Position SearchPositionByEmployeeId(Employee employee) 
        {
            employee.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            employee.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForObject<Position>("Employee.SearchPositionByEmployeeId", employee);
        }

        /// <summary>
        /// 名    称: SearchOrderCountDetail
        /// 功能概要: 按照人员统计开单量明细
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月5日10:18:03
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public IList<Employee> SearchOrderCountDetail(Order order) 
        {
            order.CompanyId = ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            order.BranchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            return sqlMap.QueryForList<Employee>("Employee.SearchOrderCountDetail", order);
        }

        /// <summary>
        /// 名    称: SearchOrderCountDetailRowCount
        /// 功能概要: 按照人员统计开单量明细记录数
        /// 作    者: 张晓林
        /// 创建时间: 2010年1月5日10:18:03
        /// 修正履历: 
        /// 修正时间: 
        /// </summary>
        public long SearchOrderCountDetailRowCount(Order order) 
        {
            return sqlMap.QueryForObject<long>("Employee.SearchOrderCountDetailRowCount", order);
        }

        #endregion

		#region IEmployeeDao 成员


		public IList<Employee> SearchEmployee(long positionId)
		{
			return sqlMap.QueryForList<Employee>("Employee.SearchEmployee", positionId);
		}

		#endregion

        /// <summary>
        /// 删除雇员的所有用户信息
        /// </summary>
        /// <param name="employeeId">雇员Id</param>
        /// <remarks>
        /// 作    者: 张晓林
        /// 创建时间: 2010年4月28日17:30:29
        /// 修正履历:
        /// 修正时间:
        /// </remarks>
        public void DeleteAllUserByEmployee(long employeeId) 
        {
            Employee employee=new Employee();
            employee.Id=employeeId;
            employee.CompanyId=ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId;
            employee.BranchShopId=ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
            sqlMap.Update("Employee.DeleteAllUserByEmployee",employee);
        }
    }
}
