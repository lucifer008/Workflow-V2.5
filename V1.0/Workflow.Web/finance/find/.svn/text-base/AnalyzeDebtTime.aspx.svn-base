<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AnalyzeDebtTime.aspx.cs"
    Inherits="FinanceAnalyzeDebtTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>帐龄分析</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../../css/calendar-blue.css" type="text/css" />
    <script type="text/javascript" src="../../js/Calendar2.js"></script>
	<script type="text/javascript" src="../../js/checkCalendar.js"></script>
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
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
                                <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 帐龄分析</td>
                                <td></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">帐龄分析</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">查询周期:</td>
                                            <td class="item_content">
                                                <div>
                                                    <input id="txtBeginDateTime" name="BeginDateTime" onfocus="setday(this);" type="text" class="datetexts" readonly="readonly"/>&nbsp;至 &nbsp;
                                                    <input id="txtTo" type="text"  onfocus="setday(this);" class="datetexts" readonly="readonly"/>
                                                </div>
                                               
                                            </td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                关键字:</td>
                                            <td class="item_content">
                                                <input name="txtKey" type="text" class="texts" value="<%=findFinanceAction.Model.CustomerName %>" />
                                                客户全称、简称，或简称的简拼，或会员卡号</td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">
                                                经手人:</td>
                                            <td class="item_content">
                                                <select name="casherEmployee">
                                                    <option value="<%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_KEY %>" selected="selected">
                                                        <%=Workflow.Support.Constants.SELECT_VALUE_NOT_SELECTED_TEXT%>
                                                    </option>
                                                    <%
                                                        for (int i = 0; i < findFinanceAction.Model.EmployeeList.Count; i++)
                                                        {
                                                            if (findFinanceAction.Model.EmployeeId == findFinanceAction.Model.EmployeeList[i].Employeeid)
                                                            {
                                                            %>
                                                            <option value="<%=findFinanceAction.Model.EmployeeList[i].Employeeid %>" selected="selected">
                                                                <%=findFinanceAction.Model.EmployeeList[i].Name%>
                                                            </option>
                                                            
                                                            <%}
                                                              else
                                                              {%>
                                                                <option value="<%=findFinanceAction.Model.EmployeeList[i].Employeeid %>">
                                                                    <%=findFinanceAction.Model.EmployeeList[i].Name%>
                                                                </option>
                                                              <%}
                                                          
                                                       }
                                                    %>
                                                </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2" align="right">
                                                <asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick=""
                                                    Text="查询" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td>
                                    查询结果:</td>
                            </tr>
                            <tr>
                                <td width="3%">
                                    &nbsp;</td>
                                <td align="center" style="padding-bottom: 5px">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th width="1%" nowrap>
                                                &nbsp;NO&nbsp;</th>
                                            <th nowrap>
                                                客户名称</th>
                                            <th width="1%" nowrap>
                                                10天内</th>
                                            <th width="1%" nowrap>
                                                10-30天</th>
                                            <th width="1%" nowrap>
                                                30-60天</th>
                                            <th width="1%" nowrap>
                                                60-90天&nbsp;</th>
                                            <th width="1%" nowrap>
                                                90-120天</th>
                                            <th width="1%" nowrap>
                                                &nbsp;&nbsp;&nbsp;&nbsp;合计&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                        </tr>
                                        <%decimal ten = 0;
                                          decimal thirty = 0;
                                          decimal sixty = 0;
                                          decimal ninty = 0;
                                          decimal hundred = 0;
                                          if (null != findFinanceAction.Model.OrderList)
                                          {
                                              for (int i = 0; i < findFinanceAction.Model.OList.Count; i++)
                                              {
                                                  decimal sum = 0;
                                        %>
                                        <tr class="detailRow">
                                            <td>
                                                <%=i+1 %>
                                            </td>
                                            <td align="left"><a href="#" onclick="customerDetail(this);">
                                                <%=findFinanceAction.Model.OList[i].CustomerName%></a><input type="hidden" name="txtCustomerId" value="<%=findFinanceAction.Model.OList[i].Id %>" />
                                            </td>
                                            <td>
                                                <%string m = "0.00";
                                                  for (int j = 0; j < findFinanceAction.Model.OrderList.Count; j++)
                                                  {
                                                      if (findFinanceAction.Model.OList[i].Id == findFinanceAction.Model.OrderList[j].Id)
                                                      {
                                                          if (findFinanceAction.Model.OrderList[j].Days == 10)
                                                          {
                                                              m = findFinanceAction.Model.OrderList[j].SumAmount.ToString("#.00");
                                                              ten += findFinanceAction.Model.OrderList[j].SumAmount;
                                                              break;
                                                          }
                                                      }
                                                  }
                                                  sum += decimal.Parse(m);
                                                %>
                                                <%Response.Write(m); %>
                                            </td>
                                            <td>
                                                <%m = "0.00";
                                                  for (int j = 0; j < findFinanceAction.Model.OrderList.Count; j++)
                                                  {
                                                      if (findFinanceAction.Model.OList[i].Id == findFinanceAction.Model.OrderList[j].Id)
                                                      {
                                                          if (findFinanceAction.Model.OrderList[j].Days == 30)
                                                          {
                                                              m = findFinanceAction.Model.OrderList[j].SumAmount.ToString("#.00");
                                                              thirty += findFinanceAction.Model.OrderList[j].SumAmount;
                                                              break;
                                                          }
                                                      }
                                                  }
                                                  sum += decimal.Parse(m);
                                                %>
                                                <%Response.Write(m); %>
                                            </td>
                                            <td>
                                                <%m = "0.00";
                                                  for (int j = 0; j < findFinanceAction.Model.OrderList.Count; j++)
                                                  {
                                                      if (findFinanceAction.Model.OList[i].Id == findFinanceAction.Model.OrderList[j].Id)
                                                      {
                                                          if (findFinanceAction.Model.OrderList[j].Days == 60)
                                                          {
                                                              m = findFinanceAction.Model.OrderList[j].SumAmount.ToString("#.00");
                                                              sixty += findFinanceAction.Model.OrderList[j].SumAmount;
                                                              break;
                                                          }
                                                      }
                                                  }
                                                  sum += decimal.Parse(m);
                                                %>
                                                <%Response.Write(m); %>
                                            </td>
                                            <td>
                                                <% m = "0.00";
                                                   for (int j = 0; j < findFinanceAction.Model.OrderList.Count; j++)
                                                   {
                                                       if (findFinanceAction.Model.OList[i].Id == findFinanceAction.Model.OrderList[j].Id)
                                                       {
                                                           if (findFinanceAction.Model.OrderList[j].Days == 90)
                                                           {
                                                               m = findFinanceAction.Model.OrderList[j].SumAmount.ToString("#.00");
                                                               ninty += findFinanceAction.Model.OrderList[j].SumAmount;
                                                               break;
                                                           }
                                                       }
                                                   }
                                                   sum += decimal.Parse(m);
                                                %>
                                                <%Response.Write(m); %>
                                            </td>
                                            <td>
                                                <%m = "0.00";
                                                  for (int j = 0; j < findFinanceAction.Model.OrderList.Count; j++)
                                                  {
                                                      if (findFinanceAction.Model.OList[i].Id == findFinanceAction.Model.OrderList[j].Id)
                                                      {
                                                          if (findFinanceAction.Model.OrderList[j].Days == 120)
                                                          {
                                                              m = findFinanceAction.Model.OrderList[j].SumAmount.ToString("#.00");
                                                              hundred += findFinanceAction.Model.OrderList[j].SumAmount;
                                                              break;
                                                          }
                                                      }
                                                  }
                                                  sum += decimal.Parse(m);
                                                %>
                                                <%Response.Write(m); %>
                                            </td>
                                            <td>
                                                <%=sum %>
                                            </td>
                                        </tr>
                                        <%}
                                      }
                                        %>
                                        <tr>
                                            <td>
                                                合计</td>
                                            <td>
                                            </td>
                                            <td>
                                                <%=ten %>
                                            </td>
                                            <td>
                                                <%=thirty %>
                                            </td>
                                            <td>
                                                <%=sixty %>
                                            </td>
                                            <td>
                                                <%=ninty %>
                                            </td>
                                            <td>
                                                <%=hundred %>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="3%">
                                    &nbsp;</td>
                            </tr>
                            <tr height="5">
                                <td>
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">
                                    &nbsp;</td>
                                <td>
                                    <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF">
                        <img alt="" src="../../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12">
                        <img alt="" src="../../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    function customerDetail(o)
    {
        var customerId=$($("input[@name='txtCustomerId']",$(o).parent().parent())).val();
        showPage('../../customer/CustomerDetail.aspx?Id='+customerId, null, 800, 550, false, true);
    }
</script>
