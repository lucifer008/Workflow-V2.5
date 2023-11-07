<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayForOrder.aspx.cs" Inherits="PayForOrder" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>结算</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/math.js"></script>
<script type="text/javascript" src="../js/finance/finance.js"></script>
<script type="text/javascript">
    var payType1=<%=Workflow.Support.Constants.PAYMENT_TYPE_CASHER_GET_VALUE%>;
    var payType2=<%=Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE%>;
    var concessionMin=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.ConcessionMin %>;
    var concessionMax=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.ConcessionMax %>;
    var renderUpMin=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMin %>;
    var renderUpMax=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMax %>;
    var zeroMin=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.ZeroMin %>;
    var zeroMax=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.ZeroMax %>;
    var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
    var master=<%=Workflow.Support.Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
    var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
</script>
 <base target="_self" />
</head>
<body  style="text-align:center">
<form id="form1" method="post" action="" runat="server">
<input id="hiddMemberCardId" name="memberCardId" type="hidden" runat="server" />
<input id="hiddOrderId" name="orderId" type="hidden" runat="server" />
<input id="hiddPaperCount" name="paperCount" type="hidden"/>
<input id="hiddChargeAmout" name="chargeAmount" type="hidden"/>
<input id="hiddDiffAmount" name="diffAmount" type="hidden"/>
<div align="center" style="width:100%" bgcolor="#ffffff" id="container">
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
            <td align="left" bgcolor="#eeeeee">首页 -&gt; 财务处理 -&gt;结算</td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">结算</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center"><table width="100%" border="1" cellpadding="2" cellspacing="1">
                <tr>
                  <td nowrap class="item_caption">工单号:</td>
                  <td class="item_content"><%=Request.QueryString["strNo"]%></td>
                  <td nowrap class="item_caption">客户名称:</td>
                  <td class="item_content"><%=Request.QueryString["strName"]%><input type="hidden" id="txtCustomerId" value="<%=Request.QueryString["customerId"] %>" /></td>
                </tr>
              </table></td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">
                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                    <tr>
                        <th width="1%" nowrap="nowrap">&nbsp;NO&nbsp;</th>
                        <th width="1%" nowrap="nowrap">&nbsp;&nbsp;业务类型&nbsp;&nbsp;</th>
                        <% for (int i = 0; i < model.PriceFactor.Count; i++)
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
                       int position = 0;
                       decimal sumMoney = 0;
                       decimal paperConsumeCount = 0;
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
                                        {
                                            //if()
                                            %>
                                            <td><%=model.OrderItemList[n].Name%></td>
                                            <%
                                                position++;
                                                m++;
                                            a++;
                                            break;
                                        }
                                        if(0==m)
                                        {%>
                                           <td>-</td>  
                                        <%
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
                    <%sumMoney += (model.OrderItem[i].Amount - paperConsumeCount) * model.OrderItem[i].UnitPrice ;
                      returnMoney = Math.Round(PrePayAmount - sumMoney, 2);
                      if (returnMoney < 0)
                          returnMoney = 0;
                    }%>
                </table>
             </td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="left"><table id="txtInputMoney" width="60%" border="1" cellpadding="2" cellspacing="1">
              <tr>
                <td nowrap class="item_caption">现金总计:</td>
                <td class="item_content"><input id="txtSumMoney" name="SumMoney"  type="text" class="num strikeTheEyeNormalChar" readonly="readonly" value='<%=Workflow.Util.NumericUtils.ToMoney(sumMoney)%>' /><input type="hidden" id="txtHiddenSumMoney"  name="hiddenSumMoney" value='<%=sumMoney %>' /></td>
                <td nowrap class="item_caption">是否冲减印章:</td>
                <td><input id="useSavePaper" name="useSavePaper" disabled="true" type="checkbox" onchange="return isNotSelectedDiffPaper();" /></td>
             </tr>
              <tr>
                <td  nowrap class="item_caption">已预收:&nbsp;&nbsp;</td>
                <td class="item_content"><input id="txtPrepayMoney" name="PrepayMoney" class="num" type="text" readonly="true" value="<%=PrePayAmount %>"/><input id="realPrePayAmount" name="realPrePayAmount" type="hidden"/>
                    <br />
                   <%
                       if (PrePayAmount > 0)
                       { 
                           needMoney= Math.Round(sumMoney - PrePayAmount, 2);
                           %>
                           <input type="checkbox" id="isUsePrepay" name="usePrepay" value="Y" checked="true" onclick="realMoneyChange();" /><label for="isUsePrepay">使用预收款</label>		
                           <%
                       }
                       else
                       {
                           needMoney = sumMoney;
                           %>
                           <input type="checkbox" id="isUsePrepay1" name="usePrepay" disabled="true" /><label for="isUsePrepay1">使用预收款</label>		
                           <%
                       }
                    %> 
                </td>
                <td nowrap class="item_caption">本次冲减印张数:</td>
                <td class="item_content"><input type="text" id="txtUseSavePaperCounter" name="UseSavePaperCounter" disabled="true" size="10" maxlength="12" value="<%=paperConsumeCount %>" onblur ="return paperCountChange();" /></td>
                </tr>
                <tr id="trPreDeposits">
                    <td nowrap class="item_caption">已预存:</td>
                    <td class="item_content" colspan="3">
                        <input id="txtPreDeposits" name="UsePreDeposits" type="text" class="num" readonly="readonly" value="<%=preDeposit %>"/><input id="realPreDepositsAmount" name="realPreDepositsAmount" type="hidden"/>
                        <%if (preDeposit>0)
                        {
                              needMoney=Math.Round(sumMoney-preDeposit,2);
                               %>
                               <input type="checkbox" id="cbIsUsePreDeposits" name="isUsePreDeposits" value="Y" checked="checked" onclick="realMoneyChange();" /><label for="cbIsUsePreDeposits">使用预存款</label>
                        <%} else{%>
                               <input type="checkbox" id="cbNotUsePreDeposits" name="isUsePreDeposits" disabled="disabled"/><label for="NotUsePreDeposits">使用预存款</label>
                        <%} %>
                    </td>
                </tr>
              <tr id="trZero">
                <td  nowrap class="item_caption">抹零:</td>
                <td colspan="3" class="item_content"><input id="txtZeroMoney" name="ZeroMoney" onblur="realMoneyChange();" readonly="true" type="text"  class="num" value="0" />
                  <a href="#" onclick="rasureTrail(3);">抹零</a>
                </td>
                </tr>
                <%if(model.NewOrder.PayType==Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE){ %>
              <tr name='trAcc'>
                <td  nowrap class="item_caption">挂账:</td>
                <td colspan="3" class="item_content"><input id="txtAcc" name="AccountMoney"  type="text"  class="num" readonly="true"  value="0" /></td>
                </tr>
                <%
                    this.cbPaymentType.Value = Workflow.Support.Constants.PAYMENT_TYPE_ACCOUNT_GET_VALUE.ToString();
                  } %>
             <tr>
                <td  nowrap class="item_caption">优惠:</td>
                <td colspan="3" class="item_content"><input id="txtPreferentialMoney" name="PreferentialMoney" onblur="realMoneyChange();" readonly="true" type="text"  class="num" value="0" />
                  <a href="#" onclick="preferentialMoney(4);">优惠</a>
                </td>
             </tr>			  
              <tr>
                <td  nowrap class="item_caption">应收金额:</td>
                <td class="item_content" nowrap><input id="txtReceivableMoney" name="ReceivableMoney" readonly="true" type="text" class="num" value="<%=Workflow.Util.NumericUtils.ToMoney(needMoney)%>" /></td>
                <td  nowrap class="item_caption">付款方式:</td>
                <td class="item_content"><select name="sltPayType" id="cbPaymentType" runat="server" onchange="getCustomerPayType();"></select></td>
              </tr>

              <tr>
                <td  nowrap class="item_caption">实收金额: </td> 
                <td class="item_content" colspan="3">
                    <input id="txtRealMoney" name="RealMoney" maxlength="14" onblur="realMoneyChange();" type="text" class="num" value="0" /><input id="realAmount" name="realAmount" type="hidden"/>
                    <input id="chkCarryMoney" name="CarryMoney" type="checkbox"  onclick="onCarryMoneyClick();" /><label id="lblCarryMoney" for="chkCarryMoney">舍入</label>
                </td>
              </tr>
              <tr>
                <td  nowrap class="item_caption">找零</td>
                <td class="strikeTheEyeNormalChar item_content "><span style="color:Red" id="giveBack">0</span><input id="txtReturnMoney" name="returnMoney" type="hidden" value="0" /></td>
                <td  nowrap colspan="2"><input id="cbPreSaveMoney" name="preSaveMoney" type="checkbox" onclick="preDepositCheck(this);"/><label for="cbPreSaveMoney">预存</label><input id="preDepositAmount" name="preDepositAmount" type="hidden"/><input type="text" id="otherPreDepositAmount" name="otherPreDepositAmount" size="10" value="0" visible="false"/></td>
              </tr>
            </table></td>
          </tr>
			  <tr>
	            <td width="3%">&nbsp;</td>	
				<td align="left">
                <input type="radio"  class="radios" name="ticket" id="rdbtN" value="N" onclick="onTicketClick(this);" checked="true" /> <label for="rdbtN">不欠发票</label>
                <input type="radio"  class="radios" name="ticket" id="rdbtF" value="F" onclick="onTicketClick(this);"/> <label for="rdbtF">无需给票</label>
                <input type="radio"  class="radios" name="ticket" id="rdbtY" value="Y" onclick="onTicketClick(this);"/> <label for="rdbtY">欠发票</label>
                <span id="sown" style="display:none; color:Red;">欠票金额:<input type="text" name="txtOweMoney" class="num" id="txtOweMoney" size="10" style="display:none;" value='0' onblur='onOwnTicket();' />
                付票金额:<input type="text" name="txtPaidTicket" class="num" id="txtPaidTicket" size="10" style="display:none;" value='0' />
                </span>
                <span id="spay" style="color:Red;">付票金额:<input type="text"  name="txtPayTicketMoney" class="num" id="txtPayTicketMoney" size="10" value="0" /></span>
				</td>
	            <td width="3%">&nbsp;</td>	
			  </tr>	
			  <tr>
	               <td width="3%">&nbsp;</td>	
				    <td align="center" class="bottombuttons">
                      <input type="button" class="buttons" id="btnOK" onclick="return dataCheck();" value="确定" />
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
  <% if (closeFlag)
   {%>
    <script type="text/javascript">
        opener.rValue='true';
        window.close();
        //window.navigate('selectOrder.aspx');
    </script>
<%} %> 
