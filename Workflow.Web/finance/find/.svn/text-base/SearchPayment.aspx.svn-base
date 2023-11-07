<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchPayment.aspx.cs" Inherits="FinanceFindSearchPayment" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>客户付款明细</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
	<script type="text/javascript" src="/js/jquery.js"></script>
	<script type="text/javascript" src="/js/default.js"></script>
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
                                                    <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" onfocus="setday(this);" value="<%=model.BalanceDateTimeString %>" readonly="readonly"/>&nbsp;至&nbsp;
                                                    <input id="txtTo" type="text" name="EndDateTime" class="datetexts" onfocus="setday(this);" value="<%=model.InsertDateTimeString %>" readonly="readonly"/>
                                                <div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">客户名称:</td>
                                            <td align="left" class="item_content"><input name="CustomerName" class="texts" type="text" value="<%=model.CustomerName %>" /></td>
                                        </tr>
                                        <tr class="querybuttons">
                                            <td colspan="2" nowrap="nowrap"><asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="" Text="查询" />
												<asp:Button ID="Button1" CssClass="buttons" runat="server" OnClick="Print" OnClientClick="" Text="打印" /></td>
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
                                            <th width="7%" nowrap>NO</th>
                                            <th width="10%">订单号</th>
                                            <th width="10%" nowrap>付款日期</th>
                                            <th width="10%" nowrap>收款人</th>
                                            <th width="10%" nowrap>付款金额</th>
                                            <th width="15%">付款类型</th>
                                            <th width="35%">备注</th>
                                        </tr>
                                        <%
                                            for (int i = 0; i < model.GatheringList.Count; i++)
                                            {
                                        %>
                                        <tr class="detailRow">
                                            <td align="center"> <%=i+1 %></td>
                                            <td><%=model.GatheringList[i].OrderNo%></td>
                                            <td><%=model.GatheringList[i].GatheringDateTime.ToString("yyyy-MM-dd")%></td>
                                            <td><%=model.GatheringList[i].UserName%></td>
                                            <td><%=model.GatheringList[i].Amount%></td>
                                            <td><%=Workflow.Support.Constants.GetPayKindLabel(model.GatheringList[i].PayKind.Trim())%></td>
                                            <td><%=model.GatheringList[i].Memo%></td>
                                        </tr>
                                        <%}
                                        %>
                                        <tr class="detailRow">
                                            <td align="center">合计</td>
                                            <td></td>
                                            <td></td>
                                            <td></td>
                                            <td class="num"><%=model.SunAmount%></td>
                                            <td></td>
                                            <td></td>
                                        </tr>
                                        <tr>
										 <td bgcolor="#eeeeee" colspan="7" align="right">
											   <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
												</webdiyer:AspNetPager>
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
