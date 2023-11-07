<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StageHandOver.aspx.cs" Inherits="StageHandOver" %>

<%@ Import Namespace="Workflow.Da.Domain" %>
<%@ Import Namespace="Workflow.Support" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
  <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
  <title>前台交班</title>
   <link href="../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
  <script type="text/javascript" language="javascript" src="../js/default.js"></script>
  <script type="text/javascript" src="../js/handover/stageHandOver.js"></script>
  <script type="text/javascript" src="../js/escExit.js"></script>
  <base target="_self" />
</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
  <input name="handOverOtherPeople" id="hiddHandOverOtherPeople" type="hidden" value="" runat="server"/>
    <input name="txtHandOverId" id="txtHandOverId" type="hidden" value="<%=lngHandOverId%>" />
    <div align="center" style="width: 99%;background-color:#ffffff"  id="container">
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
                      <td align="left" bgcolor="#eeeeee">首页 -&gt; 交班管理 -&gt; 前台交班</td>
                      <td></td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">前台交班</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="left">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <td nowrap="nowrap" class="item_caption">交接日期:</td>
                            <td class="item_content"><%=System.DateTime.Now.ToShortDateString() %></td>
                            <td nowrap="nowrap" class="item_caption">时间:</td>
                            <td class="item_content"><%=System.DateTime.Now.ToShortTimeString()%><input type="hidden" name="handOverDate" id="hiddHandOverDate" value="<%=System.DateTime.Now.ToShortTimeString()%>"/></td>
                          </tr>
                          <tr>
                            <td nowrap="nowrap" class="item_caption">交班人签字:</td>
                            <td align="left" class="item_content"><%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.EmployeeName%></td>
                            <td nowrap="nowrap" class="item_caption">接班人签字:</td>
                            <td class="item_content">
                              <select name="sleEmployee" id="sleEmployee">
                                <option value="-1">请选择</option>
                                <%
                                  foreach (Employee var in model.EmployeeList)
                                  {
                                    if (var.Employeeid != Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.Id)
                                    {
                                %>
                                <option value="<%=var.Id%>">
                                  <%=var.Name%>
                                </option>
                                <%
                                    }
                                  }
                                %>
                              </select>
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td width="3%">&nbsp;</td>
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
                            <td colspan="2" align="right" class="item_caption">新办会员卡</td>
                            <td colspan="8" align="left"><%=strMemberCardList%></td>
                          </tr>
                               <%
                              int rowS = 0;
                              if (0 == model.OrderList.Count)
                              {
                                  rowS = 2;
                              }
                              else 
                              {
                                  rowS = model.OrderList.Count + 1;
                              }
                           %>
                          <tr>
                            <td width="1%" rowspan="<%=rowS%>" align="center" nowrap="nowrap" style="text-align: center" class="item_caption">已转单</td>
                            <th width="1%" nowrap="nowrap">工单号</th>
                            <th width="1%" nowrap="nowrap">客户名称</th>
                             <th width="1%" nowrap="nowrap">工单状态</th> 
                            <th width="1%" nowrap="nowrap">开单时间</th>
                            <th width="1%" nowrap="nowrap">取送方式</th>
                            <th width="20%" colspan="2" nowrap="nowrap">送货时间</th>
                            <th nowrap="nowrap">备注</th>
                          </tr>
                          <%if (model.OrderList.Count==0){%>
                          <tr>
                          <td colspan="8" style="color:Blue">目前没有可交接的工单</td>
                          </tr>
                          <%}%>
                          
                          <%
                            int spancount = 0;
                            int span = 1,index=1;  
                            
                            foreach (Order var in model.OrderList)
                            {
                              //获取var.Status有几个
                              if (spancount == 0)
                              {
                                foreach (Order varspan in model.OrderList)
                                {
                                  if (varspan.Status == var.Status) spancount += 1;
                                }
                                span = spancount;
                              }
                          %>
                          <tr>
                           <%-- <%if (span > 0) {%>

                            <td width="10%" align="center"  rowspan="<%=span %>"><%=Constants.GetOrderStatus(var.Status)%></td>
                            <%} span = 0; spancount -= 1; %>--%>
                              
                            <td nowrap="nowrap"><a href="#" onclick="orderDetail('<%=var.No%>');"><%=var.No%></a></td>
                            <td nowrap="nowrap"><%=var.CustomerName%></td>
                            <td nowrap="nowrap"><%=Constants.GetOrderStatus(var.Status)%></td>
                            <td nowrap="nowrap"><%=var.InsertDateTime.ToString("yyyy-MM-dd HH:mm")%></td>
                            <td align="center" nowrap="nowrap"><%=Constants.GetDeliveryType(var.DeliveryType)%></td>
                            <%
                                string strDeliveryDate = "";
                                if (null != var.DeliveryDateTime && "9999-12-31" != var.DeliveryDateTime.ToString("yyyy-MM-dd"))
                                {
                                    strDeliveryDate =var.DeliveryDateTime.ToString("yyyy-MM-dd HH:mm");
                                }
                                 %>
                            <td colspan="2" align="center" nowrap="nowrap"><%=strDeliveryDate%></td>
                            <td colspan="3" align="left"><%=var.Memo%>&nbsp;</td>
                          </tr>
                          <%
                              index++;  
                            } 
                          %>
                          <tr>
                            <td align="center" bgcolor="#FFFFFF" style="text-align: center" class="item_caption">
                              <p>其</p>
                              <p>他</p>
                            </td>
                            <td colspan="9" bgcolor="#FFFFFF">
                              <p>
                                <textarea name="txtMemo" id="txtMemo" cols="95" rows="3" style="width: 100%">
                                    
                                </textarea>
                              </p>
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                    <tr>
                      <td colspan="3" align="center" class="bottombuttons">
                        <asp:Button ID="btnSaveStageHandOver" CssClass="buttons" runat="server" Text="保存&amp;打印" OnClientClick="return saveStageHandOver();" OnClick="SaveStageHandOver" />
                        <input type="button" name="btnClose" class="buttons" onclick="window.close();" value="关闭" />
                      </td>
                    </tr>
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
          <td width="11"><img alt="" src="../images/white_main_bottom_left.gif"></td>
          <td width="99%"><img alt="" src="../images/spacer_10_x_10.gif"></td>
          <td width="10"><img alt="" src="../images/white_main_bottom_right.gif"></td>
        </tr>
      </table>
    </div>
  </form>
</body>
</html>
