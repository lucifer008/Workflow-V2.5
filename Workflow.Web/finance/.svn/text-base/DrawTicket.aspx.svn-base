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
<script type="text/javascript" src="../js/math.js"></script>
<script type="text/javascript" src="../js/finance/drawticket.js"></script>
<base target="_self" />
</head>
<body style="text-align:center">
<form id="form1" runat="server">
<div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
<input name="ActionTag" id="Tag" type="hidden" value=""/>
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
                  <td nowrap class="item_caption">客户名称:</td>
                  <td class="item_content"><input type="text" id="txtCustomerName" name="customerName" runat="server"/></td>
                 
                </tr>
                <tr>
                 <td nowrap class="item_caption">订 单 号:</td>
                  <td class="item_content"><input type="text" id="OrderNo" runat="server" class="texts"/></td>
                </tr>
                <tr>
                    <td nowrap class="item_caption">会员卡号:</td>
                    <td class="item_content"><input type="text" id="memberNo" runat="server" class="texts" /></td>
                </tr>
                <tr><td colspan="2" align="right"><asp:Button ID="Search" runat="server" CssClass="buttons" Text="查询" OnClientClick="return queryDataCheck();" OnClick="Search_Click"/>&nbsp;&nbsp;
                <asp:Button ID="btnPrint" runat="server" CssClass="buttons" Text="打印" OnClientClick="return printDataCheck()" OnClick="printClick"/></td></tr>
            </table>
		  </td>
	     <td width="3%"></td>
	  </tr>
      <tr>
	    <td width="3%">&nbsp;</td>
        <td align="center">
		    <table  border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
           <tr>
                <th width="5%" nowrap></th>
                <th width="10%" nowrap>NO</th>
                <th width="15%" nowrap>订单号</th>
                <th width="15%" nowrap>客户名称</th>
                <th width="15%" nowrap>开单时间</th>
                <th width="15%" nowrap>结算时间</th>
                <th width="15%" nowrap>欠票金额</th>
                <th width="15%" nowrap>收银</th>
                <th width="15%" nowrap>领取金额</th>
          </tr>
               <%
                    bool isRe = false;
                    decimal totalMoney = 0;
                if (null!=model.OrderList && 0 != model.OrderList.Count)
                {
                    for (int i = 0; i <model.OrderList.Count; i++)
                    {
                        isRe = true;
                        totalMoney += model.OrderList[i].NotPayTicketAmount;
               %>
               <tr class="detailRow">
                    <td><input type="checkbox" id="cb<%=model.OrderList[i].Id %>" name="cbDrawTicket<%=model.OrderList[i].Id %>" checked="checked"/></td>
                    <td nowrap align="center"><%= i+1%><input type="hidden" name="orderId" value="<%=model.OrderList[i].Id %>" /><input type="hidden" name="customerIdArr<%=model.OrderList[i].Id %>" value="<%=model.OrderList[i].CustomerId %>" /></td>
                    <td nowrap align="center" Width="14%"><a href="#" onclick="orderDetail('<%=model.OrderList[i].No %>')"><%= model.OrderList[i].No%></a></td>
                    <td nowrap align="center" Width="14%"><%=model.OrderList[i].CustomerName%></td>
                    <td nowrap align="left"   Width="19%"><%= model.OrderList[i].InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                    <td nowrap align="center" Width="18%"><%= model.OrderList[i].BalanceDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                    <td nowrap align="right"  class="notPayTicketAmount"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderList[i].NotPayTicketAmount)%></td>
                    <td nowrap align="center" Width="20%"><%= model.OrderList[i].CashName%></td>
                    <td nowrap align="center" Width="12%"><input name="oweTicketAmount<%=model.OrderList[i].Id %>" type="text" onblur="checkInputTicketAmount(this)" value="<%=model.OrderList[i].NotPayTicketAmount%>" /></td>
              <%
                    }%>
               </tr>
               <tr id="trTotalMoney" class="detailRow"><td>合计</td><td colspan="8" class="totalMoney" align="right"><%=Workflow.Util.NumericUtils.ToMoney(totalMoney) %></td></tr>
              <tr class="detailRow">
                   <td colspan="9" align="right">
                      <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                   </td>
             </tr>
           <%
                } %>
        </table>
       </td>
		<td width="3%"></td>
      </tr>
        <%if (isRe)
          { %>
        <tr>
            <td width="3%"></td>
            <td align="left">
                 <label for="cbSelected" style="color:Red"><input type="checkbox" id="cbSelected" checked="checked" onclick="allSelectedClick()"/>全选</label>
            </td>
            <td width="3%"></td>
        </tr>
        <tr>
            <td colspan="3">
                <input type="button" id="btnOk" name="btnOk" value="确定" class="buttons" onclick="return drawTikcetCheck();"/>&nbsp;&nbsp;
                <input type="button" id="btnCancel" name="btnCancel" value="取消" class="buttons" onclick="return cancelTikcetCheck();"/>
            </td>
        </tr>
        <%} %>
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