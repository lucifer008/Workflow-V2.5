<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchMemberCard.aspx.cs" Inherits="SearchMemberCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>会员详情查询</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../css/calendar-blue.css" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/membercard/searchMembercardDetail.js"></script>
</head>

<body style="text-align:center">
<div align="center" style="width:99%; background-color:#FFFFFF;" id="container">
<form id="form1" runat="server">
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
         <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;会员查询&nbsp;-&gt;&nbsp;会员详情查询</td>
         <td width="3%"></td>
      </tr>
      <tr>
        <td colspan="3" class="caption" align="center">会员详情查询</td>
      </tr>
      <tr>
        <td width="3%"></td>
        <td align="center">
        <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
          <tr>
             <td nowrap class="item_caption">会员卡号</td>
             <td class="item_content" colspan="3"><input class="texts" type="text" name="txtMemberCardNo" id="txtMemberCardNo"/>
                 <asp:Button ID="Search"  Cssclass="buttons" runat="server" Text="检索"  OnClientClick="return dataValidator();" OnClick="SearchMemberCardInfo"/></td>
          </tr>
          <% if(DataShowTag && model.MemberCard != null) {%>
          <tr>
            <td nowrap class="item_caption">会员卡号</td>
            <td class="item_content" colspan="3"><%= model.MemberCard.MemberCardNo %></td>
          </tr>
          <tr>
            <td nowrap class="item_caption">级&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别</td>
            <td class="item_content"><%= model.MemberCard.MemberCardLevel.Name %></td>
            <td nowrap class="item_caption">客户名称</td>
            <td class="item_content"><%= model.Customer.Name %></td>
          </tr>
          <tr>
            <td nowrap class="item_caption">会籍起始日</td>
            <td class="item_content"><%= model.MemberCard.MemberCardBeginDate.ToString("yyyy-MM-dd") %></td>
            <td nowrap class="item_caption">卡&nbsp;状&nbsp;态</td>
                <% if(model.MemberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_KEY){ %>
            <td class="item_content"><%= Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_TEXT %></td>
            <%} else if (model.MemberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_LOGOUT_KEY){ %>
            <td class="item_content"><%= Workflow.Support.Constants.MEMBER_CARD_STATE_LOGOUT_TEXT %></td>
            <%} else {%>
            <td class="item_content"><%= Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_TEXT %></td>
            <%} %>
          </tr>
          <tr>
            <td nowrap class="item_caption">需要发票</td>
                <% if(model.MemberCard.NeedTicket == Workflow.Support.Constants.NEED_TICKET_KEY) { %>
            <td class="item_content" colspan="3"><%= Workflow.Support.Constants.NEED_TICKET_TEXT %></td>
            <%} else{ %>
            <td class="item_content" colspan="3"><%= Workflow.Support.Constants.NEED_TICKET_NOT_TEXT %></td>
            <%} %>
          </tr>
          <tr>
            <td nowrap class="item_caption">刷卡次数</td>
            <td class="item_content" colspan="3"><%= orderModel.MemberCardBrushNumber %></td>
          </tr>
          <tr>
            <td nowrap class="item_caption">消费总额</td>
            <td class="item_content"><%= model.MemberCard.ConsumeAmount %></td>
            <td nowrap class="item_caption">积&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;分</td>
            <td class="item_content"><%= model.MemberCard.Integral %></td>
          </tr>
        </table></td>
        <td width="3%"></td>
      </tr>
      <tr>
        <td width="3%"></td>
        <td align="left">参与的活动</td>
        <td width="3%"></td>
      </tr>
      <tr>
        <td width="3%"></td>
        <td align="left">
        <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
          <tr>
            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
            <th width="10%" nowrap>活动名称</th>
            <th width="15%" nowrap>优惠方案</th>
            <th width="10%" nowrap>参与时间</th>
            <th width="1%" nowrap>剩余印张数</th>
            <th width="15%" nowrap> 说明</th>
          </tr>
          <% for(int i = 1; i <= model.MemberCard.MemberCardConcessionList.Count; i++) 
             {
                 Workflow.Da.Domain.Concession concession = model.MemberCard.MemberCardConcessionList[i - 1].Concession;
                 %>
          <tr class="detailRow">
            <td align="center"><%= i%></td>
            <td align="left"><%= Campaigns[i - 1] %></td>
            <td align="left"><%= concession.Name %></td>
            <td align="center"><%= model.MemberCard.MemberCardConcessionList[i - 1].JoinDateTime.ToString("yyyy-MM-dd") %></td>
            <td align="right"><%= model.MemberCard.MemberCardConcessionList[i - 1].RestPaperCount %></td>
            <td ><%= concession.Memo %></td>
          </tr>
          <%} %>
        </table></td>
        <td width="3%"></td>
      </tr>
      <%} %>
      <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
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
</form>
</div>
</body>
</html>
