<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchTurnOver.aspx.cs" Inherits="FinanceFindSearchTurnOver" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>门店营业额查询</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>

</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页 -> 财务处理 -> 财务查询 -> 门店营业额查询</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    门店营业额查询</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">
                                                时间段:</td>
                                            <td class="item_content" nowrap="nowrap">
                                                
                                                    <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" value="<%=model.BalanceDateTimeString %>" onfocus="setday(this);" readonly="readonly"/>
                                                    <input id="txtTo" type="text" name="EndDateTime" class="datetexts" value="<%=model.InsertDateTimeString %>" onfocus="setday(this);" readonly="readonly"/>
                                            </td>
                                            <td width="36%" align="right" style="padding-right: 10px">
                                                <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick=""
                                                    Text="查询" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap>
                                                &nbsp;NO&nbsp;</th>
                                            <th width="25%" nowrap="nowrap">
                                                营业店名称</th>
                                            <th width="1%" nowrap>
                                                工单总数</th>
                                            <th width="1%" nowrap>
                                                应收款额</th>
                                            <th width="1%" nowrap>
                                                实收款额</th>
                                            <th width="1%" nowrap>
                                                欠款额</th>
                                            <th nowrap>
                                                备注</th>
                                        </tr>
                                        <%decimal orderCount = 0;
                                          decimal sumAmount = 0;
                                          decimal paidAmount = 0;
                                          decimal arrearageAmount = 0;
                                          for (int i = 0; i < model.OrderList.Count; i++)
                                          {
                                              orderCount += model.OrderList[i].OrderCount;
                                              sumAmount += model.OrderList[i].SumAmount;
                                              paidAmount += model.OrderList[i].PaidAmount;
                                              arrearageAmount += model.OrderList[i].PrepareMoneyAmount;
                                        %>
                                        <tr class="detailRow">
                                            <td align="center">
                                                <%=i+1 %>
                                            </td>
                                            <td align="left">
                                                <%=model.OrderList[i].CustomerName %>
                                            </td>
                                            <td class="num">
                                                <%=model.OrderList[i].OrderCount %>
                                            </td>
                                            <td class="num">
                                                <%=model.OrderList[i].SumAmount %>
                                            </td>
                                            <td class="num">
                                                <%=model.OrderList[i].PaidAmount %>
                                            </td>
                                            <td class="num">
                                                <%=model.OrderList[i].PrepareMoneyAmount %>
                                            </td>
                                            <td>
                                                <%=model.OrderList[i].Memo %>
                                            </td>
                                        </tr>
                                        <%}
                                        %>
                                        <tr class="detailRow">
                                            <td>
                                                合计</td>
                                            <td>
                                                &nbsp;</td>
                                            <td class="num">
                                                <%=orderCount %>
                                            </td>
                                            <td class="num">
                                                <%=sumAmount %>
                                            </td>
                                            <td class="num">
                                                <%=paidAmount %>
                                            </td>
                                            <td class="num">
                                                <%=arrearageAmount %>
                                            </td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr height="5">
                                <td>
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">
                                    &nbsp;</td>
                                <td>
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF">
                        <img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
