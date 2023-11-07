<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdatePassword.aspx.cs" Inherits="UpdatePassword" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >

<head>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
        <script type="text/javascript" src="js/jquery.js"></script>
        <script type="text/javascript"  src="js/UpdatePassword.js"></script>
    <title>密码修改</title>

</head>
<body  style="background-color:#ffffff">
    <form id="form1" runat="server"  action="" method="post" onkeydown="">
    <div id="container" style="	position:relative;text-align:center;left:expression(document.body.clientWidth/2-this.offsetWidth/2);top:200px;font-size: 12px;">
        <table  border="1" cellpadding="3" cellspacing="1"  style=" border:solid 1px #000000; text-align:center; width: 466px;" >
            <tr style="height:35px;">
                <td nowrap="nowrap" style="text-align:center; font-size:larger;" class="item_caption" colspan="2">密码修改</td>
                </tr>
            <tr style="height:35px">
                <td nowrap="nowrap" class="item_caption" style="height: 24px">原始密码：</td>
               
                <td style=" text-align:left; height: 24px; width: 258px;"><input id="txtPassword" name="password" type="password" maxlength="30" runat="server" onblur="checkLogin();"  />&nbsp;
                <span id="txtLoginResult" style=" color:Red"></span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                        ErrorMessage="请输入原始密码" ValidationGroup="password"  >*</asp:RequiredFieldValidator></td>
                        
                         
            </tr>
            <tr style="height:35px">
            
                <td nowrap="nowrap" class="item_caption">新密码：</td>
                <td style=" text-align:left; width: 258px;">
                    <input id="Password1" name="password" type="password" maxlength="30" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password1"
                        ErrorMessage="请输入新密码" ValidationGroup="password">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr style="height: 35px">
                <td class="item_caption" nowrap="nowrap">确认新密码：
                </td>
                <td style="text-align: left; width: 258px;"><input id="Password2" name="password" type="password" maxlength="30" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Password2"
                        ErrorMessage="请输入确认密码" ValidationGroup="password">*</asp:RequiredFieldValidator>
                    &nbsp;
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password1"
                        ControlToValidate="Password2" ErrorMessage="两次密码不相等" ValidationGroup="password">*</asp:CompareValidator>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="password" />
                </td>
            </tr>
            <tr style="height:35px">
                <td colspan="2">
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click"    Text="确定修改"  ValidationGroup="password"  />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>


