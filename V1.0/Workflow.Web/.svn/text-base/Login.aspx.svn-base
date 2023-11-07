<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="WorkFlowLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/login.js"></script>
    <title>快易印</title>
    <script type="text/javascript">
        if(self.location!=top.location)
        {
            top.location.href='Login.aspx';
        }
    </script>
</head>
<body">
    <form id="form1" runat="server"  action="" method="post">
    <div id="container">
        <table  border="1" cellpadding="3" cellspacing="1">
            <tr style="height:35px;">
                <td nowrap="nowrap" style="text-align:center; font-size:larger;" class="item_caption" colspan="2">用户登陆</td>
                </tr>
            <tr style="height:35px">
                <td nowrap="nowrap" class="item_caption">用户名:</td>
                <td  style=" text-align:left;"><input id="txtUserName" name="userName" type="text" maxlength="30" onfocus="clearTip(this);" /></td>
            </tr>
            <tr style="height:35px">
                <td nowrap="nowrap" class="item_caption" style="height: 24px">密  码:</td>
                <td style=" text-align:left; height: 24px;"><input id="txtPassword" name="password" type="password" maxlength="30" onfocus="clearTip(this);" />
                <span id="txtLoginResult" style=" color:Red"></span></td>
            </tr>
            <tr style="height:35px">
                <td nowrap="nowrap" class="item_caption">分  店:</td>
                <td style=" text-align:left;">
                    <select id="sltBranchShop" runat="server" >
                    </select>
                </td>
            </tr>
            <tr style="height:35px">
                <td colspan="2">
                <input id="btnOk" class="buttons" type="button" value="确定" onclick="inputCheck();" />&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

