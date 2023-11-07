<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchRepayHistory.aspx.cs"
    Inherits="SearchRepayHistory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>客户对帐表</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../../css/thickbox.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="../../js/jquery.js"></script>

    <script type="text/javascript" src="../../js/default.js"></script>

    <script type="text/javascript">
	function showOrderDetail(){
		showPage('../../order/OrderDetail.html',null,700,800,false,false);
	}

    </script>

</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF"">
                <tr>
                    <td width="11">
                        <img alt="" src="../../images/white_main_top_left.gif" /></td>
                    <td width="99%" bgcolor="#ffffff">
                        <img alt="" src="../../images/spacer_10_x_10.gif" height="10" /></td>
                    <td width="10">
                        <img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td>
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页 -> 财务处理 -> 财务查询 -> 客户对帐表</td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption">
                                    客户对帐表</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td nowrap class="item_caption">
                                                会员卡号:</td>
                                            <td class="item_content" colspan="2">
                                                <input class="texts" type="text" name="MemberCardNo" value="<%=model.MemberCardNo %>" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                客户名称:</td>
                                            <td class="item_content">
                                                <input type="text" id="txtCustomerName" name="CustomerName" value="<%=model.CustomerName%>" class="texts" />
                                                <input type="button" class="buttons selectButtons" value="选择客户" onclick="showSelectCustomer();" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right" >
                                                <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick=""
                                                    Text="查询" /></td>
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
                                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0" bgcolor="#F0F0F0">
                                        <tr>
                                            <td width="100%" align="center" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td nowrap class="item_caption">
                                                            客户名称:</td>
                                                        <%
                                                            if (model.OList.Count > 0)
                                                            {%>
                                                        <td colspan="5" class="item_content" bgcolor="#F8F8F8">
                                                            <%=model.OList[0].CustomerName %>
                                                        </td>
                                                        <%}
                                                          else
                                                          { %>
                                                        <td colspan="5" class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                        <%}        
                                                        %>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">
                                                            地址:</td>
                                                        <%
                                                            if (model.OList.Count > 0)
                                                            {%>
                                                        <td colspan="3" class="item_content" bgcolor="#F8F8F8">
                                                            <%=model.OList[0].Address %>
                                                        </td>
                                                        <%}
                                                          else
                                                          { %>
                                                        <td colspan="3" class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                        <%}        
			        
                                                        %>
                                                        <td nowrap class="item_caption">
                                                            电话:</td>
                                                        <%
                                                            if (model.OList.Count > 0)
                                                            {%>
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                            <%=model.OList[0].LastTelNo %>
                                                        </td>
                                                        <%}
                                                          else
                                                          { %>
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                        <%}        
			        
                                                        %>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">
                                                            制作次数:</td>
                                                        <%
                                                            if (model.OList.Count > 0)
                                                            {%>
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                            <%=model.OList[0].OrderCount %>
                                                        </td>
                                                        <%}
                                                          else
                                                          { %>
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                        <%}        
			        
                                                        %>
                                                        <td nowrap class="item_caption">
                                                            平均每单金额:</td>
                                                        <%
                                                            if (model.OList.Count > 0)
                                                            {%>
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                            <%=model.OList[0].PaidAmount%>
                                                        </td>
                                                        <%}
                                                          else
                                                          { %>
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                        <%}        
			        
                                                        %>
                                                        <td nowrap class="item_caption">
                                                            总计消费金额:</td>
                                                        <%
                                                            if (model.OList.Count > 0)
                                                            {%>
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                            <%=model.OList[0].SumAmount %>
                                                        </td>
                                                        <%}
                                                          else
                                                          { %>
                                                        <td class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                        <%}        
			        
                                                        %>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">
                                                            总计欠款:</td>
                                                        <%
                                                            if (model.OList.Count > 0)
                                                            {%>
                                                        <td colspan="5" class="item_content" bgcolor="#F8F8F8">
                                                            <%=model.OList[0].RealPaidAmount%>
                                                        </td>
                                                        <%}
                                                          else
                                                          { %>
                                                        <td colspan="5" class="item_content" bgcolor="#F8F8F8">
                                                        </td>
                                                        <%}        
			        
                                                        %>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td width="3%">
                                </td>
                                <td align="left">
                                </td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap>
                                                &nbsp;NO&nbsp;</th>
                                            <th width="1%" nowrap>
                                                工单号</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;总额 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;优惠&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;抹零&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;挂账&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;实收金额 &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;说明&nbsp;&nbsp;</th>
                                        </tr>
                                        <%
                                            for (int i = 0; i < model.OrderList.Count; i++)
                                            { %>
                                        <tr class="detailRow">
                                            <td align="center">
                                                <%=i+1 %>
                                            </td>
                                            <td align="center"><a href="#" onclick="orderDetail(this);">
                                                <%=model.OrderList[i].No %></a><input type="hidden" name="myOrderNo" value="<%=model.OrderList[i].No %>" />
                                            </td>
                                            <td align="center">
                                                <%=model.OrderList[i].BalanceDateTime %>
                                            </td>
                                            <td class="num">
                                                <%=model.OrderList[i].SumAmount %>
                                            </td>
                                            <td class="num">
                                                <%=model.OrderList[i].Concession%>
                                            </td>
                                            <td class="num">
                                                <%=model.OrderList[i].Zero%>
                                            </td>
                                            <td class="num">
                                                <%=model.OrderList[i].Concession%>
                                            </td>
                                            <td class="num">
                                                <%=model.OrderList[i].RealPaidAmount %>
                                            </td>
                                            <td align="center">
                                                欠款</td>
                                        </tr>
                                        <%}
                                        %>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
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
                    <td width="11">
                        <img alt="" src="../../images/white_main_bottom_left.gif" /></td>
                    <td width="99%" bgcolor="#ffffff">
                        <img alt="" src="../../images/spacer_10_x_10.gif" /></td>
                    <td width="10">
                        <img alt="" src="../../images/white_main_bottom_right.gif" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<script type="text/javascript">
function selectCustomer(objCustomer)
{
    if(objCustomer==null) return;
    $("#customerid").attr("value",objCustomer.Id);
    $("#txtMemberCardId").attr("value",objCustomer.MemeberCardId);
    $("#txtMemberCardNo").attr("value",objCustomer.MemberCardNo);
    $("#txtTradeId").attr("value",objCustomer.TradeId);
    $("#txtCustomerName").attr("value",objCustomer.Name);
    $("#txtName").attr("value",objCustomer.LinkMan);
    $("#telNo").attr("value",objCustomer.TelNo);
    $("#txtMemo").attr("value",objCustomer.Memo);
}
function showSelectCustomer(){
    var customerName=$("#txtCustomerName").val();
	showPage('../../customer/SelectCustomer.aspx?customerName='+escape(customerName),null,890,566,false,false);
}

function orderDetail(o)
{
    var orderNo=$("input[@name='myOrderNo']",$(o).parent().parent()).val();
    showPage('../../order/OrderDetail.aspx?OrderNo='+orderNo, null, 1000, 700, false, true);
}
</script>

