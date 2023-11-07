<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FinishOrderForOrderItem.aspx.cs" Inherits="order_FinishOrderForOrderItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>制作完工</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/dispatch.js"></script>
<%--    <script type="text/javascript" src="../js/escExit.js"></script>
--%>    <script type="text/javascript" src="../js/SelectEmployee.js"></script>
    <script type="text/javascript" src="../js/order/finishOrderForOrderItem.js"></script>
    <script type="text/javascript" src="../js/json.js"></script>
    <script type="text/javascript">
        var strId='<%=sb.ToString() %>';
        var receptionEmployeeName='<%=strReceptionEmployee %>';
        var receptionEmployeeId='<%=strReceptionUser %>';
    </script>
    <base target="_self" />
</head>
<body>
    <form id="formFinishOrderForOrderItem" runat="server">
        <input type="hidden" id="actionTag" name="actionTag" value="" />
        <div align="left" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="780" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_top_left.gif" width="12" height="11" border="0" /></td>
                    <td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td></td>
                                <td align="left" bgcolor="#eeeeee">首页 -> 订单管理 ->本日订单 ->制作完工</td>
                                <td style="width: 12px"></td>
                            </tr>
                            <%--                            <tr>
                                                            <td colspan="3" class="caption" align="center">制作完工</td>
                                                        </tr>--%>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="left">
                                     <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <%--<input type="button" id="btnSelect" value="选人" onclick="selectEmployee();" />--%>      
                                            <%--<td nowrap class="item_caption">订单号:</td>
                                            <td class="item_content">
                                                <span id="OrderNo"><%=Request.QueryString["strNo"]%></span>--%>
                                                <td>
                                                <input id="txtOrderNo" type="hidden" name="strOrderNo" value="<%=Request.QueryString["strNo"] %>" />
                                                </td>
                                        </tr>
                                        <tr>
                                            <td nowrap class="item_caption">客户名称:</td>
                                            <td class="item_content">
<%--                                                <span id="CustomerName"><%=Request.QueryString["strName"]%></span>                                               
--%>                                                <input id="txtCustomerName" type="hidden" name="strCustomerName" value="<%=Request.QueryString["strName"] %>" />
                                                    <input type="hidden" id="txtResult" name="SelectResult" value="" />
                                            </td>
                                        </tr>
                                    </table>
    <%--                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                            <tr>
                                                <th nowrap style=" text-align:center" class="w1">No</th>
                                                <th nowrap style=" text-align:center" class="w1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;加工内容&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                                <th nowrap style=" text-align:center" class="w1">数量</th>
                                                <th nowrap style=" text-align:center" >前期</th>
                                                <th nowrap style=" text-align:center" >后期</th>
                                                <th nowrap></th>
                                            </tr>
                                            <%
                                                if (null != model.OrderItem)
                                                {
                                                    for (int j = 0; j < model.OrderItem.Count; j++)
                                                    {
                                                        int m = 0;
                                                    %>
                                                    <tr>
                                                        <td><%=j + 1%><input type="hidden" name="orderItemArr" value="<%=model.OrderItem[j].Id %>" /></td>
                                                        <td>
                                                            <%
                                                        for (int n = m; n < model.NewOrder.OrderItemList.Count; n++)
                                                        {
                                                            if (model.OrderItem[j].Id == model.NewOrder.OrderItemList[n].Id)
                                                            { %>
                                                                                <%=model.NewOrder.OrderItemList[n].Name%>    
                                                                            <%
                                                                break;
                                                            }
                                                            m++;
                                                        }
                                                                     %>
                                                                    
                                                        </td>
                                                        <td><%=model.OrderItem[j].Amount%></td>
                                                        <td>
                                                        <select id="prophase<%=model.OrderItem[j].Id %>" name="sltProphase<%=model.OrderItem[j].Id %>" size="5" style="width:100px" multiple="multiple">
                                                                <%
                                                        for (int i = 0; i < model.EmployeeList.Count; i++)
                                                        {
                                                            //前期
                                                            if (model.EmployeeList[i].Positionid == Workflow.Support.Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                                                            {%>
                                                                                
                                                                                <option value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                                                                        <%}
                                                                      } %>
                                                                     </select>                                                    
                                                                </td>
                                                        <td>
                                                             <select id="anaphase<%=model.OrderItem[j].Id %>" name="sltAnaphase<%=model.OrderItem[j].Id %>" size="5"  style="width:100px" multiple="multiple">
                                                                <%
                                                        for (int i = 0; i < model.EmployeeList.Count; i++)
                                                        {
                                                            //后期
                                                            if (model.EmployeeList[i].Positionid == Workflow.Support.Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                                                            {%>
                                                                                <option value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                                                            <%}
                                                          }%>
                                                            </select>
                                                        </td>
                                                        <td nowrap><input type="button" value="清空"  onclick="clearSelected(this);" /></td>
                                                    </tr>    
                                                    <%}
                                              }
                                            %>
                                        </table>
                                        <table>
                                            <tr>
                                                <td nowrap class="item_caption">备注:</td>
                                                <td class="item_content"><textarea name="Memo" cols="65" rows="3" class="textarea"></textarea></td>
                                            </tr>
                                        </table>--%>
                                </td>
                                <td style="width: 12px">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center" class="bottombuttons">
                                    <input type="button" id="btnOk" class="buttons" onclick="newOrderFinishCheck()" value="确定" />
                                    <input type="button" class="buttons" onclick="window.close()" name="Submit" value="关闭" />
                                </td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td style="width: 12px"><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="12"><img alt="" src="../images/white_main_bottom_left.gif" width="12" height="11" /></td>
                    <td bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" width="10" height="10" /></td>
                    <td width="12"><img alt="" src="../images/white_main_bottom_right.gif" width="12" height="11" /></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
