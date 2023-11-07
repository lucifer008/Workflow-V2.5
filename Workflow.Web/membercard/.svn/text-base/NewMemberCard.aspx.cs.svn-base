using System;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
using Workflow.Support.Encrypt;
using Workflow.Action.Membercard;
/// <summary>
/// 名    称: NewMemberCard
/// 功能概要: 发卡
/// 作    者: liuwei
/// 创建时间: 2007-9-30
/// 修正履历: 张晓林
/// 修正时间: 2008-11-1
///             完善发卡功能
///           2009-01-17
///             增加捕获异常处理,调整页面
/// </summary>
public partial class NewMemberCard : Workflow.Web.PageBase
{

	#region //Class Member
    protected string strTitle = "发卡";
    protected string strAge = "";
    protected MemberCardModel model;
    private MemberCardAction action;
    public MemberCardAction MemberCardAction
    {
        set { action = value; }
	}

    private SearchMemberCardAction searchMemberCardAction;
    public SearchMemberCardAction SearchMemberCardAction 
    {
        set { searchMemberCardAction = value; }
    }

	#endregion

    #region //Page_Load
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            model = searchMemberCardAction.Model;
            if (!IsPostBack)
            {
                InitData();
                BingEdmitData();
            }
            //this.dropListCustomerType.SelectedIndex = 1;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex,Constants.LOGGER_NAME);
            throw ex;
        }
    }

    /// <summary>
    /// 加载修改的会员卡信息
    /// </summary>
    /// 
    private void BingEdmitData()
    {
        if (null != Request.QueryString["Id"] && "" != Request.QueryString["Id"])
        {
            strTitle = "编辑会员卡";
            Response.Expires = -1;//绑定之前清除页面缓存
            model.Id = Convert.ToInt32(Request.QueryString["Id"]);
            searchMemberCardAction.SearchMemberById();
            trade.SelectedValue = Convert.ToString(model.MemberCard.TradeId);//客户所属行业
            customerLevel.SelectedValue = Convert.ToString(model.MemberCard.CustomerLevelId);//客户级别
            memberCardLevel.SelectedValue = Convert.ToString(model.MemberCard.MemberCardLevelId);//卡级别
            dropListCustomerType.SelectedValue = Convert.ToString(model.MemberCard.CustomerTypeId);//客户类型
            cbPaymentType.Value = Convert.ToString(model.MemberCard.PayType);//支付方式
            this.memo.Text = model.MemberCard.Memo;
            if (model.MemberCard.Age != 0)
            {
                strAge = Convert.ToString(model.MemberCard.Age);
            }
            if (model.MemberCard.NeedTicket == "Y")
            {
                needTicket.Checked = true;
            }
            customerId.Value = Convert.ToString(model.MemberCard.CustomerId);
            hiddOperateTag.Value = "Update";//记录操作状态
            hiddMemberState.Value = model.MemberCard.MemberState;//记录卡状态
            hiddMemberCardId.Value = Request.QueryString["Id"];//记录memberCardId
            hiddConsumeAmount.Value = Convert.ToString(model.MemberCard.ConsumeAmount);//记录会员消费金额
            hiddIntegral.Value = Convert.ToString(model.MemberCard.Integral);//记录会员积分
            hiddCustomerValidateStatus.Value = Convert.ToString(model.MemberCard.CustomerValidateStatus);//记录客户确认状态
            string strMemberCardNo=model.MemberCard.IdentityCardNo.Trim();
            if (strMemberCardNo.Length<15)
            {
                cbCredentials.Checked = true;
            }
        }
        if (null == model.MemberCard)
        {
            model.MemberCard = new MemberCard();
        }
    }

    #endregion

    #region //InitData
    /// <summary>
    /// 初始化页面
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-9-30
    /// 修正履历:
    /// 修正时间:
    /// </remarks>	
    private void InitData()
    {
        searchMemberCardAction.Init();

        foreach (Workflow.Da.Domain.MasterTrade mt in model.MasterTradeList)
        {
			if(mt.Id!=0)
			{
				ListItem item = new ListItem(mt.Name, "0");
				item.Attributes.Add("disabled", "disabled");
				trade.Items.Add(item);
				foreach (Workflow.Da.Domain.SecondaryTrade st in mt.SecondaryTradeList)
				{
					trade.Items.Add(new ListItem("　" + st.Name, st.Id.ToString()));
				}
			}
            
        }

        customerLevel.DataSource = model.CustomerLevelList;//客户级别
        customerLevel.DataTextField = "Name";
        customerLevel.DataValueField = "Id";
        customerLevel.DataBind();

        dropListCustomerType.DataSource = model.CustomerTypeList;//客户类型
        dropListCustomerType.DataTextField = "NAME";
        dropListCustomerType.DataValueField = "Id";
        dropListCustomerType.DataBind();
        //dropListCustomerType.SelectedIndex = 1;
        //dropListCustomerType.SelectedValue =0;

        this.cbPaymentType.DataSource = model.PaymentTypes;//支付方式
        this.cbPaymentType.DataTextField = "label";
        this.cbPaymentType.DataValueField = "value";
        this.cbPaymentType.DataBind();
        searchMemberCardAction.GetMemberCardLevel();

        memberCardLevel.DataSource = model.MemberCardLevelList;//卡级别
        memberCardLevel.DataTextField = "Name";
        memberCardLevel.DataValueField = "Id";
        
        memberCardLevel.DataBind();
    }
    #endregion

    #region //InsertAndUpdate
    /// <summary>
    /// 新添加会员卡
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-9-30
    /// 修正履历:
    /// </remarks>	
    protected void insertNewMemberCard(object sender, EventArgs e)
    {

		try
		{
			if(customerId.Value != "")
            {

                #region //获取会员卡中的信息
                model.MemberCard = new Workflow.Da.Domain.MemberCard();

                model.MemberCard.CustomerId = NumericUtils.ToLong(customerId.Value);
                model.MemberCard.MemberCardNo = Request.Form.Get("memberCardNo").Trim().ToLower();					//卡号

                model.MemberCard.MemberCardLevel = new Workflow.Da.Domain.MemberCardLevel();		                  //卡级别
                model.MemberCard.MemberCardLevel.Id = NumericUtils.ToLong(memberCardLevel.SelectedValue);

                model.MemberCard.Password = "";//EncryptUtils.HexMD5(Request.Form.Get("passWord"));				    //密码
                model.MemberCard.Name = Request.Form.Get("linkMan");
                if (Request.Form.Get("age") != "")													              //年龄
                {
                    model.MemberCard.Age = Convert.ToInt32(Request.Form.Get("age"));
                }
                model.MemberCard.Email = Request.Form.Get("email");									              //Email
                model.MemberCard.Hobby = Request.Form.Get("hobby");
                model.MemberCard.MobileNo = Request.Form.Get("mobileNo");							                 //移动电话
                model.MemberCard.Position = Request.Form.Get("position");							                 //职位
                model.MemberCard.Sex = sex.SelectedValue;
                model.MemberCard.IdentityCardNo = Request.Form.Get("identityCard");
                if (Convert.ToString(needTicket.Checked).Substring(0, 1) == "T")
                {
                    model.MemberCard.NeedTicket = "Y";//
                }
                else
                {
                    model.MemberCard.NeedTicket = "N";//
                }
                if (Request.Form.Get("txtFrom") != "")
                {
                    model.MemberCard.MemberCardBeginDate = Convert.ToDateTime(Request.Form.Get("txtFrom"));//会籍开始日
                }
                if (Request.Form.Get("txtTo") != "")
                {
                    model.MemberCard.MemberCardEndDate = Convert.ToDateTime(Request.Form.Get("txtTo"));	   //会籍到期日
                }
                else
                {
                    model.MemberCard.MemberCardEndDate = Workflow.Support.Constants.NULL_DATE_TIME;
                }
                #endregion

                #region///获取客户信息
                model.Customer = new Workflow.Da.Domain.Customer();
                model.Customer.Id = NumericUtils.ToLong(customerId.Value);
                model.Customer.Name = Request.Form.Get("customerName");
                model.Customer.SimpleName = Request.Form.Get("simpleName");

                model.Customer.SecondaryTrade = new Workflow.Da.Domain.SecondaryTrade();
                model.Customer.SecondaryTrade.Id = NumericUtils.ToLong(trade.SelectedValue);

                model.Customer.CustomerLevel = new Workflow.Da.Domain.CustomerLevel();
                model.Customer.CustomerLevel.Id = NumericUtils.ToLong(customerLevel.SelectedValue);

                model.Customer.Address = Request.Form.Get("address");
                model.Customer.LastTelNo = Request.Form.Get("telNo");
                model.Customer.LastLinkMan = Request.Form.Get("linkMan");

                model.Customer.CustomerType = new CustomerType();
                model.Customer.CustomerType.Id = NumericUtils.ToLong(dropListCustomerType.SelectedValue);//客户类型
                model.Customer.Memo = Request.Form.Get("memo");
                model.Customer.ValidateStatus = Convert.ToString(hiddCustomerValidateStatus.Value);//确认状态
                if (Convert.ToString(needTicket.Checked).Substring(0, 1) == "T")
                {
                    model.Customer.NeedTicket = "Y";//
                }
                else
                {
                    model.Customer.NeedTicket = "N";//
                }

                model.Customer.PayType = NumericUtils.ToInt(cbPaymentType.Value);//支付方式
                #endregion

                #region ///获取操作记录信息
                model.MemberOperateLog = new Workflow.Da.Domain.MemberOperateLog();
                model.MemberOperateLog.OperateType = Constants.MEMBER_CARD_OPERATE_GTANT_KEY;
                model.MemberOperateLog.Memo = "发卡";
                action.Model.MemberOperateLog = model.MemberOperateLog;
                #endregion

                if (hiddOperateTag.Value == "Add")//新增
                {
                   #region //新增
                    #region ///执行发卡操作
                    if (model.Customer.ValidateStatus == "确认")
                    {
                        model.Customer.ValidateStatus = Constants.CUSTOMER_VALIDATE_STATUS_KEY;
                    }
                    else 
                    {
                        model.Customer.ValidateStatus = Constants.CUSTOMER_NOT_VALIDATE_STATUS_KEY;
                    }
                    //按照卡号查询该卡号是否已经注销，若存在已经注销，则将该卡恢复可用
                    searchMemberCardAction.CheckMemberCardByNoAndCustomerId();
                    if (0!=searchMemberCardAction.Model.MemberCardList.Count)
                    {
                        string memberCardState=searchMemberCardAction.Model.MemberCardList[0].MemberState ;
                        if (memberCardState == Constants.MEMBER_CARD_OPERATE_LOGOUT_KEY)
                        {
                            model.MemberOperateLog.MemberCardId = searchMemberCardAction.Model.MemberCardList[0].Id;
                            model.MemberCard.Id = searchMemberCardAction.Model.MemberCardList[0].Id;
                            model.MemberCard.ConsumeAmount = searchMemberCardAction.Model.MemberCardList[0].ConsumeAmount;
                            model.MemberCard.Integral = searchMemberCardAction.Model.MemberCardList[0].Integral;
                            model.MemberCard.MemberState = Constants.MEMBER_CARD_OPERATE_GTANT_KEY;
                            action.Model.MemberCard = model.MemberCard;
                            action.Model.Customer = model.Customer;
                            action.UpdateMemberCard();
                        }
                    }
                    else //不存在,则发新卡
                    {
                        model.MemberCard.MemberState = Constants.MEMBER_CARD_OPERATE_GTANT_KEY;
                        action.Model.MemberCard = model.MemberCard;
                        action.Model.Customer = model.Customer;
                        action.InsertMemberCard();
                    }
                    Response.Redirect("NewMemberCard.aspx"); 
                    #endregion

                    memberCardLevel.SelectedIndex = 0;
                    trade.SelectedIndex = 0;
                    customerLevel.SelectedIndex = 0;
                    memo.Text = "";
                    needTicket.Checked = false;
                    #endregion
                }
                else if(hiddOperateTag.Value=="Update")//更新
                {
                     #region //更新
                    model.MemberCard.Id = Convert.ToInt32(hiddMemberCardId.Value);
                    model.MemberCard.MemberState = hiddMemberState.Value;//卡状态
                    model.MemberCard.ConsumeAmount = Convert.ToDecimal(hiddConsumeAmount.Value);//消费金额
                    model.MemberCard.Integral = Convert.ToInt32(hiddIntegral.Value);//积分
                    model.MemberOperateLog.MemberCardId = Convert.ToInt32(Request.QueryString["Id"]);//membercardId
                    model.MemberOperateLog.Memo = "修改会员卡信息";
                    action.Model.MemberCard = model.MemberCard;
                    action.Model.Customer = model.Customer;
                    action.UpdateMemberCard();
                    Response.Write("<script>window.returnValue='yes'</script>");
                    Response.Write("<script>window.close();</script>");
                    #endregion
                }
            }
		}
		catch(Exception ex)
		{
			LogHelper.WriteError(ex, Constants.LOGGER_NAME);
			throw ex;
		}
    }
    #endregion
}
