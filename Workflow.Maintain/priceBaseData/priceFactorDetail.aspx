<%@ Page Language="C#" AutoEventWireup="true" CodeFile="priceFactorDetail.aspx.cs" Inherits="priceBaseData_PriceFactorDetail" %>

<%@ Import Namespace="Workflow.Support" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>价格因素详情</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/escExit.js"></script>
</head>
<body style="text-align:center">
<form id="form1" runat="server" method="post">
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
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 价格基础数据维护-&gt;价格因素详情</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">价格因素详情</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
				<table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
					<tr>
					     <td nowrap class="item_caption">名称</td>
						 <td class="item_content" align="left"><%=model.PriceFactor.Name %></td>
						 <td nowrap class="item_caption">显示文本</td>
						 <td class="item_content" colspan="3" align="left"><%=model.PriceFactor.DisplayText%></td>
					</tr>
					<tr>
					     <td nowrap class="item_caption">使用时是否显示</td>
						 <td class="item_content" align="left"><%=Constants.GetPriceFactorDisplayStatus(model.PriceFactor.IsDisplay)%></td>
						 <td nowrap class="item_caption">是否使用</td>
						 <td class="item_content" colspan="3" align="left"><%=Constants.GetPriceFactorUsedStat(model.PriceFactor.Used)%></td>
					</tr>
                  <tr>
						<td nowrap class="item_caption">对应的表</td>
						 <td class="item_content" align="left"><%=model.PriceFactor.TargetTable%></td>
						 <td nowrap class="item_caption">对应值的列</td>
						 <td class="item_content" align="left"><%=model.PriceFactor.TargetValueColumn%></td>
						 <td nowrap class="item_caption">对应文本的列</td>
						 <td class="item_content" align="left"><%=model.PriceFactor.TargetTextColumn%></td>
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
