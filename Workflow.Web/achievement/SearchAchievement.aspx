<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchAchievement.aspx.cs"
    Inherits="SearchAchievement" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>绩效查询</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/Calendar2.js"></script>
    <script type="text/javascript" src="../js/checkCalendar.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/check.js"></script>
	<script type="text/javascript" src="../js/jquery.js"></script>
	<script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/achinevement/searchachievement.js"></script>
</head>
<%--scroll="no"--%>
<body  style="text-align: center">
    <form id="form1" runat="server">
    <input type="hidden" id="hiddPositionId" name="hiddPositionId" runat="server" />
    <input type="hidden" id="hiddPositionList" name="hiddPositionList" runat="server" />
    <input type="hidden" id="hiddEmployeeList" name="hiddEmployeeList" runat="server" />
    <div align="center" style="width:99%" bgcolor="#ffffff" id="container">
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
                                        <td align="left" bgcolor="#eeeeee">首页 -&gt; 业绩管理 -&gt; 绩效查询</td>
                                        <td></td>
                                    </tr>
                                    <tr><td colspan="3" class="caption" align="center">绩效查询</td></tr>
                                    <tr>
                                        <td width="3%">&nbsp;</td>
                                        <td align="center">
                                            <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                                <tr>
                                                    <td nowrap="nowrap" class="item_caption">结算时间</td>
                                                    <td class="item_content">
                                                        <%--<div>--%>
                                                            <input id="txtBeginDateTime" name="BeginDateTime" readonly="readonly" type="text" class="datetexts" onfocus="setday(this)" size="11" runat="server"/>&nbsp;至&nbsp;
                                                            <input id="txtTo" type="text" name="EndDateTime" readonly="readonly" class="datetexts" onfocus="setday(this)" size="11" runat="server"/>
                                                       <%-- </div>--%>
                                                    </td>
                                                    <td nowrap="nowrap" class="item_caption">订单号</td>
                                                     <td class="item_content"><input id="txtOrderNo" name="txtOrderNo" type="text" /></td>
                                                </tr>
                                                <tr>
                                                    <td nowrap="nowrap" class="item_caption" style="width: 9%">部门</td>
                                                    <td class="item_content">
                                                        <select name="sltPosition" size="5" onclick="SearchPostionPerson()">
                                                        <%for (int i = 0; i < model.PositionList.Count; i++){%> 
                                                            <option value="<%=model.PositionList[i].Id %>"><%=model.PositionList[i].Name%></option>
                                                         <%}%>

                                                        </select>
                                                        <input name="clearPostion" type="button" value="清空"/>
                                                    </td>
                                                    <td nowrap="nowrap" class="item_caption" style="width: 7%"> 员工</td>
                                                    <td class="item_content">
                                                        <select id="Employee" name="sltEmployee" size="5" multiple="multiple">
                                                        <%for (int i = 0; i < model.EmployeeList.Count; i++){%> 
                                                            <option value="<%=model.EmployeeList[i].Employeeid %>"><%=model.EmployeeList[i].Name%></option>
                                                         <%}%>
                                                        </select>
                                                        <input name="clearEmployee" type="button" class="buttons" value="清空" onclick="clearEmplSelected()" />
                                                    </td>
                                                </tr>
                                                <tr class="querybuttons">
                                                    <td colspan="4" nowrap="nowrap"><asp:Button ID="btnSearch" CssClass="buttons" runat="server" Text="查询" OnClick="Search" OnClientClick="return DataCheck();"/>&nbsp;<asp:Button ID="btnDispatchPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnDispatchPrint_Click"/></td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="3%">&nbsp;</td>
                                    </tr>
                                    <tr class="emptyButtonsUpperRowHight">
                                        <td width="3%"></td>
                                        <td align="center"></td>
                                        <td width="3%"></td>
                                    </tr>
                                    <tr>
                                        <td width="3%"> &nbsp;</td>
                                        <td align="center">
                                            <table width="100%" border="1" cellpadding="3" cellspacing="1">
                                                <tr>
                                                    <th width="3%" align="center" nowrap="nowrap"> &nbsp;NO&nbsp;</th>
                                                    <th width="10%" align="center" nowrap="nowrap">订单号</th>
                                                    <th width="10%" align="center" nowrap="nowrap">加工内容</th>
                                                    <th width="20%" align="center" nowrap="nowrap">客户</th>                                        
                                                    <th width="10%" align="center" nowrap="nowrap">参与制作的岗位</th>
                                                    <th width="10%" align="center" nowrap="nowrap">雇员</th>
                                                    <th width="5%" align="center" nowrap="nowrap">开单人</th>
                                                    <th width="10%" align="center" nowrap="nowrap">结算时间</th>
                                                    <th width="20%" align="center" nowrap="nowrap">绩效</th>
                                                </tr>
                                                <%
                                                    decimal sumAmount = 0;
                                                    for (int i = 0; i < model.AchievementList.Count; i++)
                                                    {%>
                                                        <tr class="detailRow">
                                                            <td align="center"><%=i+1 %></td>
                                                            <td align="left"><a href="#" onclick="orderDetail('<%=model.AchievementList[i].No%>')"><%=model.AchievementList[i].No%></a></td>
                                                            <td align="left" class="td_name"><%=model.AchievementList[i].ProcessName%></td>
                                                            <td align="left" class="td_name"><%=model.AchievementList[i].CustomerName%></td>
                                                            <td align="left" class="td_department"><%=model.AchievementList[i].PositionName%></td>
                                                            <td align="left" class="td_department"><%=model.AchievementList[i].EmployeeName%></td>
                                                            <td align="center" class="td_name"><%=model.AchievementList[i].NewOrderName%></td>
                                                            <td align="center" nowrap="nowrap" class="td_datetime"><%=Convert.ToDateTime(model.AchievementList[i].InserDateTimeStrings).ToString("yyyy-MM-dd HH:mm")%></td>
                                                            <td align="right" class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.AchievementList[i].AchievementValue)%></td>
                                                        </tr>
                                                    <%
                                                        sumAmount += model.AchievementList[i].AchievementValue;
                                                    }
                                                    
                                                %>

                                                <tr>
                                                    <td nowrap="nowrap">合计:</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td>&nbsp;</td>
                                                    <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(sumAmount) %></td>
                                                </tr>
                                                 <tr>
                                                     <td bgcolor="#eeeeee" align="right" colspan="9">
                                                     <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                                     </webdiyer:AspNetPager>
                                                     </td>
                                               </tr>
                                            </table>
                                        </td>
                                        <td width="3%">&nbsp;</td>
                                    </tr>
                                    <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
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
