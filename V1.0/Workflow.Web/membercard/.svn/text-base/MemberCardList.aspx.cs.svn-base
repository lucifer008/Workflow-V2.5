using System;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Action.Membercard;
/// <summary>
/// 名    称: MemberCardList
/// 功能概要: 会员一览
/// 作    者: liuwei
/// 创建时间: 2007-9-29
/// 修正履历: 张晓林
/// 修正时间: 2009-02-11-2009-02-13
///             完善查询功能；
///             完成编辑和删除功能
///             增加分页功能 ；
///             增加捕获异常处理；
///             调整页面
/// </summary>
public partial class MemberCardList : Workflow.Web.PageBase
{
    #region //成员变量
    protected MemberCardModel model;
    private SearchMemberCardAction searchMemberCardAction;
    public SearchMemberCardAction SearchMemberCardAction 
    {
        set { searchMemberCardAction = value; }
        get { return searchMemberCardAction; }
    }
    #endregion

    #region //页面属性加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = searchMemberCardAction.Model;
            if (!IsPostBack)
            {
                InitData();
            }
            //编辑和删除完成后查询
            if (""!=hiddOperateTag.Value)
            {
                SearchMemberCardInfo(sender, e);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }

    /// <summary>
    /// 方法名称: InitData
    /// 功能概要: 初始化页面
    /// 作    者: liuwei
    /// 创建时间: 2007-9-29
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    /// <param></param>
    /// 
    private void InitData()
    {
        searchMemberCardAction.GetMemberCardLevel();

        ddlMemberCardLevel.DataSource = model.MemberCardLevelList;
        ddlMemberCardLevel.DataValueField = "Id";
        ddlMemberCardLevel.DataTextField = "Name";
        ddlMemberCardLevel.DataBind();
        MakeSelectDefaultItem(ddlMemberCardLevel);
        ListItem listItem1 = new ListItem();
        listItem1.Value = "-1"; listItem1.Text = "请选择";
        ListItem listItem2 = new ListItem();
        listItem2.Value = Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_KEY;
        listItem2.Text = Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_TEXT;
        ListItem listItem3 = new ListItem();
        listItem3.Value = Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_KEY;
        listItem3.Text = Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_TEXT;
        ListItem listItem4 = new ListItem();
        listItem4.Value = Workflow.Support.Constants.MEMBER_CARD_STATE_LOGOUT_KEY;
        listItem4.Text = Workflow.Support.Constants.MEMBER_CARD_STATE_LOGOUT_TEXT;
        ddlMemberCardState.Items.AddRange(new ListItem[] { listItem1, listItem2, listItem3, listItem4 });
    }
    #endregion

    #region //查询
    /// <summary>
    /// 方法名称: SearchMemberCardInfo
    /// 功能概要: 查询会员卡信息
    /// 作    者: liuwei
    /// 创建时间: 2007-9-29
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    /// <param></param>
    /// 
    protected void SearchMemberCardInfo(object sender, EventArgs e)
    {
        try
        {
            model.MemberCardNo = txtMemberCardNo.Value;
            model.MemberState = ddlMemberCardState.SelectedValue;
            model.CustomerName = txtCustomerName.Text;

            model.MemberCardLevel = new Workflow.Da.Domain.MemberCardLevel();
            model.MemberCardLevel.Id = NumericUtils.ToLong(ddlMemberCardLevel.SelectedValue);

            model.BeginDate = txtBeginDate.Value;
            model.EndDate = txtEndDate.Value;
            searchMemberCardAction.SearchMemberCard(0);
            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(searchMemberCardAction.SearchMemberCardRowCount());

            ViewState.Add("MemberCardNo", txtMemberCardNo.Value);
            ViewState.Add("MemberState", ddlMemberCardState.SelectedValue);
            ViewState.Add("CustomerName", txtCustomerName.Text);
            if ("-1" != ddlMemberCardLevel.SelectedValue) 
            {
                ViewState.Add("MemberCardLevelId", ddlMemberCardLevel.SelectedValue);
            }
            ViewState.Add("BeginDate", txtBeginDate.Value);
            ViewState.Add("EndDate", txtEndDate.Value);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //分页事件处理程序
    /// <summary>
    /// 查询下一页数据
    /// </summary>
    /// <param name="currentPageIndex"></param>
    /// 作    者: 张晓林
    /// 创建时间: 2009年2月12日
    /// 修正履历: 
    /// 修正时间: 
    private void QueryNextPageData(int currentPageIndex) 
    {
        try
        {
            if (null != ViewState["MemberCardNo"] && "" != ViewState["MemberCardNo"].ToString()) 
            {
                model.MemberCardNo = ViewState["MemberCardNo"].ToString();
            }

            if (null != ViewState["MemberState"] && "" != ViewState["MemberState"].ToString())
            {
                model.MemberState = ViewState["MemberState"].ToString();
            }

            if (null != ViewState["CustomerName"] && "" != ViewState["CustomerName"].ToString())
            {
                model.CustomerName = ViewState["CustomerName"].ToString();
            }

            if (null != ViewState["MemberCardLevelId"] && "" != ViewState["MemberCardLevelId"].ToString())
            {
                Workflow.Da.Domain.MemberCardLevel memberCardLevel = new Workflow.Da.Domain.MemberCardLevel();
                memberCardLevel.Id=NumericUtils.ToLong(ViewState["MemberCardLevelId"].ToString());
                model.MemberCardLevel = memberCardLevel;
            }

            if (null != ViewState["BeginDate"] && "" != ViewState["BeginDate"].ToString())
            {
                model.BeginDate = ViewState["BeginDate"].ToString();
            }

            if (null != ViewState["EndDate"] && "" != ViewState["EndDate"].ToString())
            {
                model.EndDate = ViewState["EndDate"].ToString();
            }

            searchMemberCardAction.SearchMemberCard(currentPageIndex-1);
            AspNetPager1.CurrentPageIndex =currentPageIndex;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = Convert.ToInt32(searchMemberCardAction.SearchMemberCardRowCount());

            ViewState.Add("MemberCardNo", model.MemberCardNo);
            ViewState.Add("MemberState", model.MemberState);
            ViewState.Add("CustomerName",model.CustomerName);
            ViewState.Add("MemberCardLevelId", ViewState["MemberCardLevelId"]);
            ViewState.Add("BeginDate", model.BeginDate);
            ViewState.Add("EndDate", model.EndDate);

        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
