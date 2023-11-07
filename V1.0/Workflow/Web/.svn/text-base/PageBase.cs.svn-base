using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Workflow.Support;

namespace Workflow.Web
{
    public class PageBase : Spring.Web.UI.Page
    {
        protected void MakeSelectDefaultItem(DropDownList select)
        {
            select.Items.Insert(0, new ListItem(Constants.SELECT_VALUE_NOT_SELECTED_TEXT, Constants.SELECT_VALUE_NOT_SELECTED_KEY));
            this.Form.Attributes.Add("action", Request.Path);
        }
    }
}
