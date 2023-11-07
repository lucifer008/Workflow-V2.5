using System;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 功能概要: NewCustomer
/// 作    者: 
/// 创建时间: 
/// 修 正 人: 陈汝胤
/// 修正时间: 2009-1-19
/// 修正描述: 代码整理
/// </summary>

public partial class NewCustomer : Workflow.Web.PageBase
{
	#region //类成员
	private NewCustomerAction action;
    protected NewCustomerModel model;

    protected bool insertTag = false;
    protected string returnMethod = "selectCustomer";
    protected bool bStatic =false;//标记在新增客户后是否应该关闭窗口,并返回一个Customer对象.false不关闭,true关闭
    protected bool displayCustomerList = true; //新增成功后点击返回按钮是显示客户一览还是直接返回 true 显示客户一览 false 直接返回
    protected bool okReturn = false;//点击确定后是否直接返回 true直接返回 false 显示返回按钮
    /// <summary>
    /// Sets the new customer action.
    /// </summary>
    /// <value>The new customer action.</value>
    public NewCustomerAction NewCustomerAction
    {
        set { action = value; }
    }
	#endregion
	
    #region  //页面初始化
    protected void Page_Load(object sender, EventArgs e)
    {
        if (ThreadLocalUtils.CurrentUserContext == null || ThreadLocalUtils.CurrentUserContext.CurrentUser == null)
        {
            Response.Write("<script>parent.location.href='../Login.aspx';</script>");
            Response.End();
        }

        model = action.Model;
        if (Request.QueryString[Constants.KEY_CALLBACK] != null)
        {
            returnMethod = Request.QueryString[Constants.KEY_CALLBACK];
        }
        if (!IsPostBack)
        {
            ParentPage.Value = Request.QueryString["Tag"];
            InitData();
        }

        action.InitCutomerType();
        if (ParentPage.Value != "1")
        {
            displayCustomerList = false;
        }
        customerLevel.SelectedIndex = 1;
    }

	#region //InitData()
	/// <summary>
    /// 页面初始化
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-9-21
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void InitData()
    {
        action.InitCustomer();

        foreach (Workflow.Da.Domain.MasterTrade mt in model.MasterTradeList)
        {
            ListItem item = new ListItem(mt.Name, "0");
            item.Attributes.Add("disabled", "disabled");
            Trade.Items.Add(item);
            foreach (Workflow.Da.Domain.SecondaryTrade st in mt.SecondaryTradeList)
            {
                Trade.Items.Add(new ListItem("　" + st.Name, st.Id.ToString()));
            }
        }

        this.MakeSelectDefaultItem(Trade);

        customerLevel.DataSource = model.CustomerLevelList;
        customerLevel.DataTextField = "NAME";
        customerLevel.DataValueField = "Id";
        customerLevel.DataBind();
        this.MakeSelectDefaultItem(this.customerLevel);

        //CustomerType.DataSource = model.CustomerTypeList;
        //CustomerType.DataTextField = "NAME";
        //CustomerType.DataValueField = "Id";
        //CustomerType.DataBind();

        //this.MakeSelectDefaultItem(this.CustomerType);

        //支付方式
        this.cbPaymentType.DataSource = model.PaymentTypes;
        this.cbPaymentType.DataTextField = "label";
        this.cbPaymentType.DataValueField = "value";
        this.cbPaymentType.DataBind();

        

    }
	#endregion
   
    #endregion

	#region //新增
	/// <summary>
    /// 新增客户
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: 刘伟
    /// 创建时间: 2007-9-21
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void InsertNewCustomer(object sender, EventArgs e)
    {
        try
        {
            model.Name = CustomerName.Text;
            model.SimpleName = SimpleName.Text;
            model.SecondaryTradeId = NumericUtils.ToLong(Trade.SelectedValue);
            model.CustomerLevelId = NumericUtils.ToLong(customerLevel.SelectedValue);
            model.CustomerTypeId = NumericUtils.ToLong(Request.Form["customerType"]);
            model.CustomerTypeName = hiddCutomerTypeName.Value;// CustomerType.Items[CustomerType.SelectedIndex].Text;
            model.CustomerLevelName = customerLevel.Items[customerLevel.SelectedIndex].Text;

            if (model.SecondaryTradeId <= 0)
            {
                model.SecondaryTradeId = 1;
            }
            if (model.CustomerLevelId <= 0)
            {
                model.CustomerLevelId = 1;
            }
            model.Address = Address.Text;
            model.LinkManName = LinkManName.Text;
            model.TelNo = TelNo.Text;
            model.Memo = Memo.Text;
            model.PayType = int.Parse(cbPaymentType.Value);
            if (NeedTicket.Checked)
            {
                model.NeedTicket = Constants.TRUE;
                model.NeedTicketName = "需要";
            }
            else
            {
                model.NeedTicket = Constants.FALSE;
                model.NeedTicketName = "";
            }
            if (Age.Text != "")
            {
                model.Age = Convert.ToInt32(Age.Text);
            }
            model.Email = EMAIL.Text;
            model.Hobby = Hobby.Text;
            model.MobileNo = MobileNo.Text;
            model.QQ = QQ.Text;
            model.Sex = Sex.SelectedValue;
            model.Position = Position.Text;
            model.PaymentTypeString = cbPaymentType.Items[cbPaymentType.SelectedIndex].Text;
            action.InsertCustomer();
            CustomerId.Value = model.Id.ToString();
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
        if (ParentPage.Value != "1")
        {
            bStatic = true;
        }
        else
        {
            //NewLinkMan.Visible = true;
        }
        if (ParentPage.Value == "2")
        {
            okReturn = true;
        }

        insertTag = true;
        //setDefault();
    }
    private void setDefault() 
    {
        CustomerName.Text = "";
        SimpleName.Text = "";
        //Trade.SelectedIndex= 0;
        //CustomerType.SelectedIndex = 0;
        Address.Text = "";
        LinkManName.Text = "";
        TelNo.Text = "";
        MobileNo.Text = "";
        model.Memo = Memo.Text;
        cbPaymentType.SelectedIndex=0;
        NeedTicket.Checked=false;
        Age.Text="";
        EMAIL.Text="";
        Hobby.Text="";
        MobileNo.Text="";
        QQ.Text="";
        Sex.SelectedIndex =0;
        Position.Text = "";
    }
    #endregion

}