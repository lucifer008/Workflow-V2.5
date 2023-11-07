<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SelectAmendmentOrder.aspx.cs" Inherits="finance_SelectAmendmentOrder" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>订单修正</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/finance/selectAmendmentOrder.js"></script>
    <script type="text/javascript">
     var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
     var master=<%=Workflow.Support.Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
     var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
     var accreditTypeKey='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_AMENDMENTER_KEY %>';
     var accreditTypeText='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_AMENDMENTER_TEXT %>';
    </script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <%--<input  type="button" onclick="alert(aTest);"/>--%>
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td style="width: 12px"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 ->订单修正</td>
                                <td></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">订单修正</td></tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center" >
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">订单号:</td>
                                            <td class="item_content">
                                                <input name="OrderNo" id="txtOrderNo" type="text" value="" runat="server"/>
                                                <asp:Button ID="search" runat="server" OnClientClick="return dataCheck();" OnClick="Search" Text="检索" CssClass="buttons" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="5%" nowrap>NO</th>
                                            <th width="15%"nowrap>订单号</th>
                                            <th width="15%"nowrap>客户名称</th>
                                            <th width="10%"nowrap>项目名称</th>
                                            <th width="15%"nowrap>开单时间</th>
                                            <th width="15%"nowrap>结算时间</th>
                                            <th width="10%" nowrap>开单人</th>
                                            <th width="10%" nowrap>收银</th>
                                            <th nowrap>备注</th>
                                            <th width="20%" nowrap></th>
                                        </tr>
                                        <%if (null != model.Orders)
                                          {
                                              int i = 0;
                                              %>
                                        <tr class="detailRow">
                                            <td><%=i + 1%></td>
                                            <td><a href="#" onclick="orderDetail(this);"><%=model.Orders.No%></a><input type="hidden" name="myOrderNo" value="<%=model.Orders.No %>"/></td>
                                            <td><%=model.Orders.CustomerName%></td>
                                            <td><%=model.Orders.ProjectName%></td>
                                            <td><%=model.Orders.InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                                            <td><%=model.Orders.BalanceDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                                            <%--<td><%=model.Orders.Name%></td>--%>
                                            <td align="center"><%=model.Orders.UserName%></td>
                                            <td align="center"><%=model.Orders.CashName%></td>
                                            <td><%=model.Orders.Memo%></td>
                                            <td>
                                                <a href="#" onclick="amendmentOrder(this)">修正</a>&nbsp;&nbsp;
                                                <input type="hidden" name="customerId" value="<%=model.Orders.CustomerId %>" />
                                                <input type="hidden" name="memberCardId" value="<%=model.Orders.MemberCardId%>"/>
                                            </td>
                                        </tr>
                                        <%
                                      } %>
                                        <tr class="detailRow">
                                            <td colspan="11" style="text-align: right;">
                                                <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                                            </td>
                                        </tr>
                                     </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
