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
    /// ��    ��: GetMemberCardIdInOrdersAjax
    /// ���ܸ�Ҫ: �ж��û�Ա�Ƿ��Ѿ��ڹ����д���
    /// ��    ��: ������
    /// ����ʱ��: 2009��2��13��
    /// ��������: 
    /// ����ʱ��: 
    /// </summary>
    class GetMemberCardIdInOrdersAjax:AjaxProcess
    {
        #region //ע��Service
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
                //ɾ����Ա
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
