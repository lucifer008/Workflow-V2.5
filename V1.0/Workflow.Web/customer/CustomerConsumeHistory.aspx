<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CustomerConsumeHistory.aspx.cs" Inherits="CustomerConsumeHistory" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>�ͻ�������ʷ</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
	<script type="text/javascript" src="../js/default.js"></script>
	<script type="text/javascript" src="../js/escExit.js"></script>
	 <script type="text/javascript" src="../js/customer/customerConsumeHistory.js"></script>
</head>
<body style="text-align: center">
<form id="form1" runat="server" method="get">
    <div align="center" style="width: 100%" id="container">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
            <tr>
                <td width="11"><img alt="" src="../images/white_main_top_left.gif" /></td>
                <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10" /></td>
                <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
            </tr>
            <tr>
                <td colspan="3" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellspacing="0" cellpadding="0">
                        <tr>
                            <td width="3%"></td>
                            <td align="left" bgcolor="#eeeeee">��ҳ -&gt; �ͻ����� -&gt; �ͻ�������ʷ</td>
                            <td width="3%"></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption">�ͻ�������ʷ</td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="left">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                    <tr>
                                        <td nowrap class="item_caption">�ͻ�����</td>
                                        <td class="item_content"><%= CustomerName%></td>
                                    </tr>
                                </table>
                            </td>
                            <td width="3%">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="center">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                    <tr>
                                        <th width="5%" nowrap align="center"> &nbsp;NO&nbsp;</th>
                                        <th width="10%" nowrap align="center">������</th>
                                        <th width="10%" nowrap align="center">��ϵ��</th>
                                        <th width="10%" nowrap align="center">������</th>
                                        <th width="20%" nowrap align="center">����ʱ��</th>
                                        <th width="20%" nowrap align="center">����ʱ��</th>
                                        <th width="20%" nowrap align="center">���ѽ��</th>
                                        <th nowrap align="center" width="20%">��ע</th>
                                    </tr>
                                    <%
                                            for (int i = 1; i <= model.OrderList.Count; i++)
                                            {
                                                Workflow.Da.Domain.Order order = model.OrderList[i - 1];
                                         %>
                                    <tr class="detailRow">
                                        <td align="center" nowrap><%= i%></td>
                                        <td nowrap align="center"><a href="#" onclick="orderDaitl(this)"><%= order.No%></a></td>
                                        <td nowrap align="left"><%= order.Name%></td>
                                        <td nowrap align="center"><%= order.ProjectName%></td>
                                        <td align="center" nowrap><%= order.InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                                        <td align="center" nowrap><%= order.BalanceDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                                        <td nowrap align="left"><%= Workflow.Util.NumericUtils.ToMoney(order.SumAmount)%></td>
                                        <td nowrap align="left"><%= order.Memo%></td>
                                    </tr>
                                    <% }%>
                                   
                                     <tr>
                                         <td colspan="8" align="right">
                                             <webdiyer:aspnetpager id="AspNetPager1" runat="server" onpagechanging="AspNetPager1_PageChanging"></webdiyer:aspnetpager>&nbsp;</td>
				                      </tr>
                                </table>
                            </td>
                            <td width="3%">&nbsp;</td>
                        </tr>
                        <tr class="emptyButtonsUpperRowHight">
                            <td colspan="3"></td>
                        </tr>
                        <tr height="5">
                            <td width="3%"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            <td bgcolor="#eeeeee">&nbsp;</td>
                            <td width="3%"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
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
