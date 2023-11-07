<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PermissionList.aspx.cs" Inherits="popedomManagement_PermissionList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>操作一览</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/popedommanagement/permission.js"></script>
    <base target="_self" />
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
        <input id="hiddTag" name="hiddTag" type="hidden" value="" />
        <input id="hiddPermissionId" name="hiddPermissionId" type="hidden" value="" />
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../../images/white_main_top_left.gif"></td>
                    <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;基本操作管理&nbsp;-&gt;&nbsp;操作一览</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">操作一览</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="left">
                                   <%-- <input id="Button1" type="button" class="buttons" value="新增操作" onclick="location.href ='/popedomManagement/NewPermission.aspx'" /></td>--%>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="1%" nowrap> &nbsp;NO&nbsp;</th>
                                            <th  class="item_caption"> 操作名称</th>
                                            <th nowrap width="1%"  class="item_caption">备注</th>
                                            <th width="1%" nowrap></th>
                                        </tr> 
                                        <%
                                            int i=1;
                                            foreach(Workflow.Da.Domain.Permission permission in model.PermissionList){ %>                                      
                                        <tr class="detailRow">
                                            <td nowrap><%=i%></td>
                                            <td nowrap><%=permission.PermissionIdentity %></td>
                                            <td nowrap align="left"><%=permission.Memo %></td>                                           
                                            <td nowrap align="left">
                                                <a href='#' onclick="EdmitPermission('<%=permission.Id %>')">编辑</a>
                                                <a href="#" onclick="DeletePermission('<%=permission.Id %>')">删除</a>
                                            </td>
                                        </tr>
                                    <%i++;} %>
                                        <tr>
                                     <td bgcolor="#eeeeee" align="right" colspan="4">
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
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="11"><img alt="" src="../../images/white_main_bottom_left.gif"></td>
                    <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif"></td>
                    <td width="10"><img alt="" src="../../images/white_main_bottom_right.gif"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
