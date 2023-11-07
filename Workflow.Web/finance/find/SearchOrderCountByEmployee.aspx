<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchOrderCountByEmployee.aspx.cs" Inherits="finance_find_SearchOrderCountByEmployee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>按人员统计订单量</title>
     <link href="../../css/css.css" rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
	<script type="text/javascript" src="../../js/jquery.js"></script>
	<script type="text/javascript" src="../../js/default.js"></script>
	<script type="text/javascript" src="../../js/finance/find/searchOrderCountByEmployee.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
        <input type="hidden" id="queryString" name="queryString" value="" runat="server"/>
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table border="0" cellspacing="0" cellpadding="0" width="100%" heigth="100%">
                            <tr><td ></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 按人员统计开单量</td>
                                <td ></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">按人员统计开单量</td></tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="0" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td align="left" bgcolor="#FFFFFF">
                                                <table width="100%" border="1" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                      <td nowrap class="item_caption">岗位</td>
                                                      <td class="item_content">
                                                        <select id="sltPosition" name="position" onchange="SearchPostionPerson()">
                                                       <%-- <option value="-1">请选择</option>--%>
                                                        <%for (int i = 0; i < model.PositionList.Count;i++ )
                                                          { %>
                                                            <option value="<%=model.PositionList[i].Id %>"><%=model.PositionList[i].Name%></option>
                                                        <%} %>
                                                        </select>
                                                       </td>
                                                      <td nowrap class="item_caption">雇员</td>
                                                      <td class="item_content">
                                                        <select id="sltEmployee" name="employee" multiple="multiple">
                                                        <%for (int i = 0; i < model.EmployeeList.Count;i++ )
                                                          { %>
                                                            <option value="<%=model.EmployeeList[i].Id %>"><%=model.EmployeeList[i].Name%></option>
                                                        <%}%>
                                                        </select>
                                                        <input type="button" id="btnClear" value="清空" onclick="clearSelectedEmployee()" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td nowrap class="item_caption" align="center">结算时间</td>
                                                        <td class="item_content" colspan="3">
                                                            <div>
                                                                <input id="txtBeginDateTime" name="BeginDateTime" type="text" class="datetexts"  onfocus="setday(this);" size="16" runat="server" readonly="readOnly" />
                                                                至 &nbsp;&nbsp;&nbsp;&nbsp;
                                                                <input id="txtTo" type="text" name="EndDateTime" class="datetexts" runat="server" onfocus="setday(this);" size="16" readonly="readOnly" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="4" align="right">
                                                            <input type="submit" class="buttons" value="查询" id="btnSearch" name="search" runat="server" onclick="getPrintDataQueryCondition()" onserverclick="btnSearch_ServerClick"/>
                                                            <input type="submit" class="buttons" value="打印" id="btnPrint" name="print" runat="server" onserverclick="btnPrint_ServerClick"/>
                                                        </td>
                                                   </tr>
                                                </table>
                                            </td>
										</tr>
                                    </table>
                                </td>
                                <td width="3%"> &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="11%" nowrap >NO</th>
                                            <th width="11%" nowrap >雇员</th>
										    <th width="11%" nowrap="nowrap">岗位</th>
										    <th width="11%" nowrap="nowrap">开单量</th>
										    <th width="11%" nowrap="nowrap">备注</th>
										    <th width="11%" nowrap="nowrap"></th>
                                        </tr>
                                        <%
                                          if (null != model.OtherEmployeeList)
                                          {
                                              int index = 0; 
                                              decimal count = 0; 
                                              for (int i = 0; i < model.OtherEmployeeList.Count; i++)
                                              {
                                                  index++;
                                              %>
                                            <tr class="detailRow">
                                                <td><%=index%></td>
                                                <td><%=model.OtherEmployeeList[i].Name%></td>
                                                <td><%=model.OtherEmployeeList[i].PositionName%></td>
                                                <%
                                                long poitionId = Workflow.Support.Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
                                                if (poitionId == model.OtherEmployeeList[i].Positionid)
                                                {
                                                    count += Math.Round(model.OtherEmployeeList[i].PhophaseNum, 2);
                                                         %>
                                                    <td><%=Math.Round(model.OtherEmployeeList[i].PhophaseNum, 2)%></td>
                                                <%
                                                }
                                                else
                                                {
                                                    count += model.OtherEmployeeList[i].AnaphseNum;
                                                         %>
                                                     <td><%=model.OtherEmployeeList[i].AnaphseNum%></td>
                                                    <%
                                                } %>
                                                <td>
                                                    <input type="hidden" name="employeeId" value="<%=model.OtherEmployeeList[i].Employeeid %>" />
                                                    <input type="hidden" name="positionId" value="<%=model.OtherEmployeeList[i].Positionid %>" />
                                                </td>
                                                <td><a href="#" onclick="showDetail(this)">明细</a></td>
                                            </tr>
                                            <%
                                              }%>
                                              <tr class="detailRow"><td align="center">合计</td><td colspan="4"><%=count %></td></tr>
                                            <tr class="detailRow">
                                               <td colspan="5" align="right">
                                                  <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging"></webdiyer:AspNetPager>
                                               </td>
                                            </tr>
                                      <%} %>
                                    </table>
                                </td>
                                 <td width="3%"> &nbsp;</td>
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
