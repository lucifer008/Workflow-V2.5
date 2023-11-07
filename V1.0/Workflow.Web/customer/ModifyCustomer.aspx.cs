using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称:ModifyCustomer
/// 功能概要: 编辑客户信息
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
/// 修 正 人: 张晓林
/// 修正时间:2009年2月10日16:50:29
/// 修正描述: 增加异常捕获功能
/// </summary>

public partial class ModifyCustomer : Workflow.Web.PageBase
{
	#region //类成员
    protected bool updateTag = false;//标志是否直接刷新页面
    protected bool insertTag = false;
    protected NewCustomerModel model;

    private NewCustomerAction action;
    public NewCustomerAction NewCustomerAction
    {
        set { action = value; }
    }
	#endregion

	#region //页面加载
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

                //判断是编辑，还是检索
                if (string.Compare(Request.QueryString["Id"], null) != 0)
                {
                    CustomerId.Text = Request.QueryString["Id"];
                    Tag.Value = Request.QueryString["Tag"];
                    model.Id = NumericUtils.ToLong(CustomerId.Text);
                    SearchCustomer();
                    action.SearchLinkManByCustomerId();

                    updateTag = true;
                }

            }
            //action.InitCutomerType();
            //执行删除联系人
            string strDeleteTag = this.deleteTag.Value;
            if (string.Compare(strDeleteTag, "delete") == 0)
            {
                long deleteId = Workflow.Util.NumericUtils.ToLong(this.deleteId.Value);
                DeleteLinkMan(deleteId);
            }

            //页面直接刷新
            if (!StringUtils.IsEmpty(CustomerId.Text) && !updateTag)
            {
                model.Id = NumericUtils.ToLong(CustomerId.Text);
                action.SelectLinkManByCustomerId();
                action.SearchCustomerById();
            }
            //Add:Cry,Date:2009-1-14,添加选择支付方式时的客户端授权验证    
            PayType.Attributes.Add("OnChange", "arrear(5);");
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
	#endregion

    #region //页面初始化
    /// <summary>
    /// 页面初始化
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-9-26
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void InitData()
    {
        action.Init();

        foreach (MasterTrade mt in model.MasterTradeList)
        {
            ListItem item = new ListItem(mt.Name, "0");
            item.Attributes.Add("disabled", "disabled");
            Trade.Items.Add(item);
            foreach (SecondaryTrade st in mt.SecondaryTradeList)
            {
                Trade.Items.Add(new ListItem("　" + st.Name, st.Id.ToString()));
            }
        }

        CustomerLevel.DataSource = model.CustomerLevelList;
        CustomerLevel.DataTextField = "NAME";
        CustomerLevel.DataValueField = "Id";
        CustomerLevel.DataBind();

        List<CustomerType> customerTypeList=(List<CustomerType>)model.CustomerTypeList;
        for (int i = 0; i < customerTypeList.Count; i++)
        {
            if (customerTypeList[i].Id == -1 || customerTypeList[i].Name == "请选择")
            {
                customerTypeList.RemoveAt(i);
            }
        }
        CustomerType.DataSource = customerTypeList;
        CustomerType.DataTextField = "NAME";
        CustomerType.DataValueField = "Id";
        CustomerType.DataBind();

        PayType.DataSource = model.PaymentTypes;
        PayType.DataTextField = "label";
        PayType.DataValueField = "value";
        PayType.DataBind();
    }
    #endregion  
    
    #region //查询
    /// <summary>
    /// 查询客户
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-9-29
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void SearchCustomer()
    {
        action.SearchCustomerById();

        if (model.Customer != null)
        {
            CustomerName.Text = model.Customer.Name;
            SimpleName.Text = model.Customer.SimpleName;
            Trade.SelectedValue = Convert.ToString(model.Customer.SecondaryTrade.Id);
            CustomerLevel.SelectedValue = Convert.ToString(model.Customer.CustomerLevel.Id);
            CustomerType.SelectedValue = Convert.ToString(model.Customer.CustomerType.Id);
            Address.Text = model.Customer.Address;
            LinkMan.Text = model.Customer.LastLinkMan;
            TelNo.Text = model.Customer.LastTelNo;

            if (model.Customer.ValidateStatus == Workflow.Support.Constants.CUSTOMER_VALIDATE_STATUS_KEY)
            {
                ValidateStatus.Checked = true;
            }

            if (model.Customer.NeedTicket == Workflow.Support.Constants.NEED_TICKET_KEY)
            {
                NeedTicket.Checked = true;
            }

            if (model.Customer.PayType == Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE)
            {
                PayType.SelectedValue = Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE.ToString();
            }
            else if (model.Customer.PayType == Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE)
            {
                PayType.SelectedValue = Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE.ToString();
            }

            Memo.Text = model.Customer.Memo;
            //searchTag = true;
        }
        else
        {
            CustomerName.Text = "";
            SimpleName.Text = "";
            Trade.SelectedIndex = 0;
            CustomerLevel.SelectedIndex = 0;
            CustomerType.SelectedIndex = 0;
            Address.Text = "";
            LinkMan.Text = "";
            TelNo.Text = "";

            ValidateStatus.Checked = false;
            NeedTicket.Checked = false;
            Memo.Text = "";
        }
    }
    #endregion

    #region //更新客户信息
     /// <summary>
     /// 更新客户信息
     /// </summary>
     /// <remarks>
     /// 作    者: 刘伟
     /// 创建时间: 2007-9-29
	  /// 修 正 人: 陈汝胤
     /// 修正时间: 2009-1-9
     /// 修正描述: 修正保存时.是否使用发票,支付方式的不更新错误
     /// </remarks>
    protected void UpdateCustomerInfo(object sender, EventArgs e)
    {
        try
        {
            if (string.Compare(CustomerId.Text, "") != 0)
            {
                model.Id = NumericUtils.ToLong(CustomerId.Text);
                //searchTag = true;

                model.Customer = new Workflow.Da.Domain.Customer();

                model.Customer.Id = NumericUtils.ToLong(CustomerId.Text);
                model.Customer.Name = CustomerName.Text;
                model.Customer.SimpleName = SimpleName.Text;

                model.Customer.SecondaryTrade = new Workflow.Da.Domain.SecondaryTrade();
                model.Customer.SecondaryTrade.Id = NumericUtils.ToLong(Trade.SelectedValue);

                model.Customer.CustomerLevel = new Workflow.Da.Domain.CustomerLevel();
                model.Customer.CustomerLevel.Id = NumericUtils.ToLong(CustomerLevel.SelectedValue);

                model.Customer.CustomerType = new Workflow.Da.Domain.CustomerType();
                model.Customer.CustomerType.Id = NumericUtils.ToLong(Request.Form["customerType"]);//CustomerType.SelectedValue);

                model.Customer.Address = Address.Text;
                model.Customer.LastLinkMan = LinkMan.Text;
                model.Customer.LastTelNo = TelNo.Text;
                model.Customer.Memo = Memo.Text;
                model.Customer.NeedTicket = NeedTicket.Checked ? Constants.TRUE : Constants.FALSE;
                if (!ValidateStatus.Checked)
                {
                    model.Customer.ValidateStatus = Workflow.Support.Constants.CUSTOMER_NOT_VALIDATE_STATUS_KEY;
                }
                else
                {
                    model.Customer.ValidateStatus = Workflow.Support.Constants.CUSTOMER_VALIDATE_STATUS_KEY;
                }
                if (Convert.ToInt32(PayType.SelectedValue) == Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE)
                {
                    model.Customer.PayType = Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE;
                }
                else if (Convert.ToInt32(PayType.SelectedValue) == Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE)
                {
                    model.Customer.PayType = Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE;
                }
                action.UpdateCustomer();

                Response.Write("<script>window.returnValue='ok';window.close();</script>");

            }
            //SearchCustomer();
            insertTag = true;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion

    #region 删除联系人
    /// <summary>
    /// 删除联系人
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-9-29
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void DeleteLinkMan(long Id)
    {
        model.LinkMan = new Workflow.Da.Domain.LinkMan();
        model.LinkMan.Id = Id;
        //searchTag = true;
        action.DeleteLinkMan();
       
        model.Id = NumericUtils.ToLong(CustomerId.Text);
        SearchCustomer();
    }
    #endregion

}
