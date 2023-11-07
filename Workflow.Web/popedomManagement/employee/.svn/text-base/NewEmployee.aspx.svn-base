<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewEmployee.aspx.cs" Inherits="popedomManagement_NewUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>雇员添加</title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" href="../../css/calendar-blue.css"  type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript"  src="../../js/popedommanagement/employee.js"></script>
    <script language="javascript" type="text/javascript">
    var positionId=new Array();
    var strpositionId='<%=strPositionId%>';
    positionId=strpositionId.split("/");
    var employeeId=<%=employeeId %>;
    var employeeNameEdmit='<%=employeeName%>';
    var master=<%=Workflow.Support.Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;//店长Id
    var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;//经理
    var currentUserPosition=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>
	</script>
	<base target="_self" />
</head>
<body onload="loadEmployeeEdmitInfo();" style="text-align:center;">
    <form id="form1" runat="server">
    <input type="hidden" name="hiddEmployeeId" id="hiddEmployeeId" value="" />
         <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
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
                                <td> </td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;人员管理&nbsp;-&gt;&nbsp;雇员添加</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">雇员添加</td>
                            </tr>
                            <tr>
                                <td ></td>
                                <td align="center">                                   
                                    <table border="1" cellpadding="3" cellspacing="1" align="left">
                                        <tr>
                                            <td align="right" class="item_caption">雇员名称</td>
                                            <td align="left"><input name="txtEmployName" id="txtEmployName" onchange="checkEmployeeNameIsExist()" type="text" maxlength="50" tabindex="2" value=""/></td>
                                        </tr>
                                        <tr>
                                            <td nowrap align="right" class="item_caption">所属岗位</td>
                                            <td align="left">
												<table align="left" border="1" width="100%">
												  <tr>
												  <%												    
												    for (int j = 0; j < model.PositionList.Count; j++)
                                              {
                                                                %>
												  <td nowrap="nowrap" >
														    <input id="cb<%=j%>" name="cbPosition" type="checkbox" value="<%=model.PositionList[j].Id %>"/>
														    <label id="label" onclick="SelectedCheckBox(cb<%=j %>)"><%=model.PositionList[j].Name%></label>
														</td>
												        <% 
                                                   if(j!=0 && j%4==0)
                                                  {
                                                    %>
												  </tr>
												  <%
                                                   }  
                                               }
													%>																											
												</table>
												<br/>
											</td>
                                        </tr>
                                    </table>
									<br/>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td></td>
                                <td align="left"><asp:Button ID="btn" runat="server" CssClass="buttons" OnClick="addEmployee" OnClientClick="return EmployeeDataCheck(); " Text="保存"/>&nbsp;
                                <input id="btnCancel" name="btnCancel" class="buttons" type="button" value="关闭" onclick="window.close();" style="display:none"/></td>
                                <td width="3%"></td>
                            </tr>
                            <tr class="emptyButtonsUpperRowHight"> <td colspan="3"></td></tr>
                            <tr>
                                <td> <img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
                                <td backcolor ="#eeeeee">&nbsp;</td>
                                <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"/></td>
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

