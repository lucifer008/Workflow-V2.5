<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewPermissionGroup.aspx.cs" Inherits="popedomManagement_NewPermissionGroup" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=strTitle %></title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/popedommanagement/permissionGroup.js"></script>
    <base target="_self" />
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
    <input id="hidPermissionGroupId" name="permissionGroupId" type="hidden" runat="server"/>
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;权限组管理&nbsp;-&gt;&nbsp;<%=strTitle %></td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center"><%=strTitle %></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" style="width: 100%" align="left">
                                        <tr>
                                            <td width="1%" nowrap  class="item_caption">权限组名称</td>
                                            <td align="left"  class="item_content"><input type="text" id="txtName" name="name" runat="server"/></td>
                                        </tr>
                                        <tr>
                                            <td width="1%" nowrap  class="item_caption">备注</td>
                                            <td align="left" class="item_content"><input type="text" id="txtMemo" name="memo" runat="server"/></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="left"">
                                <asp:Button ID="btnSave"  CssClass="buttons" Text="保存" OnClientClick="return checkData();" OnClick="btnSave_ServerClick" runat="server"/>
                                <input type="button" id="btnClose" class="buttons" value="关闭" onclick="window.close();" visible="false" runat="server"/>
                                <td width="3%"></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_bottom_left.gif"></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"></td>
                    <td width="10"><img alt="" src="../images/white_main_bottom_right.gif"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
