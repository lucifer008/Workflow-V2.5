<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Accredit.aspx.cs" Inherits="finance_Accredit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>��Ȩ</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/accredit.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
    <script type="text/jscript" language="javascript">
    var permissionGroupOpterateId=<%=permissionGroupOpterateId%>;//��ȡ����Ȩ��Id
    </script>
<% if (closeFlag)
   {%>
    <script type="text/javascript">
        window.returnValue='<%=closeFlag%>'.toLowerCase();
        close();
    </script>
    <%}
   else{ %>    
    <script type="text/javascript">
        if(window.opener!=null)
        {
            window.returnValue='false'.toLowerCase();
            close();
        }
    </script>
   <%} %>
   <base target="_self"/>
</head>
<body>
<form id="form1" runat="server" method="post" action="Accredit.aspx">
        <div align="left" style="width: 100%" bgcolor="#ffffff" id="container">
            <table width="200" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12">
                        <img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF">
                        <img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12">
                        <img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    ��Ȩ</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table border="1" cellpadding="1" cellspacing="0">
                                        <tr>
                                            <td nowrap class="item_caption">
                                                �û���:</td>
                                            <td class="item_content">
                                                <input type="text" maxlength="10" name="userName" onkeydown="return inputCheck(event);" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                ����:</td>
                                            <td class="item_content">
                                                <input type="password" maxlength="30" name="password" onkeydown="return inputCheck(event);" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
<%--                                                <asp:Button ID="btnOK" runat="server" CssClass="buttons" OnClick="Save" OnClientClick="return dataCheck();"
                                                    Text="ȷ��" />  
--%>                            			        <input id="Button1"  type="button" class="buttons" value="ȷ��"  onclick="dataCheck();"  />&nbsp;&nbsp;&nbsp;
                                                
                                                <input type="button" onclick="window.close();" value="�ر�" />
                                                <input type="hidden" name="accreditType" value="0" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr height="5">
                                <td>
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">
                                    &nbsp;</td>
                                <td>
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12">
                        <img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF">
                        <img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12">
                        <img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
