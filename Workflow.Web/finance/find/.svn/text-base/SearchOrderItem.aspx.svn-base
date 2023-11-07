<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchOrderItem.aspx.cs" Inherits="SearchOrderItem" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>订单消费查询</title>
<link href="../../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../js/Calendar2.js"></script>
<script type="text/javascript" src="../../js/checkCalendar.js"></script>
<script type="text/javascript" src="../../js/checkCalendar.js"></script>
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../js/default.js"></script>
<script type="text/javascript" src="../../js/finance/find/searchOrderItem.js"></script>
</head>
<body style="text-align:center">
<div align="center" style="width:99%; background-color:#ffffff;" id="container">
<form id="form1" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0"></td>
		<td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"></td>
		<td width="12"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 订单消费查询</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">
                    订单消费查询</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
			<table width="100%" border="1" cellpadding="2" cellspacing="1">
              <tr>
                <td nowrap class="item_caption">加工业务:</td>
                <td class="item_content">
                    <asp:DropDownList ID="BusinessType" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">不限</asp:ListItem>
                    </asp:DropDownList></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">数量:</td>
                <td class="item_content"><select name="AmountSelect" id="AmountSelect" runat="server">
                  <option>小于</option>
                  <option>小于等于</option>
                  <option>等于</option>
                  <option selected="selected">大于等于</option>
                  <option>大于</option>
                  </select>
                  <input name="Amount" id="Amount" type="text" class="num" runat="server" /></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">金额:</td>
                <td class="item_content"><select name="UnitPrice" id="UnitPrice" runat="server">
                  <option>小于</option>
                  <option>小于等于</option>
                  <option>等于</option>
                  <option selected="selected">大于等于</option>
                  <option>大于</option>
                  </select>
                    <input type="text" name="Price" id="Price" class="num" runat="server"/>
                  元</td>
              </tr>
              <tr>
                <td nowrap class="item_caption">时 间 段:</td>
                <td class="item_content"><div>
					<input id="txtFrom" type="text" name="txtFrom" runat="server" maxlength="10" onfocus="setday(this);" class="datetexts" readonly="readonly" size="16"/>&nbsp;至&nbsp;	
	    		    <input name="txtTo" type="text" id="txtTo" runat="server"  maxlength="10" onfocus="setday(this);" class="datetexts" readonly="readonly" size="16"/>
			    </td>
                </tr>
              <tr>
                <td colspan="2" nowrap align="right" style="padding-right:10px">
                    <asp:Button ID="Search"  class="buttons" runat="server" Text="查询" OnClick="SearchOrders" />
                    <asp:Button ID="Button1" CssClass="buttons" runat="server" OnClick="Print" OnClientClick="" Text="打印" /></td>
              </tr>
            </table>				</td>
				<td width="3%">&nbsp;</td>
			</tr>
			
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                              <tr>
                              
			                    <th width="3%" nowrap>&nbsp;NO&nbsp;</th>
                                <th width="10%" nowrap>订单号</th>
                                <th width="15%" nowrap>客户名称</th>
                                <th width="8%" nowrap>数量</th>
                                <th width="8%" nowrap>金额</th>
                                <th width="10%" nowrap>备注</th>
                                </tr>
                                <% int i = 1;
		        	                    foreach (Workflow.Da.Domain.Order val in model.OrderList)
			                       { %>
                                <tr class="detailRow">
				                    <td><%=i %></td>
				                    <td><a href="#" onclick="orderDetail(this)"><%=val.No %></a></td>
				                    <td><%=val.CustomerName %></td>
				                    <td><%=val.ItemAmount %></td>
				                    <td><%=val.SumAmount %></td>
				                    <td><%=val.Memo %></td>
                                </tr>
                                <% i++;
					                    } %>
                    					
				                    <% if(model.Order!=null){ %>
					                    <tr class="detailRow">
						                    <td>合计</td>
						                    <td></td>
						                    <td></td>
						                    <td><%=model.Order.ItemAmount%></td>
						                    <td><%=model.Order.SumAmount%></td>
						                    <td></td>
					                    </tr>
				                    <%} %>
                                <tr class="detailRow">
			                     <td bgcolor="#eeeeee" colspan="6" align="right">
				                       <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
					                    </webdiyer:AspNetPager>
			                     </td>
			                    </tr>
                            </table>				
			</td>
				<td width="3%">&nbsp;</td>		
			</tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3">&nbsp;</td>
			</tr>			
			<tr height="5">
				<td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
			</tr>		</table>
		</td>
	</tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td width="12"><img alt="" src="../../images/white_main_bottom_left.gif"
			width="12" height="11"></td>
		<td bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif"
			width="10" height="10"></td>
		<td width="12"><img alt="" src="../../images/white_main_bottom_right.gif"
			width="12" height="11"></td>
	</tr>
</table>
</form>
</div>
</body>
</html>
