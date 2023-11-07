<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchCustomer.aspx.cs" Inherits="SearchCustomer" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>客户查询</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/Calendar2.js"></script>
<script type="text/javascript" src="../js/checkCalendar.js"></script>
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/escExit.js"></script>
<script type="text/javascript" src="../js/customer/searchCustomer.js"></script>
</head>
<body style="text-align: center" onload="tradeAttribute();">
    <form id="form1" runat="server">
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
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
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;客户管理&nbsp;-&gt;&nbsp;客户查询</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">客户查询</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td width="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <td nowrap class="item_caption">客户名称:</td>
                                            <td class="item_content" colspan="4"><asp:TextBox ID="Name" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">所属行业:</td>
                                            <td class="item_content"><asp:DropDownList ID="Trade" runat="server" AppendDataBoundItems="True"></asp:DropDownList></td>
                                            <td nowrap class="item_caption">客户级别:</td>
                                            <td class="item_content"><asp:DropDownList ID="CustomerLevel" runat="server" AppendDataBoundItems="True"></asp:DropDownList></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">客户类型:</td>
                                            <td class="item_content"><asp:DropDownList ID="CustomerType" runat="server" AppendDataBoundItems="True"></asp:DropDownList></td>
                                            <td nowrap class="item_caption">联系人:</td>
                                            <td class="item_content"><asp:TextBox ID="LinkMan" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">注册日期:</td>
                                            <td colspan="3" class="item_content">
                                                <div>
                                                    <input id="BeginDate" class="datetexts" onfocus="setday(this);" size="16" readonly="readonly" runat="server"/>
                                                    &nbsp;&nbsp;&nbsp;&nbsp;至 &nbsp;&nbsp;&nbsp;&nbsp;
                                                    <input id="EndDate" class="datetexts" onfocus="setday(this);" size="16" readonly="readonly" runat="server"/>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="right">
                                                <asp:Button ID="Search" runat="server" Cssclass="buttons" Text="查询" OnClick="SearchCustomerInfo" OnClientClick="return checkInput();" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                                            <th width="20%" nowrap>客户名称</th>
                                            <th width="10%" nowrap>联系人</th>
                                            <th width="10%">电话</th>
                                            <th width="30%">地址</th>
                                            <th nowrap>备注</th>
                                            <th width="1%" nowrap>&nbsp;</th>
                                        </tr>
                                        <%if (model.CustomerList!=null)
                                          {
                                              for (int i = 1; i <= model.CustomerList.Count; i++)
                                              {
                                                  Workflow.Da.Domain.Customer customer = model.CustomerList[i - 1];
                                        %>
                                        <tr class="detailRow">
                                            <td align="center"><%= i%><input type="hidden" name="customerId" value="<%=customer.Id %>" /></td>
                                            <td align="left" nowrap><a href="#" onclick="customerDetail(this);"><%= customer.Name%></a></td>
                                            <td align="center" nowrap><%= customer.LastLinkMan%></td>
                                            <td align="left" nowrap><%= customer.LastTelNo%></td>
                                            <td align="left" nowrap><%= customer.Address%></td>
                                            <td align="left" nowrap><%= customer.Memo%></td>
                                            <td align="left" nowrap ><a href="#" onclick="CustomerConsumeHistory(this)">消费历史</a></td>
                                        </tr>
                                        <%}
                                      } %>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
		                    <tr>
				                <td colspan="7" style="text-align:right">
                                    <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
				                 </td>
				            </tr>                               
                            <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_bottom_left.gif"></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"></td>
                    <td width="10"><img alt="" src="../images/white_main_bottom_right.gif"></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
