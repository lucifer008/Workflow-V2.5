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
    /// 名    称: GetConcessionSum
    /// 功能概要: 根据方案Id获取方案详情
    /// 作    者: 
    /// 创建时间: 
    /// 修正履历: 张晓林
    /// 修正时间: 2009年3月19日10:04:38
    /// 修正描述：将返回的字符串改为:由一个单一的属性变成一个对象而返回
    /// </summary>
	/// <remarks>
	/// 修 正 人: 陈汝胤
	/// 修正时间: 2009.5.13
	/// 修正描述: 打折活动,送印章活动并用
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
