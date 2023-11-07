using System;
using System.Web.UI.WebControls;

using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;

/// <summary>
///  功能概要: 积分设置
///  作    者: 张晓林
///  创建时间: 2009年10月28日11:18:30
///  修正履历:
///  修正时间:
/// </summary>
public partial class system_setMarking : System.Web.UI.Page
{
    #region//ClassMember
    protected SystemModel model;
    private SystemAction systemAction;
    public SystemAction SystemAction
    {
        set { systemAction = value; }
    }
    private SearchSystemAction searchSystemAction;
    public SearchSystemAction SearchSystemAction
    {
        set { searchSystemAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchSystemAction.Model;
        Response.Expires = -1;

        if(!IsPostBack)
        {
            InitData();
            BingMarkingSetting();
        }
        DeleteMarkingSetting();
        QueryNextPageData(1);
    }

    private void InitData() 
    {
        searchSystemAction.SearchProcessContentList();
        dropListProcessContent.DataSource = searchSystemAction.Model.ProcessContentList;//加工内容
        dropListProcessContent.DataTextField = "NAME";
        dropListProcessContent.DataValueField = "Id";
        dropListProcessContent.DataBind();
    }
    private void BingMarkingSetting() 
    {
        if (null != Request.QueryString["action"] && "edmit" == Request.QueryString["action"])
        {
            hidId.Value = Request.QueryString["MarkSettingId"];
            tr1.Visible = false;
            btnCancel.Visible = true;
            txtMarkingAmount.Value = Request.QueryString["Amount"];
            txtMarkingCount.Value=Request.QueryString["Marking"];
            txtMemo.Value = Request.QueryString["Memo"];
            dropListProcessContent.SelectedValue=Request.QueryString["ProcessContentId"];
            dropListProcessContent.SelectionMode = ListSelectionMode.Single;
            dropListProcessContent.Enabled = false;
            btnClear.Visible = false;
        }
    }
    private void DeleteMarkingSetting() 
    {
        if ("delete" == Request.Form["actionTag"])
        {
            systemAction.Model.MarkingSetting.Id = Convert.ToInt32(hidId.Value);
            systemAction.DeleteMarkingSetting();
            hidId.Value = "";
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        searchSystemAction.Model.MarkingSetting.CurrentPageIndex = Convert.ToInt32(currentPageIndex - 1);
        searchSystemAction.Model.MarkingSetting.RowCount =  Convert.ToInt32(Workflow.Support.Constants.ROW_COUNT_FOR_PAGER);
        searchSystemAction.SearchMarkingSetting();
        
        AspNetPager1.CurrentPageIndex = currentPageIndex - 1;
        AspNetPager1.PageSize = Workflow.Support.Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.RowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            string strSelectedProcessContent = "";
            foreach(ListItem listItem in dropListProcessContent.Items)
            {
                if(listItem.Selected)
                {
                    strSelectedProcessContent += listItem.Value + ",";
                }
            }
            systemAction.Model.MarkingSetting.StrProcessContent = strSelectedProcessContent;
            systemAction.Model.MarkingSetting.Marking = Convert.ToDecimal(txtMarkingCount.Value);
            systemAction.Model.MarkingSetting.Amount = Convert.ToDecimal(txtMarkingAmount.Value);
            systemAction.Model.MarkingSetting.Memo = txtMemo.Value;
            if ("" != hidId.Value.Trim())//编辑
            {
                systemAction.Model.MarkingSetting.ProcessContentId = Convert.ToInt32(dropListProcessContent.SelectedValue);
                systemAction.Model.MarkingSetting.Id = Convert.ToInt32(hidId.Value);
                systemAction.UpdateMarkingSetting();
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else//插入 
            {
                systemAction.AddMarkingSetting();
                Response.Write("<script>window.navigate('setMarking.aspx')</script>");
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
