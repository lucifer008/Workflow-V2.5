<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogoutUser.aspx.cs" Inherits="LogoutUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <link href="css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="js/jquery.js"></script>
    <script type="text/javascript" src="js/logoutUser.js"></script>
    <title>注销用户</title>
</head>
<body  style="background-color:#ffffff">
    <form id="form1" runat="server"  action="" method="post" onkeydown="return login(event);">
    <div id="container" style="	position:relative;text-align:center;left:expression(document.body.clientWidth/2-this.offsetWidth/2);top:200px;font-size: 12px;">
        <table  border="1" cellpadding="3" cellspacing="1"  style=" border:solid 1px #000000; text-align:center;" width="350px" >
            <tr style="height:35px;">
                <td nowrap="nowrap" style="text-align:center; font-size:larger;" class="item_caption" colspan="2">注销用户</td>
                </tr>
            <tr style="height:35px">
                <td nowrap="nowrap" class="item_caption">用户名:</td>
                <td  style=" text-align:left;"><input id="txtUserName" name="userName" type="text" maxlength="50" onfocus="clearTip(this);" /></td>
            </tr>
            <tr style="height:35px">
                <td nowrap="nowrap" class="item_caption" style="height: 24px">密  码:</td>
                <td style=" text-align:left; height: 24px;"><input id="txtPassword" name="password" type="password" maxlength="30" onfocus="clearTip(this);" />
                <span id="txtLoginResult" style=" color:Red"></span></td>
            </tr>
            <tr style="height:35px">
                <td nowrap="nowrap" class="item_caption">分  店:</td>
                <td style=" text-align:left;">
                    <select id="sltBranchShop" runat="server">
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
