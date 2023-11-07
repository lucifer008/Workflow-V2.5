using System;
using System.Text;
using iTextSharp.text;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Report.ReportOrderQuery;

/// <summary>
/// 名    称: SearchOrder
/// 功能概要: 订单查询
/// 作    者: liuwei
/// 创建时间: 
/// 修正履历: 
/// 修正时间: 2008-12-8
/// 修 正 人: 张晓林
///           处理 查询，分页，打印问题
///           2009-01-17
///           调整页面
///</summary>

public partial class SearchOrder : Workflow.Web.PageBase
{
    #region //Class Member
    protected bool isPrint = false;
    private NewOrderAction action;
    public NewOrderAction NewOrderAction
    {
        set { action = value; }
    }
    protected OrderModel model;
    private SearchOrderAction sAction;
    public SearchOrderAction SearchOrderAction
    {
        set { sAction = value; }
    }

    #endregion

    #region //Page_Load

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                InitData();
                ViewState.Add("ComporeCondition", SelectCondition.Value);
            }
            model = sAction.Model;
            int queryTag = Convert.ToInt16(hidDate.Value);
            if (999 != queryTag) NavigateQuery(queryTag);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
        }

    }

    protected void InitData() 
    {
        action.GetOperatorList();
        int index = 0;
        for(int i=action.Model.OperatorList.Count-1;i>=0;i--)
        {
            SelectCondition.Items.Add(action.Model.OperatorList[i].Label);
            SelectCondition.Items[index].Value = action.Model.OperatorList[i].Value;
            index++;
        }        
    }

    #endregion

    #region //Search
    /// <summary>
    /// 查询订单信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-9
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    /// 
    protected void SearchOrdersInfo(object sender, EventArgs e)
    {
        try
        {
            sAction.Model.NewOrder.No = OrderNo.Value;
            sAction.Model.NewOrder.MemberCardNo = MemberCardNo.Value;
            sAction.Model.NewOrder.CustomerName = CustomerName.Value;
            sAction.Model.NewOrder.BeginBalanceDate = Request.Form.Get("txtFrom");
            sAction.Model.NewOrder.EndBalanceDate = Request.Form.Get("txtTo");
            sAction.Model.NewOrder.ComporeCondition = SelectCondition.Value;
            sAction.Model.Name = txtMobile.Value;
            sAction.Model.CustomerName = txtQQMSN.Value;
            sAction.Model.BiJiao = txtEmail.Value;
            sAction.Model.ComporeCondition = txtIdentityNo.Value;
            if (!string.IsNullOrEmpty(Money.Value))
            {
                sAction.Model.NewOrder.SumAmount = decimal.Parse(Money.Value);
            }
            sAction.SearchOrderInfo(0);
            AspNetPager1.CurrentPageIndex = 1;
            this.AspNetPager1.RecordCount = (int)model.NeedPrePayOrdersCount;//总记录数
            this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数

            ViewState.Add("No", OrderNo.Value);
            ViewState.Add("MemberCardNo", MemberCardNo.Value);
            ViewState.Add("CustomerName", CustomerName.Value);
            ViewState.Add("BeginDate", Request.Form["txtFrom"]);
            ViewState.Add("EndDate", Request.Form["txtTo"]);
            ViewState.Add("Mobile", txtMobile.Value);
            ViewState.Add("Email",txtEmail.Value);
            ViewState.Add("QQ",txtQQMSN.Value);
            ViewState.Add("IdentityNo",txtIdentityNo.Value);
            if (!string.IsNullOrEmpty(Money.Value)) 
            {
                ViewState.Add("Money", Money.Value);
            }
            ViewState.Add("ComporeCondition", SelectCondition.Value);
            hidDate.Value = "999";
         }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }                 
    }
    #endregion

    #region //Print

    protected void Button1_Click1(object sender, EventArgs e)
    {
        try
        {
            isPrint = true;
            model.IsPrint = true;
            QueryNextPageData(1);
            ReportOrderQuery ro = new ReportOrderQuery();
            StringBuilder sb = new StringBuilder();
            if (null != ViewState["No"] && ""!=ViewState["No"].ToString())
            {
                sb.Append("订单号:" + ViewState["No"].ToString());
            }
            if (null != ViewState["MemberCardNo"] && ""!=ViewState["MemberCardNo"].ToString())
            {
                sb.Append(" 会员卡号:" + ViewState["MemberCardNo"].ToString());
            }
            if (null != ViewState["CustomerName"] && ""!=ViewState["CustomerName"].ToString())
            {
                sb.Append(" 客户名称:" + ViewState["CustomerName"].ToString());
            }
            if (null != ViewState["BeginDate"] && ""!=ViewState["BeginDate"].ToString())
            {
                sb.Append(" 开始时间>=" + ViewState["BeginDate"].ToString());
            }
            if (null != ViewState["EndDate"] && ""!=ViewState["EndDate"].ToString())
            {
                sb.Append(" 结束时间<=" + ViewState["EndDate"].ToString());
            }
            if (null != ViewState["Money"] && ""!=ViewState["Money"].ToString())
            {
                sb.Append(" 金额" + ViewState["ComporeCondition"] + ViewState["Money"].ToString());
            }
            if (null != ViewState["Mobile"] && "" != ViewState["Mobile"].ToString())
            {
                sb.Append(" 手机包含:" + ViewState["Mobile"].ToString());
            }
            if (null != ViewState["Email"] && "" != ViewState["Email"].ToString())
            {
                sb.Append(" Email包含:" + ViewState["Email"].ToString());
            }
            if (null != ViewState["QQ"] && "" != ViewState["QQ"].ToString())
            {
                sb.Append(" QQ包含" + ViewState["QQ"].ToString());
            }
            if (null != ViewState["IdentityNo"] && "" != ViewState["IdentityNo"].ToString()) 
            {
                sb.Append(" 身份证号包含:" + ViewState["IdentityNo"].ToString());
            }
            ro.ConditionText = sb.ToString(); //查询条件
            string reportname = "orders" + DateTime.Now.Ticks.ToString() + ".pdf";
            ro.FileName = Server.MapPath("~") + @"\reports\" + reportname;
            ro.CreateReport(sAction.Model, "订单查询", "订单查询", PageSize.A4, 10, 10, 10, 10);
            Page.ClientScript.RegisterStartupScript(this.GetType(), "pdf", "<script type=''>showPage('../../reports/" + reportname + "', '打印委托加订单', 1024, 1024 , false, false, null);</script>");
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    
    #endregion

    #region //分页处理事件
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    protected void QueryNextPageData(int currentPageIndex)
    {
        try
        {
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["No"])))
            {
                sAction.Model.NewOrder.No = ViewState["No"].ToString();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["MemberCardNo"])))
            {
                sAction.Model.NewOrder.MemberCardNo = ViewState["MemberCardNo"].ToString();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["CustomerName"])))
            {
                sAction.Model.NewOrder.CustomerName = ViewState["CustomerName"].ToString();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["BeginDate"])))
            {
                sAction.Model.NewOrder.BeginBalanceDate = ViewState["BeginDate"].ToString();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["EndDate"])))
            {
                sAction.Model.NewOrder.EndBalanceDate = ViewState["EndDate"].ToString();
            }

            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["Money"])))
            {
                sAction.Model.NewOrder.SumAmount = Convert.ToDecimal(ViewState["Money"].ToString());
            }
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["ComporeCondition"])))
            {
                sAction.Model.NewOrder.ComporeCondition = ViewState["ComporeCondition"].ToString();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["Mobile"])))
            {
                sAction.Model.Name = ViewState["Mobile"].ToString();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["QQ"])))
            {
                sAction.Model.CustomerName = ViewState["QQ"].ToString();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["Email"])))
            {
                sAction.Model.BiJiao = ViewState["Email"].ToString();
            }
            if (!string.IsNullOrEmpty(Convert.ToString(ViewState["IdentityNo"])))
            {
                sAction.Model.ComporeCondition = ViewState["IdentityNo"].ToString();
            }
            sAction.SearchOrderInfo(currentPageIndex - 1);
            AspNetPager1.CurrentPageIndex = currentPageIndex;
            AspNetPager1.RecordCount = (int)model.NeedPrePayOrdersCount;//总记录数
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;//每页显示条数
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion

    #region//日期导航查询
    /// <summary>
    /// 按照日期导航取数据
    /// </summary>
    /// <remarks>
    /// 作     者：张晓林
    /// 日     期: 2010年7月7日10:44:35
    /// </remarks>
    private void NavigateQuery(int day) 
    {
        string acTag = actionTag.Value;
        if ("T" != acTag)
        {
            if (-30 == day)
            {
                ViewState.Add("BeginDate", DateTime.Now.ToString("yyyy-MM") + "-01");
                ViewState.Add("EndDate", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
            }
            else
            {
                if (day < -2)
                {
                    ViewState.Add("EndDate", DateTime.Now.AddDays(1).ToString("yyyy-MM-dd"));
                }
                else
                {
                    ViewState.Add("EndDate", DateTime.Now.AddDays(day + 1).ToString("yyyy-MM-dd"));
                }

                ViewState.Add("BeginDate", DateTime.Now.AddDays(day).ToString("yyyy-MM-dd"));
            }
        }
        else
        {
            ViewState.Add("BeginDate", DateTime.Now.AddDays(day).ToString("yyyy-MM-dd"));
            ViewState.Add("EndDate", DateTime.Now.AddDays(day + 1).ToString("yyyy-MM-dd"));
        }
        ViewState["No"] = null;
        ViewState["QQ"] = null;
        ViewState["Email"] = null;
        ViewState["Mobile"] = null;
        ViewState["IdentityNo"] = null;
        ViewState["MemberCardNo"] = null;
        ViewState["CustomerName"] = null;
        ViewState["ComporeCondition"] = null;
        QueryNextPageData(1);
    }
    #endregion
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        string s = "";
    }
}
