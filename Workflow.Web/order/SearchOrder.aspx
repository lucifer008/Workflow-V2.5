<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchOrder.aspx.cs" Inherits="SearchOrder" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/usercontrols/DateNavigate.ascx" TagName="DateNavigate" TagPrefix="dn" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>订单查询</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<link href="../css/DateNavigate.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/order/searchOrder.js"></script>
<script type="text/javascript" language="javascript">
var isPrint='<%=isPrint %>';
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
<input id="hidDate" name="date" type="hidden" value="999" runat="server"/>
<input id="actionTag" name="actionTag" type="hidden" value="F" runat="server"/>
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
		 <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;订单管理&nbsp;-&gt;&nbsp;订单查询</td>
		 <td width="3%"></td>
      </tr>
	  <tr><td colspan="3" class="caption" align="center">订单查询</td></tr>
	  <tr><td width="3%">&nbsp;</td>
	      <td align="center">
			<table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                <tr>
                  <td nowrap class="item_caption">订单号</td>
                  <td class="item_content"><input type="text" id="OrderNo" runat="server" class="texts"/></td>
                  <td nowrap class="item_caption"> 开单时间段</td>
                  <td class="item_content">
                  <div>
					    <input type="text" class="datetimetexts" id="txtFrom" runat="server" onfocus="setday(this);" name="txtFrom" readonly="readonly" size="16"/>&nbsp;&nbsp;至&nbsp;&nbsp;
					    <input type="text" class="datetimetexts" id="txtTo" runat="server" onfocus="setday(this);"  name="txtTo" readonly="readonly" size="16"/>
		    		</div>
				   </td>
                </tr>
                <tr>
                  <td nowrap class="item_caption">会员卡号</td>
                  <td class="item_content"><input type="text" id="MemberCardNo" runat="server" class="texts"/></td>
                  <td nowrap class="item_caption"> 金额</td>
                  <td class="item_content" colspan="3">
                         <select name="SelectCondition" id="SelectCondition" runat="server" class="biaodan"/>                                                             
                        <input type="text" class="num" id="Money"  runat="server" size="16"/>
                 </td>
                </tr>
                <tr>
                    <td nowrap class="item_caption"> 客户名称</td>
                    <td class="item_content"><input type="text" id="CustomerName" runat="server" class="texts"/> &nbsp;</td>
                    <td class="item_caption">手机</td><td class="item_content"><input type="text" id="txtMobile" runat="server" class="texts"/></td>
                </tr>
                <tr>
                    <td nowrap class="item_caption">Email</td>
                    <td class="item_content"><input type="text" id="txtEmail" runat="server" class="texts"/> &nbsp;</td>
                    <td class="item_caption">QQ(MSN)</td><td class="item_content"><input type="text" id="txtQQMSN" runat="server" class="texts"/></td>
                </tr>
                <tr>
                    <td class="item_caption">身份证号</td>
                    <td class="item_content" colspan="3"><input type="text" id="txtIdentityNo" runat="server" class="texts"/></td>
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
	    <td width="3%"></td>
	    <td><dn:DateNavigate ID="dNavigate"  runat="server"/></td>
	    <td width="3%"></td>
	  </tr>
      <tr>
	    <td width="3%">&nbsp;</td>
        <td align="center">
		    <table  border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
           <tr>
                <th width="1%" nowrap>NO</th>
                <th width="10%" nowrap>订单号</th>
                <th width="20%"nowrap>客户名称</th>
                <th width="10%" nowrap>开单时间</th>
                <th width="10%" nowrap>结算时间</th>
                <th width="10%" nowrap>消费金额</th>
                <th width="5%" nowrap>开单人</th>
                <th width="5%" nowrap>收银</th>
                <th width="5%"nowrap>备注</th>
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
                    <td align="center"><a href="#" onclick="showPage('OrderDetail.aspx?OrderNo=<%= order.No %>', null, 1000, 700, false, true);"><%= order.No%></a></td>
                    <td align="left"><%= order.Name%></td>
                    <td align="center"><%=Workflow.Util.DateUtils.ToFormatDateTime(order.InsertDateTime, Workflow.Util.DateTimeFormatEnum.DateTimeNoSecondFormat)%> </td>
                    <td align="center"><%= Workflow.Util.DateUtils.ToFormatDateTime(order.BalanceDateTime, Workflow.Util.DateTimeFormatEnum.DateTimeNoSecondFormat)%> </td>
                    <td align="right"><%= Workflow.Util.NumericUtils.ToMoney(order.Sumamount)%></td>
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
               <td colspan="9" align="right">
               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" onclick="pagerCheck();">
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
