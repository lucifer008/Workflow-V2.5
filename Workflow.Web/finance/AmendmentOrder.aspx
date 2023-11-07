<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AmendmentOrder.aspx.cs" Inherits="finance_AmendmentOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<head>
    <title>修正</title>
    <link href="../css/css.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery.js"></script>
    <script type="text/javascript" src="../js/default.js"></script>
    <script type="text/javascript" src="../js/check.js"></script>
    <script type="text/javascript" src="../js/math.js"></script>
    <script type="text/javascript" src="../js/finance/amendmentOrder.js"></script>
    <script type="text/javascript">
        var payType1=<%=Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE%>;//现金
        var payType2=<%=Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE%>;//记账
        var concessionMin=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.ConcessionMin %>;
        var concessionMax=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.ConcessionMax %>;
        var renderUpMin=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMin %>;
        var renderUpMax=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMax %>;
        var zeroMin=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.ZeroMin %>;
        var zeroMax=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.ZeroMax %>;
        var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
        var master=<%=Workflow.Support.Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
        var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
        var zeroAccreditTypeKey='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_ZERO_OUT_KEY %>';
        var zeroAccreditTypeText='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_ZERO_OUT_TEXT %>';
        var zeroAccreditTypeId=<%=Workflow.Support.Constants.GET_USER_OPERATE_ACCREDIT_ZERO_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;//抹零授权Id
        var concessionAccreditTypeKey='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_CONCESSION_KEY %>';
        var concessionAccreditTypeText='<%=Workflow.Support.Constants.USRE_ACCREDIT_TYPE_CONCESSION_TEXT %>';
        var concessionAccreditTypeId=<%=Workflow.Support.Constants.GET_USER_OPERATE_ACCREDIT_CONCESSION_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;//优惠授权Id
        var scotInverse=<%=scotInverse %>
    </script>
</head>
<body style="text-align:center">
    <form id="form1" runat="server">
    <div align="center" style="width: 99%" bgcolor="#ffffff" id="container">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
    <tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
		<td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
    </tr>
    <tr>
      <td colspan="3" bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td></td>
            <td align="left" bgcolor="#eeeeee">首页 -&gt; 财务处理 -&gt;修正</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">修正</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="2" cellspacing="1">
                <tr>
                  <td nowrap class="item_caption">订单号:</td>
                  <td class="item_content"><%=Request.QueryString["strNo"]%></td>
                  <td nowrap class="item_caption">客户名称:</td>
                  <td class="item_content"><%=Request.QueryString["strName"]%><input type="hidden" id="txtCustomerId" value="<%=Request.QueryString["customerId"] %>" /></td>
                </tr>
              </table></td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">
            <%
               int position = 0;
               decimal sumMoney = 0;
               decimal paperConsumeCount = 0;
              if (null != model.PriceFactor)
              { %>
                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                    <tr>
                        <th width="1%" nowrap="nowrap">&nbsp;NO&nbsp;</th>
                        <th width="1%" nowrap="nowrap">&nbsp;&nbsp;业务类型&nbsp;&nbsp;</th>
                        <%for (int i = 0; i < model.PriceFactor.Count; i++)
                        {
                            if (model.PriceFactor[i].IsDisplay.ToUpper() != Workflow.Support.Constants.TRUE) continue;
                            %>
                        <th nowrap="nowrap" class="w1" index="<%=i+2 %>" id="th<%=model.PriceFactor[i].Id %>">&nbsp;<%=model.PriceFactor[i].DisplayText%>&nbsp;</th>
                        <% } %>
                        <th nowrap="nowrap" class="w1">&nbsp;数量&nbsp;</th>
                        <th nowrap="nowrap" class="w1">&nbsp;单价&nbsp;</th>
                        <th nowrap="nowrap" class="w1">&nbsp;金额&nbsp;</th>
                        <th align="left" nowrap="nowrap">制作要求</th>
                    </tr>
                    <% 
                    for (int i = 0; i < model.OrderItem.Count; i++)
                    {%>
                    <tr class="detailRow">
                        <td class="center"><%=i + 1%></td>
                        <td class="left"><%=model.OrderItem[i].Name%></td>
                        <% 
                        int a = 0;
                        for (int k = 0; k < model.PriceFactor.Count; k++)
                        {
                            if (position >= model.OrderItemList.Count) break;
                            if (model.OrderItem[i].Id == model.OrderItemList[position].Id)
                            {
                                for (int n = position; n < model.OrderItemList.Count; n++)
                                {
                                    int m = 0;
                                    if (model.PriceFactor[k].Id == model.OrderItemList[n].PriceFactorId)
                                    { %>
                                            <td><%=model.OrderItemList[n].Name%></td>
                                            <%
                                        position++;
                                        m++;
                                        a++;
                                        break;
                                    }
                                    if (0 == m)
                                    {%>
                                        <td>-</td>  <%
                                        a++;
                                        break;
                                    }
                                }
                            }
                        }
                        if (a < model.PriceFactor.Count)
                        {
                            for (int b = 0; b < model.PriceFactor.Count - a; b++)
                            { %>
                                    <td>-</td>
                                 <%}
                             }
                           %>
                        <td><%paperConsumeCount += model.OrderItem[i].PaperConsumeCount; %>
                            <%=Workflow.Util.NumericUtils.ToMoney(model.OrderItem[i].Amount)%>
                        </td>
                        <td><%=Workflow.Util.NumericUtils.ToMoney(model.OrderItem[i].UnitPrice)%></td>
                        <td><%=Workflow.Util.NumericUtils.ToMoney((model.OrderItem[i].Amount * model.OrderItem[i].UnitPrice))%></td>
                        <td class="left">
                            <% string strPrint = "";
                               for (int j = 0; j < model.OrderItemPrintRequireDetail.Count; j++)
                               {
                                   if (model.OrderItem[i].Id == model.OrderItemPrintRequireDetail[j].OrderItemId)
                                   {
                                       strPrint += model.OrderItemPrintRequireDetail[j].Name + " ";
                                   }
                               }
                               strPrint = strPrint.Trim();
                               Response.Write(strPrint); 
                            %>
                        </td>
                    </tr>
                    <%sumMoney += (model.OrderItem[i].Amount - paperConsumeCount) * model.OrderItem[i].UnitPrice;
                      returnMoney = Math.Round(PrePayAmount - sumMoney, 2);
                      if (returnMoney < 0)
                          returnMoney = 0;
                  }%>
                    
                </table>
            <%} %>
             </td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="left">
            <div style="width:30%; float:left">
            <table id="txtInputMoney" width="60%" border="1" cellpadding="2" cellspacing="1">
                  <tr>
                    <td nowrap class="item_caption">现金总计:</td>
                    <td class="item_content" colspan="3"><input id="txtSumMoney" name="SumMoney"  type="text" class="num strikeTheEyeNormalChar" readonly="readonly" value='<%=Workflow.Util.NumericUtils.ToMoney(sumMoney)%>' /><input type="hidden" id="txtHiddenSumMoney"  name="hiddenSumMoney" value='<%=sumMoney %>' /></td>
                 </tr>
                  <tr>
                    <td  nowrap class="item_caption">已预收:&nbsp;&nbsp;</td>
                    <td class="item_content" colspan="3"><input id="txtPrepayMoney" name="PrepayMoney" class="num" type="text" readonly="readonly" value="<%=PrePayAmount %>"/><input id="realPrePayAmount" name="realPrePayAmount" type="hidden"/>
                       <%
                           if (PrePayAmount > 0)
                           { 
                               needMoney= Math.Round(sumMoney - PrePayAmount, 2);
                               %>
                               <input type="checkbox" id="isUsePrepay" name="usePrepay" value="Y" checked="checked" onclick="moneyChange();" /><label for="isUsePrepay">使用预收款</label>		
                               <%
                           }
                           else
                           {
                               needMoney = sumMoney;
                               %>
                               <input type="checkbox" id="isUsePrepay1" name="usePrepay" disabled="disabled" /><label for="isUsePrepay1">使用预收款</label>		
                               <%
                           }
                        %> 
                    </td>
                    </tr>
                  <tr id="trZero">
                    <td  nowrap class="item_caption">抹零:</td>
                    <td colspan="3" class="item_content"><input id="txtZeroMoney" name="ZeroMoney" onblur="moneyChange();" onkeyup="checkMoney()" readonly="readonly" type="text"  class="num" value="0" />
                    <a href="#" onclick="rasureTrail(3);">抹零</a>
                    </td>
                    </tr>
                 <tr id="trPreferent">
                    <td  nowrap class="item_caption" style="height: 29px">优惠:</td>
                    <td colspan="3" class="item_content" style="height: 29px"><input id="txtPreferentialMoney" name="PreferentialMoney" onkeyup="checkMoney()" readonly="readonly" onblur="moneyChange();" type="text"  class="num" value="0" />
                    <a href="#" onclick="preferentialMoney(4);">优惠</a>
                    </td>
                 </tr>
                 <tr>	
                    <td  nowrap class="item_caption">应收金额:</td>
                    <td class="item_content" nowrap><input id="txtReceivableMoney" name="ReceivableMoney" readonly="readonly" type="text" class="num" value="<%=Workflow.Util.NumericUtils.ToMoney(needMoney)%>" /></td>
                    <td  nowrap class="item_caption">付款方式:</td>
                    <td class="item_content"><select name="sltPayType" id="cbPaymentType" onchange="getCustomerPayType();" runat="server"></select></td>
                  </tr>

                  <tr id="trRealMoney">
                    <td  nowrap class="item_caption">实收金额: </td> 
                    <td class="item_content" colspan="3">
                        <input id="txtRealMoney" name="RealMoney" maxlength="14" type="text" class="num" value="0" onblur="moneyChange();" /><input type="hidden" id="txtRealAmount" name="realAmount"/>
                        <input id="chkCarryMoney" name="CarryMoney" type="checkbox" onclick="onCarryMoneyClick();"/><label id="lblCarryMoney" for="chkCarryMoney">舍入</label>
                    </td>
                  </tr>
                  <tr id="trGiveZero">
                    <td  nowrap class="item_caption">找零</td>
                    <td class="strikeTheEyeNormalChar item_content "><span style="color:Red" id="giveBack"></span></td>
                  </tr>
            </table>
            </div>
             <div style="width:40%" id="divGatheringInfo" style="display:none">
            <table style="width:100%">
                <tr>
                    <td style="width:40%;color:Red; font-size:large; font-weight:bold" id="tdAccCo">本次应收金额</td>
                    <td style="width:60%;font-size:large; font-weight:bold" id="tdAccountAmount">0</td>
                </tr>
                <tr>
                    <td style="width:40%;color:Red; font-size:large; font-weight:bold">本次冲减金额</td>
                    <td style="width:60%;font-size:large; font-weight:bold" id="tdPreAmountDiff">0</td>
                </tr>
                <tr>
                    <td style="width:40%;color:Red; font-size:large; font-weight:bold">本次抹零金额</td>
                    <td style="width:60%;font-size:large; font-weight:bold" id="tdZeroAmount">0</td>
                </tr>
                <tr>
                    <td style="width:40%;color:Red; font-size:large; font-weight:bold">本次优惠金额</td>
                    <td style="width:60%;font-size:large; font-weight:bold" id="tdConcessionAmount">0</td>
                </tr>
            </table>
            </div>      
            </td>
             <td width="3%">&nbsp;</td>	
          </tr>
			  <tr>
	            <td width="3%">&nbsp;</td>	
				<td align="left">
                <label id="lblRdbtN"><input type="radio"  class="radios" name="ticket" id="rdbtN" value="N" onclick="onTicketClick(this);" checked="checked" /> <label for="rdbtN">不欠发票</label></label>
                <label id="lblRdbtF"><input type="radio"  class="radios" name="ticket" id="rdbtF" value="F" onclick="onTicketClick(this);"/> <label for="rdbtF">无需给票</label></label>
                <label id="lblRdbtY"><input type="radio"  class="radios" name="ticket" id="rdbtY" value="Y" onclick="onTicketClick(this);"/> <label for="rdbtY">欠发票</label></label>
                <span id="sown" style="display:none; color:Red;">欠票金额:<input type="text" name="txtOweMoney" class="num" id="txtOweMoney" size="10" style="display:none;" value='0' onchange="moneyChange()"/>
                付票金额:<input type="text" name="txtPaidTicket" class="num" id="txtPaidTicket" size="10" style="display:none;" value='0'  onchange="moneyChange()"/>
                </span>
                <span id="spay" style="color:Red;">付票金额:<input type="text"  name="txtPayTicketMoney" class="num" id="txtPayTicketMoney" size="10" value="0" onchange="moneyChange()"/></span>
				</td>
	            <td width="3%">&nbsp;</td>	
			  </tr>	
			   <tr id="lblScot">
			    <td width="3%">&nbsp;</td>
			    <td align="left">
			        <label style="width:50%">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
			        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</label>
			        <label style="color:Green">税费:<input type="text" id="txtScotAmount" name="txtScotAmount" size="10" value="0" class="num" readonly="readonly"/></label></td>
			    <td width="3%">&nbsp;</td>
			    </tr>	
			  <tr>
	               <td width="3%">&nbsp;</td>	
				    <td align="center" class="bottombuttons">
                      <input type="button" class="buttons" id="btnOK" value="确定" onclick="return btnOkClick()"/>
                      <input name="btnReturnBack" type="button" id="btnReturnBack" class="buttons" onclick="window.close();" value="关闭" />
                      <input type="hidden" id="txtSubTag" name="subTag" value="0" />
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
    </tr>
    <tr>
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
		<td width="99%" bgcolor="#FFFFFF"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
    </tr>
  </table>
    </div>
    </form>
</body>
</html>
<script type="text/javascript">
<%if (closeFlag)
  {%>
  window.close();
  window.opener.navigate('SelectAmendmentOrder.aspx');
<%} %>
</script>
