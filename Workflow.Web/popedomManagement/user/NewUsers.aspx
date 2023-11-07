<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NewUsers.aspx.cs" Inherits="NewUsers" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title><%=strTitle %></title>
    <link href="../../css/css.css" rel="stylesheet" type="text/css" />
	<link rel="stylesheet" href="../../css/calendar-blue.css"  type="text/css" />
    <script type="text/javascript" src="../../js/jquery.js"></script>
    <script type="text/javascript" src="../../js/check.js"></script>
    <script type="text/javascript" src="../../js/default.js"></script>
    <script type="text/javascript"  src="../../js/popedommanagement/users.js"></script>
	<script type="text/javascript">
	var userName='<%=userName%>';
    var userId=<%=userId%>;
    var roleId='<%=strRoleId %>';//编辑用户的角色
    var arr=new Array();
    arr=roleId.split("/");
    var currentUserRoleId=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.RoleId %>;//当前用户的角色
    var employeeId=<%=employeeId %>;
    var isLogin='<%=isLogin %>';
    var passWord='<%=password %>';
    var userConcessionRange=<%=isNotConcessionRange%>;//用户是否有优惠范围
    var managerId=<%=Workflow.Support.Constants.ROLE_ADMINISTRATOR_VALUE(branchShopId) %>;//经理
    var casherId=<%=Workflow.Support.Constants.ROLE_CASHER_VALUE(branchShopId) %>;//收银
    var masterId=<%=Workflow.Support.Constants.ROLE_MASTER_VALUE(branchShopId) %>;//店长
	</script>
	<base target="_self" />
</head>
<body onload="LoadUserInfo()" style="text-align:center;">
    <form id="form1" runat="server">
        <input type="hidden" id="hiddUserId" name="hiddUserId" runat="server" />
        <input type="hidden" id="hiddIsLogin" name="hiddIsLogin" runat="server" />
        <input type="hidden" id="hiddTag" name="hiddTag" runat="server" /><%--标记动作(编辑或者删除)--%>
        <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
                <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                    <tr>
                        <td width="11"><img alt="" src="../../images/white_main_top_left.gif"></td>
                        <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif" height="10"></td>
                        <td width="10"><img alt="" src="../../images/white_main_top_right.gif" width="12" height="11"></td>
                    </tr>
                    <tr>
                        <td colspan="3" bgcolor="#FFFFFF">
                            <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                                <tr>
                                    <td width="3%"></td>
                                    <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;人员管理&nbsp;-&gt;&nbsp;<%=strTitle %></td>
                                    <td width="3%"></td>
                                </tr>
                                <tr>
                                    <td colspan="3" class="caption" align="center"><%=strTitle %></td>
                                </tr>
                                <tr height="5">
                                    <td style="height: 5px"><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                    <td nowrap bgcolor="#eeeeee" style="height: 5px">&nbsp;</td>
                                    <td ><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                </tr>
                                <tr>
                                    <td width="3%"></td>
                                    <td align="center">                                   
                                        <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                            <tr>
                                                <td nowrap align="right" class="item_caption">雇&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;员</td>
                                                <td align="left"><asp:DropDownList ID="sltEmployee"  runat="server" AppendDataBoundItems="True"></asp:DropDownList> </td>
                                            </tr>
                                            <tr>
                                                <td class="item_caption">用 户 名</td>
                                                <td align="left"><input name="txtUserName" id="txtUserName" type="text" maxlength="50" tabindex="2" onchange ="CheckUserNameIsExist()"/></td>
                                            </tr>
                                            
                                            <tr id="trPassWord">
                                                <td class="item_caption">登陆密码 </td>
                                                <td align="left"><input id="txtUserPassword" name="txtUserPassword" maxlength="30" type="password" tabindex="3"/></td>
                                            </tr>
                                            <tr id="trConfirmPd">
                                                 <td class="item_caption">确认密码 </td>
                                                <td align="left"><input id="txtConfirmPassword" name="txtConfirmPassword" maxlength="30" type="password" tabindex="3"/></td>
                                            </tr>
                                            <tr>
                                                <td class="item_caption">角 &nbsp; &nbsp;&nbsp; &nbsp;色</td>
                                                <td align="left">                                
                                                <table border="1" align="left" width="100%">
                                                    <tr>
													    <%
													        for (int j = 0; j < UserAction.Model.RoleList.Count;j++ )
                                                      {
                                                                %>
														    <td class="nowrap">
														        <input id="cb<%=j%>" type="checkbox" name="cbBoxRole" value="<%=UserAction.Model.RoleList[j].RoleID %>" onclick="AddRolePermission(<%=UserAction.Model.RoleList[j].RoleID %>);"/>
														        <label id="label" onclick="SelectedCheckBox(cb<%=j %>,<%=UserAction.Model.RoleList[j].RoleID %>)"><%=UserAction.Model.RoleList[j].Permissionvalues%></label>
														    </td>															
													    <%	
                                                                if (j % 4 == 0 && j != 0)
                                                                {
                                                                    %>
												            </tr>  
													    <%
                                                                }
                                                       }
													     %>
                                                </table>
											         </td>
                                            </tr>
                                            
                                        </table>
                                    </td>
                                    <td width="3%"></td>
                                </tr>
                           　    <tr id="tr1" runat="server" visible="true">                                    
                                      <td width="3%"></td>
                                      <td>
                                       <table id="tbconcessDetail" border="１" style="width: 100%; height: 100%">
                                      <tr>
                                       <td nowrap="nowrap"  class="item_caption">抹&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;零</td>
                                       <td class="item_content">
                                          <input id="txtMinApplyZero" name="txtMinApplyZero" type="text"  size="8" class="texts" value="<%=minApplyZero %>"/><span class="STYLE1">元</span> &nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;
                                          <input id="txtMaxApplyZero" name="txtMaxApplyZero" type="text" size="8" class="texts" value="<%=maxApplyZero %>"/><span class="STYLE1">元</span>   
                                       </td>
                                      </tr>
										    <tr>
										        <td nowrap="nowrap"  class="item_caption">优&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;惠</td>
										        <td class="item_content">
										            <input id="txtMinConcessionMoney" name="txtMinConcessionMoney" type="text" class="texts" size="8" value="<%=minConcessionMoney %>"/><span class="STYLE1"></span>%&nbsp;&nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;
										            <input id="txtMaxConcessionMoney" name="txtMaxConcessionMoney" type="text" class="texts" size="8" value="<%=maxConcessionMoney %>"  /><span class="STYLE1">%</span>       
										        </td>
										    </tr>
										    <tr>
										        <td nowrap="nowrap" class="item_caption">折&nbsp; &nbsp;&nbsp; &nbsp; &nbsp;让</td>
										        <td class="item_content">
										            <input id="txtMinDiscountMoney" name="txtMinDiscountMoney" type="text" class="texts" size="8" value="<%=minDiscount %>"/><span class="STYLE1"></span>%&nbsp;&nbsp;&nbsp;&nbsp;至&nbsp;&nbsp;
										            <input id="txtMaxDiscountMoney" name="txtMaxDiscountMoney" type="text" class="texts" size="8" value="<%=maxDiscount %>"/><span class="STYLE1">%</span>
										        </td>
										    </tr>
										    </table>  
									    </td>
									      <td width="3%"></td>
								    </tr>
                                <tr>
                                    <td width="3%"></td>
                                    <td align="left"><asp:Button ID="btn" runat="server" CssClass="buttons" OnClick="addUser" OnClientClick="return UserDataCheck(); " Text="保存" />
                                    &nbsp;<input name="btnCancel" id="btnCancel" class="buttons" type="button" value="关闭" onclick="return btnCancelClose();" style="display:none"/>
                                    <td width="3%">
                                    </td>
                                </tr>
                                <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                                <tr height="5">
                                    <td><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                    <td bgcolor="#eeeeee">&nbsp;</td>
                                    <td ><img alt="" src="../../images/spacer_5_x_5.gif" width="5" height="5"></td>
                                </tr>
                             </table>
                        </td>
                    </tr>
                    <tr>
                        <td width="11"><img alt="" src="../../images/white_main_bottom_left.gif"></td>
                        <td width="99%"><img alt="" src="../../images/spacer_10_x_10.gif"></td>
                        <td width="10"><img alt="" src="../../images/white_main_bottom_right.gif"></td>
                    </tr>
                </table>
            </div>
    </form>
</body>

</html>
<script language="javascript" type="text/javascript">
var concessDiscountApplyDetail=$("#tr1").html();
</script>

