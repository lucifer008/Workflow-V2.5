using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Util;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Finance;
using Workflow.Action.Finance.Model;

/// <summary>
/// 名    称: FinanceSelectOrder
/// 功能概要: 待结算单一览
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class FinanceSelectOrder :Workflow.Web.PageBase
{
    #region Class Member
    //private long orderId = 0;
    private long customerId = 0;
    private string customerName = "";
    protected FinanceModel fModel;
    private FinanceAction financeAction;
    public FinanceAction FinanceAction
    {
        set { financeAction = value; }
    }
    #endregion

    #region Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData(0);
        }
        fModel = financeAction.Model;
        ReturnOrders();

    }
    #endregion

    #region Search
    protected void Search(object sender, EventArgs e)
    {

            string strOrderNo=Request.Form["OrderNo"];
            string strMemberCardNo=Request.Form["MemberCardNo"];
            string strCodeNo=Request.Form["CodeNo"];
            string strQQ = Request.Form["txtQQ"];
            string strEmail = Request.Form["txtEmail"];
            string strPhone = Request.Form["txtPhone"];
            string strIdentityNo = Request.Form["txtIdentityNo"];

            if (!string.IsNullOrEmpty(strOrderNo) ||
                !string.IsNullOrEmpty(strMemberCardNo) ||
                !string.IsNullOrEmpty(strCodeNo))
            {
                financeAction.Model.Orders = new Order();
                financeAction.Model.Orders.No = !string.IsNullOrEmpty(strOrderNo) ? strOrderNo : null;
                financeAction.Model.Orders.MemberCardNo = !string.IsNullOrEmpty(strMemberCardNo)?strMemberCardNo:null;
                financeAction.Model.Orders.CodeNo =!string.IsNullOrEmpty(strCodeNo)?strCodeNo:null;
                //目前条码号和订单号相同
                if (!string.IsNullOrEmpty(financeAction.Model.Orders.CodeNo))
                {
                    financeAction.Model.Orders.No = financeAction.Model.Orders.CodeNo;
                }
                financeAction.GetCustomerIdByNo();
                customerId = financeAction.Model.CustomerId;
                customerName = financeAction.Model.CustomerName;
                financeAction.Model.Orders = null;
            }

/*        if (!StringUtils.IsEmpty(Request.Form["OrderNo"]))
        {
            orderId = financeAction.SelectOrderIdByOrderNo(Request.Form["OrderNo"]);
            if (orderId == 0)
            {
                orderId = -1;
            }
        }
        else
        {
            orderId = 0;
        }
*/
        financeAction.Model.Orders = new Order();
        //financeAction.Model.Orders.Id = orderId;
        if (!string.IsNullOrEmpty(customerName))
        {
            financeAction.Model.Orders.CustomerName = customerName.Trim();
            financeAction.Model.Orders.CustomerId = 0;
        }
        else
        {
            financeAction.Model.Orders.CustomerId = customerId;
        }
        financeAction.Model.Orders.CustomerTypeName = !string.IsNullOrEmpty(strQQ)?strQQ:null;
        financeAction.Model.Orders.LastTelNo = !string.IsNullOrEmpty(strPhone) ? strPhone : null;
        financeAction.Model.Orders.LinkManName = !string.IsNullOrEmpty(strEmail) ? strEmail : null;
        financeAction.Model.Orders.Memo = !string.IsNullOrEmpty(strIdentityNo) ? strIdentityNo : null;
        financeAction.Model.Orders.Status = Constants.ROW_COUNT_FOR_PAGER;
        financeAction.Model.Orders.Status1 = Constants.ORDER_STATUS_DELIVERYED_VALUE;
        financeAction.Model.Orders.Status2 = Constants.ORDER_STATUS_NOPATCHUP_VALUE;
        financeAction.Model.Orders.Status3 = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
        financeAction.Model.Orders.CurrentPageIndex = 0;
        ViewState.Add("CustomerId", customerId);
        ViewState.Add("CustomerName", customerName);
        ViewState.Add("Status", Constants.ROW_COUNT_FOR_PAGER);
        ViewState.Add("Status1", Constants.ORDER_STATUS_DELIVERYED_VALUE);
        ViewState.Add("Status2", Constants.ORDER_STATUS_NOPATCHUP_VALUE);
        ViewState.Add("Status3", Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE);
        ViewState.Add("QQ",strQQ);
        ViewState.Add("Phone",strPhone);
        ViewState.Add("Email",strEmail);
        ViewState.Add("IdentityNo",strIdentityNo);
        financeAction.SelectUnClosedOrderCount();
        financeAction.SelectUnClosedOrder();
        this.AspNetPager1.CurrentPageIndex = 1;
        this.AspNetPager1.RecordCount = financeAction.Model.UnClosedOrderCount;
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

    }
    #endregion

    #region Pager Event
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        this.AspNetPager1.CurrentPageIndex = e.NewPageIndex;
        BindData(e.NewPageIndex-1);
    }
    #endregion

    #region Data Bind
    private void BindData(int currentPageIndex)
    {
        financeAction.Model.Orders = new Order();
        if (ViewState["CustomerId"] != null)
        {
            financeAction.Model.Orders.Id = long.Parse(ViewState["CustomerId"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Id = 0;
        }
        if (ViewState["CustomerName"] != null && ViewState["CustomerName"].ToString()!="")
        {
            financeAction.Model.Orders.CustomerName = ViewState["CustomerName"].ToString();
        }
        else
        {
            financeAction.Model.Orders.CustomerName = null;
        }
        if (ViewState["Status"] != null)
        {
            financeAction.Model.Orders.Status = int.Parse(ViewState["Status"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Status = Constants.ROW_COUNT_FOR_PAGER;
        }
        if (ViewState["Status1"] != null)
        {
            financeAction.Model.Orders.Status1 = int.Parse(ViewState["Status1"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Status1 = Constants.ORDER_STATUS_DELIVERYED_VALUE;
        }
        if (ViewState["Status2"] != null)
        {
            financeAction.Model.Orders.Status2 = int.Parse(ViewState["Status2"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Status2 = Constants.ORDER_STATUS_NOPATCHUP_VALUE;
        }
        if (ViewState["Status3"] != null)
        {
            financeAction.Model.Orders.Status3 = int.Parse(ViewState["Status3"].ToString());
        }
        else
        {
            financeAction.Model.Orders.Status3 = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
        }
        financeAction.Model.Orders.CustomerTypeName = !string.IsNullOrEmpty(Convert.ToString(ViewState["QQ"])) ? ViewState["QQ"].ToString() : null;
        financeAction.Model.Orders.LastTelNo = !string.IsNullOrEmpty(Convert.ToString(ViewState["Phone"])) ? ViewState["Phone"].ToString() : null;
        financeAction.Model.Orders.LinkManName = !string.IsNullOrEmpty(Convert.ToString(ViewState["Email"])) ? ViewState["Email"].ToString() : null;
        financeAction.Model.Orders.Memo = !string.IsNullOrEmpty(Convert.ToString(ViewState["IdentityNo"])) ? ViewState["IdentityNo"].ToString() : null;

        financeAction.Model.Orders.CurrentPageIndex = currentPageIndex;
        financeAction.SelectUnClosedOrderCount();
        financeAction.SelectUnClosedOrder();

        this.AspNetPager1.RecordCount = financeAction.Model.UnClosedOrderCount;
        this.AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;

    }
    #endregion

    #region Return Order
    /// <summary>
    /// 订单返回处理
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    /// <remarks>
    /// 作    者: 张晓林
    /// 创建时间: 2008-12-23
    /// 修正履历:
    /// </remarks>
    public void ReturnOrders()
    {
        try
        {
            if (checkTag.Value == "T")//Request.Form["checkTag"] == "T")
            {
                financeAction.Model.OrderStatusAlter = new OrdersStatusAlter();
                financeAction.Model.OrderStatusAlter.OrdersId = Convert.ToUInt32(searchTag.Value);
                financeAction.Model.OrderStatusAlter.Status = Constants.ORDER_STATUS_NOBLANKOUTRECORD_VALUE;
                financeAction.Model.OrderStatusAlter.Memo = "从已登记返回到制作中";
                financeAction.ReturnOrder();
                this.AspNetPager1.CurrentPageIndex = this.AspNetPager1.CurrentPageIndex;
                BindData(this.AspNetPager1.CurrentPageIndex - 1);
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
