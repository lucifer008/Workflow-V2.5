using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;

/// <summary>
/// 名    称:NewCustomerLinkMan
/// 功能概要: 新增客户联系人
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
/// 修 正 人: 张晓林
/// 修正时间:2009年2月10日16:42:39
/// 修正描述:增加异常捕获功能
/// </summary>

public partial class NewCustomerLinkMan : Workflow.Web.PageBase
{
	#region //类成员
	private NewCustomerAction action;
    protected NewCustomerModel model;

    public NewCustomerAction NewCustomerAction
    {
        set { action = value; }
    }
    private static long currentId;
    private static long CustomerId;

    #endregion

    #region //页面属性加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            Response.AppendHeader("pragma", "no-cache");
            Response.AppendHeader("Cache-Control", "no-cache, must-revalidate");
            Response.AppendHeader("expires", "0");

            model = action.Model;
            if (!IsPostBack)
            {
                InitData();
            }
            else
            {
                if (0 == currentId)
                {
                    //新增加
                    model.LinkMan = new LinkMan();
                    model.LinkMan.CustomerId = CustomerId;
                    EditorLinkMan();
                    action.InsertLinkMan();

                }
                else
                {
                    //更新
                    model.LinkManId = currentId;
                    action.SearchLinkManByPk();
                    EditorLinkMan();
                    action.UpdateLinkMan();
                }
            }
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }

    /// <summary>
    /// 功能概要: 初始化页面数据
    /// 作    者: 陈汝胤
    /// 创建时间: 2009-1-16
    /// 修 正 人: 
    /// 修正时间: 
    /// 修正描述: 
    /// </summary>
    private void InitData()
    {
        currentId = 0;
        model = action.Model;
        string id = Request.QueryString["id"];
        string name = Request.QueryString["name"];
        if (null != id && id != "")
        {

            if (null != name && name != "")
                model.Name = name;
            model.LinkManId = long.Parse(id);
            model.Action = "修改";
            currentId = model.LinkManId;
            action.SearchLinkManByPk();
        }
        else
        {
            model.LinkMan = new LinkMan();
            string cId = Request.QueryString["cid"];
            CustomerId = long.Parse(cId);
            if (null != name && name != "")
                model.Name = name;
        }
    }
    #endregion

    #region //绑定编辑联系人信息
    /// <summary>
    /// 编辑联系人信息
    /// </summary>
    /// <remarks>
    /// 作    者: 陈汝胤 
    /// 修正时间: 2009-1-16
    /// 修正履历:
    /// </remarks>
    private void EditorLinkMan()
    {
        model.LinkMan.Name = Request.Form["txtName"];
        model.LinkMan.Sex = Request.Form["radSex"];
        string age=Request.Form["txtAge"];
        if (null != age)
            model.LinkMan.Age = int.Parse(age);
        model.LinkMan.Position = Request.Form["txtPosition"];
        model.LinkMan.Hobby = Request.Form["txtHobby"];
        model.LinkMan.CompanyTelNo = Request.Form["txtCompanyPhone"];
        model.LinkMan.MobileNo = Request.Form["txtMobilePhone"];
        model.LinkMan.Qq = Request.Form["txtQQ"];
        model.LinkMan.Email = Request.Form["txtEMail"];
        model.LinkMan.Address = Request.Form["txtAddress"];
        model.LinkMan.Memo = Request.Form["txtMemo"];
    }
    #endregion
}
