using System;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Employee;
using Workflow.Action.Permission;
using Workflow.Action.Employee.Model;
/// <summary>
/// 名    称: NewEmployee
/// 功能概要: 新增雇员
/// 作    者: 张晓林
/// 创建时间: 2009-01-8
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// 
public partial class popedomManagement_NewUsers: Workflow.Web.PageBase
{

	#region Class Member
    protected int employeeId = 0;
    protected string employeeName = "";
    protected string strPositionId;

    private EmployeeAction employeeAction;
    public EmployeeAction EmployeeAction
	{
        set { employeeAction = value; }
        get { return employeeAction; }
	}

    protected EmployeeModel model;
	#endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = employeeAction.Model;
            InitData();
            if (!IsPostBack) 
            {
                BingEmployeeInfo();
            }
        }
        catch(Exception ex)
        {
            Workflow.Support.Log.LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    private void BingEmployeeInfo() 
    {
        Response.Expires = -1;//清除页面缓存
        if (null != Request.QueryString["EmployeeId"] && "" != Request.QueryString["EmployeeId"].ToString())
        {
            employeeId = Convert.ToInt32(Request.QueryString["EmployeeId"]);
            strPositionId = Request.QueryString["PositionId"];
            employeeName =Request.QueryString["EmployeeName"];
        } 
    }
    private void InitData()
	{
		///获取岗位
        employeeAction.GetAllPosition();
    }
    #endregion

    #region Save
    protected void addEmployee(object sender, EventArgs e)
	{
		try
		{
			string[] chkPosition;	//所属岗位
			if (Request.Form["cbPosition"] != null)
			{
				chkPosition = Request.Form["cbPosition"].ToString().Split(',');//获取选中的岗位

                if (null != Request.Form["hiddEmployeeId"] && ""!=Request.Form["hiddEmployeeId"].ToString())//修改
                {
                    Employee employee = new Employee();
                    employee.Employeeid = Convert.ToInt32(Request.Form["hiddEmployeeId"]);
                    employee.Name = Request.Form["txtEmployName"]; //雇员名称
                    employeeAction.Model.Employee = employee;
                    employeeAction.UpdateEmployee(chkPosition);
                    Response.Write("<script>window.returnValue='yes'</script>");
                    Response.Write("<script>window.close();</script>");
                }
                else //添加
                {
                    Employee employee = new Employee();
                    employee.Name = Request.Form["txtEmployName"]; //雇员名称
                    employeeAction.Model.Employee = employee;
                    employeeAction.AddEmployee(chkPosition);
                }
			}
			
		}
		catch(Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
		}
    }
    #endregion
}
