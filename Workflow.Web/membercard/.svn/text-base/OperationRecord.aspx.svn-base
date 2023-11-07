<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OperationRecord.aspx.cs" Inherits="OperationRecord" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>会员管理记录</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<link href="../css/thickbox.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/membercard/operationRecord.js"></script>
<script type="text/javascript" language="javascript">
var count=0;
<%if(null!=model.MemberCardList) {%>
    count=<%=model.MemberCardList.Count %>
<%} %>
</script>
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
        <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;会员管理&nbsp;-&gt;&nbsp;会员查询&nbsp;-&gt;&nbsp;会员管理记录</td>
        <td></td> 
      </tr>
      <tr>
        <td colspan="3" class="caption" align="center">会员管理记录</td>
      </tr>
      
      <tr>
        <td width="3%"></td>
        <td align="center">
        <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
          <tr>

            <td nowrap class="item_caption">操作时间</td>
            <td class="item_content">
					<input class="datetexts" id="txtFrom" type="text" maxlength="10" onfocus="setday(this)" runat="server" readonly="readonly"/>至			
	    		    <input class="datetexts" name="txtTo" id="txtTo" type="text" onfocus="setday(this)" maxlength="10" runat="server" readonly="readonly"/>
			       
             </td>
         </tr>
         <tr> 
            <td nowrap class="item_caption">卡号</td>
            <td class="item_content" colspan="2"><input class="texts" name="MemberCardNo" id="txtMemberCardNo" runat="server" type="text" size="20" /></td>
          </tr>
          <tr>
           <td colspan="3" align="right">
               <asp:Button ID="btnSearch" runat="server"  Cssclass="buttons" Text="检索" OnClick="SearchOperateLog" OnClientClick="return dataValidetor();" />
              <asp:Button ID="btnPrint" runat="server"  Cssclass="buttons" Text="打印" OnClick="btnPrint_Click" OnClientClick="return dataPrintValidetor(count);" /> 
           </td></tr>
        </table>
        </td>
        <td width="3%"></td>
      </tr>
      <tr class="emptyButtonsUpperRowHight">
        <td colspan="3">&nbsp;
        </td>
     </tr>
      <tr>
        <td></td>
        <td align="left">
        <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
          <tr>
            <th width="1%" nowrap align="center">&nbsp;NO&nbsp;</th>
            <th width="8%" nowrap align="center">会员卡号</th>
            <th width="15%" nowrap align="center">客户名称</th>
            <th width="8%" nowrap align="center">操作时间</th>
            <th width="8%" nowrap align="center">操作人</th>
            <th width="6%" nowrap align="center">操作</th>
            <th width="15%" nowrap align="center">备注</th>
          </tr>
          <% if (null!=model.MemberCardList)
             {
                 for (int i = 1; i <= model.MemberCardList.Count; i++)
                 {
                  %>
          <tr class="detailRow">
            <td align="center" nowrap><%= i %></td>
            <td nowrap align="center"><a href="#" onclick="showPage('MemberCardDetail.aspx?Id=<%= model.MemberCardList[i - 1].Id%>', null, 800, 550, false, false);"><%= model.MemberCardList[i - 1].MemberCardNo %></a></td>
            <td nowrap align="left"><%= model.MemberCardList[i - 1].CustomerName %></td>
            <td align="center" nowrap><%= model.MemberCardList[i - 1].InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
            <td align="center" nowrap><%=model.MemberCardList[i-1].InsertUserName %></td>
            <td align="center" nowrap><%=Workflow.Support.Constants.GetMemberCardOperateType(Convert.ToString(model.MemberCardList[i - 1].OperateType))%></td>
            <td nowrap align="left"><%= model.MemberCardList[i - 1].Memo%></td>
          </tr>
          <%
                 }
                 %>
           <tr>
             <td bgcolor="#eeeeee" align="right" colspan="7">
                   <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
             </td>
          </tr>
    <%
     } 
      %>
        </table></td>
      </tr>
      <tr class="emptyButtonsUpperRowHight">
	    <td colspan="3">&nbsp;</td>
	   </tr>
      <tr height="5">
				<td style="height: 5px"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
				<td bgcolor="#eeeeee" style="height: 5px">&nbsp;</td>
				<td style="height: 5px"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
			</tr>
    </table>
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
