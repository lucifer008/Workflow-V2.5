using System;
using System.Text;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Report.HandOver;

/// <summary>
/// 名    称：StageHandOverDetail
/// 功能概要: 前台交班详情
/// 作    者: 张晓林
/// 创建时间: 2009年3月26日14:45:57
/// 修正履历：
/// 修正时间:
/// </summary>
public partial class handover_StageHandOverDetail : System.Web.UI.Page
{
    #region //ClassMember

    protected string strMem;
    protected HandOverQueryModel model;
    protected HandOver handOverDet;
    private const int intRowMax = 10;
    private HandOverQueryAction handOverQueryAction;
    public HandOverQueryAction HandOverQueryAction
    {
        set { handOverQueryAction = value; }
    }
    #endregion

    #region// Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = handOverQueryAction.Model;
        if (!IsPostBack)
        {
            BingStageHandOverDetail(Request.QueryString["HandOverId"]);
        }
    }

    private void BingStageHandOverDetail(string handOverId) 
    {
        HandOver handOver = new HandOver();
        handOver.HandOverStatus = Constants.ORDER_STATUS_SUCCESSED_VALUE.ToString();
        handOver.HandOverPerson = Constants.ORDER_STATUS_BLANKOUT_VALUE.ToString();
        handOver.Memo = handOverId;
        handOver.CurrentPageIndex = 0;
        handOver.PageRowCount = Constants.ROW_COUNT_FOR_PAGER;
        handOver.Id = Convert.ToInt32(handOverId);
        handOverQueryAction.Model.HandOver = handOver;
        handOverQueryAction.SearchHandOver();
        handOverDet = model.HandOverList[0];
        handOverQueryAction.GetHandOverOrders();
        strMem = DoMemberCardProcess();
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
        handOverQueryAction.GetHandOverMemberCard();
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

    #region //Print
    protected void btnPrintClick(object sender, EventArgs e)
    {
        ReportPrint();
    }
    private void ReportPrint()
    {
        StageHandOverModel cModel = new StageHandOverModel();
        cModel.HandOver = new HandOver();
        cModel.HandOver.InsertDateTime = Convert.ToDateTime(Request.Form["handOverDate"]);//交班日期
        cModel.HandOver.HandOverDateTime = Convert.ToDateTime(Request.Form["handOverDateTime"]);
        cModel.HandOver.Employee = new Employee();
        cModel.HandOver.Employee.Name = Request.Form["handOverPerson"];
        cModel.HandOver.OtherEmployee = new Employee();
        cModel.HandOver.OtherEmployee.Name = Request.Form["handOverOtherPerson"];
        cModel.HandOver.Memo = Request.Form["textarea"];
        cModel.StrMemberCardList = strMem;
        BingStageHandOverDetail(Request.Form["handOverId"]);
        cModel.OrderList = model.OrderList;
        cModel.StrMemberCardList =strMem;
        
        ReportStageHandOver rcHandOver = new ReportStageHandOver();
        string reportFileName = "ReportCasherHandOver" + DateTime.Now.Ticks.ToString() + ".pdf";
        rcHandOver.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rcHandOver.CreateReport(cModel, "前台交班报表", "前台交班报表", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '前台交班', 1024, 1024 , false, false, null);</script>");
    }
    #endregion
}
