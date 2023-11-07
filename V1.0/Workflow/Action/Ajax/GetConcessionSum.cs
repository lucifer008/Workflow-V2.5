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
    public  class GetConcessionSum : AjaxProcess
    {
        #region //ClassMember
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
               
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                Concession concession = new Concession();
                if (null!=parameters["ConcessionId"] && "undefined" != parameters["ConcessionId"])
                {
                    concession.Name = parameters["ConcessionId"];
                    action.Model.Concession = concession;
                    action.SearchConcession();
                    if (1 == action.Model.ConcessionList.Count) 
                    {
                        action.Model.Concession = action.Model.ConcessionList[0];
                    }
                }
                if (null != parameters["CampaignId"] && "undefined" != parameters["CampaignId"])
                {
                    concession.Memo = parameters["CampaignId"];
                    action.Model.Concession = concession;
                    action.SearchConcession();
                }
                jsonDic.Add(typeof(ConcessionModel), "ConcessionList,Concession");
                jsonDic.Add(typeof(Concession), "Id,CampaignId,Name,ChargeAmount,PaperCount,UnitPrice");
                return JSONUtils.ToJSONString(action.Model, jsonDic);
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Workflow.Support.Constants.LOGGER_NAME);
                throw ex;
            }
        }
    }
}
