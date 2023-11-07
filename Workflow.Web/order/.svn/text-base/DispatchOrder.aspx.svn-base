<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DispatchOrder.aspx.cs" Inherits="OrderDispatchOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>分配订单</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/json.js"></script>
<script type="text/javascript" src="../js/order/dispatchOrder.js"></script>
<script type="text/javascript"> 
var strNo='<%=Request.QueryString["strNo"]%>';
</script>
<%if(closeFlag) {%>
<script type="text/javascript">
    opener.location.reload();
     //opener.location.href=opener.location.href;
    close();
</script>
<%} %>
    <base target="_self" />
</head>

<body  style="text-align:center">
   
<form action="" method="post" id="form1" runat="server">
<div align="left" style="width:99%" bgcolor="#ffffff"  id="container">
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
				<td align="left" bgcolor="#eeeeee">首页 -> 订单管理 ->本日订单 ->分配订单</td>
				<td style="width: 12px"></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">分配订单</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="left">
				<table width="100%" border="1" cellpadding="2" cellspacing="1">
						  <tr>
							<td  nowrap class="item_caption">订单号:</td>
							<td class="item_content"><span id="OrderNo"></span><input id="txtOrderNo" type="hidden" name="strOrderNo" /></td>
						  </tr>
          <tr>
            <td nowrap class="item_caption">前期:</td>
            <td class="item_content"><select id="prophase" name="sltProphase" size="5" style="width:100px" multiple="multiple">
                <%
                    for (int i = 0; i < model.EmployeeList.Count; i++)
                    {
                        //前期
                        if (model.EmployeeList[i].Positionid == Workflow.Support.Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                        {%>
                        
                        <option value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                <%}
              } %>

              </select>
            </td>
          </tr>
          <tr>
            <td nowrap class="item_caption">后期:</td>
            <td class="item_content"><select id="anaphase" name="sltAnaphase" size="5"  style="width:100px" multiple="multiple">
                <%
                    for (int i = 0; i < model.EmployeeList.Count; i++)
                    {
                        //后期
                        if (model.EmployeeList[i].Positionid == Workflow.Support.Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                        {%>
                        <option value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                <%}
              }%>
            </select>
            </td>
          </tr>		  
          <tr>
            <td nowrap class="item_caption">备注:</td>
            <td class="item_content"><textarea name="Memo" cols="40" rows="3" class="textarea"></textarea></td>
          </tr>
				</table>				</td>
				<td style="width: 12px">&nbsp;</td>				
			</tr>
			<tr  class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>			
			<tr > 
				<td width="3%">&nbsp;</td>
				<td align="center" class="bottombuttons">
				<asp:Button ID="btnOk" CssClass="buttons" OnClick="SaveEmployee" Text="确定" OnClientClick="return dataCheck();" runat="server" />
				  <input type="button" class="buttons" onclick="window.close()" name="Submit" value="关闭" /></td>
			</tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>			
			<tr height="5">
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td style="width: 12px"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
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
</table>
</div>
</form>
</body>
</html>

