﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DispatchOrderForOrderItem.aspx.cs"
    Inherits="order_DispatchOrderForOrderItem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>分配工单</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/json.js"></script>
    <script type="text/javascript" src="../js/dispatch.js"></script>
    <script type="text/javascript" src="../js/escExit.js"></script>
    <script type="text/javascript">
        var strId='<%=sb.ToString() %>';
    </script>
<%--<%if(closeFlag) {%>
<script type="text/javascript">
    //opener.location.reload();
    opener.rVal='true';
    close();
</script>
<%} %> --%>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
        <div align="left" style="width: 99%" bgcolor="#ffffff" id="container">
            <table width="600" border="0" cellspacing="0" cellpadding="0">
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
                                <td align="left" bgcolor="#eeeeee">首页 -> 工单管理 ->本日工单 ->分配工单</td>
                                <td style="width: 12px"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">分配工单</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="left">
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <td nowrap class="item_caption">工单号:</td>
                                            <td class="item_content">
                                                <span id="OrderNo"><%=Request.QueryString["strNo"]%></span>
                                                <input id="txtOrderNo" type="hidden" name="strOrderNo" value="<%=Request.QueryString["strNo"] %>" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table width="100%" border="1" cellpadding="2" cellspacing="1">
                                        <tr>
                                            <th nowrap style=" text-align:center" class="w1">No</th>
                                            <th nowrap style=" text-align:center" class="w1">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;加工内容&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                                            <th nowrap style=" text-align:center" class="w1">数量</th>
                                            <th nowrap style=" text-align:center" >前期</th>
                                            <th nowrap style=" text-align:center" >后期</th>
                                            <th nowrap ></th>
                                        </tr>
                                        <%
                                            for(int j=0;j<model.OrderItem.Count;j++)
                                            {
                                                int m = 0;
                                                %>
                                                <tr>
                                                    <td><%=j+1%></td>
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
                                                    <td><%=model.OrderItem[j].Amount %></td>
                                                    <td>
                                                        <select id="prophase<%=model.OrderItem[j].Id %>" name="sltProphase<%=model.OrderItem[j].Id %>" size="5" style="width:100px" multiple="multiple" class="prophase">
                                                            <%
                                                                for (int i = 0; i < model.EmployeeList.Count; i++)
                                                                {
                                                                    //前期
                                                                    if (model.EmployeeList[i].Positionid == Workflow.Support.Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                                                                    {%>
                                                                    
                                                                    <option value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                                                                    <%}
                                                                } 
                                                            %>
                                                         </select>                                                    
                                                    </td>
                                                    <td>
                                                         <select id="anaphase<%=model.OrderItem[j].Id %>" name="sltAnaphase<%=model.OrderItem[j].Id %>" size="5"  style="width:100px" multiple="multiple" class="anaphase">
                                                            <%
                                                                for (int i = 0; i < model.EmployeeList.Count; i++)
                                                                {
                                                                    //后期
                                                                    if (model.EmployeeList[i].Positionid  == Workflow.Support.Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                                                                    {%>
                                                                    <option value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                                                            <%}
                                                          }%>
                                                        </select>
                                                    </td>
                                                    <td nowrap><input type="button" value="清空"  onclick="clearSelected(this);" /></td>
                                                </tr>    
                                            <%}
                                        %>
                                    </table>
                                    <table>
                                        <tr>
                                            <td nowrap class="item_caption">备注:</td>
                                            <td class="item_content"><textarea name="Memo" cols="65" rows="3" class="textarea"></textarea></td>
                                        </tr>
                                    </table>
                                </td>
                                <td style="width: 12px">&nbsp;</td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td align="center" class="bottombuttons">
                                    <asp:Button ID="btnOk" CssClass="buttons" Text="确定" OnClick="SaveDispatch" runat="server" />
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
