﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleList.aspx.cs" Inherits="RoleList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>角色一览</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/popedommanagement/role.js"></script>
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11">
                        <img alt="" src="../../images/white_main_top_left.gif"></td>
                    <td width="99%">
                        <img alt="" src="../../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10">
                        <img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页&nbsp;-&gt;&nbsp;人员权限管理&nbsp;-&gt;&nbsp;角色一览</td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    角色一览</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="left">
                                    <input id="Button1" type="button" class="buttons" value="新增角色" onclick="addRole();" /></td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="1%" nowrap>
                                                &nbsp;NO&nbsp;</th>
                                            <th nowrap>角色描述</th>
                                            <th width="5%" nowrap>
                                            </th>
                                        </tr> 
                                         <% int i = 1; foreach (Workflow.Da.Domain.Role role in model.RoleList)
                                       { %>                                 
                                        <tr class="detailRow">
                                            <td nowrap><%=i %></td>
                                            <td nowrap><%=role.PermissionValues %></td>
                                            <td nowrap align="left">
                                                <a href='#' onclick="editorRole(<%=role.Id %>)">编辑</a>
                                                <a href="#" onclick="deleteRole(<%=role.Id %>)">删除</a></td>
                                        </tr>
                                        <%i++;
                                      } %>
                                    </table>
                                </td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr height="5">
                                <td style="height: 5px">
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee" style="height: 5px">
                                    &nbsp;</td>
                                <td style="height: 5px">
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="11">
                        <img alt="" src="../../images/white_main_bottom_left.gif" /></td>
                    <td width="99%">
                        <img alt="" src="../../images/spacer_10_x_10.gif"></td>
                    <td width="10">
                        <img alt="" src="../../images/white_main_bottom_right.gif" /></td>
                </tr>
            </table>
        </div>
        <input id="currentValue" name="txtValue" type="hidden" value="" />
    </form>
</body>
</html>
