using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Util;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
using Workflow.Da.Domain;
using Workflow.Action.Membercard;
using Workflow.Action.Model;
using Workflow.Service.MemberCardManager;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// ��    ��: GetMemberCardDetailByNoAjax
    /// ���ܸ�Ҫ: ���ݿ��Ż�ȡ��Ա����
    /// ��    ��: ������
    /// ����ʱ��: 2009��3��19��10:04:38
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    class GetMemberCardDetailByNoAjax : AjaxProcess
    {
        #region //ClassMember
        private SearchMemberCardAction searchMemberCardAction;
        public SearchMemberCardAction SearchMemberCardAction 
        {
            set { searchMemberCardAction = value; }
        }
        private ISearchMemberCardService searchMemberCardService;
        public ISearchMemberCardService SearchMemberCardService 
        {
            set { searchMemberCardService = value; }
            get { return searchMemberCardService; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters) 
        {
            try
            {
                if (null == parameters["MemberCardNo"])
                {
                    return null;
                }
                else
                {
                    string memberCardNo = parameters["MemberCardNo"];
                    searchMemberCardAction.Model.MemberCardNo = memberCardNo;
                    searchMemberCardAction.SearchMemberCardByCardNo();

                    IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                    jsonDic.Add(typeof(MemberCard), "Id,MemberCardNo,Name,CustomerName");
                    return JSONUtils.ToJSONString(searchMemberCardAction.Model.MemberCard, jsonDic);
                }
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }
    }
}
