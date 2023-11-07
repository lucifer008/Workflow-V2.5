<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrawTicket.aspx.cs" Inherits="finance_DrawTicket" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>发票领取</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/finance/drawticket.js"></script>
<base target="_self" />
</head>
<body style="text-align:center" onkeydown="document.onkeydown();">
<form id="form1" runat="server"  method="get">
<div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
<input type="hidden" id="hiddenSearchTag" value="" />
<input name="checkTag" id="checkTag" type="hidden" value="F" />
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	</tr> 
   <tr>
    <td colspan="3" bgcolor="#FFFFFF">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="3%"></td>
		 <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;财务处理 -&gt; 发票领取</td>
		 <td width="3%"></td>
      </tr>
	  <tr><td colspan="3" class="caption" align="center">发票领取</td></tr>
	  <tr><td width="3%">&nbsp;</td>
	      <td align="center">
			<table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                <tr>
                  <td nowrap class="item_caption">工 单 号</td>
                  <td class="item_content"><input type="text" id="OrderNo" runat="server" class="texts"/></td>
                  <td colspan="5" align="right"><asp:Button ID="Search" runat="server" CssClass="buttons" Text="查询" OnClick="Search_Click"/></td>
                </tr>
            </table>
		  </td>
	     <td width="3%"></td>
	  </tr>
      <tr>
	    <td width="3%">&nbsp;</td>
        <td align="center">
		    <table  border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
           <tr>
                <th width="10%" nowrap>&nbsp;NO&nbsp;</th>
                <th width="15%" nowrap>工单号</th>
                <th width="15%" nowrap>客户名称</th>
                <th width="15%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开单时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                <th width="15%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;结算时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                <th width="15%" nowrap>欠票金额</th>
                <th width="15%" nowrap>&nbsp;收银&nbsp;</th>
                <th width="15%" nowrap></th>
          </tr>
               <%if (model.OrderList != null)
              {
                for (int i = 1; i <= model.OrderList.Count; i++)
                {
                    Workflow.Da.Domain.Order order = model.OrderList[i - 1];
               %>
               <tr class="detailRow">
                    <td nowrap align="center"><%= i%></td>
                    <td nowrap align="center" Width="14%"><a href="#" onclick="orderDetail('<%=order.No %>')"><%= order.No%></a></td>
                    <td nowrap align="center" Width="14%"><%=order.CustomerName %></td>
                    <td nowrap align="left"   Width="19%"><%= order.InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                    <td nowrap align="center" Width="18%"><%= order.BalanceDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                    <td nowrap align="right" Width="15%"><%=Workflow.Util.NumericUtils.ToMoney(order.NotPayTicketAmount)%></td>
                    <td nowrap align="center" Width="20%"><%= order.CashName%></td>
                    <td nowrap align="center" Width="12%"><a href="#" onclick="ChoiceDrawTicketOrderNo(<%=order.Id%>)" id="aDraw">领取</a>&nbsp;<a href="#" onclick="cancelNotPaidTicket(<%=order.Id%>)">取消</a></td>
              <%}%>
              <tr>
                   <td colspan="7" align="right">
                      <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                   </td>
             </tr>
            <%} %>
           </tr>
           
        </table>
       </td>
		<td width="3%"></td>
      </tr>
      <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>	
      <tr height="5">
        <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
        <td bgcolor="#eeeeee" style="height: 5px">&nbsp;</td>
        <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
      </tr>
    </table></td>
  </tr>
	<tr>
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
	</tr>
	
</table>
</div>
</form>
</body>
</html>