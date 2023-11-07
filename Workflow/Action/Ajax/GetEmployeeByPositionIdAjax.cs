using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using Workflow.Util;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Da.Domain;
using Workflow.Action.Employee;
using Workflow.Action.Employee.Model;
using Workflow.Service.SystemPermission.PositionManage;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: GetEmployeeByPositionIdAjax
    /// 功能概要: 根据岗位获取岗位下的所有雇员
    /// 作    者: 张晓林
    /// 创建时间: 2009年2月26日10:28:01
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class GetEmployeeByPositionIdAjax:AjaxProcess
    {
        #region //依赖注入Service
        private IPositionService positionService;
        public IPositionService PositionService 
        {
            set { positionService = value; }
        }
        private EmployeeAction employeeAction;
        public EmployeeAction EmployeeAction 
        {
            set { employeeAction = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            if (null == parameters["PositionId"])
            {
                return null;
            }
            else 
            {
                Hashtable condition = new Hashtable();
                condition.Add("PositionId", parameters["PositionId"]);
                employeeAction.Model.EmployeeList=positionService.GetEmployeeListByPositionId(condition);

                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(EmployeeModel), "EmployeeList");
                jsonDic.Add(typeof(Workflow.Da.Domain.Employee),"Employeeid,Name");
               return JSONUtils.ToJSONString(employeeAction.Model, jsonDic);
            }
        }
    }
}
