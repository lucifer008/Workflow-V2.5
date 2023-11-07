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
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;


/// <summary>
/// 名    称: SpecialPriceSetting
/// 功能概要: 特殊会员卡价格设置一览/追加/修改/删除
/// 作    者: 麻少华
/// 创建时间: 2007-9-27
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
/// </summary>
public partial class SpecialPriceSetting : Workflow.Web.PageBase
{
    #region 类成员
    private long lngBusinessTypeId = 0;
    private long lngMemberCardId = 0;
    protected int intAction = Constants.ACTION_INIT;
    protected BusinessTypePriceSetModel model;
    protected BusinessTypePriceSetAction businessTypePriceSetAction;
    public BusinessTypePriceSetAction BusinessTypePriceSetAction
    {
        set { businessTypePriceSetAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = businessTypePriceSetAction.Model;
        businessTypePriceSetAction.InitDataPriceTypeSpecial(intAction);

        //获得页面动作
        if (Request.Form["txtAction"] != null)
        {
            intAction = int.Parse(Request.Form["txtAction"]);
        }
        //判断页面动作执行不同的处理
        if (intAction == Constants.ACTION_INIT)
        {
            QueryProcess();
            //初始化显示
            //businessTypePriceSetAction.InitDataPriceTypeSpecial(intAction);
        }
        else if (intAction == Constants.ACTION_SEARCH)
        {
            //查询
            QueryProcess();
            //businessTypePriceSetAction.InitDataPriceTypeSpecial(intAction);
        }
        else if (intAction == Constants.ACTION_DELETE)
        {
            //删除
            DeleteProcess();
            //businessTypePriceSetAction.InitDataPriceTypeSpecial(intAction);
            //再检索一遍
            QueryProcess();
        }
        else if (intAction == Constants.ACTION_UPDATE)
        {
            //编辑后再重新检索一遍
            QueryProcess();
        }
    }
    #endregion

    #region 查询
    /// <summary>
    /// 方法名称: QueryProcess
    /// 功能概要: 自定义查询
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-27
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void QueryProcess()
    {
        //获得查询条件
        if (Request.Form["sltBusinessType"] != null)
        {
            lngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
        }
        if (Request.Form["sltMemberCardLevel"] != null)
        {
            lngMemberCardId = long.Parse(Request.Form["txtMemberCardId"]);
        }
        //设定查询条件
        model.BusinessTypePriceSet = new BusinessTypePriceSet();
        model.BusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
        //取得业务类型ID
        model.BusinessTypePriceSet.BusinessType.Id = lngBusinessTypeId;
        //取得会员卡ID
        model.BusinessTypePriceSet.TargetId = lngMemberCardId;
        //设定价格类型
        model.BusinessTypePriceSet.PriceType = Constants.PRICE_TYPE_SPECIAL;

        //查询
        businessTypePriceSetAction.InitCustomQuery(businessTypePriceSetAction.Model);
    }
    #endregion

    #region 操作保存
    /// <summary>
    /// 方法名称: DeleteProcess
    /// 功能概要: 删除价格
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-27
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void DeleteProcess()
    {
        model.BusinessTypePriceSet = new BusinessTypePriceSet();
        model.BusinessTypePriceSet.Id = int.Parse(txtId.Value);
        businessTypePriceSetAction.Delete(model);

    }
    #endregion
}
