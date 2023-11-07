<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectCustomer.aspx.cs" Inherits="GetOneCustomer" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/stringUtils.js"></script>
<script type="text/javascript" src="../js/escExit.js"></script>
<script type="text/javascript" src="../js/customer/selectCustomer.js"></script>
<script type="text/javascript" language="javascript">
function callBackMethod(objCustomer)
{   	
	if (window.opener)
	{
	    window.opener.<%=returnMethod %>(objCustomer);
	}
	close();
}
</script>
<title>选择客户</title>
</head>
<body style="text-align: center">
    <form id="form1" runat="server">
        <div align="center" style="width: 99%;" bgcolor="#FFFFFF" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
                    <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;客户管理&nbsp;-&gt;&nbsp;选择客户</td>
                                <td></td>
                            </tr>
                            
                            <tr>
                                <td colspan="3" class="caption" align="center">选择客户</td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td align="center">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <td nowrap class="item_caption">客户名称:</td>
                                            <td class="item_content" colspan="3"><input type="text" id="txtCustomerName" name="CustomerName" runat="server" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">所属行业:</td>
                                            <td class="item_content"><asp:DropDownList ID="sltTrade" runat="server" AppendDataBoundItems="True"><asp:ListItem Value="-1">请选择</asp:ListItem></asp:DropDownList></td>
                                            <td nowrap class="item_caption">客户级别:</td>
                                            <td class="item_content">
                                                <asp:DropDownList ID="sltCustomerLevel" runat="server" AppendDataBoundItems="True"><asp:ListItem Value="-1">请选择</asp:ListItem></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">客户类型:</td>
                                            <td class="item_content">
                                                <asp:DropDownList ID="sltCustomerType" runat="server" AppendDataBoundItems="True" ><asp:ListItem Value="-1">请选择</asp:ListItem></asp:DropDownList>
                                            </td>
                                            <td nowrap class="item_caption">联系人:</td>
                                            <td class="item_content"><asp:TextBox ID="txtLinkMan" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">支付方式:</td>
                                            <td class="item_content">
                                                <asp:DropDownList ID="sltPayType" runat="server" AppendDataBoundItems="True" ><asp:ListItem Value="-1">请选择</asp:ListItem></asp:DropDownList>
                                            </td>
                                            <td nowrap class="item_caption">注册日期:</td>
                                            <td class="item_content">
                                                <div>
                                                    <asp:TextBox ID="txtBeginDate" runat="server" onfocus="setday(this);" ReadOnly="true" CssClass="datetexts" MaxLength="10"></asp:TextBox>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;&nbsp;&nbsp;
                                                    <asp:TextBox ID="txtEndDate" runat="server" onfocus="setday(this);" ReadOnly="true" CssClass="datetexts" MaxLength="10"></asp:TextBox>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="right" class="querybuttons">
                                                &nbsp;
                                                &nbsp;<asp:Button ID="btnQuery" CssClass="buttons" runat="server" Text="查询" OnClick="QueryCustomer" OnClientClick="return checkInput();" />
                                            </td>
                                        </tr>
                                </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="center">
                        <table border="0" cellpadding="0" cellspacing="0" width="100%" align="left">
							<tr>
                                <td align="center">
                                     <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left" id="resultTable">
                                        <tr>
                                            <th align="center" width="1%" nowrap>&nbsp;NO&nbsp;</th>
                                            <th align="center" nowrap>客户名称</th>
                                            <th align="center" width="5%" nowrap>客户<br />行业</th>
                                            <th align="center" width="5%" nowrap>客户<br />级别</th>
                                            <th align="center" width="5%" nowrap>客户<br />类型</th>
                                            <th align="center" width="5%" nowrap>支付<br />方式</th>
                                            <th align="center" width="5%" nowrap>预存款</th>
                                            <th align="center" width="2%" nowrap>联系人</th>
                                            <th align="center" width="2%" nowrap>联系电话</th>
                                            <th align="center" nowrap>地址</th>
                                            <th align="center" width="2%" nowrap>发票</th>                                                
                                            <th align="center" width="2%" nowrap>状态</th>
                                            <th align="center">备注</th>
                                            <th align="center" width="2%" nowrap>&nbsp;</th>
                                        </tr>
                                    <%
                                        if (null != model.CustomerList)
                                        {
                                            for (int i = 1; i <= model.CustomerList.Count; i++)
                                            {
                                                Workflow.Da.Domain.Customer customer = model.CustomerList[i - 1];
                                        %>
                                        <tr class="detailRow" title="row<%=i %>">
                                            <td width="0px"><%=customer.Id%></td>
                                            <td align="left"><a href="#" onclick="choiceCustomer(<%=i %>)" ><%=customer.Name%></a></td>
                                            <td nowrap align="center"><%=customer.SecondaryTrade.Name%><input type="hidden" id="TradeId<%= i %>" value="<%= customer.SecondaryTrade.Id %>" /></td>
                                            <td align="center"><%=customer.CustomerLevel.Name%><input type="hidden" id="CustomerLevelId<%= i %>" value="<%= customer.CustomerLevel.Id %>" /></td>
                                            <td nowrap align="left"><%=customer.CustomerType.Name%></td>
                                            <td nowrap align="left">
                                                <%
                                                    switch (customer.PayType)
                                                    { 
                                                        case Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE:
                                                            Response.Write(Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_LABEL.Trim());
                                                            break;
                                                        case Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE:
                                                            Response.Write(Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_LABEL.Trim());
                                                            break;
                                                        default:
                                                            Response.Write(Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_LABEL.Trim());
                                                            break;
                                                    }
                                                %>
                                             </td>
                                             <td align="center"><%=customer.Amount%></td>
                                            <td align="center"><%=customer.LastLinkMan%></td>
                                            <td nowrap align="center"><%=customer.LastTelNo%></td>
                                            <td nowrap align="left"><%=customer.Address%></td>
                                            <%
                                                if(string.Compare(customer.NeedTicket,Workflow.Support.Constants.NEED_TICKET_KEY) == 0)
                                                {
                                                 %>
                                            <td nowrap align="center"><%= Workflow.Support.Constants.NEED_TICKET_TEXT %></td>
                                            <%
                                                } 
                                                else
                                                {
                                                    %>
                                            <td nowrap align="center"><%= Workflow.Support.Constants.NEED_TICKET_NOT_TEXT %></td>
                                            <%
                                                } %>
                                            <%
                                                if(string.Compare(customer.ValidateStatus,Workflow.Support.Constants.CUSTOMER_VALIDATE_STATUS_KEY) ==0)
                                                {
                                                 %>
                                            <td nowrap align="left"><%= Workflow.Support.Constants.CUSTOMER_VALIDATE_STATUS_TEXT %></td>
                                            <%
                                                } 
                                                else 
                                                {
                                                    %>
                                            <td nowrap align="left"><%= Workflow.Support.Constants.CUSTOMER_NOT_VALIDATE_STATUS_TEXT %></td>
                                            <%
                                                } %>
                                            <td align="left"><%=customer.Memo%></td>
                                            <td nowrap align="left"><input type="hidden" id="simplename<%=i %>" value="<%= customer.SimpleName %>" /><a href='javascript:choiceCustomer(<%=i %>);'>选择</a></td>
                                        </tr>
                                        <%
                                            }
                                        %>
                                        <tr><td colspan="14" style="text-align:right"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager></td></tr>        
                                     <% 
                                        }
                                            %>
                                    </table>
                                </td>
                            </tr>
                         </table></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
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