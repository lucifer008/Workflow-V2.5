<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrepayHandler.aspx.cs" Inherits="PrepayHandler" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>预收款处理</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/finance/prepayHandler.js"></script>
<script language="javascript" type="text/javascript">
var limitType="";
<%
    if (Workflow.Support.Constants.PREPAY_CAN_OVER == limitValue)
    {
%>
    limitType="Y";
<%
    }
    else
    { 
    %>
        limitType="N";
    <%
     }
    %>
</script>
</head>
<body  style="text-align:center">
<form id="form1" action="" method="post" runat="server">
<div align="center" style="width:99%" bgcolor="#ffffff" id="container">
  <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
      <td width="12"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0"/></td>
      <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10"/></td>
      <td width="12"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
    </tr>
    <tr>
      <td colspan="3" bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td></td>
            <td align="left" bgcolor="#eeeeee">首页 -&gt; 财务处理 -&gt; 预收款处理</td>
            <td></td>
          </tr>
          <tr><td colspan="3" class="caption" align="center"> 预收款处理</td></tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">
               <table width="100%" border="1" cellpadding="2" cellspacing="1">
                   <tr>
                      <td nowrap="nowrap" class="item_caption">工单号:</td>
                      <td class="item_content"><input id="strOrderNo" name="txtOrderNo" class="texts" type="text" onfocus="GetFoucus(this)" value="<%=lastShowOrderNo %>" />  
                      </td>
                   </tr>
                   <tr>
                      <td nowrap="nowrap" class="item_caption">开单时间</td>
                      <td class="item_content">
                         <input type="text" name="beginDateTime" id="txtBeginDateTime" class="datetexts"  onfocus="setday(this)" size="16" readonly="readonly"/>&nbsp; 至&nbsp;
                         <input type="text" name="endDateTime" id="txtEndDateTime" class="datetexts"  onfocus="setday(this)" size="16" readonly="readonly"/> 
                      </td>
                   </tr>
                   <tr>
                      <td colspan="3" align="right"><asp:Button ID="btnSearch" runat="server" CssClass="buttons" OnClick="SearchOrder" Text="检索" OnClientClick="return DataValidate();" /></td>
                   </tr>
               </table>
           </td>
		<td width="3%"></td>
		</tr>		  
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">
			    <table width="100%" border="1" cellpadding="2" cellspacing="1">
			        <%
                      string OrdersNo = "";
                      string CustomerName = "";      
                      string PrepareMoneyAmount = "";
                      if (fModel.Orders != null)
                        OrdersNo = fModel.Orders.No;
                      if (fModel.Orders != null)
                        CustomerName = fModel.Orders.CustomerName ;
                      if (fModel.Orders != null)
                        PrepareMoneyAmount = (fModel.Orders.PrepareMoneyAmount - fModel.Orders.HasPrePaidMoney).ToString();
                   %>
					      <tr>
						    <td nowrap class="item_caption">工单号:</td>
						    <td width="13%" class="item_content"><span id="labNo" > <a href="#" onclick="orderDetail('<%=OrdersNo %>')"><%=OrdersNo%></a></span></td>
						    
						    <td nowrap class="item_caption">客户名称:</td>
						    <td width="68%" class="item_content"><span id="CustomerName" ><%=CustomerName%></span></td>
					      </tr>					
					      <tr>
						    <td nowrap class="item_caption">收款额:</td>
						    <td colspan="3" class="item_content"><input type="text" id="PrepayMoney" name="PrepayMoney" onfocus="GetFoucus(this)" class="num"  value="" /></td>
					      </tr>
				</table>
			 </td>
		   </tr>
		   <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
			<tr>
			    <td width="3%">&nbsp;</td>
               <td align="center" class="bottombuttons">
                  <asp:Button ID="btnSave" runat="server" OnClick="Save"  OnClientClick="return dataCheck();" CssClass="buttons" text="保存" />
			    </td>
		        <td width="3%"></td>
		    </tr>		
		<tr>
            <td width="3%">&nbsp;</td>
            <td align="center" >
                <table id="tbList" width="100%" border="1" cellpadding="2" cellspacing="1">
                  <tr>
                    <th width="5%" nowrap align="left">NO</th>
                    <th width="15%" nowrap align="center">工单号</th>
                    <th width="15%" nowrap align="center">客户名称</th>
                    <th width="10%" nowrap align="center">开单时间</th>
                    <th width="10%" nowrap align="center">订单总金额</th>
                    <th width="10%" nowrap align="center">预付总计</th>
                  </tr>
                      <%
                        decimal sumAmountTotal=0,prepareMoneyAmountTotal=0;  
                        if (oModel.OrderList != null)
                        {
                          for (int i = 0; i < oModel.OrderList.Count; i++)
                          {
                              if (oModel.OrderList[i] != null)
                              {
                                  sumAmountTotal += oModel.OrderList[i].SumAmount;
                                  prepareMoneyAmountTotal += oModel.OrderList[i].PrepareMoneyAmount;
                      %>
                     <tr class='detailRow'>
                          <td><%=(i + 1)%></td>
                          <td>
                              <a href="#" onclick="orderDetail(this)"><%=oModel.OrderList[i].No%></a>
                              <input type="hidden" name="myOrderNo" value="<%=oModel.OrderList[i].No %>" />
                              <label>|</label>
                              <a href ="#" onclick="setSearchNo(this)" title="<%=oModel.OrderList[i].No %>">收款</a>
                          </td>
                          <td><%=oModel.OrderList[i].CustomerName%></td>
                          <td><%=oModel.OrderList[i].InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                          <td><%=Workflow.Util.NumericUtils.ToMoney(oModel.OrderList[i].SumAmount)%></td>
                          <td><%=Workflow.Util.NumericUtils.ToMoney(oModel.OrderList[i].PrepareMoneyAmount)%></td>       
                        </tr>              
                      <%
                               }
                            }%>
                            <tr class='detailRow'>
                             <td>当页合计</td>
                             <td></td>
                             <td></td> 
                             <td></td>    
                             <td><%=Workflow.Util.NumericUtils.ToMoney(sumAmountTotal)%></td>
                             <td><%=Workflow.Util.NumericUtils.ToMoney(prepareMoneyAmountTotal)%></td>    
                            </tr>
                            <tr class='detailRow'>
                             <td>总合计</td>
                             <td></td>
                             <td></td> 
                             <td></td>    
                             <td><%=Workflow.Util.NumericUtils.ToMoney(oModel.NewOrder.SumAmount)%></td>
                             <td><%=Workflow.Util.NumericUtils.ToMoney(oModel.NewOrder.PrepareMoneyAmount)%></td>    
                            </tr>
                            <tr class='detailRow'>
                                <td  style="text-align:right" colspan="7">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                       <%  }
                       %>
                  </table>	
                </td>
		        <td width="3%"></td>
		</tr>
       <tr>
          <td width="3%"></td>
          <td></td>
          <td width="3%"></td>
       </tr>
		<tr>
            <td width="3%">&nbsp;</td>
            <td align="right" >&nbsp;</td>
		     <td width="3%"></td>
		</tr>
		<tr height="5">
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
            <td bgcolor="#eeeeee">&nbsp;</td>
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
          </tr>
	</table>
	</td>
	</tr>
    <tr>
      <td width="12"><img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11"/></td>
      <td bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10"/></td>
      <td width="12"><img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11"/></td>
    </tr>
  </table>
</div>
</form>
</body>
</html>
