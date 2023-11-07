<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchOrderItem.aspx.cs" Inherits="SearchOrderItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>������ѯ</title>
<link href="../../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../../js/Calendar2.js"></script>
<script type="text/javascript" src="../../js/checkCalendar.js"></script>
<script type="text/javascript" src="../../js/checkCalendar.js"></script>
<script type="text/javascript" src="../../js/jquery.js"></script>
<script type="text/javascript" src="../../js/default.js"></script>
<script language="javascript">
	function showOrderDetail(){
		showPage('../../order/OrderDetail.html',null,700,800,false,false);
	}

</script>
</head>
<body style="text-align:center">
<div align="center" style="width:99%; background-color:#ffffff;" id="container">
<form id="form1" runat="server">
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td width="12"><img alt="" src="../../images/white_main_top_left.gif"
			width="12" height="11" border="0"></td>
		<td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif"
			width="10" height="10"></td>
		<td width="12"><img alt="" src="../../images/white_main_top_right.gif"
			width="12" height="11"></td>
	</tr>
	<tr>
		<td colspan="3" bgcolor="#FFFFFF">
		<table width="100%" border="0" cellspacing="0" cellpadding="0">
			<tr>
				<td></td>
				<td align="left" bgcolor="#eeeeee">��ҳ -> ������ -> �����ѯ -> ������ѯ</td>
				<td></td>
			</tr>
			<tr>
				<td colspan="3" class="caption" align="center">
                    ������ѯ</td>
			</tr>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
			<table width="100%" border="1" cellpadding="2" cellspacing="1">
              <tr>
                <td nowrap class="item_caption">�ӹ�ҵ��:</td>
                <td class="item_content">
                    <asp:DropDownList ID="BusinessType" runat="server" AppendDataBoundItems="True">
                        <asp:ListItem Value="0">����</asp:ListItem>
                    </asp:DropDownList></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">��������:</td>
                <td class="item_content"><select name="AmountSelect" id="AmountSelect" runat="server">
                  <option>С��</option>
                  <option>С�ڵ���</option>
                  <option>����</option>
                  <option selected="selected">���ڵ���</option>
                  <option>����</option>
                  </select>
                  <input name="Amount" id="Amount" type="text" class="num" runat="server" /></td>
              </tr>
              <tr>
                <td nowrap class="item_caption">���ʽ��:</td>
                <td class="item_content"><select name="UnitPrice" id="UnitPrice" runat="server">
                  <option>С��</option>
                  <option>С�ڵ���</option>
                  <option>����</option>
                  <option selected="selected">���ڵ���</option>
                  <option>����</option>
                  </select>
                    <input type="text" name="Price" id="Price" class="num" runat="server"/>
                  Ԫ</td>
              </tr>
              <tr>
                <td nowrap class="item_caption">ʱ �� ��:</td>
                <td class="item_content"><div>
					<input id="txtFrom" type="text" name="txtFrom" runat="server" maxlength="10" onfocus="setday(this);" class="datetexts" readonly="readonly"/>	
	    		    <input name="txtTo" type="text" id="txtTo" runat="server"  maxlength="10" onfocus="setday(this);" class="datetexts" readonly="readonly"/>
			    </td>
                </tr>
              <tr>
                <td colspan="2" nowrap align="right" style="padding-right:10px">
                    <asp:Button ID="Search"  class="buttons" runat="server" Text="��ѯ" OnClick="SearchOrders" /></td>
              </tr>
            </table>				</td>
				<td width="3%">&nbsp;</td>
			</tr>
			<% 
			    if(model.OrderList != null) 
                {
                    %>
			<tr>
				<td width="3%">&nbsp;</td>
				<td align="center">
<table width="100%" border="1" cellpadding="2" cellspacing="1">
          <tr>
			<th width="3%" nowrap>&nbsp;NO&nbsp;</th>
            <th width="10%" nowrap>������</th>
            <th width="15%" nowrap>�ͻ�����</th>
            <th width="8%" nowrap>����</th>
            <th width="8%" nowrap>���</th>
            <th width="10%" nowrap>��ע</th>
            </tr>
            <% 
                if (model.OrderList.Count != 0)
                {
                    for (int i = 1; i <= model.OrderList.Count; i++)
                    {
                        %>
          <tr  class="detailRow">
            <td align="center"><%= i %></td>
            <td align="center"><a href="javascript:showOrderDetail();"><%= model.OrderList[i - 1].MemberCardNo %></a></td>
            <td align="left"><%= model.OrderList[i - 1].CustomerName %></td>
            <td class="num" align="right"><%= amounts[i - 1] %></td>
            <td class="num" align="right"><%= model.OrderList[i - 1].SumAmount %></td>
            <td align="left"><%= model.OrderList[i - 1].Memo %></td>
            </tr>
            <%}
          }%>
        </table>				</td>
				<td width="3%">&nbsp;</td>		
			</tr>
			<%} %>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3">&nbsp;</td>
			</tr>			
			<tr height="5">
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
				<td bgcolor="#eeeeee">&nbsp;</td>
				<td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
			</tr>		</table>
		</td>
	</tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td width="12"><img alt="" src="../../images/white_main_bottom_left.gif"
			width="12" height="11"></td>
		<td bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif"
			width="10" height="10"></td>
		<td width="12"><img alt="" src="../../images/white_main_bottom_right.gif"
			width="12" height="11"></td>
	</tr>
</table>
</form>
</div>
</body>
</html>
