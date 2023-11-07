<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerList.aspx.cs" Inherits="CustomerList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>客户一览</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/customer/customerList.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server" method="get" defaultbutton="SelectCustomer">
        <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <input id="deleteId" type="hidden" runat="server" />
            <input id="deleteTag" type="hidden" runat="server"/>
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
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;客户管理&nbsp;-&gt;&nbsp;客户一览</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">客户一览</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="center">
                                        <tr>
                                            <td nowrap class="item_caption">客户名称:</td>
                                            <td class="item_content">
                                                <input class="texts" type="text" name="CustomerName" id="CustomerName" runat="server"/>
                                            </td>
                                            <td nowrap class="item_caption">卡号:</td>
                                            <td class="item_content">
                                                <input class="texts" type="text" name="memberCardNo" id="txtMemberCardNo" runat="server"/>
                                            </td>
                                            <td colspan="8" align="right"> <asp:Button ID="SelectCustomer" Cssclass="buttons" runat="server" Text="查询" OnClick="SelectCustomerCondition" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                                            <th nowrap>客户名称</th>
                                            <th width="10%" nowrap>所属行业</th>
                                            <th width="10%" nowrap>级别</th>
                                            <th width="10%" nowrap>类型</th>
                                            <th width="10%" nowrap>状态</th>
                                            <th nowrap>联系电话</th>
                                            <th nowrap>地址</th>
                                            <th nowrap>预存款</th>
                                            <th nowrap>备注</th>
                                            <th width="1%" nowrap>&nbsp;</th>
                                        </tr>
                                        <% if (null != model.CustomerList)
                                           {
                                               for (int i = 1; i <= model.CustomerList.Count; i++)
                                               {
                                                   Workflow.Da.Domain.Customer customer = model.CustomerList[i - 1];
                                        %>
                                        <tr class="detailRow">
                                            <td nowrap><%= i%></td>
                                            <td nowrap align="left"> <a href="#" onclick="showPage('CustomerDetail.aspx?Id=<%= customer.Id%>', null, 800, 550, false, true);"><%= customer.Name%></a></td>
                                            <td nowrap align="center"><%= customer.SecondaryTrade.Name%></td>
                                            <td nowrap align="center"><%= customer.CustomerLevel.Name%></td>
                                            <td nowrap align="center"><%= customer.CustomerType.Name%> </td>
                                            <%if (customer.ValidateStatus == Workflow.Support.Constants.CUSTOMER_NOT_VALIDATE_STATUS_KEY)
                                              {%>
                                            <td nowrap align="center"><%= Workflow.Support.Constants.CUSTOMER_NOT_VALIDATE_STATUS_TEXT%></td>
                                            <%}
                                              else
                                              { %>
                                            <td nowrap align="center"><%= Workflow.Support.Constants.CUSTOMER_VALIDATE_STATUS_TEXT%></td>
                                            <% }%>
                                            <td nowrap align="left"><%= customer.LastTelNo%></td>
                                            <td nowrap align="left"><%= customer.Address%></td>
                                            <td nowrap align="left"><%= customer.Amount%></td>
                                            <td nowrap align="left"><%= customer.Memo%></td>
                                            <td nowrap align="left">
                                                <a href="#" onclick="editCustomer(<%= customer.Id %>,1);">编辑</a>
                                                <a href="#" onclick='doCustomerId(<% = customer.Id %>)'>删除</a>
                                            </td>
                                        </tr>
                                        <% }%>
                                         <tr>
                                            <td colspan="13" align="right">
                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                                </webdiyer:AspNetPager>
                                            </td>
                                        </tr>
                                       <%}%>
                                       
                                    </table>
                                </td>
                                <td width="3%"></td>
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
                    <td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
                    <td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
