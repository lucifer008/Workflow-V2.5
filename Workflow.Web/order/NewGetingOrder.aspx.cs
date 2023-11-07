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
/// 名    称: NewGetingOrder
/// 功能概要: 新增取活
/// 作    者: 付强
/// 创建时间: 2007-9-13
/// 修正履历: 
/// 修正时间: 
/// </summary>
public partial class NewGetingOrder : Workflow.Web.PageBase
{
    #region 类成员
    private TakeWorkAction action;
    protected TakeWorkModel model;
    //标记是否刷新父页面
    protected bool parentSubmitTag = false;

    public TakeWorkAction TakeWorkAction
    {
        set { action = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = action.Model;

        if (!IsPostBack)
        {
            InitData();
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
    /// 创建时间: 2007-10-10
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    private void InitData()
    {
        try
        {
            action.SearchAllEmployee();

            DeliveryMan.DataSource = model.EmployeeList;
            DeliveryMan.DataTextField = "Name";
            DeliveryMan.DataValueField = "Id";
            DeliveryMan.DataBind();

            //编辑客户时，初始化内容
            EditTakeWord();
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 编辑客户时，初始化内容
    /// <summary>
    /// 编辑客户时，初始化内容
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-10
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    private void EditTakeWord()
    {
        if (Request.QueryString["Id"] != null)
        {
            long Id = NumericUtils.ToLong(Request.QueryString["Id"]);
            CustomerId.Value = Id.ToString();

            model.Id = Id;
            action.SearchTakeWorkById();

            TakeWorkId.Value = model.TakeWork.Id.ToString();
            TakeWorkNo.Text = model.TakeWork.No;
            CustomerId.Value = model.TakeWork.CustomerId.ToString();
            CustomerName.Text = model.TakeWork.CustomerName;
            Address.Text = model.TakeWork.Address;
            TelNo.Text = model.TakeWork.TelNo;
            LinkMan.Text = model.TakeWork.LinkManName;
            Memo.Text = model.TakeWork.Memo;
            Finished.SelectedValue = model.TakeWork.Finished;
            DeliveryMan.SelectedValue = model.TakeWork.Employee.Id.ToString();
            txtFrom.Value = model.TakeWork.BeginDateTime.ToString("yyyy-MM-dd hh:mm");

            if (DateTime.Compare(model.TakeWork.EndDateTime, Constants.NULL_DATE_TIME) == 0)
            {
                txtTo.Value = "";
            }
            else
            {
                txtTo.Value = model.TakeWork.EndDateTime.ToString("yyyy-MM-dd hh:mm");
            }

        }
    }
    #endregion

    #region 插入或更新取活信息(事件)
    /// <summary>
    /// 插入取活信息
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-10
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    protected void InsertDeliveryInfo(object sender, EventArgs e)
    {
        try
        {
            model.TakeWork = new Workflow.Da.Domain.TakeWork();

            model.TakeWork.No = TakeWorkNo.Text;
            model.TakeWork.CustomerId =NumericUtils.ToLong(CustomerId.Value);
            model.TakeWork.Address = Address.Text;
            model.TakeWork.TelNo = TelNo.Text;
            model.TakeWork.LinkManName = LinkMan.Text;
            model.TakeWork.Memo = Memo.Text;
            model.TakeWork.Finished = Finished.SelectedValue;

            model.TakeWork.BeginDateTime =Convert.ToDateTime(txtFrom.Value);

            if (txtTo.Value != "")
            {
                model.TakeWork.EndDateTime = Convert.ToDateTime(txtTo.Value);
            }
            else 
            {
                model.TakeWork.EndDateTime = Constants.NULL_DATE_TIME;
            }

            model.TakeWork.Employee = new Workflow.Da.Domain.Employee();
            model.TakeWork.Employee.Id =NumericUtils.ToLong(DeliveryMan.SelectedValue);

            if (!this.IsValid)
            {
     
            }
            //判断是新增还是编辑
            if (TakeWorkId.Value == "")
            {
                //新增
                action.InsertTakeWork();
                TakeWorkNo.Text = "";
            }
            else
            {
                model.TakeWork.Id =NumericUtils.ToLong(TakeWorkId.Value);
                //编辑
                action.UpdateTakeWork();
            }

            parentSubmitTag = true;
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }
    #endregion
}
