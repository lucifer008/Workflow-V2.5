<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EditCompensate.aspx.cs" Inherits="EditCompensate" %>

<%@ Import Namespace="Workflow.Da.Domain" %>
<%@ Import Namespace="Workflow.Support" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>编辑补单</title>
  <link href="/Workflow.Web/css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../js/jquery.js"></script>
  <script type="text/javascript" src="../js/check.js"></script>
  <script type="text/javascript" src="../js/compensate.js"></script>
  <script type="text/javascript">
  <%if (closeSelf) {%>
  $().ready(function(){
    var parentWindow=window.opener;
    if (parentWindow!=null){
      opener.$("#MainForm").submit();
      window.close();
      return;
      }
  });
<%} %>
</script>
</head>
<body style="text-align: center">
  <form id="MainFrom" method="post" runat="server">
    <%if (closeSelf) { return; } %>
  <input name="txtId" id="txtId" value="<%=lngId%>" type="text" />
  <input name="txtRecordMachineWatchId" id="txtRecordMachineWatchId" value="<%=lngRecordMachineWatchId %>" type="text" />
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
                                <option value="0">请选择</option>
                                <%
                                  string strSelected = "";
                                  foreach (Machine varMachine in model.MachineList)
                                  {
                                    strSelected = "";
                                    if (varMachine.Id==model.CompensateUsedPaper.MachineType.Id)
                                    { strSelected = "selected"; }
                                    %>
                                  
                                <option value="<%=varMachine.Id%>" <%=strSelected%>>
                                  <%=varMachine.Name%>
                                </option>
                                <%
                                  }
                                %>
                              </select>
                            </td>
                          </tr>
                          <tr>
                            <td align="right" nowrap="nowrap" class="item_caption">
                              纸型:</td>
                            <td align="left" class="item_content">
                              <select id="sltPaperSpecification" name="sltPaperSpecification">
                                <option value="0">请选择</option>
                                <%foreach (PaperSpecification varPaperSpecification in model.PaperSpecificationList)
                                  {
                                    strSelected = "";
                                    if (varPaperSpecification.Id == model.CompensateUsedPaper.PaperSpecification.Id)
                                    { strSelected = "selected"; }
                                    %>
                                <option value="<%=varPaperSpecification.Id%>" <%=strSelected%>>
                                  <%=varPaperSpecification.Name%>
                                </option>
                                <%
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
                                <option value="0">请选择</option>
                                <%
                                  if (model.CompensateUsedPaper.ColorType == Constants.COLOR_BLACKWHITE)
                                  {
                                %>
                                <option value="1" selected="selected">黑白</option>
                                <option value="2">彩色</option>
                                <%
                                  }
                                  else
                                  {
                                %>
                                <option value="1">黑白</option>
                                <option value="2" selected="selected">彩色</option>
                                <%
                                  }
                                     %>
                                
                              </select>
                            </td>
                          </tr>
                          <tr>
                            <td align="right" nowrap="nowrap" class="item_caption">
                              数量:</td>
                            <td align="left" class="item_content">
                              <input id="txtAmount" name="txtAmount" type="text" class="num" maxlength="5" size="10" value="<%=model.CompensateUsedPaper.UsedPaperCount%>" /></td>
                          </tr>
                          <tr>
                            <td align="right" nowrap="nowrap" class="item_caption">
                              责任人:</td>
                            <td align="left" class="item_content">
                            <% 
                              //记录当前找到的位置
                              int intCurPos = 0;
                              bool blnFound;
                              for (int i = 0; i < model.EmployeeList.Count; i++)
                               {
                                 blnFound = false;
                                 for (int j = intCurPos; j < model.CompensateUsedPaper.EmployeeList.Count; j++)
                                 {
                                   
                                   if (model.EmployeeList[i].Employeeid == model.CompensateUsedPaper.EmployeeList[j].Id)
                                   {
                                       //相同的话退出显示未选中,记录当前位置并退出
                                       blnFound = true;
                                       intCurPos++;
                                       break;
                                   }
                                 }
                                 if (blnFound)
                                 {
                                %>
                                  <input name="chkEmployee" id="chkEmployee<%=i%>" type="checkbox" class="checks" checked title="<%=model.EmployeeList[i].Name%>" value="<%=model.EmployeeList[i].Employeeid%>" /><label for="chkEmployee<%=i%>"><%=model.EmployeeList[i].Name%></label>
                                  <%
                              }
                              else
                              {//没有找到
                                   %>
                                   <input name="chkEmployee" id="chkEmployee<%=i%>" type="checkbox" class="checks"  title="<%=model.EmployeeList[i].Name%>" value="<%=model.EmployeeList[i].Employeeid%>" /><label for="chkEmployee<%=i%>"><%=model.EmployeeList[i].Name%></label>
                                
                                <%
                              }
                               }
                               %>
                                
                            </td>
                          </tr>
                          <tr>
                            <td align="right" nowrap="nowrap" class="item_caption">
                              备注:</td>
                            <td align="left" class="item_content">
                              <textarea name="txtMemo" id="txtMemo" cols="95" rows="3"><%=model.CompensateUsedPaper.Memo%></textarea></td>
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
                      <asp:Button ID="btnSaveCompenstae" Text="保存" CssClass="buttons" OnClientClick="return doCheckProcess();" OnClick="SaveCompensate" runat="server" />
                        &nbsp;&nbsp;&nbsp;
                        <input name="btnCancel" class="buttons" value="取消" type="button" onclick="window.close();" /></td>
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
