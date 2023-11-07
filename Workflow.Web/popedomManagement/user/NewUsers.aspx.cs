using System;
using System.Collections.Generic;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Support.Encrypt;
using Workflow.Action.Permission;

/// <summary>
/// 名    称: NewUsers
/// 功能概要: 新增用户
/// 作    者: 张晓林
/// 创建时间: 2009-01-12
/// 修正履历: 
/// 修正时间: 
/// </summary>
/// 
public partial class NewUsers : Workflow.Web.PageBase
{
    #region Class Member
    protected string strTitle = "用户添加";
    protected long currentUserRoleId, employeeId, userId, isNotConcessionRange, branchShopId;
    protected string userName,password,isLogin,strRoleId;
    protected string maxApplyZero,minApplyZero,maxConcessionMoney,minConcessionMoney,maxDiscount,minDiscount;
	private UserAction userAction;
	public UserAction UserAction
	{
		set { userAction = value; }
		get { return userAction; }
	}
	#endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
		if (!IsPostBack)
		{
            InitData();		
		}
        branchShopId = ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId;
		userAction.GetAllRole();
        BingUpdateUserInfo();
    }
    /// <summary>
	/// 初始化数据
	/// </summary>
	private void InitData()
	{
		 userAction.GetAllEmployee();
        this.sltEmployee.DataSource = userAction.Model.EmployeeList;
        this.sltEmployee.DataTextField = "Name";
        this.sltEmployee.DataValueField = "Employeeid";
        this.sltEmployee.DataBind();
    }

    protected void BingUpdateUserInfo() 
    {
        
        if (null != Request.QueryString["UserId"] && "" != Request.QueryString["UserId"].ToString())
        {
            Response.Expires = -1;
            strTitle = "编辑用户";
            User user = new User();
            user.EmployeeName = Request.QueryString["UserId"].ToString();//人员Id
            userAction.Model.User = user;
            user.CurrentPageIndex = 0;
            user.RowCount = Constants.ROW_COUNT_FOR_PAGER;
            userAction.GetAllUser();
            if (userAction.Model.UserList.Count > 0)
            {
                user = userAction.Model.UserList[0];
                userId = Convert.ToInt32(Request.QueryString["UserId"]);
                strRoleId = Request.QueryString["RoleId"];
                userName = user.UserName;
                employeeId = user.EmployeeId;
                password = user.Password;
                isLogin = user.IsLogin;
                isNotConcessionRange = userAction.CheckUserIsNotConcessionRange(userId);
                userAction.SearchUserConcessionRange(userId);
                foreach(UserConcessionRange ucr in userAction.Model.UserConcessionRanageList)
                {
                    //抹零
                    if(ucr.ConcessionType==Constants.CONCESSION_TYPE_ZERO_VALUE)
                    {
                        maxApplyZero = ucr.Max.ToString();
                        minApplyZero = ucr.Min.ToString();
                        continue;
                    }
                    //优惠
                    if(ucr.ConcessionType==Constants.CONCESSION_TYPE_CONCESSION_VALUE)
                    {
                        maxConcessionMoney = Convert.ToString(ucr.Max*100);
                        minConcessionMoney = Convert.ToString(ucr.Min*100);
                        continue;
                    }
                    //折让
                    if(ucr.ConcessionType==Constants.CONCESSION_TYPE_RENDERUP_VALUE)
                    {
                        maxDiscount = Convert.ToString(ucr.Max*100);
                        minDiscount = Convert.ToString(ucr.Min*100);
                        continue;
                    }
                }
            }
        }
    }
    #endregion

    #region Save
	protected void addUser(object sender, EventArgs e)
	{
		try
		{
			string[] chkRole;
			if (Request.Form["cbBoxRole"] != null)
			{
				  chkRole = Request.Form["cbBoxRole"].ToString().Split(',');//获取选中的角色数组

                  //当用户有优惠范围时，添加优惠范围
                userAction.Model.IsNullUserConcessionRanage=false;
                if("True"==hiddTag.Value)
                {
                    List<UserConcessionRange> userConcessionRanageList = new List<UserConcessionRange>();
                    UserConcessionRange userConcessionApply = new UserConcessionRange();//抹零
                    userConcessionApply.Max = Convert.ToDecimal(Request.Form["txtMaxApplyZero"]);
                    userConcessionApply.Min = Convert.ToDecimal(Request.Form["txtMinApplyZero"]);
                    userConcessionApply.ConcessionType = Constants.CONCESSION_TYPE_ZERO_VALUE;
                    userConcessionRanageList.Add(userConcessionApply);
                    UserConcessionRange userConcessionCon = new UserConcessionRange();//优惠
                    userConcessionCon.Max = Convert.ToDecimal(Request.Form["txtMaxConcessionMoney"]) / 100;
                    userConcessionCon.Min = Convert.ToDecimal(Request.Form["txtMinConcessionMoney"]) / 100;
                    userConcessionCon.ConcessionType = Constants.CONCESSION_TYPE_CONCESSION_VALUE;
                    userConcessionRanageList.Add(userConcessionCon);
                    UserConcessionRange userConcessionDiscount = new UserConcessionRange();//折让
                    userConcessionDiscount.Max = Convert.ToDecimal(Request.Form["txtMaxDiscountMoney"]) / 100;
                    userConcessionDiscount.Min = Convert.ToDecimal(Request.Form["txtMinDiscountMoney"])/100;
                    userConcessionDiscount.ConcessionType = Constants.CONCESSION_TYPE_RENDERUP_VALUE;
                    userConcessionRanageList.Add(userConcessionDiscount);
                    userAction.Model.UserConcessionRanageList = (IList<UserConcessionRange>)userConcessionRanageList;
                    userAction.Model.IsNullUserConcessionRanage = true;
                }
                if (null != hiddUserId.Value && "" != hiddUserId.Value.ToString())//Request.Form["hiddUserId"] && "" != Request.Form["hiddUserId"].ToString())//修改
                {
                    User user = new User();
                    user.EmployeeId = Int32.Parse(sltEmployee.SelectedValue);//雇员ID
                    user.UserName = Request.Form["txtUserName"];	//用户名
                    user.Password =Request.Form["txtUserPassword"]; //密码
                    user.Id = Convert.ToInt32(hiddUserId.Value);//Request.Form["hiddUserId"]);
                    user.IsLogin = hiddIsLogin.Value; //Request.Form["hiddIsLogin"].ToString();
                    //user.RoleId = Convert.ToInt32(hiddRoleId.Value);//Request.Form["hiddRoleId"]);
                    userAction.Model.User = user;
                    userAction.UpdateUserInfo(chkRole);
                    Response.Write("<script>window.returnValue='yes'</script>");
                    Response.Write("<script>window.close();</script>");
                }
                else //添加
                {
                    User user = new User();
                    user.EmployeeId = Int32.Parse(sltEmployee.SelectedValue);//雇员ID
                    user.UserName = Request.Form["txtUserName"];	//用户名
                    user.Password = EncryptUtils.HexMD5(Request.Form["txtUserPassword"]); //密码
                    user.IsLogin =Constants.FALSE;
                    userAction.Model.User = user;
                    userAction.AddUserInfo(chkRole);
                }
			
			}
		}
		catch (Exception ex) 
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
		}
	}

    #endregion
}
