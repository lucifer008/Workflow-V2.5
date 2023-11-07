using System;
using System.Collections;
using System.Collections.Generic;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Report.HandOver;
/// <summary>
/// 名    称: CasherHandOver
/// 功能概要: 收银交班
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009年3月21日17:06:14
/// 修正描述:1:修改Bug,2:调整代码
/// </summary>
public partial class CasherHandOver : Workflow.Web.PageBase
{

    #region //ClassMember
    protected bool closeFlag=false;
    protected CashHandOverModel model;
    protected long lngHandOverId = 0;//交班记录保存成功后返回的ID

    private CashHandOverAction cashHandOverAction;
    public CashHandOverAction CashHandOverAction
    {
        set { cashHandOverAction = value; }
    }
    #endregion

    #region //Page_Load
    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Expires = -1;
        model = cashHandOverAction.Model;
        if (!this.IsPostBack)
        {
            InitData(); 
        }
        if ("True" == Request.Form["tagAction"]) 
        {
            SaveCashHandOver();
        }
    }

    private void InitData() 
    {
        Hashtable condition = new Hashtable();
        condition.Add("UserId", ThreadLocalUtils.CurrentUserContext.CurrentUser.Id);//当前用户
        string startDateTime = cashHandOverAction.CashHandOverDateTime;//交班开始时间
        string endDateTime = DateTime.Now.ToString();//交班结束时间
        condition.Add("StartTime", startDateTime);
        condition.Add("EndTime", endDateTime);
        //condition.Add("PreDeposits", Constants.PAY_KIND_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(结算)
        //condition.Add("AccountPreDepositsDiff",Constants.ACCOUNT_USE_PRE_DEPOSITS_VALUE);//客户预存款冲减(应收款处理)

        condition.Add("CompanyId", ThreadLocalUtils.CurrentUserContext.CurrentUser.CompanyId);
        condition.Add("BranchShopId", ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
        cashHandOverAction.InitData(condition);
    }
    #endregion

    #region //交班
    /// <summary>
    /// 交班
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void SaveCashHandOver()
    {
        //重新检索
        //cashHandOverAction.InitData();
        InitData();
        //准备数据
        PrepareModel();
        //保存数据
        lngHandOverId = cashHandOverAction.SaveHandOver(model);
        //输出报表
        ReportPrint();
        closeFlag = true;
    }


    /// <summary>
    /// 准备各种收银交班数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareModel()
    {
        //准备交班信息数据
        PrepareHandOverModel();
        //准备收银交班信息数据
        PrepareCashHandOverModel();
        //准备收银交班时订单信息
        PrepareCashOverOrderListModel();
    }

    /// <summary>
    /// 准备交班信息数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareHandOverModel()
    {
        string strMemo = "";
        if (!StringUtils.IsEmpty(Request.Form["txtMemo"]))
        {
            strMemo = Request.Form["textarea"];
        }
        model.HandOver = new Workflow.Da.Domain.HandOver();
        //交班类型(收银交班)
        model.HandOver.HandOverType = Constants.HANDER_OVER_CASHER.ToString();
        //交班单状态(未审核)
        model.HandOver.HandOverStatus = "0";
        //交班时间
        model.HandOver.HandOverDateTime = DateTime.Now;
        //交班人(当前登陆用户的ID)
        //model.HandOver.Employee = new Employee();
        //model.HandOver.Employee.Id =ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeId;
        model.HandOver.EmployeeId = ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeId;
        //接班人
        long lngOtherEmployee = 0;
        if (!StringUtils.IsEmpty(Request.Form["sleEmployee"]))
        {
            lngOtherEmployee = long.Parse(Request.Form["sleEmployee"]);
        }
        //model.HandOver.OtherEmployee = new Employee();
        //model.HandOver.OtherEmployee.Id = lngOtherEmployee;
        model.HandOver.EmployeeId2 = lngOtherEmployee;
        //备注
        model.HandOver.Memo = strMemo;
    }

    /// <summary>
    /// 准备收银交班信息数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareCashHandOverModel()
    {  
        model.CashHandOver = new CashHandOver();
        if (!StringUtils.IsEmpty(Request.Form["txtCashAmount"]))
        {
            //现金合计
            model.CashHandOver.CashAmount = decimal.Parse(Request.Form["txtCashAmount"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["txtCashAmount"]))
        {
            //欠条金额
            model.CashHandOver.DebtAmountSum = decimal.Parse(Request.Form["txtDebtAmountSum"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["txtDebtCount"]))
        {
            //欠条笔数
            model.CashHandOver.DebtCount = int.Parse(Request.Form["txtDebtCount"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["txtKeepBusinessRecordAmountSum"]))
        {
            //记帐合计
            model.CashHandOver.KeepBusinessRecordAmountSum = decimal.Parse(Request.Form["txtKeepBusinessRecordAmountSum"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["txtKeepBusinessRecordCount"]))
        {
            //记帐笔数
            model.CashHandOver.KeepBusinessRecordCount = int.Parse(Request.Form["txtKeepBusinessRecordCount"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["txtPayForAmountSum"]))
        {
            //结款金额
            model.CashHandOver.PayForAmountSum = decimal.Parse(Request.Form["txtPayForAmountSum"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["txtPayForCount"]))
        {
            //借款笔数
            model.CashHandOver.PayForCount = int.Parse(Request.Form["txtPayForCount"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["txtStandbyAmount"]))
        {
            //备用金
            model.CashHandOver.StandbyAmount = decimal.Parse(Request.Form["txtStandbyAmount"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["txtTicketAmountSum"]))
        {
            //发票金额
            model.CashHandOver.TicketAmountSum = decimal.Parse(Request.Form["txtTicketAmountSum"]);
        }
        if (!StringUtils.IsEmpty(Request.Form["txtMemberChargeAmount"]))
        {
            //发票金额
            model.CashHandOver.MemberCardChargeAmount = decimal.Parse(Request.Form["txtMemberChargeAmount"]);
        }
    }

    /// <summary>
    /// 准备收银交班时订单信息
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareCashOverOrderListModel()
    {
        int intCount = 0;
        model.CashHandOverOrderList = new List<CashHandOverOrder>();
        IList<CashHandOverOrder> lst = model.CashHandOverOrderList;
        foreach (Order var in model.OrderList)
        {
            lst.Add(new CashHandOverOrder());
            //订单ID
            lst[intCount].OrdersId = var.Id;
            //订单号
            lst[intCount].No = var.No;
            //订单状态
            lst[intCount].EarnestAmount = var.PrepareMoneyAmount;
            intCount++;
        }
    }

    private void ReportPrint() 
    {
        model.HandOver = new HandOver();
        model.HandOver.InsertDateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());//交班日期
        model.HandOver.HandOverDateTime = Convert.ToDateTime(Request.Form["handOverDate"]);
        model.HandOver.Employee = new Employee();
        model.HandOver.Employee.Name = ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeName;
        model.HandOver.OtherEmployee = new Employee();
        model.HandOver.OtherEmployee.Name = hiddHandOverOtherPeople.Value;
        model.HandOver.Memo = Request.Form["textarea"];
        ReportCasherHandOver rcHandOver = new ReportCasherHandOver();
        string reportFileName = "ReportCasherHandOver" + DateTime.Now.Ticks.ToString() + ".pdf";
        rcHandOver.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rcHandOver.CreateReport(model, "收银交班报表", "收银交班报表", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '收银交班', 1024, 1024 , false, false, null);</script>");
    }
    #endregion

}
