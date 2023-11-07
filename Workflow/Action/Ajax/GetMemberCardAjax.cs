using System;
using System.Text;
using Workflow.Util;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Support.Ajax;
using Workflow.Support.Encrypt;
using Workflow.Service.MemberCardManager;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: Workflow.Support.Ajax.GetMemberCard
    /// 功能概要: 通过MemberCardNo和PassWord判断MemberCard是否存在
    /// 作    者: liuwei
    /// 创建时间: 2007-10-6
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class GetMemberCardAjax : AjaxProcess
    {
        #region 注入Service
        private IMemberCardService memberCardService;
        
        public IMemberCardService MemberCardService
        {
            get { return memberCardService; }
            set { memberCardService = value; }
        }

        private ISearchMemberCardService searchMemberCardService;
        public ISearchMemberCardService SearchMemberCardService 
        {
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
                System.Collections.Hashtable condition = new System.Collections.Hashtable();

                condition.Add("MemberCardNo", parameters["MemberCardNo"].Trim().ToLower());
                condition.Add("PassWord", EncryptUtils.HexMD5(parameters["password"].Trim()));
                condition.Add("CustomerId", parameters["CustomerId"].Trim().ToLower());
                string MemberCardNumber = Convert.ToString(searchMemberCardService.SearchMemberCardByMemberCardNo(condition));
                return MemberCardNumber;
            }
            catch (Exception ex) 
            {
                Workflow.Support.Log.LogHelper.WriteError(ex, Workflow.Support.Constants.LOGGER_NAME);
                throw ex;
            }
        }
    }
}
