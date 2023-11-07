<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersList.aspx.cs" Inherits="popedomManagement_UsersList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>用户一览</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/popedommanagement/users.js"></script>
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
    <input id="hiddTag" name="hiddTag" type="hidden" value="" runat="server"/>
    <input id="hiddUserId" name="hiddUserId" type="hidden" value="" runat="server"/>
    <input id="hiddRoleId" name="hiddRoleId" type="hidden" value="" runat="server"/>
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
                                <td align="left" bgcolor="#eeeeee"> 首页&nbsp;-&gt;&nbsp;人员管理&nbsp;-&gt;&nbsp;用户一览</td>
                                <td width="3%"></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">用户一览</td></tr>
                            <tr>
                                <td width="3%" nowrap></td>
                                <td align="left" width="94%" nowrap>        
                                <table border="1" width="100%" nowrap>
                                <tr><td width="80" class="item_caption">用户名</td><td ><input type="text" name="txtUserName" /></td></tr>
                                <tr>
                                <td width="80" class="item_caption">用户角色</td>
                                <td>
                                    <asp:DropDownList ID="sltUserRole"  runat="server" AppendDataBoundItems="True"><asp:ListItem Value="-1">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                                </tr>
                                <tr><td align="right" colspan="2"><input id="btnSearch" type="button" class="buttons" value="查询" runat="server" onserverclick="btnSearch_ServerClick"/></td></tr>
                                </table>
                                </td>
                                <td width="3%" nowrap></td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="1%" nowrap> &nbsp;NO&nbsp;</th>
                                            <th class="nowrap" width="10%">用户名</th>
                                            <th class="nowrap" width="10%">用户角色</th>
                                            <th width="10%" nowrap>是否登陆</th>
                                            <th width="2%" nowrap></th>
                                        </tr>
                                        <%
                                            if (null != UserAction.Model.UserList)
                                            {
                                                for (int index = 0; index < UserAction.Model.UserList.Count; index++)
                                                {
                                        %>                                       
                                        <tr class="detailRow">
                                        <td nowrap><%=index + 1%></td>
                                            <td nowrap><%=UserAction.Model.UserList[index].UserName%></td>
                                            
                                            <td nowrap><%=UserAction.GetUserRoleStringByUserId(UserAction.Model.UserList[index].Id)[1]%></td>
                                            <td nowrap align="center"><%=UserAction.Model.UserList[index].IsLogin%></td>
                                            <td nowrap align="left">
                                                <a href="#" onclick="EdmitUser('<%=UserAction.Model.UserList[index].Id%>','<%=UserAction.GetUserRoleStringByUserId(UserAction.Model.UserList[index].Id)[0]%>')">编辑</a>
                                                <a href="#" onclick="DeleteUser('<%=UserAction.Model.UserList[index].Id%>')">删除</a>
                                            </td>
                                        </tr>
                                        
                                       <%
                                                }
                                      %>
                                       <tr>
                                           <td bgcolor="#eeeeee" align="right" colspan="9">
                                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                               </webdiyer:AspNetPager>
                                           </td>
                                        </tr>
                                        <%
                                            } 
                                            %>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td style="height: 5px"><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee" style="height: 5px"> &nbsp;</td>
                                <td style="height: 5px"><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
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
