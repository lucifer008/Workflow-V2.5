<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AccountReceivableAccordingToTimeSectTotal.aspx.cs" Inherits="finance_find_AccountReceivableAccordingToTimeSectTotal" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>应收款按时间段合计</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
	<script type="text/javascript" src="../../js/check.js"></script>
	<script type="text/javascript" src="../../js/jquery.js"></script>
	<script type="text/javascript" src="../../js/default.js"></script>
	<script type="text/javascript" src="../../js/finance/find/accountReceivableAccordingToTimeSectTotal.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12px"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 应收款按时间段合计</td>
                                <td></td>
                            </tr>
                            <tr> <td colspan="3" class="caption" align="center">应收款按时间段合计</td></tr>
                            <tr> <td width="3%">&nbsp;</td>
                                 <td>
                                    <table  width="100%" border="0" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td align="center" bgcolor="#FFFFFF">
                                                <table width="100%" heigth="100%" border="1" cellpadding="0" cellspacing="0">
                                                    <tr><td nowrap class="item_caption" id="TD2" runat="server">客户名称</td>
                                                        <td class="item_content" id="TD1" runat="server" >
                                                            <input id="CustomerName" class="texts" type="text" runat="server" />
                                                            <input id="btnSelectedCustomer" class="buttons" type="button" visible="false" value="选择客户"/>
															   </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption" align="center">结算时间</td>
                                                        <td class="item_content">
                                                            <div>
                                                                <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts"  onfocus="setday(this);" size="16" runat="server" readonly="readOnly" />
                                                                &nbsp;&nbsp;至 &nbsp;&nbsp;
                                                                <input id="txtTo" type="text" name="EndDateTime" class="datetexts" runat="server" onfocus="setday(this);" size="16" readonly="readOnly"/>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right" >
                                                                <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="btnSearch_Click"  Text="查询" />
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
                                <td width="3%" > &nbsp;</td>
                                <td>
                                <%if (FindFinanceAction.OrderModel.OrderTempList != null)
								  {%>
                                    <table width="100%" heigth="100%" border="1" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <th width="1%" nowrap>N O</th>
                                            <th nowrap>客 户 名 称</th>
                                            <th nowrap>应 收 款</th>
                                            <th nowrap>备 注</th>
                                            <th nowrap></th>
                                        </tr>
                                        <%decimal arrearage = 0;
										       for (int i = 0; i < model.OrderTempList.Count; i++)
                                          {
											        arrearage += model.OrderTempList[i].AccountReceviableOweMomeyTotal;
                                        %>
                                        <tr class="detailRow">
                                            <td align="center"><%=i+1 %></td>
                                            <td align="left"><%=model.OrderTempList[i].CustomerName%></td>
                                            <td class="num" style="color:Blue"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[i].AccountReceviableOweMomeyTotal)%></td>
                                            <td><%=FindFinanceAction.OrderModel.OrderTempList[i].Memo%></td>
                                            <td>
                                                <a href="#" onclick="showOweMoneyDetail(<%=model.OrderTempList[i].CustomerId %>,'<%=model.OrderTempList[i].CustomerName %>')">欠款明细</a>
                                                <%--<a href="#" onclick="showPaidMoneyDetail(<%=model.OrderTempList[i].CustomerId %>,'<%=model.OrderTempList[i].CustomerName %>')">付款明细</a>--%>
                                            </td>
                                        </tr>
                                        <%}
                                        %>
                                        <tr class="detailRow">
                                            <td>合计</td>
                                            <td >&nbsp;</td>
                                            <td class="num" style="color:Blue"><%=Workflow.Util.NumericUtils.ToMoney(arrearage)%></td>
											&nbsp; &nbsp; &nbsp; &nbsp;
											<td>&nbsp;</td>
											<td>&nbsp;</td>
                                        </tr>
                                       <tr class="detailRow">
                                         <td bgcolor="#eeeeee" align="right" colspan="5">
                                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                                         </td>
                                      </tr> 
                                    </table>
                                    <%} %>
                                </td>
                                <td width="3%"></td>
                            </tr>

                            <tr height="5">
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td> <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                
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
