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
    ///  ��    �ƣ�GetServerDate
    ///  ���ܸ�Ҫ����ȡ �������ĵ�ǰʱ���볬ʱʱ��
    ///  ��    �ߣ�
    ///  ����ʱ��:
    ///  ��������: ������ 
    ///            ����Ϊ��ȡ �������ĵ�ǰʱ���볬ʱʱ��
    ///  ����ʱ��: 2009��12��4��10:57:09
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
        #region AjaxProcess ��Ա

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
