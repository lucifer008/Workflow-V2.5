<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyCustomer.aspx.cs" Inherits="ModifyCustomer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>客户资料维护</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/calendar-blue.css" type="text/css" />
    <script type="text/javascript" src="../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
    <script type="text/javascript" src="../js/customer/modifyCustomer.js"></script>
<style type="text/css">
<!--
.STYLE1 {color: #FF0000}
-->
</style>
<base target="_self" />
</head>
<body style="text-align: center;" onload="tradeAttribute()">
    <form id="form1" runat="server">
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <input id="deleteId" type="hidden" runat="server" />
            <input type="hidden" id="Tag" name="Tag" runat="server" />
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
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;客户管理&nbsp;-&gt;&nbsp;客户资料维护</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">客户资料维护</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <div style="display:none"><asp:TextBox ID="CustomerId" runat="server"></asp:TextBox></div>
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <td nowrap class="item_caption">客户名称<span class="STYLE1">*</span></td>
                                            <td class="item_content"><asp:TextBox ID="CustomerName" runat="server"></asp:TextBox></td>
                                            <td nowrap class="item_caption">简&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;拼</td>
                                            <td class="item_content"><asp:TextBox ID="SimpleName" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">所属行业<span class="STYLE1">*</span></td>
                                            <td class="item_content">
                                                <asp:DropDownList ID="Trade" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="Trade" ErrorMessage="请选择" Operator="NotEqual" ValueToCompare='""'></asp:CompareValidator>
                                            </td>
                                            <td nowrap class="item_caption">客户级别<span class="STYLE1">*</span></td>
                                            <td class="item_content">
                                                <asp:DropDownList ID="CustomerLevel" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">客户类型<span style="color: #ff0000">*</span></td>
                                            <td class="item_content">
                                                <asp:DropDownList ID="CustomerType" runat="server" AppendDataBoundItems="True">
                                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td nowrap class="item_caption">电&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;话<span style="color: #ff0000">*</span></td>
                                            <td class="item_content"><asp:TextBox ID="TelNo" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">姓&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;名<span class="STYLE1">*</span></td>
                                            <td class="item_content"><asp:TextBox ID="LinkMan" runat="server"></asp:TextBox></td>
                                            <td nowrap class="item_caption">地&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;址</td>
                                            <td class="item_content"><asp:TextBox ID="Address" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">发&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;票</td>
                                            <td class="item_content"><asp:CheckBox ID="NeedTicket" runat="server" Text="需要" /></td>
                                            <td nowrap class="item_caption">客户状态</td>
                                            <td class="item_content"><asp:CheckBox ID="ValidateStatus" runat="server" Text="确认" /></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">支付方式</td>
                                            <td class="item_content" colspan="3">
                                                <asp:DropDownList ID="PayType" runat="server">
                                                    <asp:ListItem Value="-1">请选择</asp:ListItem>
                                                </asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">客户说明</td>
                                            <td colspan="3" class="item_content"><asp:TextBox ID="Memo" runat="server" Columns="80" Rows="3" TextMode="MultiLine"></asp:TextBox></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <% if(CustomerId.Text != "") {%>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="left">
                                    <input type="button" class="buttons" onclick="addLinkMan(<%=model.Customer.Id %>,'<%=model.Customer.Name %>');" value="增加联系人" />
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" align="left">
                                        <tr>
                                            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                                            <th width="10%" nowrap>联系人名称</th>
                                            <th width="10%" nowrap>单位电话</th>
                                            <th width="5%" nowrap>年龄</th>
                                            <th width="5%" nowrap>男女</th>
                                            <th width="10%" nowrap>地址</th>
                                            <th width="10%" nowrap>EMAIL</th>
                                            <th width="10%" nowrap>手机</th>
                                            <th width="10%" nowrap>QQ号</th>
                                            <th width="10%" nowrap>备注</th>
                                            <th width="10%" nowrap>&nbsp;</th>
                                        </tr>
                                        <%
                                            if (model.LinkManList != null)
                                            {
                                                if (model.LinkManList.Count != 0)
                                                {
                                                    for (int i = 1; i <= model.LinkManList.Count; i++)
                                                    {
                                                        Workflow.Da.Domain.LinkMan linkMan = model.LinkManList[i - 1]; %>
                                        <tr class="detailRow">
                                            <td nowrap align="center" style="width: 34px"><%= i%></td>
                                            <td nowrap align="center"><%= linkMan.Name%></td>
                                            <td nowrap align="center"><%= linkMan.CompanyTelNo%></td>
                                            <% if (linkMan.Age != 0)
                                              { %>
                                            <td nowrap align="center"><%= linkMan.Age%></td>
                                            <%}
                                           else
                                           { %>
                                            <td nowrap align="center"></td>
                                            <%} %>
                                            <% if (linkMan.Sex == "0")
                                           { %>
                                            <td nowrap align="center">男</td>
                                            <% }else{%>
                                            <td nowrap align="center">女</td>
                                            <% }%>
                                            <td nowrap align="left"><%= linkMan.Address%></td>
                                            <td nowrap align="left"><%= linkMan.Email%></td>
                                            <td nowrap class="tel"><%= linkMan.MobileNo%></td>
                                            <td nowrap align="center"><%= linkMan.Qq%></td>
                                            <td nowrap><%= linkMan.Memo%></td>
                                            <td nowrap align="left">
                                                <a href="#" onclick="editLinkMan(<%= linkMan.Id%>,'<%=model.Customer.Name %>')">编辑</a>
                                                  <input id="deleteTag" type="hidden" runat="server" /><a href="#" onclick='deleteCustomer(<%= linkMan.Id%>)'>删除
                                                </a>
                                           </td>
                                        </tr>
                                        <% }}}%>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <%} %>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center" class="bottombuttons">&nbsp;
                                    <asp:Button ID="UpdateCustomer" Cssclass="buttons" runat="server" Text="保存" OnClick="UpdateCustomerInfo" OnClientClick="return dataValidateNewCustomer();" />
                                       &nbsp; &nbsp;
                                    <input type="button" class="buttons" value="关闭" onclick="window.close();" />
                                </td>
                                <td width="3%"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr height="5">
                    <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                    <td bgcolor="#eeeeee">&nbsp;</td>
                    <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
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
