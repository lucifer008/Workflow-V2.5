<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MemberCardConsumeSum.aspx.cs"
    Inherits="MemberCardConsumeSum" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>会员消费统计</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/calendar-blue.css"  type="text/css" />
    <script type="text/javascript" src="../js/Calendar2.js"></script>
    <script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="Text/javascript" src="../js/membercard/memberCardConsumeSum.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
                    <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;会员查询&nbsp;-&gt;&nbsp;会员消费统计</td>
                                <td width="3%"></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">会员消费统计</td></tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <td nowrap class="item_caption">消费时间</td>
                                            <td class="item_content" colspan="2">
                                                    <input id="txtBeginDateTime" name="txtBeginDateTime" type="text" class="datetexts" onfocus="setday(this)" readonly="readonly" size="16"/>至
                                                    <input id="txtTo" type="text" name="txtTo" class="datetexts" onfocus="setday(this)" size="16" readonly="readonly"/>     
                                            </td>
                                            </tr>
                                            <tr>
                                            <td nowrap class="item_caption">会员卡号</td>
                                            <td class="item_content">
                                               <input class="texts" name="txtMemberCardNo" type="text" size="15" />
                                            </td>
                                        </tr>
                                        <tr>
                                           <td colspan="3" align="right">
                                               <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" Text="查询" OnClientClick ="return searchVaildal();" />
                                               <asp:Button ID="btnPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnPrint_Click" />
                                           </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="left">&nbsp;</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="2%" nowrap align="center">&nbsp;NO&nbsp;</th>
                                            <th width="5%" nowrap align="center">会员卡号</th>
                                            <th width="30%" nowrap align="center">客户名称</th>
                                            <th width="20%" nowrap align="center">消费金额</th>
                                            <th width="20%" nowrap align="center">备注</th>
                                        </tr>
                                        <%
                                            if(null!=model.OrderList)
                                            {
                                                for (int i = 0; i < model.OrderList.Count; i++)
                                                { 
                                                    %>
                                                    <tr class="detailRow">
                                                        <td align="center" nowrap><%=i+1 %></td>
                                                        <td align="left" nowrap><a href="#" onclick="memberCardDetail(<%=model.OrderList[i].MemberCardId%>);"><%=model.OrderList[i].MemberCardNo %></a></td>
                                                        <td align="left" nowrap><%=model.OrderList[i].CustomerName %></td>
                                                        <td align="right" nowrap><%=Workflow.Util.NumericUtils.ToMoney(model.OrderList[i].SumAmount)%></td>
                                                        <td align="left" nowrap><%=model.OrderList[i].Memo %></td>
                                                    </tr>
                                                  <%
                                                }
                                        %>
                                         <tr>
                                         <td bgcolor="#eeeeee" align="right" colspan="10">
                                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                                </webdiyer:AspNetPager>
                                         </td>
                                      </tr>
                                     <%} %> 
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
                    <td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>