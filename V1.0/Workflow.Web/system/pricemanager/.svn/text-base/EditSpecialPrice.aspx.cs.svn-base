using System;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Collections;
using System.Web.Security;
using System.Configuration;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using Workflow.Action;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Action.Model;

/// <summary>
/// 名    称: EditSpecialPrice
/// 功能概要: 价格的编辑
/// 作    者: 麻少华
/// 创建时间: 2007-9-18
/// 修正履历: 付强
/// 修正时间: 2009-1-17
///           代码整理
/// </summary>
public partial class system_pricemanager_EditSpecialPrice : Workflow.Web.PageBase
{
    #region 类成员
    protected long lngBusinessTypeId = -1;
    protected long lngMemberCardLevel = -1;
    protected int intAction = Constants.ACTION_INIT;
    protected BusinessTypePriceSetModel model;
    private string PhookPager_CurrentPageKey = "pageid";
    protected long pageID = 1;
    protected BusinessTypePriceSetAction businessTypePriceSetAction;
    public BusinessTypePriceSetAction BusinessTypePriceSetAction
    {
        set { businessTypePriceSetAction = value; }
    }
    #endregion

    #region 页面加载
    protected void Page_Load(object sender, EventArgs e)
    {
        model = businessTypePriceSetAction.Model;

        if (this.IsPostBack)
        {
            if (Request.QueryString[PhookPager_CurrentPageKey] != null)
            {
                pageID = long.Parse(Request.QueryString[PhookPager_CurrentPageKey]);
            }

            if (Request.Form["sltBusinessType"] != null)
            {
                lngBusinessTypeId = long.Parse(Request.Form["sltBusinessType"]);
            }
            if (Request.Form["sltMemberCardLevel"] != null)
            {
                lngMemberCardLevel = long.Parse(Request.Form["sltMemberCardLevel"]);
            }

            if (pageID != 1)        //虽然指定的页数不是1,但是很可能要查询的内容已经变了
            {
                if (Request.QueryString["lastBusinessTypeId"] != null)
                {
                    long tmplngBusinessTypeId = long.Parse(Request.QueryString["lastBusinessTypeId"]);
                    if (tmplngBusinessTypeId != lngBusinessTypeId)
                    {
                        this.PhookPager1.RecoveryPageIndex = true;
                        pageID = 1;
                    }

                }
            }

            if (pageID != 1)
            {
                if (Request.QueryString["lastMemberCardLevel"] != null)
                {
                    long tmplngMemberCardLevel = long.Parse(Request.QueryString["lastMemberCardLevel"]);
                    if (tmplngMemberCardLevel!=lngMemberCardLevel )
                    {
                        this.PhookPager1.RecoveryPageIndex = true;
                        pageID = 1;
                    }

                }
            }

        }
        else
        {
            //如果是翻页后的新一页
            if (Request.QueryString[PhookPager_CurrentPageKey] != null)
            {
                pageID = long.Parse(Request.QueryString[PhookPager_CurrentPageKey]);
            }

            if (Request.QueryString["lastBusinessTypeId"] != null)
            {
                lngBusinessTypeId = long.Parse(Request.QueryString["lastBusinessTypeId"]);
            }

            if (Request.QueryString["lastMemberCardLevel"] != null)
            {
                lngMemberCardLevel = long.Parse(Request.QueryString["lastMemberCardLevel"]);
            }
            
        }

        //获得页面动作
        if (Request.Form["txtAction"] != null)
        {
            intAction = int.Parse(Request.Form["txtAction"]);
        }
        //判断页面动作执行不同的处理
        if (intAction == Constants.ACTION_INIT)
        {
            QueryProcess();
            //初始化显示
            businessTypePriceSetAction.InitDataPriceTypeMember(intAction);
        }
        else if (intAction == Constants.ACTION_SEARCH)
        {
            //查询
            QueryProcess();
            businessTypePriceSetAction.InitDataPriceTypeMember(intAction);
        }
        else if (intAction == Constants.ACTION_UPDATE )
        {
            Update();
            QueryProcess();
            businessTypePriceSetAction.InitDataPriceTypeMember(intAction);
        }
        else if (intAction == Constants.ACTION_DELETE)
        {
            //删除
            DeleteProcess();
            businessTypePriceSetAction.InitDataPriceTypeMember(intAction);
            //再检索一遍
            QueryProcess();
        }


        this.PhookPager1.ShowRecordCount = Constants.ROW_COUNT_FOR_PAGER;
        this.PhookPager1.ShowPageNumberCount = Constants.SHOW_PAGE_COUNT;
        this.PhookPager1.TotalRecordCount = Convert.ToInt32(businessTypePriceSetAction.GetAllBusinessTypePriceSetListCount(businessTypePriceSetAction.Model));
        this.PhookPager1.QueryStringKeyWord = PhookPager_CurrentPageKey;// "pageid";        
        this.PhookPager1.QueryString = "lastBusinessTypeId=" + lngBusinessTypeId.ToString() + "&lastMemberCardLevel=" + lngMemberCardLevel.ToString() + "&" + PhookPager_CurrentPageKey;
    }
    #endregion

    #region 操作保存
    private void QueryProcess()
    {
        
        //设定查询条件
        model.BusinessTypePriceSet = new BusinessTypePriceSet();
        model.BusinessTypePriceSet.BusinessType = new Workflow.Da.Domain.BusinessType();
        //取得业务类型ID
        model.BusinessTypePriceSet.BusinessType.Id = lngBusinessTypeId;
        //取得卡级别类型ID
        model.BusinessTypePriceSet.TargetId = lngMemberCardLevel;
        //设定价格类型
        model.BusinessTypePriceSet.PriceType = Constants.PRICE_TYPE_MEMBER;
        
        //页数和每页行数
        model.BusinessTypePriceSet.CurrentPageID = pageID;
        model.BusinessTypePriceSet.EveryPageRows = Constants.ROW_COUNT_FOR_PAGER;


        //查询
        businessTypePriceSetAction.GetAllBusinessTypePriceSetList(businessTypePriceSetAction.Model);

        List<Workflow.Support.ClientShowData> showdatas = new List<ClientShowData>();
        for (int i = 0; i < model.BusinessTypePriceSetList.Count; i++)
        {
            ClientShowData sd = new ClientShowData(model.BusinessTypePriceSetList[i]);
            showdatas.Add(sd);
        }

        Session["EditSpecialPrice_aspx_showdatas"] = showdatas;


    }
    
    private void DeleteProcess()
    {
        model.BusinessTypePriceSet = new BusinessTypePriceSet();
        //获取当前需要处理的ID
        if (Request.Form["txtId"] != null)
        {
            model.BusinessTypePriceSet.Id = long.Parse(Request.Form["txtId"]);
        }
        //删除
        businessTypePriceSetAction.Delete(model);
    }

    private void Update()
    {

        //如果找不到了,重新加载.
        if (Session["EditSpecialPrice_aspx_showdatas"] == null)
        {
            Response.Write("<script>alert('在指定时间内没有操作,需重新加载数据.请重新操作!')</script>");
            QueryProcess();
            return;
        }


        try
        {
            List<Workflow.Support.ClientShowData> showdatas = new List<ClientShowData>();
            showdatas = (List<Workflow.Support.ClientShowData>)Session["EditSpecialPrice_aspx_showdatas"];


            foreach (ClientShowData sd in showdatas)
            {
                decimal tmpd, d1 = 0, d2 = 0;
                tmpd = 0;
                decimal.TryParse(Request.Form["input1" + sd.BaseBusinessTypePriceSetId], out tmpd);
                if (tmpd <= 0)
                {
                    string err = "<script> alert('卡级别价输入错误')</script>";
                    Response.Write(err);
                    return;
                }
                else
                {
                    d1 = tmpd;
                }


                tmpd = 0;
                decimal.TryParse(Request.Form["input2" + sd.BaseBusinessTypePriceSetId], out tmpd);
                if (tmpd <= 0 || tmpd > 100)
                {
                    string err = "<script> alert('卡级别折扣输入错误')</script>";
                    Response.Write(err);
                    return;
                }
                else
                {
                    d2 = tmpd;
                }

                //decimal d1 = decimal.Parse(Request.Form["input1" + sd.BaseBusinessTypePriceSetId]);
                //decimal d2 = decimal.Parse(Request.Form["input2" + sd.BaseBusinessTypePriceSetId]);

                if (Request.Form[sd.ChkName] != null)        //如果存在这个控件的值
                {
                    if (sd.IsCheck == false)                 //如果原来没有,而现在有了,增加
                    {
                        //增加处理
                        savePriceSet(sd.BusinessTypePriceSet, sd.BaseBusinessTypePriceSetId, d1, d2);
                    }
                    else
                    {
                        //原来也有,现在也有,看看值是否改变
                        if (!(d1.Equals(sd.NewPrice) && d2.Equals(sd.PriceConcession)))
                        {
                            //先删除
                            deleteByID(sd.BusinessTypePriceSetListId);
                            //后增加.
                            savePriceSet(sd.BusinessTypePriceSet, sd.BaseBusinessTypePriceSetId, d1, d2);

                        }

                    }
                }
                else                                         //如果指定的控件的值不存在, 
                {
                    if (sd.IsCheck == true)                  //而且原来的值选定,需要删除
                    {
                        //删除
                        deleteByID(sd.BusinessTypePriceSetListId);
                    }
                }

            }
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }

    }

    private void deleteByID(long BaseBusinessTypePriceSetId)
    {
        try
        {
            model.BusinessTypePriceSet = new BusinessTypePriceSet();
            model.BusinessTypePriceSet.Id = BaseBusinessTypePriceSetId;
            //删除
            businessTypePriceSetAction.Delete(model);
        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);   
            throw ex;
        }
    }

    private void savePriceSet(BusinessTypePriceSet bizTypePriceSet,string baseBizTypePriceSetId,decimal newPrice,decimal priceConcession)
    {
        try
        {
            BusinessTypePriceSetModel saveModel = new BusinessTypePriceSetModel();
            saveModel.BusinessTypePriceSetList = new List<BusinessTypePriceSet>();

            bizTypePriceSet.BaseBusinessTypePriceSetId = long.Parse(baseBizTypePriceSetId);
            bizTypePriceSet.NewPrice = newPrice;
            bizTypePriceSet.PriceConcession = priceConcession;

            saveModel.BusinessTypePriceSetList.Add(bizTypePriceSet);

            businessTypePriceSetAction.Add(saveModel);

        }
        catch (Exception ex)
        {
            LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            throw ex;
        }
    }

    #endregion
}

