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
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Action.Model;

/// <summary>
/// 名    称: GetOrder
/// 功能概要: 上门取活
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class GetOrder : Workflow.Web.PageBase
{
    #region 类成员
    private TakeWorkAction action;
    protected TakeWorkModel model;

    public TakeWorkAction TakeWorkAction
    {
        set { action = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = action.Model;
            //if (!IsPostBack)
            //{
                InitData();
            //}
           
            //删除取活
            string strDeleteTag = this.deleteTag.Value;
            if (string.Compare(strDeleteTag, "delete") == 0)
            {
                long deleteId = Workflow.Util.NumericUtils.ToLong(this.deleteId.Value);
                DeleteTakeWork(deleteId);
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 页面初始化
    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-8
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    private void InitData()
    {
        action.SearchTakeWork();
    }
    #endregion

    #region 删除取活信息
    /// <summary>
    /// 删除取活信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-8
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    private void DeleteTakeWork(long Id)
    {
        model.Id = Id;
        action.DeleteTakeWork();

        InitData();
    }
    #endregion
}
