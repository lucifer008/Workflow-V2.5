<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RepairMemberCard.aspx.cs"  Inherits="RepairMemberCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>补卡</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/membercard/repairmembercard.js"></script>
<script language="javascript" type="text/javascript">
document.onkeydown=function()
{	
	var evt=window.event || arguments[0];
	var element=evt.srcElement || evt.target;
	<%if(reportLessTag) {%> 
		if((evt.keyCode == 13) && (
			element.id == "newMemberCardNo"
		 ))
		{
			//var btnLoss = document.getElementById("insert"); 
			//btnLoss.click();
			if(evt.keyCode==27) winClose();  
			return false;
		}
		
    <% } else{%>
	if((evt.keyCode == 13) && (element.id =="identityCardNo"))
	{
		var btnLoss = document.getElementById("search"); 
		btnLoss.click();
		if(evt.keyCode==27) winClose();  
		return false;
	}
	<% }%>
	return true;
}
function CheckMemberCardNo()
{
    if(event.keyCode==13)
    {
       doMemberCardNO();
    }
}
</script>
<style type="text/css">
<!--
.STYLE1 {color: #FF0000}
-->
</style>
</head>
<body style="text-align: center">
<form id="form1" runat="server">
    <input name="checkTag" id="checkTag" type="hidden" value="F" />
    <input name="OldMemberCardId" runat="server" id="OldMemberCardId" type="hidden" />
    <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
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
                            <td width="3%">&nbsp;</td>
                            <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;卡管理&nbsp;-&gt;&nbsp;补卡</td>
                            <td width="3%"></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption" align="center">补卡</td>
                        </tr>
                        <tr>
                            <td></td>
                            <td align="center">
                                <table width="100%" border="1" cellspacing="1" cellpadding="2">
                                     <tr>
                                        <td nowrap class="item_caption" align="center">卡&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号</td>
                                        <td class="item_content"><input type="text" id="txtMemberCardNo" name="memberCardNo" runat="server" /></td>
                                     </tr>
                                    <tr>
                                        <td nowrap class="item_caption">身 份 证 号<span class="STYLE1">*</span></td>
                                        <td class="item_content" colspan="3">
                                            <asp:TextBox ID="identityCardNo" runat="server" MaxLength="18"></asp:TextBox>&nbsp;
                                            <asp:Button ID="search" runat="server" CssClass="buttons" Text="检索" OnClick="SearchMemberCardInfo" OnClientClick="return dataValidateSearchRepair();" /></td>
                                    </tr>
                                </table>
                            </td>
                            <td></td>
                        </tr>
                        <%
                            if (searchTag)
                            {
                        %>
                        <tr>
                            <td width="3%"></td>
                            <td align="left">
                                <table width="30%" border="1" cellspacing="1" cellpadding="2">
                                    <tr>
                                        <th width="1%" nowrap align="center">&nbsp;N O&nbsp;</th>
                                        <th width="1%" nowrap align="center">&nbsp;卡 号&nbsp;</th>
                                        <th width="1%" nowrap align="center">客户名称</th>
                                        <th width="1%" nowrap align="center"> &nbsp;卡状态&nbsp;</th>
                                        <th width="1%" nowrap align="center"> &nbsp;</th>
                                    </tr>
                                    <%
                                        if (model.MemberCardList.Count != 0)
                                        {
                                            for (int i = 1; i <= model.MemberCardList.Count; i++)
                                            {
                                                Workflow.Da.Domain.MemberCard memberCard = model.MemberCardList[i - 1];             
                                    %>
                                    <tr class="row<%= memberCard.Id%>">
                                        <td align="center"><%= i%></td>
                                        <td align="center"><%= memberCard.MemberCardNo %></td>
                                        <td align="center"><%= memberCard.CustomerName %></td>
                                        <%
                                            if (memberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_KEY)
                                            {
                                        %>
                                               <td align="center"><%= Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_TEXT %></td>
                                        <%}
                                          else if (memberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_KEY)
                                          { %>
                                               <td align="center"><%= Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_TEXT %></td>
                                        <%} %>
                                        <td align="center">
                                            <a href="#" onclick='selectId(<%= memberCard.Id%>)'>选择</a></td>
                                    </tr>
                                    <%}
                                  } %>
                                </table>
                            </td>
                            <td width="3%">
                            </td>
                        </tr>
                        <%} %>
                        <%
                            if (reportLessTag)
                            {
                        %>
                        <tr>
                            <td width="3%"> &nbsp;</td>
                            <td align="center">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                    <tr onload="selectMemberCardNo()">
                                        <td nowrap class="item_caption">原 &nbsp; 卡 &nbsp; &nbsp; 号</td>
                                        <td class="item_content" id="oldMemberCard"><%= model.MemberCard.MemberCardNo %><input type="hidden" id="memberCardNo" name="MemberCardNo" value="<%= model.MemberCard.MemberCardNo %>"/>
                                        <input type="hidden" id="hiddenCustomerId" name="hiddenCustomerId" value="<%=model.MemberCard.CustomerId %>" /></td>
                                    </tr>
                                    <tr>
                                        <td nowrap class="item_caption">新 &nbsp; 卡 &nbsp;&nbsp; 号<span class="STYLE1">*</span></td>
                                        <td class="item_content"><input type="text" id="newMemberCardNo" name="NewMemberCardNo" runat="server" onblur="doMemberCardNO()" onkeydown="CheckMemberCardNo()"/></td>
                                    </tr>
                                </table>
                            </td>
                            <td></td>
                        </tr>
                        <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                        <tr>
                            <td width="3%"> &nbsp;</td>
                            <td align="center" class="bottombuttons">
                                <asp:Button ID="insert" class="buttons" runat="server" Text="确定" OnClick="InsertLogoffMemberCard" OnClientClick="return dataValidateRepairCard();"/>
                            </td>
                            <td></td>
                        </tr>
                        <%} %>
                        <tr height="5">
                            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            <td bgcolor="#eeeeee"> &nbsp;</td>
                            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                        </tr>
                    </table>
                </td>
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
