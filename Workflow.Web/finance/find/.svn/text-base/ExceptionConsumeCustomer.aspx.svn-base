<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExceptionConsumeCustomer.aspx.cs" Inherits="ExceptionConsumeCustomer" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>波动客户查询</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/checkCalendar.js" charset="utf-8"></script>
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/finance/find/exceptionConsumeCustomer.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" runat="server" method="post">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0"/></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                    <td><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0"  heigth="100%">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -&gt; 财务处理 -&gt; 财务查询 -&gt; 波动客户查询</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">波动客户查询</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%">
                                        <tr>
                                            <td align="left">
                                                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">时间:</td>
                                                        <td class="item_content">
                                                        <div>
                                                            <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" value=""  onfocus="setday(this);" readonly="readonly" runat="server"/>&nbsp;至 &nbsp;
                                                            <input id="txtTo" type="text" name="EndDateTime" class="datetexts" value=""  onfocus="setday(this);" readonly="readonly" runat="server"/>           
                                                        </div>                                                        
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">消费额:</td>
                                                        <td class="item_content">
                                                            <asp:DropDownList ID="ddpSumAmount"  runat="server" AppendDataBoundItems="True"></asp:DropDownList>
                                                          <%--  <select name="sltSumAmount">
                                                            <%
                                                                for (int i = 0; i < model.OperatorList.Count; i++)
                                                                { 
                                                                        if (model.OperatorList[i].Value == model.Operator1)
                                                                        {
                                                                        %>
                                                                        <option value="<%=model.OperatorList[i].Value %>" selected="selected">
                                                                            <%=model.OperatorList[i].Label%>
                                                                        </option>
                                                                        <%}
                                                                        else
                                                                        { %>
                                                                            <option value="<%=model.OperatorList[i].Value %>">
                                                                                <%=model.OperatorList[i].Label%>
                                                                            </option>
                                                                        <%}                                                                    
                                                                }
                                                            %>
                                                            </select>--%>
                                                            <input name="SumAmount" id="txtSumAmount" type="text" class="num" value="0" size="10" runat="server" />
                                                            元
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right" style="padding-right: 10px">
                                                            <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="return checkData();" Text="查询" />&nbsp;
                                                            <asp:Button ID="btnDispatchPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnDispatchPrint_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="1" cellspacing="1">
                                        <tr>
                                            <th nowrap>NO</th>
                                            <th nowrap>客户名称</th>
                                            <th nowrap>消费总额</th>
                                            <th nowrap>同比</th>
                                            <th nowrap>联系人</th>
                                        </tr>
                                        <%if(null!=model.OrderList){
                                            for (int i = 0; i < model.OrderList.Count; i++)
                                            { %>
                                                <tr class="detailRow">
                                                    <td align="center"><%=i+1 %></td>
                                                    <td align="left"><a href="#" onclick="customerDetail(this);"><%=model.OrderList[i].CustomerName %></a><input type="hidden" name="txtCustomerId" value="<%=model.OrderList[i].CustomerId %>" /></td>
                                                    <td class="num"><%=model.OrderList[i].SumAmount %></td>
                                                    <td class="num"><%=Math.Round(model.OrderList[i].SumAmount / model.OrderList[i].HasPrePaidMoney,2)*100+"%"%></td>
                                                    <td align="center"><%=model.OrderList[i].Name %></td>
                                                </tr>
                                            <%}%>
                                           <tr class="detailRow"><td align="right" colspan="5"><webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager></td></tr>     
                                        <%}%>
                                    </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11"/></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10"/></td>
                    <td width="12"><img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
