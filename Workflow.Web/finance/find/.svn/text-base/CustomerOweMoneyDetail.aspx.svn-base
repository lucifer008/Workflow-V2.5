<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerOweMoneyDetail.aspx.cs" Inherits="finance_find_CustomerOweMoneyDetail" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>客户欠款明细</title>
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
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 财务管理 -&gt; 财务查询 -&gt; 客户欠款明细</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption">客户欠款明细表</td>
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
                        <th>No</th>
                        <th width="10%" nowrap>订单号</th>
                        <th nowrap>开单时间</th>
                        <th nowrap>结算时间</th>
                        <th nowrap>总额</th>
                        <th nowrap>优惠金额</th>
                        <th nowrap>抹零金额</th>
                        <th nowrap>折让金额</th>
                        <th nowrap>已付款额</th>
                        <th nowrap>冲减金额</th>
                        <th nowrap>应收款额</th>
                      </tr>
                      <%
                          int index=0;
                          decimal oweMoneyTotal = 0;
                          foreach(Workflow.Da.Domain.Order order in model.OrderList) 
                          {
                              index++;
                              oweMoneyTotal += order.SumAmount - order.Concession - order.Zero - order.RenderUp - order.PaidAmount-order.NeedPrePay;
                            %>
                      <tr  class="detailRow">
                        <td><%=index %></td>
                        <td align="center"><a href="#"  onclick="orderDetail(this)"><%=order.No%></a></td>
                        <td align="center" ><%=order.InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                        <td align="center" nowrap ><%=order.BalanceDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                        <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(order.SumAmount) %></td>
                        <td align="center" ><%=Workflow.Util.NumericUtils.ToMoney(order.Concession) %></td>
                        <td align="center" ><%=Workflow.Util.NumericUtils.ToMoney(order.Zero) %></td>
                        <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(order.RenderUp) %></td>
                        <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(order.PaidAmount) %></td>
                        <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(order.NeedPrePay)%></td>
                        <td align="right"><%=Workflow.Util.NumericUtils.ToMoney(order.SumAmount-order.Concession-order.Zero-order.RenderUp-order.PaidAmount-order.NeedPrePay) %></td>
                      </tr>
                      <%
                          }
                           %>
                      <tr>
                          <td>欠款合计</td>
                          <td align="right" colspan="10"><%=Workflow.Util.NumericUtils.ToMoney(oweMoneyTotal) %></td>
                      </tr>
                       <tr class="detailRow">
                            <td colspan="11" style="text-align:right">
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
