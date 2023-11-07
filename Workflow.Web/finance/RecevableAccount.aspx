<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RecevableAccount.aspx.cs" Inherits="RecevableAccount" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
<title>应收款处理</title>
<link href="../css/css.css" rel="stylesheet" type="text/css" />
<script type="text/javascript" src="../js/jquery.js"></script>
<script type="text/javascript" src="../js/default.js"></script>
<script type="text/javascript" src="../js/check.js"></script>
<script type="text/javascript" src="../js/math.js"></script>
<script type="text/javascript" src="../js/dispatch.js"></script>
<script type="text/javascript" src="../js/arrearage.js"></script>

<script type="text/javascript">
var renderUpMin=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMin %>;
var renderUpMax=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.RenderUpMax %>;
var position=<%=Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.PositionId %>;
var master=<%=Workflow.Support.Constants.POSITION_SHOP_MASTER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
var manager=<%=Workflow.Support.Constants.POSITION_MANAGER_VALUE(Workflow.Support.ThreadLocalUtils.CurrentUserContext.CurrentUser.BranchShopId) %>;
var rendUpOutAccreditTypeKey='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_RENDUP_OUT_KEY %>';//折让超出范围授权类型标识Key
var rendUpOutAccreditTypeText='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_RENDUP_OUT_TEXT %>';//折让超出范围授权类型标识Text
var rendUpAccreditTypeKey='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_RENDUP_KEY %>';//折让授权类型标识Key
var rendUpAccreditTypeText='<%=Workflow.Support.Constants.USER_ACCREDIT_TYPE_RENDUP_TEXT %>';//折让授权类型标识Text
var scotInverse=<%=scotInverse %>
</script>
</head>
<body  style="text-align:center">
<form id="form1" action="" method="post" runat="server">
<div align="center" style="width:99%" bgcolor="#ffffff" id="container">
<input type="hidden" id="txtOrdersId" name="OrdersId" />
<input type="hidden" id="txtMoney" name="Money" />
<input type="hidden" id="txtAccMoney" name="txtAccMoney" />
<input type="hidden" id="actionTag" name="actionTag" value="False"/>
 <table width="100%" border="0" cellspacing="0" cellpadding="0">
	<tr>
		<td width="11"><img alt="" src="../images/white_main_top_left.gif"/></td>
		<td width="99%"  bgcolor="#ffffff"><img alt="" src="../images/spacer_10_x_10.gif" height="10"/></td>
		<td width="10"><img alt="" src="../images/white_main_top_right.gif" width="12" height="11"/></td>
	</tr>
    <tr>
     <td colspan="3" bgcolor="#FFFFFF"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td></td>
            <td align="left" bgcolor="#eeeeee">首页 -> 财务处理 -> 应收款处理</td>
            <td></td>
          </tr>
          <tr>
            <td></td>
            <td align="right" bgcolor="#eeeeee"></td>
            <td></td>
          </tr>
          <tr>
            <td colspan="3" class="caption" align="center">应收款处理</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">	
                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                   <tr>
                    <td nowrap class="item_caption">会员卡号:</td>
                    <td class="item_content"><input name="memberCardNo" id="txtMemberCardNo" type="text" class="texts" value="" onblur="return getCustomerInfo(event,this);" /></td>
                   </tr>
                  <tr>
                    <td nowrap class="item_caption">名称:</td>
                    <td class="item_content"><input name="textfield" id="txtCustomerName" type="text" class="texts" value="" />
                    <input type="button" class="buttons selectButtons" onclick="showSelectCustomer();" value="选择客户" />
                    <input type="hidden" id="txtCustomerId" name="CustomerId" />
                    </td>
                    </tr>
                </table>
            </td>
            <td width="3%">&nbsp;</td>
		</tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">	
             <div style="width:50%; float:left">  
                <table width="100%" border="1" cellpadding="2" cellspacing="1">
                  <tr>
                    <td colspan="2">该客户共有 <span id="arrearageNum" style="color:Red"></span> 笔欠款，总计: <span id="sumMoney" style="color:Red"></span> 元 </td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">应付:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="item_content"> <input id="txtShowPayMoney" readonly="readonly" style="color:Red" name="showPayMoney" type="text" value="0" class="num"  /><input id="txtSumMoney" name="sumMoney" type="hidden" value="0" /></td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">本次折让:&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="item_content"><input id="txtConcession" name="Concession" type="text" maxlength="14" onblur="onCurrentPayMoney();" value="0" readonly="true" class="num" />&nbsp;<a href="#" onclick="preferentialMoney(4);">折让</a></td>
                  </tr>
                  <tr>
                        <td  nowrap class="item_caption">已预存:</td>
                        <td class="item_content"><input id="txtPreDeposits" name="preDeposits" type="text" value="0" readonly="readonly" class="num"/><input id="cbUsePreDeposits" name="usePreDeposits" type="checkbox" onclick="onCurrentPayMoney();"/><input id="realUsePreDepositsAmount" name="realUsePreDepositsAmount" type="hidden" value="0"/><label for="cbUsePreDeposits">使用预存款</label></td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">本次支付:&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="item_content"> 
                        <input id="txtPayMoney" name="PayMoney" maxlength="14"  onchange ="onCurrentPayMoney();"  type="text" value="0" class="num"/>
                    </td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">找零</td>
                    <td class="item_content">
                        <span id="spPreDeposits" style="display:none">
                            <input type="text" id="txtSavePreDepositsAmount" name="savePreDepositsAmount" value="0" size="9"/>
                            <input  type="checkbox" id="cbSavePreDeposits" name="savePreDeposits" onclick="usePreDepositsClick();"/>
                            <label for="cbSavePreDeposits" style="color:Red">预存</label>
                      </span>
                    </td>
                  </tr>
                  <tr>
                    <td  nowrap class="item_caption">还欠:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td class="item_content"><input id="txtArrearage" name="Arrearage" type="text" readonly="readonly" value="0" class="num" /></td>
                  </tr>
                </table>
             </div>
            <div style="width:49%;display:none;float:left" id="divGatheringInfo">
                <table style="width:100%">
                    <tr>
                        <td colspan="2" style="width:40%;color:Red; font-size:large; font-weight:bold" id="td1">本次还款信息如下</td>
                    </tr>
                    <tr>
                        <td style="width:30%;color:Red; font-size:large; font-weight:bold" id="tdAccCo" align="right">实收金额：</td>
                        <td style="width:70%;font-size:large; font-weight:bold" id="tdAccountAmount" align="left">0</td>
                    </tr>
                    <tr>
                        <td style="width:30%;color:Red; font-size:large; font-weight:bold"  align="right">订单分配金额：</td>
                        <td style="width:70%;font-size:large; font-weight:bold" id="tdOrderDisAmount" align="left">0</td>
                    </tr>
                    <tr>
                        <td style="width:30%;color:Red; font-size:large; font-weight:bold" align="right">税费：</td>
                        <td style="width:70%;font-size:large; font-weight:bold" id="tdScotAmount" align="left">0</td>
                    </tr>
                    <tr>
                        <td style="width:30%;color:Red; font-size:large; font-weight:bold"  align="right">预存金额：</td>
                        <td style="width:70%;font-size:large; font-weight:bold" id="tdPreDospsitiAmount" align="left">0</td>
                    </tr>
                </table>
            </div>      			
             </td>
            <td width="3%">&nbsp;</td>
		    </tr>
		    <tr>
	            <td width="3%">&nbsp;</td>
                <td align="left">
                <input type="radio"  class="radios" name="ticket" id="rdbtN" onclick="onTicketClick(this)" checked="checked" /> <label for="rdbtN">不欠发票</label>
                <input type="radio"  class="radios" name="ticket" id="rdbtF" onclick="onTicketClick(this)"/> <label for="rdbtF">无需给票</label>
                <span id="spay" style="color:Red;">付票金额:<input type="text" id="txtPaidTicketAmount" name="txtPaidTicketAmount" class="num" size="10" value="0" onchange="onCurrentPayMoney()"/></span>
                <label id="lblScot" style="color:Green; display:none">税费:<input type="text" id="txtScotAmount" name="txtScotAmount" size="10" value="0" class="num" readonly="readonly"/></label>
                </td>
                <td width="3%">&nbsp;</td>
            </tr>
            <tr>
            <td width="3%">&nbsp;</td>
            <td>&nbsp;</td>
            <td width="3%">&nbsp;</td>
            </tr>
           <tr>
            <td width="3%">&nbsp;</td>
            <td align="left"><div style="float:left">以下是 <span style="color:Red" id="sCustomerName"></span>&nbsp;&nbsp;未支付完毕的订单，请分配本次交款</div>
            <div class="strikeTheEyeNormalChar" style="text-align:right;float:right">本次支付分配余额:<span style="color:Red" id="restMoney"></span></div></td>
            <td width="3%">&nbsp;</td>
          </tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">	
              <table id="tbList" width="100%" border="1" cellpadding="2" cellspacing="1">
                  <tr>
                    <th width="1%" nowrap></th>
                    <th width="1%" nowrap>&nbsp;NO&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;订单号&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;开单时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;结算时间&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;总额&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;优惠金额&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;抹零金额&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;折让金额&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;已付款额&nbsp;&nbsp;</th>
                    <th width="1%" nowrap>&nbsp;&nbsp;应收款额&nbsp;&nbsp;</th>
                    <th  align="center" nowrap>本次结欠</th>
                  </tr>
            </table>
          </td>
            <td width="3%">&nbsp;</td>
		</tr>
          <tr>
            <td width="3%">&nbsp;</td>
            <td align="center">
                <%--<asp:Button ID="btnOK" runat="server" CssClass="buttons" OnClick="Save" OnClientClick="return dataCheck();" Text="确定" />--%>
                <input type="button" id="btnOK" class="buttons" onclick="return dataCheck();" value="确定"/>
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
          </table>
		</td>
	</tr>
	<tr>
		<td width="11"><img alt="" src="../images/white_main_bottom_left.gif"/></td>
		<td width="99%" bgcolor="#ffffff"><img alt="" src="../images/spacer_10_x_10.gif"/></td>
		<td width="10"><img alt="" src="../images/white_main_bottom_right.gif"/></td>
	</tr>
  </table>
  </div>
</form>  
</body>
</html>
