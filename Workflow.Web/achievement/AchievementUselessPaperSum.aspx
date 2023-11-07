<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AchievementUselessPaperSum.aspx.cs"
    Inherits="AchievementUselessPaperSum" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/usercontrols/DateNavigate.ascx" TagName="DateNavigate" TagPrefix="dn" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>员工业绩统计</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link href="../css/DateNavigate.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Calendar2.js"></script>
    <script type="text/javascript" src="../js/checkCalendar.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/check.js"></script>
	<script type="text/javascript" src="../js/jquery.js"></script>
	<script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/achinevement/achievementuselesspapersum.js"></script>
</head>
<%--scroll="no"--%>
<body  style="text-align: center">
    <form id="form" action="" method="post" runat="server">
    <input type="hidden" id="hiddPositionList" name="hiddPositionList" runat="server" />
    <input type="hidden" id="hiddEmployeeList" name="hiddEmployeeList" runat="server" />
    <input type="hidden" id="hidAction" name="action" runat="server"/>
    <input id="hidDate" name="date" type="hidden" value="0" runat="server"/>
    <input id="actionTag" name="actionTag" type="hidden" value="F" runat="server"/>
    <input id="hidBeginDateTime" type="hidden" runat="server" />
    <input id="hidEndDateTime" type="hidden" runat="server" />
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
                                            <td align="left" bgcolor="#eeeeee">首页 -&gt; 业绩管理 -&gt; 员工业绩统计</td>
                                            <td></td>
                                        </tr>
                                        <tr>
                                            <td colspan="3" class="caption" align="center">员工业绩统计</td>
                                        </tr>
                                        <tr>
                                            <td width="3%">&nbsp;</td>
                                            <td align="left">
                                                <dn:DateNavigate ID="dateNavigate" runat="server" />
                                                <div>
                                                 <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">结算时间</td>
                                                        <td colspan="3" class="item_content">
                                                            <div>
                                                                <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts" onfocus="setday(this);" readonly="readonly" runat="server" size="11" value="" />
                                                                &nbsp;至 &nbsp;
                                                                <input id="txtTo" type="text" name="EndDateTime" class="datetexts" onfocus="setday(this);" readonly="readonly" value="" runat="server" size="11" />
                                                           </div>                                                  
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap="nowrap" class="item_caption">部门</td>
                                                        <td class="item_content">
                                                            <select name="sltPosition" size="5" onclick="SearchPostionPerson()">
                                                            <%
                                                                for (int i = 0; i < model.PositionList.Count; i++)
                                                                {
                                                                    %> 
                                                                    <option value="<%=model.PositionList[i].Id %>"><%=model.PositionList[i].Name%></option>
                                                                    <%
                                                                }
                                                            %>
                                                            </select>
                                                            <input type="button" class="buttons" value="清空" onclick="clearPosSelected()" />
                                                        </td>
                                                        <td nowrap="nowrap" class="item_caption">员工</td>
                                                        <td class="item_content">
                                                            <select name="sltEmployee" size="5" multiple="multiple">
                                                           <%for (int i = 0; i < model.EmployeeList.Count; i++){%> 
                                                                <option value="<%=model.EmployeeList[i].Employeeid %>"><%=model.EmployeeList[i].Name%></option>
                                                             <%}%>
                                                            </select>
                                                            <input type="button" class="buttons" value="清空" onclick="clearEmplSelected()" />
                                                        </td>
                                                    </tr>
                                                    <tr class="querybuttons">
                                                        <td colspan="4" nowrap="nowrap">
                                                        <asp:Button ID="btnSearch" CssClass="buttons" runat="server" Text="查询" OnClick="Search"  OnClientClick="return checkQueryCondition();" />&nbsp;
                                                        <asp:Button ID="btnDispPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnDispPrint_Click"/>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
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
                                                        <th width="10%" align="center" nowrap="nowrap">绩效</th>
                                                        <th width="10%" align="center" nowrap="nowrap">废稿</th>
                                                        <th align="center" nowrap="nowrap">&nbsp;</th>
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
                                                                <td align="center" class="td_name"><%=model.AchievementList[i].EmployeeName %></td>
                                                                <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.AchievementList[i].AchievementValue) %></td>
                                                                <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.AchievementList[i].TrashPaper) %></td>
                                                                <td width="1%" nowrap="nowrap"><input type="hidden" name="EmployeeId" value="<%=model.AchievementList[i].EmployeeId %>" />
                                                                    <a href="#" onclick="showDetail(this);">详情</a></td>
                                                            </tr>
                                                        <%}
                                                    %>
                                                    

                                                    <tr>
                                                        <td nowrap="nowrap" bgcolor="#FFFFFF">合计:</td>
                                                        <td bgcolor="#FFFFFF" class="td_name">&nbsp;</td>
                                                        <td bgcolor="#FFFFFF" class="num"><%=Workflow.Util.NumericUtils.ToMoney(achievementValue) %></td>
                                                        <td bgcolor="#FFFFFF" class="num"><%=Workflow.Util.NumericUtils.ToMoney(trashPaperValue) %></td>
                                                        <td bgcolor="#FFFFFF">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                         <td bgcolor="#eeeeee" align="right" colspan="5">
                                                         <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging" onclick="pagerCheck();">
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