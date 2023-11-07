<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchPrepay.aspx.cs" Inherits="FinanceFindSearchPrepay" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>预收款查询</title>
<link href="../../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../js/checkCalendar.js"></script>
<script type="text/javascript" src="../../js/default.js"></script>
<script type="text/javascript" src="../../js/Calendar2.js"></script>
<script type="text/javascript" src="../../js/finance/find/searchPrepay.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"> <img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 预收款查询</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">预收款查询</td>
                            </tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td nowrap class="item_caption">客户名称:</td>
                                            <td class="item_content">
                                               <input type="text" id="CustomerName" runat="server" />
                                               <input id="btnSelectedCustomer" type="button" visible="false" value="选择客户" class="buttons" onclick="return OpenCustomer();" /> 
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">付款时间:</td>
                                            <td class="item_content">
                                                    <input id="txtBeginDateTime" name="txtBeginDateTime" type="text" class="datetexts" onfocus="setday(this);" size="16" readonly="readOnly" runat="server"/>                                                
                                                    至 
                                                    <input id="txtTo" type="text" name="txtTo" class="datetexts" onfocus="setday(this);" size="16" readonly="readOnly" runat="server"/>
                                                    
                                            </td>
                                        </tr>
                                         <tr>
                                            <td nowrap class="item_caption">工单号:</td>
                                            <td class="item_content"><input type="text" id="orderNo" runat="server" /></td>
                                        </tr>
                                        <tr> 
                                               <td colspan="2" align="right">
                                               <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="" Text="查询" />
                                               <asp:Button ID="btnDispatchPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnDispatchPrint_Click" />
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="5%" align="center">NO</th>
                                            <th width="20%"  nowrap align="center"> 工单号</th>
                                            <th width="20%" nowrap align="center">客户名称</th>
                                            <th width="10%" nowrap align="center">预付款额</th>
                                            <%--<th width="10%" nowrap align="center">付款时间 </th>--%>
                                            <th nowrap align="center">备注</th>
                                        </tr>
                                        <% decimal prepareMoneyTotal = 0;
                                        for (int i = 0; i < FindFinanceAction.Model.OrderList.Count; i++)
                                        {
                                            prepareMoneyTotal += FindFinanceAction.Model.OrderList[i].PrepareMoneyAmount;
                                        %>
                                        <tr class="detailRow">
                                            <td align="center"><%=i+1 %></td>
                                            <td align="center"><a href="#" onclick="orderDetail('<%=FindFinanceAction.Model.OrderList[i].No%>')"><%=FindFinanceAction.Model.OrderList[i].No%></a></td>
                                            <td align="left"><%=FindFinanceAction.Model.OrderList[i].CustomerName %> </td>
                                            <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(FindFinanceAction.Model.OrderList[i].PrepareMoneyAmount) %></td>
                                            <td><%=FindFinanceAction.Model.OrderList[i].Memo %></td>
                                        </tr>
                                        <%}
                                        %>
                                        <tr>
                                           <td>合计</td>
                                           <td colspan="3" align="right"><%=prepareMoneyTotal%></td>
                                           <td></td>
                                          
                                        </tr>
                                        <tr>
                                         <td bgcolor="#eeeeee" align="right" colspan="5">
                                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                                </webdiyer:AspNetPager>
                                         </td>
                                      </tr>
                                    </table>
                                </td>
                                <%--<td width="3%">&nbsp;</td>--%>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
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
