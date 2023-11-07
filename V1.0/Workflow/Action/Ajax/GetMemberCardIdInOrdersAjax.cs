using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using Workflow.Service;
using Workflow.Support.Ajax;
using Workflow.Support;
using Workflow.Support.Log;
using Workflow.Service.MemberCardManager;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: GetMemberCardIdInOrdersAjax
    /// 功能概要: 判定该会员是否已经在工单中存在
    /// 作    者: 张晓林
    /// 创建时间: 2009年2月13日
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    class GetMemberCardIdInOrdersAjax:AjaxProcess
    {
        #region //注入Service
        private ISearchMemberCardService searchMemberCardService;
        public ISearchMemberCardService SearchMemberCardService 
        {
            set { searchMemberCardService = value; }
        }

        private IMemberCardService memberCardService;
        public IMemberCardService MemberCardService 
        {
            set { memberCardService = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            try
            {
                if (null == parameters["membercardId"]) return null;
                string membercardId = parameters["membercardId"];
                long count = searchMemberCardService.SearchMemberCardIdInOrdersRowCount(membercardId);
                //删除会员
                if (count==0)
                {
                    memberCardService.DeleteMemberCardById(Convert.ToInt32(membercardId));
                }
                return Convert.ToString(count);
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
                throw ex;
            }
        }
    }
}
