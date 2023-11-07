using System;
using System.Collections;
using Workflow.Action;
using Workflow.Support;
using Workflow.Action.Model;
using Workflow.Support.Log;
/// <summary>
/// 名    称: ConcessionList
/// 功能概要: 优惠方案一览
/// 作    者: liuwei
/// 创建时间: 2007-10-17
/// 修 正 人: 张晓林
/// 修正时间: 2009年2月16日9:16:59
/// 描    述: 完善分页；编辑；删除功能；添加异常处理；
/// </summary>
public partial class activities_ConcessionList : System.Web.UI.Page
{
    #region Class Member 

    protected ConcessionModel model;

    private ConcessionAction concessionAction;
    public ConcessionAction ConcessionAction 
    {
        set { concessionAction = value; }
    }
    #endregion

    #region Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = concessionAction.Model;
        try 
        {
            if (!IsPostBack) 
            {
                QueryNextPageData(1);
            }
            //编辑和删除后刷新数据
            if("True"==hiddTag.Value.Trim())
            {
                if ("delete" == hiddDeletedTag.Value)
                {
                    concessionAction.Model.Id = Convert.ToInt32(hiddDeletedId.Value);//活动Id
                    concessionAction.DeleteConcessionById();
                }
                QueryNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region //分页处理程序
    protected void QueryNextPageData(int currentPageIndex)
    {
        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = Convert.ToInt32(concessionAction.GetAllConcessionListInfoRowCount());
        concessionAction.GetAllConcessionListInfo(currentPageIndex);
    }
 
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
