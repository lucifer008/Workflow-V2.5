<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AchievementShoperOrManagerSum.aspx.cs" Inherits="achievement_SearchAchievementShoperOrManagerSum" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>店长经理绩效统计</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Calendar2.js"></script>
    <script type="text/javascript" src="../js/checkCalendar.js" charset="utf-8"></script>
   <script type="text/javascript" src="../js/check.js"></script>
	<script type="text/javascript" src="../js/jquery.js"></script>
	<script type="text/javascript" src="../js/default.js"></script>
	<script type="text/javascript" src="../js/achinevement/achievementShoperOrManagerSum.js"></script>
</head>
<body  style="text-align: center">
    <form id="form" action="" method="post" runat="server">
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
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
                                <td bgcolor="#FFFFFF">
                                    <table width="100%" border="0" cellspacing="0">
                                        <tr>
                                            <td></td>
                                            <td align="left" bgcolor="#eeeeee">首页 -&gt; 绩效管理 -&gt; 店长经理绩效统计</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" class="caption" align="center">店长经理绩效统计</td>
                                        </tr>
                                        <tr>
                                            <td width="3%">&nbsp;</td>
                                            <td align="center">
                                                <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">结算月份</td>
                                                        <td colspan="3" class="item_content">
                                                            <div>
                                                               <input id="txtMonthPaperDateTime" name="txtDailyPaperDateTime" type="text" class="datetexts"  size="16" onfocus="setday(this,this,true,false);" runat="server" readonly="readOnly" />
                                                           </div>                                                  
                                                        </td>
                                                    </tr>
                                                    <tr class="querybuttons">
                                                        <td colspan="4" nowrap="nowrap">
                                                        <asp:Button ID="btnSearch" CssClass="buttons" runat="server" Text="查询" OnClick="Search"  OnClientClick="return DataCheck();" />&nbsp;
                                                        <asp:Button ID="btnDispPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnDispPrint_Click"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td width="3%"> &nbsp;</td>
                                        </tr>
                                        <tr class="emptyButtonsUpperRowHight">
                                            <td width="3%"></td>
                                            <td align="center"></td>
                                            <td width="3%"></td>
                                        </tr>
                                        <tr>
                                            <td width="3%">&nbsp;</td>
                                            <td align="center">
                                                <table width="100%" border="1" cellpadding="3" cellspacing="1">
                                                    <tr>
                                                        <th width="5%" align="center" nowrap="nowrap">&nbsp;NO&nbsp;</th>
                                                        <th width="10%" align="center" nowrap="nowrap">员工</th>
                                                        <th width="10%" align="center" nowrap="nowrap">职位</th>
                                                        <th width="10%" align="center" nowrap="nowrap">绩效</th>
                                                        <th width="10%" align="center" nowrap="nowrap">废稿</th>
                                                        <%--<th width="10%" align="center" nowrap="nowrap"></th>--%>
                                                    </tr>
                                                    <%
                                                        decimal achievementValue = 0;
                                                        decimal trashPaperValue = 0;
                                                        for (int i = 0; i < model.AchievementList.Count; i++)
                                                        {
                                                            achievementValue += model.AchievementList[i].AchievementValue;
                                                            trashPaperValue += model.AchievementList[i].TrashPaper;
                                                            %>
                                                            <tr class="detailRow">
                                                                <td align="center"><%=i+1 %></td>
                                                                <td align="center" class="tdEmployeeName"><%=model.AchievementList[i].EmployeeName %></td>
                                                                <td align="center" class="tdPositionName"><%=model.AchievementList[i].PositionName %></td>
                                                                <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.AchievementList[i].AchievementValue) %></td>
                                                                <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.AchievementList[i].TrashPaper) %></td>
                                                                <%--<td width="10%" align="center" nowrap="nowrap"><a href="#" onclick="showAchievementDetail(this)">详情</a></td>--%>
                                                            </tr>
                                                        <%}
                                                    %>
                                                    

                                                    <tr>
                                                        <td nowrap="nowrap" bgcolor="#FFFFFF">合计:</td>
                                                        <td bgcolor="#FFFFFF" class="td_name">&nbsp;</td>
                                                        <td bgcolor="#FFFFFF">&nbsp;</td>
                                                        <td bgcolor="#FFFFFF" class="num"><%=Workflow.Util.NumericUtils.ToMoney(achievementValue) %></td>
                                                        <td bgcolor="#FFFFFF" class="num"><%=Workflow.Util.NumericUtils.ToMoney(trashPaperValue) %></td>
                                                        <%--<td bgcolor="#FFFFFF">&nbsp;</td>--%>
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
