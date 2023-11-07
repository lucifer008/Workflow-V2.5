using System;
using System.Collections.Generic;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Employee;
using Workflow.Action.Employee.Model;

/// <summary>
/// 名    称: UsersEmployeeList
/// 功能概要: 雇员一览
/// 作    者: 张晓林
/// 创建时间: 2009-01-8
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// 
public partial class UsersEmployeeList : Workflow.Web.PageBase
{

    #region //Class Member
    private EmployeeAction employeeAction;
    public EmployeeAction EmployeeAction 
	{
        set { employeeAction = value; }
        get { return employeeAction; }
	}

    protected EmployeeModel model;
    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = employeeAction.Model;
            if (!IsPostBack)
            {
                InitData();
                QueryNextPageData(1);
            }
            //删除雇员信息
            DeleteEmployeeInfo();
            //变价雇员信息
            EdmitUserInfo();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    } 
    private void InitData() 
    {
        ///获取雇员
        employeeAction.GetAllEmployee();
        this.selEmployeeList.DataSource = employeeAction.Model.EmployeeList;
        this.selEmployeeList.DataTextField = "Name";
        this.selEmployeeList.DataValueField = "Employeeid";
        this.selEmployeeList.DataBind();

        employeeAction.GetAllPosition();
        this.selPositionList.DataSource = employeeAction.Model.PositionList;
        this.selPositionList.DataTextField = "Name";
        this.selPositionList.DataValueField = "Id";
        this.selPositionList.DataBind();
    }
    #endregion

    #region //Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Employee employee = new Employee();
        if ("-1"!= selPositionList.SelectedValue)
        {
            employee.No = selPositionList.SelectedItem.Text.Trim();//.SelectedValue;
        }
        if ("-1" != selEmployeeList.SelectedValue)
        {
            employee.Name = selEmployeeList.SelectedItem.Text.Trim();//.SelectedValue;
        }

        employee.CurrentPageIndex = 0;
        employee.RowCount = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
        employeeAction.Model.Employee = employee;
        employeeAction.SearchEmployeeInfo();
        AspNetPager1.CurrentPageIndex = 1;
        AspNetPager1.PageSize = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(employeeAction.SearchEmployeeInfoRowCount());

        ViewState.Add("selPositionList", employee.No);
        ViewState.Add("selEmployeeList", employee.Name);
    }

    public string[] GetEmployeePositionStringByEmployeeId(long employeeId) 
    {
        return employeeAction.GetEmployeePositionStringByEmployeeId(employeeId);
    }
    #endregion

    #region //Edmit Employee
    private void EdmitUserInfo()
    {
        if (null != Request.Form["hiddTag"] && "Edmit" == Request.Form["hiddTag"])
        {
            Employee employee = new Employee();
            employee.RowCount = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
            employee.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex - 1;
            employeeAction.Model.Employee = employee;
            employeeAction.SearchEmployeeInfo();
            AspNetPager1.PageSize = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(employeeAction.SearchEmployeeInfoRowCount());
            AspNetPager1.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex;
            //QueryNextPageData(1);
        }
    }
    #endregion

    #region //Delete Employee
    private void DeleteEmployeeInfo()
    {
        if (null != Request.Form["hiddTag"] && "T" == Request.Form["hiddTag"].ToString())
        {
            Employee employee = new Workflow.Da.Domain.Employee();
            employee.Employeeid = Convert.ToInt32(Request.Form["hiddEmployeeId"]);
            //employee.Positionid = Convert.ToInt32(Request.Form["hiddPositionId"]);
            employee.CurrentPageIndex = 0;
            employee.RowCount = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
            employeeAction.Model.Employee = employee;
            employeeAction.DeleteEmployee();
            QueryNextPageData(1);
        }
    }
    #endregion

    //private void SearchEmployeeInfo()
    //{
    //    //按照雇员和岗位查询
    //    if (null != Request.Form["hiddTag"] && "F" == Request.Form["hiddTag"].ToString())
    //    {
    //        Employee employee = new Employee();
    //        if ("-1" != selPositionList.SelectedValue)
    //        {
    //            employee.No = selPositionList.SelectedValue;
    //        }
    //        if ("-1" != selEmployeeList.SelectedValue)
    //        {
    //            employee.Name = selEmployeeList.SelectedValue;
    //        }
    //        employee.CurrentPageIndex = AspNetPager1.CurrentPageIndex-1;
    //        employee.RowCount = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
    //        employeeAction.Model.Employee = employee;
    //        employeeAction.SearchEmployeeInfo();
    //        AspNetPager1.CurrentPageIndex = 1;
    //        AspNetPager1.RecordCount = Convert.ToInt32(employeeAction.SearchEmployeeInfoRowCount());
    //        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
    //    }
    //}

    #region //分页处理
    private void QueryNextPageData(int currentPageIndex)
    {
        Employee employee = new Employee();
        if (null != ViewState["selPositionList"] && "" != ViewState["selPositionList"].ToString())
        {
            employee.No = ViewState["selPositionList"].ToString();
        }
        if (null != ViewState["selEmployeeList"] && "" != ViewState["selEmployeeList"].ToString())
        {
            employee.Name = ViewState["selEmployeeList"].ToString();
        }
        employee.CurrentPageIndex = currentPageIndex - 1;
        employee.RowCount = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.CurrentPageIndex = currentPageIndex;
        employeeAction.Model.Employee = employee;
        employeeAction.SearchEmployeeInfo();
        AspNetPager1.PageSize = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(employeeAction.SearchEmployeeInfoRowCount());

        ViewState.Add("selPositionList", ViewState["selPositionList"]);
        ViewState.Add("selEmployeeList", ViewState["selEmployeeList"]);
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
