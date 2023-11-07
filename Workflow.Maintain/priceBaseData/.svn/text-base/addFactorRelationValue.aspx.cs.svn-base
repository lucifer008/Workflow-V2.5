using System;
using Workflow.Da.Domain;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.SystemMaintenance.PriceBaseData;
using Workflow.Action.SystemMaintenance.PriceBaseData.Model;
/// <summary>
/// 名    称: addFactorRelationValue
/// 功能概要：价格因素之间的依赖关系值操作
/// 作    者: 张晓林
/// 创建时间: 2009年5月18日10:22:46
/// 修正履历:
/// 修正时间:
/// </summary>
public partial class priceBaseData_addFactorRelationValue : System.Web.UI.Page
{
    #region//ClassMember
    protected string strTitle = "价格因素之间的依赖关系值";
    protected string factorRelationId,sourceValue,targetValue;
    protected PriceBaseDataModel model;
    private SearchPriceBaseDataAction searchPriceBaseDataAction;
    public SearchPriceBaseDataAction SearchPriceBaseDataAction
    {
        set { searchPriceBaseDataAction = value; }
        get { return searchPriceBaseDataAction; }
    }
    private PriceBaseDataAction priceBaseDataAction;
    public PriceBaseDataAction PriceBaseDataAction
    {
        set { priceBaseDataAction = value; }
    }
    #endregion

    #region//Page_load
    protected void Page_Load(object sender, EventArgs e)
    {
        model = searchPriceBaseDataAction.Model;
        searchPriceBaseDataAction.GetAllFactorRelationValue();
        if(!IsPostBack)
        {
            Response.Expires = -1;
            BingEdmitData();
        }
        DeleteData();
        QueryNextPageData(1);
    }
    /// <summary>
    /// 加载编辑数据
    /// </summary>
    private void BingEdmitData() 
    {
        if(null!=Request.QueryString["action"] && "edmit"==Request.QueryString["action"])
        {
            btnCancel.Visible = true;
            tr1.Visible = false;
            hidFactorRelationValueId.Value = Request.QueryString["FactorRelationValueId"];
            sourceValue = Request.QueryString["SourceValue"];
            targetValue= Request.QueryString["TargetValue"];
            strTitle = "编辑价格因素之间的依赖关系值";
            factorRelationId=Request.QueryString["FactorRelationId"];
        }
    }

    /// <summary>
    /// 删除数据
    /// </summary>
    private void DeleteData() 
    {
        if (null != Request.Form["actionTag"] && "delete" == Request.Form["actionTag"])
        {
            priceBaseDataAction.Model.FactorRelationValue.Id = Convert.ToInt32(hidFactorRelationValueId.Value);
            priceBaseDataAction.LogicDeleteFactorRelationValue();
            hidFactorRelationValueId.Value = "";
        }
    }
    #endregion

    #region//Save
    protected void BtnSave_Click(object sender, EventArgs e)
    {
        try 
        {
            priceBaseDataAction.Model.FactorRelationValue.FactorRelationId = Convert.ToInt32(Request.Form["factorRelation"]);
            priceBaseDataAction.Model.FactorRelationValue.ArrSourceValue = Request.Form["factorValue"].Split(',');
            priceBaseDataAction.Model.FactorRelationValue.ArrTargetValue = Request.Form["factorValue1"].Split(',');
            if ("" != hidFactorRelationValueId.Value.Trim())//更新
            {
                priceBaseDataAction.Model.FactorRelationValue.Id = Convert.ToInt32(hidFactorRelationValueId.Value);
                priceBaseDataAction.Model.FactorRelationValue.SourceValue = Convert.ToInt32(Request.Form["factorValue"]);
                priceBaseDataAction.Model.FactorRelationValue.TargetValue = Convert.ToInt32(Request.Form["factorValue1"]);
                priceBaseDataAction.UpdateFactorRelationValue();
                Response.Write("<script>window.returnValue=true</script>");
                Response.Write("<script>window.close();</script>");
            }
            else 
            {
                priceBaseDataAction.AddFactorRelationValue();
                //txtSourceValue.Value = "";
                //txtTargetValue.Value = "";
                QueryNextPageData(1);
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region//分页处理程序
    private void QueryNextPageData(int currentPageIndex) 
    {
        model.FactorRelationValue = new FactorRelationValue();
        model.FactorRelationValue.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
        model.FactorRelationValue.UpdateUser = Convert.ToInt32(currentPageIndex - 1);
        if (null != ViewState["FactorRelationId"])
        {
            model.FactorRelationValue.Memo = ViewState["FactorRelationId"].ToString();
        }
        if (null != ViewState["factorValue"])
        {
            model.FactorRelationValue.ArrSourceValue = (string[])ViewState["factorValue"];
        }
        if (null != ViewState["factorValue1"])
        {
            model.FactorRelationValue.ArrTargetValue = (string[])ViewState["factorValue1"];
        }
        searchPriceBaseDataAction.SearchFactorRelationValue();

        AspNetPager1.CurrentPageIndex = currentPageIndex;
        AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
        AspNetPager1.RecordCount = (int)model.BusinessTypeRowCount;
    }
    protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
    {
        QueryNextPageData(e.NewPageIndex);
    }
    #endregion

    #region//Search
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try 
        {
            model.FactorRelationValue = new FactorRelationValue();
            if ("-1"!=Request.Form["factorRelation"])
            {
                model.FactorRelationValue.Memo =Request.Form["factorRelation"];
            }
            if (null != Request.Form["factorValue"] && "" != Request.Form["factorValue"])
            {
                model.FactorRelationValue.ArrSourceValue = Request.Form["factorValue"].Split(',');
            }
            if (null != Request.Form["factorValue1"] && "" != Request.Form["factorValue1"])
            {
                model.FactorRelationValue.ArrTargetValue = Request.Form["factorValue1"].Split(',');
            }
            model.FactorRelationValue.InsertUser = Convert.ToInt32(Constants.ROW_COUNT_FOR_PAGER);
            model.FactorRelationValue.UpdateUser = Convert.ToInt32(0);
            searchPriceBaseDataAction.SearchFactorRelationValue();

            AspNetPager1.CurrentPageIndex = 1;
            AspNetPager1.PageSize = Constants.ROW_COUNT_FOR_PAGER;
            AspNetPager1.RecordCount = (int)model.BusinessTypeRowCount;

            ViewState.Add("FactorRelationId",model.FactorRelationValue.Memo);
            ViewState.Add("factorValue", model.FactorRelationValue.ArrSourceValue);
            ViewState.Add("factorValue1", model.FactorRelationValue.ArrTargetValue);
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
