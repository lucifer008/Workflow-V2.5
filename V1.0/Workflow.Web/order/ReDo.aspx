<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReDo.aspx.cs" Inherits="OrderReDo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>返工</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/json.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/escExit.js"></script>
<script type="text/javascript" src="../js/order/reDo.js"></script>
<script type="text/javascript">
    var strNo='<%=Request.QueryString["strNo"] %>';
    var strName='<%=Request.QueryString["strName"] %>';
</script>
<% if (closeFlag)
   {%>
    <script type="text/javascript">
        opener.location.reload();
        close();
    </script>
    <%} %>
    <base target="_self" />
</head>
<body  style="text-align:left">
<form id="form1" action="" method="post" runat="server">
<div align="left" style="width:99%" bgcolor="#ffffff"  id="container">
  <table width="400" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF"">
    <tr>
      <td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
      <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
      <td width="10"><img alt="" src="../images/white_main_top_right.gif"
			width="12" height="11"/></td>
    </tr>
    <tr>
      <td colspan="3" bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td></td>
            <td align="left" bgcolor="#eeeeee">首页->工单管理->本日工单->返工</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">返工</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="2" cellspacing="1" bgcolor="#FFFFFF">
                <tr>
                  <td nowrap class="item_caption">工单号:</td>
                  <td colspan="4" class="item_content"><span id='OrderNo'></span><input type="hidden" id="txtOrderNo" name="strOrderNo" /></td>
                </tr>
                <tr>
                  <td nowrap class="item_caption">客户名称:</td>
                  <td colspan="4" class="item_content"><span id='CustomerName'></span></td>
                </tr>
                <tr>
                  <td nowrap class="item_caption">责任人:</td>
                  <td colspan="2" class="item_content"><select id="sltDutyMan" name="DutyMan" multiple="multiple">
                  <% for (int i = 0; i < model.EmployeeList.Count; i++)
                     {
                         %>
                        <option value='<%=model.EmployeeList[i].Employeeid %>'><%= model.EmployeeList[i].Name%></option>
                  <%
                } %>                    </select>
                </td>
                <td nowrap="nowrap" class="item_caption">责任金额:</td><td><input type="text" id="txtDutyMoney" maxlength="9" name="strDutyMoney"/></td>
                </tr>
                <tr>
                  <td nowrap class="item_caption">前期:</td>
                  <td class="item_content"><div style="border:0px">
                  <% for (int i = 0; i < model.OrderItemEmployee.Count; i++)
                     {
                         //前期
                         if (model.OrderItemEmployee[i].PositionId == Workflow.Support.Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                         {%>
                        <p><%= model.OrderItemEmployee[i].Name %></p>
                  <%}
                } %>
                  </div></td>
                  <td class="item_content" colspan="4"><select id="prophase" name="sltProphase" multiple="multiple">
                <%
                      for (int i = 0; i < model.EmployeeList.Count; i++)
                      {
                          //前期
                          if (model.EmployeeList[i].Positionid == Workflow.Support.Constants.POSITION_PROPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                          {%>
                        
                        <option value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                <%}
              } %>
                                                      </select></td>
                </tr>
                <tr>
                  <td nowrap class="item_caption">后期:</td>
                  <td class="item_content"><div style="border:0px">
                  <% for (int i = 0; i < model.OrderItemEmployee.Count; i++)
                     {
                        //后期
                         if (model.OrderItemEmployee[i].PositionId == Workflow.Support.Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                        {%>
                        <p><%= model.OrderItemEmployee[i].Name %></p>
                  <%}
                } %>                  </div></td>
                  <td class="item_content" colspan="4"><select id="anaphase" name="sltAnaphase" size="3"  multiple="multiple">
                <%
                    for (int i = 0; i < model.EmployeeList.Count; i++)
                    {
                        //后期
                        if (model.EmployeeList[i].Positionid == Workflow.Support.Constants.POSITION_ANAPHASE_VALUE(Workflow.Support.ThreadLocalUtils.CurrentSession.CurrentUser.BranchShopId))
                        {%>
                        <option value='<%= model.EmployeeList[i].Employeeid %>'><%=model.EmployeeList[i].Name%></option>
                <%}
              }%>
                                                      </select></td>
                </tr>				
                <tr>
                  <td nowrap class="item_caption">返工原因:</td>
                  <td colspan="4" class="item_content"><textarea id="txtReason" cols="60" rows="3" name="strReason" class="textarea"></textarea></td>
                </tr>
              </table></td>
            <td width="3%">&nbsp;</td>
          </tr>
			<tr  class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>		  
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center" class="bottombuttons">
            <asp:Button ID="btnOk" runat="server" CssClass="buttons" OnClick="ReDoOk" OnClientClick="return dataCheck();"  Text="确定"/>
              &nbsp;<input type="button" name="Submit" value="关闭"  onclick="window.close()" class="buttons" />
            </td>
            <td width="3%">&nbsp;</td>
          </tr>
			<tr class="emptyButtonsUpperRowHight">
				<td colspan="3"></td>
			</tr>		  
          <tr height="5">
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
            <td bgcolor="#eeeeee">&nbsp;</td>
            <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"/></td>
          </tr>
        </table></td>
    <tr>
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
