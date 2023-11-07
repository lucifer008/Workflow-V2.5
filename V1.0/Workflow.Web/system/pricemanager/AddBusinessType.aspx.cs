using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Web.UI.WebControls.WebParts;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Action.Model;
using Workflow.Support.Exception;

/// <summary>
/// 名    称: AddBusinessType
/// 功能概要: 追加业务类型
/// 作    者: 麻少华
/// 创建时间: 2007-9-18
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理  
/// </summary>
public partial class AddBusinessType : Workflow.Web.PageBase
{
    #region 类成员
    protected bool closeSelf = false;
    protected PriceModel model;
    private int intAction = Constants.ACTION_INIT;
    protected PriceAction priceAction;
    public PriceAction PriceAction
    {
        set { priceAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.AppendHeader("pragma", "no-cache");
        //Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
        //Response.AppendHeader("expires", "0");
        model = priceAction.Model;
        //获得页面动作
        if (Request.Form["txtAction"] != null)
        {
            intAction = int.Parse(Request.Form["txtAction"]);
        }

        //if (!this.IsPostBack)
        //{   
        //}
        if (intAction == Constants.ACTION_INIT)
        {
            //初始化页面需要的数据
            this.InitData();
        }
        else if (intAction == Constants.ACTION_INSERT)
        {
            SaveProcess();
            //初始化页面需要的数据
            this.InitData();
        }
    }
    #endregion

    #region 数据初始化
    /// <summary>
    /// 方法名称: InitData
    /// 功能概要: 初时数据准备
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-12
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void InitData()
    {   
        //初始化数据
        priceAction.InitData();
        //数据绑定
        //MainRepeater.DataSource = priceAction.Model.PriceFactor;
        //MainRepeater.DataBind();
    }
    /// <summary>
    /// 方法名称: PrepareModel
    /// 功能概要: Model数据准备
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>

    private void PrepareModel()
    {
        string strBusinessName = "";
        if (Request.Form["txtBusinessName"] != null)
        {
            strBusinessName = Request.Form["txtBusinessName"];
        }
        //因素列表
        string[] strFactorList = null;
        //因素个数
        int intCount = 0;
        if (Request["chkFactor"] != null)
        {
            strFactorList = Request["chkFactor"].Split(',');
            intCount = strFactorList.Length;
        }
        //创建业务对象
        model.BusinessType = new Workflow.Da.Domain.BusinessType();
        //业务类型名称
        model.BusinessType.Name = strBusinessName;
        model.BusinessType.NeedRecordMachine = "Y";

        model.BusinessTypePriceFactor = new List<BusinessTypePriceFactor>();

        for (int i = 0; i < intCount; i++)
        {
            //创建BusinessTypePriceFactor对象
            model.BusinessTypePriceFactor.Add(new Workflow.Da.Domain.BusinessTypePriceFactor());
            //客户选择的因素ID
            model.BusinessTypePriceFactor[i].PriceFactorId = long.Parse(strFactorList[i]);
            //排序号(暂且保留)
            model.BusinessTypePriceFactor[i].SortNo = i;
            //业务类型ID
            model.BusinessTypePriceFactor[i].BusinessTypeId = priceAction.Model.BusinessType.Id;
        }
    }
    #endregion

    #region  保存操作
    /// <summary>
    /// 方法名称: SavaProcess
    /// 功能概要: 
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void SaveProcess()
    {
        //Model数据准备
        PrepareModel();
        //插入业务类型
        try
        {
            priceAction.InsertBusinessType(priceAction.Model);
        }
        catch (WorkflowException ex)
        {
            throw ex;
        }
        closeSelf = true;
    }
    #endregion

    #region Button 事件
    /// <summary>
    /// 方法名称: btnCancel_Click
    /// 功能概要: 取消处理,关闭页面
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void BtnCancel_Click(object sender, EventArgs e)
    {
        closeSelf = true;
    }
    #endregion
}
