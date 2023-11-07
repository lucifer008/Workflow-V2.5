<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberCardList.aspx.cs"  Inherits="MemberCardList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>会员一览</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Calendar2.js"></script>
    <script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/membercard/membercardList.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
    <input id="hiddOperateTag" name="hiddOperateTag" type="hidden" runat="server"/>
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"> <img alt="" src="../images/white_main_top_left.gif"></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;会员一览</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">会员一览</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <td nowrap class="item_caption">会员卡号</td>
                                            <td class="item_content"><input type="text" id="txtMemberCardNo" name="txtMemberCardNo" runat="server"/></td>
                                            <td nowrap class="item_caption">卡状态</td>
                                            <td class="item_content">
                                                <asp:DropDownList ID="ddlMemberCardState" runat="server">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">客户名称</td>
                                            <td class="item_content"><asp:TextBox ID="txtCustomerName" runat="server"></asp:TextBox></td>
                                            <td nowrap class="item_caption">卡级别</td>
                                            <td class="item_content">
                                                <asp:DropDownList ID="ddlMemberCardLevel" runat="server" AppendDataBoundItems="True">
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">发卡时间</td>
                                            <td class="item_content" colspan="3">
                                                <div>
                                                    <input id="txtBeginDate" runat="server" type="text" class="datetexts" onfocus="setday(this)" size="16" readonly="readonly"/>
                                                    &nbsp;&nbsp;至&nbsp;&nbsp;
                                                     <input id="txtEndDate" runat="server"  type="text" onfocus="setday(this)" size="16" readonly="readonly"/>
                                                </div>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="right" class="querybuttons">
                                                <asp:Button ID="SearchMember" runat="server" Text="查询" CssClass="buttons" OnClick="SearchMemberCardInfo"  OnClientClick="return checkInput();" />&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <%--<td width="3%"></td>--%>
                            </tr>
                            <tr>
                                <td colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="left">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="1%" nowrap align="center">&nbsp;NO&nbsp;</th>
                                            <th width="10%" nowrap align="center">会员卡号</th>
                                            <th width="20%" nowrap align="center">客户名称</th>
                                            <th width="10%" nowrap align="center">状态</th>
                                            <th width="10%" nowrap align="center">级别</th>
                                            <th width="10%" nowrap align="center">开始时间</th>
                                            <th width="10%" nowrap align="center">结束时间</th>
                                            <th width="10%" nowrap align="center">消费总额</th>
                                            <th width="1%" nowrap align="center">积分</th>
                                            <th width="10%" nowrap align="center">备注</th>
                                            <th width="1%" nowrap align="center">&nbsp;&nbsp;</th>
                                        </tr>
                                        <% if (model.MemberCardList != null)
                                           {
                                               for (int i = 1; i <= model.MemberCardList.Count; i++)
                                               {
                                                   Workflow.Da.Domain.MemberCard memberCard = model.MemberCardList[i - 1];
                                        %>
                                        <tr class="detailRow">
                                            <td align="center" nowrap><%= i%></td>
                                            <td align="center" nowrap>
                                                <a href="#" onclick="selectMembercarDetail('<%=memberCard.Id %>')"><%= memberCard.MemberCardNo%></a>
                                            </td>
                                            <td align="left" nowrap><%= memberCard.CustomerName%></td>
                                            <%
                                            if (memberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_KEY)
                                            {
                                            %>
                                            <td align="center" nowrap><%= Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_TEXT%></td>
                                            <%}
                                              else if (memberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_KEY)
                                              { %>
                                            <td align="center" nowrap><%= Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_TEXT%></td>
                                            <%}
                                              else
                                              {%>
                                            <td align="center" nowrap><%= Workflow.Support.Constants.MEMBER_CARD_STATE_LOGOUT_TEXT%></td>
                                            <%} %>
                                            <td align="center" nowrap><%= memberCard.MemberCardLevel.Name%></td>
                                            <td align="center" nowrap><%= memberCard.MemberCardBeginDate.ToString("yyyy-MM-dd")%></td>
                                            <td align="center" nowrap><%= memberCard.MemberCardEndDate.ToString("yyyy-MM-dd")%></td>
                                            <td align="right" nowrap><%= Workflow.Util.NumericUtils.ToMoney(SearchMemberCardAction.SearchMemberCardConsumeAmount(memberCard.Id))%></td>
                                            <td align="right" nowrap><%= memberCard.Integral%></td>
                                            <td nowrap><%= memberCard.CustomerMemo%></td>
                                            <td nowrap>
                                               <a href="#" onclick="EdmitMember('<%=memberCard.Id %>');">编辑</a>
                                              <a href="#" onclick="DeleteMember('<%=memberCard.Id %>');">删除</a> 
                                            </td>
                                        </tr>
                                        <%}
                                      }%>
                                     <tr>
                                         <td bgcolor="#eeeeee" align="right" colspan="11">
                                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                                </webdiyer:AspNetPager>
                                         </td>
                                      </tr> 
                                    </table>
                                </td>
                            </tr>

                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td>&nbsp;</td>
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
