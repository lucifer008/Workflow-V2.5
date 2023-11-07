<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCustomerOrderList.aspx.cs" Inherits="finance_find_SearchCustomerOrderList" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>客户客户订单列表</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
	<link href="../../css/thickbox.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../../js/jquery.js"></script>
	<script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/escExit.js"></script>
	<script type="text/javascript">
	function showOrderDetail(no){
		showPage('/order/OrderDetail.aspx?OrderNo='+no,null,850,650,false,false);
	}
	</script>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
    <div align="center" style="width:99%" bgcolor="#ffffff" id="container">
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF"">	
	<tr>
		<td width="11"><img alt="" src="../../images/white_main_top_left.gif" /></td>
		<td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif" height="10" /></td>
		<td width="10"><img alt="" src="../../images/white_main_top_right.gif"
			width="12" height="11"></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0" cellpadding="5">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 财务管理 -&gt; 财务查询 -&gt; 订单统计 -&gt; 客户客户订单列表</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption">客户客户订单列表</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="left">西北建筑设计院
				
				</td>
				<td width="3%">&nbsp;</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
				<table width="100%" border="1" cellpadding="2" cellspacing="1" >
                  <tr>
                    <th width="1%" nowrap="nowrap">NO</th>
                    <th width="10%" nowrap="nowrap">订单号</th>
                    <th width="20%" nowrap="nowrap">开单时间</td>
                    <th width="20%" nowrap="nowrap">结算时间</th>
                    <th width="5%" nowrap="nowrap">开单人</th>
                    <th width="5%" nowrap="nowrap">收银人</th>
                    <th width="5%" nowrap="nowrap">联系人</th>
                    <th nowrap="nowrap">备注</th>
                  </tr>
                  <% int i = 1;
                  	foreach(Workflow.Da.Domain.Order val in model.OrderList){ %>
                  <tr class="detailRow">
					<td><%=i %></td>
					<td><a href="javascript:showOrderDetail('<%=val.No %>')"><%=val.No %></a></td>
					<td><%=val.InsertDateTime %></td>
					<td><%=val.BalanceDateTime %></td>
					<td><%=val.NewOrderName %></td>
					<td><%=val.CashName %></td>
					<td><%=val.Name %></td>
					<td><%=val.Memo %></td>
				</tr>
                  <% i++;
				 } %>
				 <tr class="detailRow">
				 <td bgcolor="#eeeeee" colspan="8" align="right">
					   <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
						</webdiyer:AspNetPager>
				 </td>
				</tr>
                </table>				
                </td>
				<td width="3%">&nbsp;</td>
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
		<td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif"></td>
		<td width="10"><img alt="" src="../../images/white_main_bottom_right.gif"></td>
	</tr>
</table>
</div>
    </form>
</body>
</html>
