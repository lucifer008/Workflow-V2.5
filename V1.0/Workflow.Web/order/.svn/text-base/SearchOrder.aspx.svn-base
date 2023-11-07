<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchOrder.aspx.cs" Inherits="SearchOrder" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>工单查询</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/order/searchOrder.js"></script>
<script type="text/javascript" language="javascript">
var isExistData=false;     
<%
    if(null==model.OrderList || 0==model.OrderList.Count)
    {
    %>
        isExistData=true;
      <%
    }
 %>
</script>
</head>
<body style="text-align:center">
<form id="form1" runat="server">
<div align="center" style="width:99%" id="container">
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
		 <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;工单管理&nbsp;-&gt;&nbsp;工单查询</td>
		 <td width="3%"></td>
      </tr>
	  <tr><td colspan="3" class="caption" align="center">工单查询</td></tr>
	  <tr><td width="3%">&nbsp;</td>
	      <td align="center">
			<table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                <tr>
                  <td nowrap class="item_caption">工 单 号</td>
                  <td class="item_content"><input type="text" id="OrderNo" runat="server" class="texts"/></td>
                  <td nowrap class="item_caption"> 开 单 时 间 段</td>
                  <td class="item_content">
                  <div>
					    <input type="text" class="datetimetexts" id="txtFrom" runat="server" onfocus="setday(this);" name="txtFrom" readonly="readonly" maxlength="10"/>&nbsp;&nbsp;至&nbsp;&nbsp;
					    <input type="text" class="datetimetexts" id="txtTo" runat="server" onfocus="setday(this);"  name="txtTo" readonly="readonly" maxlength="10"/>
		    		</div>
				   </td>
                </tr>
                <tr>
                  <td nowrap class="item_caption">会员卡号</td>
                  <td class="item_content"><input type="text" id="MemberCardNo" runat="server" class="texts"/></td>
                  <td nowrap class="item_caption"> 客 &nbsp;&nbsp; 户&nbsp; 名&nbsp; 称</td>
                  <td class="item_content"><input type="text" id="CustomerName" runat="server" class="texts"/> &nbsp;</td>
                </tr>
                <tr>
                  <td nowrap class="item_caption"> 金 &nbsp; &nbsp; 额</td>
                  <td class="item_content" colspan="3">
                         <select name="SelectCondition" id="SelectCondition" runat="server" class="biaodan"/>                                                             
                        <input type="text" class="num" id="Money"  runat="server" maxlength="10"/>
                 </td>
                </tr>
                <tr>
                  <td colspan="6" align="right">
                      <asp:Button ID="Search" runat="server" CssClass="buttons" Text="查询" OnClick="SearchOrdersInfo" OnClientClick=" return CheckSumAmount();"/>&nbsp;
                        <asp:Button ID="Button1" runat="server" CssClass="buttons" OnClick="Button1_Click1" Text="打印" OnClientClick="return checkDataPrint();"/>
                  </td>
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
                <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                <th width="10%" nowrap>工单号</th>
                <th width="20%"nowrap>客户名称</th>
                <th width="10%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开单时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                <th width="10%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;结算时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                <th width="10%" nowrap>消费金额</th>
                <th width="1%" nowrap>开单人</th>
                <th width="1%" nowrap>&nbsp;收银&nbsp;</th>
                <th width="10%"nowrap>&nbsp;备注&nbsp;</th>
          </tr>
          <%  if (null != model.OrderList)
              {
                  decimal orderTotal = 0;
                  for (int i = 1; i <= model.OrderList.Count; i++)
                  {
                      Workflow.Da.Domain.Order order = model.OrderList[i - 1];
                      orderTotal += order.Sumamount;
               %>
               <tr class="detailRow">
                    <td align="center"><%= i%></td>
                    <td nowrap align="center"><a href="#" onclick="showPage('OrderDetail.aspx?OrderNo=<%= order.No %>', null, 1000, 700, false, true);"><%= order.No%></a></td>
                    <td align="left"><%= order.Name%></td>
                    <td nowrap align="center"><%=Workflow.Util.DateUtils.ToFormatDateTime(order.InsertDateTime, Workflow.Util.DateTimeFormatEnum.DateTimeNoSecondFormat)%> </td>
                    <td nowrap align="center"><%= Workflow.Util.DateUtils.ToFormatDateTime(order.BalanceDateTime, Workflow.Util.DateTimeFormatEnum.DateTimeNoSecondFormat)%> </td>
                    <td class="num" align="right"><%= Workflow.Util.NumericUtils.ToMoney(order.Sumamount)%></td>
                <%
              if (order != null)
              {
                 %>
                    <td><%= order.NewOrderName%></td>
                  <%}
                    else
                    { %>
                    <td></td>
              <%} %>
               <%
              if (order != null)
              {
              %>
                   <td ><%= order.CashName%></td>
            <%}
              else
              { %>
           <%-- <td nowrap></td>--%>
            <%} %>
                  <td><%= order.Memo%></td>
          </tr>
          <%}
        %>
          <tr>
               <td nowrap>合计</td>
               <td nowrap colspan="5" align="right"><%=Workflow.Util.NumericUtils.ToMoney(orderTotal)%></td>
               <td nowrap></td>
               <td nowrap></td> 
               <td nowrap></td>    
          </tr>
          <%} %>
           <tr>
               <td colspan="10" style="text-align:right">
               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                                </webdiyer:AspNetPager>
               </td>
          </tr>
        </table></td>
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
