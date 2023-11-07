<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DailyStatistical.aspx.cs" Inherits="finance_find_DailyStatistical" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>日营业报表</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
	<script type="text/javascript" src="../../js/check.js"></script>
	<script type="text/javascript" src="../../js/jquery.js"></script>
	<script type="text/javascript" src="../../js/default.js"></script>
	<script type="text/javascript" src="../../js/finance/find/dailyStatistical.js"></script>
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
                            <tr>
                                <td ></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 日营业报表</td>
                                <td ></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">日营业报表</td></tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td class="item_caption">日期</td>
                                                        <td class="item_content" colspan="2"><input id="txtBeginDateTime" name="txtBeginDateTime" type="text" class="datetexts"  size="16" onfocus="setday(this);" runat="server"/></td>
                                                        <td align="right">
                                                            <input type="submit" id="btnSearch" value="查询" class="buttons" onclick="return checkQueryCondition();" onserverclick="btnSearch_ServerClick" runat="server" />
                                                            <input type="submit" id="btnPrint" value="打印" class="buttons" onclick="return checkQueryCondition();" onserverclick="btnPrint_ServerClick" runat="server" />
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
                                            <th width="20%" nowrap>业务</th>
                                            <th width="10%" nowrap>纸型</th>
                                            <th width="30%" nowrap>数量</th>
                                            <th width="30%" nowrap>金额</th>
                                            <th width="30%" nowrap>占收入%</th>
                                          </tr>
                                        <%if (null != model.DailyBusionessReportItemList)
                                          {
                                              decimal amountTotal = 0;
                                              decimal countTotal = 0;
                                              for (int i = 0; i < model.DailyBusionessReportItemList.Count; i++)
                                              {
                                                  int rowS = model.DailyBusionessReportItemList[i].TypeSort;
                                                  countTotal += model.DailyBusionessReportItemList[i].Amount;
                                                  amountTotal += model.DailyBusionessReportItemList[i].Count;
                                           %>
                                          <tr class="detailRow">
                                          <%if(0!=rowS) {%>
                                          <td rowspan="<%=rowS %>"><%=model.DailyBusionessReportItemList[i].Name%></td>
                                          <%}%>
                                          <td><%=model.DailyBusionessReportItemList[i].PaperSpecificationName%></td>
                                          <td><%=Workflow.Util.NumericUtils.ToAmount(model.DailyBusionessReportItemList[i].Amount)%></td>
                                          <td><%=Workflow.Util.NumericUtils.ToMoney(model.DailyBusionessReportItemList[i].Count)%></td>
                                          <%if(0!=rowS) {%>
                                          <td rowspan="<%=rowS %>"><%=GetSameBusinessTypeInverse(model.DailyBusionessReportItemList[i].Name)%></td>
                                          <%}%>
                                          </tr>
                                        <%}%>
                                         <tr class="detailRow">
                                            <td colspan="2">合计</td>
                                            <td><%=Workflow.Util.NumericUtils.ToAmount(countTotal) %></td>
                                            <td><%=Workflow.Util.NumericUtils.ToMoney(amountTotal)%></td>
                                         </tr>
                                        <%}%>
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
