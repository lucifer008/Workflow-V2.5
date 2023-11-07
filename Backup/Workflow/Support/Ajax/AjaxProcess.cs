using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;

namespace Workflow.Support.Ajax
{

    /// <summary>
    /// 名    称: Workflow.Support.Ajax.AjaxProcessBase
    /// 功能概要:
    /// 作    者: 祝新宾
    /// 创建时间: 2007-9-13
    /// 修正履历:
    /// 修正时间:
    /// </summary>
    public interface AjaxProcess
    {
        string DoProcess(NameValueCollection parameters);
    }
}
