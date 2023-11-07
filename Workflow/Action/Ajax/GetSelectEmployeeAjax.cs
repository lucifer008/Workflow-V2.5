using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using System.Collections.Specialized;
using Workflow.Service.SystemPermission.EmployeeManage;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Util;
using Workflow.Service.OrderManage;

namespace Workflow.Action.Ajax
{
	public class GetSelectEmployeeAjax : AjaxProcess
	{
		#region AjaxProcess 成员

		#region inject

		private IEmployeeService employeeService;
		/// <summary>
		/// employeeService
		/// </summary>
		public IEmployeeService EmployeeService
		{
			set { employeeService = value; }
		}

		private IOrderService orderSerivce;
		/// <summary>
		/// orderSerivce
		/// </summary>
		public IOrderService OrderService
		{
			set { orderSerivce = value; }
		}



		#endregion

		

		public string DoProcess(NameValueCollection parameters)
		{
			User user = ThreadLocalUtils.CurrentUserContext.CurrentUser;

            string orderNo = parameters["orderNo"];

			SelectEmployeeModel model=new SelectEmployeeModel();
			//获取前期的雇员
			model.Employees = employeeService.SearechEmployee(Constants.POSITION_PROPHASE_VALUE(user.BranchShopId));
			foreach (Workflow.Da.Domain.Employee employee in model.Employees)
			{
				employee.IsProphase = 1;
			}
			IList<Workflow.Da.Domain.Employee> employees = employeeService.SearechEmployee(Constants.POSITION_ANAPHASE_VALUE(user.BranchShopId));
			foreach (Workflow.Da.Domain.Employee employee in employees)
			{
				model.Employees.Add(employee);
			}

			model.OrderItems = orderSerivce.GetOrderItemByOrderNo(orderNo);
            model.OrderItemList = orderSerivce.GetOrderItemFactorValueByOrderNo(orderNo);
            orderSerivce.GetFactorValueText(model.OrderItemList);

            foreach (OrderItem oi in model.OrderItems)
            {
                foreach (OrderItem o in model.OrderItemList)
                {
                    if (oi.Id == o.Id && o.TargetTable.ToUpper().Equals("PROCESS_CONTENT"))
                    {
                        oi.Name = o.Name;
                    }
                }
            }
			
	
			IDictionary<Type, string> jsonObj = new Dictionary<Type, string>();
			jsonObj.Add(typeof(SelectEmployeeModel), "Employees,OrderItems");
			jsonObj.Add(typeof(Workflow.Da.Domain.Employee), "Id,Name,IsProphase");
			jsonObj.Add(typeof(Workflow.Da.Domain.OrderItem), "Id,BusinessTypeId,Amount,Name");

			return JSONUtils.ToJSONString(model, jsonObj);
		}

		#endregion
	}
	public class SelectEmployeeModel
	{
		#region OrderItem
		
		private IList<OrderItem> orderItems;
		/// <summary>
		/// OrderItem
		/// </summary>
		public IList<OrderItem> OrderItems
		{
			get { return orderItems; }
			set { orderItems = value; }
		}

		#endregion


        private IList<OrderItem> orderItemList;
        public IList<OrderItem> OrderItemList
        {
            set {  orderItemList=value; }
            get { return orderItemList; }
        }

		#region 雇员

		private IList<Workflow.Da.Domain.Employee> employees;
		/// <summary>
		/// 雇员
		/// </summary>
		public IList<Workflow.Da.Domain.Employee> Employees
		{
			get { return employees; }
			set { employees = value; }
		}

		#endregion

	}
}
