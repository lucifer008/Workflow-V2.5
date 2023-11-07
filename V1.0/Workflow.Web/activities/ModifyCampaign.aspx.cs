using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: ModifyCampaign
/// 功能概要: 编辑营销活动
/// 作    者: liuwei
/// 创建时间: 2007-10-17
/// 修 正 人: 张晓林
/// 修正时间: 2009年2月17日9:16:59
/// 描    述: 完善编辑、删除功能；
///           添加异常处理；
/// </summary>
public partial class ModifyCampaign :Workflow.Web.PageBase
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

    #region // 页面属性加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.Expires = -1;//清除页面缓存
            model = action.Model;
            concessionModel = concessionAction.Model;

            //删除Concession
            if (string.Compare(Request.Form.Get("hiddDeletedTag"), "delete") == 0)
            {
                concessionModel.Id = NumericUtils.ToLong(Request.Form.Get("hiddDeletedId"));
                concessionAction.DeleteConcessionById();
            }

            //页面初始化
            if (!IsPostBack)
            {
                InitData();
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
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
            ControlValue();

            concessionModel.CampaignId = Id;
            //SearchCampaignInfo(Convert.ToString(Id));
            //concessionAction.SearchConcessionByCampaignId();
        }
    }
    #endregion

    #region //更新新营销活动(事件)
    /// <summary>
    /// 更新新营销活动
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-19
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    protected void UpdateCampaign(object sender, EventArgs e)
    {
        try
        {
            model.Campaign = new Campaign();

            model.Campaign.Id = NumericUtils.ToLong(HiddenCampaignId.Value);
            model.Campaign.Name = txtName.Text;
            model.Campaign.BeginDateTime = Convert.ToDateTime(txtBeginDateTime.Value);
            model.Campaign.EndDateTime = Convert.ToDateTime(txtEndDateTime.Value);
            model.Campaign.Memo = txtMemo.Text;

            action.UpdateCampaign();
            HiddenCampaignId.Value = model.Campaign.Id.ToString();

            //SearchCampaignInfo(HiddenCampaignId.Value);

            ReturnTag = true;
            Response.Write("<script>window.returnValue=true;</script>");
            Response.Write("<script>window.close();</script>");
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //给页面控件值
    /// <summary>
    /// 给页面控件值
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-19
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    private void ControlValue()
    {
        txtName.Text = model.Campaign.Name;
        txtBeginDateTime.Value = model.Campaign.BeginDateTime.ToString("yyyy-MM-dd");
        txtEndDateTime.Value = model.Campaign.EndDateTime.ToString("yyyy-MM-dd");
        txtMemo.Text = model.Campaign.Memo;
    }
    #endregion
}
