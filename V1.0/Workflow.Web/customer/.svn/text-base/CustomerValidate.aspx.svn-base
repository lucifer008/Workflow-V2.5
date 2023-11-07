<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerValidate.aspx.cs" Inherits="CustomerValidate" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>客户确认</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../js/jquery.js"></script>
	<script type="text/javascript" src="../js/default.js"></script>
	<script type="text/javascript" src="../js/customer/customerValidate.js"></script>
</head>
<body style="text-align:center">
<form id="form1" runat="server" method="post">
<div align="center" background-color:#FFFFFF;" id="container">
<input id="deleteId" type="hidden" runat="server"/>
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
           <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
        <tr>
			<td width="3%"></td>
			<td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;客户管理&nbsp;-&gt;&nbsp;客户确认</td>
			<td width="3%"></td>
		</tr>
		<tr>
		    <td colspan="3" class="caption" align="center">客户确认</td>
		</tr>
	   <tr>
        <td width="3%">&nbsp;</td>
        <td align="center">
         <table border="1" cellpadding="3" cellspacing="1" width="100%"	align="left">
          <tr>
            <th nowrap>&nbsp;</th>
            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
            <th nowrap>客户名称</th>
            <th width="1%" nowrap>所属行业</th>
            <th width="1%" nowrap>客户级别</th>
            <th width="1%" nowrap>客户类型</th>
            <th width="1%" nowrap>状态</th>
            <th width="10%" nowrap >联系人</th>
            <th width="10%" nowrap>联系电话</th>
            <th width="20%" nowrap>地址</th>
            <th width="20%" nowrap>备注</th>
          </tr>
          <%
              for (int i = 1; i <= model.CustomerList.Count; i++)
              {
                  Workflow.Da.Domain.Customer customer = model.CustomerList[i - 1];
               %>
          <tr class="detailRow">
            <td nowrap><input id="cb<%=i %>" name="cbCutomer" value="<%= customer.Id%>" type="checkbox" /></td>
            <td nowrap><%= i%></td>
            <td nowrap align="left"><a href="#" onclick="showPage('CustomerDetail.aspx?Id=<%= customer.Id %>', null, 800, 550, false, true);"><%= customer.Name%></a></td>
            <%if (null != customer.SecondaryTrade){%>
            <td nowrap align="center"><%= customer.SecondaryTrade.Name%></td>
            <%}else{ %>
            <td nowrap align="center"></td>
            <%} %>
            <%if (null != customer.CustomerLevel){%>
            <td nowrap align="center"><%= customer.CustomerLevel.Name%></td>
            <%}else{ %>
            <td nowrap align="center"></td>
            <%} %>
            <%if (null != customer.CustomerType){ %>
            <td nowrap align="center"><%= customer.CustomerType.Name%></td>
            <%}else{ %>
            <td nowrap align="center"></td>
            <%} %>
            <td nowrap align="center">未确认</td>
            <td nowrap align="left"><%= customer.LastLinkMan%></td>
            <td nowrap align="left"><%= customer.LastTelNo%></td>
            <td nowrap align="left"><%= customer.Address%></td>
            <td nowrap align="left"><%= customer.Memo%></td>
            </tr>
          <%} %>   
          <tr>
            <td colspan="12" align="right">
                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                </webdiyer:AspNetPager>
            </td>
         </tr>
        </table></td>
        <td width="3%"></td>
        </tr>
        <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
        <tr>
        <td width="3%">&nbsp;</td>
        <td align="center" class="bottombuttons">
            <asp:Button ID="Conbination" Cssclass="buttons" runat="server" OnClick="ConbinationCustomer" OnClientClick="return dataValidateConbination();" Text="合并" />
            &nbsp;
            &nbsp;&nbsp;
            <asp:Button ID="Validate"  Cssclass="buttons" runat="server" Text="确认" OnClick="UpdateCustomerValidate" OnClientClick="return dataValidate();" />    
            </td>
        <td width="3%">&nbsp;</td>
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
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
	</tr>
</table>
</div>
</form>
</body>
</html>
