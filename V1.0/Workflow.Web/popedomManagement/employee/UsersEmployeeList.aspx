<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsersEmployeeList.aspx.cs" Inherits="UsersEmployeeList" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>雇员一览</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript" src="../../js/popedommanagement/employee.js"></script>
</head>
<body style="text-align:center;">
    <form id="form1" runat="server">
    <input name="hiddEmployeeId" id="hiddEmployeeId" value="" type="hidden" />
    <input name="hiddPositionId" id="hiddPositionId" value="" type="hidden" />
    <input name="hiddTag" id="hiddTag" value="F" type="hidden" />
        <div align="center" style="width: 99%;" bgcolor="#FFFFFF" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../../images/white_main_top_left.gif"/></td>
                    <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif" height="10"/></td>
                    <td width="10"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"/></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;人员管理&nbsp;-&gt;&nbsp;雇员一览</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">雇员一览</td>
                            </tr>
                            <tr>
                                <td width="3%">&nbsp;</td>
                                <td width="94%" align="center">
                                    <table border="1" align="left" width="100%">
                                    <tr>
                                    <td nowrap="nowrap" class="item_caption">雇&nbsp;员</td>
                                    <td class="item_content">
                                     <asp:DropDownList ID="selEmployeeList"  runat="server" AppendDataBoundItems="True" Width="100"><asp:ListItem Value="-1">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                    </td>
                                    </tr>
                                    <tr><td nowrap="nowrap" class="item_caption">岗&nbsp;位</td><td class="item_content">
                                  
                                     <asp:DropDownList ID="selPositionList"  runat="server" AppendDataBoundItems="True" Width="100"><asp:ListItem Value="-1">请选择</asp:ListItem>
                                    </asp:DropDownList>
                                    </td></tr>
                                    <tr class="querybuttons"><td align="right" colspan="2"><asp:Button ID="btnSearch" CssClass="buttons" runat="server" Text="查询" OnClick="btnSearch_Click"/></td></tr>
                                    </table>
                                </td>
                                <td width="3%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="10%" nowrap>&nbsp;NO&nbsp;</th>
                                            <th nowrap width="50%">雇员</th>
                                            <th width="40%" nowrap>岗位</th>
                                            <th width="1%" nowrap></th>
                                        </tr> 
                                        <%
                                        if(null!=model.EmployeeList)
                                        {
                                         
                                             for (int i = 0; i < model.EmployeeList.Count; i++)
                                            {   
                                            %>                                      
                                            <tr class="detailRow">
                                                <td nowrap><%=i+1%></td>
                                                <td class="item_content" id="tdEmployeeName"><%=model.EmployeeList[i].Name%></td>
                                                <td nowrap align="center"><%=EmployeeAction.GetEmployeePositionStringByEmployeeId(model.EmployeeList[i].Employeeid)[1]%></td>                                        
                                                <td nowrap align="left">
                                                   <a href="#" onclick="return EdmitEmployeeInfo('<%=model.EmployeeList[i].Employeeid %>','<%=EmployeeAction.GetEmployeePositionStringByEmployeeId(model.EmployeeList[i].Employeeid)[0]%>','<%=model.EmployeeList[i].Name%>');">编辑</a>
                                                   <a href="#" onclick="DeleteEmployeeInfo('<%=model.EmployeeList[i].Employeeid %>')">删除</a>
                                               </td>
                                            </tr>
                                             
                                            <%} %>
                                <tr>
                                     <td bgcolor="#eeeeee" align="right" colspan="7">
                                     <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                     </webdiyer:AspNetPager>
                                     </td>
                                </tr>
                                    <%
                                    } %>
                               </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                              
                            <tr class="emptyButtonsUpperRowHight">
                                <td colspan="3"></td>
                            </tr>
                            <tr height="5">
                                <td style="height: 5px"><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                <td bgcolor="#eeeeee" style="height: 5px">&nbsp;</td>
                                <td style="height: 5px"><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td width="11"><img alt="" src="../../images/white_main_bottom_left.gif"/></td>
                    <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif"/></td>
                    <td width="10"><img alt="" src="../../images/white_main_bottom_right.gif"/></td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
