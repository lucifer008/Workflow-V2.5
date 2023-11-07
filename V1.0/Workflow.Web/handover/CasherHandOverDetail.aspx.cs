using System;
using iTextSharp.text;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Report.HandOver;
/// <summary>
/// 名    称：CasherHandOverDetail
/// 功能概要: 收银交班详情
/// 作    者: 张晓林
/// 创建时间: 2009年3月26日14:45:57
/// 修正履历：
/// 修正时间:
/// </summary>
public partial class handover_CasherHandOverDetail : System.Web.UI.Page
{
    #region //ClassMember

    protected HandOverQueryModel model;
    protected HandOver handOverDet;
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
            BingCasherHandOverDetail(Request.QueryString["HandOverId"]);
        }
    }

    private void BingCasherHandOverDetail(string handOverId)
    {
        HandOver handOver = new HandOver();
        handOver.Memo = handOverId;
        handOver.CurrentPageIndex = 0;
        handOver.PageRowCount = Constants.ROW_COUNT_FOR_PAGER;
        handOver.Id = Convert.ToInt32(handOverId);
        handOverQueryAction.Model.HandOver = handOver;
        handOverQueryAction.SearchHandOver();
        handOverDet = model.HandOverList[0];
        handOverQueryAction.GetFundDetail();//获取款项详情
        //strMem = DoMemberCardProcess();
    }
    #endregion

    #region //Print
    protected void btnPrintClick(object sender, EventArgs e)
    {
        ReportPrint();
    }
    private void ReportPrint()
    {
        CashHandOverModel cModel = new CashHandOverModel();
        cModel.HandOver = new HandOver();
        cModel.HandOver.InsertDateTime = Convert.ToDateTime(Request.Form["handOverDate"]);//交班日期
        cModel.HandOver.HandOverDateTime = Convert.ToDateTime(Request.Form["handOverDateTime"]);
        cModel.HandOver.Employee = new Employee();
        cModel.HandOver.Employee.Name = Request.Form["handOverPerson"];
        cModel.HandOver.OtherEmployee = new Employee();
        cModel.HandOver.OtherEmployee.Name = Request.Form["handOverOtherPerson"];
        cModel.HandOver.Memo = Request.Form["textarea"];
        BingCasherHandOverDetail(Request.Form["handOverId"]);
        cModel.OrderList = model.OrderList;
        cModel.CashHandOver = model.CashHandOver;

        ReportCasherHandOver rcHandOver = new ReportCasherHandOver();
        string reportFileName = "ReportCasherHandOver" + DateTime.Now.Ticks.ToString() + ".pdf";
        rcHandOver.FileName = Server.MapPath("~") + @"\reports\" + reportFileName;
        rcHandOver.CreateReport(cModel, "收银交班报表", "收银交班报表", PageSize.A4, 10, 10, 10, 10);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../reports/" + reportFileName + "', '收银交班', 1024, 1024 , false, false, null);</script>");
    }
    #endregion
}
