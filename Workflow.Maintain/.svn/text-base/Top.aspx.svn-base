<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
<link href="css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="js/Top.js"></script>
</head>
<body bgcolor="#6C7A83" >
<form id="form1" action="" method="post" runat="server">
<table width="100%" border="0" cellpadding="0" cellspacing="0">
  <tr id="logo" >
    <td width="152"><a href="index.html" target="_top"><img alt="" src="images/logo2.gif" border="0"/></a></td>
    <td background="images/a01_03_1.gif" >&nbsp;</td>
    <td background="images/a01_03_1.gif" align="right"><img alt="" src="images/a01_03.gif"/><img alt="" src="images/a01_04.gif"/></td>
  </tr>
  <tr>
    <td background="images/img03.gif" alt="03.gif" height="25" ></td>
    
    <td background="images/img03.gif" alt="03.gif">
        <font color="white">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <a class="fontcolor" href="index.html" target="_top"  style="color:white;text-decoration: none;" >
                <img alt="" src="images/home.gif" width="16"  align="absmiddle" border="0" />首页 </a> 
            &nbsp;&nbsp;|&nbsp;&nbsp;当前用户：<span id="strUser"><%=loginAction.LoginModel.LoginUser.EmployeeName%></span>
            &nbsp;&nbsp;|&nbsp;&nbsp;来自：<span id="strHost"><%=Request.UserHostName %></span> 
        </font>
    </td>
    <td  background="images/img03.gif" alt="03.gif" align="right">
        <font color="white"> &nbsp;&nbsp;|&nbsp;&nbsp; 
            <a href="#" style="color:white;text-decoration: none;" onclick="changePassword();">修改密码</a> &nbsp;&nbsp;|&nbsp;&nbsp; 
            <a href="#" style="color:white;text-decoration: none;" onclick="exitCurrentUser();" >注销退出</a> &nbsp;&nbsp; 
        </font> 
    </td>
  </tr>
</table>
</form>
</body>
</html>
