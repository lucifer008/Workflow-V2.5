<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdjustAchievement.aspx.cs" Inherits="AdjustAchievement" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <title>绩效调整</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/calendar-blue.css" type="text/css" />
    <script type="text/javascript" src="../js/checkCalendar.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/check.js"></script>
    <script type="text/javascript" src="../js/math.js"></script>
    <script type="text/javascript" src="../js/achinevement/adjustAchievement.js"></script>
</head>
<body style="text-align: center">
  <form id="form" action="" method="post" runat="server">
  <input id="hiddItemId" name="edmitItemId" type="hidden" value="" runat="server"/>
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
        <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="ffffff">
            <tr>
                <td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
                <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
                <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
            </tr>
            <tr>
                <td colspan="3" bgcolor="#FFFFFF">
                    <table width="100%" border="0" cellspacing="0">
                        <tr>
                            <td></td>
                            <td align="left" bgcolor="#eeeeee">首页 -&gt; 绩效管理 -&gt; 绩效调整</td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="3" class="caption" align="center">绩效调整</td>
                        </tr>
                        <tr>
                            <td width="3%">&nbsp;</td>
                            <td align="left">
                                <table border="1" cellpadding="3" cellspacing="1" width="100%">
                                    <tr>
                                        <td class="item_caption">工单号:</td>
                                        <td class="item_content"><input name="strNo" id="txtNo" type="text" class="texts" value="" size="10" onblur="return checkOrderStatus()" /><asp:Button ID="btnSearch" CssClass="buttons" runat="server" OnClick="Search" OnClientClick="return dataQuery();" Text="检索"/></td>
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
                                <td width="3%">&nbsp;</td>
                                <td align="center">
                                    <table width="100%" border="1" cellpadding="3" cellspacing="1">
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">工单号:</td>
                                                <%
                                                    if (model!=null && model.No != null)
                                                    { %>
                                                        <td width="30%" class="item_content"><a href="#" onclick="orderDetail(this);"><%=model.No%></a><input type="hidden" id="hiddOrderId" name="orderId" value="<%=model.OrderId %>" /><input type="hidden" name="myOrderNo" value="<%=model.No%>" /></td>
                                                    <%}
                                                    else 
                                                    {%>
                                                        <td width="30%" class="item_content"></td>
                                                    <%}
                                                %>
                                            <td nowrap="nowrap" class="item_caption">顾客名称:</td>
                                                <%
                                                    if (model != null && model.CustomerName != null)
                                                    { %>
                                                        <td width="30%" class="item_content"><%=model.CustomerName%></td>
                                                    <%}
                                                    else 
                                                    {%>
                                                        <td width="30%" class="item_content"></td>
                                                    <%}
                                                %>
                                        </tr>
                                        <tr>
                                            <td nowrap="nowrap" class="item_caption">项目名称:</td>
                                                <%
                                                    if (model != null && model.ProjectName != null)
                                                    { %>
                                                        <td width="30%" class="item_content"><%=model.ProjectName%></td>
                                                    <%}
                                                    else 
                                                    {%>
                                                        <td width="30%" class="item_content"></td>
                                                    <%}
                                                %>
                                            <td nowrap="nowrap" class="item_caption">金额:</td>
                                                <%
                                                    if (model != null && model.SumMoney != 0)
                                                    { %>
                                                        <td width="30%" class="item_content"><%=model.SumMoney%></td>
                                                    <%}
                                                    else 
                                                    {%>
                                                        <td width="30%" class="item_content"></td>
                                                    <%}
                                                %>
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
                                    <td width="3%">&nbsp;</td>
                                    <td align="center">
                                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                                            <tr>
                                                <th width="1%" align="center" nowrap="nowrap">NO</th>
                                                <th width="1%" align="center" nowrap="nowrap">业务类型</th>
                                                <th width="1%" align="center" nowrap="nowrap">加工业务</th>
                                                <th width="1%" align="center" nowrap="nowrap">金额</th>
                                                <th width="10%" align="center" nowrap="nowrap">阶段</th>
                                                <th width="10%" align="center" nowrap="nowrap">姓名</th>
                                                <th width="10%" align="center" nowrap="nowrap">金额</th>
                                                <th width="20%" align="center" nowrap="nowrap">备注</th>
                                                <th width="15%" align="center" nowrap="nowrap">调整前期的人员</th>
                                                <th width="15%" align="center" nowrap="nowrap">调整后期的人员</th>
                                            </tr>
                                           <% if (model != null && model.OrderItemList!=null)
                                              {
                                                  int rIndex = 0;
                                                  foreach (Workflow.Da.Domain.OrderItem orderItem in model.OrderItemList)
                                                  {
                                                      rIndex++;
                                                      %>
                                            <tr class="detailRow" >
                                               <td nowrap="nowrap"><%=orderItem.No%><input name="itemid" type="hidden" value="<%=orderItem.Id %>" /></td>
                                               <td nowrap="nowrap"><%=orderItem.BusinessType.Name%></td>
                                               <td nowrap="nowrap"><%=orderItem.ProcessContentName%></td>
                                               <td name="summoney<%=orderItem.Id %>" nowrap="nowrap"><%=orderItem.Money%></td>
                                               <td id="tPosition" nowrap="nowrap">
                                               <%
                                                      foreach (Workflow.Da.Domain.CustomEmployee custom in orderItem.Employees)
                                                      {
                                                           %>
                                                      <div id="dProphasePhase<%=custom.Id %>">
                                                         <%=custom.Position%>
                                                         <input name="employee<%=orderItem.Id %>" type="hidden" value="<%=custom.Id%>" />
                                                         <input name="position<%=orderItem.Id %>" type="hidden" value="<%=custom.PositionId %>" />
                                                         <br />
                                                      </div>
                                                <%
                                                      } %>
                                                  
                                                </td>  
                                               <td id="tEmployeeName" nowrap="nowrap">
                                                <%
                                                      foreach (Workflow.Da.Domain.CustomEmployee custom in orderItem.Employees)
                                                      {
                                                            %> 
                                                  <div id="dProphaseEmName<%=custom.Id %>">
                                                    <%=custom.Name%><br />
                                                 </div>
                                                <%
                                                      } %>
                                               </td>
                                               <td id="tMoney" nowrap="nowrap">
                                               <%
                                                      foreach (Workflow.Da.Domain.CustomEmployee custom in orderItem.Employees)
                                                      {
                                                            %>
                                                 <div id="dProphaseMoney<%=custom.Id %>"> 
                                                 <input name="money<%=orderItem.Id%><%=custom.Id%><%=custom.PositionId %>" type="text" style="width:100%;" value="<%=custom.Money %>" />
                                                 <br />
                                                 </div>
                                                <%
                                                      } %>
                                               </td>
                                              <td nowrap="nowrap"><%=orderItem.Memo%></td> 
                                              <td nowrap="nowrap">
                                               <div style="width:100%;height:100%"> 
                                                  <select id="prophase" name="sltProphase" size="5" style="width:100%;" multiple="multiple">
                                                    <%
                                                            for (int i = 0; i < model.EmployeeList.Count; i++)
                                                            {
                                                                //前期
                                                                if (model.EmployeeList[i].Positionid == Workflow.Support.Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId))
                                                                {%>
                                                                
                                                                <option label="<%=model.EmployeeList[i].Positionid %>" value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                                                        <%}
                                                      } %>
                                                  </select>
                                                  <br />
                                                  <input id="btnOk"  type="button"  class="buttons" value="加入" onclick="return checkProphaseProcess(this);"/>
                                                  <input id="btnProphaseCancel"  type="button"  class="buttons" onclick="return prophaseCanel(this)" value="移除"/>
				                                   </div>  
                                               </td>
                                              <td nowrap="nowrap">
                                                <div style="width:100%;height:100%">
                                                  <select id="anaphase" name="sltAnaphase" size="5" style="width:100%;" multiple="multiple">
                                                   <%
                                                            for (int i = 0; i < model.EmployeeList.Count; i++)
                                                            {
                                                                //后期
                                                                if (model.EmployeeList[i].Positionid == Workflow.Support.Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId))
                                                                {%>
                                                                
                                                                <option label="<%=model.EmployeeList[i].Positionid %>" value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                                                        <%}
                                                      } %>
                                                  </select> 
                                                  <br />
                                                  <input id="btnBehindOk" type="button" class="buttons" value="加入" onclick="return checkAnaphaseProcess(this);"/>
				                                  <input id="Button1" type="button" class="buttons" onclick="return anaphaseCancel(this)" value="移除"/>
				                                </div> 
                                              </td>  
                                            </tr>
                                            <%
                                                  }
                                          }
                                                %>
                                        </table>
                                    </td>
                                    <td width="3%">&nbsp;</td>
                                </tr>
                                <tr class="emptyButtonsUpperRowHight">
                                    <td colspan="3"></td>
                                </tr>
                                <tr>
                                    <td colspan="3" align="center" class="bottombuttons">
                                        <asp:Button ID="btnSave" CssClass="buttons" runat="server" OnClick="Save" OnClientClick="return amountCheck();" Text="确定" />
                                        
                                    </td>
                               </tr>
                                <tr height="5">
                                    <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                    <td bgcolor="#eeeeee">&nbsp;</td>
                                    <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
                <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
                <td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
