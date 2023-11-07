using System;
using System.Collections.Generic;
using System.Text;

using Workflow.Service.SystemMaintenance.System;
using Workflow.Support.Ajax;
using Workflow.Da.Domain;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// ��    ��: 
    /// ���ܸ�Ҫ: ��ȡ����Ĭ��ֵ
    /// ��    ��: ������
    /// ����ʱ��: 2010��7��3��14:35:44
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



        #region AjaxProcess ��Ա

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
