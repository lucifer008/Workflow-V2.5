<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchHandOver.aspx.cs" Inherits="SearchHandOver" %>
<%@ Register Assembly="AspNetPager" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Workflow.Da.Domain" %>
<%@ Import Namespace="Workflow.Support" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>交班查询</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../js/check.js"></script>
  <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
  <script type="text/javascript" language="javascript" src="../js/default.js"></script>
  <script type="text/javascript" src="../js/checkCalendar.js"></script>
  <script type="text/javascript" src="../js/Calendar2.js"></script>
  <script type="text/javascript" language="javascript" src="../js/handover/searchHandOver.js"></script>
</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
      <table width="100%" border="0" cellspacing="0" cellpadding="0" bgcolor="#FFFFFF">
        <tr>
          <td width="11"><img alt="" src="../images/white_main_top_left.gif"></td>
          <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif" height="10"></td>
          <td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"></td>
        </tr>
        <tr>
          <td colspan="3" bgcolor="#FFFFFF">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td bgcolor="#FFFFFF">
                  <table width="100%" border="0" cellspacing="0">
                    <tr>
                      <td></td>
                      <td align="left" bgcolor="#eeeeee">首页 -&gt; 交班管理 -&gt; 交班查询</td>
                      <td></td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">交班查询</td>
                    </tr>
                    <tr>
                      <td>&nbsp;</td>
                      <td align="left">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <td nowrap="nowrap" class="item_caption">交接日期:</td>
                            <td colspan="3" class="item_content">
                                <div>
                                  <input type="text" class="datetimetexts" id="txtBeginDate" name="txtBeginDate" size="16" onfocus="setday(this)" maxlength="16" readonly="readonly" />至
                                  <input type="text" class="datetimetexts" id="txtEndDate" name="txtEndDate"  size="16" maxlength="16" onfocus="setday(this)" readonly="readonly"/ >
                                </div>
                            </td>
                          </tr>
                          <tr>
                            <td nowrap="nowrap" class="item_caption">部门:</td>
                            <td align="left" class="item_content">
                              <select name="sltPosition">
                                <option value="-1">请选择</option>
                                <%
                                    if (null != model.PositionList)
                                    {
                                        foreach (Position var in model.PositionList)
                                        { 
                                %>
                                <option value="<%=var.Id%>"><%=var.Name%></option>
                                <%
                                    }
                                }
                                %>
                              </select>
                            </td>
                            <td nowrap="nowrap" class="item_caption">交班人:</td>
                            <td class="item_content">
                              <select name="sltHandOverPerson">
                                <option value="-1">请选择</option>
                                <%
                                    if (null != model.EmployeeList)
                                    {
                                        foreach (Employee var in model.EmployeeList)
                                        { 
                                %>
                                <option value="<%=var.Id%>"><%=var.Name%></option>
                                <%
                                    }
                                }
                                %>
                              </select>
                            </td>
                          </tr>
                          <tr class="querybuttons">
                            <td colspan="4" nowrap="nowrap">
                             <asp:Button ID="btnQuery" runat="server" Text="查询" CssClass="buttons" OnClick="QueryProcess" OnClientClick="return QueryProcess();" />
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td>&nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight">
                      <td></td>
                      <td align="center"></td>
                      <td></td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="center">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <th width="10%" nowrap="nowrap">&nbsp;NO&nbsp;</th>
                            <th width="10%" nowrap="nowrap">交班类型</th>
                            <th width="10%" nowrap="nowrap">交班人</th>
                            <th width="10%" nowrap="nowrap">接班人</th>
                            <th width="1%" nowrap="nowrap">交班时间</th>
                            <th nowrap="nowrap">备注</th>
                            <th width="1%" nowrap="nowrap">&nbsp;</th>
                          </tr>
                        <%
                          if(null!=model.HandOverList)
                          {
                              int intCount = 0;
                              foreach (HandOver var in model.HandOverList)
                              { 
                                %>
                              <tr class="detailRow">
                                <td align="center"><%=++intCount%><input type="hidden" id="handOverId" name="handOverId" value="<%=var.Id %>" /></td>
                                <td align="center"><%=Constants.GetHandOverType(var.HandOverType)%></td>
                                <td align="center"><%=var.HandOverPerson%></td>
                                <td align="center"><%=var.OtherHandOverPerson%></td>
                                <td nowrap="nowrap" class="tdHandOverDateTime"><%=Convert.ToDateTime(var.HandOverDateTime).ToString("yyyy-MM-dd HH:mm")%></td>
                                <td align="left"><%=var.Memo%></td>
                                <%
                                  if (var.HandOverType == Constants.HANDER_OVER_FRONT.ToString())
                                  {
                                      %>
                                <td nowrap="nowrap"><a href="#" onclick="displayStageHandOverDetail(this)">详细</a></td>
                                    <%
                                  }
                                else
                                  {
                                       %>
                                <td nowrap="nowrap"><a href="#" onclick="displayCasherHandOverDetail(this)">详细</a></td>
                                  <%
                                      
                                  }
                                %>
                              </tr>
                              <%
                              } %>
                               <tr>
                                 <td bgcolor="#eeeeee" align="right" colspan="7">
                                       <webdiyer:AspNetPager ID="AspNetPager1" runat="server" OnPageChanging="AspNetPager1_PageChanging">
                                        </webdiyer:AspNetPager>
                                 </td>
                              </tr> 
                          <%} %>
                        </table>
                      </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                    <tr height="5">
                      <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                        <td bgcolor="#eeeeee">&nbsp;</td>
                      <td><img alt="" src="../images/spacer_5_x_5.gif" width="5" height="5"></td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
        <tr>
          <td width="11"> <img alt="" src="../images/white_main_bottom_left.gif"></td>
          <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"></td>
          <td width="10"><img alt="" src="../images/white_main_bottom_right.gif"></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
