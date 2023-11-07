<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CopyCounter.aspx.cs" Inherits="logcounters_CopyCounter" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>机器抄表</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="../js/default.js"></script>
    <script type="text/javascript" language="javascript" src="../js/escExit.js"></script>
    <script type="text/javascript" language="javascript" src="../js/logcounters/copyCounter.js"></script>
    <base target="_self" />
</head>
<body>
    <form id="form1" runat="server">
    <div align="center" width="99%" id="container">
            <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
                <tr>
                    <td width="11"><img alt="" src="../images/white_main_top_left.gif" /></td>
                    <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10" /></td>
                    <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11" /></td>
                </tr>
                <tr>
                    <td colspan="3" bgcolor="#FFFFFF">
                        <table width="100%" border="0" cellpadding="0" cellspacing="3" bgcolor="#FFFFFF">
                            <tr>
                                <td width="3%"></td>
                                <td align="left" bgcolor="#eeeeee">首页&nbsp;-&gt;&nbsp;抄表处理&nbsp;-&gt;&nbsp;机器抄表</td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
                                <td colspan="3" class="caption" align="center">机器抄表</td>
                            </tr>
                            <tr>
                                <td width="3%"></td>
                                <td align="center">
                                    <table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
											<th width="20%" nowrap="nowrap">打印机</th>
											<th nowrap="nowrap">M1</th>
											<th nowrap="nowrap">M2</th>
											<th nowrap="nowrap">M3</th>
											<th nowrap="nowrap">M4</th>
                                        </tr>
										<%foreach (Workflow.Da.Domain.Machine machine in model.MachineList){ %>
										<tr>
											<td><%=machine.Name %></td>
											<% foreach (Workflow.Da.Domain.MachineWatch machineWatch in machine.watchs){%>
											<td>
												<input class="check" name="<%=machineWatch.Name %><%=machineWatch.Id %>" style="text-align:right;width:150px;" type="text" value="" />
											</td>
											<%} %>
										</tr>
										<%} %>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
								<td width="3%"></td>
                                <td colspan="" align="left"><div style="float:left;width:100%;">未完成工单用纸数量:</div><input onclick="editProductionPaperAmount();" type="button" value="新增" /></td>
                                <td width="3%"></td>
                            </tr>
                            
                            <tr>
								<td width="3%"></td>
                                <td align="center">
									<table border="1" cellpadding="3" cellspacing="1" width="100%" align="left">
                                        <tr>
                                            <th width="15%" nowrap="nowrap">工单</th>
											<th nowrap="nowrap">机器</th>
											<th nowrap="nowrap">纸型</th>
											<th nowrap="nowrap">颜色</th>
											<th nowrap="nowrap">数量</th>
											<th nowrap="nowrap">操作</th>
                                        </tr>
											<%if(null!= model.UncompleteOrderList) {%>
											<%foreach(Workflow.Da.Domain.UncompleteOrdersUsedPaper uncomplete in model.UncompleteOrderList) {
											%>
										<tr>	
											<td width="15%" nowrap="nowrap"><%=uncomplete.OrderNo %></td>
											<td nowrap="nowrap"><%=uncomplete.MachineName %></td>
											<td nowrap="nowrap"><%=uncomplete.PaperName %></td>
											<td nowrap="nowrap"><%=Workflow.Support.Constants.GetColorType(uncomplete.ColorType)%></td>
											<td nowrap="nowrap"><%=uncomplete.UsedPaperCount %></td>
											<td nowrap align="left">
                                                <a href='#' onclick="editProductionPaperAmount(<%=uncomplete.Id %>)">编辑</a>
                                                <a href="#" onclick="deleteRow(<%=uncomplete.Id%>)">
                                                    删除</a></td>
										 </tr>	
										 <%} }%>
                                    </table>
                                </td>
                                <td width="3%"></td>
                            </tr>
                            <tr>
            <td>&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="3" cellspacing="1">
                <tr>
                  <td align="right" nowrap="nowrap" bgcolor="#FFFFFF" class="item_caption">登记人:</td>
                  <td bgcolor="#FFFFFF" class="item_content"><%=model.Register.EmployeeName%></td>
                  <td nowrap="nowrap" bgcolor="#FFFFFF" class="item_caption">核对人:</td>
                  <td bgcolor="#FFFFFF" class="item_content"><select id="userSel" name="select2">
					<%foreach(Workflow.Da.Domain.User user in model.UserList){
						if(model.Register.Id!=user.Id)
						{%>
                      <option value="<%=user.Id %>"><%=user.Employee.Name %></option>
                      <%} }%>
                    </select></td>
                  <td nowrap="nowrap" bgcolor="#FFFFFF" class="item_caption">验证密码:</td>
                  <td align="left" bgcolor="#FFFFFF" class="item_content">
                  <input id="password" name="textfield4" type="password" class="texts" value="" size="10" /></td>
                </tr>
              </table></td>
            <td>&nbsp;</td>
          </tr>
          
		  <tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
		  </tr>
          <tr>
            <td colspan="3" align="center" class="bottombuttons" style="height: 23px"><input name="Submit2" type="button" class="buttons" onclick="verifyRecordWatch();" value="核对" /></td></tr>
                            
                            <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                            <tr height="5">
                                <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
                                <td bgcolor="#eeeeee">&nbsp;</td>
                                <td ><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5" /></td>
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
            <input id="RecordMachineWatch" name="RecordMachineWatch" type="hidden" value="<%=model.RecordMachineWatchId %>" />
            <input id="UncompleteOrder" name="UncompleteOrder" type="hidden" value="" />
            <input id="verify" name="verify" type="hidden" value="" />
        </div>
    </form>
</body>
</html>
