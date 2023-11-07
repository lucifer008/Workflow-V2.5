using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;

/// <summary>
/// 名    称: AddCampaign
/// 功能概要: 新增营销活动
/// 作    者: liuwei
/// 创建时间: 2007-10-15
/// 修 正 人: 张晓林
/// 修正时间: 2009年2月16日9:16:59
/// 描    述: 完成分页；新增；编辑；删除功能；添加异常处理；
/// </summary>
public partial class AddCampaign : Workflow.Web.PageBase
{
    #region //成员变量
    protected bool ReturnTag = false;

    private CampaignAction action;
    protected CampaignModel model;
    public CampaignAction CampaignAction
    {
        set { action = value; }
    }

    private ConcessionAction concessionAction;
    protected ConcessionModel concessionModel;
    public ConcessionAction ConcessionAction
    {
        set { concessionAction = value; }
    }
    #endregion

    #region //页面属性加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = action.Model;
        concessionModel = concessionAction.Model;

        //删除Concession
        if (string.Compare(Request.Form.Get("DeletedTag"), "delete") == 0)
        {
            concessionModel.Id =NumericUtils.ToLong(Request.Form.Get("DeletedId"));
            concessionAction.DeleteConcessionById();
        }

        //页面初始化
        //InitData();
    }
    #endregion

    #region //页面初始化
    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-17
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    private void InitData()
    {
        if (!StringUtils.IsEmpty(Request.QueryString["Id"]))
        {
            long Id = NumericUtils.ToLong(Request.QueryString["Id"]);
            HiddenCampaignId.Value = Id.ToString();
            model.Id = Id;
            action.SearchCampaignByCampaignId();
            concessionModel.CampaignId = Id;
            ReturnTag = true;
        }
    }
    #endregion

    #region //插入
    /// <summary>
    /// 插入新营销活动
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-15
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    protected void InsertCampaign(object sender, EventArgs e)
    {
        model.Campaign = new Campaign();

        model.Campaign.Name = Request.Form["txtName"].ToString(); //txtName.Text;
        model.Campaign.BeginDateTime =Convert.ToDateTime(txtBeginDateTime.Value);
        model.Campaign.EndDateTime =Convert.ToDateTime(txtEndDateTime.Value);
        model.Campaign.Memo = txtMemo.Text;

        action.InsertCampaign();
        Response.Redirect("AddCampaign.aspx");
        HiddenCampaignId.Value = model.Campaign.Id.ToString();//保存campaignId
        ReturnTag = true;
    }
    #endregion
}
