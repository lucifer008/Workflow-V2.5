<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CanceAfterVerificationDelivery.aspx.cs" Inherits="OrderCanceAfterVerificationDelivery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>核销送货</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/json.js"></script>
<script type="text/javascript" src="../js/escExit.js"></script>
<script type="text/javascript" src="../js/order/cancelAfterVerificationDelivery.js"></script>
<script type="text/javascript"> 
    var strNo='<%= Request.QueryString["strNo"] %>'; 
    var strName='<%= Request.QueryString["strName"] %>';
</script>
    <base target="_self" />
</head>

<body  style="text-align:left">
<% if (closeFlag)
   {%>
    <script type="text/javascript">
        opener.location.reload();
        close();
    </script>
    <%} %>
<form id="form1" action="" method="post" runat="server">
<div align="left" style="width:99%" bgcolor="#ffffff" id="container">
<table width="400" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td width="12"><img alt="" src="../images/white_main_top_left.gif"
			width="12" height="11" border="0"/></td>
		<td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif"
			width="10" height="10"/></td>
		<td width="12"><img alt="" src="../images/white_main_top_right.gif"
			width="12" height="11"/></td>
	</tr>

	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">首页 -&gt; 本日工单 -&gt; 核销送货</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">核销送货</td>
			</tr>
			<tr>
				<td width="3%" style="height: 178px">&nbsp;</td>
				<td align="center" style="height: 178px">
				<table width="100%" border="1" cellpadding="2" cellspacing="1">
						  <tr>
							<td  nowrap class="item_caption">工单号:</td>
							<td class="item_content"><span id="OrderNo"></span><input type="hidden" id="txtOrderNo" name="strOrderNo" /></td>
						  </tr>
						  <tr>
							<td  nowrap class="item_caption">客户名称:</td>
							<td class="item_content"><span id="CustomerName"></span></td>
						  </tr>
						  <tr>
							<td  nowrap class="item_caption">核销状态:</td>
							<td class="item_content"><input name="CancelAfterVerificationStatus" class="checks"
							id="sltCancelAfterVerificationStatus" type="checkbox" />
                      &nbsp;
                      <label for="ckneedPrepareMoney">已送出</label>
						  </tr>
						  <tr>
							<td  nowrap class="item_caption">说明:</td>
							<td class="item_content"><textarea name="Remark" class="textarea" cols="50" rows="4" style="width:100%"></textarea></td>
						  </tr>
				</table>				</td>
			<td width="3%" style="height: 178px">&nbsp;</td>				
			</tr>
			<tr  class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>			
			<tr > 
				<td width="3%">&nbsp;</td>
				<td align="center" class="bottombuttons">
				<asp:Button ID="btnOk" OnClick="CancelAfterVerificationn" OnClientClick="dataCheck();" runat="server" CssClass="buttons" Text="确定" />&nbsp;
				  <input type="button" class="buttons"  onclick="window.close()" name="Submit" value="关闭" /></td>
			</tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>			
			<tr height="5">
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
			</tr>
			
			</table>
			</td>

		</tr>
	<tr>
		<td width="12"><img alt="" src="../images/white_main_bottom_left.gif"
			width="12" height="11"/></td>
		<td bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif"
			width="10" height="10"/></td>
		<td width="12"><img alt="" src="../images/white_main_bottom_right.gif"
			width="12" height="11"/></td>
	</tr>
	<tr></tr>
</table>
</div>
</form>
</body>
</html>
