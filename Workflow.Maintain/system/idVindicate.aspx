﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="idVindicate.aspx.cs" Inherits="system_idVindicate" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Workflow.Support" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title><%=strTitle%></title>
 <link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/system/idVindicate.js"></script>
<base target="_self" />
</head>
<body style="text-align:center">
<form id="form1" runat="server" method="post">
<input type="hidden"  id="hiddIdKey" name="actionIdKey" runat="server"/>
 <div align="center" style="width:99%" bgcolor="#ffffff" id="container">
  <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif" /></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10" /></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 价格基础数据维护-&gt;<%=strTitle%></td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center"><%=strTitle%></td>
			</tr>
			<tr>
			    <td width="3%">&nbsp;</td>
				<td colspan="3" align="left">
                    <asp:Button ID="btnInit" CssClass="buttons" OnClientClick="return initCheck();" Text="初始化" OnClick="btnInit_Click" Visible="false" runat="server"/>&nbsp;
                </td>
                <td width="3%">&nbsp;</td>
			</tr>
			<tr id="tr1" runat="server">
			    <td width="3%">&nbsp;</td>
			    <td width="94%" align="center">
			    <table border="1" cellpadding="3" cellspacing="1" width="100%">
					<tr>
					<th  nowrap="nowrap" align="center" width="5%">No</th>
					<th  nowrap="nowrap" align="center" width="20%">标示符</th>
					<th  nowrap="nowrap" align="center" width="5%">开始值</th>
					<th  nowrap="nowrap" align="center" width="10%">当前值</th>
					<th  nowrap="nowrap" align="center" width="20%">结束值</th>
					<th  nowrap="nowrap" align="center" width="20%">备注</th>
					<th  nowrap width="10%"></th>
					</tr>
					<%
                        if (null != model.IdGeneratorList)
                        {
                            int index = 1;
                            foreach (IdGenerator idGenerator in model.IdGeneratorList)
                            { 
                            %>
                            <tr class="detailRow">
                                <td class="no"><%=index%></td>
                                <td class="flagNo"><%=idGenerator.FlagNo%></td>
                                <td class="beginValue"><%=idGenerator.BeginValue%></td>
                                <td class="currentValue"><%=idGenerator.CurrentValue%></td>
                                <td class="endValue"><%=idGenerator.EndValue%></td>
                                <td class="memo"><%=idGenerator.Memo%></td>
					             <td>
					                <input type="hidden" name="idGeneratorId" value="<%=idGenerator.Id %>"/> 
					                <a href="#" onclick="edmitIdGenerator(this)" >编辑</a>&nbsp;
					               <%-- <a href="#" onclick="deleteIdGenerator(this)">删除</a>--%>
					             </td> 
					           </tr>
                       <% index++;
                        }
                       } %>
                       <tr>
                         <td bgcolor="#eeeeee" align="right" colspan="7">
                         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                         </webdiyer:AspNetPager>
                         </td>
                    </tr> 
				</table>
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

