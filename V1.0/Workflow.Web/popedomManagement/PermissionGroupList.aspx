<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PermissionGroupList.aspx.cs" Inherits="popedomManagement_PermissionGroupList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="Workflow.Support" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>权限组一览</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/popedommanagement/permissionGroup.js"></script>
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
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;权限组管理&nbsp;-&gt;&nbsp;权限组一览</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">权限组一览</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th nowrap width="40%">权限组名称</th>
                                            <th nowrap width="50%">备注</th>
                                            <th nowrap></th>
                                        </tr>
                                        <%
                                            foreach(PermissionGroup permissionGroup in model.PermissionGroupList)
                                            { %>                                       
                                        <tr class="detailRow">
                                            <td nowrap class="Name"><%=permissionGroup.Name%></td>
                                            <td nowrap align="left" class="Memo"><%=permissionGroup.Memo %></td>                                          
                                            <td nowrap align="left">
                                               <input type="hidden" name="permissionGroupId" value="<%=permissionGroup.Id%>" />
                                                <a href="#" onclick="edmitPermissionGroup(this);">编辑</a>
                                                <a href="#" onclick="deletePermissionGroup(this);">删除</a>
                                            </td>
                                        </tr>
                                        <%} %> 
                                      <tr>
                                     <td bgcolor="#eeeeee" align="right" colspan="3">
                                       <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                       </webdiyer:AspNetPager>
                                     </td>
                                </tr>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee" style="height: 5px">&nbsp;</td>
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
