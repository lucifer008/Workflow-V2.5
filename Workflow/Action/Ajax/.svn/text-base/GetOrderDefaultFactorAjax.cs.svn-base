using System;
using System.Collections.Generic;
using System.Text;

using Workflow.Service.SystemMaintenance.System;
using Workflow.Support.Ajax;
using Workflow.Da.Domain;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: 
    /// 功能概要: 获取开单默认值
    /// 作    者: 白晓宇
    /// 创建时间: 2010年7月3日14:35:44
    /// </summary>
    public class GetOrderDefaultFactorAjax: AjaxProcess
    {
        #region service
        private ISystemService systemService;
        public ISystemService SystemService
        {
            set { systemService = value; }
        }
        #endregion



        #region AjaxProcess 成员

        public string DoProcess(System.Collections.Specialized.NameValueCollection parameters)
        {
            string json = String.Empty;
            ApplicationProperty applicationProperty = systemService.GetDefaultPriceFactor();
            if (applicationProperty != null)
            {
                json = applicationProperty.Memo;
            }
            return json;
        }

        #endregion
    }
}
