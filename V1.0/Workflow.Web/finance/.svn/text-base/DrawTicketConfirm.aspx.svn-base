<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DrawTicketConfirm.aspx.cs" Inherits="finance_DrawTicketConfirm" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<title>发票领取</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/escExit.js"></script>
<script type="text/javascript" src="../js/finance/drawticket.js"></script>
<base target="_self" />
<script>
    <%if(isDraw){ %>
        window.close();
        opener.location.reload();
    <%} %>
</script>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
    <input id="hiddDrawTicketAmountTotal" name="drawTicketAmountTotal" value="<%= drawTicketAmount%>" type="hidden" />
    <div align="center" id="container">
    <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
    <tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	</tr> 
	<tr>
	<td></td>
    <td colspan="3" bgcolor="#FFFFFF">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td width="3%"></td>
		 <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;财务处理 -&gt; 发票领取</td>
		 <td width="3%"></td>
      </tr>
      <tr>
        <td colspan="3" class="caption" align="center">发票领取</td>
      </tr>
      <tr>
        <td width="3%">&nbsp;</td>
        <td align="center"><table width="100%" border="1" cellpadding="2" cellspacing="1">
            <tr id="tr1">
                <th width="15%" nowrap>工单号</th>
                <th width="15%" nowrap>客户名称</th>
                <th width="15%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开单时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                <th width="15%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;结算时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                <th width="15%" nowrap>欠票金额</th>
                <th width="15%" nowrap>&nbsp;收银&nbsp;</th>
            </tr>
             <%if (null!=model.OrderList)
              {
                    Workflow.Da.Domain.Order order = model.OrderList[0];
               %>
               <tr class="detailRow">
                    <td nowrap align="center" Width="14%"><a href="#" onclick="orderDetail('<%=order.No %>')"><%= order.No%></a></td>
                     <td nowrap align="center" Width="14%"><%=order.CustomerName %></td>
                    <td nowrap align="left"   Width="19%"><%= order.InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                    <td nowrap align="center" Width="18%"><%= order.BalanceDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                    <td nowrap align="right" Width="20%"><%=Workflow.Util.NumericUtils.ToMoney(order.NotPayTicketAmount)%></td>
                    <td nowrap align="center" Width="20%"><%= order.CashName%></td>
              </tr>
            <%} %>
          </table>
        </td>
      </tr>
      <tr>
        <td width="3%">&nbsp;</td>
        <td align="center">
           <table width="100%" border="1" cellpadding="2" cellspacing="1">
            <tr>
               <td class="item_caption">本次领取金额</td><td class="item_content">
               <input type="text" name="drawtTicketAmount" id="txtDrawTicketAmount" value="<%=drawTicketAmount %>" />
               </td>
            </tr>
          </table>
        </td>
      </tr> 
      <tr>
           <td width="3%">&nbsp;</td>	
           <td align="center" class="bottombuttons">
              <asp:Button ID="btnOK" CssClass="buttons" runat="server" OnClick="Save" OnClientClick="return dataCheck();" Text="确定" />
              <input type="button" id="btnCancel" name="cancel" class="buttons" value="关闭" onclick="window.close();"/>
           </td>
          <td width="3%">&nbsp;</td>	
      </tr> 
      <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>	
      <tr height="5">
        <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
        <td bgcolor="#eeeeee" style="height: 5px">&nbsp;</td>
        <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
      </tr> 
     </table> 
    </td>
    <td></td>
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
