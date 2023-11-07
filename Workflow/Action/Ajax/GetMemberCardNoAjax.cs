using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Util;
using System.Collections.Specialized;
using Workflow.Service;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Ajax;
using Workflow.Service.MemberCardManager;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: Workflow.Support.Ajax.GetMemberCardNo
    /// 功能概要: 判定该卡号是否已经存在
    /// 作    者: liuwei
    /// 创建时间: 2007-10-10
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class GetMemberCardNoAjax:AjaxProcess
    {
        #region 注入Service
        private ISearchMemberCardService searchMemberCardService;
        public ISearchMemberCardService SearchMemberCardService
        {
            get { return searchMemberCardService; }
            set { searchMemberCardService = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            try
            {
                if (parameters["MemberCardNo"] == null)
                {
                    return null;
                }
                string memberCardNo = parameters["MemberCardNo"].Trim().ToLower();
                string tagMemberCard = searchMemberCardService.SearchWhetherMemberCardNo(memberCardNo).ToString();
                if (tagMemberCard == "0")//改卡号不存在
                {
                    return tagMemberCard;
                }
                else
                {
                    string customerId = parameters["CustomerId"].Trim().ToLower();
                    System.Collections.Hashtable hashCondition = new System.Collections.Hashtable();
                    //hashCondition.Add("CustomerId", customerId);
                    hashCondition.Add("MemberCardNo", memberCardNo);
                    //检验卡号和顾客Id是不是唯一
                    IList<MemberCard> memberCardList = searchMemberCardService.CheckMemberCardNo(hashCondition);
                    
                    //判断该卡的状态
                    if (memberCardList != null)
                    {
                        bool Tag = false;
                        foreach (MemberCard memberCard in memberCardList)
                        {
                            if (memberCard.MemberState != Constants.MEMBER_CARD_OPERATE_LOGOUT_KEY)
                            {
                                Tag = false;
                            }
                            else 
                            {
                                Tag = true;
                            }
                        }
                        if (Tag)
                        {
                            return "0";
                        }
                        else 
                        {
                            return "1";
                        }
                    }
                    else
                    {
                        return "0";//可以使用该卡
                    }
                }
            }
            catch(Exception ex)
            {
                Workflow.Support.Log.LogHelper.WriteError(ex,Workflow.Support.Constants.LOGGER_NAME);
                //throw ex;
                return null;
            }
        }
    }
}
