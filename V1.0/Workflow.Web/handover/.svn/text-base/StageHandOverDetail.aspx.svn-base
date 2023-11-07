<%@ Page Language="C#" AutoEventWireup="true" CodeFile="StageHandOverDetail.aspx.cs" Inherits="handover_StageHandOverDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="Workflow.Da.Domain" %>
<%@ Import Namespace="Workflow.Support" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>前台交班详情</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../js/check.js"></script>
  <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
  <script type="text/javascript" language="javascript" src="../js/default.js"></script>
  <script type="text/javascript" language="javascript" src="../js/escExit.js"></script>
</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
  <input type="hidden" name="handOverId" value="<%=Request.QueryString["HandOverId"]%>" />
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
                      <td align="left" bgcolor="#eeeeee">首页 -&gt; 交班管理 -&gt; 前台交班详情</td>
                      <td></td>
                    </tr>
                    <tr>
                      <td colspan="3" class="caption" align="center">前台交班详情</td>
                    </tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="left">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <td nowrap="nowrap" class="item_caption">交接日期:</td>
                            <td class="item_content"><%=handOverDet.HandOverDateTime.ToShortDateString() %><input type="hidden" name="handOverDate" value="<%=handOverDet.HandOverDateTime.ToShortDateString() %>" /></td>
                            <td nowrap="nowrap" class="item_caption">时间:</td>
                            <td class="item_content"><%=handOverDet.HandOverDateTime.ToString("HH:mm")%><input type="hidden" name="handOverDateTime" value="<%=handOverDet.HandOverDateTime.ToString("HH:mm") %>" /></td>
                          </tr>
                          <tr>
                            <td nowrap="nowrap" class="item_caption">交班人</td>
                            <td align="left" class="item_content"><%=handOverDet.HandOverPerson%><input type="hidden" name="handOverPerson" value="<%=handOverDet.HandOverPerson %>" /></td>
                            <td nowrap="nowrap" class="item_caption">接班人</td>
                            <td class="item_content"><%=handOverDet.OtherHandOverPerson %><input type="hidden" name="handOverOtherPerson" value="<%=handOverDet.OtherHandOverPerson %>" /></td>
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
                            <td colspan="8" align="left"><%=strMem%><input type="hidden" name="handOverMemberCard" value="<%=strMem %>" /></td>
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
                            <td width="1%" align="center" nowrap="nowrap" style="text-align: center" rowspan="<%=rowS %>" class="item_caption">已转单</td>
                            <th width="1%" nowrap="nowrap">工单号</th>
                            <th width="1%" nowrap="nowrap">客户名称</th>
                            <th width="1%" nowrap="nowrap">工单状态</th>
                            <th width="1%" nowrap="nowrap">开单时间</th>
                            <th width="1%" nowrap="nowrap">取送方式</th>
                            <th width="20%" colspan="2" nowrap="nowrap">送货时间</th>
                            <th nowrap="nowrap">备注</th>
                          </tr>
                          <%
                             if (model.OrderList.Count==0)
                             {
                                  %>
                          <tr>
                          <td colspan="8" style="color:Blue">没有交接工单的信息</td>
                          </tr>
                          <%
                             }
                               %>
                          
                          <%
                            int spancount = 0;
                            int span = 1,index=1;  
                            %>
                          
                            <%
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
                            <td nowrap="nowrap"><%=var.No%></td>
                            <td nowrap="nowrap"><%=var.CustomerName%></td>
                            <td nowrap="nowrap"><%=Constants.GetOrderStatus(var.Status)%></td>
                            <td nowrap="nowrap"><%=var.InsertDateTime%></td>
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
                                <textarea name="txtMemo" id="txtMemo" cols="95" rows="3" style="width: 100%"></textarea>
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
                        <asp:Button ID="btnPrint" CssClass="buttons" runat="server" Text="打印" OnClick="btnPrintClick" />
                        <input type="button" class="buttons" name="btnClose" onclick="window.close();" value="关闭"/>
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
