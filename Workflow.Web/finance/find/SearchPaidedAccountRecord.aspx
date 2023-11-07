<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchPaidedAccountRecord.aspx.cs" Inherits="finance_find_SearchPaidedAccountRecord" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>应收款付款记录</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
	<script type="text/javascript" src="../../js/jquery.js"></script>
	<script type="text/javascript" src="../../js/default.js"></script>
	<script type="text/javascript" src="../../js/finance/find/searchPaidedAccountRecord.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
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
                            <tr><td ></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 应收款付款记录</td>
                                <td ></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">应收款付款记录</td></tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                      <td nowrap class="item_caption">会员卡号</td>
                                                      <td class="item_content" colspan="2"><input id="txtMemberCardNo" name="memberCardNo" type="text" size="16" runat="server"/></td>
                                                    </tr>
                                                    <tr>
                                                      <td nowrap class="item_caption">客户名称</td>
                                                      <td class="item_content" colspan="2"><input id="txtCustomerName" name="customerName" type="text" size="16" runat="server"/></td>
                                                    </tr>
                                                    <tr>
                                                      <td nowrap class="item_caption"> 收款日期</td>
                                                      <td class="item_content">
                                                        <div>
                                                             <input id="txtBeginDateTime" name="txtBeginDateTime" type="text" class="datetexts"  size="16" onfocus="setday(this);" runat="server" readonly="readOnly" />&nbsp;至&nbsp;
                                                             <input id="txtEndDateTime" name="txtEndDateTime" type="text" class="datetexts" size="16" onfocus="setday(this)" runat="server" readonly="readonly"/>
                                                         </div>
                                                       </td>
                                                     </tr>
                                                    <tr>
                                                    <td colspan="2" align="right">
														        <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="btnSearch_Click" Text="查询" OnClientClick="return queryDataCheck();"/>&nbsp;
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
                                <td align="center">
                                    
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="5%" nowrap> &nbsp;N&nbsp; O&nbsp;</th>
                                            <th width="15%" nowrap>客户名称</th>
                                            <th width="15%" nowrap >收款日期</th>
										    <th width="15%" nowrap="nowrap">收款金额</th>
										    <th width="15%" nowrap="nowrap">预存金额</th> 
										    <th width="15%" nowrap="nowrap">发票金额</th> 
										    <th width="15%" nowrap="nowrap">税费</th> 
                                            <th nowrap="nowrap" width="5%"></th>
                                        </tr>
									    <% if (null != model.OtherGathingAndRefundMentRecordList)
                                           {
                                               decimal paidAmountTotal = 0;
                                               decimal preDepositiAmountTotal = 0;
                                               decimal ticketAmountTotal = 0;
                                               decimal scotAmuntTotal = 0;
                                               for (int i = 0; i < model.OtherGathingAndRefundMentRecordList.Count; i++)
                                               {
                                                   paidAmountTotal += model.OtherGathingAndRefundMentRecordList[i].PaidAmount;
                                                   ticketAmountTotal += model.OtherGathingAndRefundMentRecordList[i].TicketAmountSum;
                                                   scotAmuntTotal += model.OtherGathingAndRefundMentRecordList[i].Amount;
                                                   decimal pAmount = model.OtherGathingAndRefundMentRecordList[i].PreDepositiAmount;
                                                   if (0 < pAmount) preDepositiAmountTotal += model.OtherGathingAndRefundMentRecordList[i].PreDepositiAmount;
                                                   else pAmount = 0;
                                         %>
                                                    <tr class="detailRow">
                                                    <td><%=i+1 %><input name="customerId" type="hidden" value="<%=model.OtherGathingAndRefundMentRecordList[i].CustomerId%>" /></td>
                                                    <td class="customerName"><%=model.OtherGathingAndRefundMentRecordList[i].CustomerName %></td>
                                                    <td class="gatheringDateTime"><%=model.OtherGathingAndRefundMentRecordList[i].InsertDateTimeString %></td>
									                <td><%=Workflow.Util.NumericUtils.ToMoney(model.OtherGathingAndRefundMentRecordList[i].PaidAmount)%></td>
									                <td><%=Workflow.Util.NumericUtils.ToMoney(pAmount)%></td>
									                <td><%=Workflow.Util.NumericUtils.ToMoney(model.OtherGathingAndRefundMentRecordList[i].TicketAmountSum) %></td> 
									                <td><%=Workflow.Util.NumericUtils.ToMoney(model.OtherGathingAndRefundMentRecordList[i].Amount)%></td>
									                <td><a href="#" onclick="showPaidMoneyDetail(this)">明细</a></td> 
									                </tr>
									    <%
                                               }%>
                                        
                                        <tr class="detailRow">
                                            <td colspan="3" align="right">合计</td>
                                            <td><%=Workflow.Util.NumericUtils.ToMoney(paidAmountTotal) %></td>
                                            <td><%=Workflow.Util.NumericUtils.ToMoney(preDepositiAmountTotal) %></td>
                                            <td><%=Workflow.Util.NumericUtils.ToMoney(ticketAmountTotal) %></td>
                                            <td><%=Workflow.Util.NumericUtils.ToMoney(scotAmuntTotal) %></td>
                                            <td></td>
                                        </tr>
									    <%} %>
                                        <tr class="detailRow">
                                           <td bgcolor="#eeeeee" align="right" colspan="8">
                                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                               </webdiyer:AspNetPager>
                                           </td>
                                        </tr>
                                    </table>
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
