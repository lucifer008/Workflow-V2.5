<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportLossRecovery.aspx.cs" Inherits="ReportLossRecovery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>挂失/恢复</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/membercard/reportLossMemberCard.js"></script>
<script type="text/javascript" language="javascript">	     
function winClose()
{
    window.top.opener=null;
    window.close();
}  
document.onkeydown=function()
{	
    var evt=window.event || arguments[0];
    var element=evt.srcElement || evt.target; 
    <%if(reportLessTag) {%>	
	    if((evt.keyCode == 13) && (
		    element.id=="passWordAfftirm" ||
		    element.id == "reportLessName"||
		    element.id == "reportLessMode" ||
		    element.id == "telNo" 
	     ))
	    {
			 
		     <% if(model.MemberCard.MemberState == "1"){%>
			    var btnLoss = document.getElementById("LossMemberCard"); 
			    btnLoss.click();
			    if(evt.keyCode==27) winClose();  
			    return false;
		    <% }else{%>
			    var btnRecovery= document.getElementById("RecoveryMemberCard");
			    btnRecovery.click();
			    if(evt.keyCode==27) winClose(); 
			    return false;
		    <% }%>
		    return true;
	    }
	    else if((evt.keyCode == 13) && element.id == "passWord")
	    {
		    return false;
	    } 
    <%}else{ %>
	    if((evt.keyCode == 13) && (element.id =="identityCardNo"))
	    {
		    var btnLoss = document.getElementById("searchMemberCard"); 
		    btnLoss.click();
		    if(evt.keyCode==27) winClose();  
		    return false;
	    }
	    return true;
    <%} %>
	
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
    <input name ="checkTag" id="checkTag" type="hidden" value="F"/>
    <input name="searchTag" id="searchTag" type="hidden" />
    <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
                <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
                <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
            </tr>
            <tr>
                <td width="3%"></td>
                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;卡管理&nbsp;-&gt;&nbsp;挂失/恢复</td>
                <td width="3%"></td>
            </tr>
            <tr>
                <td colspan="3" class="caption" align="center">挂失/恢复</td>
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
                            <td nowrap class="item_caption">身&nbsp;份&nbsp;证&nbsp;号</td>
                            <td class="item_content" colspan="3" id="submit">
                                <input type="text" id="identityCardNo" runat="server"/>
                                <asp:Button ID="searchMemberCard" runat="server"  CssClass="buttons" Text="检索" OnClick="SearchMemberCardByIdentityCard" OnClientClick="return dataValidateSearchReportLoss();" TabIndex="1"/>
								</td>
                        </tr>
                    </table>
                </td>
                <td width="3%"></td>
            </tr>
            <%
               if(searchTag)
               {
             %>
            <tr>
                <td width="3%"></td>
                <td align="left">
                    <table border="1" cellspacing="1" cellpadding="2">
                        <tr>
                             <th nowrap align="center"> &nbsp;N&nbsp;&nbsp;O&nbsp;&nbsp;</th>
                             <th nowrap align="center"> &nbsp;卡&nbsp;&nbsp;号&nbsp;</th>
                             <th nowrap align="center"> 客户名称</th>
                             <th nowrap align="center"> &nbsp;卡状态&nbsp;</th>
                             <th nowrap align="center">&nbsp;</th>
                        </tr>
                    <%if (model.MemberCardList.Count != 0)
                      {
                          for (int i = 1; i <= model.MemberCardList.Count; i++)
                            {
                                Workflow.Da.Domain.MemberCard memberCard = model.MemberCardList[i - 1];             
                    %>
                        <tr class="row<%= memberCard.Id%>">
                            <td align="center"> <%= i%></td>
                            <td align="center"><%= memberCard.MemberCardNo %></td>
                            <td align="center"><%= memberCard.CustomerName %></td>
                             <%if (memberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_KEY){%>
                                <td align="center"><%= Workflow.Support.Constants.MEMBER_CARD_STATE_NATURAL_TEXT %></td>
                             <%}
                              else if (memberCard.MemberState == Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_KEY)
                              { %>
                            <td align="center"><%= Workflow.Support.Constants.MEMBER_CARD_STATE_REPORTLOSS_TEXT %></td>
                            <%} %>
                            <td align="center"><a href="#" onclick='SelectId(<%= memberCard.Id%>)' tabindex="2">选择</a></td>
                        </tr>
                        <%}
                      } %>
                    </table>
                </td>
                <td width="3%"></td>
            </tr>
            <%} %>
            <%if(reportLessTag){%>
            <tr>
                <td width="3%">&nbsp;</td>
                <td align="center">
                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                        <tr>
                            <td nowrap class="item_caption"> 会&nbsp;员&nbsp;卡&nbsp;号<span class="STYLE1">*</span></td>
                            <td class="item_content" id="membercardno" runat="server">
                                <%=model.MemberCard.MemberCardNo%><input name="hiddenMembercardno" id="hiddenMembercardno" type="hidden" value='<%=model.MemberCard.MemberCardNo%>' />
                                <input name="membercardid" id="membercardid" type="hidden" value='<%= model.MemberCard.Id %>'/>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap class="item_caption">客&nbsp;户&nbsp;名&nbsp;称<span class="STYLE1">*</span></td>
                            <%if (model.Customer != null)
                              {%>
                            <td class="item_content"><%= model.Customer.Name%><input type="hidden" id="hiddenCustomerId" name="hiddenCustomerId" value="<%=model.Customer.Id %>" />
                            </td>
                            <%}else{%>
                             <td class="item_content"></td>
                            <%}%>
                        </tr>
                     <%if (model.MemberCard.MemberState == "1")
                       {%>
						
                        <tr>
                            <td nowrap class="item_caption"> 挂&nbsp;&nbsp;&nbsp;失&nbsp;&nbsp;&nbsp;人<span class="STYLE1"></span><span class="STYLE1">*</span></td>
                            <td class="item_content"><input ID="reportLessName" runat="server" Width="154px" /></td>
                        </tr>
                        <tr>
                            <td nowrap class="item_caption"><span class="STYLE1"><span style="color: #333333; background-color: #d6dfef">挂&nbsp;失&nbsp;方&nbsp;式</span>*</span></td>
                            <td class="item_content">
                                <asp:DropDownList ID="reportLessMode" runat="server" AppendDataBoundItems="True" Width="162px">
                                    <asp:ListItem Value="0">请选择</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap class="item_caption">联&nbsp;系&nbsp;电&nbsp;话<span class="STYLE1">*</span></td>
                            <td class="item_content"><input type="text" ID="telNo"  Width="154px" runat="server"/></td>
                        </tr>
                        <%}%>
                    </table>
                </td>
                <td width="3%"></td>
            </tr>
            <tr class="emptyButtonsUpperRowHight">
                <td colspan="3"></td>
            </tr>
            <tr>
                <td width="3%">&nbsp;</td>
                <td align="center" class="bottombuttons">
                    <%if(model.MemberCard.MemberState == "1") {%>
                        <asp:Button ID="LossMemberCard" runat="server" CssClass="buttons" Text="挂失" OnClick="InsertReportLossMemberCard" OnClientClick="return dataValidateReportLossCard();"/>
                    <%} %>&nbsp;
                    <%if (model.MemberCard.MemberState != "1"){%>
                        <asp:Button ID="RecoveryMemberCard" runat="server" CssClass="buttons" Text="恢复" OnClick="RecoveryReportLossMemberCard"/>
                    <%} %>
                </td>
                <td width="3%"></td>
            </tr>
            <%}%>
            <tr height="5">
                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                <td bgcolor="#eeeeee">&nbsp; </td>
                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
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
