<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SwapMemberCardRecord.aspx.cs" Inherits="SwapMemberCardRecord" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>会员换卡记录</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/check.js"></script>
    <script type="text/javascript" src="../js/Calendar2.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/membercard/swapMemberCardRecord.js"></script>
    <script type="text/javascript" language="javascript">
    var count=0;
    <%if(null!=model.ChangeMemberCardList) {%>
        count=<%=model.ChangeMemberCardList.Count %>
    <%} %>
    </script>
</head>
<body style="text-align: center">
    <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
    <form id="form1" runat="server">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
                <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
            </tr>
            <tr>
                <td colspan="3" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="3%"></td>
                            <td align="left" bgcolor="#eeeeee">
                                首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;会员查询&nbsp;-&gt;&nbsp;会员换卡记录</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption" align="center">会员换卡记录</td>
                        </tr>
                        <tr>
                            <td width="3%"></td>
                            <td align="center">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                    <tr>
                                        <td nowrap class="item_caption">时间</td>
                                        <td class="item_content">
                                            <div>
                                                <input class="datetexts" id="txtFrom" name="txtFrom" runat="server" type="text" onfocus="setday(this)" readonly="readonly" maxlength="10"/>至
                                                <input class="datetexts" name="txtTo" id="txtTo" runat="server" type="text" onfocus="setday(this)" readonly="readonly" maxlength="10"/>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td nowrap class="item_caption">新卡卡号</td>
                                        <td nowrap class="item_content"><input class="texts" id="txtMemberCardNo" name="MemberCardNo" runat="server" type="text" /></td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="right">
                                           <asp:Button ID="btnSearch" runat="server" Cssclass="buttons" Text="检索" OnClick="SearchChageMemberCard" OnClientClick="return dataValidetor();" />
                                           <asp:Button ID="btnPrint" runat="server" Cssclass="buttons" Text="打印" OnClick="btnPrintClick" OnClientClick="return printDataValidetor(count);" />
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="3%"></td>
                        </tr>
                        <tr class="emptyButtonsUpperRowHight">
                            <td colspan="3"> &nbsp;</td>
                        </tr>
                        <tr>
                            <td width="3%"></td>
                            <td align="center">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                    <tr><th width="3%" nowrap>&nbsp;NO&nbsp;</th>
                                        <th width="15%" nowrap>客户名称</th>
                                        <th width="8%" nowrap>原卡号</th>
                                        <th width="8%" nowrap>新卡号</th>
                                        <th width="8%" nowrap>时间</th>
                                        <th nowrap width="15%">备注</th>
                                    </tr>
                                    <% if (null!=model.ChangeMemberCardList)
                                       {
                                           for (int i = 1; i <= model.ChangeMemberCardList.Count; i++)
                                           {
                                        %>
                                    <tr class="detailRow">
                                        <td align="center" nowrap><%= i %></td>
                                        <td align="left" nowrap><a href="#" onclick="customerDetail('<%=model.ChangeMemberCardList[i - 1].CustomerId %>')"><%= model.ChangeMemberCardList[i - 1].CustomerName%></a></td>
                                        <td align="center" nowrap><%= model.ChangeMemberCardList[i - 1].OldMemberCardNo %></td>
                                        <td align="center" nowrap><%= model.ChangeMemberCardList[i - 1].NewMemberCardNo %></td>
                                        <td align="center" nowrap><%= model.ChangeMemberCardList[i - 1].InsertDateTime.ToString("yyyy-MM-dd HH:mm") %></td>
                                        <td align="left" nowrap><%= model.ChangeMemberCardList[i - 1].Memo %></td>
                                    </tr>
                                    <%}%>
                                   <tr>
                                       <td colspan="6" align="right">
                                          <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                                       </td>
                                   </tr>
                                  <%} %>
                                </table>
                            </td>
                            <td width="3%"></td>
                        </tr>
                        <tr class="emptyButtonsUpperRowHight">
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr height="5">
                            <td style="height: 5px"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            <td bgcolor="#eeeeee" style="height: 5px">&nbsp;</td>
                            <td style="height: 5px"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
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
        </form>
    </div>
</body>
</html>
