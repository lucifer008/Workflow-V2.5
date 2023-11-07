<%@ Page Language="C#" AutoEventWireup="true" CodeFile="YearPaper.aspx.cs" Inherits="finance_find_YearPaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>年度汇总</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/math.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <style type="text/css">
       .yearNav a
       {
            text-decoration:none;
       } 
       .yearNav a:active
       {
            text-decoration:none;
            color:black;
       }
    </style>
    <script type="text/javascript">
        function showMonthPaper(dt){
            var url = "MonthPaper.aspx?dt=" + dt;
        	showPage(url, null, 800, 485, false, false);
        }
    </script>
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
    <div align="center" style="width: 99%; background-color: #FFFFFF; margin:0px auto;" id="container">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0"/></td>
                <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                <td width="12"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
            </tr>
            <tr>
                <td colspan="3" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="3%"></td>
                            <td align="left" bgcolor="#eeeeee">首页 -&gt; 财务处理 -&gt;年度汇总</td>
                            <td width="3%"></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption" align="center">年 度 汇 总</td>
                        </tr>
                       
                       <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="center">
                               <table width="100%">
                                <tr>
                                    <td id="tdNav" align="left" class="yearNav" style="">
                                        <a href="YearPaper.aspx?year=<%=currentYear-2%>" index="<%=currentYear - currentYear +2%>">前年</a>
                                        <a href="YearPaper.aspx?year=<%=currentYear-1%>" index="<%=currentYear - currentYear +1%>">去年</a>
                                        <a href="YearPaper.aspx?year=<%=currentYear %>" index="<%=currentYear - currentYear%>">本年</a>
                                    </td>
                                    <td  align="right"><%=DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") %></td>
                                </tr>
                               </table>
                            </td>
                            <td width="3%">&nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="center">
                                <%
                                    //应收款
                                    decimal accountReceviableTotal = 0.00M;
                                    
                                    //现金合计
                                    decimal cashTotal = 0.00M;
                                    
                                    //发票金额合计
                                    decimal paidAmountTotal = 0.00M;

                                    //会员卡冲减金额
                                    decimal memberDiffAmountTotal = 0.00M;

                                    //税费
                                    decimal scotAmountTotal = 0.00M;
                                    
                                    //当月营业额合计
                                    decimal dailyMoneyTotal = 0.00M;
                                 %>
                            
                               <table width="100%"  border="1" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <th>No</th>
                                        <th style="width:10%">现金</th>
                                        <th style="width:10%">记账</th>
                                        <th style="width:10%">发票</th>
                                        <th style="width:10%">会员卡冲减金额</th>
                                        <th style="width:10%">当月营业额合计</th>
                                        <th style="width:10%">税费</th>
                                        <th style="width:4%">操作</th>
                                    </tr>
                               
                               <%
                                   DateTime beginDateTime;
                                   DateTime endDateTime;
                                   for (int i = 0; i < 12; i++)
                                   {
                                       beginDateTime = Convert.ToDateTime(year.ToString() + "-" + Convert.ToString(i + 1) + "-1");
                                       endDateTime = beginDateTime.AddMonths(1);

                                       CashHandOverAction.Model.HandOverDateTime = beginDateTime.ToString("yyyy-MM-dd");
                                       FindFinanceAction.Model.NewOrder.CurrentHandOverBeginDate = CashHandOverAction.DailyPaperMinHandOverDateTime;

                                       CashHandOverAction.Model.HandOverDateTime = endDateTime.ToString("yyyy-MM-dd");
                                       FindFinanceAction.Model.NewOrder.CurrentHandOverEndDate = CashHandOverAction.DailyPaperMinHandOverDateTime;

                                       FindFinanceAction.SearchMonthPaperOrder_ToPrint();
                                       if (1 == model.OrderTempList.Count)
                                       {
                                           decimal cashMoney = model.OrderTempList[0].PaidAmount - model.OrderTempList[0].RealPaidAmount;
                                           if (isCurrentYear)
                                           {
                                               if (i + 1 > DateTime.Now.Month)
                                               {
                                                   break; 
                                               }
                                           }
                                     
                                     %>
                                        <tr class="detailRow">
                                        <td align="center" style="width:4%;" ><%=i + 1%>月</td>
                                        <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(cashMoney)%></td>
                                        <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[0].AccountReceviableOweMomeyTotal)%></td>
                                        <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[0].NotPayTicketAmount)%></td>
                                        <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderTempList[0].RealPaidAmount)%></td>
                                        <td align="right" style="color:Blue"><%=Workflow.Util.NumericUtils.ToMoney(cashMoney + model.OrderTempList[0].AccountReceviableOweMomeyTotal)%></td>
                                        <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.ScotAmount)%></td>
                                        <td style="width:4%;" ><a  onclick="showMonthPaper('<%= HttpUtility.HtmlEncode(beginDateTime.ToString("yyyy-MM")) %>')"  href="#">详情</a></td>
                                    </tr> 
                                    
                                    <%cashTotal += cashMoney; 
                                     accountReceviableTotal += model.OrderTempList[0].AccountReceviableOweMomeyTotal;
                                     paidAmountTotal += model.OrderTempList[0].NotPayTicketAmount;
                                     memberDiffAmountTotal += model.OrderTempList[0].RealPaidAmount; 
                                     scotAmountTotal += model.ScotAmount;
                                     dailyMoneyTotal += cashMoney + model.OrderTempList[0].AccountReceviableOweMomeyTotal;
                                      %>
                                   <%}
                                 }%>
                                  <tr class="detailRow">
                                       <td align="center">合计</td>
                                       <td class="num" align="right"><%=Workflow.Util.NumericUtils.ToMoney(cashTotal)%></td>
                                       <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(accountReceviableTotal)%></td>
				                       <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(paidAmountTotal)%></td>
				                       <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(memberDiffAmountTotal)%></td>
				                       <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(dailyMoneyTotal)%></td>
				                       <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(scotAmountTotal)%></td>
				                       <td>&nbsp;</td>
                                   </tr>      
                        
                                   
                               </table>
                            </td>
                            <td width="3%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3"></td>
                        </tr>
                        <tr height="5">
                            <td width="3%"><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                            <td bgcolor="#eeeeee">&nbsp;</td>
                            <td width="3%"><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                        </tr>
                       
                    </table>
                </td>
            </tr>
            <tr>
                <td width="12"><img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11"/></td>
                <td bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                <td width="12"><img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11"/></td>
            </tr>
        </table>
           <script type="text/javascript">
            var aArr = $('a', $($('#tdNav')));
            var yearDiff = <%=currentYear%> - <%=year %>;
            for(var i = 0; i < aArr.length; i++){
                if (aArr[i].index == yearDiff){
                    aArr[i].style.cssText = 'color:red';
                }
            }
        </script>
    </div>
    </form>
</body>
</html>
