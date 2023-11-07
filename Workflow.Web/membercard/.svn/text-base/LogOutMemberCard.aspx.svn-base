<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogOutMemberCard.aspx.cs"  Inherits="LogOutMemberCard" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>注销</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/membercard/logoutmembercard.js"></script>
<script language="javascript" type="text/javascript"> 	      
function winClose()
{
	window.top.opener=null;
	window.close();
}
document.onkeydown=function()
{	
	var evt=window.event || arguments[0];
	var element=evt.srcElement || evt.target;
	<%if(SearchTag) {%> 
		if((evt.keyCode == 13) && (
			element.id=="passWordAfftirm" ||
			element.id == "logoffMan"||
			element.id == "txtFrom" ||
			element.id == "memo"
		 ))
		{
			var btnLoss = document.getElementById("insert"); 
			btnLoss.click();
			if(evt.keyCode==27) winClose();  
			return false;
		} 
		else if((evt.keyCode == 13) && element.id == "passWord")
		{
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
</script>
 <style type="text/css">
<!--
.STYLE1 {color: #FF0000}
-->
</style>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <input name="checkTag" id="checkTag" type="hidden" value="F" />
            <input name="searchTag" id="searchTag" type="hidden" />
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr><td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                    <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr><td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;卡管理&nbsp;-&gt;&nbsp;注销</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">注销</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table width="100%" border="1" cellspacing="1" cellpadding="2">
                                        <tr>
                                             <td nowrap class="item_caption" align="center">卡&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;号</td>
                                             <td class="item_content"><input type="text" id="txtMemberCardNo" name="memberCardNo" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">身&nbsp;份&nbsp;证&nbsp;号<span class="STYLE1">*</span></td>
                                            <td class="item_content" colspan="3">
                                               <input type="text" ID="identityCardNo" MaxLength="18"   runat="server"/>
                                                <asp:Button ID="search" runat="server" CssClass="buttons" Text="检索" OnClick="SearchMemberCard" OnClientClick="return dataValidateSearchLogOut();"/>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <%
                                if (SearchTag)
                                {
                            %>
                            <tr>
                                <td width="3%"></td>
                                <td align="left">
                                    <table border="1" cellspacing="1" cellpadding="2">
                                        <tr>
                                            <th nowrap align="center"> &nbsp;NO&nbsp;</th>
                                            <th nowrap align="center">卡&nbsp;&nbsp;号</th>
                                            <th nowrap align="center">客户名称</th>
                                            <th nowrap align="center">卡状态</th>
                                            <th nowrap align="center"> &nbsp;</th>
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
												<td align="center"><%= memberCard.MemberCardNo%></td>
												<td align="center"><%= memberCard.CustomerName%></td>
												<%
												if (memberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_KEY)
												{
												%>
												<td align="center"><%= Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_TEXT %></td>
                                            <%}
                                              else if (memberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_KEY)
                                              { 
											    %>
												<td align="center"><%= Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_TEXT %> </td>
                                            <%} %>
												<td align="center"><a href="#" id="a" onclick='SelectId(<%= memberCard.Id%>)'>选择</a></td>
                                        </tr>
                                        <%}
                                      } %>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <%}%>
                            <%
                                if (ReportLessTag && model.MemberCard.MemberState != "3")
                                {
                            %>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                           <td nowrap class="item_caption">会&nbsp;员&nbsp;卡&nbsp;号<span class="STYLE1">*</span></td>
                                           <td class="item_content" id="membercardno" style="height: 22px"><%= model.MemberCard.MemberCardNo %><input name="hiddenMembercardNo" id="hiddenMembercardNo" type="hidden" value='<%= model.MemberCard.MemberCardNo %>' /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption"> 客&nbsp;户&nbsp;名&nbsp;称<span class="STYLE1">*</span></td>
                                            <td class="item_content"> <%= model.Customer.Name %><input name="hiddenCustomerId" type="hidden" id="hiddenCustomerId" value="<%=model.Customer.Id %>" /><input name="membercardid" id="membercardid" type="hidden" value='<%= model.MemberCard.Id %>' /></td>
                                        </tr>
                                       <%-- <tr>
                                            <td nowrap class="item_caption"> 注&nbsp;&nbsp;&nbsp;销&nbsp;&nbsp;&nbsp;人<span class="STYLE1">*</span></td>
                                            <td class="item_content"><asp:TextBox ID="logoffMan" runat="server" Width="150px"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                注&nbsp;销&nbsp;时&nbsp;间<span class="STYLE1">*</span></td>
                                            <td class="item_content">
                                                <div>
                                                    <input class="datetexts" runat="server" id="txtFrom" type="text" readonly="readonly" maxlength="10" onfocus="setday(this);"/>&nbsp;
                                                    </div>
                                            </td>
                                        </tr>--%>
                                        <tr>
                                            <td nowrap class="item_caption"> 注&nbsp;销&nbsp;原&nbsp;因</td>
                                            <td class="item_content" colspan="3"><asp:TextBox ID="memo" runat="server" Columns="70" Rows="3" TextMode="MultiLine" Height="42px"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center" class="bottombuttons">
                                    <asp:Button ID="insert" Cssclass="buttons" runat="server" Text="确定" OnClick="InsertLogoffMemberCard" OnClientClick="return dataValidateLogOutCard();"/>
                                    </td>
                                <td width="3%"></td>
                            </tr>
                            <%}%>
                            <tr height="5">
                                <td width="3%"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td width="3%"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
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
