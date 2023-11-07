#region imports
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Workflow.Action.Finance.Find.Model;
using Workflow.Action.Finance.Find;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;
using Workflow.Action;

#endregion
/// <summary>
/// 名    称: YearPaper
/// 功能概要: 年度汇总
/// 作    者: 白晓宇
/// 创建时间: 2010年7月14日13:46:14
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class finance_find_YearPaper : System.Web.UI.Page
{
    #region action
    private CashHandOverAction cashHandOverAction;
    public CashHandOverAction CashHandOverAction
    {
        set { cashHandOverAction = value; }
        get { return cashHandOverAction; }
    }

    protected FindFinanceAction action;
    public FindFinanceAction FindFinanceAction
    {
        set { action = value; }
        get { return action; }
    }

    protected FindFinanceModel model;
    #endregion

    #region 类成员
    /// <summary>
    /// 当前查询的年
    /// </summary>
    protected int year  = 0;

    /// <summary>
    /// 当前年
    /// </summary>
    protected int currentYear = 0;

    /// <summary>
    /// 是否是当前年
    /// </summary>
    protected bool isCurrentYear = true;
    #endregion

    /// <summary>
    /// 页面加载
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = action.Model;

            currentYear = DateTime.Now.Year;

            if (!Page.IsPostBack)
            {
                this.InitData();
            }
            else
            {
                this.ProcessPostBack();
            }

            isCurrentYear = currentYear - year == 0 ? true : false;
        }
        catch (Exception ex)
        {
            Workflow.Support.Log.LogHelper.WriteError(ex, Workflow.Support.Constants.LOGGER_NAME);
        }
    }

    /// <summary>
    /// 初始化页面数据
    /// </summary>
    public void InitData()
    {
        //获取到查询的年
        if (null != Request.QueryString["year"])
        {
            year = int.Parse(Request.QueryString["year"].ToString());
        }
        else
        {
            year = DateTime.Now.Year;
        }
    }

    /// <summary>
    /// 处理页面回发
    /// </summary>
    public void ProcessPostBack()
    {
        
    }
}
