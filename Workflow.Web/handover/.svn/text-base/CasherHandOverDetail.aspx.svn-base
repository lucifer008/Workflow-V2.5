<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CasherHandOverDetail.aspx.cs" Inherits="handover_CasherHandOverDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Import Namespace="Workflow.Da.Domain" %>
<%@ Import Namespace="Workflow.Support" %>
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>收银交班交班详情</title>
  <link href="../css/css.css" rel="stylesheet" type="text/css" />
  <script type="text/javascript" src="../js/check.js"></script>
  <script type="text/javascript" language="javascript" src="../js/jquery.js"></script>
  <script type="text/javascript" language="javascript" src="../js/default.js"></script>
  <script type="text/javascript" language="javascript" src="../js/escExit.js"></script>
</head>
<body style="text-align: center">
  <form id="MainForm" method="post" runat="server">
  <input type="hidden" name="handOverId" value="<%=Request.QueryString["HandOverId"]%>" />
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
                      <td align="left" bgcolor="#eeeeee">首页 -&gt; 交班管理 -&gt; 收银交班交班详情</td>
                      <td></td>
                    </tr>
                    <tr><td colspan="3" class="caption" align="center">收银交班交班详情</td></tr>
                    <tr>
                      <td width="3%">&nbsp;</td>
                      <td align="left">
                        <table width="100%" border="1" cellpadding="3" cellspacing="1">
                          <tr>
                            <td nowrap="nowrap" class="item_caption">交接日期:</td>
                            <td class="item_content"><%=handOverDet.HandOverDateTime.ToShortDateString() %><input type="hidden" name="handOverDate" value="<%=handOverDet.HandOverDateTime.ToShortDateString() %>" /></td>
                            <td nowrap="nowrap" class="item_caption">时间:</td>
                            <td class="item_content"><%=handOverDet.HandOverDateTime.ToString("HH:mm") %><input type="hidden" name="handOverDateTime" value="<%=handOverDet.HandOverDateTime.ToString("HH:mm") %>" /></td>
                          </tr>
                          <tr>
                            <td nowrap="nowrap" class="item_caption">交班人</td>
                            <td align="left" class="item_content"><%=handOverDet.HandOverPerson %><input type="hidden" name="handOverPerson" value="<%=handOverDet.HandOverPerson %>" /></td>
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
                             <td class="item_caption" style="text-align: center">No</td>
                             <td align="center" nowrap="nowrap" colspan="4" class="item_caption" style="text-align: center">款项详情</td>
                          </tr>
                          <tr>
                          <td align="center" style="background-color:#d6dfef">1</td>
                           <td width="30%" align="center">发票金额</td>
                            <td colspan="3" class="num"><%= Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.TicketAmountSum) %>
                              <input name="txtTicketAmountSum" value="<%=model.CashHandOver.TicketAmountSum%>" type="hidden" />
                            </td>
                          </tr>
                          <tr>
                            <td align="center" rowspan="<%=model.OrderList.Count+2%>" style="background-color:#d6dfef">2</td>
                            <td rowspan="<%=model.OrderList.Count+2%>" align="center"><p>预付款</p></td>
                            <td width="20%" align="center">订单号</td>
                            <td width="20%" align="center">预付款</td>
                            <td width="20%" align="center">备注</td>
                          </tr>
                          <%
                              decimal preTotal = 0;
                            foreach (Order var in model.OrderList)
                            {
                                preTotal += var.PrepareMoneyAmount;
                          %>
                          <tr>
                            <td align="center"><%=var.No %></td>
                            <td align="left" class="num"><%=var.PrepareMoneyAmount%></td>
                            <td class="num"><%=var.Memo%></td>
                          </tr>
                          <%
                            } %>
                          <tr>
                              <td></td>
                              <td></td>
                          </tr>
                          <tr>
                            <td align="center" style="background-color:#d6dfef">3</td>
                            <td align="center"><p>结款</p></td>
                            <td align="center">共<%=model.CashHandOver.PayForCount%>单</td>
                            <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.PayForAmountSum)%></td>
                            <td class="num"><%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.PayForAmountSum)%></td>
                          </tr>
                          <tr>
                            <td align="center" style="background-color:#d6dfef">4</td>
                            <td align="center">记帐合计</td>
                            <td align="right" colspan="3" nowrap="nowrap"><%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.KeepBusinessRecordAmountSum)%></td>
                            
                          </tr>
                           <tr>
                            <td align="center" style="background-color:#d6dfef">4</td>
                            <td align="center">会员卡充值金额合计</td>
                            <td align="right" colspan="3" nowrap="nowrap"><%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.MemberCardChargeAmount)%><input name="txtMemberChargeAmount" type="hidden" value="<%=model.CashHandOver.MemberCardChargeAmount%>" /></td>
                          </tr>
                          <tr>
                            <td align="center" style="background-color:#d6dfef">5</td>
                            <td align="center">欠条合计</td>
                            <td align="left" nowrap="nowrap" class="num"><%--欠条合计共<%=model.CashHandOver.DebtCount%>--%>张</td>
                            <td align="left" nowrap="nowrap" colspan="2" class="num">欠款合计<%--<%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.DebtAmountSum)%>--%></td>
                          </tr>
                          <tr>
                            <td align="center" style="background-color:#d6dfef">6</td>
                            <td align="center" nowrap="NOWRAP" bgcolor="#FFFFFF">备用金</td>
                            <td align="right" colspan="4"><%--<%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.StandbyAmount)%>--%></td>
                          </tr>
                          <tr>
                            <td align="center" nowrap="nowrap" bgcolor="#FFFFFF" style="text-align: center" style="background-color:#d6dfef">
                              <p>其</p>
                              <p>他</p>
                            </td>
                            <td colspan="4" align="left" nowrap="nowrap">
                              <p>
                                <textarea name="textarea" cols="95" rows="3" style="width: 100%">
                                    
                                </textarea>
                              </p>
                            </td>
                          </tr>
                           <tr>
                             <td class="item_caption">本次交班合计</td>
                             <td  colspan="4" style=" color:Red;">
                             发票金额:<%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.TicketAmountSum)%>
                             预收款:<%=Workflow.Util.NumericUtils.ToMoney(preTotal) %>
                             记账:<%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.KeepBusinessRecordAmountSum)%>
                             结款:<%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.PayForAmountSum)%>
                             会员卡充值金额:<%=Workflow.Util.NumericUtils.ToMoney(model.CashHandOver.MemberCardChargeAmount)%>
                             欠条:
                             备用金:
                            </td>
                         </tr>
                        </table>
                      </td>
                      <td width="3%">&nbsp;</td>
                    </tr>
                    <tr class="emptyButtonsUpperRowHight"><td colspan="3"></td></tr>
                    <tr>
                      <td colspan="3" align="center" class="bottombuttons">
                        <asp:Button ID="btnSaveCashHandOver" runat="server" CssClass="buttons" Text="打印" OnClick="btnPrintClick" />  
                        <input type="button" name="btnClose" value="关闭" onclick="window.close();" class="buttons" />                      
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
