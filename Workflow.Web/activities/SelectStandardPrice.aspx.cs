using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;

/// <summary>
/// 名    称: SelectStandardPrice
/// 功能概要: 选择标准价格
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 张晓林
/// 修正时间: 2009年2月16日9:16:59
/// 描    述: 添加分页功能:
///           添加异常处理；
/// </summary>
public partial class SelectStandardPrice : Workflow.Web.PageBase
{
    #region //Class Member
    private BaseBusinessTypePriceSetAction baseBusinessTypePriceSetAction;
    protected BaseBusinessTypePriceSetModel model;

    public BaseBusinessTypePriceSetAction BaseBusinessTypePriceSetAction
    {
        set { baseBusinessTypePriceSetAction = value; }
    }

    //业务类型ID
    protected long lngBusinessTypeId = 0;

    #endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = baseBusinessTypePriceSetAction.Model;

            if (!IsPostBack)
            {
                //页面初始化
                //baseBusinessTypePriceSetAction.SearchSalesroomPriceInfo(1);
                baseBusinessTypePriceSetAction.InitData();
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

    #region //查询
    protected void SearchPrice(object sender, EventArgs e)
    {
        try
        {
            long Id = NumericUtils.ToLong(Request.Form.Get("sltBusinessType"));

            //设定查询条件
            BaseBusinessTypePriceSet baseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            //baseBusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
            baseBusinessTypePriceSet.BusinessTypeId = Id;
            //查询
            if(0!=Id)
            {
                baseBusinessTypePriceSetAction.Model.BaseBusinessTypePriceSet = baseBusinessTypePriceSet;
                baseBusinessTypePriceSetAction.SearchSalesroomPriceInfo(1);
                AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
                AspNetPager1.CurrentPageIndex = 1;
                AspNetPager1.RecordCount = Convert.ToInt32(baseBusinessTypePriceSetAction.SearchBaseBuinessTypeSetInfoRowCount(baseBusinessTypePriceSet));
                ViewState.Add("BusinessType", Id);
            }
            
            //baseBusinessTypePriceSetAction.InitCustomQuery(baseBusinessTypePriceSetAction.Model);
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
        BaseBusinessTypePriceSet baseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
        if (null!=ViewState["BusinessType"] && ""!=ViewState["BusinessType"].ToString())
        {
            baseBusinessTypePriceSet.BusinessTypeId = Convert.ToInt32(ViewState["BusinessType"]);
        }
        baseBusinessTypePriceSetAction.Model.BaseBusinessTypePriceSet=baseBusinessTypePriceSet;
        baseBusinessTypePriceSetAction.SearchSalesroomPriceInfo(currentPageIndex);
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.RecordCount = Convert.ToInt32(baseBusinessTypePriceSetAction.SearchBaseBuinessTypeSetInfoRowCount(baseBusinessTypePriceSet));
        ViewState.Add("BusinessType", ViewState["BusinessType"]);
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion
}
