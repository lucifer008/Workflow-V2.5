<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewMemberCard.aspx.cs" Inherits="NewMemberCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title><%=strTitle %></title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/membercard/membercard.js"></script>
<script language="javascript" type="text/javascript">
    var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
    var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
    var accreditTypeKey='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_NEW_MEMBERCARD_KEY %>';
    var accreditTypeText='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_NEW_MEMBERCARD_TEXT %>';
    var accreditTypeId=<%=Workflow.Support.Constants.GET_USER_OPERATE_ACCREDIT_OWE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;//挂账授权Id
    var payType=<%=Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE %>;
</script>
<base target="_self" />
<style type="text/css">
<!--
.STYLE1 {color: #FF0000}
-->
</style>
</head>
<body style="text-align:center"  onload="tradeAttribute(<%=model.Id %>);">
<form id="form1" runat="server">
<div align="center" width="99%" background-color:#FFFFFF;" id="container">
<input id="hiddOperateTag" name="hiddOperateTag" type="hidden" runat="server" value="Add"/>
<input id="hiddMemberCardId" name="hiddMemberCardId" type="hidden" runat="server" />
<input id="hiddConsumeAmount" name="hiddConsumeAmount" type="hidden" runat="server" />
<input id="hiddIntegral" name="hiddIntegral" type="hidden" runat="server" />
<input id="hiddMemberState" name="hiddMemberState" type="hidden" runat="server" />
<input id="hiddCustomerValidateStatus" name="hiddCustomerValidateStatus" type="hidden" runat="server" />
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
         <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;卡管理&nbsp;-&gt;&nbsp;<%=strTitle %></td>
         <td width="3%"></td>        
      </tr>
      <tr><td colspan="3" class="caption" align="center"><%=strTitle %></td></tr>
      <tr>
        <td width="3%">&nbsp;</td>
        <td align="center">
         <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
              <tr>
                <td nowrap class="item_caption">客 户 名 称<span class="STYLE1">*</span></td>
                <td class="item_content" colspan="4">
                    <input type="text" id ="customerName" name="customerName" value="<%=model.MemberCard.CustomerName %>" readonly="readOnly"/>
                    <input type="button" class="buttons" onclick="OpenCustomer();" value="选 择客户" id="Button1" name="Button1" />
                    <input type="hidden" id="customerId"  runat="server" />
                </td>
              </tr>
              <tr>
                <td nowrap class="item_caption">所 属 行 业<span class="STYLE1">*</span></td>
                <td class="item_content">
                        <asp:DropDownList ID="trade"  runat="server" AppendDataBoundItems="True"><asp:ListItem Value="-1">请选择</asp:ListItem>
                        </asp:DropDownList>
                </td>
                <td class="item_caption">客 户 类 型</td>
                <td class="item_content">
                      <asp:DropDownList ID="dropListCustomerType"  runat="server" AppendDataBoundItems="True">
                     <asp:ListItem Value="-1">请选择</asp:ListItem> 
                      </asp:DropDownList>
                </td>
              </tr>
              <tr>
                <td nowrap class="item_caption">通 讯 地 址</td>
                <td class="item_content"><input type="text" id="address" name="address" value="<%=model.MemberCard.CustomerAddress %>" /></td>
                <td nowrap class="item_caption">简 &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; 拼</td>
                <td colspan="2" class="item_content"><input type="text" id="Text1" name="simpleName" value="<%=model.MemberCard.CustomerNameSimple %>" /></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">持&nbsp;&nbsp;&nbsp;卡&nbsp;&nbsp;&nbsp;人<span class="STYLE1">*</span></td>
                <td class="item_content"><input type="text" id="linkMan" name="linkMan"  value="<%=model.MemberCard.LastLinkMan %>"/></td>
                <td nowrap class="item_caption">单 位 电 话</td>
                <td colspan="2" class="item_content"><input type="text" id="telNo" name="telNo" onblur="CheckFastnessTelephone(telNo);" value="<%=model.MemberCard.LastTelNo %>"/></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">身 份 证 号<span class="STYLE1">*</span></td>
                <td class="item_content"><input type="text" id="identityCard" name="identityCard" maxlength="18" value="<%=model.MemberCard.IdentityCardNo %>"/><input type="checkbox" id="cbCredentials" runat="server" /><label id="lblCredentials" onclick="return selectLabelChange();" style="color:red">其他证件</label></td>
                <td nowrap class="item_caption">性 &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 别</td>
                <td colspan="2" class="item_content">
                    <asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" Width="156px">
                        <asp:ListItem Value="0" Selected="True">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">年 &nbsp; &nbsp; &nbsp; &nbsp; 龄</td>
                <td class="item_content"><input type="text" id="age" name="age" maxlength="2" value="<%=strAge%>"/></td>
                <td nowrap class="item_caption">职 &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;务</td>
                <td colspan="2" class="item_content"><input type="text" id="position" name="position" value="<%=model.MemberCard.Position %>""/></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">手 &nbsp; &nbsp; &nbsp; &nbsp; 机</td>
                <td class="item_content"><input type="text" id="mobileNo" name="mobileNo" onblur="CheckMobileNo(mobileNo);" value="<%=model.MemberCard.MobileNo %>"/></td>
                <td nowrap class="item_caption">爱 &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 好</td>
                <td colspan="2" class="item_content"><input type="text" id="hobby" name="hobby" value="<%=model.MemberCard.Hobby %>"/></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">会籍起始日<span class="STYLE1">*</span></td>
                <td class="item_content"><div><input class="datetexts" readonly="readonly" id="txtFrom" name="txtFrom" type="text" maxlength="10" onfocus="setday(this);" value="<%=model.MemberCard.MemberCardBeginDateString %>"/>&nbsp;</div></td>
                <td nowrap class="item_caption">会籍到期日<span class="STYLE1">*</span></td>
                <td colspan="2" class="item_content">
                  <div><input class="datetexts" readonly="readonly" id="txtTo" name="txtTo" type="text" maxlength="10" onfocus="setday(this);" value="<%=model.MemberCard.MemberCardEndDateString %>"/>&nbsp;&nbsp;</div>         
                </td>
              </tr>
              <tr>
                <td nowrap class="item_caption">发 &nbsp; &nbsp; &nbsp;&nbsp; 票</td>
                <td class="item_content"><asp:CheckBox ID="needTicket" runat="server" Text="需要"/></td>
                <td nowrap class="item_caption">EMAIL</td>
                <td class="item_content"><input type="text" id="email" name="email" onblur="CheckEmail(email);" value="<%=model.MemberCard.Email %>" /></td>
              </tr>
            <tr>
                <td nowrap class="item_caption">支 付 方 式</td>
                <td class="item_content"><select name="sltPayType" id="cbPaymentType" onchange="arrear();" runat="server"></select></td>
              </tr> 
              <tr>
                  <td nowrap class="item_caption">客 户 说 明</td>
                  <td colspan="4" class="item_content"><asp:TextBox ID="memo" runat="server" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
              </tr>
            </table>	
		</td>
		<td width="3%"></td>
      </tr> 
      <tr>
        <td width="3%">&nbsp;</td>
        <td align="center">
         <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
          <tr>
            <td nowrap class="item_caption">卡 &nbsp; &nbsp; &nbsp; &nbsp; 号<span class="STYLE1">*</span></td>
            <td class="item_content"><input type="text" id="memberCardNo" name="memberCardNo" onchange="doProcess()" value="<%=model.MemberCard.MemberCardNo %>" /></td>
          </tr>
          <tr>
            <td nowrap class="item_caption">级 &nbsp; &nbsp; &nbsp; &nbsp; 别<span class="STYLE1">*</span></td>
            <td class="item_content">
                <asp:DropDownList ID="memberCardLevel" runat="server" AppendDataBoundItems="True">
                  <asp:ListItem Value="-1">请选择</asp:ListItem>
                </asp:DropDownList>
            </td>
          </tr>
           <tr>
            <td nowrap class="item_caption">客 户 级 别<span class="STYLE1">*</span></td>
            <td class="item_content">
                <asp:DropDownList ID="customerLevel" runat="server" AppendDataBoundItems="True">
                  <asp:ListItem Value="-1">请选择</asp:ListItem>
                </asp:DropDownList>
            </td>
          </tr>
        </table></td>
        <td width="3%"></td>
      </tr>
      <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
      <tr>
        <td>&nbsp;</td>
        <td align="left" class="bottombuttons">
            <asp:Button ID="newCard" CssClass="buttons" runat="server" Text="保存" OnClick="insertNewMemberCard" OnClientClick="return dataValidateNewMemberCard();" />
            &nbsp;&nbsp;&nbsp;<input id="btnClose" name="btnClose" type="button" class="buttons" value="关闭" onclick="window.close();" style="display:none" />
        </td>
        <td></td>
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
</form>
</body>
</html>
