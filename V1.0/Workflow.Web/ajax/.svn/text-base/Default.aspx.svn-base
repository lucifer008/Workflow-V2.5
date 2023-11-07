<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="ajax_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
    <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="../js/default.js" charset="gb2312"></script>
    <script type="text/javascript" language="javascript">
        var flag = "<%= Workflow.Support.Constants.AJAX_PROCESS_DEMO %>";
        var test = getJSON("{a : '1', name:'zxb'}");
        
        alert(test.a);
        
        function doProcess()
        {
            $.getJSON("AjaxEngine.aspx", getJSON("{a : '1', name:'zxb'}"), processJson);
        }
        function processJson(json){
            if (json.success == null || json.success) {
                var message = "name : " + json.Name +"\n"
                    + "Demo : " + json.Demo + "\n"
                    + "Address : " + json.Address.Address1 + "," + json.Address.Address2;
                alert(message);
            } else {
                alert("failed");
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <input id="Button1" type="button" value="button" onclick="doProcess();"/>
    </div>
    </form>
</body>
</html>
