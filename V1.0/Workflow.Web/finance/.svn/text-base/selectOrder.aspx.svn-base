<%@ Page Language="C#" AutoEventWireup="true" CodeFile="selectOrder.aspx.cs" Inherits="FinanceSelectOrder" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>收银</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/finance/selectOrder.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="get" runat="server">
        <input name="checkTag" id="checkTag" type="hidden" value="F" runat="server" />
        <input name="searchTag" id="searchTag" type="hidden" runat="server"/>
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
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 ->收银</td>
                                <td></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">收银</td></tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center" >
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">工单号:</td>
                                            <td class="item_content">
                                                <input name="OrderNo" id="txtOrderNo" type="text" value="" />
                                                <asp:Button ID="search" runat="server" OnClick="Search" OnClientClick="" Text="检索" CssClass="buttons" />
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
                                            <th width="15%"nowrap>工单号</th>
                                            <th width="15%"nowrap>客户名称</th>
                                            <th width="10%"nowrap>项目名称</th>
                                            <th width="15%"nowrap>开单时间</th>
                                            <th width="10%" nowrap>联系人</th>
                                            <th width="10%" nowrap>联系电话</th>
                                            <th width="10%" nowrap>开单人</th>
                                            <th nowrap>备注</th>
                                            <th width="10%" nowrap></th>
                                        </tr>
                                        <%if (null != fModel.OrderList)
                                          {
                                              for (int i = 0; i < fModel.OrderList.Count; i++)
                                              {%>
                                        <tr  >
                                            <td><%=i + 1%></td>
                                            <td><a href="#" onclick="orderDetail(this);"><%=fModel.OrderList[i].No%></a><input type="hidden" name="myOrderNo" value="<%=fModel.OrderList[i].No %>"/></td>
                                            <td><%=fModel.OrderList[i].CustomerName%></td>
                                            <td><%=fModel.OrderList[i].ProjectName%></td>
                                            <td><%=fModel.OrderList[i].InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                                            <td><%=fModel.OrderList[i].Name%></td>
                                            <td><%=fModel.OrderList[i].LastTelNo%></td>
                                            <td align="center"><%=fModel.OrderList[i].UserName%></td>
                                            <td><%=fModel.OrderList[i].Memo%></td>
                                            <td>
                                                <a href="#" onclick="payForOrder(this)">结算</a>&nbsp;&nbsp;<%--location.href=payForOrder(this)--%> 
                                                <a href="#" onclick=" return ReturnClew(<%=fModel.OrderList[i].Id %>);"> 返回</a>
                                                <input type="hidden" name="customerId" value="<%=fModel.OrderList[i].CustomerId %>" />
                                                <input type="hidden" name="memberCardId" value="<%=fModel.OrderList[i].MemberCardId%>"/>
                                            </td>
                                        </tr>
                                        <%}
                                      } %>
                                        <tr>
                                            <td colspan="10" style="text-align: right;">
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
