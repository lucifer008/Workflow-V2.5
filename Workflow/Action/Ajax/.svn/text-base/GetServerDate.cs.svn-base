using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Workflow.Util;
using Workflow.Support;
using Workflow.Service;
using Workflow.Da.Domain;
using Workflow.Support.Log;
using Workflow.Support.Ajax;

namespace Workflow.Action.Ajax
{
    /// <summary>
    ///  名    称：GetServerDate
    ///  功能概要：获取 服务器的当前时间与超时时间
    ///  作    者：
    ///  创建时间:
    ///  修正履历: 张晓林 
    ///            修正为获取 服务器的当前时间与超时时间
    ///  修正时间: 2009年12月4日10:57:09
    /// </summary>
    class GetServerDate : AjaxProcess
    {

        #region //ClassMember
        private IApplicationProperty applicationProperty;
        public IApplicationProperty ApplicationProperty
        {
            set { applicationProperty = value; }
        }
        #endregion
        #region AjaxProcess 成员

        public string DoProcess(System.Collections.Specialized.NameValueCollection parameters)
        {
            try
            {
                IDictionary<Type, string> jsonDic = new Dictionary<Type, string>();
                jsonDic.Add(typeof(Order), "InsertDateTimeString,Status");
                Order order = new Order();
                order.InsertDateTimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                order.Status = int.Parse(applicationProperty.GetOrderTimeOuntTime());
                return JSONUtils.ToJSONString(order, jsonDic);
                //return "1,'"+DateTime.Now.ToString()+"'";
            }
            catch(Exception ex)
            {
                LogHelper.WriteError(ex, Constants.LOGGER_NAME);
            }
            return Convert.ToString("0");
        }

        #endregion
    }
}
