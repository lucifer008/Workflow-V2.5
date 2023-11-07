using System;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.System;
using Workflow.Action.SystemMaintenance.System.Model;

/// <summary>
/// 名    称:edmitId
/// 功能概要:编辑Id生成器
/// 作    者:张晓林
/// 创建时间:2009年6月7日
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class system_edmitId : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "编辑Id生成器";
    protected SystemModel model;
    private SystemAction systemAction;
    public SystemAction SystemAction
    {
        set { systemAction = value; }
    }
    #endregion

    #region//Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = systemAction.Model;
        if (!IsPostBack)
        {
            Response.Expires = -1;
            hidId.Value = Request.QueryString["IdGeneratorId"];
            txtBeginValue.Value = Request.QueryString["BeginValue"];
            txtCurrentValue.Value = Request.QueryString["CurrentValue"];
            txtEndValue.Value = Request.QueryString["EndValue"];
            txtMemo.Value = Request.QueryString["Memo"];
            txtFlagNo.Value = Request.QueryString["FlagNo"];
        }
    }
    #endregion

    #region//Update
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            model.IdGenerator.Id = Convert.ToInt32(hidId.Value);
            model.IdGenerator.FlagNo = txtFlagNo.Value;
            model.IdGenerator.BeginValue = Convert.ToInt32(txtBeginValue.Value);
            model.IdGenerator.CurrentValue = Convert.ToInt32(txtCurrentValue.Value);
            model.IdGenerator.EndValue = Convert.ToInt32(txtEndValue.Value);
            model.IdGenerator.Memo =txtMemo.Value;
            systemAction.UpdateIdGenerator();
            Response.Write("<script>window.returnValue=true;</script>");
            Response.Write("<script>window.close();</script>");
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
        }
    }
    #endregion
}
