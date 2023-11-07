<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchPayment.aspx.cs" Inherits="FinanceFindSearchPayment" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>客户付款明细</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" runat="server" action="" method="post">
        <div align="center" style="width: 100%" bgcolor="#ffffff" id="container">
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
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 客户付款明细</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">客户付款明细</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="3" cellspacing="1">
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">时间段:</td>
                                            <td class="item_content">
                                                <div>
                                                    <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" onfocus="setday(this);" readonly="readonly"/>&nbsp;至&nbsp;
                                                    <input id="txtTo" type="text" name="EndDateTime" class="datetexts" onfocus="setday(this);" readonly="readonly"/>
                                                <div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">客户名称:</td>
                                            <td align="left" class="item_content"><input name="CustomerName" class="texts" type="text" value="<%=model.CustomerName %>" /></td>
                                        </tr>
                                        <tr class="querybuttons">
                                            <td colspan="2" nowrap="nowrap"><asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="" Text="查询" /></td>
                                        </tr>
                                    </table>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td></td>
                                <td align="center"></td>
                                <td></td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                                            <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;付款日期&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>&nbsp;收款人&nbsp;</th>
                                            <th width="1%" nowrap="nowrap">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;付款金额&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;欠款金额&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th nowrap>备注</th>
                                        </tr>
                                        <%
                                            decimal amount = 0;
                                            decimal arrearage = 0;
                                            for (int i = 0; i < model.GatheringList.Count; i++)
                                            {
                                                amount += model.GatheringList[i].Amount;
                                                arrearage += model.GatheringList[i].Arrearage;
                                        %>
                                        <tr class="detailRow">
                                            <td align="center"> <%=i+1 %></td>
                                            <td align="center"><%=model.GatheringList[i].GatheringDateTime.ToString("yyyy-MM-dd")%></td>
                                            <td align="center"><%=model.GatheringList[i].UserName%></td>
                                            <td align="center"><%=model.GatheringList[i].Amount%></td>
                                            <td align="center"><%=model.GatheringList[i].Arrearage%></td>
                                            <td align="center"><%=model.GatheringList[i].Memo%></td>
                                        </tr>
                                        <%}
                                        %>
                                        <tr class="detailRow">
                                            <td align="center">合计</td>
                                            <td>&nbsp;</td>
                                            <td>&nbsp;</td>
                                            <td class="num"><%=amount %></td>
                                            <td class="num"><%=arrearage %></td>
                                            <td>&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">&nbsp;</td>
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
