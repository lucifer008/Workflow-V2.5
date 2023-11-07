<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyPaper.aspx.cs" Inherits="finance_find_DailyPaper" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/usercontrols/DateNavigate.ascx" TagName="DateNavigate" TagPrefix="dn" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>日报</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/DateNavigate.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
	<script type="text/javascript" src="../../js/check.js"></script>
	<script type="text/javascript" src="../../js/jquery.js"></script>
	<script type="text/javascript" src="../../js/default.js"></script>
	<script type="text/javascript" src="../../js/finance/find/dailypaper.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
    <input id="hidDate" name="date" type="hidden" value="0" runat="server"/>
    <input id="actionTag" name="actionTag" type="hidden" value="F" runat="server"/>
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%" heigth="100%">
                            <tr>
                                <td ></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 日报</td>
                                <td ></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">日 报</td></tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td nowrap class="item_caption"> 结算日期</td>
                                                        <td class="item_content">
                                                            <div>
                                                            <input id="txtBeginDateTime" name="txtBeginDateTime" type="text" class="datetexts"  size="16" onfocus="setday(this);" runat="server" readonly="readOnly" />&nbsp;至&nbsp;
														    <input id="txtEndDateTime" name="txtEndDateTime" type="text" class="datetexts" size="16" onfocus="setday(this)" runat="server" readonly="readonly"/>
                                                            </div>
                                                        </td>
                                                        <td nowrap class="item_caption"> 查询类型</td>
                                                        <td class="item_caption"><select id="sltQueryType" runat="server"></select></td>
                                                        <td align="right">
														    <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="btnSearch_Click" Text="查询" OnClientClick="return DataCheck();"/>&nbsp;
														    <asp:Button ID="btnDispatchPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnDispatchPrint_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
										</tr>
                                    </table>
                                </td>
                                <td width="3%"> &nbsp;</td>
                            </tr>
                            <tr>
                            <td width="3%"> &nbsp;</td>
                            <td><dn:DateNavigate ID="dateNavigate" runat="server" /></td>
                            <td width="3%"> &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    <%if (model.OrderTempList != null){%>
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="5%" nowrap> &nbsp;N&nbsp; O&nbsp;</th>
                                            <th width="11%" nowrap >订 单 号</th>
                                            <th width="11%" nowrap >客户名称</th>
                                            <th width="11%" nowrap > 现&nbsp; 金</th>
                                            <th width="11%" nowrap > 记 账</th>
									        <th width="11%" nowrap="nowrap">发 票</th>
									        <th width="11%" nowrap="nowrap">会员卡冲减金额</th>
									        <th width="11%" nowrap="nowrap">开单时间</th>
									        <th width="11%" nowrap="nowrap">结算时间</th>
                                        </tr>
                                        <%decimal accountReceviableTotal = 0;//应收款合计 
                                          decimal cashTotal = 0;//现金合计
                                          decimal paidAmountTotal = 0;//发票金额合计
                                          decimal memberCardDiffAmountTotal = 0;//会员卡冲减金额合计
                                          for (int i = 0; i < model.OrderTempList.Count; i++)
                                           {
                                               accountReceviableTotal += model.OrderTempList[i].AccountReceviableOweMomeyTotal;
                                               cashTotal += model.OrderTempList[i].PaidAmount-model.OrderTempList[i].RealPaidAmount;
                                               paidAmountTotal += model.OrderTempList[i].NotPayTicketAmount;
                                               memberCardDiffAmountTotal += model.OrderTempList[i].RealPaidAmount;
                                        %>
                                           <tr class="detailRow">
                                               <td align="center"><%=i+1 %></td>
                                               <td align="center" ><a href="#" onclick="orderDetail(this)"><%=model.OrderTempList[i].No%></a></td>
                                               <td align="center" ><%=model.OrderTempList[i].CustomerName%></td>
                                               <td class="num"  align="right"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[i].PaidAmount-model.OrderTempList[i].RealPaidAmount)%></td>
                                               <td align="right"><%=model.OrderTempList[i].AccountReceviableOweMomeyTotal %></td>       
										       <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[i].NotPayTicketAmount)%></td>
										       <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[i].RealPaidAmount)%></td>
										       <td align="center"><%=Convert.ToDateTime(model.OrderTempList[i].InserDateTimeStrings).ToString("yyyy-MM-dd HH:mm")%></td>
										       <td align="center"><%=Convert.ToDateTime(model.OrderTempList[i].BalanceDateTime).ToString("yyyy-MM-dd HH:mm")%></td>
                                           </tr>
                                        <%}
                                        %>
                                            <tr class="detailRow">
                                                <td align="right" colspan="2">本页合计</td>
                                                <td> &nbsp;</td>
                                                <td class="num" align="right"><%=Workflow.Util.NumericUtils.ToMoney(cashTotal)%></td>
										         <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(accountReceviableTotal)%></td>
										         <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(paidAmountTotal)%></td>
										         <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(memberCardDiffAmountTotal)%></td>
										         <td></td>
										         <td></td>
                                            </tr>
                                            <tr class="detailRow">
                                                <td align="right" colspan="2">总税费</td>
                                                <td colspan="7" align="center" style="color:Green"><%=Workflow.Util.NumericUtils.ToMoney(model.ScotAmount)%></td>
                                           </tr>
                                           <tr class="detailRow">
                                                <td align="right" colspan="2">总合计</td>
                                                <td> &nbsp;</td>
                                                <td class="num" align="right" style="color:Red"><%=Workflow.Util.NumericUtils.ToMoney(model.CashTotal + model.ScotAmount)%></td>
										        <td align="right" style="color:Aqua"><%=Workflow.Util.NumericUtils.ToMoney(model.OweTotal) %></td>
										        <td align="right" style="color:Lime"><%=Workflow.Util.NumericUtils.ToMoney(model.TicketTotal) %></td>
										        <td align="right" style="color:Purple"><%=Workflow.Util.NumericUtils.ToMoney(model.MemberCardAmountTotal) %></td>
										        <td></td>
										        <td></td>
                                            </tr>
                                             <tr class="detailRow">
                                                <td align="right" colspan="2">总收入</td>
                                                <td colspan="7" align="center" style="color:Blue"><%=Workflow.Util.NumericUtils.ToMoney(model.OweTotal + model.CashTotal + model.ScotAmount)%></td>
                                            </tr>
                                            <tr>
                                                <td bgcolor="#eeeeee" align="right" colspan="9"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" onclick="pagerCheck();"></webdiyer:AspNetPager></td>
                                            </tr>
                                    </table>
                                    <%} %>
                                </td>
                            </tr>
                             <tr height="5">
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
