<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyUsers.aspx.cs" Inherits="popedomManagement_ModifyUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>修改用户</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script language="javascript" src="../js/jquery.js"></script>
    <script language="javascript" src="../js/default.js"></script>
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11">
                        <img alt="" src="../images/white_main_top_left.gif"></td>
                    <td width="99%">
                        <img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10">
                        <img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页&nbsp;-&gt;&nbsp;人员管理&nbsp;-&gt;&nbsp;用户修改</td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    用户修改</td>
                            </tr>
                            <tr height="5">
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee" style="height: 5px">
                                    &nbsp;</td>
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="center">                                   
                                    <table border="1" cellpadding="3" cellspacing="1" style="width: 100%" align="left">
                                        <tr>
                                            <td width="1%" nowrap align="right">雇员：
                                            </td>
                                            <td align="left">
                                                <asp:DropDownList ID="DropDownList1" runat="server">
                                                    <asp:ListItem Value="1">娃哈哈</asp:ListItem>
                                                    <asp:ListItem Value="2" Selected="True">杀破</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td width="1%" nowrap align="right">用户登陆名：
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TextBox1" runat="server">用户名称一号</asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td width="1%" nowrap align="right">登陆密码：
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td width="1%" nowrap align="right">角色：
                                            </td>
                                            <td align="left">
                                                <table border="1" style="width: 50%" align="left">
                                                    <tr>
                                                        <td width="1%" nowrap><input type="checkbox" checked="checked" />
                                                        </td>
                                                        <td nowrap>总经理
                                                        </td>
                                                        <td width="1%" nowrap><input type="checkbox" />
                                                        </td>
                                                        <td nowrap>经理
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="1%" nowrap><input type="checkbox" />
                                                        </td>
                                                        <td nowrap>店长
                                                        </td>
                                                        <td width="1%" nowrap><input type="checkbox" />
                                                        </td>
                                                        <td nowrap>副店长
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td width="1%" nowrap><input type="checkbox" checked="checked" />
                                                        </td>
                                                        <td nowrap>收银
                                                        </td>
                                                        <td width="1%" nowrap>
                                                        </td>
                                                        <td nowrap>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td width="3%" style="height: 24px">
                                </td>
                                <td align="left" style="height: 24px">
                                    <input type="button" value="修改" onclick="location.href='/popedomManagement/UsersList.aspx'" />
                                    <input type="button" value="返回" onclick="location.href='/popedomManagement/UsersList.aspx'" />
                                <td width="3%" style="height: 24px">
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3" style="height: 10px">
                                </td>
                            </tr>
                            <tr height="5">
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee" style="height: 5px">
                                    &nbsp;</td>
                                <td style="height: 5px">
                                    <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td width="11">
                        <img alt="" src="../images/white_main_bottom_left.gif"></td>
                    <td width="99%">
                        <img alt="" src="../images/spacer_10_x_10.gif"></td>
                    <td width="10">
                        <img alt="" src="../images/white_main_bottom_right.gif"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
