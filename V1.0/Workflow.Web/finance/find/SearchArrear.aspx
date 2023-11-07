<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchArrear.aspx.cs" Inherits="FinanceFindSearchArrear" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>Ӧ�տ��ѯ</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
    <script type="text/javascript" src="../../js/finance/find/searcharrear.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">��ҳ -> ������ -> �����ѯ -> Ӧ�տ��ѯ</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">Ӧ�տ��ѯ</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td nowrap class="item_caption">�ͻ�����:</td>
                                                        <td class="item_content"><asp:TextBox ID="CustomerName" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">���:</td>
                                                        <td class="item_content">  
                                                            <select name="Operation1" id="Operation1" runat="server" class="biaodan">
                                                              <option value="&gt;=">���ڵ���</option>
                                                                  <option value=">">����</option>
                                                                  <option value="=">����</option>
                                                                  <option value="<=">С�ڵ���</option>
                                                                  <option value="<">С��</option>
                                                                </select>
                                                            <asp:TextBox ID="SumAmount" runat="server" Width="68px">0</asp:TextBox>
                                                            Ԫ<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
                                                                ControlToValidate="SumAmount" ErrorMessage="����ʽ����" ValidationExpression="^[0-9]\d*$"
                                                                ValidationGroup="serach"></asp:RegularExpressionValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">����:</td>
                                                        <td class="item_content">     
                                                            <select name="Operation2" id="Operation2" runat="server" class="biaodan">
                                                             <option value="&gt;=">���ڵ���</option>
                                                              <option value=">">����</option>
                                                              <option value="=">����</option>
                                                              <option value="<=">С�ڵ���</option>
                                                              <option value="<">С��</option>
                                                                </select>
                                                            <asp:TextBox ID="Days" runat="server" Width="64px">0</asp:TextBox>
                                                            ��<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server"
                                                                ControlToValidate="Days" ErrorMessage="��ʽ����" ValidationExpression="^[0-9]\d*$"
                                                                ValidationGroup="serach"></asp:RegularExpressionValidator></td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption">����ʱ��:</td>
                                                        <td class="item_content">
                                                            <div>
                                                                <input id="BeginDateTime" runat="server" class="datetexts" maxlength="10" name="txtFrom" onfocus="setday(this);" readonly="readonly" size="16" type="text" />&nbsp;&nbsp;��&nbsp;&nbsp;
                                                                 <input id="EndDateTime" runat="server" class="datetexts" maxlength="10" name="endform" onfocus="setday(this);" readonly="readonly" size="16" type="text" />

                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right">
                                                            <asp:Button ID="btnSearch" runat="server" CssClass="buttons" OnClick="Search" Text="��ѯ" ValidationGroup="serach" />
                                                            <asp:Button ID="Button1" CssClass="buttons" runat="server" OnClick="Button1_Click" Text="��ӡ" ValidationGroup="serach" />
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
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap>NO</th>
                                            <th width="30%" nowrap>�ͻ�����</th>
                                            <th width="1%" nowrap>Ӧ�տ���</th>
                                            <th nowrap>��ע</th>
                                            <th width="10%" nowrap></th>
                                        </tr>
                                        <%decimal arrearage = 0;
                                          for (int i = 0; i < model.OrderList.Count; i++)
                                          {
                                              arrearage += model.OrderList[i].SumAmount;
                                        %>
                                        <tr class="detailRow">
                                            <td align="center"><%=i+1 %></td>
                                            <td align="left"><%=model.OrderList[i].CustomerName %></td>
                                            <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.OrderList[i].SumAmount)%></td>
                                            <td><%=model.OrderList[i].Memo %></td>
                                            <td><a href="#" onclick="showOweMoneyDetail(<%=model.OrderList[i].CustomerId %>,'<%=model.OrderList[i].CustomerName %>')">��ϸ</a></td>
                                        </tr>
                                        <%}
                                        %>
                                        <tr class="detailRow">
                                            <td>�ϼ�</td>
                                            <td>&nbsp;</td>
                                            <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(arrearage)%></td>
                                            <td>&nbsp;</td>
                                            <td > &nbsp;</td>
                                        </tr>
                                        <tr class="detailRow">
                                            <td colspan="5" style="text-align:right">
                                               <webdiyer:aspnetpager id="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" ></webdiyer:aspnetpager>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

