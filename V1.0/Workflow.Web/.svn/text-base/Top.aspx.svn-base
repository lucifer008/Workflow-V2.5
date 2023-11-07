<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Top.aspx.cs" Inherits="Top" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title></title>
<link href="css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
var master=<%=Workflow.Support.Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
var pubAccunt=<%=Workflow.Support.Constants.POSITION_PUBLIC_ACCUNT_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;

function showMenu()
{
	/*top.topFrame.cols = (top.topFrame.cols == "0,*") ? "210,*" : "0,*";
	if (top.topFrame.cols == "0,*")	{
	document.all.image1.src="images/fore.gif";
	}
	else	{
	document.all.image1.src="images/back.gif";
	}*/
}
function showtop()
{
	/*top.leftFrame.rows = (top.leftFrame.rows == "30,*") ? "118,*" : "30,*";
	
	if (top.leftFrame.rows == "30,*")	{
	document.all.image2.src="images/in.gif";
	logo.style.display='none';
	}
	else	{
	document.all.image2.src="images/out.gif";
	logo.style.display='block';
	}*/
}
</script>
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
            <a href="#" style="color:white;text-decoration: none;" onclick="logoutUser();">注销用户</a>&nbsp;&nbsp;|&nbsp;&nbsp; 
            <a href="#" style="color:white;text-decoration: none;" onclick="changePassword();">修改密码</a> &nbsp;&nbsp;|&nbsp;&nbsp; 
            <a href="#" style="color:white;text-decoration: none;" onclick="exitCurrentUser();" >注销退出</a> &nbsp;&nbsp; 
        </font> 
    </td>
  </tr>
</table>
</form>
</body>
</html>
<script type="text/javascript">
    function exitCurrentUser()
    {
        //window.parent.navigate("LoginOut.aspx");//Firefox下不支持
        window.location.href="LoginOut.aspx";
        
    }
    function changePassword()
    {
        window.parent.frames["mainFrame"].navigate("UpdatePassword.aspx");
    }
    function logoutUser()
    {
        var returnVal='false';
        switch(position)
        {
            case master:
            case manager:
            case pubAccunt:
                returnVal='true';
                break;
            default:
                returnVal=accredit(6);
                break;
            
        } 
        if(returnVal=='true')
        {
            window.parent.frames["mainFrame"].navigate("LogoutUser.aspx");
        }
    }
    function accredit(t)
    {
	    return window.showModalDialog('finance/Accredit.aspx',t,'dialogHeigth:100px;dialogWidth:260px;status:no');
    }
</script>