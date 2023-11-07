<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderPaidMoneyDetail.aspx.cs" Inherits="finance_find_OrderPaidMoneyDetail" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>订单付款明细</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript" src="../../js/jquery.js"></script>
    <script language="javascript" type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/escExit.js"></script>
    <script type="text/javascript" src="../../js/finance/find/customerOweMoneyDetail.js"></script>
</head>
<body style="text-align:center">
<div align="center" style="width:100%" bgcolor="#ffffff" id="container">
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF"">	
	<tr>
		<td width="11"><img alt="" src="../../images/white_main_top_left.gif" /></td>
		<td width="99%"  bgcolor="#ffffff"><img alt="" src="../../images/spacer_10_x_10.gif" height="10" /></td>
		<td width="10"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 财务管理 -&gt; 财务查询 -&gt; 订单付款明细</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption">订单付款明细</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="left"></td>
				<td width="3%">&nbsp;</td>
			</tr>		
			<tr>
			    <td width="3%">&nbsp;</td>
				<td align="left">客户名称:<%=customerName %></td>
				<td width="3%">&nbsp;</td>
			</tr>	
			<tr>
				<td width="3%" >&nbsp;</td>
				<td align="center">
				    <table width="100%" border="1" cellpadding="2" cellspacing="1" >
                      <tr>
                        <th nowrap>No</th>
                        <th nowrap>订单号</th>
                        <th nowrap>订单总金额</th>
                        <th nowrap>付款日期</th>
                        <th nowrap>付款金额</th>
                      </tr>
                      <%
                          int index=0;
                          decimal paidMoneyTotal = 0;
                          foreach(Workflow.Da.Domain.Order order in model.OrderList) 
                          {
                              index++;
                              paidMoneyTotal += order.PaidAmount;
                              decimal paidAmount = order.PaidAmount + order.CurrentMoney;
                            %>
                      <tr  class="detailRow">
                        <td><%=index %></td>
                        <td align="center"><a href="#"  onclick="orderDetail(this)"><%=order.No%></a></td>
                        <td align="center"><%=order.SumAmount%></td>
                        <td align="right"><%=Request.QueryString["GatheringDateTime"]%></td>
                        <td align="center" ><%=Workflow.Util.NumericUtils.ToMoney(paidAmount)%></td>
                      </tr>
                      <%
                          }
                           %>
                      <tr>
                          <td>付款合计</td>
                          <td align="right" colspan="6"><%=Workflow.Util.NumericUtils.ToMoney(paidMoneyTotal)%></td>
                      </tr>
                       <tr class="detailRow">
                            <td colspan="7" style="text-align:right">
                               <webdiyer:aspnetpager id="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" ></webdiyer:aspnetpager>
                            </td>
                       </tr>
                    </table>
                </td>                              
				<td width="3%" >&nbsp;</td>
			</tr>
			<tr>
				<td width="3%" >&nbsp;</td>
				<td align="center"></td>
				<td width="3%" >&nbsp;</td>
			</tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>			
			<tr height="5">
				<td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
			</tr>
		</table>
		</td>
	</tr>
	<tr>
		<td width="11"><img alt="" src="../../images/white_main_bottom_left.gif"></td>
		<td width="99%"  bgcolor="#ffffff"><img alt="" src="../../images/spacer_10_x_10.gif"></td>
		<td width="10"><img alt="" src="../../images/white_main_bottom_right.gif"></td>
	</tr>
</table>
</div>
</body>
</html>

