<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewCustomer.aspx.cs" Inherits="NewCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>客户添加</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<link rel="stylesheet" href="../css/calendar-blue.css"  type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/escExit.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/customer/newCustomer.js"></script>
<script type="text/javascript">
   var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
   var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
   var accreditTypeKey='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_NEW_OWE_CUSTOMER_KEY %>';
   var accreditTypeText='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_NEW_OWE_CUSTOMER_TEXT %>';
   var accreditTypeId=<%=Workflow.Support.Constants.GET_USER_OPERATE_ACCREDIT_OWE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;//挂账授权Id
   var payType=<%=Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE %>;
   var payTypeCash=<%=Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE %>;
 <%
    if (bStatic) 
    {
 %>
        $().ready(function()
        {
	        if (window.opener && window.opener.<%= returnMethod %>){
	            var objCustomer = new Object();
                objCustomer.Id = <%= model.Id.ToString()%>;
                objCustomer.Name = $("#CustomerName").attr("value");
                objCustomer.LinkMan = $("#LinkManName").attr("value");
                objCustomer.TelNo = $("#TelNo").attr("value");
                objCustomer.Address = $("#Address").attr("value");
                objCustomer.Memo = $("#Memo").attr("value");
       	        objCustomer.TradeId = <%=model.SecondaryTradeId.ToString()%>;
       	        objCustomer.NeedTicket='<%=model.NeedTicketName%>';
       	        objCustomer.CustomerType='<%=model.CustomerTypeName.ToString()%>';
       	        objCustomer.CustomerLevelId=<%=model.CustomerLevelId.ToString()%>;
       	        objCustomer.PaymentType='<%=model.PaymentTypeString %>';
       	        objCustomer.SimpleName='<%=model.SimpleName.ToString()%>';
		        window.opener.<%= returnMethod %>(objCustomer);
		        close();
            }
            else
            {
                window.returnValue="ok";
                window.close();
            }
        });
 <% } %>
function ReturnClick()
{
    if('<%=displayCustomerList %>'.toLowerCase()=='false')
    {
        close();
    }
    else
    {
        document.location.href='CustomerList.aspx';
    }
 }
</script>
<base target="_self" />
<style type="text/css">
<!--
.STYLE1 {color: #FF0000}
-->
</style>
</head>

<body style="text-align:center">
<form id="form1" runat="server">
<input id="txtCustomerId" name="txtCustomerId" value="<%= CustomerId.Value %>" type="hidden" />
<div align="center" style="width:100%;" bgcolor="#FFFFFF" id="container">
<input type="hidden" name="hiddCutomerTypeName" id="hiddCutomerTypeName" runat="server"/>
<table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	</tr>
  <tr>
    <td colspan="3" bgcolor="#FFFFFF">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
           <td width="3%"></td>
		    <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;客户管理&nbsp;-&gt;&nbsp;客户添加</td>
		    <td width="3%"></td>
      </tr>      
      <tr><td colspan="3" class="caption" align="center">客户添加</td></tr>
      <tr>
        <td width="3%">&nbsp;</td>
        <td align="center">
            <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
              <tr>
                <td nowrap class="item_caption">客户名称<span class="STYLE1">*</span></td>
                <td class="item_content"><asp:TextBox ID="CustomerName" runat="server" MaxLength="50"></asp:TextBox></td>
                <td nowrap class="item_caption" >简&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;拼</td>
                <td colspan="2" class="item_content"><asp:TextBox ID="SimpleName" runat="server"  MaxLength="20"></asp:TextBox></td>
              </tr>
              <tr>
                <td nowrap class="item_caption" >所属行业<span class="STYLE1">*</span></td>
                <td class="item_content">
                  <asp:DropDownList ID="Trade" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
                </td>
                <td nowrap class="item_caption">客户级别<span class="STYLE1">*</span></td>
                <td colspan="2" class="item_content">
                    <asp:DropDownList ID="customerLevel" runat="server" disabled="true" AppendDataBoundItems="True"></asp:DropDownList>
                </td>
              </tr>
			    <tr>
                <td nowrap class="item_caption">客户类型<span class="STYLE1">*</span></td>
                <td class="item_content">
                  <select id="sltCustomerType" name="customerType">
                  <option value="-1">请选择</option>
                  <%if (null != model.CustomerTypeList)
                    {
                        for (int i = 0; i < model.CustomerTypeList.Count; i++)
                        { %>
                    <option value="<%=model.CustomerTypeList[i].Id %>"><%=model.CustomerTypeList[i].Name%></option>
                  <%}
                }%>
                  </select>  
                </td>
                <td nowrap class="item_caption">单位电话</td>
                <td colspan="2" class="item_content"><asp:TextBox ID="TelNo" runat="server" MaxLength="20"></asp:TextBox></td>
              </tr>
			   <tr>
                <td nowrap class="item_caption">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名<span class="STYLE1">*</span></td>
                <td class="item_content"><asp:TextBox ID="LinkManName" runat="server"  MaxLength="20"></asp:TextBox></td>
                <td nowrap class="item_caption">性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别</td>
                <td colspan="2" class="item_content">
                    <asp:RadioButtonList ID="Sex" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                        <asp:ListItem Selected="True" Value="0">男</asp:ListItem>
                        <asp:ListItem Value="1">女</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
              </tr>
			   <tr>
                <td nowrap class="item_caption">身份证号</td>
                <td class="item_content"><asp:TextBox ID="txtIdentityNo" runat="server" MaxLength="100"></asp:TextBox></td>
                <td nowrap class="item_caption">年&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;龄</td>
                <td colspan="2" class="item_content"><asp:TextBox ID="Age" runat="server" MaxLength="2"></asp:TextBox></td>
              </tr>
			   <tr>
			   <td nowrap class="item_caption">通讯地址</td>
                <td class="item_content"><asp:TextBox ID="Address" runat="server" MaxLength="100"></asp:TextBox></td>
                <td nowrap class="item_caption">手&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;机</td>
                <td class="item_content" ><asp:TextBox ID="MobileNo" runat="server" MaxLength="20"></asp:TextBox></td>
              </tr>
			  <tr>
			    <td nowrap class="item_caption">EMAIL</td>
                <td class="item_content"><asp:TextBox ID="EMAIL" runat="server" MaxLength="50"></asp:TextBox></td>
                <td nowrap class="item_caption">职&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;务</td>
			     <td class="item_content"><asp:TextBox ID="Position" runat="server" MaxLength="50"></asp:TextBox></td>
			  </tr>
			  <tr>
			     <td nowrap class="item_caption">爱&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;好</td>
			     <td class="item_content"><asp:TextBox ID="Hobby" runat="server" MaxLength="100"></asp:TextBox></td>
                 <td nowrap class="item_caption">QQ(MSN)</td>
			     <td class="item_content"><asp:TextBox ID="QQ" runat="server"  MaxLength="20"></asp:TextBox></td>
			  </tr>
			  <tr>
			  <td nowrap class="item_caption">发&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;票</td>
			     <td class="item_content">
                    <asp:CheckBox ID="NeedTicket" runat="server" Text="需要" /><asp:HiddenField ID="CustomerId" runat="server" /><asp:HiddenField ID="ParentPage" runat="server" Value="F" />
                </td>                    
			    <td nowrap class="item_caption">支付方式</td>
			    <td class="item_content"><select name="sltPayType" id="cbPaymentType" onchange="arrear();" runat="server"></select></td>
			  </tr>
              <tr>
                <td nowrap class="item_caption">客户说明</td>
                <td colspan="4" class="item_content"><asp:TextBox ID="Memo" runat="server" Rows="3" TextMode="MultiLine" Width="664px" MaxLength="200"></asp:TextBox></td>
              </tr>
            </table>        
        </td>        
        <td width="3%"></td>
      </tr>
      <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
      <tr>
        <td width="3%"></td>
        <td align="center" class="bottombuttons">
            <asp:Button ID="InsertCustomer" Cssclass="buttons" runat="server" Text="确定" OnClick="InsertNewCustomer" OnClientClick="return dataValidateNewCustomer();" />&nbsp;
            <input name="btnClose"  type="button" class="buttons" onclick="ReturnClick();" value="关闭" style="display:none"/>
        </td>
        <td width="3%"></td>
      </tr> 
      <tr height="5">
		<td ><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
		<td bgcolor="#eeeeee">&nbsp;</td>
		<td ><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
	  </tr>     
    </table>
   </td>
  </tr>
	<tr>
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif" /></td>
		<td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" /></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif" /></td>
	</tr>
</table>
</div> 
</form>
</body>
</html>
<%if (okReturn) 
 {%>
    <script type="text/javascript">
        close();
    </script>
<%}
  else
  {
      if(insertTag)
      {%>
        <script type="text/javascript">
           // alert("客户新增成功!");
        </script>
      <%}
  }%>