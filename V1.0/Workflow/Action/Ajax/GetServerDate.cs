using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Support.Ajax;
using Workflow.Util;

namespace Workflow.Action.Ajax
{
    class GetServerDate : AjaxProcess
    {
        #region AjaxProcess ��Ա

        public string DoProcess(System.Collections.Specialized.NameValueCollection parameters)
        {
            return "1,'"+DateTime.Now.ToString()+"'";
        }

        #endregion
    }
}
