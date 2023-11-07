using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: CampaignList
/// 功能概要: 营销活动管理
/// 作    者: liuwei
/// 创建时间: 2007-10-15
/// 修 正 人: 张晓林
/// 修正时间: 2009年2月16日9:16:59
/// 描    述: 增加分页功能；
///           完善 编辑、删除功能；
///           添加异常处理；
/// </summary>
public partial class CampaignList : Workflow.Web.PageBase
{
    #region //成员变量
    private CampaignAction action;
    protected CampaignModel model;

    public CampaignAction CampaignAction
    {
        set { action = value; }
    }
    #endregion

    #region //页面属性加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = action.Model;

            if (hiddTag.Value.Trim()=="delete")
            {
                model.Id = NumericUtils.ToLong(hiddId.Value);//营销活动Id
                action.DeleteCampaignById();
            }

            QueryNextPageData(1);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion 

    #region //分页处理程序
    private void QueryNextPageData(int currentPageIndex)
    {
        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(action.SearchAllCampaignRowCount());
        action.SearchAllCampaign(currentPageIndex-1);
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
