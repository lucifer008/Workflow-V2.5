using System;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: AddConcession
/// 功能概要: 优惠方案添加
/// 作    者: liuwei
/// 创建时间: 2007-10-17
/// 修 正 人: 张晓林
/// 修正时间: 2009年3月16日17:51:20
/// 描    述: 完成添加，编辑，异常处理；
/// </summary>
public partial class activities_AddConcession : System.Web.UI.Page
{
    #region //成员变量
    protected bool BusinessTypePrice = false;
    protected string Title = "添加";
    private ConcessionAction concessionAction;
    protected ConcessionModel concessionModel;
    public ConcessionAction ConcessionAction
    {
        set { concessionAction = value; }
    }

    #endregion

    #region //页面属性加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            concessionModel = concessionAction.Model;
            if (!IsPostBack)
            {
                InitData();
            }

            if (null!=Request.QueryString["ConcessionId"] && "" != Request.QueryString["ConcessionId"])
            {
                Response.Expires = -1;
                hiddbaseBusinessTypePriceId.Value = Request.QueryString["BaseBusinessTypeId"];
                hiddConcessionId.Value = Request.QueryString["ConcessionId"];
                Title = "编辑";
            }

            //标志已经选择了价格
            if (!StringUtils.IsEmpty(hiddbaseBusinessTypePriceId.Value))
            {
                BusinessTypePrice = true;
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
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
    /// 作    者: liuwei
    /// 创建时间: 2007-10-17
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    public void InitData()
    {
        concessionAction.SearchMemberCardLevel();
        concessionAction.GetAllCampaignList();
        ddlCampaign.DataSource =concessionModel.CampaignList;//所属营销活动
        ddlCampaign.DataTextField = "Name";
        ddlCampaign.DataValueField = "Id";
        ddlCampaign.DataBind();
    }
    #endregion

    #region //插入优惠活动
    /// <summary>
    /// 插入优惠活动
    /// </summary>
    /// <param></param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-17
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void InsertConcessionInfo(object sender, EventArgs e)
    {
        try
        {
            Concession concession = new Concession();
            concession.CampaignId = NumericUtils.ToLong(ddlCampaign.SelectedValue);

            concession.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            concession.BaseBusinessTypePriceSet.Id = NumericUtils.ToLong(hiddbaseBusinessTypePriceId.Value);

            concession.ChargeAmount = Convert.ToDecimal(Request.Form.Get("txtChargeAmount"));
            concession.PaperCount = Convert.ToDecimal(Request.Form.Get("txtPaperCount"));//赠送印章数Convert.ToDecimal(hiddCount.Value) + Convert.ToDecimal(Request.Form.Get("txtPaperCount"));//实际印章数
            concession.UnitPrice = Convert.ToDecimal(hiddUnitPrice.Value);//优惠价格
            concession.Name = txtName.Text;
            concession.Description = txtDescription.Text;
            concession.Memo = "";
            concession.ConcessionMemberCardLevelId =Request.Form["cbMemberLevel"].Split(',');//卡级别
            concession.RoomPrice = Convert.ToDecimal(hiddRoomPrice.Value);//门市价格
            concessionModel.Concession =concession;

            //更新
            if (null != Request.QueryString["ConcessionId"] && "0"!=Request.QueryString["ConcessionId"]) 
            {
                concession.Id = Convert.ToInt32(Request.QueryString["ConcessionId"]);
                concessionAction.UpdateConcession();
                Response.Write("<script>window.returnValue=true;</script>");
                Response.Write("<script>window.close();</script>");
            }
            else //插入
            {
                concessionAction.InsertConcession();
                Response.Redirect("AddConcession.aspx");
            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            //throw ex;
        }
    }
    #endregion
}
