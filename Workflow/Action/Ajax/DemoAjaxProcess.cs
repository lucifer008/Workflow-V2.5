using System;
using System.Collections.Generic;
using System.Text;
using Workflow.Util;
using System.Collections.Specialized;
using Workflow.Support.Ajax;

namespace Workflow.Action.Ajax
{
    /// <summary>
    /// 名    称: Workflow.Support.Ajax.DemoAjaxProcess
    /// 功能概要: 
    /// 作    者: 祝新宾
    /// 创建时间: 2007-9-13
    /// 修正履历: 
    /// 修正时间: 
    /// </summary>
    public class DemoAjaxProcess : AjaxProcess  
    {
        #region AjaxProcess 成员

        public string DoProcess(NameValueCollection parameters)
        {
            IDictionary<Type, String> jsonPairs = new Dictionary<Type, String>();
            jsonPairs.Add(typeof(People), "Name,Demo,Address");
            jsonPairs.Add(typeof(Address), "Address1,Address2");
            return JSONUtils.ToJSONString(new People(), jsonPairs);
        }

        #endregion
    }

    public class People
    {
        private string name = "祝新宾";

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string demo = "备注";

        public string Demo
        {
            get { return demo; }
            set { demo = value; }
        }

        private Address address;

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }
        public People()
        {
            address = new Address();
        }
    }

    public class Address
    {
        private string address1 = "xi'an china";

        public string Address1
        {
            get { return address1; }
            set { address1 = value; }
        }
        private string address2 = "高新区";

        public string Address2
        {
            get { return address2; }
            set { address2 = value; }
        }
    }
}
