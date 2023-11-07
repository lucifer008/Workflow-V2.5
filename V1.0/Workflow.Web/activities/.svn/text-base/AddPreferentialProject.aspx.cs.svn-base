 using System;
using System.Web.UI.WebControls;
using Workflow.Util;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;
/// <summary>
/// 名    称: AddPreferentialProject
/// 功能概要: 优惠方案添加
/// 作    者: liuwei
/// 创建时间: 2007-10-17
/// 修 正 人: 张晓林
/// 修正时间: 2009年2月16日9:16:59
/// 描    述: 完成分页；新增；编辑；删除功能；添加异常处理；
/// </summary>
public partial class AddPreferentialProject : Workflow.Web.PageBase
{
    #region //成员变量
    protected bool BusinessTypePrice = false;
    protected bool ReturnParent = false;

    private ConcessionAction concessionAction;
    protected ConcessionModel concessionModel;
    public ConcessionAction ConcessionAction
    {
        set { concessionAction = value; }
    }

    private BaseBusinessTypePriceSetAction action;
    protected BaseBusinessTypePriceSetModel model;
    public BaseBusinessTypePriceSetAction BaseBusinessTypePriceSetAction
    {
        set { action = value; }
    }
    #endregion

    #region //页面属性加载
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            concessionModel = concessionAction.Model;
            model = action.Model;

            if (!IsPostBack)
            {
                InitData();
            }

            //获取选择业务类型的基本信息
            if (!StringUtils.IsEmpty(hiddbaseBusinessTypePriceId.Value))
            {
                BusinessTypePrice = true;
                long Id = NumericUtils.ToLong(hiddbaseBusinessTypePriceId.Value);

                GetBusinessTypePrice(Id);
            }
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
    /// 作    者: liuwei
    /// 创建时间: 2007-10-17
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    public void InitData()
    {
        
        hiddCampaign.Value = Request.QueryString["Id"];
        hiddTag.Value = Request.QueryString["Tag"];

        concessionAction.SearchMemberCardLevel();

        foreach (Workflow.Da.Domain.MemberCardLevel mc in concessionModel.MemberCardLevelList)
        {
            MemberCardLevel.Items.Add(new ListItem(mc.Name, mc.Id.ToString()));
        }
    }
    #endregion

    #region //获取选种的价格因素
    /// <summary>
    /// 获取选种的价格因素
    /// </summary>
    /// <param name="Id">BaseBusinessTypePriceSetId</param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-17
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    private void GetBusinessTypePrice(long Id)
    {
        model.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
        model.BaseBusinessTypePriceSet.Id = Id;

        action.GetBaseBusinessTypePriceSetById(model.BaseBusinessTypePriceSet);
    }
    #endregion

    #region //获取业务类型的其他因素
    /// <summary>
    /// 获取业务类型的其他因素
    /// </summary>
    /// <param name="Id">BusinessTypeId</param>
    /// <returns></returns>
    /// <remarks>
    /// 作    者: liuwei
    /// 创建时间: 2007-10-17
    /// 修正履历:
    /// 修正时间:
    /// </remarks>
    protected void GetBaseBusinessTypePrice(long Id)
    {
        model.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
        model.BaseBusinessTypePriceSet.BusinessType = new BusinessType();
        model.BaseBusinessTypePriceSet.BusinessType.Id = Id;
        action.InitCustomQuery(model);
    }
    #endregion

    #region //插入优惠活动(事件)
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
            //插入优惠活动
            concessionModel.Concession = new Concession();

            concessionModel.Concession.CampaignId = NumericUtils.ToLong(hiddCampaign.Value);

            concessionModel.Concession.BaseBusinessTypePriceSet = new BaseBusinessTypePriceSet();
            concessionModel.Concession.BaseBusinessTypePriceSet.Id = NumericUtils.ToLong(hiddbaseBusinessTypePriceId.Value);

            concessionModel.Concession.ChargeAmount = Convert.ToDecimal(Request.Form.Get("txtChargeAmount"));
            concessionModel.Concession.PaperCount = Convert.ToDecimal(Request.Form.Get("hiddCount")) + Convert.ToDecimal(Request.Form.Get("txtPaperCount"));
            concessionModel.Concession.UnitPrice = Convert.ToDecimal(Request.Form.Get("hiddUnitPrice"));
            concessionModel.Concession.Name = txtName.Text;
            concessionModel.Concession.Description = txtDescription.Text;
            concessionModel.Concession.Memo = "";

            //插入优惠活动适应的卡级别
            concessionModel.ConcessionMemberCardLevelIds = "";
            foreach (ListItem lt in MemberCardLevel.Items)
            {
                if (lt.Selected == true)
                {
                    concessionModel.ConcessionMemberCardLevelIds = concessionModel.ConcessionMemberCardLevelIds + lt.Value;

                    concessionModel.ConcessionMemberCardLevelIds += ",";
                }
            }
            //插入差价
            string[] Ids = Request.Form.Get("hiddBaseBusinessTypePriceSerIds").Split(new char[] { ',' });

            concessionModel.ConcessionDifferencePricesIds = Request.Form.Get("hiddBaseBusinessTypePriceSerIds");
            concessionModel.ConcessionDifferencePriceValues = "";

            for (int i = 1; i < Ids.Length; i++)
            {
                if (StringUtils.IsEmpty(Request.Form.Get(Ids[i])))
                {
                    concessionModel.ConcessionDifferencePriceValues += "0";
                }
                else
                {
                    concessionModel.ConcessionDifferencePriceValues = concessionModel.ConcessionDifferencePriceValues + Request.Form.Get(Ids[i]);
                }

                concessionModel.ConcessionDifferencePriceValues += ",";

            }

            concessionAction.InsertConcession();

            ReturnParent = true;
        }
        catch(Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }
    #endregion
}
