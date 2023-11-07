using System;
using System.Web;
using System.Text;
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
/// 名    称: StageHandOver
/// 功能概要: 前台交班
/// 作    者: 
/// 创建时间: 
/// 修正履历: 张晓林
/// 修正时间: 2009年3月20日17:33:28
/// 修正描述:1:修改Bug,2:调整代码
/// </summary>
public partial class StageHandOver : Workflow.Web.PageBase
{
    #region //成员变量的定义

    protected bool closeFlag = false;
    protected StageHandOverModel model;
    protected string strMemberCardList;
    protected long lngHandOverId = 0;    //交班记录保存成功后返回的ID
    private const int intRowMax = 10;
    private StageHandOverAction stageHandOverAction;
    public StageHandOverAction StageHandOverAction
    {
        set { stageHandOverAction = value; }
    }
    #endregion

    #region //页面初始化
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
        model = stageHandOverAction.Model;
        if (!this.IsPostBack)
        {
            InitData();
            strMemberCardList = DoMemberCardProcess();
        }
    }
    private void InitData()
    {
        //条件：#StartTime# and #EndTime#
        Hashtable condition = new Hashtable();
        condition.Add("UserId", ThreadLocalUtils.CurrentUserContext.CurrentUser.Id);
        //开始时间 StartTime:为上次交班时间
        condition.Add("StartTime", stageHandOverAction.Stage_Work_Start_Time);
        //结束时间 EndTime
        condition.Add("EndTime", DateTime.Now.ToString());
        condition.Add("NoStatus1", Workflow.Support.Constants.ORDER_STATUS_SUCCESSED_VALUE);
        condition.Add("NoStatus2", Workflow.Support.Constants.ORDER_STATUS_BLANKOUT_VALUE);
        //获取当前用户的上次加班人
        condition.Add("LastHandOverId",stageHandOverAction.LastHandOverId);
        stageHandOverAction.InitData(condition);
    }
    #endregion

    #region //交班

    #region //保存交班记录
    /// <summary>
    /// 保存交班记录
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    protected void SaveStageHandOver(object sender, EventArgs e)
    {
        InitData();
        model.StrMemberCardList = DoMemberCardProcess();
        //获取交班的会员卡信息数据和工单信息
        PrepareModel();
        //保存数据
        lngHandOverId = stageHandOverAction.SaveHandOver(model);
        //打印数据
        PrintReport(lngHandOverId);
        Response.Write("<script>window.returnValue=true;</script>");
        //Response.Write("<script>window.close();</script>");
        //closeFlag = true;
        btnSaveStageHandOver.Enabled = false;
    }
    /// <summary>
    /// 名    称:PrintReport
    /// 功能概要：交班报表打印
    /// 作    者:张晓lin
    /// 创建时间:2009年3月21日10:54:54
    /// 修正履历：
    /// 修正时间:
    /// </summary>
    private void PrintReport(long handOverId) 
    {
        model.HandOver = new HandOver();
        model.HandOver.InsertDateTime = Convert.ToDateTime(DateTime.Now.ToShortDateString());//交班日期
        model.HandOver.HandOverDateTime = Convert.ToDateTime(Request.Form["handOverDate"]);
        model.HandOver.Employee = new Employee();
        model.HandOver.Employee.Name = ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeName;
        model.HandOver.OtherEmployee = new Employee();
        model.HandOver.OtherEmployee.Name=hiddHandOverOtherPeople.Value;
        model.HandOver.Memo = Request.Form["txtMemo"];//Request.Form[""];
        ReportStageHandOver rsHandOver = new ReportStageHandOver();
        string reportFileName = "ReportStageHandOver" + DateTime.Now.Ticks.ToString() + ".pdf";
        rsHandOver.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rsHandOver.CreateReport(model, "前台交班报表", "前台交班报表", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '前台交班', 1024, 1024 , false, false, null);</script>");
    }

    /// <summary>
    /// 将会员卡列表格式化成逗号分隔的字符串(每十个一换行)
    /// </summary>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private string DoMemberCardProcess()
    {
        StringBuilder strMemberCardList = new StringBuilder();
        int intCurCount = 0;
        if (model.MemberCardList != null)
        {
            foreach (MemberCard var in model.MemberCardList)
            {
                if ((++intCurCount % intRowMax) == 0)
                {
                    strMemberCardList.AppendFormat("{0}<br>,", var.MemberCardNo);
                }
                else
                {
                    strMemberCardList.AppendFormat("{0},", var.MemberCardNo);
                }
            }
        }
        if (strMemberCardList.Length != 0)
        {
            strMemberCardList.Remove(strMemberCardList.Length - 1, 1);
        }
        return strMemberCardList.ToString();
    }
    #endregion

    #region //准备各种前台交班数据

    /// <summary>
    /// /// 准备各种前台交班数据
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
        //准备交班时会员卡信息
        PrepareHandMemberCardListModel();
        //准备交班时工单信息
        PrepareHandOverOrderListModel();
    }
    #endregion

    #region //准备交班信息数据
    /// <summary>
    /// 准备交班信息数据
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    ///         朱静程       注释硬编程变量，增加常量
    /// 修正时间: 2008-11-04
    /// </remarks>
    private void PrepareHandOverModel()
    {
        string strMemo="";
        if (!StringUtils.IsEmpty(Request.Form["txtMemo"]))
        {
            strMemo = Request.Form["txtMemo"];
        }
        model.HandOver = new Workflow.Da.Domain.HandOver();
        //交班类型(前台交班)
        //model.HandOver.HandOverType = "1";                                                                // 2008-11-04 朱静程注释;
        model.HandOver.HandOverType = Workflow.Support.Constants.HANDER_OVER_FRONT.ToString();                         // 2008-11-04 朱静程加;

        //交班单状态(未审核)
        model.HandOver.HandOverStatus = "0";
        //交班时间
        model.HandOver.HandOverDateTime = DateTime.Now;
        //交班人(当前登陆用户的ID)
        model.HandOver.Employee = new Employee();
      
        //model.HandOver.Employee.Id = 2;                                                                   // 2008-11-04 朱静程注释;
        model.HandOver.Employee.Id = Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeId;   // 2008-11-04 朱静程加;

        //接班人
        long lngOtherEmployee = 0;
        if (!StringUtils.IsEmpty(Request.Form["sleEmployee"]))
        {
            lngOtherEmployee = long.Parse(Request.Form["sleEmployee"]);
        }
        model.HandOver.OtherEmployee = new Employee();
        model.HandOver.OtherEmployee.Id = lngOtherEmployee;
        //备注
        model.HandOver.Memo = strMemo;
    }
    #endregion

    #region //准备交班时会员卡信息
    /// <summary>
    /// 准备交班时会员卡信息
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareHandMemberCardListModel()
    {
        int intCount=0;
        model.HandOverMemberCardList=new List<HandOverMemberCard>();
        IList<HandOverMemberCard> lst=model.HandOverMemberCardList;
        foreach (MemberCard var in model.MemberCardList)
        {
            lst.Add(new HandOverMemberCard());
            //会员卡ID
            lst[intCount].MemberCardId=var.Id;
            //会员卡NO
            lst[intCount].MemberCardNo = var.MemberCardNo;
            intCount++;
        }
    }
    #endregion

    #region //准备交班时工单信息
    /// <summary>
    /// 准备交班时工单信息
    /// </summary>
    /// <remarks>
    /// 作    者: 麻少华
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间:
    /// </remarks>
    private void PrepareHandOverOrderListModel()
    {
        int intCount = 0;
        model.HandOverOrderList = new List<HandOverOrder>();
        IList<HandOverOrder> lst = model.HandOverOrderList;
        foreach (Order var in model.OrderList)
        {
            lst.Add(new HandOverOrder());
            //工单ID
            lst[intCount].OrdersId = var.Id;
            //工单号
            lst[intCount].No = var.No;
            //工单状态
            lst[intCount].Status = var.Status;
            //开单时间
            lst[intCount].InsertDateTime = var.InsertDateTime;
            //送货方式
            lst[intCount].DeliveryType = var.DeliveryType;
            //送货时间
            lst[intCount].DeliveryDateTime = var.DeliveryDateTime;
            //备注
            lst[intCount].Memo = var.Memo;
            intCount++;
        }
    }

    #endregion

    #endregion
}


