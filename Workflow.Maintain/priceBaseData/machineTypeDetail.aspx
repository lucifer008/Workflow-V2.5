﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="machineTypeDetail.aspx.cs" Inherits="priceBaseData_machineTypeDetail" %>
<%@ Import Namespace="Workflow.Support" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>机器类型详情</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/escExit.js"></script>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
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
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 价格基础数据维护-&gt;机器类型详情</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">机器类型详情</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
				<table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
					<tr>
					<td nowrap class="item_caption">编号</td>
						<td class="item_content" align="left"><%=machineType.No %></td>
						<td nowrap class="item_caption">名称</td>
						<td class="item_content" align="left"><%=machineType.Name %></td>
					</tr>
                    <tr>
						<td nowrap class="item_caption">是否需要抄表</td>
						<td class="item_content" colspan="3" align="left">
						   <%=Constants.GetInWatchIsNot(machineType.NeedRecordWarch) %>
						 </td>
                    </tr>
				</table>
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
