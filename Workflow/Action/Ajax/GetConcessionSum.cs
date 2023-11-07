using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Workflow.Util;
using Workflow.Action.Model;
using Workflow.Service;
using Workflow.Support;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Support.Ajax;
namespace Workflow.Action.Ajax
{
    /// <summary>
    /// ��    ��: GetConcessionSum
    /// ���ܸ�Ҫ: ���ݷ���Id��ȡ��������
    /// ��    ��: 
    /// ����ʱ��: 
    /// ��������: ������
    /// ����ʱ��: 2009��3��19��10:04:38
    /// ���������������ص��ַ�����Ϊ:��һ����һ�����Ա��һ�����������
    /// </summary>
	/// <remarks>
	/// �� �� ��: ����ط
	/// ����ʱ��: 2009.5.13
	/// ��������: ���ۻ,��ӡ�»����
	/// </remarks>
    public  class GetConcessionSum : AjaxProcess
    {
        #region ClassMember

		private ConcessionModel model;

        private ConcessionAction action;
        public ConcessionAction ConcessionAction
        {
            get { return action; }
            set { action = value; }
        }
        #endregion

        public string DoProcess(NameValueCollection parameters)
        {
            try
            {
				string campaignId=parameters["id"];

				if (!string.IsNullOrEmpty(campaignId))
				{
					model = action.Model;
					model.CampaignId = long.Parse(campaignId);
					action.SearchConcession();
					
					IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
					jsonDic.Add(typeof(ConcessionModel), "DiscountConcessionList,ConcessionList");
					jsonDic.Add(typeof(DiscountConcession), "Id,CampaignId,Name,ChargeAmount");
					jsonDic.Add(typeof(Concession), "Id,CampaignId,Name,ChargeAmount,PaperCount,ActivityPrice");
					return JSONUtils.ToJSONString(action.Model, jsonDic);
				}
				return "";
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Workflow.Support.Constants.LOGGER_NAME);
                throw ex;
            }
        }
    }
}
