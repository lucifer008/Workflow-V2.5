<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyRole.aspx.cs" Inherits="ModifyRole" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>角色<%=model.Action %></title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/escExit.js"></script>
    <script type="text/javascript" src="../../js/popedommanagement/role.js"></script>
    <base target="_self" />
</head>
<body>
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
                                    首页&nbsp;-&gt;&nbsp;操作权限管理&nbsp;-&gt;&nbsp;角色管理&nbsp;-&gt;&nbsp;角色<%=model.Action %></td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    角色<%=model.Action %></td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="left">                                    
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="left">
                                    角色权限描述：<input type="text" name="roleName" value="<%=model.Name %>" /></td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="30%" nowrap>
                                                权限描述
                                            </th>
                                            <th nowrap>
                                                状态
                                            </th>
                                        </tr>
                                        <% if (null != model.PermissionGroupList)
                                           {
                                               long usedPermissionOperator = Workflow.Support.Constants.PERMISSION_GROUP_OPERATE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
                                               foreach (Workflow.Da.Domain.PermissionGroup permissionGroup in model.PermissionGroupList)
                                               { %>
                                        <tr>
                                            <td><%=permissionGroup.Name%></td>
                                            
                                            <td nowrap>
                                            <%foreach(Workflow.Da.Domain.Permission permission in model.PermissionList){ %>
                                            <%if ( usedPermissionOperator == permission.Id)
                                              {
                                                  if (0!=permissionGroup.PermissionId){ %>
                                                <input checked="checked" name="roleCheckbox" value="<%=permissionGroup.Id %>:<%=permission.Id %>" type="checkbox" />
                                                <%}else{ %>
                                                <input name="roleCheckbox" value="<%=permissionGroup.Id %>:<%=permission.Id %>" type="checkbox" />
                                                <%} %>
                                            <%}else{ %>
                                            <input disabled="disabled" name="roleCheckbox"  value="<%=permissionGroup.Id %>:<%=permission.Id %>" type="checkbox" />
                                            <%} %>
                                            <%=permission.PermissionIdentity %>&nbsp;&nbsp;
                                            <%} %>
                                            </td>
                                        </tr>
                                        <%}
                                      }%>
                                    </table>                                    
                                </td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td width="3%" style="height: 24px">
                                </td>
                                <td align="left" style="height: 24px">
                                    <input type="button" value="保存" onclick="currentAction();"/>&nbsp;&nbsp;
                                 </td>
                                <td width="3%" style="height: 24px">
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr height="5">
                                <td style="height: 5px">
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee" style="height: 5px">
                                    &nbsp;</td>
                                <td style="height: 5px">
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                         </table>
                    </td>
                </tr>
                <tr>
                    <td width="11">
                        <img alt="" src="../../images/white_main_bottom_left.gif"></td>
                    <td width="99%">
                        <img alt="" src="../../images/spacer_10_x_10.gif"></td>
                    <td width="10">
                        <img alt="" src="../../images/white_main_bottom_right.gif"></td>
                </tr>
            </table>
        </div>
        <input name="operation" type="hidden" value="operation" />
    </form>
</body>
</html>
