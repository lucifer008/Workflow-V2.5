<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Compensate.aspx.cs" Inherits="Compensate" %>

<%@ Import Namespace="Workflow.Da.Domain" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>补单</title>
	<link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" language="javascript" src="../js/default.js"></script>
	<script type="text/javascript" language="javascript" src="../js/escExit.js" ></script>
	<script type="text/javascript">
  <%if (closeSelf) {%>
  $().ready(function(){
	  window.returnValue="ok"; //提交父窗体页面
	  window.close();
  });
<%} %>
</script>
 <base target="_self" />
</head>
<body style="text-align: center">
  <form id="MainFrom" method="post" runat="server">
    <%if (closeSelf) { return; } %>
	<input name="txtRecordMachineWatchId" id="txtRecordMachineWatchId" value="<%=lngRecordMachineWatchId %>" type="hidden" />
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11">
            <img alt="" src="../images/white_main_top_left.gif"></td>
          <td width="99%">
            <img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
          <td width="10">
            <img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
        </tr>
        <tr>
          <td colspan="3" bgcolor="#FFFFFF">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td bgcolor="#FFFFFF">
                  <table width="100%" border="0" cellspacing="0">
                    <tr>
                      <td>
                      </td>
                      <td align="left" bgcolor="#eeeeee">
                        首页 -&gt; 抄表处理 -&gt; 补单</td>
                      <td>
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">
                        补单</td>
                    </tr>
                    <tr>
                      <td width="3%">
                        &nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" cellspacing="1" cellpadding="3">
                          <tr>
                            <td width="6%" align="right" nowrap="nowrap" class="item_caption">
                              机器:</td>
                            <td width="94%" align="left" class="item_content">
                              <select id="sltMachine" name="sltMachine">
                                <%foreach (Machine varMachine in model.MachineList){
									  if(model.MachineId==varMachine.Id)
                                  {%>
                                  <option selected="selected" value="<%=varMachine.Id%>"><%=varMachine.Name%></option>
                                  <%}else{ %>
                                <option value="<%=varMachine.Id%>"><%=varMachine.Name%></option>
                                <%
									  }}
                                %>
                              </select>
                            </td>
                          </tr>
                          <tr>
                            <td align="right" nowrap="nowrap" class="item_caption">
                              纸型:</td>
                            <td align="left" class="item_content">
                              <select id="sltPaperSpecification" name="sltPaperSpecification">
                                <%foreach (PaperSpecification varPaperSpecificationList in model.PaperSpecificationList)
								  {
									  if (model.PaperId == varPaperSpecificationList.Id)
									  {%>
                                <option selected="selected" value="<%=varPaperSpecificationList.Id%>"><%=varPaperSpecificationList.Name%></option>
                                <%}
								  else
								  { %>
                                <option value="<%=varPaperSpecificationList.Id%>"><%=varPaperSpecificationList.Name%></option>
                                <%
									}
								}
                                %>
                              </select>
                            </td>
                          </tr>
                          <tr>
                            <td align="right" nowrap="nowrap" class="item_caption">
                              颜色:</td>
                            <td align="left" class="item_content">
                              <select id="sltColor" name="sltColor">
                              <%if(model.PaperColor=="1"){ %><option selected="selected" value="1">黑白</option><%}else{ %><option value="1">黑白</option><%} %>
                              <%if(model.PaperColor=="2"){ %><option selected="selected" value="2">彩色</option><%}else{ %><option value="2">彩色</option><%} %>
                              </select>
                            </td>
                          </tr>
                          <tr>
                            <td align="right" nowrap="nowrap" class="item_caption">
                              数量:</td>
                            <td align="left" class="item_content">
                              <input id="txtAmount" name="txtAmount" type="text" class="num" maxlength="5" size="10" value="<%=model.CompensateCount %>" /></td>
                          </tr>
                          <tr>
                            <td align="right" nowrap="nowrap" class="item_caption">
                              责任人:</td>
                            <td align="left" class="item_content">
                            <%int i = 0;
                              foreach (Employee varEmployee in model.EmployeeList)
                              {
                                i++;
								  if(model.EmployeeNameList.Contains(varEmployee.Name)){
                            %>
								<input checked="checked" name="chkEmployee" id="chkEmployee<%=i%>" type="checkbox" class="checks" title="<%=varEmployee.Name%>" value="<%=varEmployee.Employeeid%>" /><label for="chkEmployee<%=i%>"><%=varEmployee.Name%></label>
                            <%}else{ %>
                                <input name="chkEmployee" id="chkEmployee<%=i%>" type="checkbox" class="checks" title="<%=varEmployee.Name%>" value="<%=varEmployee.Employeeid%>" /><label for="chkEmployee<%=i%>"><%=varEmployee.Name%></label>
                            <%
                              } }%>
                            </td>
                          </tr>
                          <tr>
                            <td align="right" nowrap="nowrap" class="item_caption">
                              备注:</td>
                            <td align="left" class="item_content">
                              <textarea name="txtMemo" id="txtMemo" cols="95" rows="3"></textarea></td>
                          </tr>
                        </table>
                      </td>
                      <td width="3%">
                        &nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td colspan="3">
                      </td>
                    </tr>
                    <tr>
                      <td colspan="3" align="center" class="bottombuttons">
                      <asp:Button ID="btnSaveCompenstae" Text="保存" CssClass="buttons" OnClick="SaveCompensate" runat="server" />
                        &nbsp;&nbsp;&nbsp;
                        <input name="btnCancel" class="buttons" value="关闭" type="button" onclick="window.close();" /></td>
                    </tr>
                    <tr height="5">
                      <td>
                        <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                      <td bgcolor="#eeeeee">
                        &nbsp;</td>
                      <td>
                        <img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11">
            <img alt="" src="../images/white_main_bottom_left.gif"></td>
          <td width="99%">
            <img alt="" src="../images/spacer_10_x_10.gif"></td>
          <td width="10">
            <img alt="" src="../images/white_main_bottom_right.gif"></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
