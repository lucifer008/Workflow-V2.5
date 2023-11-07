<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MonthPaper.aspx.cs" Inherits="finance_find_MonthPaper" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>月报</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
	<script type="text/javascript" src="../../js/check.js"></script>
	<script type="text/javascript" src="../../js/jquery.js"></script>
	<script type="text/javascript" src="../../js/default.js"></script>
	<script type="text/javascript" src="../../js/finance/find/monthpaper.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td ><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
                            <tr><td ></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 月报</td>
                                <td></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">月 报</td></tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                                    <tr><td nowrap class="item_caption"> 结算月份</td>
                                                        <td class="item_content">
                                                            <div><input id="txtMonthPaperDateTime" name="txtDailyPaperDateTime" type="text" class="datetexts"  size="16" onfocus="setday(this,this,true,false);" runat="server" readonly="readOnly" />
																    &nbsp; &nbsp; &nbsp;&nbsp;
                                                             </div>
                                                        </td>
                                                        <td colspan="2" align="right" >
															    <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="btnSearch_Click" Text="查询"/>&nbsp;
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
                                            <th width="1%" nowrap> NO</th>
                                            <th width="33%" nowrap>现金</th>
                                            <th width="33%" nowrap>记账</th>
											<th width="33%" nowrap>发票</th>
                                        </tr>
                                           <%
                                            decimal accountReceviableTotal = 0, cashTotal = 0, paidAmountTotal = 0;
                                            string reqMonth = txtMonthPaperDateTime.Value;
                                             if ("" == reqMonth)
                                             {
                                                 reqMonth = DateTime.Now.ToShortDateString();
                                             }
                                            int monthDays=FindFinanceAction.HowMonthDay(Convert.ToDateTime(reqMonth).Year, Convert.ToDateTime(reqMonth).Month);
                                            for (int index = 1; index <= monthDays; index++)
                                            {  
                                                   string year = Convert.ToDateTime(reqMonth).ToString("yyyy");
                                                   string month = Convert.ToDateTime(reqMonth).ToString("MM");
                                                   string beginDateTime = Convert.ToDateTime(year + "-" + month + "-" + index.ToString()).ToString("yyyy-MM-dd");
                                                   string endDateTime = Convert.ToDateTime(year + "-" + month + "-" + index.ToString()).AddDays(+1).ToString("yyyy-MM-dd");
                                                   CashHandOverAction.Model.HandOverDateTime = beginDateTime;
                                                   FindFinanceAction.Model.NewOrder.CurrentHandOverBeginDate = CashHandOverAction.DailyPaperMinHandOverDateTime;
                                                  
                                                   CashHandOverAction.Model.HandOverDateTime = endDateTime;
                                                   FindFinanceAction.Model.NewOrder.CurrentHandOverEndDate = CashHandOverAction.DailyPaperMinHandOverDateTime;
                                                   
                                                   FindFinanceAction.SearchMonthPaperOrder_ToPrint();
                                                   if (1== model.OrderTempList.Count)
                                                   {
                                                      
                                                     %>
                                                       <tr class="detailRow">
                                                           <td align="center" width="1%"><%=index%></td>
                                                           <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[0].PaidAmount)%></td>
                                                           <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[0].AccountReceviableOweMomeyTotal)%></td>
											               <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[0].NotPayTicketAmount)%></td>
                                                       </tr>
                                                          <%
                                                        accountReceviableTotal += model.OrderTempList[0].AccountReceviableOweMomeyTotal;//应收款合计
                                                        cashTotal += model.OrderTempList[0].PaidAmount;//现金合计
                                                        paidAmountTotal += model.OrderTempList[0].NotPayTicketAmount;//发票金额合计
                                                   }
                                                %>
                                               <%} %> 
                                               <tr class="detailRow">
                                                   <td align="center">合计</td>
                                                   <td class="num" align="right"><%=Workflow.Util.NumericUtils.ToMoney(cashTotal)%></td>
                                                   <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(accountReceviableTotal)%></td>
							                       <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(paidAmountTotal)%></td>
                                               </tr>                                            
                                        </table>
                                        
                                </td>
                            </tr>
                             <tr height="5">
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee"> &nbsp;</td>
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12" ><img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
