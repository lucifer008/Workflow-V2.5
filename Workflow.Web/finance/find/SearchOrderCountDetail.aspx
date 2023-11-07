<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchOrderCountDetail.aspx.cs" Inherits="finance_find_SearchOrderCountDetail" %>

<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Workflow.Support" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>按照人员统计订单量明细</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/escExit.js"></script>
	<script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
	<script type="text/javascript" src="../../js/jquery.js"></script>
	<script type="text/javascript" src="../../js/default.js"></script>
	<script type="text/javascript" src="../../js/finance/find/searchOrderCountDetail.js"></script>
</head>
<body style="text-align: center">
    <form id="form1" action="" method="post" runat="server">
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
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 财务查询 -> 按照人员统计订单量明细</td>
                                <td ></td>
                            </tr>
                            <tr><td colspan="3" class="caption" align="center">按照人员统计订单量明细</td></tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center"></td>
                                <td width="3%"> &nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%"> &nbsp;</td>
                                <td align="center">
                                    
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="5%" nowrap> &nbsp;N&nbsp; O&nbsp;</th>
                                            <th width="15%" nowrap>订单号</th>
                                            <th width="20%" nowrap >开单日期</th>
										    <th width="20%" nowrap="nowrap">结算日期</th>
										    <th width="15%" nowrap="nowrap">参与制作雇员</th> 
										    <th width="15%" nowrap="nowrap">岗位</th> 
										    <th width="15%" nowrap="nowrap">开单量</th> 
										</tr>
										<%  decimal total = 0;
										    for(int i=0;i<model.EmployeeList.Count;i++){ %>
										<tr>
										    <td><%=i+1 %></td>
										    <td><a href="#" onclick="orderDetail(this)"><%=model.EmployeeList[i].OrderNo %></a></td>
										    <td><%=model.EmployeeList[i].InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
										    <td><%=model.EmployeeList[i].BalanceDateTime.ToString("yyyy-MM-dd HH:mm") %></td>
										    <td><%=model.EmployeeList[i].Name %></td>
										    <td><%=model.EmployeeList[i].PositionName%></td>
										    <%
                                                long poitionId =Constants.POSITION_PROPHASE_VALUE(ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId);
                                                if (poitionId == model.EmployeeList[i].Positionid)
                                                {
                                                    total += Math.Round(model.EmployeeList[i].PhophaseNum, 2);
                                             %>
										   <td><%=Math.Round(model.EmployeeList[i].PhophaseNum, 2)%></td>
										    <%}
                                            else
                                            {
                                                total +=model.EmployeeList[i].AnaphseNum;
                                            %>
                                                <td><%=model.EmployeeList[i].AnaphseNum%></td>
                                            <%} %>
										</tr>
										<%} %>
										<tr>
										    <td>当页合计</td><td align="center" colspan="6"><%=total%></td>
										</tr>
                                        <tr class="detailRow">
                                           <td bgcolor="#eeeeee" align="right" colspan="7">
                                               <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                               </webdiyer:AspNetPager>
                                           </td>
                                        </tr>
                                    </table>
                                </td>
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
