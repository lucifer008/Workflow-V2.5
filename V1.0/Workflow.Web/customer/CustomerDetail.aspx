<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerDetail.aspx.cs" Inherits="CustomerDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>客户详细资料</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/escExit.js"></script>
</head>

<body style="text-align:center">
<div align="center" style="width:100%; background-color:#FFFFFF;"  id="container">
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
	</tr>
  <tr>
    <td colspan="3" bgcolor="#FFFFFF">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>       
         <td width="3%"></td>
         <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;客户管理&nbsp;-&gt;&nbsp;客户详细资料</td>
         <td width="3%"></td>
      </tr>
      <tr>
        <td colspan="3" class="caption">客户详细资料</td>
      </tr>
      <tr>
        <td width="3%"></td>
        <td align="left">客户编号:<%= model.Customer.Id %></td>
        <td width="3%"></td>
      </tr>
      <tr>
        <td width="3%"></td>
        <td align="center">
           <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
              
              <tr>
                <td nowrap class="item_caption">客户名称</td>
                <td class="item_content"><%= model.Customer.Name%></td>
                <td nowrap class="item_caption">简&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;拼</td>
                <td class="item_content"><%= model.Customer.SimpleName%></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">所属行业</td>
                <td class="item_content"><%= model.Customer.SecondaryTrade.Name%></td>
                <td nowrap class="item_caption">客户级别</td>
                <td class="item_content"><%= model.Customer.CustomerLevel.Name %></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">客户类型</td>
                <td class="item_content" style="background-color: #ffffff"><%= model.Customer.CustomerType.Name%></td>
                <td nowrap class="item_caption">客户状态</td>
                    <%if (model.Customer.ValidateStatus == Workflow.Support.Constants.CUSTOMER_VALIDATE_STATUS_KEY)
                      { %>
                <td class="item_content" style="background-color: #ffffff"><%= Workflow.Support.Constants.CUSTOMER_VALIDATE_STATUS_TEXT %></td>
                <%}
                  else
                  {  %><td class="item_content" style="background-color: #ffffff"><%= Workflow.Support.Constants.CUSTOMER_NOT_VALIDATE_STATUS_TEXT %></td>
                  <%} %>
              </tr>
              <tr style="background-color: #ffffff">
                <td nowrap class="item_caption">发&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;票</td>
                <%if (model.Customer.NeedTicket == Workflow.Support.Constants.NEED_TICKET_KEY)
                  { %>
                <td class="item_content"> <%= Workflow.Support.Constants.NEED_TICKET_TEXT %></td>
                <%}
                  else
                  { %>
                <td class="item_content"><%= Workflow.Support.Constants.NEED_TICKET_NOT_TEXT %></td>
                <%} %>
                <td nowrap class="item_caption">地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址</td>
                <td class="item_content"> &nbsp;<%= model.Customer.Address %></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">客户说明</td>
                <td colspan="4" class="item_content"><%= model.Customer.Memo %></td>
              </tr>
            </table></td>
           <td width="3%"></td>
      </tr>
      <tr>
        <td width="3%"></td>
        <td align="center">
         <table border="1" cellpadding="3" cellspacing="1" width="100%"	align="left">
          <tr>
            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
            <th width="5%" nowrap>联系人</th>
            <th width="10%" nowrap>单位电话</th>
            <th width="15%" nowrap>地址</th>
            <th width="15%" nowrap>EMAIL</th>
            <th width="10%" nowrap>手机</th>
            <th width="10%" nowrap>QQ号</th>
            <th width="10%" nowrap>备注</th>
          </tr>
          <%
              if (model.Customer.LinkManList.Count != 0)
              {
                  for (int i = 1; i <= model.Customer.LinkManList.Count; i++)
                  {
                      Workflow.Da.Domain.LinkMan linkMan = model.Customer.LinkManList[i - 1];
               %>
          <tr class="detailRow"> 
            <td nowrap align="center"><%= i%></td>
            <td nowrap align="left"><%= linkMan.Name%></td>
            <td nowrap align="left"><%= linkMan.CompanyTelNo%></td>
            <td nowrap align="left"><%= linkMan.Address%></td>
            <td nowrap align="left"><%= linkMan.Email%></td>
            <td nowrap class="tel"><%= linkMan.MobileNo%></td>
            <td nowrap align="center"><%= linkMan.Qq%></td>
            <td nowrap align="left"><%= linkMan.Memo%></td>
          </tr>
          <%}
        } %>
        </table></td>
        <td width="3%"></td>
        </tr>
        <tr class="emptyButtonsUpperRowHight">
		  <td colspan="3"></td>
			</tr>
        <tr height="5">
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
			</tr>
      </table></td>
  </tr>
	<tr>
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif"></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif"></td>
	</tr>
</table>
</div>
</body>
</html>
