<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DiscountConcessionList.aspx.cs" Inherits="activities_DiscountConcessionList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>打折活动一览</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="../js/default.js"></script>
    <script type="text/javascript" language="javascript" src="../js/activities/DiscountConcession.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" style="width: 99%; background-color: #FFFFFF;" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11">
                        <img alt="" src="../../images/white_main_top_left.gif" /></td>
                    <td width="99%">
                        <img alt="" src="../../images/spacer_10_x_10.gif" height="10 /"></td>
                    <td width="10">
                        <img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="left" bgcolor="#eeeeee">
                                    首页&nbsp;-&gt;&nbsp;活动管理&nbsp;-&gt;&nbsp;打折活动一览</td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">
                                    打折活动一览</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                </td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th nowrap width="1%">NO</th>
                                            <th nowrap width="10%">所属营销活动</th>
                                            <th nowrap width="10%">方案名称</th>
                                            <th nowrap width="10%">冲值金额</th>
                                            <th nowrap>说明</th>
                                            <th nowrap width="10%">操作</th>
                                        </tr>
                                        <% foreach(Workflow.Da.Domain.DiscountConcession dc in model.DiscountList){ %>
                                        <tr class="detailRow">
                                            <td nowrap><%=dc.Id %></td>
                                            <td nowrap><%=dc.CampaignName %></td>
                                            <td nowrap><%=dc.Name %></td>
                                            <td nowrap><%=dc.ChargeAmount %></td>
                                            <td nowrap><%=dc.Memo %></td>
                                            <td>
                                            <a href="javascript:editRow(<%=dc.Id %>)">编辑</a>&nbsp;&nbsp;&nbsp;
                                            <a href="javascript:delRow(<%=dc.Id %>)">删除</a></td>
                                        <% } %>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                </td>
                            </tr>
                            <tr>
								<td width="3%"></td>
								<td align="right">
									<webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
								</td>
								<td width="3%"></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3">
                                </td>
                            </tr>
                            <tr height="5">
                                <td style="height: 5px">
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee" style="height: 5px">
                                    &nbsp;</td>
                                <td style="height: 5px">
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="11">
                        <img alt="" src="../../images/white_main_bottom_left.gif" /></td>
                    <td width="99%">
                        <img alt="" src="../../images/spacer_10_x_10.gif" /></td>
                    <td width="10">
                        <img alt="" src="../../images/white_main_bottom_right.gif" /></td>
                </tr>
            </table>
            <input id="delRow" name="delRow" type="hidden" value="" />
        </div>
    </form>
</body>
</html>
