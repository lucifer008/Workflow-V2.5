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
/// 名    称: EditBusinessType
/// 功能概要: 业务类型的编辑
/// 作    者: 麻少华
/// 创建时间: 2007-9-18
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
/// </summary>
public partial class EditBusinessType : Workflow.Web.PageBase
{
    #region 类成员
    protected bool closeSelf = false;
    //业务类型ID
    private long lngBusinessTypeId = 0;
    //业务类型名称
    private string strBusinessTypeName = "";
    protected int intAction = Constants.ACTION_INIT;
    protected PriceAction priceAction;
    public PriceAction PriceAction
    {
        set { priceAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        //获得页面动作
        if (Request.Form["txtAction"] != null)
        {
            intAction = int.Parse(Request.Form["txtAction"]);
        }
        //if (!this.IsPostBack)
        //{
        //    //Response.AppendHeader("pragma", "no-cache");
        //    //Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
        //    //Response.AppendHeader("expires", "0");


        //    //初始化页面需要的数据
        //    this.InitData();
        //}
        //判断页面动作执行不同的处理
        //初始化显示
        if (intAction == Constants.ACTION_INIT)
        {
            #region 前页面参数获得
            //取得业务ID
            if (Request.QueryString["id"] != null)
            {
                lngBusinessTypeId = long.Parse(Request.QueryString["id"]);
            }
            //业务类型名称
            if (Request.QueryString["name"] != null)
            {
                strBusinessTypeName = Request.QueryString["name"].ToString();
            }
            #endregion
            InitData();
        }
        else if (intAction == Constants.ACTION_UPDATE)
        {
            SavePriceSet();
        }
    }
    #endregion

    #region 数据准备
    /// <summary>
    /// 方法名称: InitData
    /// 功能概要: 初始数据准备
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    private void InitData()
    {
        //初始化数据
        priceAction.Model.BusinessType = new Workflow.Da.Domain.BusinessType();
        priceAction.Model.BusinessType.Id = lngBusinessTypeId;
        priceAction.Model.BusinessType.Name = strBusinessTypeName;
        //初时数据
        priceAction.InitDataForUpdate();
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
        //业务类型ID
        long lngBusinessTypeId = long.Parse(Request.Form["txtBusinessId"]);
        //业务类型名称
        string strBusinessName = Request.Form["txtBusinessName"].ToString();
        //被选中的因素List
        string[] strFactorList = null;
        //被选中的因素个数
        int intCount = 0;
        if (Request["chkFactor"] != null)
        {
            strFactorList = Request["chkFactor"].Split(',');
            intCount = strFactorList.Length;
        }

        //priceAction.Model.BusinessType = null;
        //给BusinessType对象赋值
        //业务类型ID
        priceAction.Model.BusinessType = new Workflow.Da.Domain.BusinessType();
        priceAction.Model.BusinessType.Id = lngBusinessTypeId;
        //业务类型名称
        priceAction.Model.BusinessType.Name = strBusinessName;

        priceAction.Model.BusinessTypePriceFactor = new List<BusinessTypePriceFactor>();

        //给BusinessTypePriceFactor对象赋值
        for (int i = 0; i < intCount; i++)
        {   
            priceAction.Model.BusinessTypePriceFactor.Add(new Workflow.Da.Domain.BusinessTypePriceFactor());
            //选择的因素ID
            priceAction.Model.BusinessTypePriceFactor[i].PriceFactorId = long.Parse(strFactorList[i]);
            //排序号(目前保留)
            priceAction.Model.BusinessTypePriceFactor[i].SortNo = i;
            //业务类型ID
            priceAction.Model.BusinessTypePriceFactor[i].BusinessTypeId = priceAction.Model.BusinessType.Id;
        }
    }
    #endregion

    #region 操作保存
    /// <summary>
    /// 方法名称: SavePriceSet
    /// 功能概要: 修改当前的业务类型
    /// 作    者: 麻少华
    /// 创建时间: 2007-9-18
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void SavePriceSet()
    {
        //Model数据准备
        PrepareModel();
        try
        {
            priceAction.UpdateBusinessType(priceAction.Model);
        }
        catch (WorkflowException ex)
        {
            throw ex;
        }
        closeSelf = true;
    }
    #endregion
}
