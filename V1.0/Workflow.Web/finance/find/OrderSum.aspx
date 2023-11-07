<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderSum.aspx.cs" Inherits="FinanceFindOrderSum" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>客户消费统计</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
    <script type="text/javascript" src="../../js/checkCalendar.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript">
	function showOrderDetail(){
		showPage('SearchCustomerOrderList.html',null,700,476,false,false);
	}
	$(document).ready(function() {
		$("a[@innerHTML=详细]").attr("href", "javascript:showOrderDetail();");
	});	
    </script>

</head>
<body>
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
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 客户消费统计</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">客户消费统计</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">时间段:</td>
                                            <td class="item_content" nowrap="nowrap">
                                                <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" onfocus="setday(this);" readonly="readonly"/>&nbsp;至&nbsp;
                                                <input id="txtTo" type="text" name="EndDateTime" class="datetexts" onfocus="setday(this);" readonly="readonly"/></td>
                                            <td width="36%" style="padding-right: 10px" align="right"><asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="" Text="查询" /></td>
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
                                            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                                            <th width="30%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;客户名称&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>&nbsp;&nbsp;工单数&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>&nbsp;&nbsp;打印量&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;金额&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="65%" nowrap>备注</th>
                                            <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                        </tr>
                                        <%
                                            decimal orderCount = 0;
                                            decimal paperCount = 0;
                                            decimal sumAmount = 0;
                                            for (int i = 0; i < model.OrderList.Count; i++)
                                            {
                                                orderCount += model.OrderList[i].OrderCount;
                                                paperCount += model.OrderList[i].PaperCount;
                                                sumAmount += model.OrderList[i].SumAmount;
                                        %>
                                        <tr class="detailRow">
                                            <td align="center"><%=i+1 %></td>
                                            <td align="left"><a href="#" onclick="customerDetail(this);">
                                                <%=model.OrderList[i].CustomerName%></a><input type="hidden" name="txtCustomerId" value="<%=model.OrderList[i].CustomerId %>" />
                                            </td>
                                            <td class="num"><%=model.OrderList[i].OrderCount%></td>
                                            <td class="num"><%=model.OrderList[i].PaperCount%></td>
                                            <td class="num"><%=model.OrderList[i].SumAmount%></td>
                                            <td align="left"><%=model.OrderList[i].Memo%></td>
                                            <td><a href="#"></a></td>
                                        </tr>
                                        <%}
                                        %>
                                        <tr class="detailRow">
                                            <td>合计</td>
                                            <td>&nbsp;</td>
                                            <td class="num"><%=orderCount %></td>
                                            <td class="num"><%=paperCount %></td>
                                            <td class="num"><%=sumAmount %></td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
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
                    <td width="12"><img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function customerDetail(o)
    {
        var customerId=$($("input[@name='txtCustomerId']",$(o).parent().parent())).val();
        showPage('../../customer/CustomerDetail.aspx?Id='+customerId, null, 800, 550, false, true);
    }
</script>
