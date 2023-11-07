<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchMatureOrder.aspx.cs" Inherits="finance_SearchMatureOrder" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Workflow.Support"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>报红订单统计</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/Calendar2.js"></script>
	<script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../js/finance/SearchMatureOrder.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <%--<input  type="button" onclick="alert(aTest);"/>--%>
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td style="width: 12px"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 ->报红订单统计</td>
                                <td></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">报红订单统计</td></tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center" >
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">订单号</td>
                                            <td class="item_content" colspan="3"><input name="OrderNo" id="txtOrderNo" type="text" value="" runat="server"/></td>
                                        </tr>
                                         <tr>
                                            <td class="item_caption">开单时间</td>
                                            <td class="item_content" colspan="3"><input id="txtInBeginDateTime" name="inBeginDateTime" size="13" readonly="readonly" onfocus="setday(this);" runat="server" class="buttons" />&nbsp;至&nbsp;<input id="txtInEndDateTime" name="inEndDateTime" size="13" readonly="readonly" onfocus="setday(this);" runat="server" class="buttons" /></td>
                                         </tr>
                                        <tr>
                                            <td class="item_caption">结算时间</td>
                                            <td class="item_content" colspan="3"><input id="txtBaBeginDateTime" name="baBeginDateTime" size="13" readonly="readonly" onfocus="setday(this);" runat="server" class="buttons" />&nbsp;至&nbsp;<input id="txtBaEndDateTime" name="baEndDateTime" size="13" readonly="readonly" onfocus="setday(this);" runat="server" class="buttons" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="right">
                                                <asp:Button ID="search" runat="server" OnClientClick="return dataCheck();" OnClick="Search" Text="检索" CssClass="buttons" />&nbsp;
                                                <asp:Button ID="btnPrint" runat="server"  OnClick="Print" Text="打印" CssClass="buttons" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="5%" nowrap>NO</th>
                                            <th width="10%"nowrap>订单号</th>
                                            <th width="14%"nowrap>客户名称</th>
                                            <th width="10%"nowrap>项目名称</th>
                                            <th width="15%"nowrap>开单时间</th>
                                            <th width="15%"nowrap>结算时间</th>
                                            <th width="8%" nowrap>开单人</th>
                                            <th width="8%" nowrap>收银</th>
                                            <th width="15%" nowrap>备注</th>
                                        </tr>
                                        <%if (null != model.OrderList)
                                          {
                                              for (int j = 0; j < model.OrderList.Count; j++)
                                              {
                                              %>
                                        <tr class="detailRow">
                                            <td><%=j + 1%></td>
                                            <td><a href="#" onclick="orderDetail(this);"><%=model.OrderList[j].No%></a><input type="hidden" name="myOrderNo" value="<%=model.OrderList[j].No %>"/></td>
                                            <td><%=model.OrderList[j].CustomerName%></td>
                                            <td><%=model.OrderList[j].ProjectName%></td>
                                            <td><%=model.OrderList[j].InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                                            <%if (Constants.NULL_DATE_TIME == model.OrderList[j].BalanceDateTime)
                                              { %>
                                              <td></td>
                                            <%}
                                              else
                                              { %>
                                            <td><%=model.OrderList[j].BalanceDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                                            <%} %>
                                            <td align="center"><%=model.OrderList[j].UserName%></td>
                                            <td align="center"><%=model.OrderList[j].CashName%></td>
                                            <td><%=model.OrderList[j].Memo%></td>
                                        </tr>
                                        <%
                                            }
                                        } %>
                                        <tr>
                                            <td colspan="9" style="text-align: right;">
                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                                            </td>
                                        </tr>
                                     </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
