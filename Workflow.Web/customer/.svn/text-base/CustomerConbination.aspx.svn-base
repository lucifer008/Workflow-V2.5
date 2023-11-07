<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerConbination.aspx.cs" Inherits="CustomerConbination" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title>合并客户</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
	<script type="text/javascript" src="../js/jquery.js"></script>
	<script type="text/javascript" src="../js/default.js"></script>
	<script type="text/javascript" src="../js/escExit.js"></script>
	<script type="text/javascript" src="../js/customer/customerConbination.js"></script>
	<base target="_self" />
</head>
<body style="text-align:center">
<form id="form1" runat="server">
<div align="center" style="width:99%; background-color:#FFFFFF;" id="container">
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif" /></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10" /></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
           <table  width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
        <tr>
			<td width="3%"></td>
			<td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;客户管理&nbsp;-&gt;&nbsp;合并客户</td>
			<td width="3%"></td>
		</tr>
		<tr>
		    <td colspan="3" class="caption" align="center">合并客户</td>
		</tr>
		<tr>
		    <td width="3%"></td>
		    <td align="center">
		     <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
              <tr>
                <td nowrap class="item_caption">客户编号</td>
                <td class="item_content" colspan="3">
                    <input class="texts" id="customerid" name="customerid" type="text" />&nbsp;
                    <input class="buttons" type="button" onclick="selectedCustomer();" value="选择" />
                    <asp:HiddenField ID="HiddenConbination" runat="server" />
                </td>
              </tr>
              <tr>
                <td nowrap class="item_caption">客户名称</td>
                <td class="item_content" colspan="3" id="customername"></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">所属行业</td>
                <td class="item_content" id="trade"></td>
                <td nowrap class="item_caption">客户级别</td>
                <td class="item_content"  id="customerlevel"></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">客户类型</td>
                <td class="item_content"  id="customertype"></td>
                <td nowrap class="item_caption">地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址</td>
                <td class="item_content" id="address"></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名</td>
                <td class="item_content" id="linkman"></td>
                <td nowrap class="item_caption">电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话</td>
                <td class="item_content" id="telno"></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">发&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;票</td>
                <td class="item_content" id="needticket"></td>
                <td nowrap class="item_caption">客户状态</td>
                <td class="item_content" id="validatestatus"></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">客户说明</td>
                <td colspan="4" class="item_content" id="memo"></td>
              </tr>
            </table> 
		    </td>
		    <td></td>
		</tr>
	    <tr>
	        <td width="3%">&nbsp;</td>
	        <td align="left" style="font-weight:bold;">要合并的客户</td>
	        <td></td>
	    </tr>
		<tr>
		    <td width="3%">&nbsp;</td>
		    <td align="center">
		        <table border="1" cellpadding="3" cellspacing="1" width="100%"	align="left">
          <tr>
            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
            <th nowrap>客户名称</th>
            <th width="1%" nowrap>所属行业</th>
            <th width="1%" nowrap>客户级别</th>
            <th width="1%" nowrap>客户类型</th>
            <th width="1%" nowrap>状态</th>
            <th width="1%" nowrap>联系人</th>
            <th nowrap>联系电话</th>
            <th nowrap>地址</th>
            <th width="20%" nowrap>备注</th>
          </tr>
          <%
              if (ConbinationId.Length != 0 && !ShowTag)
              {
                  for (int i = 1; i <= ConbinationId.Length; i++)
                  {
                      model.Id = Workflow.Util.NumericUtils.ToLong(ConbinationId[i - 1]);
                      action.SearchCustomerById();
               %>
          <tr class="detailRow">
            <td nowrap><%=  i%></td>
            <td nowrap align="left"><a href="#" onclick="customerDetail(<%= model.Customer.Id %>);"><%= model.Customer.Name%></a></td>
            <td nowrap align="center"><%= model.Customer.SecondaryTrade.Name%></td>
            <td nowrap><%= model.Customer.CustomerLevel.Name%></td>
            <td nowrap><%= model.Customer.CustomerType.Name%></td>
            <td nowrap>未确认</td>
            <td nowrap align="left"><%= model.Customer.LastLinkMan%></td>
            <td nowrap align="left"><%= model.Customer.LastTelNo%></td>
            <td nowrap align="left"><%= model.Customer.Address%></td>
            <td nowrap align="left"><%= model.Customer.Memo%></td>
          </tr>
           <%}
         } %>
          </table>
		    </td>
		    <td width="3%"></td>
		</tr>
		<tr class="emptyButtonsUpperRowHight"><td colspan="3">&nbsp;</td></tr>
		<tr>
        <td width="3%"></td>
        <td align="center" class="bottombuttons">
            <asp:Button ID="Conbination" Cssclass="buttons" runat="server" Text="合并" OnClick="ConbinationCustomer"  OnClientClick="return DataValidator();"/>&nbsp;&nbsp;
        <input type="button" class="buttons" onclick="returnConbination();" value="返回" /></td>
        <td width="3%"></td>
      </tr> 
      <tr height="5">
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
				<td bgcolor="#eeeeee" >&nbsp;</td>
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
			</tr>   
	 </table>
    </td>
	</tr>
	<tr>
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif" /></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" /></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif" /></td>
	</tr>
</table>
</div>
</form>
</body>
</html>
